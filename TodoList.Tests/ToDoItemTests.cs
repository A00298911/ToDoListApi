using System;
using TodoList.Models;
using Xunit;

namespace TodoList.Tests
{
    public class ToDoItemTests
    {
        [Fact]
        public void CanCreateToDoItem()
        {
            var item = new ToDoItem
            {
                Id = 1,
                Title = "Test Task",
                Description = "Test Description"
            };

            Assert.Equal(1, item.Id);
            Assert.Equal("Test Task", item.Title);
            Assert.Equal("Test Description", item.Description);
        }

        [Fact]
        public void CanMarkItemAsCompleted()
        {
            var item = new ToDoItem();
            item.IsCompleted = true;
            item.CompletedDate = DateTime.Now;

            Assert.True(item.IsCompleted);
            Assert.NotNull(item.CompletedDate);
        }

        [Fact]
        public void CanUpdateItemDetails()
        {
            var item = new ToDoItem { Title = "Old Title" };
            item.Title = "New Title";

            Assert.Equal("New Title", item.Title);
        }

        [Fact]
        public void CanCheckIfItemIsIncomplete()
        {
            var item = new ToDoItem { IsCompleted = false };

            Assert.False(item.IsCompleted);
            Assert.Null(item.CompletedDate);
        }
    }
}
