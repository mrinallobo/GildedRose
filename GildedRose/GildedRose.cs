using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class GildedRose
    {
        private IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var itemUpdater = ItemUpdaterFactory.CreateItemUpdater(item);
                itemUpdater.UpdateItem(item);
            }
        }
    }

    public interface IItemUpdater
    {
        void UpdateItem(Item item);
    }
    public class RegularItemUpdater : IItemUpdater
    {
        public void UpdateItem(Item item)
        {
            item.SellIn--;
            item.Quality = DecreaseQuality(item.SellIn, item.Quality);
            item.Quality = Math.Max(item.Quality, 0);
        }
        private int DecreaseQuality(int sellIn, int quality)
        {
            // Decrease quality by 1 if sellIn >= 0, else decrease by 2
            return sellIn >= 0 ? quality - 1 : quality - 2;
        }
    }

    public class ConjuredItem : IItemUpdater
    {
        public void UpdateItem(Item item)
        {
            item.SellIn--;
            item.Quality = DecreaseQuality(item.SellIn, item.Quality);
            item.Quality = Math.Max(item.Quality, 0);
        }
        private int DecreaseQuality(int sellIn, int quality)
        {
            return sellIn >= 0 ? quality - 2 : quality - 4;
        }
    }
    public class AgedBrieItemUpdater : IItemUpdater
    {
        public void UpdateItem(Item item)
        {
            item.SellIn--;
            item.Quality = IncreaseQuality(item.SellIn, item.Quality);
            item.Quality = Math.Min(item.Quality, 50);
        }
        private int IncreaseQuality(int sellIn, int quality)
        {
            // Increase quality by 1 if sellIn >= 0, else increase by 2
            return sellIn >= 0 ? quality + 1 : quality + 2;
        }
    }
    public class BackstagePassItemUpdater : IItemUpdater
    {
        public void UpdateItem(Item item)
        {
            item.SellIn--;
            item.Quality = IncreaseQuality(item.SellIn, item.Quality);
            item.Quality = Math.Max(item.Quality, 0);
        }
        private int IncreaseQuality(int sellIn, int quality)
        {
            return sellIn < 0
                ? 0
                : sellIn < 5
                    ? Math.Min(50, quality + 3)
                    : sellIn < 10
                        ? Math.Min(50, quality + 2)
                        : Math.Min(50, quality + 1);
        }

    }

    public class SulfurasItemUpdater : IItemUpdater
    {
        public void UpdateItem(Item item){}
    }

    public static class ItemUpdaterFactory
    {
        private static readonly Dictionary<string, Func<IItemUpdater>> ItemUpdaterFactories = new Dictionary<string, Func<IItemUpdater>>
        {
            { "Aged Brie", () => new AgedBrieItemUpdater() },
            { "Backstage passes to a TAFKAL80ETC concert", () => new BackstagePassItemUpdater() },
            { "Sulfuras, Hand of Ragnaros", () => new SulfurasItemUpdater() },
            { "Conjured Mana Cake", () => new ConjuredItem() }
        };

        public static IItemUpdater CreateItemUpdater(Item item)
        {
            if (ItemUpdaterFactories.TryGetValue(item.Name, out var factory))
            {
                return factory();
            }
            return new RegularItemUpdater();
        }
    }
}
