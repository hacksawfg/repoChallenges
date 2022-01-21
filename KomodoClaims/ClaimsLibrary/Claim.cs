using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsLibrary
{
    public enum ClaimType
    {
        Car,
        Home,
        Theft
    }

    public class Claim
    {
        public Claim() { }

        public Claim(int claimID, ClaimType claimType, string claimDescription, decimal totalDamage, DateTime accidentDate, DateTime claimDate, bool claimValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            ClaimDescription = claimDescription;
            TotalDamage = totalDamage;
            AccidentDate = accidentDate;
            ClaimDate = claimDate;
        }

        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string ClaimDescription { get; set; }
        public decimal TotalDamage { get; set; }
        public DateTime AccidentDate { get; set; }
        public DateTime ClaimDate { get; set; }
        public bool ClaimValid { get; set; }
    }
}