namespace IT6OrderManagementWebAppCS.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public string CreatedDate { get; set; } = "";
    }
}
