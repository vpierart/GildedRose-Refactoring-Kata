using System;
using System.Collections.Generic;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");


            List<BusinessRule>businessRules = new List<BusinessRule>
            {
                //Rules as described in the exercise range limits are all inclusive
                new BusinessRule { productName = "Aged Brie", dailyDelta = 1},
                new BusinessRule { productName = "Sulfuras, Hand of Ragnaros", minAllowedValue = 80, maxAllowedValue = 80, dailyDelta = 0, isLegendary = true},
                new BusinessRule { productName = "Backstage passes to a TAFKAL80ETC concert", sellInDateRangeTop = 0, minAllowedValue = 0, maxAllowedValue = 0, dailyDelta = 0},
                new BusinessRule { productName = "Backstage passes to a TAFKAL80ETC concert", sellInDateRangeBottom = 1, sellInDateRangeTop = 5, dailyDelta = 3},
                new BusinessRule { productName = "Backstage passes to a TAFKAL80ETC concert", sellInDateRangeBottom = 6, sellInDateRangeTop = 10, dailyDelta = 2},
                new BusinessRule { productName = "Backstage passes to a TAFKAL80ETC concert", sellInDateRangeBottom = 11, dailyDelta = 1},
                new BusinessRule { productName = "Conjured Mana Cake", isConjured = true}
            };

            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
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
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(Items);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j]);
                }
                Console.WriteLine("");
                //new method
                app.UpdateQuality(businessRules);
                //deprecated old method
                //app.UpdateQuality();
            }
            Console.ReadKey();
        }
    }
}
