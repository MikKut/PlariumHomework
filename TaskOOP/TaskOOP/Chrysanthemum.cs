
using System;

namespace FlowerShop
{
    internal class Chrysanthemum : Flower
    {
        public string Name { get => "Chrisantemum"; }
        new DateTime _periodOfLife = new DateTime(1, 1, 1);
        public new DateTime PeriodOfLife { get => _periodOfLife; }
        public new DateTime TimeOfBeingCollected { get; set; }
        public Chrysanthemum(DateTime timeOfBeingCollected, int lengthOfStem, double basePrice, double additionalPricePerEachSmOfStem) : base(timeOfBeingCollected, lengthOfStem, basePrice, additionalPricePerEachSmOfStem)
        { }
        public Chrysanthemum() : base()
        { }
    }
}