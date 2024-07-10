using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace H_Spot.Models
{
    public class Illnesses
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

       
        [JsonIgnore] 
        public ICollection<Symptom> Symptoms { get; set; } = new List<Symptom>();
    }
}

