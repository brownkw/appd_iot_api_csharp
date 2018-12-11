using NUnit.Framework;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using AppDynamics.IoT;

namespace AppD_IoT_CSharp_Test
{
    [TestFixture()]
    public class Test
    {
        IoTBeacon beacon;
        List<IoTBeacon> beacons; 

        [TestFixtureSetUp]
        public void Init() 
        {
            //IoTBeacon.SetAppKey("AD-AAB-AAM-MNW");
            IoTBeacon.SetAppKey("AD-AAB-AAM-NCE");
            IoTBeacon.SetEndpointUrl("https://iot-col.eum-appdynamics.com");
            //IoTBeacon.SetProxy("http://127.0.0.1:8888");

            beacon = new IoTBeacon();
            beacon.SetDeviceInfo(new DeviceInfo
            {
                DeviceId = "12345678",
                DeviceName = "Oculus Go 64GB",
                DeviceType = "Oculus Go"
            });

            beacon.SetVersionInfo(new VersionInfo
            {
                FirmwareVersion = "1.0",
                SoftwareVersion = "1.0",
                OperatingSystemVersion = "1.0",
                HardwareVersion = "1.0"
            });

            CustomEvent cevt = new CustomEvent();

            cevt.Timestamp = DateTime.Now.AddMinutes(-1).ConvertToTimestamp();
            cevt.Duration = (long)DateTime.Now.Subtract(DateTime.Now.AddMinutes(-1)).TotalMilliseconds;
            cevt.EventType = "Test Event Type";
            cevt.EventSummary = "Test Event Summary";
            cevt.StringProperties = new Dictionary<string, string>
            {
                { "String1", "String1" },
                { "String2", "String2" },
                { "String3", "String3" }
            };

            cevt.LongProperties = new Dictionary<string, long>
            {
                { "Long1", 1 },
                { "Long2", 2 },
                { "Long3", 3 }
            };

            cevt.BooleanProperties = new Dictionary<string, bool>
            {
                { "Bool1", true },
                { "Bool2", false }
            };

            cevt.DateTimeProperties = new Dictionary<string, long>
            {
                { "Datetime1", DateTime.Now.AddDays(-1).ConvertToTimestamp() },
                { "Datetime2", DateTime.Now.AddDays(-2).ConvertToTimestamp() },
                { "Datetime3", DateTime.Now.AddDays(-3).ConvertToTimestamp() }
            };

            cevt.DoubleProperties = new Dictionary<string, double>
            {
                { "Double1", 1.0 },
                { "Double2", 2.0 }
            };

            beacon.AddCustomEvent(cevt);

            beacons = new List<IoTBeacon>() { beacon };
        }

        [Test()]
        public void ValidateAppKey()
        {
            var response = IoTBeacon.IsAppKeyEnabled();
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test()]
        public void ValidateBeacons()
        {
            var response = IoTBeacon.Validate(beacons);
            Console.WriteLine(response.ToString());
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test()]
        public void ValidateCloning()
        {
            // First object
            var tmp_str = JsonConvert.SerializeObject(beacon);

            // Creating new object
            var beacon2 = beacon.Clone();

            // Deep comparision of objects
            JObject o1 = JObject.Parse(tmp_str);
            JObject o2 = JObject.Parse(JsonConvert.SerializeObject(beacon2));

            Assert.IsTrue(JToken.DeepEquals(o1, o2));
            Assert.AreNotSame(beacon, beacon2);
        }

        [Test()]
        public void SendBeacon()
        {
            var response = IoTBeacon.Send(beacons);
            Console.WriteLine(response.ToString());
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

    }
}
