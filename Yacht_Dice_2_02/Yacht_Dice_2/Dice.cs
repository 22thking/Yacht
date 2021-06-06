using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yacht_Dice_2
{
    class Dice
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

        public int Return_dice_value(int index)
        {
            return dice[index];
        }
        public bool Return_dice_checked(int index)
        {
            return check_dice[index];
        }
        public void Dice_turn_false(int index)
        {
            check_dice[index] = false;
        }
        public void Dice_turn_true(int index)
        {
            check_dice[index] = true;
        }
    }
}
