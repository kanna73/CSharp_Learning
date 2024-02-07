namespace ExtensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Maths addObj = new Maths();
            addObj.Add(5, 6);
            addObj.sub(8,4);
        }
    }
}
