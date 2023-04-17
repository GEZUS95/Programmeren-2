using System;
using System.Collections.Generic;
using System.Text;

namespace assignment3
{
    class YahtzeeGame
    {
        public Dice[] dices = new Dice[5];

        public void Init()
        {
            for (int i = 0; i < dices.Length; i++)
            {
                dices[i] = new Dice();
            }
        }

        public void Throw()
        {
            for (int i = 0; i < dices.Length; i++)
            {
                dices[i].Throw();
            }
        }

        public void DisplayValues()
        {
            for (int i = 0; i < dices.Length; i++)
            {
                dices[i].DisplayValue();
            }
            Console.WriteLine();
        }

        public bool Yahtzee()
        {
            return ((dices[0].value == dices[1].value) && (dices[0].value == dices[2].value) && (dices[0].value == dices[3].value) && (dices[0].value == dices[4].value));
        }
    }
}
