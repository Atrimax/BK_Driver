using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Ivi.Visa;
using NationalInstruments.Visa;
using Ivi.Visa.Interop;
using System.Runtime.InteropServices;

/*****************************  SCN20 ATE TEST STATION *****************************
 * BK 9130C Driver 
 * Written by Alexey Tseirif
 * 8/08/2022
 * Function list:
 *  1. Initialization             - bool BK_Init() 
 *  2. Setup OVP,                 - void Setup_OVP(int Channel, string Voltage)
 *  3. Output each channel On/Off - optional   
 *  4. Output all channels On/Off - void Turn_ONOFF(bool ON_OFF, int channels)
 *  5. Measure Voltage           - float Meas_Voltage(int Channel)
 *  6. Measure Current           - float Meas_Current(int Channel)
 *  7. Setup Voltage by channel  - void Setup_Voltage(int Channel, string Voltage)
 *  8. Setup Current by channel  - void Setup_Current(int Channel, string Current)
 *  9. Clear all registers       - void BK_Clear()
 *  10. Reset PS                 - void BK_Reset()
 *  
 *  
 * ********************************************************************************* 
*/
namespace BK_Driver
{
    public partial class BK_Main : Form
    {
        Ivi.Visa.Interop.ResourceManager rMgr = new ResourceManagerClass();//Create a resource manager
        FormattedIO488 src = new FormattedIO488Class();

        public string sendstring = string.Empty; // strings
        public string src_address = string.Empty;

        public BK_Main()
        {
            InitializeComponent();
            getAvailableResources();
            
        }
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmd_Open.Enabled = true;
            Cmd_Close.Enabled = true;
            src_address = comboBox1.SelectedItem.ToString();
        }
        public void getAvailableResources()//function that find the available USBTMC resources and populates combobox1
        {
            try
            {
                //USB VISA resources
                string[] resources = rMgr.FindRsrc("USB?*");
                comboBox1.Items.AddRange(resources);
            }
            catch (Exception)
            {
                txtRead.Text = "No Resources Available";

            }
        }
        private void Cmd_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Cmd_Open_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            txtSend.Enabled = true; 
            Cmd_Read.Enabled = true;
            txtRead.Enabled = true; 
            Cmd_Write.Enabled = true; 
            Cmd_ONOFF.Enabled = true;

            string srcAddress = src_address;

