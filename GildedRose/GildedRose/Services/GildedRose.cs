using GildedRose.Factories;
using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public IList<Item> Items { get; set; }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                // Since updateStrategy does only one thing now, it looks weird.
                // But the idea is that the factory would construct an appropriate UpdateStrategy and caller would
                // use it as he wants.
                var updateStrategy = UpdateStrategyFactory.GetUpdateStrategyForItem(item);
                updateStrategy.Update(item);
            }
        }
    }
}
