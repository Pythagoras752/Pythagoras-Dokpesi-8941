using H_Spot.Models;
using Microsoft.EntityFrameworkCore;

namespace HPlusSport.API.Models
{
    public static class MedicalBuilderExtensions
    {
        public static void Data(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Illnesses>().HasData(
                new Illnesses { Id = 1, Name = "COVID-19", Description = "Coronavirus disease 2019" },
                new Illnesses { Id = 2, Name = "Influenza", Description = "Seasonal flu" },
                new Illnesses { Id = 3, Name = "Hypertension", Description = "High blood pressure" }
            );

            modelBuilder.Entity<Symptom>().HasData(
                new Symptom { Id = 1, Description = "Fever", IllnessId = 1 },
                new Symptom { Id = 2, Description = "Cough", IllnessId = 1 },
                new Symptom { Id = 3, Description = "Fatigue", IllnessId = 2 },
                new Symptom { Id = 4, Description = "Headache", IllnessId = 2 },
                new Symptom { Id = 5, Description = "Dizziness", IllnessId = 3 }
            );
        }
    }
}
