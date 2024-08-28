class Sales
{
    private Costumer? buyer;
    private decimal finalPrice = 0;
    public int? Id { get; set; }
   public Costumer? Buyer { get{
        return buyer;
    } set{value = this.buyer;} }
    List<Product> ProductList { get; set; }
    public PaymentForm PaymentForm { get; set; }
    public decimal FinalPrice { get{return this.finalPrice;}}

    public Sales(List<Product> products, PaymentForm payment,  Costumer? buyer){
        this.ProductList = products;
        this.PaymentForm = payment;
        foreach (Product product in products){
            this.finalPrice += product.Price;
        }
        if(buyer is not null){
            this.buyer = buyer;
        }
    }

    public void AddItem(Product product){
        this.ProductList.Add(product);
        this.finalPrice += product.Price;
    }

    public override string ToString()
    {
        string items = "";

        foreach(Product item in this.ProductList){
            items += "" + item.ToString() + "\n";
        }
        return $"Id: {this.Id}\nBuyer:{this.Buyer}\nProductList:{items}\nFinalPrice:{this.FinalPrice}\n Payment Form: {this.PaymentForm}";
    }

    public string GenerateCoupom()
    {
        string items = "";

        foreach(Product item in this.ProductList){
            items += "" + item.ToString() + "\n";
        }
        return $"Cupom Fiscal:\nBuyer:{this.Buyer.ToString()}\nProductList:{items}\nFinalPrice:{this.FinalPrice}\nPayment Form: {this.PaymentForm}";
    }
};