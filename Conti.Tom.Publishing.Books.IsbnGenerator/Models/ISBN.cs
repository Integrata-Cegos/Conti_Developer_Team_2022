namespace Conti.Tom.Publishing.Books.IsbnGenerator
{
    public class ISBN
    {
        private int _part1;
        private int _part2;
        private int _part3;
        private int _part4;

        public ISBN(int a, int b, int c, int d)
        {
            _part1 = a;
            _part2 = b;
            _part3 = c;
            _part4 = d;
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

            return toCompare._part1 == _part1 && toCompare._part2 == _part2 &&
                   toCompare._part3 == _part3 && toCompare._part4 == _part4;

        }

        public override int GetHashCode()
        {
            int hash = HashCode.Combine(_part1, _part2, _part3, _part4);
            return hash;
        }

        public override string ToString()
        {
            return $"{_part1}-{_part2}-{_part3}-{_part4}";
        }

    }
}
