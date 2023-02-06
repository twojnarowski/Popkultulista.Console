using FluentAssertions;
using Popkultulista.App;
using Popkultulista.Core;

namespace Popkultulista.Tests;

public class ItemServiceTests
{
    [Fact]
    public void AddItem_AddsItemToTheList()
    {
        // Arrange
        var itemService = new ListItemService();
        ListItem item = new("test", 1, 1, 1, 1, 1);

        // Act
        var returnedId = itemService.AddItem(item);

        // Assert
        var result = itemService.GetItemById(item.Id);
        result.Should().NotBeNull();
        result.Name.Should().Be("test");
        returnedId.Should().NotBeEmpty();
        returnedId.Should().Be(item.Id);
    }

    [Fact]
    public void GetAllItems_ReturnsAListOfAllItems()
    {
        // Arrange
        var itemService = new ListItemService();
        ListItem item = new("test", 1, 1, 1, 1, 1);
        ListItem item2 = new("test2", 1, 1, 1, 1, 1);
        itemService.Items.Add(item);
        itemService.Items.Add(item2);

        // Act
        var res = itemService.GetAllItems();

        // Assert
        res.Should().NotBeNull();
        res.Count.Should().Be(2);
    }

    [Fact]
    public void RemoveItems_RemovesItemFromTheList()
    {
        // Arrange
        var itemService = new ListItemService();
        ListItem item = new("test", 1, 1, 1, 1, 1);
        itemService.Items.Add(item);

        // Act
        itemService.RemoveItem(item);

        // Assert
        var result = itemService.GetItemById(item.Id);
        result.Should().BeNull();
    }

    [Fact]
    public void UpdateItem_UpdatesItemOnTheList()
    {
        // Arrange
        var itemService = new ListItemService();
        ListItem item = new("test", 1, 1, 1, 1, 1);
        itemService.Items.Add(item);

        // Act
        var itemToUpdate = itemService.GetItemById(item.Id);
        itemToUpdate.Name = "test2";
        itemService.UpdateItem(itemToUpdate);

        // Assert
        var result = itemService.GetItemById(itemToUpdate.Id);
        result.Should().NotBeNull();
        result.Name.Should().Be("test2");
    }

    [Fact]
    public void GetItemById_ReturnsItem()
    {
        // Arrange
        var itemService = new ListItemService();
        ListItem item = new("test", 1, 1, 1, 1, 1);
        itemService.Items.Add(item);

        // Act
        var returnedItem = itemService.GetItemById(item.Id);

        // Assert
        returnedItem.Should().NotBeNull();
        returnedItem.Name.Should().Be("test");
    }



}