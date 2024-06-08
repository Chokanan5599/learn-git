using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace TLA_SalseForeCast.Models
{
    public class DIRPERSONNAME_Model
    {
        public long PERSON { get; set; }
        public string? FIRSTNAME { get; set; }
        public string? MIDDLENAME { get; set; }
        public string? LASTNAME { get; set; }
        public DateTime VALIDFROM { get; set; }
        public int VALIDFROMTZID { get; set; }
        public DateTime VALIDTO { get; set; }
        public int VALIDTOTZID { get; set; }
        public string? MODIFIEDBY { get; set; }
        public string? CREATEDBY { get; set; }
        public int RECVERSION { get; set; }
        public long PARTITION { get; set; }
        [Key]
        public long RECID { get; set; }

    }
    public class Form_Fill {

        public long RECID { get; set; }
        public long PERSON { get; set; }
        public string? salesName { get; set; }
        public string? user { get; set; }
        public DateTime? validfrom { get; set; }

    }
}























    