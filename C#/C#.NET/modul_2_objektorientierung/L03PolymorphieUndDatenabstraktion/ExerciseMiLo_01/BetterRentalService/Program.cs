namespace BetterRentalService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("___ Better Rental Servie ___");
            Console.WriteLine();

            List<IRental> rentals = new List<IRental>();

            rentals.Add(new RentalTruck() { CurrentRenter = "Truck Renter"});
            rentals.Add(new RentalSailboat() { CurrentRenter = "Sailboat Renter" });
            rentals.Add(new RentalCar() { CurrentRenter = "Car Renter" });

            foreach (var r in rentals)
            {
                if (r is RentalTruck t)
                {
                    Console.WriteLine($"Truck is rented by: {t.CurrentRenter}");
                }
                if (r is RentalSailboat s)
                {
                    Console.WriteLine($"Sailboat is rented by: {s.CurrentRenter}");

                }
            }
        }
    }

}
