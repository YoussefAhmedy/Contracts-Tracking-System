using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Contract_Tracking_System.Models
{
    public class Contract
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartContract { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndContract { get; set; }

        [StringLength(100)]
        public string ContractNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string ContractKind { get; set; } // بيع - إيجار - صيانة

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [StringLength(500)]
        public string Notes { get; set; }

        // العلاقة مع العميل
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer? Customer { get; set; }

        // العلاقة مع الضمانات
        public ICollection<Guarantee>? Guarantees { get; set; }
    }
}
