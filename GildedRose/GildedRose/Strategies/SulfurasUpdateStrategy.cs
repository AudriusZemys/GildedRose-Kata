using GildedRose.Strategies.Interfaces;

namespace GildedRose.Strategies
{
    // This strategy might fit "legendary" items more, however, requirements are unclear
    public class SulfurasUpdateStrategy : IUpdateStrategy
    {
        public void Update(Item item)
        {
            // - "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        }
    }
}
