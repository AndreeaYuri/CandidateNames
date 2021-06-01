﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CandidateNames.Candidate;
using NUnit.Framework;

namespace CandidateNames.Tests
{
    [TestFixture]
    public class CandidatesTests
    {


        [Test]
        public void CombineAllApplicants_NullLists_ThrowsException()
        {
            var candidates = new Candidates();
            List<string> developers = null;
            List<string> testers = null;
            Assert.Throws<NullReferenceException>(() => { candidates.CombineAllApplicants(developers, testers); });
        }
        [Test]
        public void CombineAllApplicants_PassValidLists_ReturnListOfStrings()
        {
            var candidates = new Candidates();
            List<string> developers = candidates.GetDeveloperJobApplicants().ToList();
            List<string> testers = candidates.GetTesterJobApplicants().ToList();
            Assert.That(candidates.CombineAllApplicants(developers, testers), Is.TypeOf<List<string>>());
        }
        [Test]
        public void CombineAllApplicants_SameNameInTwoLists_ReturnUniqueName()
        {
            var candidates = new Candidates();
            List<string> developers = new List<string>();
            developers.Add("Gherca, Andreea");
            developers.Add("Trillo, Alex");

            List<string> testers = new List<string>();
            testers.Add("Gherca, Andreea");

            Assert.That(candidates.CombineAllApplicants(developers, testers).Count(p => p == "Gherca, Andreea"), Is.EqualTo(1));
        }

    }
}