using ExcelTech_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace ExcelTech_Project.ViewModels.Input
{
    public class PatientInputModel
    {
        public int PatientId { get; set; }
        [Required, StringLength(50)]
        public string PatientName { get; set; } = default!;
        [EnumDataType(typeof(EpilepsyType))]
        public EpilepsyType? Epilepsy { get; set; } = default!;
        [Required(ErrorMessage ="Disease information is required")]
        public int DiseaseInformationId { get; set; }
        [Required(ErrorMessage = "Allergies is required")]
        public int[] AllergyIds { get; set; }= default!;
        public int[]? NCDIds { get; set; } = default!;
    }
}
