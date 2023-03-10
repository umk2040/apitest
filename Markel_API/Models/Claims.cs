using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Markel_API.Models
{
    public class Claims
    {
        public string UCR { get; set; } = string.Empty;
        [Required]
        public int CompanyId { get; set; }
        public DateTime ClaimDate { get; set; }
        public DateTime LossDate { get; set; }
        public string AssuredName { get; set; } = string.Empty;
        public decimal IncurredLoss { get; set; }
        public bool Closed { get; set; }
        public double AgeOfTheClaim { get; set; }

        [JsonIgnore]
        public virtual Company? Company { get; set; }
    }
}
