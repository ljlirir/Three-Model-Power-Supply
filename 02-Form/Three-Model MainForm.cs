using LBSoft.IndustrialCtrls.Meters;
using Sample_Project._02_Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace eTommensDC
{
    public partial class MainForm : Form
    {


   
        public MainForm()
        {
           
            InitializeComponent();
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged; // 绑定选项卡切换事件
            tabControl.Selecting += new TabControlCancelEventHandler(tabControl_Selecting);//绑定设备在当前界面运行时不能切换页面的操作
        }

        private static bool isOn = false; // 标记按钮状态
        public static string comSetXMLFileName = AppDomain.CurrentDomain.BaseDirectory + "setting\\ThreeModeWSComSet.XML";
        public static string appSetXMLFileName = AppDomain.CurrentDomain.BaseDirectory + "setting\\ThreeModeappSet.XML";
        public static List<ThreeModeControlThread> ThreeModBusComInfoList = new List<ThreeModeControlThread>();
         public static List<ThreeModeControlThread> ModBusSetList = ModBusComInfo.readWSComSetting(MainForm.comSetXMLFileName);
        public static DateTime appStartTime = DateTime.Now;
        private bool GLIThreadStop = false;
      
        private void MainForm_Load(object sender, EventArgs e)
        {
            PWT_textBox.Text = "";
            PWT_textBox.Clear();
            if (ModBusSetList.Count == 0)
            {
                if (MessageBox.Show("未设置设备及端口参数，是否设置", "设备参数", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    ComSetForm setComAndDeviceForm = new ComSetForm();
                    setComAndDeviceForm.ShowDialog();
                }
                else
                {
                    return;
                }

            }
            else
            {
                //(zhang)把所有配置读到链表
                foreach (ThreeModeControlThread indexModBusComInfo in ModBusSetList)
                {
                    //COMWSname_comboBox.Items.Add(indexModBusComInfo.WSname);
                }

            }


        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //if (tabControl1.SelectedTab == PW)
            //{
            //    MessageBox.Show("当前页面：电源模式\n请确认已保存相关信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else if (tabControl1.SelectedTab == CH)
            //{
            //    MessageBox.Show("当前页面：充电模式\n请确认已保存相关信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else if (tabControl1.SelectedTab == FU)
            //{
            //    MessageBox.Show("当前页面：保险丝熔断模式\n请确认已保存相关信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 获取当前选中的 TabPage 名称
            string selectedTabName = tabControl.SelectedTab.Text;

            // 根据 TabPage 名称启用或禁用 ToolStrip
            if (selectedTabName == "电源模式") // 假设目标 TabPage 名称为 tabPage2
            {
                toolStrip.Enabled = true; // 启用 ToolStrip
            }
            else
            {
                toolStrip.Enabled = false; // 禁用 ToolStrip
            }
            
        }
        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            string PWSwitchText = PWOutPut_button.Text;
            string CHSwitchText = CHOutPut_button.Text;
            string FUSwitchText = FUOutPut_button.Text;
            // 如果条件满足，则禁止切换选项卡
            if ((PWSwitchText == "ON") || (CHSwitchText == "ON") || (FUSwitchText == "ON"))
            {
                e.Cancel = true; // 禁止切换
                MessageBox.Show("无法切换选项卡，因为条件未满足！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }


        private void setSationReal(ThreeModeControlThread myLataColInfo)
        {
            if (this.InvokeRequired == false)
            {

                string dmFormat = "";
                int intVolueLen = ((int)myLataColInfo.rVoltage).ToString().Length;
                for (Int16 DecPoint = 0; DecPoint <= myLataColInfo.ShowBit; DecPoint++)
                {
                    if ((DecPoint == intVolueLen) && (DecPoint != myLataColInfo.ShowBit))
                    {
                        dmFormat = dmFormat + ".";

                    }
                    else
                    {
                        dmFormat = dmFormat + "0";
                    }
                    CHA_lbDigitalMeter.Text = dmFormat;
                    CHA_lbDigitalMeter.Value = myLataColInfo.rVoltage;
                }

            }


        }



        private void PWOVP_textBox_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void CHT_lbDigitalMeter_Load(object sender, EventArgs e)
        {

        }

        private void PWV_lbDigitalMeter_Load(object sender, EventArgs e)
        {

        }

        private void PW_Click(object sender, EventArgs e)
        {

        }
        private void CHmAh_lbDigitalMeter_Load(object sender, EventArgs e)
        {

        }

        private void CHA_lbDigitalMeter_Load(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DerivedSampleData_toolStripButton_Click(object sender, EventArgs e)
        {
            ExportCVSForm form= new ExportCVSForm();
            form.ShowDialog();
        }

        private void ConfigureDevive_toolStripButton_Click(object sender, EventArgs e)
        {
            ComSetForm form= new ComSetForm();
            form.ShowDialog();
        }
       
        private void PWOutPut_button_Click(object sender, EventArgs e)
        {
            isOn = !isOn; // 切换状态
            if (isOn)
            {
                PWOutPut_button.Text = "ON";
                PWOutPut_button.BackColor = System.Drawing.Color.Green; // 打开时绿色
            }
            else
            {
                PWOutPut_button.Text = "OFF";
                PWOutPut_button.BackColor = System.Drawing.Color.Red; // 关闭时红色
            }
        }

        private void CHOutPut_button_Click(object sender, EventArgs e)
        {
            isOn = !isOn; // 切换状态
            if (isOn)
            {
                CHOutPut_button.Text = "ON";
                CHOutPut_button.BackColor = System.Drawing.Color.Green; // 打开时绿色
            }
            else
            {
                CHOutPut_button.Text = "OFF";
                CHOutPut_button.BackColor = System.Drawing.Color.Red; // 关闭时红色
            }
        }

        private void FUOutPut_button_Click(object sender, EventArgs e)
        {
            isOn = !isOn; // 切换状态
            if (isOn)
            {
                FUOutPut_button.Text = "ON";
                FUOutPut_button.BackColor = System.Drawing.Color.Green; // 打开时绿色
            }
            else
            {
                FUOutPut_button.Text = "OFF";
                FUOutPut_button.BackColor = System.Drawing.Color.Red; // 关闭时红色
            }
        }

        private void PWSetOvp_button_Click(object sender, EventArgs e)
        {

        }

        private void PWSetCurrent_button_Click(object sender, EventArgs e)
        {

        }
    }
}





