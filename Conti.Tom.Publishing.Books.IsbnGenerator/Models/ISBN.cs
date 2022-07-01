using System.Text.RegularExpressions;

namespace Conti.Tom.Publishing.Books.IsbnGenerator.Models
{
    public class ISBN
    {
        private int _part1;

        public int Part1
        {
            get { return _part1; }
            set { _part1 = value; }
        }

        private int _part2;

        public int Part2
        {
            get { return _part2; }
            set { _part2 = value; }
        }

        private int _part3;

        public int Part3
        {
            get { return _part3; }
            set { _part3 = value; }
        }

        private int _part4;

        public int Part4
        {
            get { return _part4; }
            set { _part4 = value; }
        }



        private string _prefix;
        public string Prefix
        {
            get { return _prefix; }
            set { _prefix = value; }
        }

        private string _countryCode;
        public string  CountryCode
        {
            get { return _countryCode; }
            set { _countryCode = value; }
        }

        public ISBN()
        {

        }

        public ISBN(int p1, int p2, int p3, int p4) : this("ISBN:", "world", p1, p2, p3, p4)
        { }

        public ISBN(string prefix, string countryCode, int p1, int p2, int p3, int p4)
        {
            this._part1 = p1;
            this._part2 = p2;
            this._part3 = p3;
            this._part4 = p4;
            this._countryCode = countryCode;
            this._prefix = prefix;
        }

        public static ISBN TryParse(string isbnstring)
        {
            var isbncollection = Regex.Match(isbnstring, @"(.*:)(\d*)(?:-)(\d*)(?:-)(\d*)(?:-)(\d*)(.*)");
            var prefix = isbncollection.Groups[1].Value;
            int.TryParse(isbncollection.Groups[2].Value, out int part1);
            int.TryParse(isbncollection.Groups[3].Value, out int part2);
            int.TryParse(isbncollection.Groups[4].Value, out int part3);
            int.TryParse(isbncollection.Groups[5].Value, out int part4);
            var countrycode = isbncollection.Groups[6].Value;
            return new ISBN(prefix, countrycode, part1, part2, part3, part4);
        }

        public virtual string Info()
        {
            return ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            if (this == obj)
                return true;

            if (obj.GetType() != this.GetType())
                return false;


            ISBN toCompare = (ISBN)obj;

            return _part1 == toCompare._part1 && _part2 == toCompare._part2 && _part3 == toCompare._part3 && _part4 == toCompare._part4;
        }

        public override int GetHashCode()
        {
            int hash = HashCode.Combine(_part1, _part2, _part3, _part4);
            return hash;
        }

        public override string ToString()
        {
            return $"{_prefix}{_part1}-{_part2}-{_part3}-{_part4}-{_countryCode}";
        }

    }
}
