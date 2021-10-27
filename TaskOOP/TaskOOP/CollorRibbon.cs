using System;

namespace FlowerShop
{
    internal class ColorRibbon : Accessory
    {
        private static bool priceIsSet = false;
        private const int QuantityOfVariants = 3;
        public static int[] priceOfTheAccessoryOfTheColor = new int[QuantityOfVariants];
        private new readonly string _nameOfTheCategory = "collor ribbon";
        public new string NameOfTheCategory => _nameOfTheCategory;
        Colors _color;
        public Colors Color
        {
            get => _color;
            set
            {
                int temp = (int)value;//to minimize casting
                if (temp < 0 || temp > QuantityOfVariants)
                {
                    throw new ArgumentException($"Color by index {temp} does not exist");
                }
                _color = value;
            }
        }
        public enum Colors
        {
            Red = 0,
            Yellow,
            Green
        };
        public virtual int this[int index]
        {
            get => priceOfTheAccessoryOfTheColor[index];
            private set
            {
                if (index < 0 && index > 3 && value < 0)
                {
                    throw new IndexOutOfRangeException($"Wrong index or value for array of accessory");
                }
                priceOfTheAccessoryOfTheColor[index] = value;
            }
        }
        public void RearrengeThePrice()
        {
            Console.WriteLine($"Set prices of {NameOfTheCategory}");
            for (int i = 0; i < QuantityOfVariants; i++)
            {
                Console.Write((Colors)i + ": ");
                if (!int.TryParse(Console.ReadLine(), out priceOfTheAccessoryOfTheColor[i]))
                {
                    throw new InvalidCastException($"Cannot conver it to appropriate value for accessory");
                }

            }
        }
        public ColorRibbon(Colors color)
        {
            Color = color;
            if (!priceIsSet)
            {
                RearrengeThePrice();
                priceIsSet = true;
            }
            TotalPrice += priceOfTheAccessoryOfTheColor[(int)color];
        }

    }
}