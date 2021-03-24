using GildedRose.Strategies.Interfaces;

namespace GildedRose.Strategies
{
    public class BackstagePassUpdateStrategy : IUpdateStrategy
    {
        private const int ChangeValue = 1;

        public void Update(Item item)
        {
            // 	- The Quality of an item is never more than 50
            if (item.SellIn > 0)
            {
                if (item.Quality < 50)
                {
                    item.Quality += ChangeValue;
                }
            }

            // 	Quality increases by 2 when there are 10 days or less.
            if (item.SellIn <= 10)
            {
                item.Quality = UpdateQuality(item.Quality, 50);
            }

            // and by 3 when there are 5 days or less
            if (item.SellIn <= 5)
            {
                item.Quality = UpdateQuality(item.Quality, 50);
            }

            item.SellIn -= ChangeValue;

            // but Quality drops to 0 after the concert
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }

        private int UpdateQuality(int quality, int ifLessThan)
        {
            if (quality < 50)
            {
                quality += ChangeValue;
            }

            return quality;
        }
    }
}
