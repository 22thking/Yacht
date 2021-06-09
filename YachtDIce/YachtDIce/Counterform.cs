using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverPattern;
using System.Windows.Forms;

namespace YachtDIce
{
    public partial class Counterform : Form
    {
        Label[] CounterCul = new Label[12];
        CounterInfo data = new CounterInfo();
        public delegate void ChildDiceSendData(int value); //부모 클래스에게 신호를 보내기 위함
        public event ChildDiceSendData SendData;       
        public Counterform()
        {
            InitializeComponent();
            CounterCul[0] = counterCul1;
            CounterCul[1] = counterCul2;
            CounterCul[2] = counterCul3;
            CounterCul[3] = counterCul4;
            CounterCul[4] = counterCul5;
            CounterCul[5] = counterCul6;
            CounterCul[6] = counterCul7;
            CounterCul[7] = counterCul8;
            CounterCul[8] = counterCul9;
            CounterCul[9] = counterCul10;
            CounterCul[10] = counterCul11;
            CounterCul[11] = counterCul12;
        }
        public void ChangeText()
        {
            for (int i = 0; i < 12; i++)
            {
                CounterCul[i].Text = data.countercollection.ToString();
            }
            CateforisSum.Text = data.counterCateforiesScore.ToString();
            ResultSum.Text = data.counterResultScore.ToString();
        }
        public void GetServerData()
        {
            //data.countercollection = GetServer
            //data.counterResultScore= GetServer
            //data.counterCateforiesScore= GetServer
            ChangeText();
            SendData(data.counterResultScore); //델리게이트 사용하여 이벤트!
        }
    }
}
