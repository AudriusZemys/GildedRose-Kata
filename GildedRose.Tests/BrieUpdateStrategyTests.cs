using FluentAssertions;
using GildedRose.Strategies;
using GildedRose.Strategies.Interfaces;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class BrieUpdateStrategyTests
    {
        IUpdateStrategy _strategy;

        [SetUp]
        public void SetUp()
        {
            _strategy = new BrieUpdateStrategy();
        }

        [TestCase(2, 0, 1, 1)] // Normal
        [TestCase(3, 50, 2, 50)] // Quality does not exceed 50
        public void Update_behaves_correctly(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var backstagePass = new Item { Name = ItemNames.Brie, SellIn = sellIn, Quality = quality };
            _strategy.Update(backstagePass);
            backstagePass.Name.Should().Be(ItemNames.Brie);
            backstagePass.Quality.Should().Be(expectedQuality);
            backstagePass.SellIn.Should().Be(expectedSellIn);
        }
    }
}
