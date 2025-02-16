namespace New_CRUDTask.Model.DTO
{
    public class OrderCreatedDTO
    {
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public List<ProductOrderDTO> ProductOrders { get; set; }
    }
}
