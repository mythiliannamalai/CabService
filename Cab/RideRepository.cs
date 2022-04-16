using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab
{
    public class RideRepository
    {
        public Dictionary<string, List<Ride>> rideRepository;
        public RideRepository()
        {
            rideRepository = new Dictionary<string, List<Ride>>();
        }
        public void AddRideRepository(string userId,Ride ride)
        {
            if(rideRepository.ContainsKey(userId))
            {
                rideRepository[userId].Add(ride);
            }
            else
            {
                rideRepository.Add(userId, new List<Ride>());
                rideRepository[userId].Add(ride);
            }
        }
        public List<Ride> returnListByUserId(string userId)
        {
            if (rideRepository.ContainsKey(userId))
            {
                return rideRepository[userId];
            }
            else
            {
                throw new CabException(CabException.ExceptionType.Invalid_User_Id, "Invalid User Id");
            }
        }
    }
}
