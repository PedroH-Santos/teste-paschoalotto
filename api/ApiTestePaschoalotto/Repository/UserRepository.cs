using ApiTestePaschoalotto.DataBase;
using ApiTestePaschoalotto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTestePaschoalotto.Repository
{
    public class UserRepository
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public UserRepository(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task<List<UserModel>> GetUsers()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _dataBaseContext = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
                return await _dataBaseContext.Users.Include(u => u.Address).ToListAsync();
            }
        }

        public async Task InsertUser(UserResponseModel result)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _dataBaseContext = scope.ServiceProvider.GetRequiredService<DataBaseContext>();

                AddressModel address = new AddressModel()
                {
                    City = result.Location.City,
                    State = result.Location.State,
                    Country = result.Location.Country,
                    PostCode = Convert.ToString(result.Location.Postcode),
                    Street = result.Location.Street.Name + " - " + result.Location.Street.Number,
                    TimeZone = result.Location.Timezone.Description + " - " + result.Location.Timezone.OffSet
                };
                UserModel model = new UserModel()
                {
                    Address = address,
                    Cell = result.Cell,
                    Email = result.Email,
                    Gender = result.Gender,
                    DobDate = ConvertToUtc(result.Registered.Date),
                    Image = result.Picture.Medium,
                    Name = result.Name.First + " " + result.Name.Last,
                    Nat = result.Nat,
                    Password = result.Login.Password,
                    Phone = result.Phone,
                    RegisteredAt = ConvertToUtc(result.Registered.Date),
                    Username = result.Login.Username
                };
                await _dataBaseContext.Users.AddAsync(model);
                await _dataBaseContext.SaveChangesAsync();
            }
        }

        internal async Task<UserModel> GetUserByUsernameAndPassword(string username, string password)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _dataBaseContext = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
                return await _dataBaseContext.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            }
        }

        private DateTime ConvertToUtc(string dateTimeString)
        {
            var dateTime = DateTime.Parse(dateTimeString);
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        }
    }
}
