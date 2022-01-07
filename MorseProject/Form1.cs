using System;
using System.Linq;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MorseProject
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 以下变量可以调节
        /// </summary>
        const int fps = 40;//T=1/fps
        double minThre = 0;//区分有无
        double daltaThre = 0;//选取的阈值.-阈值
        const int minLengthThre = ((int)(0.3 * fps));//一个字母的最短长度，对应0.3s
        const int maxLengthThre = ((int)(0.5 * fps));//一个字母的最长长度，对应1s
        /// <summary>
        /// 以下变量
        /// </summary>
        int i = 0;//循环变量
        int j = 0;//用于切分字符串以及当缓存过长时清除缓存数组
        int length = 0;//临时变量，数组长度
        Thread thread;//进程
        bool clear = false;//判定是否清除界面内的数字
        bool stop = false;//判定是否停止刷新
        double num = new double();//读取临时数字
        string str = string.Empty;//空字符串 显示用
        List<double> numList = new List<double>();//存储临时数据的数组
        /// <summary>
        /// 操作函数
        /// </summary>
        Action<string> actionDraw;//匿名操作函数
        Action<string> actionDraw1;//匿名操作函数
        Action<string> actionDraw2;//匿名操作函数
        SerialPort sp = new SerialPort();//端口
        string morseStr = string.Empty;//保存莫尔斯电码的字符串
        List<SerialPort> AvaPorts = MorseCode.GetSerialPorts();//可用的端口

        public Form1()
        {//初始化
            InitializeComponent();
        }

        /// <summary>
        /// 初始化窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            loadPort();
        }
        /// <summary>
        /// 加载端口
        /// </summary>
        private void loadPort()
        {
            labelPort.Text = "共检测到" + AvaPorts.Count.ToString() + "个串口";
            portsBox.Items.Clear();
            for (i = 0; i < AvaPorts.Count; i++)
                portsBox.Items.Add(AvaPorts[i].PortName);
            portsBox.SelectedIndex = 0;
        }
        /// <summary>
        /// 选择端口按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void portsChoose_Click(object sender, EventArgs e)
        {
            sp.PortName = portsBox.SelectedItem.ToString();
            stop = false;
            try
            {
                minThre = Convert.ToDouble(textBoxMin.Text);
                daltaThre = Convert.ToDouble(textBoxDelta.Text);
            }
            catch
            {
                minThre = 40;
                daltaThre = 48;
            }
            sp.Open();
            thread = new Thread(RunTime);//创建线程
            thread.Start();
            portsChoose.Enabled = false;
        }

        /// <summary>
        /// 停止按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            sp.Close();
            stop = true;
            portsChoose.Enabled = true;
            thread.Abort();//关闭线程
            loadPort();
        }
        /// <summary>
        /// 清除文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            clear = true;
        }
        /// <summary>
        /// 从指定的端口读取数字
        /// </summary>
        /// <returns></returns>
        private double read()
        {
            try
            {
                num = double.Parse(sp.ReadLine());
                numList.Add(num);
                if (labelTemp1.InvokeRequired)
                    this.labelTemp1.Invoke(actionDraw1, num.ToString());
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
            if (numList[0] >= minThre || numList[length - 1] >= minThre || numList.Max() < minThre)
            {
                j += 1;
                if (j > 70)
                {
                    numList = numList.Skip(35).Take(35).ToList();//取列表的后一半
                    str = " ";
                    if (morseDataLabel.InvokeRequired)
                        if (!morseDataLabel.Text.EndsWith(" "))
                            draw();
                    j = 0;
                }
                if (j > 35)
                {
                    str = MorseCode.Dec(morseStr);
                    morseStr = String.Empty;
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
                    this.labelTemp2.Invoke(actionDraw2, morseStr);
                numList.Clear();
            }
        }
        /// <summary>
        /// 清空
        /// </summary>
        private void clearLabel()
        {
            if (morseDataLabel.InvokeRequired)
                this.morseDataLabel.Invoke(actionDraw, "受到的信息为：");
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
                if (clear)
                    clearLabel();
            }
        }
    }
}