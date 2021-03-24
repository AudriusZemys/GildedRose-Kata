using FluentAssertions;
using GildedRose.Strategies;
using GildedRose.Strategies.Interfaces;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class ConjuredUpdateStrategyTests
    {
        IUpdateStrategy _strategy;

        [SetUp]
        public void SetUp()
        {
            _strategy = new ConjuredUpdateStrategy();
        }

        [TestCase(3, 6, 2, 4)] // Normal
        [TestCase(3, 1, 2, 0)] // Quality does not go below 0
        public void Update_behaves_correctly(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var backstagePass = new Item { Name = ItemNames.ConjuredCake, SellIn = sellIn, Quality = quality };
            _strategy.Update(backstagePass);
            backstagePass.Name.Should().Be(ItemNames.ConjuredCake);
            backstagePass.Quality.Should().Be(expectedQuality);
            backstagePass.SellIn.Should().Be(expectedSellIn);
        }
    }
}
