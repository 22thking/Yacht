using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObserverPattern;

namespace YachtDIce
{
    public partial class Myscore : Form, IObserver
    {
        Button[] calbutton = new Button[12];
        ISubject _subject;
        CalculDice calculdice = new CalculDice();
        CheckCul checkc = new CheckCul();
        public delegate void ChildDiceSendData(int value); //부모 클래스에게 신호를 보내기 위함
        public event ChildDiceSendData SendData;
        bool copymyturn;
        bool possiblepush = false;
        public Myscore(ISubject subject)
        {
            _subject = subject;
            subject.registerObserver(this);
            InitializeComponent();
            calbutton[0] = Cal1;
            calbutton[1] = Cal2;
            calbutton[2] = Cal3;
            calbutton[3] = Cal4;
            calbutton[4] = Cal5;
            calbutton[5] = Cal6;
            calbutton[6] = Cal7;
            calbutton[7] = Cal8;
            calbutton[8] = Cal9;
            calbutton[9] = Cal10;
            calbutton[10] = Cal11;
            calbutton[11] = Cal12;
        }
        public Myscore()
        {
            InitializeComponent();
        }
        public void DiceUpdate(int[] dice,bool[] check,bool myturn)
        {
            copymyturn = myturn;
            if (myturn)
            {
                possiblepush = true;
                calculdice.CulCollection(dice);
                ChangeText();
            }
        }
        private int[] TurnText()
        {
            int[] copy = new int[12];
            for (int i = 0; i < 12; i++)
            {
                copy[i] = int.Parse(calbutton[i].Text);
            }
            return copy;
        }
        private void ResetText()
        {
            for (int i = 0; i < 12; i++)
            {
                if (calculdice.Turn_Checked(i))
                    calbutton[i].Text = "" + 0;
            }
        }
        private void ChangeText()
        {
            int[] copycul = calculdice.TurnValue;
            for (int i = 0; i < 12; i++)
            {
                if (calculdice.Turn_Checked(i))
                {
                    calbutton[i].Text = copycul[i].ToString();
                    calbutton[i].ForeColor = Color.DimGray;
                }
            }
        }
        private void ScoreButton_Click(object sender, EventArgs e)
        {
            if (!copymyturn)
                return;
            if (!possiblepush)
                return;
            possiblepush = false;
            Button now_click_button = (Button)sender; //배열 index값을 받기 위해 버튼 Tag에 index값 있음
            int index = int.Parse(now_click_button.Tag.ToString());
            if (!calculdice.Turn_Checked(index))
                return;
            calculdice.Check_sum_false(index);
            calbutton[index].ForeColor = Color.Red;
            ResetText();
            checkc.Checked_Sum_Categories(TurnText());
            checkc.Checked_Sum_Result(TurnText());
            if (checkc.get_categories_checked&& BonusLabel.BackColor != Color.Aqua)
            {
                BonusLabel.BackColor = Color.Aqua;
                BonusLabel.Text += " + 35";
            }
                
            BonusScore.Text = checkc.categoriesscore.ToString();
            ResultScore.Text = checkc.resultscore.ToString();
            this.SendData(checkc.resultscore);
        }
    }
}
