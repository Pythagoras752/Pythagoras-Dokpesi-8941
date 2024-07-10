namespace H_Spot.Models
{
    public class Symptom
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int IllnessId { get; set; } // Foreign key
        public Illnesses Illness { get; set; } // Navigation property
    }
}
