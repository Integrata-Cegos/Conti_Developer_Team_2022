namespace Conti.BK.IsbnGenerator.API{
    public class Isbn
    {
        private string _prefix;
        private string _countryCode;
        private int _part1;
        private int _part2;
        private int _part3;
        private int _part4;
        public string Prifix {get{return _prefix;}}
        public string CountryCode {get{return _countryCode;}}
        public int Part1 {get{return _part1;}}
        public int Part2 {get{return _part2;}}
        public int Part3 {get{return _part3;}}
        public int Part4 {get{return _part4;}}
        public string IsbnString{
            get{
                return this.ToString();
            } 
            private set{
                this._countryCode = value.Split(':')[0];
                var split = value.Split(':')[1].Split("-");
                this._part1 = Convert.ToInt32(split[0]);
                this._part2 = Convert.ToInt32(split[1]);
                this._part3 = Convert.ToInt32(split[2]);
                this._part4 = Convert.ToInt32(split[3]);
                this._countryCode = split[4];
            }
        }
        public Isbn(string isbnString){
            this.IsbnString = isbnString;
        }
        public Isbn(int p1, int p2, int p3, int p4) :this("ISBN:", "-world", p1, p2, p3, p4)
        {}

        public Isbn(string prefix, string countryCode, int p1, int p2, int p3, int p4){
            this._part1 = p1;
            this._part2 = p2;
            this._part3 = p3;
            this._part4 = p4;
            this._countryCode = countryCode;
            this._prefix = prefix;
        }

        public override int GetHashCode()
        {
            //Prinzipiell OK, aber führt zu Performance-Problemen
            //return 0;
            //Gut unter Annahme, dass jeder Part nur den Wertebereich 1-999 haben kann
            return 1000000000 * _part1 + 1000000 * _part2 + 1000 * _part3 + _part4;
        }

        public override bool Equals(Object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                if (this == obj)
                {
                    return true;
                }
                if (obj.GetType() != this.GetType())
                {
                    return false;
                }

                Isbn toCompare = (Isbn)obj;

                return this._part1 == toCompare._part1 && this._part2 == toCompare._part2 && this._part3 == toCompare._part3 && this._part4 == toCompare._part4;
            }
        }


        public override string ToString()
        {
            string isbnAsString = _prefix + _part1 + "-" + _part2 + "-" + _part3 + "-" + _part4 + _countryCode;
            return isbnAsString;
        }

    }

    public interface IIsbnService{
        public Isbn Next();
    }
}