using Factory;
using Interface;
using MathsComponents;

namespace UseOfInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
           /* MathsLibrary m = new MathsLibrary();
            m.add(10, 10);*/
            var m1 = FactoryMaths.createMaths();  /*  one way of de-coupeling but the 
                                                   *  problem is if the method provider changes the method 
                                                   *  then the error will be detected only in the run time  */
           
            m1.add1(10, 10);  /* here this is add1 is not in MathsLibrary class and interface 
                               but there is no error displayed in the compile time */



            ImathsBasic m2 = FactoryMaths.createMaths();    
            m2.add(10, 10);

        }
    }
}
