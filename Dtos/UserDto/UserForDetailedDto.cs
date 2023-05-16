using atteducation.api.Models;


namespace atteducation.Dtos
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Ci { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastActive { get; set; }
        public List<Rol> Rol { get; set; }
    }
}