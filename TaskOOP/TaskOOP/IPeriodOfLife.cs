
using System;

namespace FlowerShop
{
    interface IPeriodOfLife
    {
        public DateTime PeriodOfLife
        {
            get;
        }
        public DateTime TimeOfBeingCollected
        {
            get;
        }
    }
}