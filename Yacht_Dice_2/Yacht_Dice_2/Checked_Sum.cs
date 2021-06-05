using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yacht_Dice_2
{
    class Checked_Sum
    {
        private bool categories_checked = false;
        public bool get_categories_checked
        {
            get
            {
                return categories_checked;
            }
        }
        public int Checked_Sum_Categories(int[] sum_index_value)
        {
            int sum = 0;
            for (int i = 0; i < 6; i++)
            {                             
                sum += sum_index_value[i];
            }
            if (!categories_checked && sum >= 65)
                categories_checked = true;
            return sum;
        }
        public int Checked_Sum_Result(int[] sum_index_value)
        {
            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += sum_index_value[i];
            }
            if (categories_checked)
            {
                sum += 35;
            }
            return sum;
        }
    }
}
