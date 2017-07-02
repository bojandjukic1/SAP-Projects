using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Airstream.User_Interfaces;
using Airstream.Feedback.Database;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Airstream
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        /// 

        private static int _uniqQID;
        private static int _uniqWhatsInsideID;
        private static int _uniqFeedbackQID;
        private static int _uniqRFID_ID;
        private static string _projectFolder = "..\\..\\..\\";

        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Fill the form with data before startng 
            PopulateAndPrepareData();
            bool quit = false;

            while(quit == false)
            {
                UI_Default welcomeScreen = new UI_Default(false);
                var result = welcomeScreen.ShowDialog();
                if (result == DialogResult.OK)
                {
                   quit = welcomeScreen._quitForm;

                }
            }
            
            


        }

        public static void PopulateAndPrepareData()
        {
            UpdateUniqueQID();
            UpdateUniqueWhatsInsideID();
            UpdateUniqueFeedbackQsID();
            UpdateUniqueRFID_ID();
            RefreshData();
        }

        public static void UpdateUniqueQID()
        {
            DatabaseConnection db = new DatabaseConnection();
            List<string>[] result = db.SelectFromDYK("SELECT * FROM didyouknowdata");
            _uniqQID = result[0].ToArray().Length;
        }

        public static void UpdateUniqueRFID_ID()
        {
            DatabaseConnection db = new DatabaseConnection();
            List<string>[] result = db.SelectFromRFID("SELECT * FROM rfid_storage");
            _uniqRFID_ID = result[0].ToArray().Length;
        }

        public static void UpdateUniqueWhatsInsideID()
        {
            DatabaseConnection db = new DatabaseConnection();
            List<string>[] result = db.SelectFromWhatsInside("SELECT * FROM whatsinsidedata");
            _uniqWhatsInsideID = result[0].ToArray().Length;
        }

        public static void UpdateUniqueFeedbackQsID()
        {
            DatabaseConnection db = new DatabaseConnection();
            List<string>[] result = db.SelectFromFeedbackQs("SELECT * FROM feedbackqs");
            _uniqFeedbackQID = result[0].ToArray().Length;
        }


        public static void RefreshData()
        {
            //Note that we do not want to lose feedback as this is dynamic data and we would lose it 
            DatabaseConnection db = new DatabaseConnection();
            string q1 = "DELETE FROM didyouknowdata";
            db.InsertUpdateDelete(q1);
            string q2 = "DELETE FROM whatsinsidedata";
            db.InsertUpdateDelete(q2);
            string q3 = "DELETE FROM feedbackqs";
            db.InsertUpdateDelete(q3);
            string q4 = "DELETE FROM rfid_storage";
            db.InsertUpdateDelete(q4);

            AddDataWhatsInside();
            AddQuestionDataDYK();
            AddFeedbackQData();
            AddRFIDData();
   
        }


        public static void AddQuestionDataDYK()
        {
            //Add default data to the database
            DatabaseConnection db = new DatabaseConnection();
            List<string> questions = new List<string>();
            List<string> optionAs = new List<string>();
            List<string> optionBs = new List<string>();
            List<string> optionCs = new List<string>();
            List<string> optionDs = new List<string>();
            List<string> answers = new List<string>();

            int iterator = 0;
            try
            {
                using (var fs = File.OpenRead(_projectFolder + @"Data\did_you_know_data.csv"))
                using (var reader = new StreamReader(fs,Encoding.UTF7))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        if (iterator >= 1)
                        {
                            questions.Add(values[0]);
                            optionAs.Add(values[1]);
                            optionBs.Add(values[2]);
                            optionCs.Add(values[3]);
                            optionDs.Add(values[4]);
                            answers.Add(values[5]);
                        }

                        iterator += 1;
                    }
                }
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show("Excel is open or the file for the did you know data is open somewhere else, please close and try again");
                
            }
  
            List<string>[] result = db.SelectFromDYK("SELECT * FROM didyouknowdata");
            // Note result[0][3] grabs the 3rd row and the first column (zero based indexing)
            int i = 0;
            //populate data if empty
            if (result[0].Any() == false)
            {
                _uniqQID = 0;
                foreach (var val in questions)
                {
                    string s1, s2, s3, s4, s5, s6, s7;
                    s1 = _uniqQID.ToString();
                    s2 = questions[i];
                    s3 = optionAs[i];
                    s4 = optionBs[i];
                    s5 = optionCs[i];
                    s6 = optionDs[i];
                    s7 = answers[i];
                    i += 1;
                    _uniqQID += 1;
                    string q = String.Format("INSERT INTO didyouknowdata VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", s1,
                        s2, s3, s4, s5, s6, s7);
                    db.InsertUpdateDelete(q);
                }
            }
            db.CloseConnection();

        }


        public static void AddRFIDData()
        {
            //Add default data to the database
            DatabaseConnection db = new DatabaseConnection();
            List<string> rfid_number = new List<string>();
            List<string> customer_name = new List<string>();
            List<string> occupation = new List<string>();
            List<string> company = new List<string>();
            List<string> images = new List<string>();

            int iterator = 0;

            try
            {
                using (var fs = File.OpenRead(_projectFolder + @"Data\rfid_data.csv"))
                using (var reader = new StreamReader(fs, Encoding.UTF7))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        if (iterator >= 1)
                        {
                            rfid_number.Add(values[0]);
                            customer_name.Add(values[1]);
                            occupation.Add(values[2]);
                            company.Add(values[3]);
                            images.Add(values[4]);

                        }

                        iterator += 1;

                    }
                }
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show("Excel is open or the file for the did you know data is open somewhere else, please close and try again");

            }


            List<string>[] result = db.SelectFromRFID("SELECT * FROM rfid_storage");
            // Note result[0][3] grabs the 3rd row and the first column (zero based indexing)

            int i = 0;
            //populate data if empty
            if (result[0].Any() == false)
            {
                _uniqRFID_ID = 0;

                foreach (var val in rfid_number)
                {
                    string s1, s2, s3, s4, s5;
                    s1 = rfid_number[i];
                    s2 = customer_name[i];
                    s3 = occupation[i];
                    s4 = company[i];
                    s5 = images[i];
                    i += 1;
                    _uniqRFID_ID += 1;
                    string q = String.Format("INSERT INTO rfid_storage VALUES('{0}','{1}','{2}','{3}','{4}');", s1, s2, s3, s4,s5);
                    Debug.Print(q);
                    db.InsertUpdateDelete(q);
                }
            }
            db.CloseConnection();

        }


        public static void AddFeedbackQData()
        {
            //Add default data to the database
            DatabaseConnection db = new DatabaseConnection();
            List<string> yOrNos = new List<string>();
            List<string> questions = new List<string>();
            List<string> optionAs = new List<string>();
            List<string> optionBs = new List<string>();
            List<string> optionCs = new List<string>();
            List<string> optionDs = new List<string>();
            List<string> optionEs = new List<string>();

            int iterator = 0;

            try
            {
                using (var fs = File.OpenRead(_projectFolder + @"Data\FeedbackQs.csv"))
                using (var reader = new StreamReader(fs, Encoding.UTF7))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        if (iterator >= 1)
                        {
                            yOrNos.Add(values[0]);
                            questions.Add(values[1]);
                            optionAs.Add(values[2]);
                            optionBs.Add(values[3]);
                            optionCs.Add(values[4]);
                            optionDs.Add(values[5]);
                            optionEs.Add(values[6]);

                        }

                        iterator += 1;

                    }
                }
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show("Excel is open or the file for the did you know data is open somewhere else, please close and try again");

            }


            List<string>[] result = db.SelectFromFeedbackQs("SELECT * FROM feedbackqs");
            // Note result[0][3] grabs the 3rd row and the first column (zero based indexing)

            int i = 0;
            //populate data if empty
            if (result[0].Any() == false)
            {
                _uniqFeedbackQID = 0;

                foreach (var val in questions)
                {
                    string s1, s2, s3, s4, s5, s6, s7, s8;
                    s1 = _uniqFeedbackQID.ToString();
                    s2 = yOrNos[i];
                    s3 = questions[i];
                    s4 = optionAs[i];
                    s5 = optionBs[i];
                    s6 = optionCs[i];
                    s7 = optionDs[i];
                    s8 = optionEs[i];
                    i += 1;
                    _uniqFeedbackQID += 1;
                    string q = String.Format("INSERT INTO feedbackqs VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');", s1, s2, s3, s4, s5, s6, s7,s8);
                    db.InsertUpdateDelete(q);
                }
            }
            db.CloseConnection();

        }


        public static void AddDataWhatsInside()
        {
            //Add default data to the database
            DatabaseConnection db = new DatabaseConnection();
            List<string> item = new List<string>();
            List<string> data = new List<string>();
            List<string> technicalspecs = new List<string>();
            List<string> filepaths = new List<string>();



            int iterator = 0;
            try
            {
                using (var fs = File.OpenRead(_projectFolder + @"Data\whats_inside_data.csv"))
                using (var reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        if (iterator >= 1)
                        {
                            StreamReader sr = new StreamReader(_projectFolder + @"Data\WhatsInsideDescriptions\" + values[1].ToString(), Encoding.UTF7);
                            string descText = sr.ReadToEnd();
                            Debug.Print(descText);
                            sr = new StreamReader(_projectFolder + @"Data\WhatsInsideDescriptions\" + values[2].ToString(), Encoding.UTF7);
                            string techDescText = sr.ReadToEnd();

                            item.Add(values[0]);
                            data.Add(descText);
                            technicalspecs.Add(techDescText);
                            filepaths.Add(values[3]);
                            Debug.Print(values[1].ToString());
                        }

                        iterator += 1;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Print("The data file is open in another application");
                MessageBox.Show("Close the app and then close excel before continuing");
            }


            List<string>[] result = db.SelectFromWhatsInside("SELECT * FROM whatsinsidedata");
            // Note result[0][3] grabs the 3rd row and the first column (zero based indexing)

            int i = 0;
            //populate data if empty
            if (result[0].Any() == false)
            {
                _uniqWhatsInsideID = 0;

                foreach (var val in data)
                {
                    string s1, s2, s3, s4, s5;
                    s1 = _uniqWhatsInsideID.ToString();
                    s2 = item[i];
                    s3 = data[i];
                    s4 = technicalspecs[i];
                    s5 = filepaths[i];
                    i += 1;
                    _uniqWhatsInsideID += 1;
                    string q = String.Format("INSERT INTO whatsinsidedata VALUES('{0}','{1}','{2}','{3}','{4}');", s1, s2, s3, s4, s5);
                    db.InsertUpdateDelete(q);
                }
            }
            db.CloseConnection();

        }

      


    }
}
