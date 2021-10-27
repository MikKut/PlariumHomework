using System;

namespace FlowerShop
{
    internal class Lily : Flower
    {
        public string Name { get => "Lily"; }
        DateTime _periodOfLife = new DateTime(1, 1, 10);
        public new DateTime PeriodOfLife { get => _periodOfLife; }
        public new DateTime TimeOfBeingCollected { get; set; }
        public Lily(DateTime timeOfBeingCollected, int lengthOfStem, double basePrice, double additionalPricePerEachSmOfStem) : base(timeOfBeingCollected, lengthOfStem, basePrice, additionalPricePerEachSmOfStem)
        {
        }
        public Lily() : base()
        { }
    }
}