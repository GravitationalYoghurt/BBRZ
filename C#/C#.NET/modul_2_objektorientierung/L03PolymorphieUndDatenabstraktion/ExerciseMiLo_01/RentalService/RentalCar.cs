using System.Xml.Linq;

namespace RentalService
{
    public class RentalCar : RentalVehicle
    {
        public CarType Style { get; set; }

        public override string ToString()
        {
            return $"RentalID: {this.RentalId}, NoP: {NumberOfPassengers}";
        }
    }

}
