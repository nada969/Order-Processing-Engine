using System;

// 1- Define Delegate for event handler (the "contract")
public delegate void OrderHandler(Order order);

public enum OrderStatus
{
    Pending,
    Completed,
    Failed
}

public class Order
{
    public OrderItem[] Items = new OrderItem[0];
    public int Id { get; set; }
	public Customer Customer { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public Order(int id, Customer cutomer)
	{
		this.Id = id;
		this.Customer = cutomer;
	}

    public bool OrderIsEmpty => Items is null || Items.Length == 0;
    public void AddItem(OrderItem item)
    {
        if (OrderIsEmpty)
        {
            Items = new OrderItem[] { item };
        }
        else
        {
            Items = Items.Append(item).ToArray();
        }
    }

    public int ItemsNum => Items?.Length ?? 0;


    public OrderStatus CompleteOrder() => Status = OrderStatus.Completed; 
    public OrderStatus FailedOrder() => Status = OrderStatus.Failed; 
}


// Publisher class
public class OrderProcess
{
    // 2. Declare an event based on that delegate
    public event OrderHandler OrderCreated;

    // Notify all subscribers (if any exist)
    public void OnOrderCreated(Order order)
    {
        // Do order processing
        Console.WriteLine($"Order #{order.Id} placed");
        if(order.Status == OrderStatus.Completed)
        {
            OrderCreated?.Invoke(order);   // call event / raise the event
        }
        
    }
}

// Subscriber class
public class Stock
{
    /// 4. Subscribe to the event ...--> parameter is the class that has the event
    public void Subscribe(OrderProcess process)
    {
        process.OrderCreated += OnOrderCreated;

    }

    public void OnOrderCreated(Order order)
    {
        Console.WriteLine("\n[Stock] Updating inventory...");

        if (order.Status is OrderStatus.Completed)
        {
            foreach (OrderItem item in order.Items)
            {
                item.Product.Stock -= item.Quantity;
            }
        }
        Console.WriteLine("stok done");
    }
}

public class Payment
{
   
    /// 4. Subscribe to the event ...--> parameter is the class that has the event
    public void Subscribe(OrderProcess process)
    {
        process.OrderCreated += OnOrderCreated;

    }

    public void OnOrderCreated(Order order)
    {
        double TotalPrice = 0;
        if (order.Status is OrderStatus.Completed)
        {
            foreach (OrderItem item in order.Items)
            {
                TotalPrice += item.ItemTotalPrice;
            }
        }
        Console.WriteLine("the total price of order:" + order.Id + " is " + TotalPrice);
    }
}