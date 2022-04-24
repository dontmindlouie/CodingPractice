using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPracticeService.ClassProblems.ParkingLot
{
    public class Vehicle
    {
        public Vehicle(int size, string licensePlate, bool isHandicap = false)
        {
            Size = size;
            LicensePlate = licensePlate;
            IsHandicap = isHandicap;
        }
        public int Size;
        public string LicensePlate;
        public bool IsHandicap; 
    }
}
