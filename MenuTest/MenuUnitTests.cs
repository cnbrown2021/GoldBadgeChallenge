using Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Cafe_UnitTest
{
    [TestClass]
    public class MenuUnitTests
    {
        private MenuRepo _repository;

        [TestInitialize]
        public void Arrange()
        {
            Menu chickenSandwhich = new Menu(5, "Chicken Sandwhich", "chicken sandwhich", "chicken breast", 2);
            Menu alfredoPasta = new Menu(6, "Alfredo Pasta", "pasta", "fettucine", 4);

            _repository = new MenuRepo();

            _repository.AddContentToDirectory(chickenSandwhich);
            _repository.AddContentToDirectory(alfredoPasta);
        }

        [TestMethod]
        public void AddToMenuDirectory_ShouldGetCorrectInfo()
        {
            //Arrange
            Menu item = new Menu();
            MenuRepo repository = new MenuRepo();

            //Act
            bool gain = repository.AddContentToDirectory(item);

            //Assert
            Assert.IsTrue(gain);
        }

        //Testing READ method
        [TestMethod]
        public void GetDirectory_ShouldReturnItemList()
        {
            //Arrange
            Menu item = new Menu(5, "Chicken Sandwhich", "chicken sandwhich", "chicken breast", 2);
            MenuRepo repo = new MenuRepo();

            repo.AddContentToDirectory(item);

            //Act
            List<Menu> listItem = repo.GetMenuItems();

            bool gain = listItem.Contains(item);

            //Assert
            Assert.IsTrue(gain);
        }

        [TestMethod]
        public void UpdateMenu_ShouldBeTrue()
        {
            //Arrange
            Menu itemUpdate = _repository.GetMenuNumber(1);
            Menu newItem = new Menu(1, "Grilled cheese", "cheese sandwhich", "gouda cheese", 1);

            //Act
            bool updateItem = _repository.UpdateMenu(itemUpdate, newItem);

            //Assert
            Assert.IsTrue(updateItem);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            //Arrange
            Menu itemDelete = _repository.GetMenuNumber(1);

            //Act
            bool removeItem = _repository.DeleteItem(itemDelete);

            //Assert
            Assert.IsTrue(removeItem);
        }
    }
}
