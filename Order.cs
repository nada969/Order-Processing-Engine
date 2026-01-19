using System;

public class Order<T>
{
    private T[] _items = new T[0];

    public int Id { get; set; }
	public Customer Customer { get; set; }
	public OrderItem OrderItem { get; set; }
	public bool Status { get; set; }
	public DateTime CreateAt { get; set; }
	//, DateTime createdAt
	
    public Order(int id, Customer cutomer, bool status)
	{
		this.Id = id;
		this.Customer = cutomer;
		this.Status = status;
		//this.CreateAt = createdAt;
	}

	private int updateStock()
	{
		if(this.Status is true)
		{
			return this.OrderItem.Product.Stock -= this.OrderItem.Quantity;
		}
		return this.OrderItem.Product.Stock;

    }

	public void AddItem(T item)
	{
	
		_items = _items.Append(item).ToArray();
        
    }
    public void PrintItems()
    {
		foreach(T item in _items){
            Console.WriteLine(item.ToString());
        }
    }
	public bool OrderIsEmpty => _items is null || _items.Length == 0;
	public int ItemsNum => _items is null ? 0 : _items.Length;
}
