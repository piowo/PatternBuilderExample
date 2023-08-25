using System;


namespace builderExample
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Zastosowanie wzorca Builder.\n");
            Console.WriteLine("Przygotowujemy pizze:");
            Console.WriteLine("============================\n");

            MakePizza pizza = new MakePizza.Builder(true, 20)
                    .SetKindOfSauce(MakePizza.Sauce.Bbq)
                    .SetWithMeat(true)
                    .SetWithVegetables(true)
                    .Build();
            
            Console.WriteLine(pizza);
            Console.ReadKey();
        }
    }
}
