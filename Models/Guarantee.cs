using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contract_Tracking_System.Models
{
    public class Guarantee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime GuaranteeStart { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime GuaranteeEnd { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        // العلاقة مع العقد
        [ForeignKey("Contract")]
        public int ContractID { get; set; }
        public Contract? Contract { get; set; }
    }
}
