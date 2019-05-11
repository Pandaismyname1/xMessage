using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class TextMessage : Message
    {
        [Required]
        public string Data { get; set; }
    }
}
