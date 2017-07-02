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
using System.Diagnostics;
using Airstream.User_Interfaces;

namespace Airstream.User_Interfaces
{
    public partial class UI_Default : Form
    {
        static Button _didYouKnowBtn;
        public static Button _whatsInsideBtn;
        static Button _leaveSomeFeedbackBtn;
        static string projectFolder;
        static Label _didYouKnowLabel;
        static Label _whatsInsideLabel;
        static Label _leaveSomeFeedbackLabel;
        static Panel _didYouKnowPanel;
        static Panel _whatsInsidePanel;
        static Panel _leaveSomeFeedbackPanel;
        public static TextBox _rfidTriggerTextBox;
        public static Button _yesRFID;
        public  bool _quitForm;
        public static Form defaultForm;
        public static Button _rfidScanImage;


        private const int DEFAULT_DISPLAY_QUESTION = 0;

        public UI_Default(bool quitForm)
        {
            defaultForm = this;
            _quitForm = quitForm;

            InitializeComponent();
            this.DoubleBuffered = true;
            this.FormClosing += UI_Default_FormClosing;
            UI_General.SetGeneralElements(this);
            UI_General._labelWhite._BackColor = Color.Transparent;
            SetUniqueElements();
            SetRfidTriggerBox();
            AddAndBringToFrontControls();
            AddEventHandlers();
       

        }


        private void UI_Default_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(UI_General._sapBtnclicked)
            {
                _quitForm = true;
            }
            else
            {
                _quitForm = false;
            }

            this.DialogResult = DialogResult.OK;

        }



        public void AddEventHandlers()
        {
            _leaveSomeFeedbackBtn.Click += _leaveSomeFeedbackBtn_Click;
            _didYouKnowBtn.Click += _didYouKnowBtn_Click;
            _whatsInsideBtn.Click += _whatsInsideBtn_Click;

        }

        public  void AddAndBringToFrontControls()
        {
            Controls.Add(_rfidScanImage);
            _rfidScanImage.BringToFront();

        }

