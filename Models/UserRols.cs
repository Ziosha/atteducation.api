namespace atteducation.api.Models
{
    public class UserRols
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual Rol  Rol { get; set; }
        public int RolId { get; set; }
    }
}