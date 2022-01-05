using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace MorseProject
{
    public partial class Form1 : Form
    {
        const int fps = 40;//T=1/fps
        const int minThre = 65;//区分有无
        const int daltaThre = 85;//选取的阈值.-阈值
        const int minLengthThre = ((int)(0.3 * fps));//一个字母的最短长度，对应0.3s
        const int maxLengthThre = ((int)(0.5 * fps));//一个字母的最长长度，对应1s

        int i = 0;//循环变量
        int j = 0;//判断是否长时间卡住
        int length = 0;//临时变量，数组长度
        Thread thread;//进程
        bool stop = false;//判定是否停止刷新
        double num = new double();//读取临时数字
        string str = string.Empty;//空字符串 显示用

        Action<string> actionDraw;//匿名操作函数
        Action<string> actionDraw1;//匿名操作函数
        Action<string> actionDraw2;//匿名操作函数
        //Action<string> actionClear;//匿名操作函数
        SerialPort sp = new SerialPort();//端口
        string morseStr = string.Empty;//保存莫尔斯电码的字符串
        string bugTmpStr = string.Empty;//保存解码bug的字符串
        List<SerialPort> AvaPorts = MorseCode.GetSerialPorts();//可用的端口


        List<double> numList = new List<double>();//存储临时数据的数组

        public Form1()
        {//初始化
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {//初始化
            loadPort();
            //morseDataLabel.Text = MorseCode.Dec("");
        }
        private void loadPort()
        {//加载端口
            labelPort.Text = "共检测到" + AvaPorts.Count.ToString() + "个串口";
            portsBox.Items.Clear();
            for (i = 0; i < AvaPorts.Count; i++)
                portsBox.Items.Add(AvaPorts[i].PortName);
            portsBox.SelectedIndex = 0;
        }

        private void portsChoose_Click(object sender, EventArgs e)
        {//选择端口按键
            sp.PortName = portsBox.SelectedItem.ToString();
            sp.Open();
            thread = new Thread(RunTime);//创建线程
            thread.Start();
            portsChoose.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {//停止按键
            sp.Close();
            stop = true;
            portsChoose.Enabled = true;
            thread.Abort();//关闭线程
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            AvaPorts = MorseCode.GetSerialPorts();//可用的端口
            portsBox.Items.Clear();
            for (i = 0; i < AvaPorts.Count; i++)
                portsBox.Items.Add(AvaPorts[i].PortName);
            portsBox.SelectedIndex = 0;
        }
        /// <summary>
        /// 从指定的端口读取数字
        /// </summary>
        /// <returns></returns>
        private double read()
        {//从指定的端口读取数字
            try
            {
                num = double.Parse(sp.ReadLine());
                numList.Add(num);
                if (labelTemp1.InvokeRequired)
                {
                    //bugTmpStr = MorseCode.Dec(morseStr);
                    this.labelTemp1.Invoke(actionDraw1, num.ToString());
                }
                return num;
            }
            catch
            {
                numList.Add(minThre);
                return 0;
            }
        }
        /// <summary>
        /// 显示
        /// </summary>
        private void draw()
        {
            if (morseDataLabel.InvokeRequired)
                this.morseDataLabel.Invoke(actionDraw, morseDataLabel.Text + str);
        }

        /// <summary>
        /// 分析获得的数据
        /// </summary>
        public void analyse()
        {
            length = numList.Count;
            //if (length < minLengthThre) { return; }//如果长度过短，直接返回

            if (numList[0] >= minThre || numList[length - 1] >= minThre || numList.Max() < minThre)
            {
                j += 1;
                if (j > 40)
                {
                    numList = numList.Skip(10).Take(10).ToList();//取列表的后一半
                    morseStr = String.Empty;
                    j = 0;
                }
                if(j> 35)
                {
                    str = MorseCode.Dec(morseStr);
                    morseStr = string.Empty;
                    draw();
                }
            }
            else
            {
                j = 0;

                if (numList.Max() > daltaThre)
                    morseStr += '-';
                else
                    morseStr += '.';

                if (labelTemp2.InvokeRequired)
                {
                    this.labelTemp2.Invoke(actionDraw2, morseStr);
                }
                numList.Clear();
            }
        }
        /// <summary>
        /// 进程
        /// </summary>
        private void RunTime()
        {
            actionDraw = (str) => { this.morseDataLabel.Text = str; };
            actionDraw1 = (str) => { this.labelTemp1.Text = str; };
            actionDraw2 = (str) => { this.labelTemp2.Text = str; };
            while (true)
            {
                if (stop)
                    return;
                read();
                analyse();
                //draw();
            }
        }


    }
}
