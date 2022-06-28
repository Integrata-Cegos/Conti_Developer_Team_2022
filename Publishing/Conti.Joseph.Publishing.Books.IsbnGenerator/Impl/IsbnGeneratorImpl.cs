using Conti.Joseph.IsbnGenerator.API;
namespace Conti.Joseph.IsbnGenerator.Impl
{

    public abstract class BaseIsbnService:IIsbnService{
        public abstract Isbn Next();
        public string Prefix{get; set;} = "";
        public string CountryCode{get; set;} = "";
    }
    public class CounterIsbnService:BaseIsbnService{
        private static int _counter = 1;

        public override Isbn Next(){
            return new Isbn(Prefix, CountryCode, 1,2,4, _counter++);

        }
    }

    public class RandomIsbnService:BaseIsbnService{
        private Random random = new Random();

        public override Isbn Next(){
            return new Isbn(Prefix, CountryCode, 1,2,3, random.Next(0, 999));

        }
    }
}
