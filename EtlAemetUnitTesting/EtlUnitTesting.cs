using EtlAemet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace EtlAemetUnitTesting
{
    //TODO: Añadir test para MqttPublisher
    [TestClass]
    public class EtlUnitTesting
    {
        [TestMethod]
        //Could fail if any of the stations is offline.
        public void GetTenerifeCoastalData()
        {
            Etl etl = new Etl();
            var tenerifeCoastalData = etl.GetTenerifeCoastalData();
            Assert.IsTrue(tenerifeCoastalData.Any(sd => sd.ubi.Equals("TENERIFE/SUR")));
            Assert.IsTrue(tenerifeCoastalData.Any(sd => sd.ubi.Equals("SANTA CRUZ DE TENERIFE ")));
            Assert.IsTrue(tenerifeCoastalData.Any(sd => sd.ubi.Equals("ANAGA-COL. REP. ARGENTINA")));
            Assert.IsTrue(tenerifeCoastalData.Any(sd => sd.ubi.Equals("PUERTO DE LA CRUZ")));
        }

    }
}
