using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tax.services.DTOs;

namespace Tax.services
{
    public class TaxServices
    {
        public TaxServices()
        {
            //TODO
        }

        public BandInfo[] GetBandInfo()
        {
            return _bandInfo;
        }

        public decimal GetMyTotalTax(decimal salary)
        {
            var bands = _bandInfo.AsEnumerable().OrderByDescending(x => x.BandNumber);

            var taxableValues = _bandInfo.Where(x => salary > x.StartAmount)
                .Select(x =>
                new {
                    bandNumber = x.BandNumber,
                    taxableAmount = x.Percentage == 0.0m ? 0 :
                        (salary > x.MaxAmount ?
                            (x.MaxAmount - x.StartAmount) * x.Percentage
                            : (salary - x.StartAmount) * x.Percentage
                        )
                })
                .ToArray();


            return Convert.ToDecimal(taxableValues.Select(x => x.taxableAmount).Sum());
        }

        private static readonly BandInfo[] _bandInfo = new[] {
                new BandInfo
                {
                    BandNumber = 1,
                    StartAmount = 0m,
                    MaxAmount = 18200.0m,
                    Percentage = 0.0m
                },
                new BandInfo
                {
                    BandNumber = 2,
                    StartAmount = 18200.0m,
                    MaxAmount = 45000.0m,
                    Percentage = 0.19m
                },
                new BandInfo
                {
                    BandNumber = 3,
                    StartAmount = 45000.0m,
                    MaxAmount = 120000.0m,
                    Percentage = 0.32m
                },
                new BandInfo
                {
                    BandNumber = 4,
                    StartAmount = 120000m,
                    MaxAmount = 180000.0m,
                    Percentage = 0.45m
                },
                new BandInfo
                {
                    BandNumber = 5,
                    StartAmount = 180000m,
                    MaxAmount = null,
                    Percentage = 0.45m
                }
            };
    }
}
