
using System;

namespace FlowerShop
{
    internal abstract class Plant : IPeriodOfLife
    {
        DateTime _periodOfLife;
        DateTime _timeOfBeingCollected;
        public DateTime PeriodOfLife
        {
            get => _periodOfLife;
            protected set
            {
                _periodOfLife = value;
            }
        }
        public DateTime TimeOfBeingCollected
        {
            get => _timeOfBeingCollected;
            protected set
            {
                _timeOfBeingCollected = value;
            }
        }
    }
}