using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Airstream.Feedback.Database;
using System.IO;
using System.Diagnostics;

namespace Airstream.User_Interfaces
{
    public partial class WelcomePopup : Form
    {


        private string _rfidNumber;
        
        public WelcomePopup(string rfidNumber)
        {


            InitializeComponent();
            this.DoubleBuffered = true;
            this._rfidNumber = rfidNumber;

            //



            if (IsRfidRegistered())
            {
                PersonalizeWelcomePopup();
            }
            //UI_Default._rfidScanImage.BackgroundImage = new Bitmap(projectFolder + @"Pictures\rfid\rfid_recognized.png");
            UI_General._labelWhite.Visible = false;
            UI_Default._rfidScanImage.Visible = false;

            Timer timerToClose = new Timer();
            timerToClose.Interval = 6000;
            timerToClose.Tick += new EventHandler(timer_Tick);
            timerToClose.Start();
            this.FormClosing += WelcomePopup_FormClosing;



        }

        private void WelcomePopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            UI_General._labelWhite.Visible = true;
            UI_Default._rfidScanImage.Visible = true;

        }

        private void PersonalizeWelcomePopup()
        {
            this._wouldYouLikeACoffeeRFID.Visible = true;
            this._yesBtnRFID.Visible = true;
            this._noBtnRFID.Visible = true;
            this._coffeeOption.Visible = true;
            this._espressoOption.Visible = true;

            DatabaseConnection db = new DatabaseConnection();

            string q = String.Format("SELECT * FROM rfid_storage WHERE rfid_storage.rfid_number = '{0}'", _rfidNumber);
            List<string>[] result = db.SelectFromRFID(q);

            //Personalize name, occupation and company

            string customer_name = result[1][0];
            string occupation = result[2][0];
            string company = result[3][0];



            this._labelName.Text = customer_name;
            this._labelOccupation.Text =
                occupation +
                ((!String.IsNullOrEmpty(company) && !String.IsNullOrEmpty(occupation)) ? ", " : "") +
                company;


            if (File.Exists(projectFolder + @"Pictures\rfid\companylogos\" + result[4][0].ToString()))
            {
                this._companyLogo.Image = new Bitmap(projectFolder + @"Pictures\rfid\companylogos\" + result[4][0].ToString());

            }
            else if(File.Exists(projectFolder + @"Pictures\general\SAP-Logo.jpg"))
            {
                this._companyLogo.Image = new Bitmap(projectFolder + @"Pictures\SAP-Logo.jpg");
            }

            //if response to would you like a coffee/espresso is yes 



        }


        private bool IsRfidRegistered()
        {
            DatabaseConnection db = new DatabaseConnection();
            List<string>[] result = db.SelectFromRFID("SELECT * FROM rfid_storage");

            for(int i = 0; i <result[0].ToArray().Length; i++)
            {
                if(result[0][i].ToLower().ToString() == _rfidNumber.ToLower().ToString())
                {
                    return true;
                }
            }
            return false;

            
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this._wouldYouLikeACoffeeRFID.Visible = false;
            this._yesBtnRFID.Visible = false;
            this._noBtnRFID.Visible = false;
            this.Close();
            

        }

    }
}
