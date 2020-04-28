using RatingDemo.WebApp.Domains;

namespace RatingDemo.WebApp.Models
{
    public class LoginRequest
    {
        public string Passcode { get; set; }
        public Services Service { get; set; }
    }
}