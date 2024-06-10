using ApiTestePaschoalotto.Models;
using ApiTestePaschoalotto.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace ApiTestePaschoalotto.Services
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService(UserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;

        }





        public async Task<string> Authenticate(string username, string password)
        {
            UserModel user = await _userRepository.GetUserByUsernameAndPassword(username, password);
            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("TESTEPASCHOALOTTOSECRETOKEYFORCREATEAUTHENTICATION");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<List<UserModel>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task UploadNewUsers()
        {
            using (HttpClient client = new HttpClient())
            {
                string path = "https://randomuser.me/api";
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    string stringUser = await response.Content.ReadAsStringAsync();
                    UserAllResponseModel user = JsonSerializer.Deserialize<UserAllResponseModel>(stringUser)!;
                    foreach (var result in user.Results)
                    {
                        await _userRepository.InsertUser(result); // Await the call
                    }

                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public async Task<string> ExportUsersAsCsv()
        {
            List<UserModel> users = await _userRepository.GetUsers();

            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("Id,Gender,Name,Email,Username,Password,RegisteredAt,DobDate,Phone,Cell,Image,Street,City,Country,State,TimeZone,PostCode,Nat");

            foreach (UserModel user in users)
            {
                csvBuilder.AppendLine($"{user.Id},{user.Gender},{user.Name},{user.Email},{user.Username},{user.Password},{user.RegisteredAt},{user.DobDate},{user.Phone}," +
                    $"{user.Cell},{user.Image},{user.Address.Street}, {user.Address.City}, {user.Address.Country},{user.Address.State},{user.Address.TimeZone},{user.Address.PostCode},{user.Nat}");
            }

            return csvBuilder.ToString();
        }
    }
}
