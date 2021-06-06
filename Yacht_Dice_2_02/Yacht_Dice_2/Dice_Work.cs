using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yacht_Dice_2
{
    class Dice_Work
    {
        private int[] dice = { -1, -1, -1, -1, -1 };
        private bool[] check_dice = { true, true, true, true, true };
        public int[] turn_dice
        {
            get
            {
                return dice;
            }
            set
            {
                dice = value;
            }
        }
        public bool[] turn_check_dice
        {
            get
            {
                return check_dice;
            }
            set
            {
                check_dice = value;
            }
        }
        public void Rolling_dice()
        {
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                if (check_dice[i])
                {
                    int roll_dice = random.Next(0, 6);
                    dice[i] = roll_dice;
                }
            }
        }
        public void Reset_dice()
        {
            for (int i = 0; i < 5; i++)
            {
                dice[i] = -1;
                check_dice[i] = true;
            }
        }
    }
}
