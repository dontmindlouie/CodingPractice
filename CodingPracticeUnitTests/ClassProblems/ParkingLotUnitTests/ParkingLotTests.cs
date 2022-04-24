using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingPracticeService.ClassProblems.ParkingLot;
using FluentAssertions;
using Microsoft;
using Xunit;

namespace CodingPracticeUnitTests.ClassProblems.ParkingLotUnitTests
{
    public class ParkingLotTests
    {
        [Fact]
        public void ParkingLotShouldCreateSpots()
        {
            var expectedLicensePlate = "asdf";
            var ParkingLot = new ParkingLot(4);
            var vehicle = new Vehicle(size: 1, expectedLicensePlate) ;
            var spotId = ParkingLot.Park(vehicle);
            Console.WriteLine($"spot id: {spotId}");
            var retrievedVehicle = ParkingLot.RetrieveVehicle(spotId);
            Verify.Equals(retrievedVehicle.LicensePlate, expectedLicensePlate);
            Verify.Equals(retrievedVehicle, vehicle);
        }
        [Fact]
        public void ParkingLargeVehicleInCompactSpot()
        {
            var expectedLicensePlate = "test";
            var ParkingLot = new ParkingLot(4, 0, 4, 0);
            var inputVehicle = new Vehicle(size: 2, expectedLicensePlate);
            //var spotId = ParkingLot.Park(inputVehicle);
            var parkTask = ParkingLot.Invoking(x => x.Park(inputVehicle));
            parkTask.Should().Throw<InvalidOperationException>();

        }
    }
}
