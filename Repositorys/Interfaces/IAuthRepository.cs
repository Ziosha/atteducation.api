using atteducation.Dtos;
using atteducation.api.Models;

namespace atteducation.api.Repositorys.Interfaces
{
    public interface IAuthRepository
    {
        
        Task<User> Login(string username, string password);
        Task<string> UsernameOrEmail(string usernameOrEmail);
        Task<User> Register(UserForRegisterDto user);
        Task<string> UsernameOrEmailExist(UserForRegisterDto userForRegisterDto);
        // User CompleteInfoToConfirmVerify(UserForRecoveryVerifyDto userForRecoveryVerifyDto, User user);
        // Task<string> ChangePassword(UserForChangePasswordDto userForChangePasswordDto);
        // SecurityTokenDescriptor CreateToken(User userToReturn, List<Rol> rols);
        string CreateTokens(User user, List<Rol> rols);
        Task<DataForAuthenticationDto> AuthenticationData(int userId);
        Task<List<Rol>> GetRolsPerUser(int userId);
        Task<Rol> AssignRol(int userId, int rolId);
                                                                                                                                                       
    }
}