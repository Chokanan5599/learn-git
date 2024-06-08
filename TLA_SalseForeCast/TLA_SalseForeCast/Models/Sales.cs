namespace TLA_SalseForeCast.Models
{
     public class SalesModel
    {
        public int Id { get; set; } 
        public string? FL_Name { get; set; }
        public double? Quantity { get; set; }
        public double? Total_Sales { get; set; }
        public double? Total_Cost { get; set; }
        public double? Profit_THB { get; set; }
        public double? Profit_Percentage { get; set; }
        public DateTime? Record_Date { get; set; }
    }
}
