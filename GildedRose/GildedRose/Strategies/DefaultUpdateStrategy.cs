using GildedRose.Strategies.Interfaces;

namespace GildedRose.Strategies
{
    public class DefaultUpdateStrategy : IUpdateStrategy
    {
        // SHORTCUT: would be configurable ideally.
        private const int ReductionValue = 1;

        public void Update(Item item)
        {
            // Taken from requirements.
            // - At the end of each day our system lowers both (edit: Quality and SellIn) values for every item.
            // - The Quality of an item is never negative.
            if (item.Quality > 0)
            {
                item.Quality -= ReductionValue;
            }

            item.SellIn -= ReductionValue;

            // - Once the sell by date has passed, Quality degrades twice as fast.
            if (item.SellIn < 0)
            {
                // Just reduce the quality once more.
                if (item.Quality > 0)
                {
                    item.Quality -= ReductionValue;
                }
            }
        }
    }
}
