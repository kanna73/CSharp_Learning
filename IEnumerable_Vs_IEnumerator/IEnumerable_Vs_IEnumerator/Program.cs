namespace IEnumerable_Vs_IEnumerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IenumerableClass obj = new IenumerableClass();  
            obj.iterateViaIenumerable(obj.list);
            obj.iterateViaIEnumeratorUpto3(obj.enumerator);
        }
    }
}
