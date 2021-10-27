using System;

namespace FlowerShop
{
    internal abstract class Accessory : IHasPrice
    {
        public readonly string _nameOfTheCategory = "accessory";
        private const int QuantityOfVariants = 3;
        private double _totalPrice = 0;
        public double TotalPrice 
        {
            get => _totalPrice;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total price less than zero");
                }
                _totalPrice = value;
            }
              
        }
        public string NameOfTheCategory => _nameOfTheCategory;
        public void MakeMarkup(double quantityOfPercents)
        {
            if (quantityOfPercents < 0)
            {
                throw new ArgumentException("Wronng percent of markup");
            }
            else 
            {
                TotalPrice += TotalPrice * quantityOfPercents/100;
            }
        }
        public void MakeDiscount(double quantityOfPercents)
        {
            if (quantityOfPercents < 0 || quantityOfPercents>100)
            {
                throw new ArgumentException("Wronng percent of discount");
            }
            else
            {
                TotalPrice -= TotalPrice * quantityOfPercents / 100;
            }
        }
    }
}