        public void SetRfidTriggerBox()
        {

            _rfidTriggerTextBox = new TextBox();
            _rfidTriggerTextBox.BackColor = Color.Black;
            _rfidTriggerTextBox.TextChanged += _rfidScanned;
            _rfidTriggerTextBox.ForeColor = Color.Black;
            _rfidTriggerTextBox.BorderStyle = BorderStyle.None;
            _rfidTriggerTextBox.Font = UI_General.GetLabelGrayFont();
            _rfidTriggerTextBox.Location = new Point(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.5) - Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.1), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.9));
            _rfidTriggerTextBox.Size = new Size(0, 0);
            _rfidTriggerTextBox.Text = "";
            _rfidTriggerTextBox.TabIndex = 0;

            _rfidTriggerTextBox.Select();

            Controls.Add(_rfidTriggerTextBox);

        }

        public  void SetUniqueElements()
        {
            // Instantiate elements 
            _didYouKnowBtn = new Button();
            _whatsInsideBtn = new Button();
            _leaveSomeFeedbackBtn = new Button();
            projectFolder = UI_General.GetProjectFolder();
            _didYouKnowLabel = new Label();
            _whatsInsideLabel = new Label();
            _leaveSomeFeedbackLabel = new Label();
            _leaveSomeFeedbackPanel = new Panel();
            _whatsInsidePanel = new Panel();
            _didYouKnowPanel = new Panel();
            _rfidScanImage = new Button();


            //_rfidScanLabel = new Label();



            UI_General._labelWhite.Controls.Add(_didYouKnowPanel);
            UI_General._labelWhite.Controls.Add(_whatsInsidePanel);
            UI_General._labelWhite.Controls.Add(_leaveSomeFeedbackPanel);

            double containerWidth = UI_General._labelWhite.Width;
            double containerHeight = UI_General._labelWhite.Height;

            _didYouKnowPanel.Size = new Size(200, 250);
            _didYouKnowPanel.BackColor = Color.Transparent;
            _didYouKnowPanel.Top += 50;
            double spacing = (containerWidth - _didYouKnowPanel.Width * 3)/4;
            _didYouKnowPanel.Left += Convert.ToInt16(spacing);

            _whatsInsidePanel.Size = new Size(200, 250);
            _whatsInsidePanel.BackColor = Color.Transparent;
            _whatsInsidePanel.Top += 50;
            _whatsInsidePanel.Left += Convert.ToInt16(spacing + _whatsInsidePanel.Width + spacing + _whatsInsidePanel.Width + spacing);

            _leaveSomeFeedbackPanel.Size = new Size(200, 250);
            _leaveSomeFeedbackPanel.BackColor = Color.Transparent;
            _leaveSomeFeedbackPanel.Top += 50;
            _leaveSomeFeedbackPanel.Left += Convert.ToInt16(spacing + _leaveSomeFeedbackPanel.Width + spacing);


            //Set their properties
            _rfidScanImage.Size = new Size(Convert.ToInt32(350 *0.75), Convert.ToInt32(100*0.75));
            _rfidScanImage.Location = new Point(Convert.ToInt32(UI_General.GetSizeScreen().Width - (_rfidScanImage.Size.Width )), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.89));
            _rfidScanImage.BackgroundImage = new Bitmap(projectFolder + @"Pictures\rfid\rfid_scan.png");
            _rfidScanImage.BackColor = Color.Transparent;
            _rfidScanImage.BackgroundImageLayout = ImageLayout.Stretch;
            _rfidScanImage.FlatStyle = FlatStyle.Flat;
            _rfidScanImage.FlatAppearance.BorderSize = 0;
            _rfidScanImage.FlatAppearance.MouseOverBackColor = _rfidScanImage.BackColor;
            _rfidScanImage.FlatAppearance.MouseDownBackColor = _rfidScanImage.BackColor;


            _didYouKnowBtn.Size = new Size(200, 200);
            _didYouKnowBtn.BackgroundImage = new Bitmap(projectFolder + @"Pictures\default\did_you_know.jpg");
            _didYouKnowBtn.BackgroundImageLayout = ImageLayout.Stretch;


            _didYouKnowPanel.Controls.Add(_didYouKnowBtn);
            _didYouKnowPanel.Controls.Add(_didYouKnowLabel);
            _didYouKnowBtn.Top += 25;
            _didYouKnowLabel.Left += (_didYouKnowPanel.Width - _didYouKnowLabel.Width) / 2;


            _whatsInsideBtn.Size = new Size(200, 200);
            _whatsInsideBtn.BackgroundImage = new Bitmap(projectFolder + @"Pictures\default\whats_inside.jpg");
            _whatsInsideBtn.BackgroundImageLayout = ImageLayout.Stretch;

            _whatsInsidePanel.Controls.Add(_whatsInsideBtn);
            _whatsInsidePanel.Controls.Add(_whatsInsideLabel);
            _whatsInsideBtn.Top += 25;
            //_whatsInsideLabel.Text = "What's Inside?";
            _whatsInsideLabel.Left += (_whatsInsidePanel.Width - _whatsInsideLabel.Width) / 2;


            _leaveSomeFeedbackBtn.Size = new Size(200, 200);
            _leaveSomeFeedbackBtn.BackgroundImage = new Bitmap(projectFolder + @"Pictures\default\feedback.jpg");
            _leaveSomeFeedbackBtn.BackgroundImageLayout = ImageLayout.Stretch;
            _leaveSomeFeedbackPanel.Controls.Add(_leaveSomeFeedbackBtn);
            _leaveSomeFeedbackPanel.Controls.Add(_leaveSomeFeedbackLabel);
            _leaveSomeFeedbackBtn.Top += 25;
            //_leaveSomeFeedbackLabel.Text = "Leave feedback!";
            _leaveSomeFeedbackLabel.Left += (_leaveSomeFeedbackPanel.Width - _leaveSomeFeedbackLabel.Width) / 2;



            _didYouKnowBtn.BackColor = Color.FromArgb(255, 255, 255);
            _didYouKnowBtn.ForeColor = UI_General.GetLabelGrayForeColor();

            _whatsInsideBtn.BackColor = Color.FromArgb(255, 255, 255);
            _whatsInsideBtn.ForeColor = UI_General.GetLabelGrayForeColor();


            _leaveSomeFeedbackBtn.BackColor = Color.FromArgb(255, 255, 255);
            _leaveSomeFeedbackBtn.ForeColor = UI_General.GetLabelGrayForeColor();


        }
        private  void _leaveSomeFeedbackBtn_Click(object sender, EventArgs e)
        {
            UI_Feedback newFeedbackForm = new UI_Feedback();
            newFeedbackForm.Owner = this;
            newFeedbackForm.ShowDialog();
            this.ActiveControl = _rfidTriggerTextBox;

        }

        private  void _didYouKnowBtn_Click(object sender, EventArgs e)
        {
            UI_DYK newFeedbackForm = new UI_DYK(DEFAULT_DISPLAY_QUESTION);
            newFeedbackForm.Owner = this;
            newFeedbackForm.ShowDialog();
            this.ActiveControl = _rfidTriggerTextBox;


        }
        private  void _whatsInsideBtn_Click(object sender, EventArgs e)
        {
            UI_WhatsInside newFeedbackForm = new UI_WhatsInside();
            newFeedbackForm.Owner = this;
            newFeedbackForm.ShowDialog();


        }
       public static void ClearEventHandlers()
        {

        }

        private void _rfidScanned(object sender, EventArgs e)
        {
            if (_rfidTriggerTextBox.Text.Length == 8)
            {
                Form RfidWelcomeScreen = new WelcomePopup(_rfidTriggerTextBox.Text);
                RfidWelcomeScreen.Owner = this;
                _rfidTriggerTextBox.Text = "";
                RfidWelcomeScreen.ShowDialog();
            }
  
        }
    }


}
