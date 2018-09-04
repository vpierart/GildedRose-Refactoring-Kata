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


        public void UpdateQuality(List<BusinessRule> rules)
        {
            for (var i = 0; i < Items.Count; i++)
            {
                BusinessRule ruleToApply = getBusinessRule(rules, Items[i].Name, Items[i].SellIn);                
                Items[i].Quality = Items[i].Quality + ruleToApply.dailyDelta;
                if (Items[i].Quality > ruleToApply.maxAllowedValue) Items[i].Quality = ruleToApply.maxAllowedValue;
                if (Items[i].Quality < ruleToApply.minAllowedValue) Items[i].Quality = ruleToApply.minAllowedValue;
                if (!ruleToApply.isLegendary) Items[i].SellIn = Items[i].SellIn - 1;
            }
        }

        private BusinessRule getBusinessRule(List<BusinessRule> rules, string name, int sellIn)
        {

            foreach (var rule in rules)
            {
                if (rule.productName == name && (sellIn >= rule.sellInDateRangeBottom && sellIn <= rule.sellInDateRangeTop))
                return rule;
            }
            //if no defined rules, pick the default one (specifying the sellin date is passed or not)
            return new BusinessRule(sellIn > 0);
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {


                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
