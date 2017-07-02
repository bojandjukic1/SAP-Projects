using System.Windows.Forms;
using System.Drawing;
using System;

namespace Airstream.User_Interfaces
{
    partial class WelcomePopup
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label _labelName;
        private PictureBox _companyLogo;
        private Label _labelOccupation;
        string projectFolder = UI_General.GetProjectFolder();
        private  Label _wouldYouLikeACoffeeRFID;
        private  Button _rfidScanImage;
        private  RoundLabel _yesBtnRFID;
        private  RoundLabel _noBtnRFID;
        private RoundLabel _coffeeOption;
        private RoundLabel _espressoOption;
        private Timer _timerToClose;
        private int _countDown = 10;


        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {

            

            this._labelName = new Label();
            this._companyLogo = new PictureBox();
            this._labelOccupation = new Label();
            this._rfidScanImage = new Button();
            this._noBtnRFID = new RoundLabel();
            this._yesBtnRFID = new RoundLabel();
            this._wouldYouLikeACoffeeRFID = new Label();
            this._espressoOption = new RoundLabel();
            this._coffeeOption = new RoundLabel();
            this._timerToClose = new Timer();

            _timerToClose.Interval = 1000;
            _timerToClose.Tick += new EventHandler(_timerToClose_Tick);
            _timerToClose.Start();

            // Main Settings for the Welcome Popup
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new Size(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.6), Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.75));
            this.Controls.Add(this._labelName);
            this.Controls.Add(this._companyLogo);
            this.Controls.Add(this._labelOccupation);
            this.ResumeLayout(false);
            this.BringToFront();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;


            //PictureBox for the company logo or the default image (in case the rfid tag is not registered or image is missing)
            this._companyLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this._companyLogo.Size = new Size(600, 300);
            this._companyLogo.Location = new Point((this.ClientSize.Width / 2) - (this._companyLogo.Width / 2), 10);
            this._companyLogo.Image = new Bitmap(projectFolder + @"Pictures\general\SAP_Logo.jpg");


            // Label for Name of the customer. If RFID Chip is not registered, there is a Welcome Text instead of the name

            this._labelName.AutoSize = true;
            this._labelName.MinimumSize = new Size(600, 0);
            this._labelName.Location = new Point((this.ClientSize.Width / 2) - (this._labelName.Width / 2), this._companyLogo.Size.Height + 30);
            this._labelName.Text = "Herzlich Willkommen";
            this._labelName.TextAlign = ContentAlignment.MiddleCenter;
            this._labelName.Font = new Font("Serif", 24);


            // Label for Occupation. If RFID Chip is not registered, there is a hint instead of Occupation

            this._labelOccupation.AutoSize = true;
            this._labelOccupation.MinimumSize = new Size(600, 0);
            this._labelOccupation.Location = new Point((this.ClientSize.Width / 2) - (this._labelOccupation.Width / 2), this._labelName.Location.Y + this._labelName.Height + 10);
            this._labelOccupation.Text = "Ihr RFID Chip ist noch nicht registriert";
            this._labelOccupation.TextAlign = ContentAlignment.MiddleCenter;
            this._labelOccupation.Font = new Font("Serif", 12);

            // RFID Buttons and label for would you like a coffee

            double containerWidth = this.Width;
            double containerHeight = this.Height;



            this._wouldYouLikeACoffeeRFID.Text = "Möchten Sie einen             oder             ?";
            this._wouldYouLikeACoffeeRFID.Font = new Font("Arial", 18);
            this._wouldYouLikeACoffeeRFID.Size = new Size(Convert.ToInt32(containerWidth), Convert.ToInt32(containerHeight * 0.2));
            this._wouldYouLikeACoffeeRFID.TextAlign = ContentAlignment.MiddleCenter;
            this._yesBtnRFID.Text = "Ja!";
            this._noBtnRFID.Text = "Nein";
            this._noBtnRFID.Font = this._yesBtnRFID.Font = new Font("Arial", 10);
            this._yesBtnRFID.Size = _noBtnRFID.Size = new Size(100, 50);
            this._yesBtnRFID.TextAlign = _noBtnRFID.TextAlign = ContentAlignment.MiddleCenter;
            this._yesBtnRFID.BackColor = _noBtnRFID.BackColor = Color.White;
            this._yesBtnRFID.Top += Convert.ToInt32(containerHeight * 0.87);
            this._yesBtnRFID.Left += Convert.ToInt32(containerWidth * 0.3);
            this._yesBtnRFID.ForeColor = this._noBtnRFID.ForeColor = Color.White;
            this._yesBtnRFID._BackColor = Color.LightSlateGray;
            this._noBtnRFID._BackColor = Color.IndianRed;

            this._noBtnRFID.Top += Convert.ToInt32(containerHeight * 0.87);
            this._noBtnRFID.Left += Convert.ToInt32(containerWidth * 0.5);



            this._wouldYouLikeACoffeeRFID.Top += Convert.ToInt32(containerHeight * 0.69);


            this._wouldYouLikeACoffeeRFID.BackColor = Color.Transparent;
            //_wouldYouLikeACoffeeRFID.Left += Convert.ToInt32(screenWidth * 0.3);

            //Coffee and espresso options 

            this._coffeeOption.Text = "Coffee";
            this._espressoOption.Text = "Espresso";
            this._coffeeOption.Font = this._espressoOption.Font = new Font("Arial", 10);
            this._coffeeOption.Size = _espressoOption.Size = new Size(75, 50);
            this._coffeeOption.TextAlign = _espressoOption.TextAlign = ContentAlignment.MiddleCenter;
            this._coffeeOption._BackColor = _espressoOption._BackColor = Color.LightGray;

            this._coffeeOption.Top += Convert.ToInt32(containerHeight * 0.74);
            this._coffeeOption.Left += Convert.ToInt32(containerWidth * 0.49);
            this._coffeeOption.ForeColor = this._espressoOption.ForeColor = Color.Black;


            this._espressoOption.Top += Convert.ToInt32(containerHeight * 0.74);
            this._espressoOption.Left += Convert.ToInt32(containerWidth * 0.67);




            this.Controls.Add(_noBtnRFID);
            this.Controls.Add(_yesBtnRFID);
            this.Controls.Add(_wouldYouLikeACoffeeRFID);
            this.Controls.Add(_coffeeOption);
            this.Controls.Add(_espressoOption);


            this._wouldYouLikeACoffeeRFID.BringToFront();
            this._yesBtnRFID.BringToFront();
            this._noBtnRFID.BringToFront();
            this._coffeeOption.BringToFront();
            this._espressoOption.BringToFront();

            this._noBtnRFID.Click += _noBtnRFID_Click;
            this._yesBtnRFID.Click += _yesBtnRFID_Click;
            this._coffeeOption.Click += _coffeeOption_Click;
            this._espressoOption.Click += _espressoOption_Click;

            this._wouldYouLikeACoffeeRFID.Visible = false;
            this._yesBtnRFID.Visible = false;
            this._noBtnRFID.Visible = false;
            this._coffeeOption.Visible = false;
            this._espressoOption.Visible = false;
            this._yesBtnRFID.Enabled = false;



        }

        private void _timerToClose_Tick(object sender, EventArgs e)
        {
            this._countDown -= 1;
        }

        private void _espressoOption_Click(object sender, EventArgs e)
        {
            RoundLabel thisBtn = (RoundLabel)sender;
            thisBtn._BackColor = Color.LightBlue;
            thisBtn.ForeColor = Color.White;
            this._coffeeOption.Enabled = false;
            this._yesBtnRFID.Enabled = true;
            this._yesBtnRFID._BackColor = Color.LightGreen;

        }

        private void _coffeeOption_Click(object sender, EventArgs e)
        {
            RoundLabel thisBtn = (RoundLabel)sender;
            thisBtn._BackColor = Color.LightBlue;
            thisBtn.ForeColor = Color.White;
            _espressoOption.Enabled = false;
            _yesBtnRFID.Enabled = true;
            _yesBtnRFID._BackColor = Color.LightGreen;
        }

        private void _yesBtnRFID_Click(object sender, EventArgs e)
        {
            string order = "";
            if (this._coffeeOption.Enabled)
            {
                order = "coffee";
                System.Diagnostics.Process.Start("http://coffeeinairstream.hopto.org/cgi-bin/coffeeCGI.py?"+order + "=1");

            }
            else if (this._espressoOption.Enabled)
            {
                order = "espresso";
                System.Diagnostics.Process.Start("http://coffeeinairsteam.hopto.org/cgi-bin/coffeeCGI.py?"+order+"=1");

            }
        }

        private void _noBtnRFID_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}