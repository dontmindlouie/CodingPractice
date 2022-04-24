using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPracticeService.ClassProblems.ParkingLot
{
    interface IParkingLot
    {
        int Park(Vehicle vehicle);

    }
    public class ParkingLot : IParkingLot
    {
        public ParkingLot(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Spots.Add(i, new Spot(2, false));
            }
        }
        public ParkingLot(int size, int handicapCount = 0, int compactCount = 0, int wideCount = 0)
        {
            for (int i = 0; i < size; i++)
            {
                bool handicap = false;

                if (handicapCount > 0)
                {
                    Spots.Add(i, new Spot(size: 2, isHandicap: true));
                    handicapCount--;
                    continue;
                }
                if (compactCount > 0)
                {
                    Spots.Add(i, new Spot(size: 1, isHandicap: false));
                    compactCount--;
                    continue;
                }
                if (wideCount > 0)
                {
                    Spots.Add(i, new Spot(size: 3, isHandicap: false));
                    wideCount--;
                    continue;
                }
                handicapCount--;
            }
        }
        public int Park(Vehicle vehicle)
        {
            if (IsFull()) throw new InvalidOperationException("Parking lot is full.");
            var openSpot = Spots.
                FirstOrDefault(spot =>
            {
                if (spot.Value != null && spot.Value.IsValidVehicle(vehicle) == true)
                    return true;
                return false;
            });
            if (openSpot.Value == null) throw new InvalidOperationException("No valid parking spots available for this vehicle");
            Spots[openSpot.Key].Park(vehicle);
            return openSpot.Key;
        }
        public int Park(Vehicle vehicle, int? spotId = null)
        {
            if (spotId == null) Park(vehicle);
            if (!Spots.ContainsKey((int)spotId))
                throw new InvalidOperationException("Spot Id doesn't exist.");
            Spots[(int)spotId].Park(vehicle);
            return (int)spotId;
        }
        public bool IsFull()
        {
            foreach (var spot in Spots)
            {
                if (spot.Value.isEmpty())
                    return false;
            }
            return true;
        }

        public Vehicle RetrieveVehicle(int spotId)
        {
            if (Spots.ContainsKey(spotId) == false)
            {
                throw new NullReferenceException("Spot does not exist.");
            }

            return Spots[spotId].RetrieveVehicle();
        }

        private IDictionary<int, ISpot> Spots = new Dictionary<int, ISpot>();

    }
}
