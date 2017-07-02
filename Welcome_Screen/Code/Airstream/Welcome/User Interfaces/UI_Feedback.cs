using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Airstream.Feedback.Statistics;
using Airstream.Feedback.Database;
using System.Diagnostics;
using Airstream.User_Interfaces;
using MySql.Data.MySqlClient;

namespace Airstream
{
    public partial class UI_Feedback : Form
    {
        // Instatiate all elements

        #region Instantiate all elements
        private Label _labelFeedbackQuestion;
        private Label _labelBarGraphOption1;
        private Label _labelBarGraphOption2;
        private Label _labelBarGraphOption3;
        private Label _labelBarGraphOption4;
        private Label _labelBarGraphOption5;
        private Label _labelFeedbackFavorites;
        private Label _labelFeedbackMoreInfo;
        private Label _labelForFeedbackPercentages;



        private string projectFolder = UI_General.GetProjectFolder();


        private int _feedbackID = 0;

        private Font _labelFeedbackQuestionFont = new Font("Arial Bold", 23.0f);
        private Font _labelForFeedbackPercentagesFont = new Font("Arial Bold", 13.5f);


        private Color _labelFeedbackQuestionForeColor = Color.FromArgb(255, 255, 255);
        private Color _buttonOptionBackColor = Color.FromArgb(255, 255, 255);


        private PictureBox _pictureBoxFeedbackFavorites;
        private PictureBox _backBtnFeedback;
        private PictureBox _fwdBtnFeedback;
        private PictureBox _homeBtn;

        private Button _buttonOption0;
        private Button _buttonOption1;
        private Button _buttonOption2;
        private Button _buttonOption3;
        private Button _buttonOption4;


        private List<string> _answers = new List<string>();
        private List<int> _yOrNoIndexes;


        private static int _currentFeedbackQ = 0;
        private static int _numFeedbackQs = 0;
        private static int _currentSummaryQ = 0;
        PieChart A = new PieChart();
        List<Tuple<string, float>> B = new List<Tuple<string, float>>();
        private static int _screenWidth = UI_General.GetSizeScreen().Width;
        private static int _screenHeight = UI_General.GetSizeScreen().Height;

        private const int FEEDBACK_QUESTION_COL = 2;
        private const int YES_OR_NO_COL = 1;
        private const int ANSWER_ONE = 3;
        private const int ANSWER_TWO = 4;
        private const int ANSWER_THREE = 5;
        private const int ANSWER_FOUR = 6;
        private const int ANSWER_FIVE = 7;

        #endregion

        /// <summary>
        /// Constructor for the Feedback UI which takes in the list of questions as its only parameter
        /// </summary>
        /// <param name="questions"></param>

        public UI_Feedback()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            //Create a blank form to work with 
            UI_General.SetGeneralElements(this);
            UpdateFeedbackID();
            _yOrNoIndexes = GetYorNoIndexes();
            // Set all the labels/elements needed
            SetElements();
            AddControls();
            BringControlsToFront();
            AddEventHandlers();
            //Begin the Feedback
            _numFeedbackQs = GetNumFeedbackQs();
            HideEvaluationElements();
            StartFeedback();

        }

