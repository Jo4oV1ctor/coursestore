namespace CourseStore.Domain.Enums
{
    public enum OrderStatusEnum : int
    {
        PendingPayment = 0,
        Processing = 1,
        Shipped = 2,
        Delivered = 3,
    }
}
