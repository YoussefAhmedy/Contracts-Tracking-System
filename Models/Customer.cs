using System.ComponentModel.DataAnnotations;

namespace Contract_Tracking_System.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        public string CustomerKind { get; set; } // فرد أو شركة

        [EmailAddress]
        public string EmailAddress { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // علاقة واحد إلى متعدد
        
        public virtual ICollection<Contract>? Contracts { get; set; }
    }

}
