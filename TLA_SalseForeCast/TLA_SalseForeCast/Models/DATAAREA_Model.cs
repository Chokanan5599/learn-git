using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace TLA_SalseForeCast.Models
{
    public class DATAAREA_Model

    {
        public string ID { get; set; }
        public string? NAME { get; set; }
        public int ISVIRTUAL { get; set; }
        public int ALWAYSNATIVE { get; set; }
        public int TIMEZONE { get; set; }
        public int RECVERSION { get; set; }
        [Key]
        public long PARTITION { get; set; }
        public long RECID { get; set; }

    }
}























    