using Badge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Badge_UnitTest
{
    [TestClass]
    public class BadgeUnitTests
    {
        private BadgeRepo _badgeRepo;
        [TestInitialize]
        public void Arrange()
        {
            Badge employee = new Badge(4, "d4");
            _badgeRepo = new BadgeRepo();
            _badgeRepo.AddBadge(employee);
        }

        [TestMethod]
        public void AddBadge_ShouldGetInfo()
        {
            //Arrange
            Badge access = new Badge();
            BadgeRepo repository = new BadgeRepo();

            //Act
            bool gain = repository.AddBadge(access);

            //Assert
            Assert.IsTrue(gain); 
        }

        [TestMethod]
        public void ShowAccess_ShouldReturn()
        {
            //Arrange
            Badge access = new Badge(1,"d3");
            BadgeRepo repo = new BadgeRepo();
            repo.AddBadge(access);

            //Act
            List<Badge> listBadge = repo.ShowAccess();
            bool gain = listBadge.Contains(access);

            //Assert
            Assert.IsTrue(gain);
        }

        [TestMethod]
        public void UpdateDoor_ShouldBeTrue()
        {
            //Arrange
            Badge badgeUpdate = _badgeRepo.GetBadge(1);
            Badge newAccess = new Badge(1, "d5");

            //Act
            bool updateBadge = _badgeRepo.UpdateDoor(badgeUpdate, newAccess);

            //Assert
            Assert.IsTrue(updateBadge);
        }

        [TestMethod]
        public void DeleteAccess()
        {
            //Arrange
            Badge accessDelete = _badgeRepo.GetBadge(1);

            //Act
            bool removeAccess = _badgeRepo.DeleteDoor(accessDelete);

            //Assert
            Assert.IsTrue(removeAccess);
        }
    }
}
