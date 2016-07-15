using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Forms
{
    public partial class CardSelector : Form
    {
        public CardType Result { get; set; }

        public CardSelector(List<CardType> availableCards)
        {
            InitializeComponent();


            if (availableCards.Contains(CardType.Black))
            {
                btnBlack.Enabled = true;
            }
            if (availableCards.Contains(CardType.White))
            {
                btnWhite.Enabled = true;
            }
            if (availableCards.Contains(CardType.Orange))
            {
                btnOrange.Enabled = true;
            }
            if (availableCards.Contains(CardType.Pink))
            {
                btnPink.Enabled = true;
            }
            if (availableCards.Contains(CardType.Red))
            {
                btnRed.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //btnblack
            Result = CardType.Black;
            Close();
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            Result = CardType.White;
            Close();
        }

        private void btnOrange_Click(object sender, EventArgs e)
        {
            Result = CardType.Orange;
            Close();
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            Result = CardType.Red;
            Close();
        }

        private void btnPink_Click(object sender, EventArgs e)
        {
            Result = CardType.Pink;
            Close();
        }
    }
}
