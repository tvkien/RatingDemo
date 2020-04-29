using RatingDemo.WebApp.Domains;

namespace RatingDemo.WebApp.Models
{
    public class LoginRequest
    {
        public string Passcode { get; set; }

        public ServiceType Service { get; set; }
    }
}