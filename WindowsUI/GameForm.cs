using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsUI
{
    public partial class GameForm : Form
    {
        public bool isClicked = false;
        public int m_CurrentTurn=0;
        public static Button CurrentButton;
        private GameLogic m_GameLogic;
        private int m_AmountOfTurns;
        private readonly Button[] r_buttonsOfRandomColors;
        public readonly Button[,] r_buttonsOfGameplay;
        private readonly Button[] r_getFeedBackButton;
        private readonly Button[,] r_actualFeedBack;
        private readonly List<Color> r_FeedBackColors;
        private readonly SelectingColor r_selectingColor;

        private Color[] r_colorOfPicked;

        public Color ButtonColor { get { return CurrentButton.BackColor; } set { CurrentButton.BackColor = value; } }

        

        public GameForm(int i_AmountOfTurns)
        {
            this.r_colorOfPicked = new Color[4];
            InitializeComponent();
            m_AmountOfTurns = i_AmountOfTurns;
            m_GameLogic = new GameLogic(i_AmountOfTurns);
            r_selectingColor = new SelectingColor(this);
            r_buttonsOfRandomColors = new Button[4];
            r_buttonsOfGameplay = new Button[i_AmountOfTurns, 4];
            r_getFeedBackButton = new Button[i_AmountOfTurns];
            r_actualFeedBack= new Button[m_AmountOfTurns,4];
            r_FeedBackColors = new List<Color>(4);
            this.Text = "Bulls And Cows";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoSize = true;
            

        }

        public void RunApp()
        {
            SetComputerButtons();
            SetPlayerButtons();
            SetFeedBackButtons();
            SetActualFeedBackButtons();
            this.ShowDialog();

        }
        private void SetActualFeedBackButtons()
        {
            for(int i = 0; i < m_AmountOfTurns; i++)
            {
                    int j = 0;
                    int xVal = 43 * ((5 + j) - (28 * j));
                    int yVal = 43 * ((i + 2) - (28 * i) + (i*28));
                    
                    r_actualFeedBack[i, j] = new Button();
                    r_actualFeedBack[i, j].Location = new Point(xVal+ (15 * j), yVal);
                    r_actualFeedBack[i, j].Enabled = false;
                    r_actualFeedBack[i, j].Size = new Size(15, 15);
                    this.Controls.Add(r_actualFeedBack[i, j++]);
                    
                    r_actualFeedBack[i, j] = new Button();
                    r_actualFeedBack[i, j].Location = new Point(xVal + (15 * j), yVal);
                    r_actualFeedBack[i, j].Enabled = false;
                    r_actualFeedBack[i, j].Size = new Size(15, 15);
                    this.Controls.Add(r_actualFeedBack[i, j++]);
                    r_actualFeedBack[i, j] = new Button();
                    r_actualFeedBack[i, j].Location = new Point(xVal, yVal + 15);
                    r_actualFeedBack[i, j].Enabled = false;
                    r_actualFeedBack[i, j].Size = new Size(15, 15);
                    this.Controls.Add(r_actualFeedBack[i, j++]);
                    
                    r_actualFeedBack[i, j] = new Button();
                    r_actualFeedBack[i, j].Location = new Point(xVal + 15, yVal + 15);
                    r_actualFeedBack[i, j].Enabled = false;
                    r_actualFeedBack[i, j].Size = new Size(15, 15);
                    this.Controls.Add(r_actualFeedBack[i, j++]);
                
            }
        }
        private void SetPlayerButtons()
        {
            for (int i = 0; i < r_buttonsOfGameplay.GetLength(0); i++)
            {
                for (int j = 0; j < r_buttonsOfGameplay.GetLength(1); j++)
                {
                    r_buttonsOfGameplay[i, j] = new Button();
                    r_buttonsOfGameplay[i, j].SetBounds(43 * j, 43 * (i + 2), 35, 35);
                    r_buttonsOfGameplay[i, j].Enabled = false;
                    this.Controls.Add(r_buttonsOfGameplay[i, j]);
                    r_buttonsOfGameplay[i, j].Click += new EventHandler(this.button_Click);
                    
                }

            }

            ToEnableClick();
        }
        
        private void SetFeedBackButtons()
        {
            for(int i = 0; i <m_AmountOfTurns ; i++)
            {
                r_getFeedBackButton[i] = new Button();
                r_getFeedBackButton[i].SetBounds(43 * 4, 43 * (i + 2)+8, 35, 20);
                r_getFeedBackButton[i].Text = "-->>";
                r_getFeedBackButton[i].Enabled = false;
                this.Controls.Add(r_getFeedBackButton[i]);
                r_getFeedBackButton[i].Click += new EventHandler(this.feedBackButton_Click);
                
            }
        }

        // $G$ CSS-008 (-3) Missing blank line, after "while" block.
        private void SetComputerButtons()
        {
            for (int k = 0; k < 4; k++)
            {
                r_buttonsOfRandomColors[k] = new Button();
                r_buttonsOfRandomColors[k].SetBounds(43 * k, 15, 35, 35);
                r_buttonsOfRandomColors[k].Enabled = false;
                Controls.Add(r_buttonsOfRandomColors[k]);
                r_buttonsOfRandomColors[k].BackColor = m_GameLogic.RandomColor();
                while (m_GameLogic.r_ComputerColorList.Contains(r_buttonsOfRandomColors[k].BackColor))
                {
                    r_buttonsOfRandomColors[k].BackColor = m_GameLogic.RandomColor();

                }
                m_GameLogic.r_ComputerColorList[k] = r_buttonsOfRandomColors[k].BackColor;
                r_buttonsOfRandomColors[k].BackColor = Color.Black;
            }
        }

        // $G$ CSS-007 (0) Missing blank line, after "for" block.
        private void ToDisableClick()
        {
            for (int i = 0; i < 4; i++)
            {
                r_buttonsOfGameplay[m_CurrentTurn, i].Enabled = false;
                this.Controls.Add(r_buttonsOfGameplay[m_CurrentTurn, i]);
            }
            m_CurrentTurn++;

        }

        private void ToEnableClick()
        {

            if (m_CurrentTurn <= m_AmountOfTurns)
            {
                for (int i = 0; i < 4; i++)
                {
                    r_buttonsOfGameplay[m_CurrentTurn, i].Enabled = true;
                    this.Controls.Add(r_buttonsOfGameplay[m_CurrentTurn, i]);
                }
            }
            

            for (int i = m_CurrentTurn + 1; i < m_AmountOfTurns; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    r_buttonsOfGameplay[i, j].Enabled = false;
                    this.Controls.Add(r_buttonsOfGameplay[i, j]);
                }
            }

        }

        // $G$ CSS-007 (0) Missing blank line, after "for" block.
        private void feedBackButton_Click(object sender, EventArgs e)
        {
            r_getFeedBackButton[m_CurrentTurn].Enabled = false;

            int k = 0;
            for (int i = 0; i < 4; i++)
            {
                if (m_GameLogic.CheckingAnswer(m_GameLogic.r_PlayerAnswerList[i], m_GameLogic.ComputerColorList[i]))
                {
                    r_actualFeedBack[m_CurrentTurn, k++].BackColor = Color.Black;
                }
               
            }

            for(int j = k; j < 4; j++)
            {
                if (m_GameLogic.PlayerColorCheckInComputerColors(m_GameLogic.r_PlayerAnswerList[j], m_GameLogic.ComputerColorList))
                {
                    r_actualFeedBack[m_CurrentTurn, k++].BackColor = Color.Yellow;
                }
            }
            if (m_CurrentTurn == m_AmountOfTurns-1)
            {
                for (int j = 0; j < 4; j++)
                {
                    r_buttonsOfRandomColors[j].BackColor = m_GameLogic.r_ComputerColorList[j];
                }
            }
            else
            {
                ToDisableClick();
                ToEnableClick();
            }

        }

       private bool isRowClicked()
        {
            bool isClicked = true;
            for(int i = 0; i < 4; i++)
            {
                if (r_buttonsOfGameplay[m_CurrentTurn, i].BackColor == SystemColors.Control)
                {
                    isClicked = false;
                }
                else
                {
                    m_GameLogic.r_PlayerAnswerList[i] = r_buttonsOfGameplay[m_CurrentTurn, i].BackColor;
                }

            }

            return isClicked;
        }

        // $G$ CSS-007 (0) Missing blank line, after "for" block.
        public bool CheckIfTheColorsExists(Color i_ColorToCheck)
        {
            bool isExists = false;
            for(int i = 0; i < 4; i++)
            {
                if (!(r_buttonsOfGameplay[m_CurrentTurn, i].BackColor != i_ColorToCheck))
                {
                    isExists = true;
                }
            }
            return isExists;
        }

        // $G$ CSS-006 (0) Missing blank line, after "if / else" blocks
        public void FillPickedColorArray()
        {
            for(int i = 0; i < 4; i++)
            {
                if (r_colorOfPicked[i] == null)
                {
                    r_colorOfPicked[i] = new Color();
                }
                r_colorOfPicked[i] = r_buttonsOfGameplay[m_CurrentTurn, i].BackColor;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            
            CurrentButton = (Button)sender;
            r_selectingColor.ShowDialog();
            if (!isRowClicked())
            {
                FillPickedColorArray();
                
            }
            else
            {
                r_getFeedBackButton[m_CurrentTurn].Enabled = true;
                r_selectingColor.EnableButtons();
            }
            
        }

        
    }
}
