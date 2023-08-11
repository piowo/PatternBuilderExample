using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace builderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zastosowanie wzorca Builder.\n");
            Console.WriteLine("Przygotowujemy pizze:");
            Console.WriteLine("============================\n");

            MakePizza pizza = new MakePizza.Builder(true, 20)
                    .setKindOfSauce(MakePizza.Sauce.BBQ)
                    .setWithMeat(true)
                    .setWithVegetables(true)
                    .build();
            
            Console.WriteLine(pizza);
            Console.ReadKey();
        }
    }
}
