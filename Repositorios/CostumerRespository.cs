
class CostumerRespository : IRepository<Costumer>
{
    public CostumerRespository(){}
    public override Costumer Alter(Costumer t)
    {
            Costumer customer = this.Data.FirstOrDefault(x => t.Id == x.Id);
            customer.Document = t.Document;
            customer.Name = t.Name;
            customer.Points = t.Points;
            return customer;
        
    }

    public override Costumer Create(Costumer t)
    {
        if(t.Id != null){
            throw new ArgumentException("Customer already has an Id");
        }
        t.Id = this.Data.Count() + 1;
        this.Data.Add(t);

        return t;
    }

    public override void Delete(int id)
    {
        this.Data.RemoveAll(x => x.Id == id);
    }

    public override List<Costumer> FindAll()
    {
        return this.Data;
    }

    public override Costumer FindById(int id)
    {
        var user = this.Data.FirstOrDefault(x => x.Id == id);
        if(user is null){
            throw new ArgumentException("User not Found");
        }else{
            return user;
        }
    }
}