using System;

public class Customer
{
	// //Fields
	// private int _id;
	// private string _name;
	// private string _email;
    //Properties
    public int Id { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	//Constructor
	public Customer(int id, string name, string email)
	{
		this.Id = id;
		this.Name = name;
		this.Email = email;
	}
}
