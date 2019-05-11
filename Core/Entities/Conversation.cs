using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Conversation
    {
        [Key]
        public long Id { get; set; }
    }
    public class ConversationLinkage
    {
        [ForeignKey("Conversation")]
        public long ConversationId { get; set; }
        [ForeignKey("Account")]
        public long AccountId { get; set; }
    }
}
