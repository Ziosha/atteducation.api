using System.ComponentModel.DataAnnotations;

namespace atteducation.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Must specify password between 4 and 32 characters")]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Ci { get; set; }
        public List<RolsToListDto> Rol { get; set; }
        //Back Data
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int CreationUserId { get; set; }
        public int UpdateUserId { get; set; }
        public UserForRegisterDto()
        {
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}