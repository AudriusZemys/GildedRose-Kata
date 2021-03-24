using FluentAssertions;
using GildedRose.Strategies;
using GildedRose.Strategies.Interfaces;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class DefaultUpdateStrategyTests
    {
        IUpdateStrategy _strategy;

        [SetUp]
        public void SetUp()
        {
            _strategy = new DefaultUpdateStrategy();
        }

        [TestCase(3, 6, 2, 5)] // Normal
        [TestCase(3, 0, 2, 0)] // Quality does not go below 0
        public void Update_behaves_correctly(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var backstagePass = new Item { Name = ItemNames.DexterityVest, SellIn = sellIn, Quality = quality };
            _strategy.Update(backstagePass);
            backstagePass.Name.Should().Be(ItemNames.DexterityVest);
            backstagePass.Quality.Should().Be(expectedQuality);
            backstagePass.SellIn.Should().Be(expectedSellIn);
        }
    }
}
