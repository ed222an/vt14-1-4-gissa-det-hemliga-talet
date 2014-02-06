using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gissa_det_hemliga_talet.Model;

namespace Gissa_det_hemliga_talet
{
    public partial class Default : System.Web.UI.Page
    {

        // Sparar undan sessionsvariabeln med det SecretNumber-objektet.
        private SecretNumber SecretNumber
        {
            get { return Session["SecretNumber"] as SecretNumber; }
            set { Session["SecretNumber"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (SecretNumber.CanMakeGuess) // Så länge som CanMakeGuess returnerar true kan en gissning göras.
                {
                    // Tolkar det inmatade värdet till ett heltal.
                    SecretNumber.MakeGuess(int.Parse(InputTextBox.Text));

                    // Olika utskrifter ifall gissningen är för hög/låg/tidigare gissad.
                    if (SecretNumber.Outcome == Outcome.High)
                    {
                        StatusLabel.Text = String.Format("för högt!");
                    }
                    else if (SecretNumber.Outcome == Outcome.Low)
                    {
                        StatusLabel.Text = String.Format("för lågt!");
                    }
                    else if (SecretNumber.Outcome == Outcome.PreviousGuess)
                    {
                        StatusLabel.Text = String.Format("Du har redan gissat på detta talet!");
                    }
                    else // Utskrift för vinst.
                    {
                        EndLabel.Text = String.Format("Grattis! Du klarade det på {0} försök!", SecretNumber.Count);
                        EndLabel.Visible = true;

                        // Visar "Skapa nytt hemligt nummer"-knappen för nytt spel.
                        ResetButton.Visible = true;
                    }

                    // Loopar igenom listan med gissningar och skriver ut dem på rad.
                    foreach (int i in SecretNumber.PreviousGuesses)
                    {
                        GuessLabel.Text += String.Format("{0} ", i);
                    }

                    // Visar gissningarna etc.
                    GuessLabel.Visible = true;
                    InputTextBox.Enabled = true;
                    GuessButton.Visible = true;
                    ResetButton.Visible = false;
                }

                // Har användaren gissat 7 gånger visas förlorartexten.
                if (SecretNumber.Count == SecretNumber.MaxNumberOfGuesses)
                {
                    EndLabel.Text = String.Format("Du har inga gissningar kvar. Det hemliga talet var {0}.", SecretNumber.Number);
                    EndLabel.Visible = true;
                    InputTextBox.Enabled = false;
                    GuessButton.Enabled = false;
                    ResetButton.Visible = true;
                }
            }
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            // Skapar en ny instans av SecretNumber och sparar det i en sessionsvariabel.
            Session["SecretNumber"] = new SecretNumber();
            InputTextBox.Enabled = true;
            GuessButton.Visible = true;
            ResetButton.Visible = false;
        }
    }
}