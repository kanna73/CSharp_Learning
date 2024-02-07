using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class MathWrapper
    {
        public static int sub(this Maths obj, int x, int y)
        {
            return x - y;
        }
    }
}
