using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICollection_Vs_IEnumerable
{
    public  class Class1
    {
        public ICollection<int> A;
        public IEnumerable<int> B;

        public Class1()
        {
            A = new List<int>()
            {
                1,2, 3, 4, 5, 6, 7,
            };
            B = new List<int>()
            {
                1, 2, 3, 4,
            };
        }

        public void addUSingICollection(int a)
        {
            A.Add(a);
        }
        public void addUSingIEnumerable(int a)
        {
/*            B.Add(a)   
 *            so the difference between ICollection and IEnumerable is that using ICollection we add ,delete (mutable) but using IEnumerable  is only readonly 
*/        }
    }
}
