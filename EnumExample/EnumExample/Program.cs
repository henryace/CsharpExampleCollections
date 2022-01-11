using System;

namespace EnumExample
{
    enum Flowers
    {
        None,
        Daisy = 1,
        Lili = 2,
        Rose = 3
    }

    class Program
    {
        static void Main(string[] args)
        {
            Flowers Flower;

            if (Enum.TryParse("3", out Flower))
            {
                Console.WriteLine(Flower);
            }
        }
    }
}
