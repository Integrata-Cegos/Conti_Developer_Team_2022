using Microsoft.EntityFrameworkCore;
Console.WriteLine("Hello EntityFramwork");
/*using Javacream.Efc;
Console.WriteLine("Hello EntityFramwork");
CatContext context = new CatContext(); //Context ist nach Erzeugung "leichtgewichtig", keine Connection wird geöffnet
Cat thommy = new Cat("Thommy", 9.99, "brown");
Console.WriteLine(thommy);
context.Cats.Add(thommy);
Console.WriteLine(thommy);
context.SaveChanges();//Connection wird erzeugt, Transaktion wird begonnen, SQL generiert und abgesetzt, Transaktion versucht zu committen, Connection wird geschlossen
Console.WriteLine(thommy);
thommy.Weight=5.6;
Console.WriteLine(thommy);
context.SaveChanges();
context.Cats.Remove(thommy);
context.SaveChanges();
List<Cat> catList = context.Cats.ToList();
catList.ForEach(cat => Console.WriteLine(cat));
Cat result = context.Cats.Single(cat => cat.Id == 2);//Abfrage basiert auf einer LINQ-Methode
Cat result2 = (from cat in context.Cats where cat.Id == 3 select cat).Single<Cat>();//Abfrage basiert auf einer LINQ-Abfrage
Cat result3 = context.Cats.FromSqlRaw("select * from CATS where id = '4'").Single<Cat>();//Abfrage basiert auf SQL
Console.WriteLine(result);
*/

