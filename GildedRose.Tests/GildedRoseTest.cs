using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Tests
{
    public class GildedRoseTest
    {
        GildedRose gildedRose;
        IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

        [SetUp]
        public void SetUp()
        {
            gildedRose = new GildedRose(Items);
        }

        [Test]
        public void UpdateQuality_changes_values_accordingly()
        {
            gildedRose.UpdateQuality();

            gildedRose.Items[0].Name.Should().Be(Constants.DexterityVest);
            gildedRose.Items[0].SellIn.Should().Be(9);
            gildedRose.Items[0].Quality.Should().Be(19);

            gildedRose.Items[1].Name.Should().Be(Constants.Brie);
            gildedRose.Items[1].SellIn.Should().Be(1);
            gildedRose.Items[1].Quality.Should().Be(1);

            gildedRose.Items[2].Name.Should().Be(Constants.Elixir);
            gildedRose.Items[2].SellIn.Should().Be(4);
            gildedRose.Items[2].Quality.Should().Be(6);

            gildedRose.Items[3].Name.Should().Be(Constants.Sulfuras);
            gildedRose.Items[3].SellIn.Should().Be(0);
            gildedRose.Items[3].Quality.Should().Be(80);

            gildedRose.Items[4].Name.Should().Be(Constants.BackstagePass);
            gildedRose.Items[4].SellIn.Should().Be(14);
            gildedRose.Items[4].Quality.Should().Be(21);

            gildedRose.Items[5].Name.Should().Be(Constants.BackstagePass);
            gildedRose.Items[5].SellIn.Should().Be(9);
            gildedRose.Items[5].Quality.Should().Be(50);

            gildedRose.Items[6].Name.Should().Be(Constants.BackstagePass);
            gildedRose.Items[6].SellIn.Should().Be(4);
            gildedRose.Items[6].Quality.Should().Be(50);

            gildedRose.Items[7].Name.Should().Be(Constants.Cake);
            gildedRose.Items[7].SellIn.Should().Be(2);
            gildedRose.Items[7].Quality.Should().Be(5);
        }
    }
}
