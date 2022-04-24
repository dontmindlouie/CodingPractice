using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPracticeService.ClassProblems.ParkingLot
{
    interface ISpot
    {
        bool isEmpty();
        void Park(Vehicle vehicle);
        bool TryPark(Vehicle vehicle);
        Vehicle RetrieveVehicle();
        bool IsValidVehicle(Vehicle vehicle);
    }
    class Spot : ISpot
    {
        public int Size;
        public Vehicle ParkedVehicle;
        public bool IsHandicap;

        public Spot(int size, bool isHandicap)
        {
            Size = size;
            IsHandicap = isHandicap;
        }

        public int GetSize()
        {
            return Size;
        }

        public bool isEmpty()
        {
            if (ParkedVehicle == null)
                return true;
            else return false;
        }

        public bool TryPark(Vehicle vehicle)
        {
            if (ParkedVehicle != null) return false;
            if (vehicle == null) return false;
            if (IsHandicap == true)
                if (vehicle.IsHandicap == false)
                    return false;
            ParkedVehicle = vehicle;
            return true;
        }

        public void Park(Vehicle vehicle)
        {
            if (IsHandicap == true)
            {
                if (vehicle.IsHandicap == false)
                {
                    throw new InvalidOperationException("Vehicle is not handicap tagged.");
                }
            }
            if (vehicle.Size > this.Size) throw new InvalidOperationException("Vehicle is too large for the spot.");
            else ParkedVehicle = vehicle;
        }
        public Vehicle RetrieveVehicle()
        {
            var tempVeh = ParkedVehicle;
            ParkedVehicle = null;
            return  tempVeh;
        }
        public bool IsValidVehicle(Vehicle vehicle)
        {
            if (vehicle == null) return false;
            if (vehicle.Size > Size) return false;
            if (!vehicle.IsHandicap && this.IsHandicap) return false;
            return true;
        }
    }
}
