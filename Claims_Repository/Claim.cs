using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Repository
{
    //POCO
    public class Claim
    {
        public Claim() { }
        public int ClaimId { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfClaim { get; set; }
        public DateTime DateOfIncident { get; set; }
        public bool IsValid { get; set; }

        public Claim(int claimId, string claimType, string description, decimal claimAmount, DateTime dateOfClaim, DateTime dateOfIncident, bool isValid)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfClaim = dateOfClaim;
            DateOfIncident = dateOfIncident;
            IsValid = isValid;
        }

        public bool Valid
        {
            get
            {
                if (IsValid)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        

    }
}
