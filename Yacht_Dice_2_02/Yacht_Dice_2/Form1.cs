using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yacht_Dice_2
{
    public partial class Form1 : MetroFramework.Forms.MetroForm //상속 클래스 변경
    {
        //일단 전송해야 하는 값은 form에서 real_dice.turn_dice, real_dice.turn_check_dice, Get_sumbutton_value(),
        //private int categories_sum = 0;
        //private int result_sum = 0; 이거까지 전송을 해야함 
        //받는 거는 Counter_information에서 get으로 받으면 가능 
        //Change_image(int[] counter_dice)이거로 다이스
        //Counter_Change_dice_checked(bool[] counter_check_dice) 이놈은 홀드
        //이놈은 나머지private void Counter_sum_change(int[] get,int bonus,int result) 동작할겨
        //현재는 턴을 못 넘길거야 내일 자고 일어나서 함 맞추자 
        Label[] opponent_sum = new Label[12];
        Random random = new Random();
        PictureBox[] Dice_images=new PictureBox[5];
        PictureBox[] hold_dice_image = new PictureBox[5];
        Button[] sum_buttons = new Button[12];
        Button[] hold_buttons = new Button[5];
        Dice real_dice = new Dice();
        Dice_Work work_dice = new Dice_Work();
        Dice_Sum sum_dice = new Dice_Sum();
        Checked_Sum checked_sum = new Checked_Sum();
        Counter_information counter_information = new Counter_information();
        private int categories_sum = 0;
        private int result_sum = 0;
        private int rolling_dice_num = 3;
        private int game_turn = 1;
        private bool host=true;
        private bool end_turn;
        private bool my_turn;
        private bool button_enable = false;
        private string[] dice_image =
        {
            @"C:\Users\김희권\source\repos\Yacht_Dice_2\Yacht_Dice_2\Resources\one.png",
            @"C:\Users\김희권\source\repos\Yacht_Dice_2\Yacht_Dice_2\Resources\two.png",
            @"C:\Users\김희권\source\repos\Yacht_Dice_2\Yacht_Dice_2\Resources\three.png",
            @"C:\Users\김희권\source\repos\Yacht_Dice_2\Yacht_Dice_2\Resources\four.png",
            @"C:\Users\김희권\source\repos\Yacht_Dice_2\Yacht_Dice_2\Resources\five.png",
            @"C:\Users\김희권\source\repos\Yacht_Dice_2\Yacht_Dice_2\Resources\six.png"
        };
        public Form1()
        {
            InitializeComponent();
        } 
        private void Form1_Load(object sender, EventArgs e)
        {
            if (host)
            {
                while (true)
                {
                    int my_ran_value = random.Next();
                    int counter_ran_value = random.Next();
                    if (my_ran_value > counter_ran_value)
                    {
                        my_turn = true;
                        // 방에 들어온 사람에게는 false 보내기
                        break;
                    }
                    else
                    {
                        my_turn = false;
                        // 방에 들어온 사람에게는 false 보내기
                        break;
                    }
                }
            }
            else
            {
                //호스트가 아닐 경우 my_turn을 받기
            }
            if (my_turn)
            {
                turn_t.Text = "<-";
                end_turn = false;
            }else
            {
                turn_t.Text = "->";
                end_turn = true;
            }
            dice_rolling_num.Text = rolling_dice_num + "번";
            turn_num.Text = game_turn + " / 12";
            opponent_sum[0] = opponent_sum1;
            opponent_sum[1] = opponent_sum2;
            opponent_sum[2] = opponent_sum3;
            opponent_sum[3] = opponent_sum4;
            opponent_sum[4] = opponent_sum5;
            opponent_sum[5] = opponent_sum6;
            opponent_sum[6] = opponent_sum7;
            opponent_sum[7] = opponent_sum8;
            opponent_sum[8] = opponent_sum9;
            opponent_sum[9] = opponent_sum10;
            opponent_sum[10] = opponent_sum11;
            opponent_sum[11] = opponent_sum12;
            Dice_images[0] = Dice1;
            Dice_images[1] = Dice2;
            Dice_images[2] = Dice3;
            Dice_images[3] = Dice4;
            Dice_images[4] = Dice5;
            hold_dice_image[0] = hold_dice1;
            hold_dice_image[1] = hold_dice2;
            hold_dice_image[2] = hold_dice3;
            hold_dice_image[3] = hold_dice4;
            hold_dice_image[4] = hold_dice5;
            sum_buttons[0] = sum1;
            sum_buttons[1] = sum2;
            sum_buttons[2] = sum3;
            sum_buttons[3] = sum4;
            sum_buttons[4] = sum5;
            sum_buttons[5] = sum6;
            sum_buttons[6] = sum7;
            sum_buttons[7] = sum8;
            sum_buttons[8] = sum9;
            sum_buttons[9] = sum10;
            sum_buttons[10] = sum11;
            sum_buttons[11] = sum12;
            hold_buttons[0] = hold1;
            hold_buttons[1] = hold2;
            hold_buttons[2] = hold3;
            hold_buttons[3] = hold4;
            hold_buttons[4] = hold5;
            Reset_Dice_image();
        }
        private void Turn_image_change()
        {
            if (my_turn)
            {
                turn_t.Text = "<-";
            }
            else
            {
                turn_t.Text = "->";
            }
        }
        private void Rollong_Click(object sender, EventArgs e)
        {
            if (!my_turn)
                return;            
            if (rolling_dice_num <1)
                return;
            if (!button_enable)
                button_enable = true;
            rolling_dice_num--;
            dice_rolling_num.Text = rolling_dice_num + "번";
            work_dice.turn_check_dice = real_dice.turn_check_dice;
            work_dice.Rolling_dice();
            real_dice.turn_dice = work_dice.turn_dice;
            Change_image(counter_information.getset_dice);
            Change_sum_text();
        }
        private int[] Get_sumbutton_value()
        {
            int[] get = new int[12];
            for (int i = 0; i < 12; i++)
            {
                get[i] = int.Parse(sum_buttons[i].Text);
            }
            return get;
        }
        private void Change_image(int[] counter_dice)
        {
            if (my_turn)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (!real_dice.Return_dice_checked(i))
                        continue;
                    int value = real_dice.Return_dice_value(i);
                    Dice_images[i].Load(dice_image[value]);
                    Dice_images[i].SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }else
            {
                for (int i = 0; i < 5; i++)
                {
                    Dice_images[i].Load(dice_image[counter_dice[i]]);
                    Dice_images[i].SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }  
        }
        private void Change_hold_dice_image(bool get,int index)
        {
            if (!get)
            {
                hold_dice_image[index].Image = null;
            } else
            {
                int value = real_dice.Return_dice_value(index);
                hold_dice_image[index].Load(dice_image[value]);
                hold_dice_image[index].SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void Change_dice_image(bool get, int index)
        {
            if (!get)
            {
                int value = real_dice.Return_dice_value(index);
                Dice_images[index].Load(dice_image[value]);
                Dice_images[index].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                Dice_images[index].Image = null;
            }
        }
        private void Counter_Change_dice_checked(bool[] counter_check_dice) //이놈은 hold버튼 누를 때 마다 호출
        {
            for (int i = 0; i < 5; i++)
            {
                Change_hold_dice_image(counter_check_dice[i], i);
                Change_dice_image(counter_check_dice[i], i);
            }
        }
        private void Counter_sum_change(int[] get,int bonus,int result)//이놈은 점수 체크했을 시 오름
        {
            for (int i = 0; i < 12; i++)
            {
                opponent_sum[i].Text = get[i].ToString();
            }
            Counter_bonus_score.Text = bonus.ToString();
            if (Counter_bonus_label.BackColor != Color.Aqua && bonus >= 65)
                Counter_bonus_label.BackColor = Color.Aqua;
            Counter_result_score.Text = result.ToString();
            if (!end_turn)
            {
                game_turn++;
            }
            my_turn = true;
            Turn_image_change();
        }
        private void Change_sum_text()
        {            
            int[] get = sum_dice.sum_Collection(real_dice.turn_dice);
            bool[] check_sum = sum_dice.turn_check_sum;
            for (int i = 0; i < 12; i++)
            {
                if (check_sum[i])
                {
                    sum_buttons[i].Text = get[i].ToString();
                    sum_buttons[i].ForeColor = Color.DimGray;
                }                
            }
        }
        private void Reset_Dice_image()
        {
            for (int i = 0; i < 5; i++)
            {
                Dice_images[i].Load(@"C:\Users\김희권\source\repos\Yacht_Dice_2\Yacht_Dice_2\Resources\empty.png");
                Dice_images[i].SizeMode = PictureBoxSizeMode.StretchImage;
                hold_dice_image[i].Image = null;
            }
        }
        private void Change_hold(int index)
        {
            bool get = real_dice.Return_dice_checked(index);
            if (get)
            {
                hold_buttons[index].ForeColor = Color.Black;
            }
               
            else hold_buttons[index].ForeColor = Color.Red;
        }
        private void hold1_Click(object sender, EventArgs e)
        {
            if (!my_turn)
                return;
            if (!button_enable)
                return;
            Button now_click_button = (Button)sender;
            int index = int.Parse(now_click_button.Tag.ToString());
            bool get = real_dice.Return_dice_checked(index);           
            if (get)
            {
                real_dice.Dice_turn_false(index);
            }
            else
            {
                real_dice.Dice_turn_true(index);
            }
            Change_hold_dice_image(get, index);
            Change_dice_image(get, index);
            Change_hold(index);
        }
        
        private void sum_change_text()
        {
            rolling_dice_num = 3;
            dice_rolling_num.Text = rolling_dice_num + "번";
            if (end_turn)
            {
                game_turn++;
            }
            my_turn = false;
            Turn_image_change();
            turn_num.Text = game_turn + " / 12";
            int[] copy_sum = Get_sumbutton_value();
            categories_sum = checked_sum.Checked_Sum_Categories(copy_sum);
            if (checked_sum.get_categories_checked) 
            {
                bonus_label.BackColor = Color.Aqua; 
            }
            button_enable = false;
            sum_categories.Text = "" + categories_sum;
            result_sum = checked_sum.Checked_Sum_Result(copy_sum);
            score.Text = "score : " + result_sum;
        }
        private void sum1_Click(object sender, EventArgs e)
        {
            if (!my_turn)
                return;
            if (!button_enable)
                return;
            Button now_click_button = (Button)sender;
            int index=int.Parse(now_click_button.Tag.ToString());
            bool get=sum_dice.Turn_Checked(index);
            if (!get)
                return;
            sum_dice.Check_sum_false(index);
            now_click_button.ForeColor = Color.Red;
            work_dice.Reset_dice();
            real_dice.turn_check_dice = work_dice.turn_check_dice;
            for (int i = 0; i < 5; i++)
            {
                Change_hold(i);
            }   
            Reset_Dice_image();
            Change_sum_text();
            sum_change_text();
        }
    }
}
