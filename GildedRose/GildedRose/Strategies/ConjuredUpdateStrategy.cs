using GildedRose.Helpers;
using GildedRose.Strategies.Interfaces;

namespace GildedRose.Strategies
{
    // SHORTCUT: Could extend DefaultUpdateStrategy by overriding change values (let's say we have them in properties and
    // assign them from Options).
    public class ConjuredUpdateStrategy : IUpdateStrategy
    {
        // - "Conjured" items degrade in Quality twice as fast as normal items
        private const int QualityChangeValue = 2;
        private const int SellInChangeValue = 1;

        public void Update(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= QualityChangeValue;
            }

            item.SellIn -= SellInChangeValue;

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality -= QualityChangeValue;
                }
            }

            ItemQualityHelper.EnsureQualityIsNotNegative(item);
        }
    }
}
