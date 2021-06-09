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
    public partial class Diceplay :Form,IObserver
    {
        PictureBox[] HoldPicture = new PictureBox[5];
        PictureBox[] DicePicture = new PictureBox[5];
        ISubject _subject;
        public delegate void ChildDiceSendData(int index); //부모 클래스에게 신호를 보내기 위함
        public event ChildDiceSendData SendData;
        bool copymyturn;
        bool possiblepush = false;
        public Diceplay(ISubject subject)
        {
            _subject = subject;
            subject.registerObserver(this);
            InitializeComponent();
            HoldPicture[0] = HPic1;
            HoldPicture[1] = HPic2;
            HoldPicture[2] = HPic3;
            HoldPicture[3] = HPic4;
            HoldPicture[4] = HPic5;
            DicePicture[0] = pDice1;
            DicePicture[1] = pDice2;
            DicePicture[2] = pDice3;
            DicePicture[3] = pDice4;
            DicePicture[4] = pDice5;
        }
        private string[] dice_image =
        {
            @"C:\Users\김희권\source\repos\YachtDIce\YachtDIce\Resources\one.png",
            @"C:\Users\김희권\source\repos\YachtDIce\YachtDIce\Resources\two.png",
            @"C:\Users\김희권\source\repos\YachtDIce\YachtDIce\Resources\three.png",
            @"C:\Users\김희권\source\repos\YachtDIce\YachtDIce\Resources\four.png",
            @"C:\Users\김희권\source\repos\YachtDIce\YachtDIce\Resources\five.png",
            @"C:\Users\김희권\source\repos\YachtDIce\YachtDIce\Resources\six.png"
        };
        public Diceplay()
        {
            InitializeComponent();
        }
        private void ResetDicePicture()
        {
            for (int i = 0; i < 5; i++)
            {
                HoldPicture[i].Image = null;
                DicePicture[i].Image = null;
                DicePicture[i].Load(@"C:\Users\김희권\source\repos\YachtDIce\YachtDIce\Resources\empty.png");
                DicePicture[i].SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void ChangePicture(int[] dice, bool[] check) //update 신호를 받으면 그 신호에 맞게 주사위 변함
        {
            for (int i = 0; i < 5; i++)
            {
                if (check[i])
                {
                    DicePicture[i].Load(dice_image[dice[i]]);
                    DicePicture[i].SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
        private void MovingImage(int index)  //hold에 따라서 사진 위치를 바꿈
        {
            if (!(DicePicture[index].Image == null))
            {
                HoldPicture[index].Image = DicePicture[index].Image;
                HoldPicture[index].SizeMode = PictureBoxSizeMode.StretchImage;
                DicePicture[index].Image = null;
            }else
            {
                DicePicture[index].Image = HoldPicture[index].Image;
                DicePicture[index].SizeMode = PictureBoxSizeMode.StretchImage;
                HoldPicture[index].Image = null;
            }
        }
        public void DiceUpdate(int[] dice, bool[] check,bool myturn) //옵저버 패턴으로 update() signal 받기
        {
            copymyturn = myturn;
            possiblepush = true;
            if (dice[0] == -1)
            {
                ResetDicePicture();
                possiblepush = false;
                return;
            }
            ChangePicture(dice, check);
        }
        private void Hold_Click(object sender, EventArgs e)
        {
            if (!copymyturn)
                return;
            if (!possiblepush)
                return;
            Button now_click_button = (Button)sender; //배열 index값을 받기 위해 버튼 Tag에 index값 있음
            int index = int.Parse(now_click_button.Tag.ToString());
            MovingImage(index);
            this.SendData(index); //부모클래스에게 이벤트 발생 및 정보 보내기
        }
    }
}
