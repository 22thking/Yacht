using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yacht_Dice_2
{
    class Dice_Sum
    {
        private int[] sum_index_value = new int[12];
        private bool[] check_sum_button =
            {true, true, true, true, true, true, true, true, true, true, true, true, true };
        public bool[] turn_check_sum
        {
            get
            {
                return check_sum_button;
            }
        }

        public bool Turn_Checked(int index)
        {
            return check_sum_button[index];
        }
        public void Check_sum_false(int index)
        {
            check_sum_button[index] = false;
        }
        public int[] sum_Collection(int[] dice)
        {
            int now_sum = 0;
            int sum = 0;
            if (dice[0] == -1)
            {
                for (int i = 0; i < 12; i++)
                {
                    sum_index_value[i] = 0;
                }
                return sum_index_value;
            }

            for (int i = 0; i < 5; i++)
            {
                if (dice[i] == 0)
                    sum += 1;
            }
            sum_index_value[0] = sum;
            sum = 0;
            for (int i = 0; i < 5; i++)
            {
                if (dice[i] == 1)
                    sum += 2;
            }
            sum_index_value[1] = sum;
            sum = 0;
            for (int i = 0; i < 5; i++)
            {
                if (dice[i] == 2)
                    sum += 3;
            }
            sum_index_value[2] = sum;
            sum = 0;
            for (int i = 0; i < 5; i++)
            {
                if (dice[i] == 3)
                    sum += 4;
            }
            sum_index_value[3] = sum;
            sum = 0;
            for (int i = 0; i < 5; i++)
            {
                if (dice[i] == 4)
                    sum += 5;
            }
            sum_index_value[4] = sum;
            sum = 0;
            for (int i = 0; i < 5; i++)
            {
                if (dice[i] == 5)
                    sum += 6;
            }
            sum_index_value[5] = sum;
            sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum += dice[i] + 1; //choice
            }
            sum_index_value[6] = sum;
            now_sum = sum;
            sum = 0;
            int[] dice_num = { 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (dice[i] == j)
                        dice_num[j]++;
                }
            }
            bool check = false;
            for (int i = 0; i < 6; i++)
            {
                if (dice_num[i] > 3) //four of a kind
                    check = true;
            }
            if (check)
                sum_index_value[7] = now_sum;
            else sum_index_value[7] = 0;
            check = false;
            bool check2 = false;
            for (int i = 0; i < 6; i++)
            {
                if (dice_num[i] > 2) //Full house
                    check = true;
                else if (dice_num[i] > 1)
                    check2 = true;
            }
            if (check && check2)
                sum_index_value[8] = now_sum;
            else sum_index_value[8] = 0;
            check = false;
            if (dice_num[0] > 0 && dice_num[1] > 0 && dice_num[2] > 0 && dice_num[3] > 0) //SS
                check = true;
            if (dice_num[1] > 0 && dice_num[2] > 0 && dice_num[3] > 0 && dice_num[4] > 0)
                check = true;
            if (dice_num[2] > 0 && dice_num[3] > 0 && dice_num[4] > 0 && dice_num[5] > 0)
                check = true;
            if (check)
                sum_index_value[9] = 15;
            else sum_index_value[9] = 0;
            check = false; //LS
            if (dice_num[0] > 0 && dice_num[1] > 0 && dice_num[2] > 0 && dice_num[3] > 0 && dice_num[4] > 0)
                check = true;
            if (dice_num[1] > 0 && dice_num[2] > 0 && dice_num[3] > 0 && dice_num[4] > 0 && dice_num[5] > 0)
                check = true;
            if (check)
                sum_index_value[10] = 30;
            else sum_index_value[10] = 0;
            check = false;
            for (int i = 0; i < 6; i++)
            {
                if (dice_num[i] > 4) //Yacht
                    check = true;
            }
            if (check)
                sum_index_value[11] = 50;
            else sum_index_value[11] = 0;
            return sum_index_value;
        }
    }
}
