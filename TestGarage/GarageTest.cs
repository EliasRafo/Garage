using Garage;
using Microsoft.VisualBasic.FileIO;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace TestGarage
{
    public class GarageTest
    {
        Garage<Vehicle> garage;

        public GarageTest()
        {
            garage = new(6);
        }

        [Fact]
        public void AddVehicle_AddCar_Success()
        {
            // arrange

            Vehicle car = new Car("ABC123", "red", 4, "Diesel");

            bool expected = true;

            // Act
            bool actual = garage.AddVehicle(car);

            //Assert

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddVehicle_WithNull_ThrowsException()
        {
           Assert.Throws<ArgumentNullException>(() =>  garage.AddVehicle(null));            
        }

        [Fact]
        public void AddVehicle_GarageIsFull()
        {
            // arrange
            var car1 = new Car("ABC223", "red", 4, "Gas");
            var car2 = new Car("ABC133", "red", 4, "Gas");
            var car3 = new Car("ABC144", "red", 4, "Gas");
            var car4 = new Car("ABC663", "red", 4, "Gas");
            var car5 = new Car("ABC128", "red", 4, "Gas");
            var car6 = new Car("ABC148", "red", 4, "Gas");
            var car7 = new Car("ABC222", "red", 4, "Gas");

            garage.AddVehicle(car1);
            garage.AddVehicle(car2);
            garage.AddVehicle(car3);
            garage.AddVehicle(car4);
            garage.AddVehicle(car5);
            garage.AddVehicle(car6);

            bool expected = false;

            // Act
            bool actual = garage.AddVehicle(car7);

            //Assert

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void List()
        {
            // arrange
            var car = new Car("ABC123", "red", 4, "Gas");
            garage.AddVehicle(car);

            // Act
            var actual =  garage.First();

            //Assert

            Assert.Equal(car, actual);
        }

        [Fact]
        public void RemoveVehicle_RemoveCar_Success()
        {
            // arrange

            Vehicle car = new Car("ABC123", "red", 4, "Diesel");
            garage.AddVehicle(car);

            bool expected = true;

            // Act
            bool actual = garage.RemoveVehicle(car);

            //Assert

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveVehicle_WithNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => garage.RemoveVehicle(null));
        }
    }
}