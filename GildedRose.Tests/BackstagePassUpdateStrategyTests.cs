using FluentAssertions;
using GildedRose.Strategies;
using GildedRose.Strategies.Interfaces;
using NUnit.Framework;

namespace GildedRose.Tests
{
    // Tests duplicate with GildedRoseTest, but let's keep it separate here for more cases
    public class BackstagePassUpdateStrategyTests
    {
        IUpdateStrategy _strategy;

        [SetUp]
        public void SetUp()
        {
            _strategy = new BackstagePassUpdateStrategy();
        }

        [TestCase(15, 20, 14, 21)] // Normal
        [TestCase(10, 10, 9, 12)] // 10 days or less
        [TestCase(10, 49, 9, 50)] // 10 days or less does not exceed maximum quality
        [TestCase(5, 10, 4, 13)] // 5 days or less
        [TestCase(5, 49, 4, 50)] // 5 days or less does not exceet maximum quality
        public void Update_behaves_correctly(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var backstagePass = new Item { Name = ItemNames.BackstagePass, SellIn = sellIn, Quality = quality };
            _strategy.Update(backstagePass);
            backstagePass.Name.Should().Be(ItemNames.BackstagePass);
            backstagePass.Quality.Should().Be(expectedQuality);
            backstagePass.SellIn.Should().Be(expectedSellIn);
        }
    }
}
