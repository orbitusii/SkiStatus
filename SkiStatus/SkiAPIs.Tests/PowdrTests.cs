

namespace SkiAPIs.Tests
{
    [TestClass]
    public class PowdrTests
    {
        string sampleData = @"[{""id"": 5,""resort_id"": """",""lift_id"": """",""sector"": ""Copper Mountain"",""rank_sector"": 0,""area"": 0,""type"": ""area"",""subtype"": ""general_information"",""status"": [{""status_name"": ""opening"",""status_value"": ""false"",""status_change_date"": """",""html"": ""Lorem Ipsum Dolor""}],""properties"": {""link"": ""google.com"",""season"": ""winter"",""subtype"": [{""closing"": ""17:00"",""opening"": ""08:00""}],""link_text"": ""FULL NORDIC REPORT"",""global_status"": ""close"",""name"": ""Nordic Center""}}]";
        Interpreter interpreter = SkiAPI.GetInterpreter(APIFormat.Powdr);

        [TestMethod]
        public void GetInterpreter()
        {
            Assert.IsFalse(interpreter is null);
            Assert.IsTrue(interpreter is Powdr);
        }

        [TestMethod]
        public void GetTypeIdentifiers_Trails ()
        {
            Assert.IsTrue(interpreter.GetTypeIdentifiers(SkiObjectType.Trail)["type"] == "trail");
            Assert.IsTrue(interpreter.GetTypeIdentifiers(SkiObjectType.Lift)["type"] == "lift");
            Assert.ThrowsException<NotSupportedException>(() => interpreter.GetTypeIdentifiers(SkiObjectType.Mountain));
        }

        [TestMethod]
        public void ParseSectors ()
        {
            interpreter.Parse(sampleData);

            Assert.IsTrue(interpreter.GetMountains()[0].name == "Copper Mountain");
        }
    }
}