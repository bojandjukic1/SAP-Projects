using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Airstream.Feedback.Database;

namespace Airstream.User_Interfaces
{
    public partial class UI_WhatsInside : Form
    {
        private PictureBox _backBtn;
        private PictureBox _fwdBtn;
        private PictureBox _homeBtn;
        private PictureBox _itemImage;
        private const int DEFAULT_IMAGE_ROW = 0;
        private const int DEFAULT_IMAGE_COL = 4;

        private const int DEFAULT_DESC_ROW = 0;
        private const int DEFAULT_DESC_COL = 2;

        private const int DEFAULT_TECH_DESC_ROW = 0;
        private const int DEFAULT_TECH_DESC_COL = 3;

        private int _itemID = 0;
        private int _numItems = 0;

        private RichTextBox _description;
        private RichTextBox _technicalSpecs;

        private string projectFolder = UI_General.GetProjectFolder();
        List<string>[] _results;
        public static bool _homeBtnClicked = false;


        public UI_WhatsInside()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            UI_General.SetGeneralElements(this);
            InstantiateElements();
            SetElements();
            BringElementsToFront();
            SetDefaultScreen();
            ConnectToDB();
        }

   

        private void SetElements()
        {
            UI_General._labelWhite.Height = (Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.64));
            UI_General._labelWhite.Controls.Add(_backBtn);
            UI_General._labelWhite.Controls.Add(_fwdBtn);
            UI_General._labelWhite.Controls.Add(_itemImage);
            UI_General._labelWhite.Controls.Add(_description);
            UI_General._labelWhite.Controls.Add(_technicalSpecs);
            Controls.Add(_homeBtn);


            int containerHeight = UI_General._labelWhite.Height;
            int containerWidth = UI_General._labelWhite.Width;

            _backBtn.Size = new Size(100, 100);
            _fwdBtn.Size = new Size(100, 100);
            _homeBtn.Size = new Size(50, 50);


            _backBtn.BackgroundImage = new Bitmap(projectFolder + @"Pictures\general\back.png");
            _backBtn.BackgroundImageLayout = ImageLayout.Stretch;
            _fwdBtn.BackgroundImage = new Bitmap(projectFolder + @"Pictures\general\forward.png");
            _fwdBtn.BackgroundImageLayout = ImageLayout.Stretch;
            _homeBtn.BackgroundImage = new Bitmap(projectFolder + @"Pictures\general\home_icon.png");
            _homeBtn.BackgroundImageLayout = ImageLayout.Stretch;
            _homeBtn.BackColor = Color.Transparent;
            _backBtn.BackColor = _fwdBtn.BackColor = Color.White;

            double verticalSpacing = (containerHeight - _backBtn.Height) / 2;
            _backBtn.Top += Convert.ToInt32(verticalSpacing);

            _fwdBtn.Top += Convert.ToInt32(verticalSpacing);
            _fwdBtn.Left += Convert.ToInt32(containerWidth - _fwdBtn.Width);


            int home_x = Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.95);
            int home_y = Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.95 - _homeBtn.Height);

            _homeBtn.Location = new Point(home_x, home_y);

            _backBtn.Click += _backBtn_Click;
            _fwdBtn.Click += _fwdBtn_Click;
            _homeBtn.Click += _homeBtn_Click;

            _description.Size = new Size(350, 400);
            _technicalSpecs.Size = new Size(250, 200);
            _description.Font = new Font("Century Gothic", 14);
            _technicalSpecs.Font = new Font("Arial", 10);
            _description.ReadOnly = true;
            _technicalSpecs.ReadOnly = true;
            _description.Enter += _description_Enter;
            _technicalSpecs.Enter += _description_Enter;
            _description.BorderStyle = BorderStyle.None;
            _description.BackColor = Color.White;
            _technicalSpecs.BorderStyle = BorderStyle.None;
            _technicalSpecs.BackColor = Color.White;


        }

        private void _description_Enter(object sender, EventArgs e)
        {
            ActiveControl = _itemImage;

        }

        private void _homeBtn_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            UI_Default.defaultForm.Close();
        }

        private void _fwdBtn_Click(object sender, EventArgs e)
        {
            if (_itemID >= 0 && _itemID < _numItems - 1)
            {
                _itemID += 1;
                UpdateDisplay(_itemID);
            }
            Debug.Print(_itemID.ToString());
        }

        private void _backBtn_Click(object sender, EventArgs e)
        {
            if (_itemID > 0)
            {
                _itemID -= 1;
                UpdateDisplay(_itemID);

            }
        }

        private void UpdateDisplay(int itemID)
        {
            _itemImage.BackgroundImage = 
                new Bitmap(projectFolder + @"Pictures\whatsinside\" + _results[DEFAULT_IMAGE_COL][DEFAULT_IMAGE_ROW + itemID].ToString());
            _description.Text = _results[DEFAULT_DESC_COL][DEFAULT_DESC_ROW + itemID];
            _technicalSpecs.Text = _results[DEFAULT_TECH_DESC_COL][DEFAULT_TECH_DESC_ROW + itemID];
            _numItems = _results[0].ToArray().Length;

        }

        private void BringElementsToFront()
        {
            _backBtn.BringToFront();
            _fwdBtn.BringToFront();
            _homeBtn.BringToFront();
            _itemImage.BringToFront();
        }
        private void InstantiateElements()
        {
            _backBtn = new PictureBox();
            _fwdBtn = new PictureBox();
            _itemImage = new PictureBox();
            _homeBtn = new PictureBox();
            _description = new RichTextBox();
            _technicalSpecs = new RichTextBox();

        }

        private void SetDefaultScreen()
        {
            int containerHeight = UI_General._labelWhite.Height;
            int containerWidth = UI_General._labelWhite.Width;
            _itemImage.BackgroundImageLayout = ImageLayout.Stretch;
            _itemImage.Size = new Size(200, 200);
            _itemImage.Left += Convert.ToInt32(0.75 * _itemImage.Width);
            _itemImage.Top += Convert.ToInt32(containerHeight * 0.1);

            _description.Text = "Default text";
            _technicalSpecs.Text = "Default tech specs";
            _technicalSpecs.Top += (Convert.ToInt32(_itemImage.Height + 0.3 * _itemImage.Height));
            _technicalSpecs.Left += Convert.ToInt32(containerWidth * 0.15);
            _description.Left += (Convert.ToInt32(containerWidth * 0.55));
            _description.Top += Convert.ToInt32(containerHeight * 0.1);

        }

        private void ConnectToDB()
        {
            DatabaseConnection db = new DatabaseConnection();
            _results = db.SelectFromWhatsInside("SELECT * FROM whatsinsidedata");
            _itemImage.BackgroundImage = new Bitmap(projectFolder + @"Pictures\whatsinside\" +
                _results[DEFAULT_IMAGE_COL][DEFAULT_IMAGE_ROW].ToString());
            _description.Text = _results[DEFAULT_DESC_COL][DEFAULT_DESC_ROW];
            _technicalSpecs.Text = _results[DEFAULT_TECH_DESC_COL][DEFAULT_TECH_DESC_ROW];
            _numItems = _results[0].ToArray().Length;
            db.CloseConnection();

        }

    }
}
