namespace ConsoleApp.Models
{
    internal class Offer
    {
        public Guid ID { get; set; }
        public DateTime CheckInDate { get; set; }
        public int StayDurationNights { get; set; }
        public string PersonCombination { get; set; }
        public string Service_Code { get; set; }
        public decimal Price { get; set; }
        public decimal PricePerAdult { get; set; }
        public decimal PricePerChild { get; set; }
        public decimal StrikePrice { get; set; }
        public decimal StrikePricePerAdult { get; set; }
        public decimal StrikePricePerChild { get; set; }    
        public bool ShowStrikePrice { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
