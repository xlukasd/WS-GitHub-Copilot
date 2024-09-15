namespace OrderManagement.DomainModel
{
    public class OrderProcessor
    {
        public void ProcessOrder(Order order)
        {
            // Validation
            if (order.TotalAmount <= 0)
            {
                throw new InvalidOperationException("Order total amount must be positive.");
            }

            // Inventory check
            foreach (var item in order.OrderItems)
            {
                if (Inventory.CheckAvailability(item.ProductId, item.Quantity) == false)
                {
                    throw new OutOfStockException($"Product {item.ProductId} is out of stock.");
                }
            }

            // Payment processing
            if (!PaymentProcessor.ProcessPayment(order.TotalAmount))
            {
                throw new PaymentFailedException("Payment processing failed.");
            }

            // Shipping
            ShippingService.ShipOrder(order);

            // Update order status
            order.OrderStatus = OrderStatus.Completed;
        }
    }
}
