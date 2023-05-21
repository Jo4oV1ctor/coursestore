using CourseStore.Domain.Enums;

namespace CourseStore.Domain.Entities
{
    public class Order
    {
        public Order(int id, OrderStatusEnum orderStatus, Client client)
        {
            Id = id;
            OrderStatus = orderStatus;
            Client = client;
            Items = new List<OrderItem>();
        }

        public int Id { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; private set; }
        public decimal TotalPrice { get; private set; }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
            //TotalPrice = Items.Sum(i => i.Price); (Lambda)
            SetTotalPrice(Items);
        }

        public void RemoveItem(OrderItem item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
                SetTotalPrice(Items);
            }
            else
            {
                throw new ArgumentNullException("O item informado não existe no pedido!");
            }
        }

        public void SetTotalPrice(List<OrderItem> items)
        {
            foreach (OrderItem i in items)
            {
                TotalPrice = TotalPrice + i.Price;
            }
        }
    }
}
