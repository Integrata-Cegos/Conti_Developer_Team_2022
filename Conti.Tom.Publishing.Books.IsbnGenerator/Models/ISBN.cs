namespace Conti.Tom.Publishing.Books.IsbnGenerator.Models
{
    public class ISBN
    {
        private string _prefix;
        private string _countryCode;
        private int _part1;
        private int _part2;
        private int _part3;
        private int _part4;

        public ISBN(int p1, int p2, int p3, int p4) : this("ISBN:", "-world", p1, p2, p3, p4)
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
            return $"{_prefix}{_part1}-{_part2}-{_part3}-{_part4}{_countryCode}";
        }

    }
}
