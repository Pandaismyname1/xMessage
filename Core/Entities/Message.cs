using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Account")]
        [Required]
        public long SenderId { get; set; }
        [ForeignKey("Conversation")]
        [Required]
        public long ConversationId { get; set; }
    }
}
