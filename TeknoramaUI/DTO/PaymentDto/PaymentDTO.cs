namespace TeknoramaUI.DTO.PaymentDto
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public string CardUserName { get; set; }
        public string CardNumber { get; set; }
        public string SecurityNumber { get; set; }
        public int CardExpiryMonth { get; set; }
        public int CardExpiryYear { get; set; }
        public decimal ShoppingPrice { get; set; }
    }
}
