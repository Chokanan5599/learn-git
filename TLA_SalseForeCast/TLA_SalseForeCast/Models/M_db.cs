using Microsoft.EntityFrameworkCore;

namespace TLA_SalseForeCast.Models
{
    public class M_db : DbContext
    {
        public M_db(DbContextOptions<M_db> options)
           : base(options)
        {

        }
       
        public DbSet<UserModel> UserPermission { get; set; } = null!;
        public DbSet<SalesModel> Sales_Responsible { get; set; } = null!;

    }
}
