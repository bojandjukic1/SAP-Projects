using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Airstream.Feedback.Statistics;
using Airstream.Feedback.Database;
using System.Diagnostics;


namespace Airstream.User_Interfaces
{
    public partial class UI_DYK : Form
    {
        private static Label _labelForQuestion;
        private static Label _labelForAnswer;

        private static string projectFolder = UI_General.GetProjectFolder();
        private static Font _labelForQuestionFont;

        private static Button _answerOption1;
        private static Button _answerOption2;
        private static Button _answerOption3;
        private static Button _answerOption4;
        private static PictureBox _homeBtn;
        private static PictureBox _backBtn;
        private static PictureBox _fwdBtn;

        private static int screenWidth = UI_General.GetSizeScreen().Width;
        private static int screenHeight = UI_General.GetSizeScreen().Height;
        private static int _displayQuestion;
        private static int _numQuestions = 0;
        private static List<string>[] _answers;
        private static Form _dykForm;
        private static bool _rightAnswerChecked = false;
        private const int QUESTION_COL = 1;
        private const int ANS_OPTION1_COL = 2;
        private const int ANS_OPTION2_COL = 3;
        private const int ANS_OPTION3_COL = 4;
        private const int ANS_OPTION4_COL = 5;

        public UI_DYK(int displayQuestion)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            UI_General.SetGeneralElements(this);
            _dykForm = this;
            _displayQuestion = displayQuestion;
            _numQuestions = GetNumQuestions();
            _answers = GetRightAnswers();
            InstantiateElements();
            SetUniqueElements();
            AddControlsToContainer();
            AddEventHandlers();
            UpdateDisplay();
           
        }

        public List<string>[] GetRightAnswers()
        {
            DatabaseConnection db = new DatabaseConnection();
            List<string>[] result = db.SelectFromDYK("SELECT * FROM didyouknowdata");
            return result;
        }

        public static int GetNumQuestions()
        {
            DatabaseConnection db = new DatabaseConnection();
            List<string>[] result = db.SelectFromDYK("SELECT * FROM didyouknowdata");
            return result[0].ToArray().Length;

        }
        public static void AddEventHandlers()
        {
            _homeBtn.Click += _homeBtn_Click;
            _answerOption1.Click += answer_Click;
            _answerOption2.Click += answer_Click;
            _answerOption3.Click += answer_Click;
            _answerOption4.Click += answer_Click;
            _backBtn.Click += _backBtn_Click;
            _fwdBtn.Click += _fwdBtn_Click;

        }

        private static void _fwdBtn_Click(object sender, EventArgs e)
        {
            Debug.Print(_numQuestions.ToString());
            if (_displayQuestion < _numQuestions - 1)
            {
                _displayQuestion += 1;
                UpdateDisplay();

            }
            else
            {
                _fwdBtn.Enabled = false;
            }
            _labelForAnswer.Visible = false;
            ResetButtonColours();
            _rightAnswerChecked = false;
        }

        private static void ResetButtonColours()
        {
            _answerOption1.BackColor = Color.White;
            _answerOption2.BackColor = Color.White;
            _answerOption3.BackColor = Color.White;
            _answerOption4.BackColor = Color.White;

        }

        private static void _backBtn_Click(object sender, EventArgs e)
        {
            _fwdBtn.Enabled = true;

            if (_displayQuestion > 0)
            {
                _displayQuestion -= 1;
                UpdateDisplay();

            }
            _labelForAnswer.Visible = false;
            ResetButtonColours();
            _rightAnswerChecked = false;
        }

        private static void answer_Click(object sender, EventArgs e)
        {
            _labelForAnswer.Visible = true;
            Button s = (Button)sender;
            if(_rightAnswerChecked == false)
            {
                CheckIfRightAnswer(s);

            }
        }

        private static void CheckIfRightAnswer(Button answer)
        {
            if(_answers[6][_displayQuestion] == answer.Text)
            {
                answer.BackColor = Color.LightGreen;
                _labelForAnswer.Text = "Richtig!";
            }
            else
            {
                _labelForAnswer.Text = "Falsch!";

                answer.BackColor = Color.IndianRed;
                if(_answerOption1.Text == _answers[6][_displayQuestion]){
                    _answerOption1.BackColor = Color.LightGreen;
                }
                else if(_answerOption2.Text == _answers[6][_displayQuestion]){
                    _answerOption2.BackColor = Color.LightGreen;
                }
                else if (_answerOption3.Text == _answers[6][_displayQuestion]){
                    _answerOption3.BackColor = Color.LightGreen;

                }
                else if (_answerOption4.Text == _answers[6][_displayQuestion]){
                    _answerOption4.BackColor = Color.LightGreen;

                }
            }
            _rightAnswerChecked = true;
        }

