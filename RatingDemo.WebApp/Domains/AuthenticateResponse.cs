namespace RatingDemo.WebApp.Domains
{
    public class AuthenticateResponse
    {
        public bool IsSucceed { get; set; }
        public string Tokens { get; set; }
        public string ErrorMessage { get; set; }
    }
}