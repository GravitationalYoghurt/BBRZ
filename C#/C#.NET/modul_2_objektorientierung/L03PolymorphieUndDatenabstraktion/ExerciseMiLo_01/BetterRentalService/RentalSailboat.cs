namespace BetterRentalService
{
    public class RentalSailboat : IRental
    {
        public int RentalId { get; set; }
        public string CurrentRenter { get; set; }
        public decimal PricePerDay { get; set; }
    }

}
