namespace BetterRentalService
{
    public class LandVehicle
    {
        public int NumberOfPassengers { get; set; }


        public virtual void StartEngine()
        {
            Console.WriteLine("Turn vehicle key to ignition setting");
            Console.WriteLine("Turn vehicle key to on");
        }

        public virtual void StopEngine()
        {
            Console.WriteLine("Turn vehicle key to off");
        }
    }
}
