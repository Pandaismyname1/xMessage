using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class ContactLinkage
    {
        [Key]
        public int ContactLinkageId { get; set; }
        [Required]
        [ForeignKey("Account")]
        public int Account1Id { get; set; }
        [Required]
        [ForeignKey("Account")]
        public int Account2Id { get; set; }
    }
}
