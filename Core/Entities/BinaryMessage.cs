using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class BinaryMessage : Message
    {
        [Required]
        public BinaryMessageType Type { get; set; }
        [Required]
        public byte[] Data { get; set; }
    }
}
