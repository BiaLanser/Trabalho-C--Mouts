
class SalesRespository : IRepository<Sales>
{
    public SalesRespository(){}
    public override Sales Alter(Sales t)
    {
        throw new NotImplementedException();
    }

    public override Sales Create(Sales t)
    {
        CostumerRespository client = new();
        if(t.Id != null){
            throw new ArgumentException("Sales already has an Id");
        }
        t.Id = this.Data.Count() + 1;
        this.Data.Add(t);
        t.Buyer.AddPoints(t.FinalPrice);
        client.Alter(t.Buyer);

        return t;
    }

    public override void Delete(int id)
    {
        this.Data.RemoveAll(x => x.Id == id);
    }

    public override List<Sales> FindAll()
    {
        return this.Data;
    }

    public override Sales FindById(int id)
    {
        var user = this.Data.FirstOrDefault(x => x.Id == id);
        if(user is null){
            throw new ArgumentException("Sale not Found");
        }else{
            return user;
        }
    }
}