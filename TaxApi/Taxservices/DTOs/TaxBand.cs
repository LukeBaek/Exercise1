using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax.services.DTOs
{
    public class TaxBand
    {
        public int Id { get; set; }
        public decimal SalaryMin { get; set; }
        public decimal SalaryMax { get; set; }
        public decimal TaxRates { get; set; }
        public decimal TaxBase { get; set; }
    }
}
