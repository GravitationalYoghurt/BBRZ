namespace BetterRentalService
{
    public interface IRental
    {
        int RentalId { get; set; }   // Guid RentalId { get; protected set; }
        string CurrentRenter { get; set; }
        decimal PricePerDay { get; set; }
    }


}
