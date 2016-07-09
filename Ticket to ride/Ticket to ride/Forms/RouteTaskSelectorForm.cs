using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Forms
{
    public partial class RouteTaskSelectorForm : Form
    {
        public List<RouteCard> SelectedRouteCards;
        private readonly RouteCard _routeFour;
        private readonly RouteCard _routeOne;
        private readonly RouteCard _routeTwo;
        private readonly RouteCard _routeThree;
        private readonly RouteCardSelectorState RouteCardSelectorState;

        public RouteTaskSelectorForm(RouteCard routeOne, RouteCard routeTwo, RouteCard routeThree, RouteCard routeFour, bool routeOneRequired, RouteCardSelectorState routeCardSelectorState)
        {
            SelectedRouteCards = new List<RouteCard>();
            RouteCardSelectorState = routeCardSelectorState;

            if (RouteCardSelectorState == RouteCardSelectorState.InitialPickup)
            {
                //todo fix size and reposition button
                Width = 579;
            }


            _routeOne = routeOne;
            _routeTwo = routeTwo;
            _routeThree = routeThree;
            _routeFour = routeFour;


            string routeOneText = routeOne.GetStartLocation().Identifier + " to " + routeOne.GetEndLocation().Identifier;
            string routeTwoText = routeTwo.GetStartLocation().Identifier + " to " + routeTwo.GetEndLocation().Identifier;
            string routeThreeText = routeThree.GetStartLocation().Identifier + " to " + routeThree.GetEndLocation().Identifier;
            string routeFourText = "";
            if (RouteCardSelectorState == RouteCardSelectorState.InitialPickup)
            {
                routeFourText = routeFour.GetStartLocation().Identifier + " to " +
                                       routeFour.GetEndLocation().Identifier;
            }

            InitializeComponent();

            LblRouteOneRequired.Visible = RouteCardSelectorState == RouteCardSelectorState.InitialPickup;

            BtnRouteOne.Enabled = RouteCardSelectorState != RouteCardSelectorState.InitialPickup;

            LblRouteOne.Text = routeOneText;
            LblRouteTwo.Text = routeTwoText;
            LblRouteThree.Text = routeThreeText;
            LblRouteFour.Text = routeFourText;

        }

        private void RouteTaskSelector_Load(object sender, EventArgs e)
        {

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
                if (NumberOfRoutesSelected() < 2)
                {
                    MessageBox.Show("Please select at least 2 cards");
                }
                else
                {
                    AddSelectedCard();
                    Close();
                }

            
            //todo check if one is required



        }

        private void AddSelectedCard()
        {
            if (BtnRouteOne.Checked)
            {
                SelectedRouteCards.Add(_routeOne);
            }
            if (BtnRouteTwo.Checked)
            {
                SelectedRouteCards.Add(_routeTwo);
            }
            if (BtnRouteThree.Checked)
            {
                SelectedRouteCards.Add(_routeThree);
            }
            if (BtnRouteFour.Checked)
            {
                SelectedRouteCards.Add(_routeFour);
            }
        }

        private int NumberOfRoutesSelected()
        {
            int numberSelected =0 ;
            if (BtnRouteOne.Checked)
            {
                numberSelected++;
            }
            if (BtnRouteTwo.Checked)
            {
                numberSelected++;
            }
            if (BtnRouteThree.Checked)
            {
                numberSelected++;
            }
            if (BtnRouteFour.Checked)
            {
                numberSelected++;
            }
            return numberSelected;
        }



        private void BtnRouteOne_CheckedChanged(object sender, EventArgs e)
        {
         
        }
    }
}
