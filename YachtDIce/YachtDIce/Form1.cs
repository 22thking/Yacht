using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using ObserverPattern;

namespace YachtDIce
{
    public partial class Form1 : Form,ISubject
    {
        Counterform counterform = null;
        Diceplay diceplay = null;
        Myscore myscore = null;
        IList _observers = new ArrayList();
        DiceInfo diceinfo = new DiceInfo();
        GameData gamedata = new GameData();
        public Form1()
        {
            InitializeComponent();
            myscore = new Myscore(this);
            myscore.TopLevel = false;
            myscore.FormBorderStyle = FormBorderStyle.None;
            myscore.Dock = DockStyle.Fill;
            MyPanel.Controls.Add(myscore);
            myscore.Show();
            myscore.SendData += EventFromMyscoreForm;

            counterform = new Counterform();
            counterform.TopLevel = false;
            counterform.FormBorderStyle = FormBorderStyle.None;
            counterform.Dock = DockStyle.Fill;
            CounterPanel.Controls.Add(counterform);
            counterform.Show();
            counterform.SendData += EventFromCounterForm;

            diceplay = new Diceplay(this);
            diceplay.TopLevel = false;
            diceplay.FormBorderStyle = FormBorderStyle.None;
            diceplay.Dock = DockStyle.Fill;
            DicePanel.Controls.Add(diceplay);
            diceplay.Show();
            diceplay.SendData += EventFromDiceForm;
        }
        public void registerObserver(IObserver o)
        {
            _observers.Add(o);
        }
        public void notifyObservers()
        {
            foreach (IObserver o in _observers)
                o.DiceUpdate(diceinfo.Dice,diceinfo.CheckDice,gamedata.myturn);
        }
        private void Rolling_Click(object sender, EventArgs e)
        {
            if (gamedata.rollingnum < 1)
                return;
            diceinfo.RollingDice();
            notifyObservers();
            gamedata.rollingnum--;
            RollingNumLabel.Text = gamedata.rollingnum.ToString();
        }
        private void GetServerData() //상대방이 Rolling 눌렀을 때
        {
            //diceinfo.Dice = GetServer
            notifyObservers();
            gamedata.rollingnum--;
            RollingNumLabel.Text = gamedata.rollingnum.ToString();
        }
        public void EventFromDiceForm(int index)
        {
            diceinfo.TurnCheckDice(index);
        }
        private void EndYachtGame()
        {
            if (gamedata.CounterScore < gamedata.MyScore)
            {
                //호스트 승리
            }else
            {
                //클라이언트 승리
            }
        }
        public void EventFromMyscoreForm(int value)
        {
            gamedata.rollingnum = 3;
            RollingNumLabel.Text = gamedata.rollingnum.ToString();
            diceinfo.ResetDice();
            diceplay.DiceUpdate(diceinfo.Dice, diceinfo.CheckDice, gamedata.myturn);
            gamedata.MyScore = value;
            //gamedata.myturn = false;
            if (gamedata.host)
                gamedata.turn++;
            if (gamedata.turn > 12)
                EndYachtGame();
            TurnLabel.Text = gamedata.turn.ToString();
            
        }
        public void EventFromCounterForm(int value)
        {
            gamedata.rollingnum = 3;
            RollingNumLabel.Text = gamedata.rollingnum.ToString();
            diceinfo.ResetDice();
            diceplay.DiceUpdate(diceinfo.Dice, diceinfo.CheckDice, gamedata.myturn);
            gamedata.myturn = true;
            gamedata.CounterScore = value;
            if (!gamedata.host)
                gamedata.turn++;
            if (gamedata.turn > 12)
                EndYachtGame();
            TurnLabel.Text = gamedata.turn.ToString();
        }
    }
}
