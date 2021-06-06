using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yacht_Dice_2
{
    class Counter_information
    {
        int[] dice = new int[5];
        public int[] getset_dice
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
        bool[] check_dice = new bool[5];
        public bool[] getset_check_dice
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
        int[] sum = new int[12];
        public int[] getset_sum
        {
            get
            {
                return sum;
            }
            set
            {
                sum = value;
            }
        }
        int categories_sum = 0;
        public int getset_categories_sum
        {
            get
            {
                return categories_sum;
            }
            set
            {
                categories_sum = value;
            }
        }
        int result_sum = 0;
        public int getset_result_sum
        {
            get
            {
                return result_sum;
            }
            set
            {
                result_sum = value;
            }
        }
    }
}
