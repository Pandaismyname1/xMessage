using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class AuthKey
    {
        [Key]
        public int KeyId { get; set; }
        [Required]
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        [Required]
        public string Key { get; set; }
    }
}
