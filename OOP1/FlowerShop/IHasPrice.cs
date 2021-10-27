namespace FlowerShop
{
    interface IHasPrice
    {
        public double TotalPrice { get; }
        public void MakeMarkup(double quantityOfPercents);
        public void MakeDiscount(double quantityOfPercents);
    }
}
