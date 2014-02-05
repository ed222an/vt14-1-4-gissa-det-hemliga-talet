using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gissa_det_hemliga_talet.Model
{
    public class SecretNumber
    {
        // Fält
        private int _number;
        private List<int> _previousGuesses;

        // Konstant
        public const int MaxNumberOfGuesses = 7;

        // Egenskaper
        public bool CanMakeGuess
        {
            get;
        }

        public int Count
        {
            get;
        }

        public int? Number
        {
            get
            {
                return _number;
            }
        }

        public IEnumerable<int> PreviousGuesses
        {
            get
            {
                return _previousGuesses;
            }
        }

        public Outcome Outcome
        {
            get;
            set;
        }

        // Metoder
        public void Initialize()
        {
            _previousGuesses.Clear();
            Outcome = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100) // Kontrollerar så att gissningen är giltig.
            {
                throw new ArgumentOutOfRangeException("Gissningen är inte i det slutna intervallet 1-100");
            }

            if (_previousGuesses.Contains(guess)) // Gissningen på detta talet är redan gjord.
            {
                Outcome = Outcome.PreviousGuess;
            }
            else if (guess < Number) // Gissningen är mindre än det hemliga talet.
            {
                Count += 1;
                Outcome = Outcome.Low;
            }
            else if (guess > Number) // Gissningen är större än det hemliga talet.
            {
                Count += 1;
                Outcome = Outcome.High;
            }
            else
            {
                Count += 1;
                Outcome = Outcome.Correct;
            }

            return Outcome;
        }

        // Konstruktor
        public SecretNumber()
        {
            Random rnd = new Random();
            _number = rnd.Next(1, 101);

            _previousGuesses = new List<int>(7);

            Initialize();

        }
    }
}