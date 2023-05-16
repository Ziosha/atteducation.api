namespace atteducation.api.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Namerol { get; set; }
        public ICollection<UserRols> UserRols { get; set; }
    }
}