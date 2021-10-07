using Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Claims_UnitTest
{
    [TestClass]
    public class ClaimUnitTest1
    {
        private ClaimRepo _claimRepository;

        [TestInitialize]
        public void Arrange()
        {
            Claim claimOne = new Claim(3, "car", "accident", 400, new DateTime(2021, 10, 03), new DateTime(2021, 10, 01), true);
            _claimRepository = new ClaimRepo();
            _claimRepository.CreateClaim(claimOne);
        }

        [TestMethod]
        public void CreateClaim_ShouldGetCorrectInfo()
        {
            //Arrange
            Claim info = new Claim();
            ClaimRepo repository = new ClaimRepo();

            //Act
            bool gain = repository.CreateClaim(info);

            //Assert
            Assert.IsTrue(gain);
        }

        [TestMethod]
        public void GetClaim_ShouldReturnList()
        {
            //Arrange
            Claim info = new Claim(3, "car", "accident", 400, new DateTime(2021, 10, 03), new DateTime(2021, 10, 01), true);
            ClaimRepo repo = new ClaimRepo();
            repo.CreateClaim(info);

            //Act
            List<Claim> listOfClaim = repo.GetClaim();
            bool gain = listOfClaim.Contains(info);

            //Assert
            Assert.IsTrue(gain);
        }

        [TestMethod]
        public void UpdateClaim_ShouldBeTrue()
        {
            //Arrange
            Claim claimUpdate = _claimRepository.ClaimId(1);
            Claim newClaim = new Claim(1, "car", "accident", 400, new DateTime(2021, 10, 02), new DateTime(2021, 10, 01), true);

            //Act
            bool updateClaim = _claimRepository.UpdateClaim(claimUpdate, newClaim);

            //Assert
            Assert.IsTrue(updateClaim);
        }

        [TestMethod]
        public void DeleteClaim_ShouldReturnTrue()
        {
            //Arrange
            Claim claimDelete = _claimRepository.ClaimId(1);

            //Act
            bool removeClaim = _claimRepository.DeleteClaim(claimDelete);

            //Assert
            Assert.IsTrue(removeClaim);
        }
    }
}
