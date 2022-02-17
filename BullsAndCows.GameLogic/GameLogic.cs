using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Logic
{
    public class GameLogic
    {
        public Color[] r_PlayerAnswerList;
        public Color[] r_ComputerColorList;

        public List<Color> r_ListOfColors;
        private Random m_Random = new Random();

        public GameLogic(int i_AmountOfTurns)
        {
            r_PlayerAnswerList = new Color[4];
            r_ComputerColorList = new Color[4];
            this.r_ListOfColors = new List<Color>(8)
            {
                Color.Red,
                Color.Green,
                Color.Yellow,
                Color.Blue,
                Color.White,
                Color.Brown,
                Color.Purple,
                Color.LightBlue,
            };
        }

        public GameLogic()
        {
        }

        public Color RandomColor()
        {
            return r_ListOfColors[m_Random.Next(0, r_ListOfColors.Count)];
        }

        public Color[] PlayerAnswerList
        {
            get
            {
                return r_PlayerAnswerList;
            }
        }

        public Color[] ComputerColorList
        {
            get
            {
                return r_ComputerColorList;
            }
        }

        public bool CheckingAnswer(Color i_PlayerChar, Color i_ComputerChar)
        {
            bool isAnswerIsTrue = true;
            for(int i = 0; i < 4; i++)
            {
                if (i_PlayerChar != i_ComputerChar)
                {
                    isAnswerIsTrue = false;
                }
            }

            return isAnswerIsTrue;
        }

        public bool PlayerColorCheckInComputerColors(Color i_PlayerChar, Color[] i_ComputerCharArr)
        {
            bool isPlayersCharIsValid = false;

            for(int i = 0; i < 4; i++)
            {
                if (i_PlayerChar == i_ComputerCharArr[i] )
                {
                    isPlayersCharIsValid = true;
                    break;
                }
            }

            return isPlayersCharIsValid;
        }
    }
}