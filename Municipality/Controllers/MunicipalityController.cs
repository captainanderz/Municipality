using System.Globalization;
using AutoMapper;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using MunicipalityProject.Business.Models;
using MunicipalityProject.Services;

namespace MunicipalityProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipalityController : ControllerBase
    {
        private readonly IMunicipalityService _municipalityService;
        private readonly IMapper _mapper;
        private readonly ILogger<MunicipalityController> _logger;
        
        public MunicipalityController(IMunicipalityService municipalityService, IMapper mapper, ILogger<MunicipalityController> logger)
        {
            _municipalityService = municipalityService;
            _mapper = mapper;
            _logger = logger;
        }

        // For testing only
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _municipalityService.GetAll());
        }

        [HttpGet]
        public IActionResult Get(string name, DateTime? date)
        {
            if (string.IsNullOrWhiteSpace(name) || date == null)
            {
                return BadRequest();
            }

            return Ok(_municipalityService.GetSpecificMunicipality(name, date.Value));
        }

        [HttpGet("GetTax")]
        public IActionResult GetTax(string name, DateTime? date)
        {
            if (string.IsNullOrWhiteSpace(name) || date == null)
            {
                return BadRequest();
            }

            var municipality = _municipalityService.GetSpecificMunicipality(name, date.Value);
            if (municipality?.TaxRate == null)
            {
                return NoContent();
            }

            return Ok(municipality.TaxRate);
        }

        [HttpPost]
        public IActionResult Add(MunicipalityDto municipality)
        {
            if (!municipality.Validate(municipality))
            {
                return NoContent();
            }

            return Ok(_municipalityService.AddMunicipality(_mapper.Map<Municipality>(municipality)));
        }

        [HttpDelete]
        public IActionResult Delete(MunicipalityDto municipality)
        {
            if (!municipality.Validate(municipality))
            {
                return NoContent();
            }

            var response = _municipalityService.DeleteMunicipality(_mapper.Map<Municipality>(municipality));

            if (response == null)
            {
                return NoContent();
            }

            return Ok();
        }

        [HttpPost("AddFromFile")]
        public IActionResult AddFromFile()
        {
            var files = Request.Form.Files;

            if (!files.Any())
            {
                return NoContent();
            }

            var file = files.FirstOrDefault();
            using TextReader sr = new StreamReader(file.OpenReadStream());
            using var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
            csv.Configuration.RegisterClassMap<MunicipalityDtoMap>();
            csv.Configuration.Delimiter = ";";
            var municipalities = csv.GetRecords<MunicipalityDto>().ToList();
            if (!municipalities.Any())
            {
                return NoContent();
            }

            var addedMunicipalities = _municipalityService.AddMunicipality(_mapper.Map<List<Municipality>>(municipalities));

            return Ok(addedMunicipalities);
        }
    }
}
