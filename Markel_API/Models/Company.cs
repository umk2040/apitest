namespace Markel_API.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string Address3 { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public bool Active { get; set; }
        public bool HasActiveInsurancePolicy { get; set; }
        public DateTime InsuranceEndDate { get; set; }
        public virtual List<Claims> Claims { get; set; }
    }
}
