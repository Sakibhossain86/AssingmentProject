using ExcelTech_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcelTech_Project.Repostoris
{
    public class PatientsRepo : IPatientsRepo
    {
        ExeclDbContext db;
        public PatientsRepo(ExeclDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Allergy>> GetAllegiesAsync()
        {
            return await db.Allergies.ToListAsync();
        }

        public async Task<IEnumerable<DiseaseInformation>> GetDiseaseInformationsAsync()
        {
            return await db.DiseaseInformations.ToListAsync();
        }

        public async Task<IEnumerable<NCD>> GetNCDsAsync()
        {
            return await db.NCDs.ToListAsync();
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await db.Patients.ToListAsync();
        }

        public async Task<Patient> InsertPatientAsync(Patient patient)
        {
            await this.db.Patients.AddAsync(patient);
            await this.db.SaveChangesAsync();
            return patient;
        }

        public async Task<IEnumerable<Allergy_Detail>> InsertAllergyDetailsAsync(IEnumerable<Allergy_Detail> allergy_Details)
        {
            await this.db.Allergy_Details.AddRangeAsync(allergy_Details);
            await this.db.SaveChangesAsync();
            return allergy_Details;
        }

        public async Task<Allergy_Detail> InsertAllergyDetailAsync(Allergy_Detail allergy_Detail)
        {
            await this.db.Allergy_Details.AddAsync(allergy_Detail);
            await this.db.SaveChangesAsync();
            return allergy_Detail;
        }

        public async Task<IEnumerable<NCD_Detail>> InsertNCDDetailsAsync(IEnumerable<NCD_Detail> nCD_Details)
        {
            await this.db.NCD_Details.AddRangeAsync(nCD_Details);
            await this.db.SaveChangesAsync();
            return nCD_Details;
        }
    }
}
