using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airstream.Tests
{

    [TestClass]
    public class FeedbackTests
    {
        Feedback.Database.DatabaseConnection db;
        [TestInitialize]
        public void StartTests()
        {
            db = new Feedback.Database.DatabaseConnection();

        }

        [TestMethod]
        public void SelectFromFeedbackTests()
        {
            string q = @"SELECT * FROM feedback";
            List<string>[] result = db.SelectFromFeedback(q);
            //Test column 1 data  - expect int
            for(int i = 0; i < result[0].ToArray().Length; i++)
            {
                int num;
                bool isNum  = Int32.TryParse(result[0][i], out num);
                Assert.AreEqual(isNum, true);
            }
            //Test column 2 data - expect int
            for (int i = 0; i < result[1].ToArray().Length; i++)
            {
                int num;
                bool isNum = Int32.TryParse(result[1][i], out num);
                Assert.AreEqual(isNum, true);
            }
            //Test column 3 data  - expect string > 0 
            for (int i = 0; i < result[2].ToArray().Length; i++)
            {
                Assert.AreEqual(result[2][i].GetType(), typeof(string));
                Assert.IsTrue(result[2][i].Length > 0);
            }

        }
        [TestMethod]
        public void SelectFromDYKTests()
        {
            string q = @"SELECT * FROM didyouknowdata";
            List<string>[] result = db.SelectFromDYK(q);
            //Test column 1 data  - expect int
            for (int i = 0; i < result[0].ToArray().Length; i++)
            {
                int num;
                bool isNum = Int32.TryParse(result[0][i], out num);
                //First column is a number
                Assert.AreEqual(isNum, true);
            }
            //Test column 2 data - expect string > 0 
            for (int i = 0; i < result[1].ToArray().Length; i++)
            {
                Assert.AreEqual(result[1][i].GetType(), typeof(string));
                Assert.IsTrue(result[1][i].Length > 0);
            }
            //Test column 3 data  - expect int > 0 
            for (int i = 0; i < result[2].ToArray().Length; i++)
            {
                int num;
                bool isNum = Int32.TryParse(result[2][i], out num);
                //Third column is a number
                Assert.AreEqual(isNum, true);
            }
            //Test column 4 data  - expect int > 0 

            for (int i = 0; i < result[3].ToArray().Length; i++)
            {
                int num;
                bool isNum = Int32.TryParse(result[3][i], out num);
                //Fourth column is a number
                Assert.AreEqual(isNum, true);
            }
            //Test column 5 data  - expect int > 0 

            for (int i = 0; i < result[4].ToArray().Length; i++)
            {
                int num;
                bool isNum = Int32.TryParse(result[4][i], out num);
                //Fifth column is a number
                Assert.AreEqual(isNum, true);
            }
            //Test column 6 data  - expect int > 0 

            for (int i = 0; i < result[5].ToArray().Length; i++)
            {
                int num;
                bool isNum = Int32.TryParse(result[5][i], out num);
                //Sixth column is a number
                Assert.AreEqual(isNum, true);
            }
            //Test column 7 data  - expect int > 0 

            for (int i = 0; i < result[6].ToArray().Length; i++)
            {
                int num;
                bool isNum = Int32.TryParse(result[6][i], out num);
                //Seventh column is a number
                Assert.AreEqual(isNum, true);
            }

        }

        [TestMethod]
        public void SelectFromFeedbackQsTests()
        {
            string q = @"SELECT * FROM feedbackqs";
            List<string>[] result = db.SelectFromFeedbackQs(q);
            //Test column 1 data  - expect int
            for (int i = 0; i < result[0].ToArray().Length; i++)
            {
                int num;
                bool isNum = Int32.TryParse(result[0][i], out num);
                //First column is a number
                Assert.AreEqual(isNum, true);
            }
            //Test column 2 data - expect 0 or  1
            for (int i = 0; i < result[1].ToArray().Length; i++)
            {
                int num;
                bool isNum = Int32.TryParse(result[1][i], out num);
                bool isZeroOrOne = false;
                if (num == 0 || num == 1) { isZeroOrOne = true; } ;
                //Second column is a 0 or 1 
                Assert.AreEqual(true, isZeroOrOne);
            }
            //Test column 3 data  - expect string > 0 
            for (int i = 0; i < result[2].ToArray().Length; i++)
            {
                Assert.AreEqual(result[2][i].GetType(), typeof(string));
                Assert.IsTrue(result[2][i].Length > 0);
            }

            //Test column 4 data  - expect string > 0 
            for (int i = 0; i < result[3].ToArray().Length; i++)
            {
                Assert.AreEqual(result[3][i].GetType(), typeof(string));
                Assert.IsTrue(result[3][i].Length > 0);
            }
            //Test column 5 data  - expect string > 0 
            for (int i = 0; i < result[4].ToArray().Length; i++)
            {
                Assert.AreEqual(result[4][i].GetType(), typeof(string));
                Assert.IsTrue(result[4][i].Length > 0);
            }
            //Test column 6 data  - expect string > 0 
            for (int i = 0; i < result[5].ToArray().Length; i++)
            {
                Assert.AreEqual(result[5][i].GetType(), typeof(string));
                Assert.IsTrue(result[5][i].Length > 0);
            }
            //Test column 7 data  - expect string > 0 
            for (int i = 0; i < result[6].ToArray().Length; i++)
            {
                Assert.AreEqual(result[6][i].GetType(), typeof(string));
                Assert.IsTrue(result[6][i].Length > 0);
            }
            //Test column 8 data  - expect string > 0 
            for (int i = 0; i < result[7].ToArray().Length; i++)
            {
                Assert.AreEqual(result[7][i].GetType(), typeof(string));
                Assert.IsTrue(result[7][i].Length > 0);
            }

        }

        [TestMethod]
        public void SelectFromRFIDStorageTests()
        {
            string q = @"SELECT * FROM rfid_storage";
            List<string>[] result = db.SelectFromRFID(q);
            //Test column 1 data  - expect int of 8 or more digits 
            for (int i = 0; i < result[0].ToArray().Length; i++)
            {
                int num;
                bool isNum = Int32.TryParse(result[0][i], out num);
                bool greaterThanOrEqualToEight = false;
                if(num.ToString().Length >= 8)
                {
                    greaterThanOrEqualToEight = true;
                }
                //First column is a valid RFID tag
                Assert.AreEqual(true, greaterThanOrEqualToEight);
            }
            //Test column 2 data - expect string > 0 
            for (int i = 0; i < result[1].ToArray().Length; i++)
            {
                Assert.AreEqual(result[1][i].GetType(), typeof(string));
                Assert.IsTrue(result[1][i].Length > 0);
            }
            //Test column 3 data  - expect string > 0 
            for (int i = 0; i < result[2].ToArray().Length; i++)
            {
                Assert.AreEqual(result[2][i].GetType(), typeof(string));
                Assert.IsTrue(result[2][i].Length > 0);
            }

            //Test column 4 data  - expect string > 0 
            for (int i = 0; i < result[3].ToArray().Length; i++)
            {
                string[] companies = { "SAP", "Mercedez Benz" , "Tesla Motors" };

                Assert.AreEqual(result[3][i].GetType(), typeof(string));
                Assert.IsTrue(result[3][i].Length > 0);
                Assert.IsTrue(companies.Contains(result[3][i]));
            }
            //Test column 5 data  - expect string > 0 
            for (int i = 0; i < result[4].ToArray().Length; i++)
            {
                Assert.AreEqual(result[4][i].GetType(), typeof(string));
                Assert.IsTrue(result[4][i].Length > 0);
            }
        }

        [TestMethod]
        public void SelectFromWhatsInsideDataTests()
        {
            string q = @"SELECT * FROM whatsinsidedata";
            List<string>[] result = db.SelectFromWhatsInside(q);
            //Test column 1 data  - expect int
            for (int i = 0; i < result[0].ToArray().Length; i++)
            {
                int num;
                bool isNum = Int32.TryParse(result[0][i], out num);
                //First column is a number
                Assert.AreEqual(isNum, true);
            }
            //Test column 2 data - expect string > 0 
            for (int i = 0; i < result[1].ToArray().Length; i++)
            {
                Assert.AreEqual(result[1][i].GetType(), typeof(string));
                Assert.IsTrue(result[1][i].Length > 0);
            }
            //Test column 3 data  - expect string > 0 
            for (int i = 0; i < result[2].ToArray().Length; i++)
            {
                Assert.AreEqual(result[2][i].GetType(), typeof(string));
                Assert.IsTrue(result[2][i].Length > 0);
            }
            //Test column 4 data  - expect string > 0 
            for (int i = 0; i < result[3].ToArray().Length; i++)
            {
                Assert.AreEqual(result[3][i].GetType(), typeof(string));
                Assert.IsTrue(result[3][i].Length > 0);
            }
            //Test column 5 data  - expect string > 0 
            for (int i = 0; i < result[4].ToArray().Length; i++)
            {
                Assert.AreEqual(result[4][i].GetType(), typeof(string));
                Assert.IsTrue(result[4][i].Length > 0);
            }

        }

        [TestCleanup]
        public void TestTearDown()
        {
            db.CloseConnection();
            db = null;
        }
      
    }
}
