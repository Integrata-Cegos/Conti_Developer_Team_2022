using Microsoft.EntityFrameworkCore;
using Javacream.Efc;
Console.WriteLine("Hello EntityFramwork");
LS_CatContext context = new LS_CatContext(); //Context ist nach Erzeugung "leichtgewichtig", keine Connection wird geöffnet
LS_Cat thommy = new LS_Cat("Thommy", 9.99, "brown");
Console.WriteLine(thommy);
context.LS_Cats.Add(thommy);
Console.WriteLine(thommy);
context.SaveChanges();//Connection wird erzeugt, Transaktion wird begonnen, SQL generiert und abgesetzt, Transaktion versucht zu committen, Connection wird geschlossen
Console.WriteLine(thommy);
thommy.Weight=5.6;
Console.WriteLine(thommy);
context.SaveChanges();
context.LS_Cats.Remove(thommy);
context.SaveChanges();
List<LS_Cat> LS_catList = context.LS_Cats.ToList();
LS_catList.ForEach(LS_cat => Console.WriteLine(LS_cat));
LS_Cat result = context.LS_Cats.Single(LS_cat => LS_cat.Id == 3); //Abfrage basiert auf einer LINQ-Methode
Console.WriteLine(result);
LS_Cat result2 = (from LS_cat in context.LS_Cats where LS_cat.Id == 4 select LS_cat).Single<LS_Cat>(); //Abfrage basiert auf einer LINQ-Abfrage
Console.WriteLine(result2);
LS_Cat result3 = context.LS_Cats.FromSqlRaw("select * from LS_CATS where id = '4'").Single<LS_Cat>(); //Abfrage basiert auf SQL
Console.WriteLine(result3);
LS_catList = context.LS_Cats.Where(LS_cat => LS_cat.Weight == 9.99).ToList();
LS_catList.ForEach(LS_cat => Console.WriteLine(LS_cat));