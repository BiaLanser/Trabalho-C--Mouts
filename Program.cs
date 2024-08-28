
using System.Reflection.Metadata.Ecma335;

CostumerRespository repo = new();

repo.Create(new Costumer("Paola","11292902981"));

Costumer customer2 = new Costumer("Gabriel","112");
customer2.Id = 1;


SalesRespository salesRepo = new SalesRespository();
repo.Alter(customer2);

Costumer costumer= repo.FindById(1);


Product tv = new Product("TV", 30.00m);

List<Product> products = new(){tv};



salesRepo.Create(new Sales(products, PaymentForm.DIGITAL_WALLET, costumer));
List<Costumer> list = repo.FindAll();


foreach(Costumer i in list){
    System.Console.WriteLine(i.ToString());
}