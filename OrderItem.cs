using System;

public class OrderItem
{
	public Product Product { get; set; }
	public int Quantity { get; set; }
	//public double TotalPrice { get; set=>  ; }

    public OrderItem(Product product, int quantity)
	{
		this.Product = product;
		this.Quantity = quantity;
	}

	public double ItemTotalPrice() => this.Product.Price * this.Quantity;
}
