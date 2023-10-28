namespace PharmaGo.Domain.Entities
{
    public class PurchaseDetail
    {

        public int Id { get; set; }
        public Drug Drug { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int QuantityOfProduct { get; set; }
        public decimal Price { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public string Status { get; set; }
        public decimal PriceOfProduct { get; set; }
    }
}