using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace TLA_SalseForeCast.Models
{
    public class HCMWORKER_Model
    {
        public long PERSON { get; set; }
        public string? PERSONNELNUMBER { get; set; }
        public DateTime MODIFIEDDATETIME { get; set; }
        public string? MODIFIEDBY { get; set; }
        public DateTime CREATEDDATETIME { get; set; }
        public string?  CREATEDBY { get; set; }
        public int RECVERSION { get; set; }
        public long PARTITION { get; set; }
        [Key]
        public long RECID { get; set; }

    }
}























    