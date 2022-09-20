namespace TaxApi.Models
{
    public class TaxBandModel
    {
        public int Id { get; set; }
        public decimal SalaryMax { get; set; }
        public decimal SalaryMin { get; set; }
        public decimal TaxBase { get; set; }
        public decimal TaxRates { get; set; }
    }
}
