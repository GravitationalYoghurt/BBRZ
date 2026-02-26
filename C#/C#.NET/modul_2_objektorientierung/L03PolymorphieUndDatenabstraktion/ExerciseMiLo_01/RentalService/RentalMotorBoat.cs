
namespace RentalService
{
    public class  RentalMotorBoat : RentalVehicle
    {
        
    }

    public class RentalSailBoat : RentalVehicle
    {
        public override void StartEngine()
        {
            throw new Exception("I do not have any engine to start");
        }
    }

}
