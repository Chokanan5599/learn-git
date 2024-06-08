using System.ComponentModel.DataAnnotations;

namespace TLA_SalseForeCast.Models
{
    public class WEB_SALESFORECAST_USERPERMISSION
    {
       
        public int ID { get; set; }
        public int User_id { get; set; }
        public string? Pass_id { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }

    }
}
