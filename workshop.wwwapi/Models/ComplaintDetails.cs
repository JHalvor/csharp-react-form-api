namespace workshop.wwwapi.Models
{
    public class ComplaintDetails
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Address {  get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Complaint { get; set; }
        public string Contact { get; set; }
        public bool Consent { get; set; }

    }
}