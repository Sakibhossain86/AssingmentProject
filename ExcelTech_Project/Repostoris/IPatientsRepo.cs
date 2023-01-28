using ExcelTech_Project.Models;

namespace ExcelTech_Project.Repostoris
{
    public interface IPatientsRepo
    {
        Task<IEnumerable<Allergy>> GetAllegiesAsync();
        Task<IEnumerable<NCD>> GetNCDsAsync();
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<IEnumerable<DiseaseInformation>> GetDiseaseInformationsAsync();
        Task<Patient> InsertPatientAsync(Patient patient);
        Task<Allergy_Detail> InsertAllergyDetailAsync(Allergy_Detail allergy_Detail);
        Task<IEnumerable<Allergy_Detail>> InsertAllergyDetailsAsync(IEnumerable<Allergy_Detail> allergy_Details);
        Task<IEnumerable<NCD_Detail>> InsertNCDDetailsAsync(IEnumerable<NCD_Detail> nCD_Details);
    }
}
