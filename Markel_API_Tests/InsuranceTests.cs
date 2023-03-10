using Markel_API.Interfaces;
using Markel_API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Assert = NUnit.Framework.Assert;

namespace Markel_API_Tests
{
    [TestClass]
    public class InsuranceTests
    {
        private Mock<IInsuranceService> _insuranceService;

        [TestMethod]
        public async Task Get_GivenOneCompany_ReturnsCompanyDetails()
        {
            //Arrange
            int testId = 1;
            _insuranceService = new Mock<IInsuranceService>();
            var service = _insuranceService.Object;
            var testCompany = new Company
            {
                Id = 1,
                Name = "XYZ Corp",
                Address1 = "dummy lane1",
                Address2 = "dummy address2",
                Address3 = "dummy address3",
                Postcode = "postcode1",
                Country = "UK",
                InsuranceEndDate = DateTime.Today,
                Active = true,
                HasActiveInsurancePolicy = true
            };
            _insuranceService
                .Setup(x=>x.GetCompany(testId))
                .ReturnsAsync(testCompany);

            //Act
            var result = await service.GetCompany(testId);

            //Assert
            Assert.That(result, Is.Not.Null);
            _insuranceService.Verify(x => x.GetCompany(testId), Times.Once());
        }
        [TestMethod]
        public async Task Get_GivenOneCompany_ReturnsAllClaims()
        {
            //Arrange
            int testCompanyId = 1;
            _insuranceService = new Mock<IInsuranceService>();
            var service = _insuranceService.Object;
            var testCompany = new Company
            {
                Id = 1,
                Name = "XYZ Corp",
                Address1 = "dummy lane1",
                Address2 = "dummy address2",
                Address3 = "dummy address3",
                Postcode = "postcode1", 
                Country = "UK",
                InsuranceEndDate = DateTime.Today,
                Active = true,
                HasActiveInsurancePolicy = true
            };
            var testClaim = new Claims
            {
                UCR = "Claim1",
                CompanyId = testCompanyId,
                ClaimDate = DateTime.Today,
                LossDate = DateTime.Today,
                AssuredName = "Claim1",
                IncurredLoss = 10000.55m,
                Closed = true
            };
            var testClaim2 = new Claims
            {
                UCR = "Claim2",
                CompanyId = testCompanyId,
                ClaimDate = DateTime.Today,
                LossDate = DateTime.Today,
                AssuredName = "Claim2",
                IncurredLoss = 10000.55m,
                Closed = true
            };
            _insuranceService
                .Setup(x => x.GetCompanyClaims(testCompanyId))
                .ReturnsAsync(new List<Claims> { testClaim, testClaim2 });

            //Act
            var result = await service.GetCompanyClaims(testCompanyId);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(2));
            _insuranceService.Verify(x => x.GetCompanyClaims(testCompanyId), Times.Once());

        }
        [TestMethod]
        public async Task Get_GivenOneClaimId_ReturnsClaimDetails()
        {
            //Arrange
            string testClaimId = "Claim1";
            _insuranceService = new Mock<IInsuranceService>();
            var service = _insuranceService.Object;
            var testClaim = new Claims
            {
                UCR = "Claim1",
                CompanyId = 1,
                ClaimDate = DateTime.Today,
                LossDate = DateTime.Today,
                AssuredName = "Claim1",
                IncurredLoss = 10000.55m,
                Closed = true
            };
            var testClaim2 = new Claims
            {
                UCR = "Claim2",
                CompanyId = 2,
                ClaimDate = DateTime.Today,
                LossDate = DateTime.Today,
                AssuredName = "Claim2",
                IncurredLoss = 10000.55m,
                Closed = true
            };
            _insuranceService
                .Setup(x=>x.GetClaims(It.IsAny<string>()))
                .ReturnsAsync(testClaim);

            //Act
            var result = await service.GetClaims(testClaimId);

            //Assert
            Assert.That(result, Is.Not.Null);
            _insuranceService.Verify(x => x.GetClaims(testClaimId),Times.Once);
        }
    }
}