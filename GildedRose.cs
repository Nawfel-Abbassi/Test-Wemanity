using System.Collections.Generic;
namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                ManageQuality(i);

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }
                if (Items[i].SellIn < 0)
                {
                    ManageQuality(i);
                }
            }
        }

        #region private methods

        private void ManageQuality(int i)
        {
            if (Items[i].Name != "Aged Brie")
            {
                Items[i].Quality = IncreaseOrDegradeQuality(Items[i].Name, Items[i].Quality, Items[i].SellIn);
            }
            else
            {
                Items[i].Quality = IncreaseQuality(Items[i].Quality);
            }
        }

        private int DegradeQuality(string name, int quality)
        {
            if (quality > 0)
            {
                if (name != "Sulfuras, Hand of Ragnaros")
                {
                    quality = quality - 1;
                }
                if (name == "Conjured Mana Cake")
                {
                    quality = quality - 1;
                }
            }
            return quality;
        }

        private int IncreaseQualityBackstage(int sellIn, int quality)
        {
            if (sellIn­­ > 0)
            {
                if (quality < 50)
                {
                    quality = quality + 1;
                    if (sellIn < 11)
                    {
                        quality = IncreaseQuality(quality);
                    }
                    if (sellIn < 6)
                    {
                        quality = IncreaseQuality(quality);
                    }
                }
            }
            else
            {
                quality = 0;
            }
            return quality;
        }

        public int IncreaseQuality(int quality)
        {
            if (quality < 50)
            {
                quality = quality + 1;
            }
            return quality;
        }

        private int IncreaseOrDegradeQuality(string name, int quality, int sellIn)
        {
            if (name != "Backstage passes to a TAFKAL80ETC concert")
            {
                quality = DegradeQuality(name, quality);
            }
            else
            {
                quality = IncreaseQualityBackstage(sellIn, quality);
            }
            return quality;
        }
        #endregion
    }
}