using Conti.AB.Efc;

Console.WriteLine("Hello EntityFramework");
BleiCatContext context = new BleiCatContext();
BleiCat schnurri = new BleiCat("Schnurri", 5.00, "schwarz-weiß");
Console.WriteLine(schnurri);
context.BleiCats.Add(schnurri);
Console.WriteLine(schnurri);
context.SaveChanges();
Console.WriteLine(schnurri);
schnurri.Weight = 6.5;
Console.WriteLine(schnurri);
context.SaveChanges();
context.BleiCats.Remove(schnurri);
context.SaveChanges();
List<BleiCat> catList = context.BleiCats.ToList();
catList.ForEach(bleiCat => Console.WriteLine(bleiCat));
BleiCat result = context.BleiCats.Single(bleiCat => bleiCat.Id ==5);
Console.WriteLine(result);