class Product
{
    public int? Id { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }


    public Product(string Description, decimal Price){
        this.Description = Description;
        this.Price = Price;
    }
    public override string ToString() {
        return $"Id: {this.Id}\nDescription:{this.Description}\nPrice:{this.Price}";
    }

}