// using atteducation.api.Repositorys.Interfaces;

// namespace atteducation.api.Repositorys
// {
//     public class AuthRepository: IAuthRepository
//     {
//         private readonly DataContext _context;
//         private readonly IConfiguration _config;
//         private readonly IMapper _mapper;
//         private readonly SymmetricSecurityKey _key;
//         public AuthRepository(DataContext context, IConfiguration config, IMapper mapper)
//         {
//             _context = context;
//             _config = config;
//             _mapper = mapper;
//             _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Appsettings:Token"]));
//         }
//         public async Task<User> Login(string usernameOrEmail, string password)
//         {
//             usernameOrEmail = usernameOrEmail.Trim();
//             password = password.Trim();
//             var user = await _context.Users
//                 .FirstOrDefaultAsync(x => (x.Username == usernameOrEmail || x.Email == usernameOrEmail));

//             if (user == null)
//                 return null;

//             if (!verifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
//                 return null;

//             return user;
//         }

//         private bool verifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
//         {
//             using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
//             {
//                 var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
//                 for (int i = 0; i < computedHash.Length; i++)
//                 {
//                     if (computedHash[i] != passwordHash[i]) return false;
//                 }
//                 return true;
//             }
//         }

//         public async Task<User> Register(UserForRegisterDto user)
//         {
//             using (var transaction = _context.Database.BeginTransaction())
//             {
//                 try
//                 {
//                     var password = user.Password.Trim();

//                     var createdUser = _mapper.Map<User>(user);

//                     byte[] passwordHash, passwordSalt;
//                     CreatePasswordHash(password, out passwordHash, out passwordSalt);
//                     createdUser.PasswordHash = passwordHash;
//                     createdUser.PasswordSalt = passwordSalt;

//                     await _context.Users.AddAsync(createdUser);
//                     await _context.SaveChangesAsync();

//                     transaction.Commit();

//                     return createdUser;
//                 }
//                 catch (Exception)
//                 {
//                     transaction.Rollback();
//                     throw new Exception("registration_failed");
//                 }
//             }
//         }

//         private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
//         {
//             using (var hmac = new System.Security.Cryptography.HMACSHA512())
//             {
//                 passwordSalt = hmac.Key;
//                 passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
//             }
//         }

//         public async Task<string> UsernameOrEmail(string usernameOrEmail)
//         {
//             usernameOrEmail = usernameOrEmail.Trim();

//             var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == usernameOrEmail || x.Email == usernameOrEmail);
//             if (user == null)
//                 return "wrong_usernameOrEmail";

//             return "";
//         }

//         public async Task<string> UsernameOrEmailExist(UserForRegisterDto userForRegisterDto)
//         {
//             if (await _context.Users.AnyAsync(x => x.Username == userForRegisterDto.Username))
//             {
//                 return "username_exists";
//             }
//             if (await _context.Users.AnyAsync(x => x.Email == userForRegisterDto.Email))
//             {
//                 return "email_exists";
//             }

//             return "";
//         }

//         // public SecurityTokenDescriptor CreateToken(User userToReturn, List<Rol> rols)
//         // {
//         //    try
//         //     {
//         //         var claims = new[] {
//         //             new Claim (ClaimTypes.NameIdentifier, userToReturn.Id.ToString()),
//         //             new Claim (ClaimTypes.Name, userToReturn.Username)
//         //         };

//         //         foreach (var rol in rols)
//         //         {
//         //             claims = claims.Concat(
//         //                 new[] {
//         //                     new Claim(ClaimTypes.Role, rol.Name)
//         //                 }).ToArray();
//         //         }

//         //         var key = new SymmetricSecurityKey(Encoding.UTF8
//         //             .GetBytes(_config.GetSection("AppSettings:Token").Value));

//         //         var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

//         //         var tokenDescriptor = new SecurityTokenDescriptor
//         //         {
//         //             Subject = new ClaimsIdentity(claims),
//         //             Expires = DateTime.Now.AddDays(1),
//         //             SigningCredentials = creds
//         //         };

//         //         var tokenHandler = new JwtSecurityTokenHandler();

//         //         var token = tokenHandler.CreateToken(tokenDescriptor);
//         //         return tokenDescriptor;
//         //     }
//         //     catch (Exception)
//         //     {
//         //         return null;
//         //     }
//         // }

//         public string CreateTokens(User user, List<Rol> rols)
//         {
//             var claims = new List<Claim>
//             {
//                 new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString())
//             };

//             foreach(var role in rols)
//             {
//                  claims.Add(new Claim(ClaimTypes.Role, role.Name));
//             }

//             var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

//             var tokenDescriptor = new SecurityTokenDescriptor
//             {
//                 Subject = new ClaimsIdentity(claims),
//                 Expires = DateTime.Now.AddDays(7),
//                 SigningCredentials = creds,
                
//             };

//             var tokenHandler = new JwtSecurityTokenHandler();

//             var token = tokenHandler.CreateToken(tokenDescriptor);

//             return tokenHandler.WriteToken(token);
//         }

//         public async Task<DataForAuthenticationDto> AuthenticationData(int userId)
//         {
//             var userFromRepo = await GetUser(userId);
//             var userReturn = _mapper.Map<UserForDetailedDto>(userFromRepo);
            
//             var rols = await GetRolsPerUser(userId);
//             var rolsAssignedToList = _mapper.Map<List<RolsToListDto>>(rols);
    
//             var tokenDescriptor = CreateTokens(userFromRepo, rols);
            
            

//             var dataForAuthenticationDto = new DataForAuthenticationDto()
//             {
//                 Token = tokenDescriptor,
//                 Personal = userReturn,
//                 Rols = rolsAssignedToList
//             };

//             return dataForAuthenticationDto;
//         }

//         public async Task<User> GetUser(int personalId)
//         {
//             var user = await _context.Users
//             .FirstOrDefaultAsync(x => x.Id == personalId);

//             return user;
//         }

//         public async Task<List<Rol>> GetRolsPerUser(int personalId)
//         {
//             var rols = await _context.RolUsers.Where(r => r.UserId == personalId).Select(x => x.Rol).ToListAsync();
//             return rols;
//         }

//          public async Task<Rol> AssignRol(int userId, int rolId)
//         {
//             var rol = await _context.Rols.FirstOrDefaultAsync(r => r.Id == rolId);
//             if (rol != null)
//             {
//                 var userRol = new RolUser()
//                 {
//                     RolId = rol.Id,
//                     UserId = userId
//                 };

//                 await _context.RolUsers.AddAsync(userRol);
//                 await _context.SaveChangesAsync();
//             }

//             return rol;
//         }
//     }
// }