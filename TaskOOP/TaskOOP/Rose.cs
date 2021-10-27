
using System;

namespace FlowerShop
{
    internal class Rose : Flower
    {
        private const double DiscountWhenWithThorns = 0.1;
        private const double MarkupWhenWithoutThorns = 11.2;
        private bool _hasThorn;
        public string Name { get => "Rose"; }
        readonly new DateTime _periodOfLife = new DateTime(1, 1, 9);
        public new DateTime PeriodOfLife { get => _periodOfLife; }
        public bool HasThorn { get; set; }
        public Rose(DateTime timeOfBeingCollected, int lengthOfStem, double basePrice, double additionalPricePerEachSmOfStem, bool hasThorn) : base(timeOfBeingCollected, lengthOfStem, basePrice, additionalPricePerEachSmOfStem)
        {
            HasThorn = hasThorn;
            if (hasThorn)
            {
                AdditionalPrice -= additionalPricePerEachSmOfStem * DiscountWhenWithThorns;
            }
        }
        public Rose() : base()
        { }
        public void DeleteThorn()
        {
            if (HasThorn)
            {
                AdditionalPrice += AdditionalPrice * MarkupWhenWithoutThorns;
                HasThorn = false;
            }
        }
    }
}