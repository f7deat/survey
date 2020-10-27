using Survey.Enums;

namespace Survey.Models
{
    public class UserSession {
        public string Id { get; set; }
        public string Name { get; set; }
        public UserType UserType { get; set; }
    }
}