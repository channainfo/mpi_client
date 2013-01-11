using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MPIClient.DataAccess.Model;
using System.Net;
using System.Threading;
using MPIClient.DataAccess;


namespace MPIClient
{
    /// <summary>
    /// Summary description for SynchronizationTest
    /// </summary>
    [TestClass]
    public class SynchronizationTest
    {
        public SynchronizationTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        AutoResetEvent _TestTrigger;
        private TestContext testContextInstance;
        
        private Byte[] result;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        private static void initializeTestDatabase()
        {
            string connectionString = ConfigManager.GetConnectionString("CoreDSN");
            NDbUnit.Core.INDbUnitTest mySqlDatabase = new NDbUnit.Core.SqlClient.SqlDbUnitTest(connectionString);

            mySqlDatabase.ReadXmlSchema(@"..\..\..\MPIClientTest\MPIClient.xsd");
            mySqlDatabase.ReadXml(@"..\..\..\MPIClientTest\Patient.xml");
            mySqlDatabase.ReadXml(@"..\..\..\MPIClientTest\Visit.xml");
            
            mySqlDatabase.PerformDbOperation(NDbUnit.Core.DbOperationFlag.CleanInsertIdentity);
        }
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        private static PatientSyn stubPatientSyn()
        {
            PatientSyn patientSyn = new PatientSyn();
            string fingerprint = "p/8BHmcANQECRwGTABoBATsBvgCTAAGCAEUAzgABVQCCAC8BAkEBYAAVAQI7AbcA7gABMAGzACEBAUwBkwB7AAGNAIYAiAABTAFmAIYAAcAARwA1AQJSAXEA+gACMAEtAKEAAj4AnwDyAAIwAcgAFQECRwGjAFcAAUcBVwB0AAEdAGEAzQACZgCxAD8AAZMAHQDlAAHyAIAAGgACXQFXALMAAk8AcACxAAJ8AF4AmQAB1gBwALgAAnEALAAZAQHFAFIAlwACLQAsAHoAATMAOgBxAAHcAKwAGRcYGxwdCQgYCgoRDgYHDxYXGRYSGRsKBAEWGBYbEBMDEgAEEhYRHRcYAxYFDBIXCQoACwcBAAUbERkYDRsYEQsaCBANHBcbCwUBDgQFDwYcERgJFwobHRkbFg0KCBQDDA4WChcJAQwbHAwSAxkKHQIIDR0NGAEFBwYZCgMNCREEBwcOAAEDFxIYGgUZCQEPDw4YHRoUGwkSGwQMCRABBgMbAgkYHAocAxgLBAAMCBEYCBMVDREMAw0KFwgWCQAaAhAMGQgTEg0EDhAVFA0WHAwGBQ4LDAUSFBIOEhYdBA8OGRoMBQMMFgcMChAUFgAHCR0aAxEQCwEFFAQGFwIHBQITCRMZAhccAA4MFAMcAgoGGQQaCxQPDAYCBhIBEhoSBhcYEA4WGAIOAxEVCBUOAgAPCwMKExETDwUUHB0QFgICEQEDCRUKFR0VGg0YEw8ZHBUPAhsVBwI=";

            Random random = new Random();

            patientSyn.age = random.Next(100);
            patientSyn.gender = random.Next(1, 3);
            patientSyn.patientid = "1";
            patientSyn.fingerprint_l1 = fingerprint;
            patientSyn.fingerprint_l2 = fingerprint;
            patientSyn.sitecode = "0202";
            patientSyn.visits = new List<VisitSyn>();
            return patientSyn;
        }
        [TestMethod]
        public void synchronize_Patient_With_No_Visit_Data_Return_A_Patient_From_The_Server()
        {
            PatientSyn patientSyn = stubPatientSyn();

            var webClient = new Mock<WebClient>();
            WebRequestClass webRequest = new WebRequestClass();

            //webClient.Setup(m => m.UploadValuesAsync(, null)).Callback(() => "22");
            this._TestTrigger = new AutoResetEvent(false);
            webRequest.synPatient(patientSyn, null, uploadLoadValuesCompleted, 0);
            this._TestTrigger.WaitOne();
            Assert.IsNotNull(result);
            Object jsonObject = GeneralUtil.serializeToJSONObject(result);
            Assert.IsNotNull(jsonObject);

        }

        [TestMethod]
        public void synchronize_Patient_With_No_Visit_Data_Return_A_Patient_With_Correct_Data()
        {
            PatientSyn patientSyn = stubPatientSyn();

            var webClient = new Mock<WebClient>();
            WebRequestClass webRequest = new WebRequestClass();

            //webClient.Setup(m => m.UploadValuesAsync(, null)).Callback(() => "22");
            this._TestTrigger = new AutoResetEvent(false);
            webRequest.synPatient(patientSyn, null, uploadLoadValuesCompleted, 0);
            this._TestTrigger.WaitOne();
            Assert.IsNotNull(result);
            Object jsonObject = GeneralUtil.serializeToJSONObject(result);
            Assert.IsNotNull(jsonObject);
            Patient patient = GeneralUtil.getPatientListFromJSONObject(jsonObject)[0];

            Assert.AreEqual(patientSyn.age, patient.Age);
            Assert.AreEqual(patientSyn.gender, patient.Gender);
            Assert.AreEqual(patientSyn.sitecode, patient.SiteCode);

        }
        [TestMethod]
        public void test()
        {
            initializeTestDatabase();
        }
        public void uploadLoadValuesCompleted(Object sender, System.Net.UploadValuesCompletedEventArgs e)
        {
            result = e.Result;
            this._TestTrigger.Set();

        }
    }
}
