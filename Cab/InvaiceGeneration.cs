using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab
{
    public class InvoiceGeneration
    {
        public int PricePerKilometer;
        public int PricePerminute;
        public int miniumFare;
        public InvoiceGeneration()
        {
            this.PricePerKilometer = 10;
            this.PricePerminute = 1;
            this.miniumFare = 5;
        }
        public double SingleRide(Ride ride)
        {
            if(ride.distance<0)
            {
                throw new CabException(CabException.ExceptionType.Invalid_Distance, "Invalid Distance");
            }
            if(ride.time<0)
            {
                throw new CabException(CabException.ExceptionType.Invalid_Time, "Invalid Time");
            }
            return Math.Max(miniumFare, ride.distance * PricePerKilometer + ride.time * PricePerminute);
                
        }
    }
}
