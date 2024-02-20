using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable_Vs_IEnumerator
{
    public  class IenumerableClass
    {
        public List<int> number;
        public IEnumerable<int> list;
        public IEnumerator<int> enumerator;
        public IenumerableClass()
        {
            this.number=new List<int>()
        {
            0, 1, 2, 3, 4, 5,
        };
            this.list = (IEnumerable<int>)number;
            this.enumerator = this.number.GetEnumerator();
        }

        public void iterateViaIenumerable(IEnumerable<int> data)// here the state is not maintained because of the IEnumerable
        {
            foreach (int i in data)
            {
                Console.WriteLine(i);
            }
        }
        public void iterateViaIEnumeratorUpto3(IEnumerator<int> enumerator)
        {
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
                if(enumerator.Current == 3)
                {
                    iterateViaIEnumeratorabove3(enumerator);
                }
            }
        }
        public static void iterateViaIEnumeratorabove3(IEnumerator<int> enumerator)//here the state of the list is maintained because of the IEnumerator
        {
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }

    }
}
