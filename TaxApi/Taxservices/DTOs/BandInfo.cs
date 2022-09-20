namespace Tax.services.DTOs
{
    public class BandInfo
    {
        public int BandNumber { get; set; }
        public decimal StartAmount { get; set; }
        public decimal? MaxAmount { get; set; }
        public decimal Percentage { get; set; }
    }
}