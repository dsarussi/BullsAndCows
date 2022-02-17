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
    public partial class AmountOfTurnsForm : Form
    {
        private int r_AmountOfTurns;
        public AmountOfTurnsForm()
        {
            
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            r_AmountOfTurns = 4;
            this.numOfTurn_btn.Text = "Number Of Chances: " + r_AmountOfTurns;
            this.Text = "bool Pgia";

        }

        private void AmountOfTurns_Click(object sender, EventArgs e)
        {

            r_AmountOfTurns++;
            this.numOfTurn_btn.Text = "Number Of Chances: " + r_AmountOfTurns;
            if (r_AmountOfTurns > 10)
            {
                r_AmountOfTurns = 4;
                this.numOfTurn_btn.Text = "Number Of Chances: " + r_AmountOfTurns;
            }


        }

        private void Start_Click(object sender, EventArgs e)
        {
            GameForm r_gameForm = new GameForm(r_AmountOfTurns);
            r_gameForm.RunApp();
            this.Close();
        }

       
    }
}
