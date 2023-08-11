using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace builderExample
{
    class MakePizza
    {
        public enum Sauce
        {
            TOMATO, DANISH, BBQ
        }

        private readonly bool thinCake;
        private readonly int quantityOfCheese;
        private readonly Sauce kindOfSauce;
        private readonly bool withMeat;
        private readonly bool withVegetables;

         public MakePizza(Builder builder)
         {
                this.thinCake = builder.thinCake;
                this.quantityOfCheese = builder.quantityOfCheese;
                this.kindOfSauce = builder.kindOfSauce;
                this.withMeat = builder.withMeat;
                this.withVegetables = builder.withVegetables;
         }

        private String getKindOfSauce(Sauce sauce)
        {
            StringBuilder nameOfSauce = new StringBuilder();
            switch (sauce)
            {
                case Sauce.TOMATO:
                    nameOfSauce.Append("pomidorowy");
                    break;
                case Sauce.BBQ:
                    nameOfSauce.Append("BBQ");
                    break;
                case Sauce.DANISH:
                    nameOfSauce.Append("duński");
                    break;
            }
            return nameOfSauce.ToString();
        }

      
        public override String ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("na " + (thinCake ? "cienkim" : "grubym") + " cieście\n");
            stringBuilder.Append("ilość sera  : " + quantityOfCheese + "\n");
            stringBuilder.Append("rodzaj sosu : " + getKindOfSauce(kindOfSauce) + "\n");
            stringBuilder.Append("dodatki : \n" +
                    "mięso: " + (withMeat ? "tak" : "nie") + "\n" +
                    "warzywa: " + (withVegetables ? "tak" : "nie") + "\n"
                    );
            return stringBuilder.ToString();
        }

        public class Builder
        {
            public bool thinCake { get; private set; }
            public int quantityOfCheese { get; private set; }
            public Sauce kindOfSauce { get; private set; } = Sauce.TOMATO;
            public bool withMeat { get; private set; } = true;
            public bool withVegetables { get; private set; } = true;

            public Builder(bool thinCake, int quantityOfCheese)
            {
                this.thinCake = thinCake;
                this.quantityOfCheese = quantityOfCheese;
            }

            public Builder setKindOfSauce(Sauce sauce)
            {
                this.kindOfSauce = sauce;
                return this;
            }

            public Builder setWithMeat(bool withMeat)
            {
                this.withMeat = withMeat;
                return this;
            }

            public Builder setWithVegetables(bool withVegetables)
            {
                this.withVegetables = withVegetables;
                return this;
            }

            public MakePizza build()
            {
                return new MakePizza(this);
            }
        }
    }
}
