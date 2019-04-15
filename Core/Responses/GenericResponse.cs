using System.Collections.Generic;

namespace Core.Responses
{
    public class GenericResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
