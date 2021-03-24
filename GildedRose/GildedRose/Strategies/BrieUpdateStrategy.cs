using GildedRose.Strategies.Interfaces;

namespace GildedRose.Strategies
{
    // Maybe this applies to all cheeses? Or aged cheese? 
    public class BrieUpdateStrategy : IUpdateStrategy
    {
        private const int ChangeValue = 1;

        public void Update(Item item)
        {
            // 	- The Quality of an item is never more than 50 (edit: applies only to items that increase in quality).
            if (item.Quality < 50)
            {
                item.Quality += ChangeValue;
            }

            item.SellIn -= ChangeValue;

            if (item.SellIn < 0)
            {
                if (item.Quality < 50)
                {
                    item.Quality += ChangeValue;
                }
            }
        }
    }
}
