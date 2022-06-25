namespace api.Models
{
    public class Pet
    {
        public int OwnerID { get; set; }
        public int PetID { get; set; }
        public string PetName { get; set; }
        public string Type { get; set; }
    }
}