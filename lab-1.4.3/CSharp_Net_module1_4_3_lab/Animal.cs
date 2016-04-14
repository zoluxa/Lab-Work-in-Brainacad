using System;
using System.Collections;

namespace CSharp_Net_module1_4_3_lab
{
    // 12) change methods of sorting to properties

    // 1) implement interface IComparable
    public class Animal : IComparable
    {
        // 2) declare properties and parameter constructor
        public string Genus { get; set; }
        public int Weight { get; set; }
        // 3) implement method ComareTo()
        // it comares Genus of type string - return result of method String.Compare 
        // for this.genus and argument object
        // don't forget to cast object to Animal
        public Animal(string __genus, int __weight) {
            Genus = __genus;
            Weight = __weight;
        }

        int IComparable.CompareTo(object obj)
        {
            Animal t1 = obj as Animal;
            
            if (t1 != null) 
                return String.Compare(this.Genus, t1.Genus);
            else
                throw new ArgumentException("It's not an animal!!");
        }


        // 4) declare methods SortWeightAscending(), SortGenusDescending()
        // they are static and return IComparer
        // return type is custed from constructor of classes SortWeightAscendingHelper, 
        // SortGenusDescendingHelper calling 
        public static IComparer SortWeightAscending { get { return (IComparer)new SortWeightAscendingHelper(); } }

        public static IComparer SortGenusDescending { get { return (IComparer)new SortGenusDescendingHelper(); } }

        // 5) declare 2 nested private classes SortWeightAscendingHelper, SortGenusDescendingHelper 
        // they implement interface IComparer
        // every nested class has implemented method Comare with 2 parameters of object and return int
        // class SortWeightAscendingHelper sort weight by ascending
        // class SortGenusDescendingHelper sort genus by descending
        private class SortWeightAscendingHelper : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                Animal o1 = x as Animal;
                Animal o2 = y as Animal;
                if (o1 != null && o2 != null)
                    return o1.Weight.CompareTo(o1.Weight);
                else
                    throw new NotImplementedException("Something went wrong...");
            }
        }

        private class SortGenusDescendingHelper : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                Animal o1 = x as Animal;
                Animal o2 = y as Animal;
                if (o1 != null && o2 != null)
                    return String.Compare(o1.Genus, o2.Genus);
                else
                    throw new NotImplementedException("Something went wrong...");
            }
        }
    }
}
