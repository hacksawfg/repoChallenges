using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsLibrary
{
    public class ClaimsRepository
    {
        // CRU - no Delete (resolved outside of scope of code, removed from queue when claim dealt with)
        private readonly Queue<Claim> _claimQueue = new Queue<Claim>(); 

        // Create
        public bool AddNewClaim(Claim newClaim)
        {
            int startingCount = _claimQueue.Count;
            _claimQueue.Enqueue(newClaim);

            return _claimQueue.Count > startingCount;
        }

        // Read
        public Queue<Claim> GetClaimList()
        {
            return _claimQueue;
        }
        
        // Update
        public void DealWithClaim()
        {
            // check out Peek method for queue also 
            _claimQueue.Dequeue();
        }

    }
}