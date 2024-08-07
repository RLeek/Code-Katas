using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void NewUpdateQuality()
    {
        Items = Items.Select(item =>
                item switch
                {
                    Item Conjured when Conjured.Name.Contains("Conjured") =>
                        UpdateConjuredItem(item),
                    Item Aged_Brie when Aged_Brie.Name.Contains("Aged Brie") =>
                        UpdateAgedBrie(item),
                    Item Backstage_Pass when Backstage_Pass.Name.Contains("Backstage passes") =>
                        UpdateBackstagePass(item),
                    Item Sulfuras when Sulfuras.Name.Contains("Sulfuras") =>
                        UpdateLegendaryItem(item),
                    Item _ => 
                        UpdateStandardItem(item)
                }).ToList();
    }

    private Item UpdateAgedBrie(Item item)
    {
        item.Quality = (item.Quality, item.SellIn) switch
        {
            (< 50, > 0) => int.Min(50, item.Quality + 1),
            (< 50, <= 0) => int.Min(50, item.Quality + 2),
            (50, _) => 50,
            (_) => throw new Exception()
        };

        item.SellIn -= 1;
        return item;
    }

    private Item UpdateBackstagePass(Item item)
    {
        item.Quality = item.SellIn switch
        {
            ( <= 0) => 0,
            ( <= 5) => int.Min(50, item.Quality + 3),
            ( <= 10) => int.Min(50, item.Quality + 2),
            (_) => int.Min(50, item.Quality+1)
        };
        item.SellIn -= 1;
        return item;
    }

    private Item UpdateLegendaryItem(Item item) => item;

    private Item UpdateConjuredItem(Item item)
    {
        // Unfortunately, since api is not functional - we have to modify in place 
        item.Quality = (item.SellIn, item.Quality) switch
        {
            (_, 0) => item.Quality,
            ( > 0, _) => int.Max(0, item.Quality - 2),
            ( <= 0, _) => int.Max(0, item.Quality - 4)
        };
        item.SellIn -= 1;

        return item;
    }

    private Item UpdateStandardItem(Item item)
    {
        // Unfortunately, since api is not functional - we have to modify in place 
        item.Quality = (item.SellIn, item.Quality) switch
        {
            (_, 0) => item.Quality,
            (> 0, _) => int.Max(0, item.Quality - 1),
            (<= 0, _ ) => int.Max(0, item.Quality - 2)
        };
        item.SellIn -= 1;

        return item;
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