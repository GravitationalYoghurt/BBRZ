namespace BetterRentalService
{
    public class RentalCar : LandVehicle, IRental
    {
        public CarType Style { get; set; }
        public int RentalId { get; set; }    //public Guid RentalId { get; set; } = Guid.NewGuid();    
        public string CurrentRenter { get; set; }
        public decimal PricePerDay { get; set; }
    }

}
