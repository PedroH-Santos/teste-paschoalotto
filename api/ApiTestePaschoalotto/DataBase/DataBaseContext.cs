using ApiTestePaschoalotto.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTestePaschoalotto.DataBase
{
    public class DataBaseContext: DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AddressModel> Address { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
    }
}
