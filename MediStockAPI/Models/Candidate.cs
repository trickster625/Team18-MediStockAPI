using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models
{
    public class Candidate
    {
        public int Candidate_ID { get; set; }

        public string Candidate_Name { get; set; }

        public string Candidate_Surname { get; set; }

        public string Candidate_Email { get; set; }

        public string Candidate_ContactNumber { get; set; }

        public byte[] Candidate_CVFile { get; set; }
    }
}