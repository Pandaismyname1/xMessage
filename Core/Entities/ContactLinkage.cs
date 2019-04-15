using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class ContactLinkage
    {
        [Key]
        public int ContactLinkageId { get; set; }
        [Required]
        public int Account1Id { get; set; }
        [Required]
        public int Account2Id { get; set; }
    }
}
