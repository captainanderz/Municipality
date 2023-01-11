using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MunicipalityProject.Business.Enums;

namespace MunicipalityProject.Business.Models
{
    public class Municipality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public MunicipalitySchedules Schedule { get; set; }
        public double TaxRate { get; set; }
        public DateTime Date { get; set; }
    }
}