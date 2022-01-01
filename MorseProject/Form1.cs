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
        const int minThre = 25;//区分有无
        const int daltaThre = 35;//选取的阈值.-阈值
        const int minLengthThre = 3;//一个字母的最短长度，对应0.3s
        const int maxLengthThre = 10;//一个字母的最长长度，对应1s

        int i = 0;//循环变量
        int j = 0;//判断是否长时间卡住
        int length = 0;//临时变量，数组长度
        Thread thread;//进程
        bool stop = false;//判定是否停止刷新
        double num = new double();//读取临时数字
        string str = string.Empty;//空字符串 显示用

        Action<string> actionDraw;//匿名操作函数
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
                return num;
            }
            catch
            {
                numList.Add(0);
                return 0;
            }
        }

        private void draw()
        {//将点划线画出来
            if (morseDataLabel.InvokeRequired)
            {
                //bugTmpStr = MorseCode.Dec(morseStr);
                this.morseDataLabel.Invoke(actionDraw,morseDataLabel.Text+str);
            }
        }
        private bool isIncrease(List<double> array, int len)
        {//判断数组是否单增
            if (len != 1)
                return (array[len - 2] <= array[len - 1]) && isIncrease(array, len - 1);
            else
                return true;
        }
        private bool isDecrease(List<double> array, int len)
        {//判断数组是否单减
            if (len != 1)
                return (array[len - 2] >= array[len - 1]) && isDecrease(array, len - 1);
            else
                return true;
        }
        /// <summary>
        /// 分析获得的数据
        /// </summary>
        private void analyse()
        {
            length = numList.Count;
            if (length < minLengthThre) return;//如果长度过短，直接返回

            for (i = 0; i < length; i++)
                if (numList[0] >= minThre || numList[length - 1] >= minThre || numList.Max() < minThre)
                {
                    j++;
                    if (j > 20)
                        break;
                    return;
                }
                else
                {
                    j = 0;
                }

            if (numList.Count > maxLengthThre)//认为分割两个字母
            {
                str = MorseCode.Dec(morseStr);
                morseStr = string.Empty;
                draw();
            }

            if (numList.Max() > daltaThre)
                morseStr += '-';
            else
                morseStr += '.';

            numList.Clear();
        }
        private void RunTime()
        {//进程
            actionDraw = (str) => { this.morseDataLabel.Text = str; };
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