        public void SetElements()
        {
            _labelForFeedbackPercentages = new Label();
            _labelForFeedbackPercentages.BackColor = UI_General.GetLabelGrayBackColor();
            _labelForFeedbackPercentages.Cursor = Cursors.No;
            _labelForFeedbackPercentages.ForeColor = UI_General.GetLabelGrayForeColor();
            _labelForFeedbackPercentages.Font = _labelForFeedbackPercentagesFont;
            _labelForFeedbackPercentages.Location = new Point(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.63), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.50));
            _labelForFeedbackPercentages.Size = new Size(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.2), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.278));
            _labelForFeedbackPercentages.Text = "";
            _labelForFeedbackPercentages.Visible = false;

           

            _pictureBoxFeedbackFavorites = new PictureBox();
            _pictureBoxFeedbackFavorites.BackColor = UI_General.GetLabelGrayBackColor();
            _pictureBoxFeedbackFavorites.Location = new Point(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.4), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.50));
            _pictureBoxFeedbackFavorites.Size = new Size(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.156), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.279));
            _pictureBoxFeedbackFavorites.Visible = false;



            B.Add(new Tuple<string, float>("A", 12));
            B.Add(new Tuple<string, float>("A", 2));
            B.Add(new Tuple<string, float>("A", 6));
            B.Add(new Tuple<string, float>("A", 9));
            B.Add(new Tuple<string, float>("A", 7));

            _pictureBoxFeedbackFavorites.BackgroundImage = A.DrawPieChart(B);


            _labelBarGraphOption1 = new Label();
            _labelBarGraphOption1.BackColor = ShowStatistics.DetermineColor();
            _labelBarGraphOption1.Location = new Point(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.21), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.51));
            _labelBarGraphOption1.Size = new Size(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.16), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.032));
            _labelBarGraphOption1.Visible = false;

            _labelBarGraphOption2 = new Label();
            _labelBarGraphOption2.BackColor = ShowStatistics.DetermineColor();
            _labelBarGraphOption2.Location = new Point(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.21), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.56));
            _labelBarGraphOption2.Size = new Size(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.016), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.032));
            _labelBarGraphOption2.Visible = false;



            _labelBarGraphOption3 = new Label();
            _labelBarGraphOption3.BackColor = ShowStatistics.DetermineColor();
            _labelBarGraphOption3.Location = new Point(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.21), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.61));
            _labelBarGraphOption3.Size = new Size(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.076), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.032));
            _labelBarGraphOption3.Visible = false;

            _labelBarGraphOption4 = new Label();
            _labelBarGraphOption4.BackColor = ShowStatistics.DetermineColor();
            _labelBarGraphOption4.Location = new Point(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.21), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.66));
            _labelBarGraphOption4.Size = new Size(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.122), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.032));
            _labelBarGraphOption4.Visible = false;


            _labelBarGraphOption5 = new Label();
            _labelBarGraphOption5.BackColor = ShowStatistics.DetermineColor();
            _labelBarGraphOption5.Location = new Point(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.21), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.71));
            _labelBarGraphOption5.Size = new Size(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.092), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.032));
            _labelBarGraphOption5.Visible = false;



            _labelFeedbackMoreInfo = new Label();

            // Feedback Question element
            _labelFeedbackQuestion = new Label();
            _labelFeedbackQuestion.Font = _labelFeedbackQuestionFont;
            _labelFeedbackQuestion.Size = new Size(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.75), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.14));
            _labelFeedbackQuestion.Text = "";
            _labelFeedbackQuestion.TextAlign = ContentAlignment.MiddleCenter;
            _labelFeedbackQuestion.Top += Convert.ToInt32(_screenHeight * 0.25);
            _labelFeedbackQuestion.Left += 150;

            _backBtnFeedback = new PictureBox();
            _backBtnFeedback.BackColor = Color.White;
            _backBtnFeedback.BackgroundImage = new Bitmap(projectFolder + @"Pictures\general\back.png");
            _backBtnFeedback.BackgroundImageLayout = ImageLayout.Stretch;
            _backBtnFeedback.Size = new Size(100, 100);
            _backBtnFeedback.Top += Convert.ToInt16(UI_General.GetSizeScreen().Height * 0.5);
            _backBtnFeedback.Left += Convert.ToInt16(UI_General.GetSizeScreen().Width * 0.07);

            _fwdBtnFeedback = new PictureBox();
            _fwdBtnFeedback.BackColor = Color.White;
            _fwdBtnFeedback.BackgroundImage = new Bitmap(projectFolder + @"Pictures\general\forward.png");
            _fwdBtnFeedback.BackgroundImageLayout = ImageLayout.Stretch;
            _fwdBtnFeedback.Size = new Size(100, 100);
            _fwdBtnFeedback.Top += Convert.ToInt16(UI_General.GetSizeScreen().Height * 0.5);
            _fwdBtnFeedback.Left += Convert.ToInt16(UI_General.GetSizeScreen().Width * 0.83);

            _fwdBtnFeedback.Visible = false;
            _backBtnFeedback.Visible = false;



            _homeBtn = new PictureBox();
            _homeBtn.BackColor = Color.Transparent;
            _homeBtn.BackgroundImage = new Bitmap(projectFolder + @"Pictures\general\home_icon.png");
            _homeBtn.Size = new Size(50, 50);
            _homeBtn.BackgroundImageLayout = ImageLayout.Stretch;

            _homeBtn.Visible = false;

            ShowStatistics.getUsedColors().Clear();
            SetQandAElements();



        }
        
        public void AddEventHandlers()
        {
            _buttonOption0.Click += Option_Click;
            _buttonOption1.Click += Option_Click;
            _buttonOption2.Click += Option_Click;
            _buttonOption3.Click += Option_Click;
            _buttonOption4.Click += Option_Click;
            _backBtnFeedback.Click += backBtn_Click;
            _fwdBtnFeedback.Click += fwdBtn_Click;
            _homeBtn.Click += _homeBtn_Click;
        }

        public void SetQandAElements()
        {
            // QUESTION & ANSWER - ELEMENTS

            int screenWidth = Convert.ToInt32(UI_General.GetSizeScreen().Width);
            int screenHeight = Convert.ToInt32(UI_General.GetSizeScreen().Height);
            int buttonSize = 200;
            double spacing = (screenWidth - 5 * buttonSize) / 6;

            _buttonOption0 = new Button();
            _buttonOption1 = new Button();
            _buttonOption2 = new Button();
            _buttonOption3 = new Button();
            _buttonOption4 = new Button();

            _buttonOption0.Size = _buttonOption1.Size = _buttonOption2.Size = _buttonOption3.Size = _buttonOption4.Size = new Size(buttonSize, buttonSize);
            _buttonOption0.BackColor = _buttonOption1.BackColor = _buttonOption2.BackColor = _buttonOption3.BackColor = _buttonOption4.BackColor = _buttonOptionBackColor;
            _buttonOption0.ForeColor = _buttonOption1.ForeColor = _buttonOption2.ForeColor = _buttonOption3.ForeColor = _buttonOption4.ForeColor = UI_General.GetLabelGrayForeColor();
            _buttonOption0.Font = _buttonOption1.Font = _buttonOption2.Font = _buttonOption3.Font = _buttonOption4.Font = UI_General.GetLabelGrayFont();
            _buttonOption0.Top += 25 + Convert.ToInt16((screenHeight - _buttonOption0.Height) / 2);
            _buttonOption0.Left += Convert.ToInt16(spacing);
            _buttonOption0.TextAlign = _buttonOption1.TextAlign = _buttonOption2.TextAlign = _buttonOption3.TextAlign = _buttonOption4.TextAlign = ContentAlignment.TopCenter;


            _buttonOption1.Top += 25 + Convert.ToInt16((screenHeight - _buttonOption0.Height) / 2);
            _buttonOption1.Left += Convert.ToInt16(2 * spacing + buttonSize);


            _buttonOption2.Top += 25 + Convert.ToInt16((screenHeight - _buttonOption0.Height) / 2);
            _buttonOption2.Left += Convert.ToInt16(3 * spacing + 2 * buttonSize);


            _buttonOption3.Top += 25 + Convert.ToInt16((screenHeight - _buttonOption0.Height) / 2);
            _buttonOption3.Left += Convert.ToInt16(4 * spacing + 3 * buttonSize);


            _buttonOption4.Top += 25 + Convert.ToInt16((screenHeight - _buttonOption0.Height) / 2);
            _buttonOption4.Left += Convert.ToInt16(5 * spacing + 4 * buttonSize);


        }

        public void InstantiateElements()
        {

        }

        public void AddControls()
        {
            Controls.Add(_labelForFeedbackPercentages);
            Controls.Add(_buttonOption4);
            Controls.Add(_buttonOption3);
            Controls.Add(_buttonOption2);
            Controls.Add(_buttonOption1);
            Controls.Add(_buttonOption0);
            Controls.Add(_homeBtn);
            Controls.Add(_backBtnFeedback);
            Controls.Add(_fwdBtnFeedback);
            Controls.Add(_labelFeedbackQuestion);
            Controls.Add(_labelBarGraphOption5);
            Controls.Add(_labelBarGraphOption4);
            Controls.Add(_labelBarGraphOption3);
            Controls.Add(_labelBarGraphOption2);
            Controls.Add(_pictureBoxFeedbackFavorites);
            Controls.Add(_labelBarGraphOption1);
        }

        public void BringControlsToFront()
        {
            _fwdBtnFeedback.BringToFront();
            _backBtnFeedback.BringToFront();
            _homeBtn.BringToFront();
            _labelBarGraphOption1.BringToFront();
            _labelBarGraphOption2.BringToFront();
            _labelBarGraphOption3.BringToFront();
            _labelBarGraphOption4.BringToFront();
            _labelBarGraphOption5.BringToFront();
            _labelFeedbackQuestion.BringToFront();
            _pictureBoxFeedbackFavorites.BringToFront();
            _labelForFeedbackPercentages.BringToFront();
            _buttonOption0.BringToFront();
            _buttonOption1.BringToFront();
            _buttonOption2.BringToFront();
            _buttonOption3.BringToFront();
            _buttonOption4.BringToFront();
        }

        private static List<int> GetYorNoIndexes()
        {
            List<int> indexes = new List<int>();

            DatabaseConnection db = new DatabaseConnection();
            List<string>[] result = db.SelectFromFeedbackQs("SELECT * FROM feedbackqs");
            
            for(int i =0; i < result[0].ToArray().Length; i++)
            {
                if(result[1][i] == 1.ToString())
                {
                    indexes.Add(i);
                }
            }
            return indexes;
        }


        private static int GetNumFeedbackQs()
        {
            DatabaseConnection db = new DatabaseConnection();
            List<string>[] result = db.SelectFromFeedbackQs("SELECT * FROM feedbackqs");
            return result[0].ToArray().Length;

        }

        private void _homeBtn_Click(object sender, EventArgs e)
        {
            _currentFeedbackQ = 0;
            _currentSummaryQ = 0;
            ActiveForm.Close();
            UI_Default.defaultForm.Close();
        }



        /// <summary>
        /// Start the feedback process by calling the NextQuestion Function to display the first question with _currentQuestion = 0
        /// </summary>
        public void StartFeedback()
        {
            DisplayQuestion();

        }

        /// <summary>
        /// A function to loop through the questions until they are all answered
        /// </summary>
        public void DisplayQuestion()
        {

            if (_currentFeedbackQ < _numFeedbackQs)
            {
                List<string>[] result = ConnectToDB(_currentFeedbackQ);
                _labelFeedbackQuestion.Text = result[FEEDBACK_QUESTION_COL][_currentFeedbackQ].ToString();


                if(_currentFeedbackQ == 0)
                {
                    try
                    {
                        _buttonOption0.BackgroundImage = new Bitmap(projectFolder + @"Pictures\feedback\alexa_logo_done.jpg");
                        _buttonOption0.BackgroundImageLayout = ImageLayout.Stretch;
                        _buttonOption0.Text = result[ANSWER_ONE][_currentFeedbackQ].ToString();
                        _buttonOption1.BackgroundImage = new Bitmap(projectFolder + @"Pictures\feedback\netatmo_logo_done.jpg");
                        _buttonOption1.BackgroundImageLayout = ImageLayout.Stretch;
                        _buttonOption1.Text = result[ANSWER_TWO][_currentFeedbackQ].ToString();
                        _buttonOption2.BackgroundImage = new Bitmap(projectFolder + @"Pictures\feedback\touchtable_logo_done.jpg");
                        _buttonOption2.BackgroundImageLayout = ImageLayout.Stretch;
                        _buttonOption2.Text = result[ANSWER_THREE][_currentFeedbackQ].ToString();
                        _buttonOption3.BackgroundImage = new Bitmap(projectFolder + @"Pictures\feedback\welcomescreen_logo_done.jpg");
                        _buttonOption3.BackgroundImageLayout = ImageLayout.Stretch;
                        _buttonOption3.Text = result[ANSWER_FOUR][_currentFeedbackQ].ToString();
                        _buttonOption4.BackgroundImage = new Bitmap(projectFolder + @"Pictures\feedback\digitalboardroom_logo_done.jpg");
                        _buttonOption4.BackgroundImageLayout = ImageLayout.Stretch;
                        _buttonOption4.Text = result[ANSWER_FIVE][_currentFeedbackQ].ToString();
                    }
                    catch
                    {
                        Debug.Print("One of more of the image paths is wrong, please check it and try again");
                    }
                   

                }
                else
                {
                    try
                    {
                        _buttonOption0.BackgroundImage = new Bitmap(projectFolder + @"Pictures\feedback\faces\really_happy.png");
                        _buttonOption1.BackgroundImage = new Bitmap(projectFolder + @"Pictures\feedback\faces\happy.png");
                        _buttonOption2.BackgroundImage = new Bitmap(projectFolder + @"Pictures\feedback\faces\neutral.png");
                        _buttonOption3.BackgroundImage = new Bitmap(projectFolder + @"Pictures\feedback\faces\sad.png");
                        _buttonOption4.BackgroundImage = new Bitmap(projectFolder + @"Pictures\feedback\faces\crying.png");
                        _buttonOption0.Text = _buttonOption1.Text = _buttonOption2.Text
                            = _buttonOption3.Text = _buttonOption4.Text = "";
                    }
                    catch
                    {
                        Debug.Print("One of more of the image paths is wrong, please check it and try again");

                    }

                }

                if (result[YES_OR_NO_COL][_currentFeedbackQ].ToString() == 0.ToString())
                {
                    _buttonOption0.Name = result[ANSWER_ONE][_currentFeedbackQ].ToString();
                    _buttonOption1.Name = result[ANSWER_TWO][_currentFeedbackQ].ToString();
                    _buttonOption2.Name = result[ANSWER_THREE][_currentFeedbackQ].ToString();
                    _buttonOption3.Name = result[ANSWER_FOUR][_currentFeedbackQ].ToString();
                    _buttonOption4.Name = result[ANSWER_FIVE][_currentFeedbackQ].ToString();
                }
                else
                {
                    _buttonOption0.Visible = false;
                    _buttonOption2.Visible = false;
                    _buttonOption4.Visible = false;
                    _buttonOption1.Name = result[ANSWER_TWO][_currentFeedbackQ].ToString();
                    _buttonOption3.Name = result[ANSWER_FOUR][_currentFeedbackQ].ToString();
                }

            }
            else if(_currentFeedbackQ == _numFeedbackQs)
            {
                AddAnswersToDB();
                AddHomeScreenButton();
                ShowEvaluationForFavourites();
            }
        }

        public static List<string>[] ConnectToDB(int displayQuestion)
        {
            DatabaseConnection db = new DatabaseConnection();
            List<string>[] result = db.SelectFromFeedbackQs("SELECT * FROM feedbackqs");
            db.CloseConnection();
            return result;
        }


        public void AddHomeScreenButton()
        {
            _homeBtn.Visible = true;
            UI_General._labelWhite.Height = Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.64);
            int containerHeight = UI_General._labelWhite.Height;
            int containerWidth = UI_General._labelWhite.Width;

            int home_x = Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.95);
            int home_y = Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.95 - _homeBtn.Height);

            _homeBtn.Location = new Point(home_x, home_y);


        }



        public void AddAnswersToDB()
        {
            DatabaseConnection db = new DatabaseConnection();
            int i = 0;
            foreach (var answers in _answers)
            {
                string q = String.Format("INSERT INTO feedback VALUES('{0}','{1}','{2}');", _feedbackID + i, i, _answers[i]);
                db.InsertUpdateDelete(q);
                Debug.Print(q);
                i += 1;
            }
            db.CloseConnection();

        }

        public void ShowEvaluationForFavourites()
        {
            ClearScreenForFeedbackSummary();
            DatabaseConnection db = new DatabaseConnection();
            List<string>[] questions = db.SelectFromFeedbackQs("SELECT * FROM feedbackqs");

            // Array to store percentages
            Dictionary<string, float> data = new Dictionary<string, float>();
            data = GetFavoritesData();

            PieChart A = new PieChart();
            List<Tuple<string, float>> B = new List<Tuple<string, float>>();

            B.Add(new Tuple<string, float>("Alexa", data["Alexa"]));
            B.Add(new Tuple<string, float>("NetAtmo", data["NetAtmo"]));
            B.Add(new Tuple<string, float>("Digital Boardroom", data["Digital Boardroom"]));
            B.Add(new Tuple<string, float>("55 Zoll-Tisch", data["55 Zoll-Tisch"]));
            B.Add(new Tuple<string, float>("Welcome-Screen", data["Welcome-Screen"]));
            Bitmap pieChart = A.DrawPieChart(B);

            _pictureBoxFeedbackFavorites.BackgroundImage = pieChart;
            _pictureBoxFeedbackFavorites.Visible = true;

            _labelBarGraphOption1.Visible = true;
            _labelBarGraphOption2.Visible = true;
            _labelBarGraphOption3.Visible = true;
            _labelBarGraphOption4.Visible = true;
            _labelBarGraphOption5.Visible = true;
            _labelFeedbackQuestion.Text = questions[2][_currentSummaryQ].ToString();
            _labelFeedbackQuestion.Visible = true;

            _labelBarGraphOption1.Size = _labelBarGraphOption2.Size = _labelBarGraphOption3.Size = _labelBarGraphOption4.Size = _labelBarGraphOption5.Size = new Size(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.122), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.032));
            _labelBarGraphOption1.TextAlign = _labelBarGraphOption2.TextAlign = _labelBarGraphOption3.TextAlign = _labelBarGraphOption4.TextAlign = _labelBarGraphOption5.TextAlign = ContentAlignment.MiddleRight;
            _labelBarGraphOption1.Text = "Alexa";
            _labelBarGraphOption2.Text = "NetAtmo";
            _labelBarGraphOption3.Text = "Digital Boardroom";
            _labelBarGraphOption4.Text = "55 Zoll-Tisch";
            _labelBarGraphOption5.Text = "Welcome-Screen";

            _labelForFeedbackPercentages.Visible = true;


            string[] answersQuestion1 = { "Alexa", "NetAtmo", "Digital Boardroom", "55 Zoll-Tisch", "Welcome-Screen" };
            string[] votes = { Convert.ToInt16(data["Alexa"] * 100) + "%", Convert.ToInt16(data["NetAtmo"] * 100) + "%",
                Convert.ToInt16(data["Digital Boardroom"] * 100) + "%", Convert.ToInt16(data["55 Zoll-Tisch"] * 100) + "%",
                Convert.ToInt16(data["Welcome-Screen"] * 100) + "%" };
            String s = ""; //String.Format("{1,-10} {0,-18}\n\n", "Optionen", "Stimmen in %");

            for (int index = 0; index < answersQuestion1.Length; index++)
            {
                if (index < answersQuestion1.Length - 1)
                    s += String.Format("{1,-10} {0,-18:N0}\n\n", answersQuestion1[index], votes[index]);
                else
                    s += String.Format("{1,-10} {0,-18:N0}", answersQuestion1[index], votes[index]);
            }

            _labelForFeedbackPercentages.Text = s;

        }

        private void ClearScreenForFeedbackSummary()
        {

            _labelFeedbackQuestion.Visible = false;
            UI_General.GetLabelGray().Visible = true;
            _labelFeedbackQuestion.BackColor = UI_General.GetLabelGrayBackColor();
            //Change colour of feedback question so it is visible on the white screen
            _labelFeedbackQuestion.ForeColor = Color.FromArgb(45, 45, 45);
            HideQandAElements();
            _fwdBtnFeedback.Visible = true;
            _backBtnFeedback.Visible = true;
            
            _pictureBoxFeedbackFavorites.Visible = false;
            _labelBarGraphOption1.Visible = false;
            _labelBarGraphOption2.Visible = false;
            _labelBarGraphOption3.Visible = false;
            _labelBarGraphOption4.Visible = false;
            _labelBarGraphOption5.Visible = false;
            _labelForFeedbackPercentages.Visible = false;

        }


        private void HideEvaluationElements()
        {
            UI_General.GetLabelGray().Visible = false;
            _labelForFeedbackPercentages.Visible = false;
            _pictureBoxFeedbackFavorites.Visible = false;
            _labelBarGraphOption1.Visible = false;
            _labelBarGraphOption2.Visible = false;
            _labelBarGraphOption3.Visible = false;
            _labelBarGraphOption4.Visible = false;
            _labelBarGraphOption5.Visible = false;
            _labelFeedbackQuestion.BackColor = Color.Transparent;
            _labelFeedbackQuestion.ForeColor = _labelFeedbackQuestionForeColor;
        }

        private void HideQandAElements()
        {
            _buttonOption0.Visible = false;
            _buttonOption1.Visible = false;
            _buttonOption2.Visible = false;
            _buttonOption3.Visible = false;
            _buttonOption4.Visible = false;

        }

        private void ShowQandAElements()
        {
            _buttonOption0.Visible = true;
            _buttonOption1.Visible = true;
            _buttonOption2.Visible = true;
            _buttonOption3.Visible = true;
            _buttonOption4.Visible = true;
        }



        public Dictionary<string, float> GetFavoritesData()
        {
            int[] pData = new int[5];
            string[] answers = new string[] { "Alexa", "NetAtmo", "Digital Boardroom", "55 Zoll-Tisch", "Welcome-Screen" };
            string defaultQuery;
            defaultQuery = @"SELECT Count(feedback.feedbackAnswer)
                             FROM feedback
                             WHERE feedback.feedbackAnswer =";
            DatabaseConnection db = new DatabaseConnection();

            try
            {
                int i = 0;
                float total = 0;
                foreach (string answer in answers)
                {
                    string q = answer;
                    string query = defaultQuery + " '" + q + "';";
                    int numFavourites = db.Count(query);
                    pData[i] = numFavourites;
                    total += numFavourites;
                    i += 1;
                }
                Dictionary<string, float> dictionary = new Dictionary<string, float>();
                dictionary.Add(answers[0], (pData[0] / total));
                dictionary.Add(answers[1], (pData[1] / total));
                dictionary.Add(answers[2], (pData[2] / total));
                dictionary.Add(answers[3], (pData[3] / total));
                dictionary.Add(answers[4], (pData[4] / total));

                return dictionary;
            }
            catch(MySqlException e)
            {
                Debug.Print(e.ToString());
                return new Dictionary<string, float>();
            }
           
        }

        public Dictionary<string, float> GetFiveOptionQData(int fQuestion)
        {
            int[] pData = new int[5];
            string[] answers = new string[] { "Sehr gut", "Gut", "Nichts besonderes", "Schlecht", "Sehr schlecht" };
            string defaultQuery;
            defaultQuery = @"SELECT Count(feedback.feedbackAnswer)
                             FROM feedback
                             WHERE feedback.feedbackAnswer =";
            DatabaseConnection db = new DatabaseConnection();

            try
            {
                int i = 0;
                float total = 0;
                foreach (string answer in answers)
                {
                    string q = answer;
                    string query = defaultQuery + " '" + q + "'" + " AND feedback.feedbackQ ='" + fQuestion + "';";
                    //Debug.Print(query.ToString());
                    int count = db.Count(query);
                    pData[i] = count;
                    total += count;
                    i += 1;
                }
                Dictionary<string, float> dictionary = new Dictionary<string, float>();
                dictionary.Add(answers[0], (pData[0] / total));
                dictionary.Add(answers[1], (pData[1] / total));
                dictionary.Add(answers[2], (pData[2] / total));
                dictionary.Add(answers[3], (pData[3] / total));
                dictionary.Add(answers[4], (pData[4] / total));
                return dictionary;
            }
            catch(MySqlException e)
            {
                Debug.Print(e.ToString());
                return new Dictionary<string, float>();
            }
           
        }

        public Dictionary<string, float> GetTwoOptionQData(int fQuestion)
        {
            int[] pData = new int[2];
            string[] answers = new string[] { "Ja", "Nein" };
            string defaultQuery;
            defaultQuery = @"SELECT Count(feedback.feedbackAnswer)
                             FROM feedback
                             WHERE feedback.feedbackAnswer =";
            DatabaseConnection db = new DatabaseConnection();

            try
            {
                int i = 0;
                float total = 0;
                foreach (string answer in answers)
                {
                    string q = answer;
                    string query = defaultQuery + " '" + q + "'" + " AND feedback.feedbackQ ='" + fQuestion + "';";
                    Debug.Print(query.ToString());
                    int count = db.Count(query);
                    Debug.Print(count.ToString());
                    pData[i] = count;
                    total += count;
                    i += 1;
                }
                Debug.Print(total.ToString());
                Dictionary<string, float> dictionary = new Dictionary<string, float>();
                dictionary.Add(answers[0], (pData[0] / total));
                dictionary.Add(answers[1], (pData[1] / total));
                Debug.Print((pData[0] / total).ToString());
                Debug.Print((pData[1] / total).ToString());

                return dictionary;
            }
            catch(MySqlException e)
            {
                Debug.Print(e.ToString());
                return new Dictionary<string, float>();
            }
          
        }


        public void ShowEvaluationForQWithFiveAnswers(int currentSummaryQuestion)
        {
            Debug.Print("Here");
            ClearScreenForFeedbackSummary();

            DatabaseConnection db = new DatabaseConnection();
            List<string>[] questions = db.SelectFromFeedbackQs("SELECT * FROM feedbackqs");

            // Array to store percentages
            Dictionary<string, float> data = new Dictionary<string, float>();
            data = GetFiveOptionQData(currentSummaryQuestion);

            PieChart A = new PieChart();
            List<Tuple<string, float>> B = new List<Tuple<string, float>>();

            B.Add(new Tuple<string, float>("Sehr gut", data["Sehr gut"]));
            B.Add(new Tuple<string, float>("Gut", data["Gut"]));
            B.Add(new Tuple<string, float>("Nichts besonderes", data["Nichts besonderes"]));
            B.Add(new Tuple<string, float>("Schlecht", data["Schlecht"]));
            B.Add(new Tuple<string, float>("Sehr schlecht", data["Sehr schlecht"]));
            Bitmap pieChart = A.DrawPieChart(B);

            _pictureBoxFeedbackFavorites.BackgroundImage = pieChart;
            _pictureBoxFeedbackFavorites.Visible = true;

            _labelBarGraphOption1.Visible = true;
            _labelBarGraphOption2.Visible = true;
            _labelBarGraphOption3.Visible = true;
            _labelBarGraphOption4.Visible = true;
            _labelBarGraphOption5.Visible = true;
            _labelFeedbackQuestion.Text = questions[2][_currentSummaryQ].ToString();
            _labelFeedbackQuestion.Visible = true;


            _labelBarGraphOption1.Size = _labelBarGraphOption2.Size = _labelBarGraphOption3.Size = _labelBarGraphOption4.Size = _labelBarGraphOption5.Size = new Size(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.122), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.032));
            _labelBarGraphOption1.TextAlign = _labelBarGraphOption2.TextAlign = _labelBarGraphOption3.TextAlign = _labelBarGraphOption4.TextAlign = _labelBarGraphOption5.TextAlign = ContentAlignment.MiddleRight;
            _labelBarGraphOption1.Text = "Sehr gut";
            _labelBarGraphOption2.Text = "Gut";
            _labelBarGraphOption3.Text = "Nichts besonderes";
            _labelBarGraphOption4.Text = "Schlecht";
            _labelBarGraphOption5.Text = "Sehr schlecht";

            _labelForFeedbackPercentages.Visible = true;


            string[] answersQuestion1 = { "Sehr gut", "Gut", "Nichts besonderes", "Schlecht", "Sehr schlecht" };
            string[] votes = { Math.Round(Convert.ToDouble(data["Sehr gut"] * 100),2) + "%",
                               Math.Round(Convert.ToDouble(data["Gut"] * 100), 2) + "%",
                               Math.Round(Convert.ToDouble(data["Nichts besonderes"] * 100), 2) + "%",
                               Math.Round(Convert.ToDouble(data["Schlecht"] * 100), 2) + "%",
                               Math.Round(Convert.ToDouble(data["Sehr schlecht"] * 100), 2) + "%" };
            String s = ""; //String.Format("{1,-10} {0,-18}\n\n", "Optionen", "Stimmen in %");

            for (int index = 0; index < answersQuestion1.Length; index++)
            {
                if (index < answersQuestion1.Length - 1)
                    s += String.Format("{1,-10} {0,-18:N0}\n\n", answersQuestion1[index], votes[index]);
                else
                    s += String.Format("{1,-10} {0,-18:N0}", answersQuestion1[index], votes[index]);
            }

            _labelForFeedbackPercentages.Text = s;

        }


        public void ShowEvaluationForQWithTwoAnswers(int currentSummaryQuestion)
        {
            Debug.Print("Now here");

            ClearScreenForFeedbackSummary();
            DatabaseConnection db = new DatabaseConnection();
            List<string>[] questions = db.SelectFromFeedbackQs("SELECT * FROM feedbackqs");

            // Array to store percentages
            Dictionary<string, float> data = new Dictionary<string, float>();
            data = GetTwoOptionQData(currentSummaryQuestion);

            PieChart A = new PieChart();
            List<Tuple<string, float>> B = new List<Tuple<string, float>>();

            B.Add(new Tuple<string, float>("Ja", data["Ja"]));
            B.Add(new Tuple<string, float>("Nein", data["Nein"]));

            Bitmap pieChart = A.DrawPieChart(B);

            _pictureBoxFeedbackFavorites.BackgroundImage = pieChart;
            _pictureBoxFeedbackFavorites.Visible = true;

            _labelBarGraphOption1.Visible = true;
            _labelBarGraphOption2.Visible = true;

            _labelFeedbackQuestion.Text = questions[2][_currentSummaryQ].ToString();
            _labelFeedbackQuestion.Visible = true;

            _labelBarGraphOption1.Size = _labelBarGraphOption2.Size = _labelBarGraphOption3.Size = _labelBarGraphOption4.Size = _labelBarGraphOption5.Size = new Size(Convert.ToInt32(UI_General.GetSizeScreen().Width * 0.122), Convert.ToInt32(UI_General.GetSizeScreen().Height * 0.032));
            _labelBarGraphOption1.TextAlign = _labelBarGraphOption2.TextAlign = _labelBarGraphOption3.TextAlign = _labelBarGraphOption4.TextAlign = _labelBarGraphOption5.TextAlign = ContentAlignment.MiddleRight;
            _labelBarGraphOption1.Text = "Ja";
            _labelBarGraphOption2.Text = "Nein";

            _labelForFeedbackPercentages.Visible = true;


            string[] answersQuestion = { "Ja", "Nein" };
            string[] votes = { Convert.ToInt16(data["Ja"] * 100) + "%", Convert.ToInt16(data["Nein"] * 100) + "%" };
            String s = ""; //String.Format("{1,-10} {0,-18}\n\n", "Optionen", "Stimmen in %");

            for (int index = 0; index < answersQuestion.Length; index++)
            {
                s += String.Format("{1,-10} {0,-18:N0}\n\n", answersQuestion[index], votes[index]);

            }

            _labelForFeedbackPercentages.Text = s;

        }


        public void UpdateFeedbackID()
        {
            DatabaseConnection db = new DatabaseConnection();
            string q = "SELECT * from feedback";
            List<string>[] result = db.SelectFromFeedback(q);
            int length = Convert.ToInt16((result[0].Count().ToString()));
            _feedbackID = length;
        }



        /*  -----------------------------------        EVENT HANDLERS -------------------------------------- */       
        /// <summary>
        /// An event handler for clicking any of the options to a question
        /// </summary>
        private void Option_Click(object sender, EventArgs e)
        {
            Button answerAsBtn = (Button)sender;
            _answers.Add(answerAsBtn.Name);
            _currentFeedbackQ += 1;

            DisplayQuestion();

        }



        private void backBtn_Click(object sender, EventArgs e)
        {

            if (_currentSummaryQ > 0)
            {
                _currentSummaryQ -= 1;
                ClearScreenForFeedbackSummary();
                if (_currentSummaryQ == 0)
                {

                    ShowEvaluationForFavourites();
                }
                else if (_yOrNoIndexes.Contains(_currentSummaryQ))
                {
                    ShowEvaluationForQWithTwoAnswers(_currentSummaryQ);
                }
                else
                {
                    ShowEvaluationForQWithFiveAnswers(_currentSummaryQ);

                }
            }

        }

        private void fwdBtn_Click(object sender, EventArgs e)
        {
            Debug.Print("Current sum q: " + _currentSummaryQ.ToString());
            if (_currentSummaryQ < _numFeedbackQs - 1)
            {
                _currentSummaryQ += 1;
                ClearScreenForFeedbackSummary();
                if (_currentSummaryQ == 0)
                {

                    ShowEvaluationForFavourites();
                }
                else if (_yOrNoIndexes.Contains(_currentSummaryQ))
                {
                    ShowEvaluationForQWithTwoAnswers(_currentSummaryQ);
                }
                else
                {
                    ShowEvaluationForQWithFiveAnswers(_currentSummaryQ);

                }
            }


        }

        private void UI_Feedback_Load(object sender, EventArgs e)
        {

        }
    }
}
