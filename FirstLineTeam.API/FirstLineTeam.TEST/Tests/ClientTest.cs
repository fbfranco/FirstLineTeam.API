using FirstLineTeam.CORE.Models;
using FirstLineTeam.DATA.Config;
using FirstLineTeam.DATA.Persistens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace FirstLineTeam.TEST.Tests
{
    [TestClass]
    public class ClientTest
    {
        ClientRepository repo;
        Client client = new Client();

        [TestInitialize]

        public void TestSetup()
        {
            InitializableDB db = new InitializableDB();
            Database.SetInitializer(db);
            repo = new ClientRepository();
        }

        [TestMethod]
        public void IsClientInitializableDB()
        {
            var result = repo.GetClients();
            Assert.IsNotNull(result);
        }
    }
}
