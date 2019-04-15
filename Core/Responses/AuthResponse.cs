namespace Core.Responses
{
    public class AuthResponse : GenericResponse
    {
        public int AccountId { get; set; }
        public string AuthKey { get; set; }
    }
}
