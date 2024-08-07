using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void UpdateQuality_StandardItem_DegradesToZero()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 2, Quality = 4 } };
        GildedRose app = new GildedRose(Items);
        

        // Act/assert
        app.NewUpdateQuality();
        Assert.Equal(3, Items[0].Quality);
        Assert.Equal(1, Items[0].SellIn);

        app.NewUpdateQuality();
        Assert.Equal(2, Items[0].Quality);
        Assert.Equal(0, Items[0].SellIn);

        app.NewUpdateQuality();
        Assert.Equal(0, Items[0].Quality);
        Assert.Equal(-1, Items[0].SellIn);

        app.NewUpdateQuality();
        Assert.Equal(0, Items[0].Quality);
        Assert.Equal(-2, Items[0].SellIn);

    }

    [Fact]
    public void UpdateQuality_Sulfurus_DoesNotDegrade()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras", SellIn = 2, Quality = 80 } };
        GildedRose app = new GildedRose(Items);


        // Act/assert
        app.NewUpdateQuality();
        Assert.Equal(80, Items[0].Quality);
        Assert.Equal(2, Items[0].SellIn);

        app.NewUpdateQuality();
        Assert.Equal(80, Items[0].Quality);
        Assert.Equal(2, Items[0].SellIn);

        app.NewUpdateQuality();
        Assert.Equal(80, Items[0].Quality);
        Assert.Equal(2, Items[0].SellIn);

    }

    [Fact]
    public void UpdateQuality_BackStagePass_Increases()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 11, Quality = 0 } };
        GildedRose app = new GildedRose(Items);


        // Act/assert
        app.NewUpdateQuality();
        Assert.Equal(1, Items[0].Quality);
        Assert.Equal(10, Items[0].SellIn);

        app.NewUpdateQuality();
        Assert.Equal(3, Items[0].Quality);
        Assert.Equal(9, Items[0].SellIn);

        app.NewUpdateQuality();
        app.NewUpdateQuality();
        app.NewUpdateQuality();
        app.NewUpdateQuality();

        app.NewUpdateQuality();
        Assert.Equal(14, Items[0].Quality);
        Assert.Equal(4, Items[0].SellIn);

        app.NewUpdateQuality();
        app.NewUpdateQuality();
        app.NewUpdateQuality();
        app.NewUpdateQuality();
        app.NewUpdateQuality();
        Assert.Equal(0, Items[0].Quality);
        Assert.Equal(-1, Items[0].SellIn);

    }

    [Fact]
    public void UpdateQuality_AgedBrie_Increases()
    {
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 48 } };
        GildedRose app = new GildedRose(Items);

        // Act/assert
        app.NewUpdateQuality();
        Assert.Equal(49, Items[0].Quality);
        Assert.Equal(0, Items[0].SellIn);

        app.NewUpdateQuality();
        Assert.Equal(50, Items[0].Quality);
        Assert.Equal(-1, Items[0].SellIn);

        app.NewUpdateQuality();
        Assert.Equal(50, Items[0].Quality);
        Assert.Equal(-2, Items[0].SellIn);
    }

    [Fact]
    public void UpdateQuality_ConjuredItem_DegradesToZero()
    {
        // Arrange
        // Arrange
        IList<Item> Items = new List<Item> { new Item { Name = "Conjured foo", SellIn = 2, Quality = 7 } };
        GildedRose app = new GildedRose(Items);


        // Act/assert
        app.NewUpdateQuality();
        Assert.Equal(5, Items[0].Quality);
        Assert.Equal(1, Items[0].SellIn);

        app.NewUpdateQuality();
        Assert.Equal(3, Items[0].Quality);
        Assert.Equal(0, Items[0].SellIn);

        app.NewUpdateQuality();
        Assert.Equal(0, Items[0].Quality);
        Assert.Equal(-1, Items[0].SellIn);

        app.NewUpdateQuality();
        Assert.Equal(0, Items[0].Quality);
        Assert.Equal(-2, Items[0].SellIn);
    }
}