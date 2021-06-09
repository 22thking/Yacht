using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtDIce
{
    class DiceInfo
    {
        private int[] dIce = { 0, 0, 0, 0, 0 };
        private bool[] checkdice = { true,true,true,true,true };
        public int[] Dice
        {
            get
            {
                return dIce;
            }
            set
            {
                dIce = value;
            }
        }
        public bool[] CheckDice
        {
            get
            {
                return checkdice;
            }
        }

        public void RollingDice()
        {
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                if(checkdice[i])
                  dIce[i] = random.Next(0, 6);
            }
        }
        public void TurnCheckDice(int index)
        {
            if (checkdice[index])
                checkdice[index] = false;
            else checkdice[index] = true;
        }

        public void ResetDice()
        {
            for (int i = 0; i < 5; i++)
            {
                checkdice[i] = true;
                Dice[i] = -1;
            }
        }
    }
}
