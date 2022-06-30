namespace Conti.BK.Store.WebService;

public class Isbn
{
    

    public int p1 { get; set; }
    public int p2 { get; set; }
    public int p3 { get; set; }
    public int p4 { get; set; }
     public override int GetHashCode()
        {
            //Prinzipiell OK, aber führt zu Performance-Problemen
            //return 0;
            //Gut unter Annahme, dass jeder Part nur den Wertebereich 1-999 haben kann
            return 1000000000 * p1 + 1000000 * p2 + 1000 * p3 + p4;
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

                return this.p1 == toCompare.p1 && this.p2 == toCompare.p2 && this.p3 == toCompare.p3 && this.p4 == toCompare.p4;
            }
        }

}
