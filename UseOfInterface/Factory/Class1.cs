using MathsComponents;

namespace Factory
{
    public static class FactoryMaths
    {
        public static dynamic createMaths()
        {
            return new MathsLibrary();
        }
    }
}
