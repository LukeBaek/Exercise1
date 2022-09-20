namespace TaxApi.Models
{
    public class TaxBand
    {
        public long BandId { get; set; }
        public decimal SalaryMax { get; set; }
        public decimal SalaryMin { get; set; }
        public decimal TaxBase { get; set; }
        public decimal TaxRates { get; set; }

    }
}