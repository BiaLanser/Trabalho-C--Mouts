
class ProductsRespository : IRepository<Product>
{
    public ProductsRespository(){}
    public override Product Alter(Product t)
    {
        Product product = this.Data.FirstOrDefault(x => x.Id == t.Id);
        if (product is null){
            throw new Exception("Product not found");
        }else{
            product.Description = t.Description;
            product.Price = t.Price;
            return product;
        }
    }

    public override Product Create(Product t)
    {
        if(t.Id != null){
            throw new ArgumentException("Product already has an Id");
        }
        t.Id = this.Data.Count() + 1;
        this.Data.Add(t);

        return t;
    }

    public override void Delete(int id)
    {
        this.Data.RemoveAll(x => x.Id == id);
    }

    public override List<Product> FindAll()
    {
        return this.Data;
    }

    public override Product FindById(int id)
    {
        var user = this.Data.FirstOrDefault(x => x.Id == id);
        if(user is null){
            throw new ArgumentException("Product not Found");
        }else{
            return user;
        }
    }
}