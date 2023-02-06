using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Popkultulista.App;
using Popkultulista.App.Abstract;
using Popkultulista.App.Managers;
using Popkultulista.Core;

namespace Popkultulista.Tests
{
    public class ItemManagerTests
    {
        [Fact]
        public void AddItem_AddsItemToTheList()
        {
            // Arrange
            ListItem item = new("test", 1, 1, 1, 1, 1);
            var mock = new Mock<IService<ListItem>>();
            mock.Setup(m => m.AddItem(item)).Returns(item.Id);
            var manager = new ItemManager(mock.Object);

            // Act
            manager.AddNewItem();

            // Assert
            mock.Verify(m => m.AddItem(item));
        }

        [Fact]
        public void RemoveItems_RemovesItemFromTheList()
        {
            // Arrange
            ListItem item = new("test", 1, 1, 1, 1, 1);
            var mock = new Mock<IService<ListItem>>();
            mock.Setup(m => m.RemoveItem(item));
            var manager = new ItemManager(mock.Object);

            // Act
            manager.RemoveItem();

            // Assert
            mock.Verify(m => m.RemoveItem(item));
        }

        [Fact]
        public void GetItemById_ReturnsItem()
        {
            // Arrange
            ListItem item = new("test", 1, 1, 1, 1, 1);
            var mock = new Mock<IService<ListItem>>();
            mock.Setup(m => m.GetItemById(item.Id)).Returns(item);
            mock.Setup(m => m.GetAllItems()).Returns(new List<ListItem>() { item });
            mock.Setup(m => m.IsEmpty()).Returns(false);
            var manager = new ItemManager(mock.Object);

            // Act
            manager.GetItem();

            // Assert
            mock.Verify(m => m.GetItemById(item.Id));
        }
    }
}
