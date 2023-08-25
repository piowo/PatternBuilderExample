using System;
using System.Text;

namespace builderExample
{
    class MakePizza
    {
        public enum Sauce
        {
            Tomato, Danish, Bbq
        }

        private readonly bool _thinCake;
        private readonly int _quantityOfCheese;
        private readonly Sauce _kindOfSauce;
        private readonly bool _withMeat;
        private readonly bool _withVegetables;

         public MakePizza(Builder builder)
         {
                this._thinCake = builder.ThinCake;
                this._quantityOfCheese = builder.QuantityOfCheese;
                this._kindOfSauce = builder.KindOfSauce;
                this._withMeat = builder.WithMeat;
                this._withVegetables = builder.WithVegetables;
         }

        private String GetKindOfSauce(Sauce sauce)
        {
            StringBuilder nameOfSauce = new StringBuilder();
            switch (sauce)
            {
                case Sauce.Tomato:
                    nameOfSauce.Append("pomidorowy");
                    break;
                case Sauce.Bbq:
                    nameOfSauce.Append("BBQ");
                    break;
                case Sauce.Danish:
                    nameOfSauce.Append("duński");
                    break;
            }
            return nameOfSauce.ToString();
        }

      
        public override String ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("na " + (_thinCake ? "cienkim" : "grubym") + " cieście\n");
            stringBuilder.Append("ilość sera  : " + _quantityOfCheese + "\n");
            stringBuilder.Append("rodzaj sosu : " + GetKindOfSauce(_kindOfSauce) + "\n");
            stringBuilder.Append("dodatki : \n" +
                    "mięso: " + (_withMeat ? "tak" : "nie") + "\n" +
                    "warzywa: " + (_withVegetables ? "tak" : "nie") + "\n"
                    );
            return stringBuilder.ToString();
        }

        public class Builder
        {
            public bool ThinCake { get; private set; }
            public int QuantityOfCheese { get; private set; }
            public Sauce KindOfSauce { get; private set; } = Sauce.Tomato;
            public bool WithMeat { get; private set; } = true;
            public bool WithVegetables { get; private set; } = true;

            public Builder(bool thinCake, int quantityOfCheese)
            {
                this.ThinCake = thinCake;
                this.QuantityOfCheese = quantityOfCheese;
            }

            public Builder SetKindOfSauce(Sauce sauce)
            {
                this.KindOfSauce = sauce;
                return this;
            }

            public Builder SetWithMeat(bool withMeat)
            {
                this.WithMeat = withMeat;
                return this;
            }

            public Builder SetWithVegetables(bool withVegetables)
            {
                this.WithVegetables = withVegetables;
                return this;
            }

            public MakePizza Build()
            {
                return new MakePizza(this);
            }
        }
    }
}
