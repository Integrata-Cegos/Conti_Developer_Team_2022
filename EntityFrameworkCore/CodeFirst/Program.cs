using Conti.AB.Efc;

Console.WriteLine("Hello EntityFramework");
BleiCatContext context = new BleiCatContext();
BleiCat schnurri = new BleiCat("Schnurri", 9.99, "schwarz-weiß");
Console.WriteLine(schnurri);
context.BleiCats.Add(schnurri);
Console.WriteLine(schnurri);
context.SaveChanges();
Console.WriteLine(schnurri);
schnurri.Weight = 5.0;
Console.WriteLine(schnurri);
context.SaveChanges();
context.BleiCats.Remove(schnurri);
context.SaveChanges();
List<BleiCat> catList = context.BleiCats.ToList();
catList.ForEach(cat => Console.WriteLine(cat));
BleiCat result = context.BleiCats.Single(cat => cat.Id == 4);
Console.WriteLine(result);