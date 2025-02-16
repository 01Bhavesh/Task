namespace New_CRUDTask.Model.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public List<ProductOrderDTO> Products { get; set; }
    }
}
