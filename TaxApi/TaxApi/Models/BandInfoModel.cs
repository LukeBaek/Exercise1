namespace TaxApi.Models
{
    public class BandInfoModel
    {
        public int bandNumber { get; set; }
        public decimal startAmount { get; set; }
        public decimal? maxAmount { get; set; }
        public decimal percentage { get; set; }

        public override string ToString()
        {
            return $"SalaryBand {bandNumber}: From ${startAmount} to ${maxAmount.ToString() ?? "or over"}  => {percentage}%";
        }
    }
}

