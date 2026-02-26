namespace RentalService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RentalCar car = new RentalCar();
            //car.Style = TruckType.BoxTruck;   //funktioniert nicht, da Style vom Typ CarType ist

            RentalVehicle vehicleTruck = new RentalTruck();
            RentalVehicle vehicleCar = new RentalCar();
            vehicleTruck.StartEngine();  // Aufruf der Methode StartEngine() der Klasse RentalTruck, da die Instanz vom Typ RentalTruck ist
            vehicleCar.StartEngine();
            
            vehicleCar.RentalId = 1111;
            vehicleCar.NumberOfPassengers = 5;
            Console.WriteLine(vehicleCar);


        }

        
    }


}
