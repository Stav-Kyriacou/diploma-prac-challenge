using System;

namespace api.Models
{
    public class Treatment
    {
        public int OwnerID { get; set; }
        public int TreatmentID { get; set; }
        public int PetID { get; set; }
        public int ProcedureID { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public float Payment { get; set; }
    }
}