using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace TLA_SalseForeCast.Models
{
    public class DIRPERSONUSER_Model
    {
        public long PERSONPARTY { get; set; }
        public string? USER_ { get; set; }
        public DateTime VALIDTO { get; set; }
        public int VALIDTOTZID { get; set; }
        public DateTime VALIDFROM { get; set; }
        public int VALIDFROMTZID { get; set; }
        public int RECVERSION { get; set; }
        public long PARTITION { get; set; }
        [Key]
        public long RECID { get; set; }

    }
}























    