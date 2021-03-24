using FluentAssertions;
using GildedRose.Strategies;
using GildedRose.Strategies.Interfaces;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class SulfurasUpdateStrategyTests
    {
        IUpdateStrategy _strategy;

        [SetUp]
        public void SetUp()
        {
            _strategy = new SulfurasUpdateStrategy();
        }

        [TestCase(3, 6, 3, 6)] // Normal
        public void Update_behaves_correctly(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var backstagePass = new Item { Name = ItemNames.Sulfuras, SellIn = sellIn, Quality = quality };
            _strategy.Update(backstagePass);
            backstagePass.Name.Should().Be(ItemNames.Sulfuras);
            backstagePass.Quality.Should().Be(expectedQuality);
            backstagePass.SellIn.Should().Be(expectedSellIn);
        }
    }
}