            src.IO = (IMessage)rMgr.Open(srcAddress, AccessMode.NO_LOCK, 2000, "");
            src.IO.Timeout = 2000;
        }
        private void Cmd_Close_Click(object sender, EventArgs e)
        {
            src.IO.Close();
            comboBox1.Enabled = true;
            Cmd_Close.Enabled = false;
            Cmd_ONOFF.Enabled = false;
        }
        private void Cmd_Write_Click(object sender, EventArgs e)
        {

            sendstring = sendstring.Replace("\r\n","\n");
            src.WriteString(sendstring);//("*IDN?\n");//
            txtRead.AppendText(txtSend.Text + "\r\n");
            txtSend.Text = string.Empty;
        }
        private void Cmd_Read_Click(object sender, EventArgs e)
        {
            try
            {
                txtRead.Text += src.ReadString() + "\r\n";
            }
            catch (TimeoutException)
            {
                txtRead.Text = "timeout exception";

            }

        }
        // function turn_ONOFF get two parameters (status ON/OFF, number of channels to be turned ON/OFF)
        // turn_ONOFF(true, 2) - channel 1 and 2 must be turned ON
        private void Turn_ONOFF(bool ON_OFF, int channels)
        {
            string b_command = string.Empty;
            if (ON_OFF)
            {
                switch (channels)
                {
                    case 1:
                        b_command = "1,0,0";
                        break;
                    case 2:
                        b_command = "1,1,0";
                        break;
                    case 3:
                        b_command = "1,1,1";
                        break;
                }
            }
            else 
            {
                switch (channels)
                {
                    case 1:
                        b_command = "0,1,1";
                        break;
                    case 2:
                        b_command = "0,0,1";
                        break;
                    case 3:
                        b_command = "0,0,0";
                        break;
                }

            }
            sendstring = "APP:OUT "+ b_command + "\n";
            src.WriteString(sendstring);
        }
        //Setup voltage (channel, voltage)
        //Setup_Voltage(2, 15) - setup channel 2 voltage 15V
        private void Setup_Voltage(int Channel, string Voltage)
        {
            string b_command = string.Empty;

            switch (Channel)
            {
                case 1:
                    b_command = "INST CH1\n";
                    break;
                case 2:
                    b_command = "INST CH2\n";
                    break;
                case 3:
                    b_command = "INST CH3\n";
                    break;
            }
            src.WriteString(b_command);
            System.Threading.Thread.Sleep(200);
            b_command = "SOUR:VOLT:LEV:IMM:AMPL " + Voltage + "\n";
            src.WriteString(b_command);

        }
        //Setup current (channel, current)
        //Setup_Current(3, 1) - setup channel 3 current 1A
        private void Setup_Current(int Channel, string Current)
        {
            string b_command = string.Empty;

            switch (Channel)
            {
                case 1:
                    b_command = "INST CH1\n";
                    break;
                case 2:
                    b_command = "INST CH2\n";
                    break;
                case 3:
                    b_command = "INST CH3\n";
                    break;
            }
            src.WriteString(b_command);
            System.Threading.Thread.Sleep(200);
            b_command = "SOUR:CURR:LEV:IMM:AMPL " + Current + "\n";
            src.WriteString(b_command);

        }
        //Setup_OVP (channel, voltage)
        //Setup_OVP(3, 10) - setup channel 3 voltage 10V maximum limit
        private void Setup_OVP(int Channel, string Voltage)
        {
            string b_command = string.Empty;

            switch (Channel)
            {
                case 1:
                    b_command = "INST CH1\n";
                    break;
                case 2:
                    b_command = "INST CH2\n";
                    break;
                case 3:
                    b_command = "INST CH3\n";
                    break;
            }
            src.WriteString(b_command);
            System.Threading.Thread.Sleep(200);
            b_command = "SOUR:VOLT:PROT:LEV " + Voltage + "V\n";
            src.WriteString(b_command);

        }
        //Measurement Voltage
        //Meas_Voltage(2) - measurement voltage of channel 2
        private float Meas_Voltage(int Channel)
        {
            float Meas_Voltage = 0;
            string b_command = string.Empty;

            switch (Channel)
            {
                case 1:
                    b_command = "INST CH1\n";
                    break;
                case 2:
                    b_command = "INST CH2\n";
                    break;
                case 3:
                    b_command = "INST CH3\n";
                    break;
            }
            src.WriteString(b_command);
            System.Threading.Thread.Sleep(200);
            b_command = "MEAS:SCAL:VOLT:DC?\n";
            src.WriteString(b_command);
            System.Threading.Thread.Sleep(200);
            Meas_Voltage = float.Parse(src.ReadString());

            return Meas_Voltage;
        }
        //Measurement Current
        //Meas_Current(1) - measurement current of channel 1
        private float Meas_Current(int Channel)
        {
            float Meas_Current = 0;
            string b_command = string.Empty;

            switch (Channel)
            {
                case 1:
                    b_command = "INST CH1\n";
                    break;
                case 2:
                    b_command = "INST CH2\n";
                    break;
                case 3:
                    b_command = "INST CH3\n";
                    break;
            }
            src.WriteString(b_command);
            System.Threading.Thread.Sleep(200);
            b_command = "MEAS:SCAL:CURR:DC?\n";
            src.WriteString(b_command);
            System.Threading.Thread.Sleep(200);
            Meas_Current = float.Parse(src.ReadString());

            return Meas_Current;
        }

        //Initilization function return of (*IDN?\n) -> (B&K Precision, 9130C, 800885011777110054, 1.11-1.04)
        private bool BK_Init()
        {            
            string p_answer = string.Empty;
            bool BK_INIT = false;
                        
            src.WriteString("*IDN?\n");
            System.Threading.Thread.Sleep(200);
            
            p_answer = src.ReadString();
            //BK_INIT = p_answer.Contains("800885011777110054");
            BK_INIT = p_answer.Contains("9130");

            return BK_INIT;
        }
        //SCPI "*CLS" commands clear registers of BK PS
        private void BK_Clear()
        {
            string p_answer = string.Empty;
            
            src.WriteString("*CLS\n");
            System.Threading.Thread.Sleep(200);
        }
        //This command resets the power supply
        private void BK_Reset()
        {
            string p_answer = string.Empty;

            src.WriteString("*RST\n");
            System.Threading.Thread.Sleep(200);
        }

        // TURN ON/OFF each channel separatly
        private void Turn_ONOFF_EACH(bool ON_OFF, int Channel)
        {
            string b_command = string.Empty;

            switch (Channel)
            {
                case 1:
                    b_command = "INST CH1\n";
                    break;
                case 2:
                    b_command = "INST CH2\n";
                    break;
                case 3:
                    b_command = "INST CH3\n";
                    break;
            }
            src.WriteString(b_command);
            System.Threading.Thread.Sleep(200);
            if (ON_OFF)
            {
                b_command = "SOUR:CHAN:OUTP ON\n";
            }
            else
            {
                b_command = "SOUR:CHAN:OUTP OFF\n";
            }
            sendstring = b_command;
            src.WriteString(sendstring);
        }

        //SCPI command console mode
        private void TxtSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                sendstring = txtSend.Text+"\n";
                Cmd_Write.Focus();
            }
        }

        // set channel 2 to 10 volts
        // turn channel 2 ON
        private void Cmd_ONOFF_Click(object sender, EventArgs e)
        {
            //sendstring = "SYST:VERS?"+"\n";
            //sendstring = "OUTP?" + "\n";
            //src.WriteString(sendstring);            
            Setup_Voltage(2, "10");
            //Turn_ONOFF(true, 1);
            Turn_ONOFF_EACH(true, 2);
            //float gt = Meas_Voltage(1);
            //bool ts = BK_Init();
        }
    }
}
