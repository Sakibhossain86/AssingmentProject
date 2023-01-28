using ExcelTech_Project.Models;
using System.Runtime.InteropServices;

namespace ExcelTech_Project.HostedServices
{
    public class DbSeeder
    {
        private readonly ExeclDbContext db;
        public DbSeeder(ExeclDbContext db) 
        {
            this.db = db;
        }
        public async Task SeedAsync()
          
        {
            if(!(await db.Database.CanConnectAsync()))
            {
                await this.db.Database.EnsureCreatedAsync();
                await db.Allergies.AddRangeAsync(new Allergy[]
                {
                    new Allergy{ AllergyName="Drugs - Penicilin"},
                    new Allergy{ AllergyName="Drugs - Others" },
                    new Allergy{ AllergyName="Oinments"},
                    new Allergy{ AllergyName="Sprays"}
                });
                await db.NCDs.AddRangeAsync(new NCD[]
                {
                new NCD{ NCDName="Asthma"},
                new NCD{ NCDName="Cancer"},
                new NCD{ NCDName="Disorder of eye"},
                new NCD{ NCDName="Disorder of ear"}
                });
                await db.DiseaseInformations.AddRangeAsync(new DiseaseInformation[]
                {
                    new DiseaseInformation{ DiseaseName="Ulcer"},
                    new DiseaseInformation{ DiseaseName="Hepatitis"},
                    new DiseaseInformation{ DiseaseName="Hypertension"}
                });
                await db.SaveChangesAsync();
            }
           
        }
    }
}
