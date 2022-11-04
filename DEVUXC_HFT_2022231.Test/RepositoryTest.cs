using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEVUXC_HFT_2022231.Repository.Repositories;
using DEVUXC_HFT_2022231.Repository;
using System.Xml;
using Moq;
using DEVUXC_HFT_2022231.Repository.Interfaces;
using DEVUXC_HFT_2022231.Models;

namespace DEVUXC_HFT_2022231.Test
{
    [TestFixture]
    public class RepositoryTest
    {
        F1DbContext cxt;
        Mock< IRepository<Driver>> mockIDriverRepo;
        Mock< IRepository<Race>> mockIRaceRepo;
        Mock< IRepository<Season>> mockISeasonRepo;

        [SetUp]
        public void Init()
        {

        }

    }
}