        private static void _homeBtn_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            UI_Default.defaultForm.Close();

        }

        public static void InstantiateElements()
        {
            _answerOption1 = new Button();
            _answerOption2 = new Button();
            _answerOption3 = new Button();
            _answerOption4 = new Button();
            _labelForAnswer = new Label();
            _labelForQuestion = new Label();
            _labelForQuestionFont = new Font("Arial Bold", 23.0f);
            _homeBtn = new PictureBox();
            _fwdBtn = new PictureBox();
            _backBtn = new PictureBox();


        }

        public static void SetUniqueElements()
        {
            UI_General._labelWhite.Visible = false;

            _answerOption1.Size = _answerOption2.Size = _answerOption3.Size = _answerOption4.Size = new Size(200, 200);
            _answerOption1.BackColor = _answerOption2.BackColor = _answerOption3.BackColor = _answerOption4.BackColor = Color.White;
            _answerOption1.TextAlign = _answerOption2.TextAlign = _answerOption3.TextAlign = _answerOption4.TextAlign = ContentAlignment.MiddleCenter;
            int answersHeight = Convert.ToInt32((screenHeight - _answerOption1.Height)/2);
            int spacing = Convert.ToInt32((screenWidth - 4 * _answerOption1.Width) / 5);
            int buttonWidth = _answerOption1.Width;

            _answerOption1.Top += answersHeight;
            _answerOption1.Left += spacing;
            _answerOption2.Top += answersHeight;
            _answerOption2.Left += 2*spacing + buttonWidth;
            _answerOption3.Top += answersHeight;
            _answerOption3.Left += 3*spacing + 2*buttonWidth;
            _answerOption4.Top += answersHeight;
            _answerOption4.Left += 4 * spacing + 3 * buttonWidth;
            _answerOption1.Text = _answerOption2.Text = _answerOption3.Text = _answerOption4.Text = "Default text";
            _answerOption1.Font = _answerOption2.Font = _answerOption3.Font = _answerOption4.Font = new Font("Arial", 15);

            //home button element
            _homeBtn.Size = new Size(50, 50);
            _homeBtn.BackgroundImage = new Bitmap(projectFolder + @"Pictures\general\home_icon.png");
            _homeBtn.BackgroundImageLayout = ImageLayout.Stretch;
            _homeBtn.BackColor = Color.Transparent;

            int home_x = Convert.ToInt32(screenWidth * 0.95);
            int home_y = Convert.ToInt32(screenHeight * 0.95 - _homeBtn.Height);

            _homeBtn.Location = new Point(home_x,home_y);

            // Labels
            _labelForQuestion.Text = "Default text";
            _labelForQuestion.TextAlign = ContentAlignment.MiddleCenter;
            _labelForQuestion.Font = _labelForQuestionFont;
            _labelForQuestion.Top += Convert.ToInt32(screenHeight * 0.15);
            _labelForQuestion.BackColor = _labelForAnswer.BackColor = Color.Transparent;
            _labelForQuestion.ForeColor = _labelForAnswer.ForeColor = Color.White;
            _labelForQuestion.Size = new Size(Convert.ToInt32(screenWidth), 50);

            _labelForAnswer.Text = "Default text";
            _labelForAnswer.TextAlign = ContentAlignment.MiddleCenter;
            _labelForAnswer.Font = _labelForQuestionFont;
            _labelForAnswer.Top += Convert.ToInt32(screenHeight * 0.75);
            _labelForAnswer.BackColor = _labelForAnswer.BackColor = Color.Transparent;
            _labelForAnswer.ForeColor = _labelForAnswer.ForeColor = Color.White;
            _labelForAnswer.Size = new Size(Convert.ToInt32(screenWidth), 50);
            _labelForAnswer.Visible = false;



            //back and fwd buttons
            int buttonsFromTop = Convert.ToInt32(screenHeight * 0.22);
            _fwdBtn.Size = new Size(75, 75);
            _fwdBtn.BackgroundImage = new Bitmap(projectFolder + @"Pictures\general\forward.png");
            _fwdBtn.BackgroundImageLayout = ImageLayout.Stretch;
            _fwdBtn.BackColor = _backBtn.BackColor = Color.Transparent;
            _fwdBtn.Location = new Point(Convert.ToInt32((screenWidth - _fwdBtn.Width) - 0.05*screenWidth), buttonsFromTop);
            _backBtn.Size = new Size(75, 75);
            _backBtn.BackgroundImage = new Bitmap(projectFolder + @"Pictures\general\back.png");
            _backBtn.BackgroundImageLayout = ImageLayout.Stretch;
            _backBtn.Location = new Point(Convert.ToInt32(screenWidth*0.05), buttonsFromTop);


        }

        public void AddControlsToContainer()
        {
            Controls.Add(_answerOption1);
            Controls.Add(_answerOption2);
            Controls.Add(_answerOption3);
            Controls.Add(_answerOption4);
            Controls.Add(_answerOption4);
            Controls.Add(_homeBtn);
            Controls.Add(_labelForQuestion);
            Controls.Add(_labelForAnswer);
            Controls.Add(_backBtn);
            Controls.Add(_fwdBtn);
            _labelForQuestion.BringToFront();
            _backBtn.BringToFront();
            _fwdBtn.BringToFront();

        }

        public static void UpdateDisplay()
        {

            List<string>[] result = ConnectToDB(_displayQuestion);
            _labelForQuestion.Text = result[QUESTION_COL][_displayQuestion].ToString();
            _answerOption1.Text = result[ANS_OPTION1_COL][_displayQuestion].ToString();
            _answerOption2.Text = result[ANS_OPTION2_COL][_displayQuestion].ToString();
            _answerOption3.Text = result[ANS_OPTION3_COL][_displayQuestion].ToString();
            _answerOption4.Text = result[ANS_OPTION4_COL][_displayQuestion].ToString();
        }

        public static List<string>[] ConnectToDB(int displayQuestion)
        {
            DatabaseConnection db = new DatabaseConnection();
            //resust[COL][ROW] - zero indexed 
            List<string>[] result = db.SelectFromDYK("SELECT * FROM didyouknowdata");
            db.CloseConnection();
            return result; 
        }
    }
}
