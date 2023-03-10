using Microsoft.EntityFrameworkCore;

namespace Markel_API.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company
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
                    HasActiveInsurancePolicy = false
                },
                new Company
                {
                    Id = 2,
                    Name = "ABC Corp",
                    Address1 = "dummy lane1",
                    Address2 = "dummy address2",
                    Address3 = "dummy address3",
                    Postcode = "postcode1",
                    Country = "UK",
                    InsuranceEndDate = DateTime.Today,
                    Active = true,
                    HasActiveInsurancePolicy = false
                },
                new Company
                {
                    Id = 3,
                    Name = "Markel",
                    Address1 = "dummy lane1",
                    Address2 = "dummy address2",
                    Address3 = "dummy address3",
                    Postcode = "postcode1",
                    Country = "UK",
                    InsuranceEndDate = DateTime.Today,
                    Active = true,
                    HasActiveInsurancePolicy = false
                },
                new Company
                {
                    Id = 4,
                    Name = "Lyod's",
                    Address1 = "dummy lane1",
                    Address2 = "dummy address2",
                    Address3 = "dummy address3",
                    Postcode = "postcode1",
                    Country = "UK",
                    InsuranceEndDate = DateTime.Today,
                    Active = true,
                    HasActiveInsurancePolicy = false
                });
            modelBuilder.Entity<Claims>().HasData(
                 new Claims
                 {
                     UCR = "Claim1",
                     CompanyId = 1,
                     ClaimDate = DateTime.Today,
                     LossDate = DateTime.Today,
                     AssuredName = "Claim1",
                     IncurredLoss = 10000.55m,
                     Closed = true
                 },
                  new Claims
                  {
                      UCR = "Claim2",
                      CompanyId = 1,
                      ClaimDate = DateTime.Today,
                      LossDate = DateTime.Today,
                      AssuredName = "Claim1",
                      IncurredLoss = 10000.55m,
                      Closed = true
                  },
                   new Claims
                   {
                       UCR = "Claim3",
                       CompanyId = 2,
                       ClaimDate = DateTime.Today,
                       LossDate = DateTime.Today,
                       AssuredName = "Claim1",
                       IncurredLoss = 10000.55m,
                       Closed = true
                   },
                    new Claims
                    {
                        UCR = "Claim4",
                        CompanyId = 3,
                        ClaimDate = DateTime.Today,
                        LossDate = DateTime.Today,
                        AssuredName = "Claim1",
                        IncurredLoss = 10000.55m,
                        Closed = true
                    });
        }
    }
}
