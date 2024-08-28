using System.Xml.Serialization;

public class Costumer
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public int Points { get; set; }

    public Costumer(string Name, string document){
        this.Name = Name;
        this.Document = document;
    }

    public override string ToString()
    {
        return $"Id: {this.Id}\nName:{this.Name}\nDocument:{this.Document}\nPoints:{this.Points}";
    }

    public void AddPoints(decimal value){
        if(value < 0){

            throw new ArgumentOutOfRangeException("Value below zero");
        }
        decimal  soma = 0;
        decimal valor = 10;

        while(soma < value){
            this.Points++;
            soma+=valor;
        }
    }
}
