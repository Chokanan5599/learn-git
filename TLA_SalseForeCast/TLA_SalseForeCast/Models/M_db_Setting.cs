using Microsoft.EntityFrameworkCore;

namespace TLA_SalseForeCast.Models
{
 
    public class M_db_Setting : DbContext
    {
        public M_db_Setting(DbContextOptions<M_db_Setting> options)
           : base(options)
        {

        }

        public DbSet<WEB_SALESFORECAST_USERPERMISSION> WEB_SALESFORECAST_USERPERMISSION { get; set; } = null!;
        public DbSet<WEB_SALESFORECAST_COMPANY> Company { get; set; } = null!;
        public DbSet<SYSUSERINFO> SYSUSERINFO { get; set; } = null!;
      
        

    }
}
