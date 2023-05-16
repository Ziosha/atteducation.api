namespace atteducation.Dtos
{
    public class DataForAuthenticationDto
    {
        public string Token { get; set; }
        public UserForDetailedDto Personal { get; set; }
        public List<RolsToListDto> Rols { get; set; }
    }
}