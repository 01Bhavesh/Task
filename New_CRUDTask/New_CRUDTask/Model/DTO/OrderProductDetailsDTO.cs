namespace New_CRUDTask.Model.DTO
{
    public class OrderProductDetailsDTO
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
