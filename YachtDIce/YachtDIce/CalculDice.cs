using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtDIce
{
    class CalculDice
    {
        private int[] calindexvalue = new int[12];
        private bool[] checkvaluebutton =
            {true, true, true, true, true, true, true, true, true, true, true, true, true };
        public bool[] TurnCheckValue
        {
            get
            {
                return checkvaluebutton;
            }
        }
        public int[] TurnValue
        {
            get
            {
                return calindexvalue;
            }
        }

        public bool Turn_Checked(int index)
        {
            return checkvaluebutton[index];
        }
        public void Check_sum_false(int index)
        {
            checkvaluebutton[index] = false;
        }
        public void CulCollection(int[] dice)
        {
            int now_sum = 0;
            int sum = 0;
            if (dice[0] == -1)
            {
                for (int i = 0; i < 12; i++)
                {
                    calindexvalue[i] = 0;
                }
                return;
            }

            for (int i = 0; i < 5; i++)
            {
                if (dice[i] == 0)
                    sum += 1;
            }
            calindexvalue[0] = sum;
            sum = 0;
            for (int i = 0; i < 5; i++)
            {
                if (dice[i] == 1)
                    sum += 2;
            }
            calindexvalue[1] = sum;
            sum = 0;
            for (int i = 0; i < 5; i++)
            {
                if (dice[i] == 2)
                    sum += 3;
            }
            calindexvalue[2] = sum;
            sum = 0;
            for (int i = 0; i < 5; i++)
            {
                if (dice[i] == 3)
                    sum += 4;
            }
            calindexvalue[3] = sum;
            sum = 0;
            for (int i = 0; i < 5; i++)
            {
                if (dice[i] == 4)
                    sum += 5;
            }
            calindexvalue[4] = sum;
            sum = 0;
            for (int i = 0; i < 5; i++)
            {
                if (dice[i] == 5)
                    sum += 6;
            }
            calindexvalue[5] = sum;
            sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum += dice[i] + 1; //choice
            }
            calindexvalue[6] = sum;
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
                calindexvalue[7] = now_sum;
            else calindexvalue[7] = 0;
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
                calindexvalue[8] = now_sum;
            else calindexvalue[8] = 0;
            check = false;
            if (dice_num[0] > 0 && dice_num[1] > 0 && dice_num[2] > 0 && dice_num[3] > 0) //SS
                check = true;
            if (dice_num[1] > 0 && dice_num[2] > 0 && dice_num[3] > 0 && dice_num[4] > 0)
                check = true;
            if (dice_num[2] > 0 && dice_num[3] > 0 && dice_num[4] > 0 && dice_num[5] > 0)
                check = true;
            if (check)
                calindexvalue[9] = 15;
            else calindexvalue[9] = 0;
            check = false; //LS
            if (dice_num[0] > 0 && dice_num[1] > 0 && dice_num[2] > 0 && dice_num[3] > 0 && dice_num[4] > 0)
                check = true;
            if (dice_num[1] > 0 && dice_num[2] > 0 && dice_num[3] > 0 && dice_num[4] > 0 && dice_num[5] > 0)
                check = true;
            if (check)
                calindexvalue[10] = 30;
            else calindexvalue[10] = 0;
            check = false;
            for (int i = 0; i < 6; i++)
            {
                if (dice_num[i] > 4) //Yacht
                    check = true;
            }
            if (check)
                calindexvalue[11] = 50;
            else calindexvalue[11] = 0;
        }
    }
}
