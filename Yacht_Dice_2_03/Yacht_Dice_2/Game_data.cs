using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yacht_Dice_2
{
    class Game_data
    {
        public int categories_sum = 0;
        public int result_sum = 0;
        public int rolling_dice_num = 3;
        private int game_turn = 1;
        public bool host = true;
        public bool end_turn;
        public bool my_turn;
        public bool button_enable = false;

        public void Game_turn_plus()
        {
            game_turn++;
        }
        public int Get_game_turn()
        {
            return game_turn;
        }

        public bool End_game()
        {
            if (game_turn > 12)
                return true;
            else return false;
        }
    }
}
