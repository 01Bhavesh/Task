namespace New_CRUDTask.Model.DTO
{
    public class OrderResponseDTO
    {
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public List<OrderProductDetailsDTO>? ProductOrders { get; set; }
    }
}
