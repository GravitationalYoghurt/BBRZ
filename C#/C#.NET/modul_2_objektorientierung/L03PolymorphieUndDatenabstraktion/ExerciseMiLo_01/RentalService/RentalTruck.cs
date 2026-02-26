namespace RentalService
{
    public class RentalTruck : RentalVehicle
    {
        public TruckType Style { get; set; }


        public override void StartEngine()
        {
            Console.WriteLine("Press brake pedal");
            Console.WriteLine("Turn truck key to ignition setting");
            Console.WriteLine("Turn truck key to on");
        }
    }

}
