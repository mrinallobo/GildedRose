using Xunit;
using System.Collections.Generic;
using GildedRose;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            //IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };
            //GildedRose app = new GildedRose(Items);
            //app.UpdateQuality();
            //Assert.Equal(19, Items[0].Quality);
            IList<Item> items = new List<Item> {new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
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
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6} };



            GildedRose.GildedRose app = new GildedRose.GildedRose(items);
            for (int i = 0; i < 30; i++)
                app.UpdateQuality();



            Assert.Equal(-20, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);



            Assert.Equal(-28, items[1].SellIn);
            Assert.Equal(50, items[1].Quality);



            Assert.Equal(-25, items[2].SellIn);
            Assert.Equal(0, items[2].Quality);



            Assert.Equal(0, items[3].SellIn);
            Assert.Equal(80, items[3].Quality);



            Assert.Equal(-1, items[4].SellIn);
            Assert.Equal(80, items[4].Quality);



            Assert.Equal(-15, items[5].SellIn);
            Assert.Equal(0, items[5].Quality);



            Assert.Equal(-20, items[6].SellIn);
            Assert.Equal(0, items[6].Quality);



            Assert.Equal(-25, items[7].SellIn);
            Assert.Equal(0, items[7].Quality);


            Assert.Equal(-27, items[8].SellIn);
            Assert.Equal(0, items[8].Quality);
        }
    }
}
