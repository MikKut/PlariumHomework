using System;

namespace FlowerShop
{
    internal class Package : Accessory, IHasPrice
    {
        private static bool priceIsSet = false;
        private const int QuantityOfPackageVariants = 3;
        public static int[] priceOfTheAccessoryOfTheColor = new int[QuantityOfPackageVariants] { 10, 12, 15 };
        public new readonly string _nameOfTheCategory = "package";
        public new string NameOfTheCategory => _nameOfTheCategory;
        Colors _color;
        public Colors Color
        {
            get => _color;
            set
            {
                int temp = (int)value;//to minimize casting
                if (temp < 0 || temp > QuantityOfPackageVariants)
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
            Blue
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
            for (int i = 0; i < QuantityOfPackageVariants; i++)
            {
                Console.Write((Colors)i + ": ");
                if (!int.TryParse(Console.ReadLine(), out priceOfTheAccessoryOfTheColor[i]))
                {
                    throw new InvalidCastException($"Cannot conver it to appropriate value for accessory");
                }

            }
        }
        public Package(Colors color)
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