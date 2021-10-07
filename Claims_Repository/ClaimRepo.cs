using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Repository
{
    //CRUD
    public class ClaimRepo
    {
        public readonly List<Claim> claimDirectory = new List<Claim>();

        //Create
        public bool CreateClaim(Claim info)
        {
            int startingCount = claimDirectory.Count;
            claimDirectory.Add(info);

            bool wasAdded = (claimDirectory.Count > startingCount);
            return wasAdded;

        }

        //Read
        public List<Claim> GetClaim()
        {
            return claimDirectory;
        }

        //Get by ClaimID
        public Claim ClaimId(int Id)
        {
            foreach (Claim info in claimDirectory)
            {
                if (info.ClaimId == Id)
                {
                    return info;
                }
            }
            return null;
        }

        //Update
        public bool UpdateClaim(Claim existingClaim, Claim newClaim)
        {
            if (existingClaim != newClaim)
            {
                existingClaim.ClaimId = newClaim.ClaimId;
                existingClaim.ClaimType = newClaim.ClaimType;
                existingClaim.Description = newClaim.Description;
                existingClaim.ClaimAmount = newClaim.ClaimAmount;
                existingClaim.DateOfClaim = newClaim.DateOfClaim;
                existingClaim.DateOfIncident = newClaim.DateOfIncident;
                existingClaim.IsValid = newClaim.IsValid;
                return true;
            }
            else
            {
                return false;
            }
        }



        //Delete
        public bool DeleteClaim (Claim existingClaim)
        {
            bool result = claimDirectory.Remove(existingClaim);
            return result;
        }
    }
}
