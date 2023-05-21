namespace CourseStore.Domain.Entities
{
    public class OrderItem
    {
        public OrderItem(int id, int quantity, Product product)
        {
            Id = id;
            Quantity = quantity;
            Price = product.Price * quantity;
            Product = product;
        }

        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; private set; }
        public Product Product { get; set; }
    }
}
