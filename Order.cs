using System;

// 1- Define Delegate for event handler (the "contract")
public delegate void OrderHandler<T>(Order<T> order);

public enum OrderStatus
{
    Pending,
    Completed,
    Failed
}


// Publisher class for event createOrder
public class OrderProcess<T>
{
    // 2. Declare an event based on that delegate
    public event OrderHandler<T> OrderCreated , OrderCompleted, OrderFailed;

    // Notify all subscribers (if any exist)
    public void OnOrderCreated(Order<T> order)
    {
        // Do order processing
        Console.WriteLine($"Order #{order.Id} placed");
        OrderCreated?.Invoke(order);   // call event / raise the event

    }
    // Notify all subscribers (if any exist)
    public void OnOrderCompleted(Order<T> order)
    {
        // Do order processing
        Console.WriteLine($"Order #{order.Id} Done");
        OrderCompleted?.Invoke(order);   // call event / raise the event

    }
    // Notify all subscribers (if any exist)
    public void OnOrderFailed(Order<T> order)
    {
        // Do order processing
        Console.WriteLine($"Order #{order.Id} Failed");
        OrderFailed?.Invoke(order);   // call event / raise the event

    }
}


//// without Generic:
//public class Order
//{
//    public OrderItem[] Items = new OrderItem[0];
//    public int Id { get; set; }
//	public Customer Customer { get; set; }
//    public OrderStatus Status { get; set; } = OrderStatus.Pending;
//    public Order(int id, Customer cutomer)
//	{
//		this.Id = id;
//		this.Customer = cutomer;
//	}

//    public bool OrderIsEmpty => Items is null || Items.Length == 0;
//    public void AddItem(OrderItem item)
//    {
//        if (OrderIsEmpty)
//        {
//            Items = new OrderItem[] { item };
//        }
//        else
//        {
//            Items = Items.Append(item).ToArray();
//        }
//    }

//    public int ItemsNum => Items?.Length ?? 0;


//    public OrderStatus CompleteOrder() => Status = OrderStatus.Completed; 
//    public OrderStatus FailedOrder() => Status = OrderStatus.Failed; 
//}

//// with Generic:
public class Order<T>
{
    public List<T> Items { get; set; } = new();
    //public  T[] Items = new T[0];
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public Order(int id, Customer cutomer)
    {
        this.Id = id;
        this.Customer = cutomer;
    }

    public bool OrderIsEmpty => Items is null || Items.Count == 0;
    public int ItemsNum => Items?.Count ?? 0;
    public void AddItem(T item) => Items.Add(item);

    public OrderStatus CompleteOrder() => Status = OrderStatus.Completed;
    public OrderStatus FailedOrder() => Status = OrderStatus.Failed;
}


// Subscriber class
public class Stock
{
    /// 4. Subscribe to the event ...--> parameter is the class that has the event
    public void Subscribe(OrderProcess<OrderItem> process)
    {
        process.OrderCompleted += OnOrderCompleted;
        process.OrderFailed += OnOrderFailed;
    }
    // update the stock
    public void OnOrderCompleted(Order<OrderItem> order)
    {
        if (order.Status is OrderStatus.Completed)
        {
            foreach (var item in order.Items)
            {
<<<<<<< HEAD
                int oldQua = item.Product.Stock;
                item.Product.Stock -= item.Quantity;
                Console.WriteLine("Updating the inventory of "+ item.Product.Name +" from: " + oldQua+ " to be: " + item.Product.Stock);
            }
        }
    }
    // Restore the stock
    public void OnOrderFailed(Order<OrderItem> order)
    {
        if (order.Status is OrderStatus.Failed)
        {
            foreach (var item in order.Items)
            {
                int oldQua = item.Product.Stock;
                item.Product.Stock += item.Quantity;
                Console.WriteLine("Updating the inventory of " + item.Product.Name + " from: " + oldQua + " to be: " + item.Product.Stock);
=======
				item.Product.ReduceStock(item.Quantity);
                // item.Product.Stock -= item.Quantity;
>>>>>>> aebe2fa6ff070f67a58b63787626bd6a906ed48d
            }
        }
    }
}

public class Payment
{ 
    /// 4. Subscribe to the event ...--> parameter is the class that has the event
    public void Subscribe(OrderProcess<OrderItem> process)
    {
        process.OrderCreated += OnOrderCreated;

    }
    public void OnOrderCreated(Order<OrderItem> order)
    {
        double TotalPrice = 0;
        foreach (var item in order.Items) {TotalPrice += item.ItemTotalPrice;}
        Console.WriteLine("the total price of order:" + order.Id + " is " + TotalPrice);
    }
}
