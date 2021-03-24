using GildedRose.Strategies;
using GildedRose.Strategies.Interfaces;

namespace GildedRose.Factories
{
    public class UpdateStrategyFactory
    {
        // Could play with switch expressions, but I don't have the newest VS installed and it does not support .NET 3.x :(
        // If/else sausage for now.
        // Also, else if's are not really necessary, just a personal preference.
        public static IUpdateStrategy GetUpdateStrategyForItem(Item item)
        {
            if (item.Name == ItemNames.BackstagePass)
            {
                return new BackstagePassUpdateStrategy();
            }
            else if (item.Name == ItemNames.Brie)
            {
                return new BrieUpdateStrategy();
            }
            else if (item.Name.StartsWith("Conjured"))
            {
                return new ConjuredUpdateStrategy();
            }
            else if (item.Name == ItemNames.Sulfuras)
            {
                return new SulfurasUpdateStrategy();
            }

            return new DefaultUpdateStrategy();
        }
    }
}
