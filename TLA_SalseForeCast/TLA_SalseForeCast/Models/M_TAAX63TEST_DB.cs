using Microsoft.EntityFrameworkCore;
using TLA_SalseForeCast.Models;

namespace TLA_SalseForeCast.Models
{
    public class M_TAAX63TEST_DB : DbContext
    {
        public M_TAAX63TEST_DB(DbContextOptions<M_TAAX63TEST_DB> options)
           : base(options)
        {

        }
        public DbSet<WEB_SALESFORECAST_USERPERMISSION> WEB_SALESFORECAST_USERPERMISSION { get; set; } = null!;
        public DbSet<WEB_SALESFORECAST_COMPANY> WEB_SALESFORECAST_COMPANY { get; set; } = null!;
        public DbSet<SYSUSERINFO> SYSUSERINFO { get; set; } = null!;


        //MOdel From fill date
        public DbSet<DIRPERSONNAME_Model> DIRPERSONNAME { get; set; } = null!;
        public DbSet<DIRPERSONUSER_Model> DIRPERSONUSER { get; set; } = null!;
        public DbSet<HCMWORKER_Model> HCMWORKER { get; set; } = null!;
        public DbSet<ETP_OC_TEAM> ETP_OC_TEAM { get; set; } = null!;
        public DbSet<DATAAREA_Model> DATAAREA { get; set; } = null!;

    }
}
