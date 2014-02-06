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
            get
            {
                // Returnerar true ifall användaren gissat färre gången än maxantalet.
                if (Count < MaxNumberOfGuesses)
                {
                    return true;
                }
                return false;
            }
        }

        public int Count
        {
            get
            {
                // Returnerar storleken på gissningslistan.
                return PreviousGuesses.Count();
            }
        }

        public int? Number
        {
            get
            {
                // Returnerar null ifall användningar har fler gissningar att göra.
                if (CanMakeGuess)
                {
                    return null;
                }
                return _number;
            }
        }

        public IEnumerable<int> PreviousGuesses
        {
            get
            {
                return _previousGuesses.AsReadOnly();
            }
        }

        public Outcome Outcome {get; set;}

        // Metoder
        public void Initialize()
        {
            // Skapar ett nytt random-objekt och ett hemligt nummer mellan 1-100.
            Random rnd = new Random();
            _number = rnd.Next(1, 101);

            // Skapar ny lista & tömmer eventuella existerande element.
            _previousGuesses = new List<int>(MaxNumberOfGuesses);
            _previousGuesses.Clear();
            Outcome = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess)
        {
            if (CanMakeGuess)
            {
                if (guess < 1 || guess > 100) // Kontrollerar så att gissningen är giltig.
                {
                    throw new ArgumentOutOfRangeException("Gissningen är inte i det slutna intervallet 1-100");
                }

                if (PreviousGuesses.Contains(guess)) // Gissningen på detta talet är redan gjord.
                {
                    Outcome = Outcome.PreviousGuess;
                }
                else
                {
                    if (guess < _number) // Gissningen är mindre än det hemliga talet.
                    {
                        Outcome = Outcome.Low;
                    }
                    else if (guess > _number) // Gissningen är större än det hemliga talet.
                    {
                        Outcome = Outcome.High;
                    }
                    else // Annars är gissningen lika med det hemliga talet.
                    {
                        Outcome = Outcome.Correct;
                    }

                    // Lägger till gissningen i listan med gissningar.
                    _previousGuesses.Add(guess);
                }
            }
            else
            {
                Outcome = Outcome.NoMoreGuesses;
            }

            return Outcome;
        }

        // Konstruktor
        public SecretNumber()
        {
            Initialize();
        }
    }
}