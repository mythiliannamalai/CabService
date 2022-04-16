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
        public double totalFare;
        public int numofRides;
        public double averagePerRide;
        public int primiumPricePerKilometer;
        public int primiumPricePerminute;
        public int primiumminiumFare;

        public InvoiceGeneration()
        {
            this.PricePerKilometer = 10;
            this.PricePerminute = 1;
            this.miniumFare = 5;
            this.primiumPricePerKilometer = 15;
            this.primiumPricePerminute = 2;
            this.primiumminiumFare = 20;
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
        public double MultiRide(List<Ride> rides)
        {
            foreach(Ride ride in rides)
            {
                totalFare +=SingleRide(ride);
                numofRides++;
            }            
            averagePerRide= totalFare / numofRides;
            return totalFare;
        }
        public double PrimiumSingleRide(Ride ride)
        {
            if (ride.distance < 0)
            {
                throw new CabException(CabException.ExceptionType.Invalid_Distance, "Invalid Distance");
            }
            if (ride.time < 0)
            {
                throw new CabException(CabException.ExceptionType.Invalid_Time, "Invalid Time");
            }
            return Math.Max(primiumminiumFare, ride.distance * primiumPricePerKilometer + ride.time * primiumPricePerminute);

        }
        public double Primium_MultiRide(List<Ride> rides)
        {
            foreach (Ride ride in rides)
            {
                totalFare += PrimiumSingleRide(ride);
                numofRides++;
            }
            averagePerRide = totalFare / numofRides;
            return totalFare;
        }
    }
}
