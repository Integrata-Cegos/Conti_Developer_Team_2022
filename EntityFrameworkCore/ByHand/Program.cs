using Javacream.Efc;
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
Cat result = context.Cats.Single(cat => cat.Id == 2);
Console.WriteLine(result);

