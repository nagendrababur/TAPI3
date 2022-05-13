using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TAPI3Lib;
using System.Threading;
using System.Configuration;

namespace tapi3_dev
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private TAPIClass tobj;
        private ITAddress[] ia = new TAPI3Lib.ITAddress[10];
        private ITBasicCallControl bcc;
        private callnotification cn;
        private bool h323, reject;
        uint lines;
        int line;
        int[] registertoken = new int[10];
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button6;
        private Button button7;
        private Button button8;
        private TextBox textBox3;
        private CheckBox checkBox3;
        int delay = Convert.ToInt32(ConfigurationManager.AppSettings["executionDelay"]);
        //int registertoken;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            initializetapi3();
            h323 = false;
            reject = false;
            MessageBox.Show("lines : " + lines, "Lines avaialble are");
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        void initializetapi3()
        {
            try
            {
                tobj = new TAPIClass();
                tobj.Initialize();
                IEnumAddress ea = tobj.EnumerateAddresses();
                ITAddress ln;
                uint arg3 = 0;
                lines = 0;

                cn = new callnotification();
                cn.addtolist = new callnotification.listshow(this.status);
                tobj.ITTAPIEventNotification_Event_Event += new TAPI3Lib.ITTAPIEventNotification_EventEventHandler(cn.Event);
                tobj.EventFilter = (int)(TAPI_EVENT.TE_CALLNOTIFICATION |
                    TAPI_EVENT.TE_DIGITEVENT |
                    TAPI_EVENT.TE_PHONEEVENT |
                    TAPI_EVENT.TE_CALLSTATE |
                    TAPI_EVENT.TE_GENERATEEVENT |
                    TAPI_EVENT.TE_GATHERDIGITS |
                    TAPI_EVENT.TE_REQUEST);

                for (int i = 0; i < 10; i++)
                {
                    ea.Next(1, out ln, ref arg3);
                    ia[i] = ln;
                    if (ln != null)
                    {
                        comboBox1.Items.Add(ia[i].AddressName);
                        lines++;
                    }
                    else
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            tobj.Shutdown();
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(80, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(408, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Select Line of communication";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Line";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(80, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 160);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Call status";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(296, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Clear status";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(32, 24);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(344, 82);
            this.listBox1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 280);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 20);
            this.textBox1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(80, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Call number/IP";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(400, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "CALL";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(536, 240);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Answer";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(536, 280);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Disconnect";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Location = new System.Drawing.Point(520, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(104, 64);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Answer mode";
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(16, 24);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(80, 24);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "Reject";
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(264, 280);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 16);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "H.323 call(IP call)";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(536, 112);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "Transfer";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(520, 80);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(520, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "tranfer address";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(520, 24);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 17;
            this.button6.Text = "Register";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(536, 325);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 18;
            this.button7.Text = "Monitor";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(401, 325);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 19;
            this.button8.Text = "Barge In";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(79, 325);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(152, 20);
            this.textBox3.TabIndex = 20;
            // 
            // checkBox3
            // 
            this.checkBox3.Location = new System.Drawing.Point(264, 332);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(112, 16);
            this.checkBox3.TabIndex = 21;
            this.checkBox3.Text = "H.323 call(Conf)";
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(659, 364);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "tapi3_dev";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            line = comboBox1.SelectedIndex;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            TAPI3Lib.ITAddress ln = null;
            ln = ia[line];
            if (textBox1.Text.Length != 0)
            {
                MessageBox.Show("" + textBox1.Text, "Calling to");
                try
                {
                    if (!h323)
                    {
                        bcc = ln.CreateCall(textBox1.Text, TapiConstants.LINEADDRESSTYPE_PHONENUMBER | TapiConstants.LINEADDRESSTYPE_IPADDRESS, TapiConstants.TAPIMEDIATYPE_DATAMODEM | TapiConstants.TAPIMEDIATYPE_AUDIO);
                        bcc.SetQOS(TapiConstants.TAPIMEDIATYPE_DATAMODEM | TapiConstants.TAPIMEDIATYPE_AUDIO, QOS_SERVICE_LEVEL.QSL_BEST_EFFORT);
                        bcc.Connect(false);
                    }
                    else
                    {
                        bcc = ln.CreateCall(textBox1.Text, TapiConstants.LINEADDRESSTYPE_IPADDRESS, TapiConstants.TAPIMEDIATYPE_AUDIO);
                        bcc.Connect(false);
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Failed to create call!", "TAPI3");
                }
            }
            else
            {
                MessageBox.Show("Please enter number to dial.. ");
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            //listBox1.Items.Clear();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            IEnumCall ec = ia[line].EnumerateCalls();
            uint arg = 0;
            ITCallInfo ici;
            try
            {
                ec.Next(1, out ici, ref arg);
                ITBasicCallControl bc = (TAPI3Lib.ITBasicCallControl)ici;
                if (!reject)
                {
                    bc.Answer();
                }
                else
                {
                    bc.Disconnect(DISCONNECT_CODE.DC_REJECTED);
                    ici.ReleaseUserUserInfo();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("There may not be any calls to answer! \n\n" + exp.ToString(), "TAPI3");
            }
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            IEnumCall ec = ia[line].EnumerateCalls();
            uint arg = 0;
            ITCallInfo ici;
            try
            {
                ec.Next(1, out ici, ref arg);
                ITBasicCallControl bc = (ITBasicCallControl)ici;
                bc.Disconnect(DISCONNECT_CODE.DC_NORMAL);
                ici.ReleaseUserUserInfo();
            }
            catch (Exception exp)
            {
                MessageBox.Show("No call to disconnect!", "TAPI3");
            }
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            h323 = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
        {
            reject = checkBox2.Checked;
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            IEnumCall ec = ia[line].EnumerateCalls();
            uint arg = 0;
            ITCallInfo ici;
            try
            {
                ec.Next(1, out ici, ref arg);
                ITBasicCallControl bc = (ITBasicCallControl)ici;
                bc.BlindTransfer(textBox2.Text);
                //ici.ReleaseUserUserInfo();
            }
            catch (Exception exp)
            {
                MessageBox.Show("May not have any call to disconnect!\n\n" + exp.ToString(), "TAPI3");
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            MessageBox.Show("To recieve calls from any line you need to register on that line\n,you can do this by selecting the line ansd press the register button!", "Instruction");
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            try
            {
                registertoken[line] = tobj.RegisterCallNotifications(ia[line], true, true, TapiConstants.TAPIMEDIATYPE_AUDIO, 2);
                MessageBox.Show("Registration token : " + registertoken[line], "Registration Succeed for line " + line);
            }
            catch (Exception ein)
            {
                MessageBox.Show("Failed to register on line " + line, "Registration for calls");
            }
        }
        private void button7_Click(object sender, System.EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            h323 = checkBox3.Checked;
        }
        public void status(string str)
        {
            Thread.Sleep(delay);
            listBox1.Items.Add(str);
        }
        private void button8_Click(object sender, System.EventArgs e)
        {
            IEnumCall ec = ia[line].EnumerateCalls();
            TAPI3Lib.ITAddress ln = null;
            ln = ia[line];
            try
            {
                bcc.Hold(true);
                ITBasicCallControl bc1 = ln.CreateCall(textBox3.Text, TapiConstants.LINEADDRESSTYPE_IPADDRESS, TapiConstants.TAPIMEDIATYPE_AUDIO);
                bc1.Connect(false);
                Thread.Sleep(delay);
                bcc.Transfer(bc1, true);
                Thread.Sleep(delay);
                bc1.Finish(FINISH_MODE.FM_ASCONFERENCE);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
        }
    }
    class callnotification : TAPI3Lib.ITTAPIEventNotification
    {
        public delegate void listshow(string str);
        public listshow addtolist;

        public void Event(TAPI3Lib.TAPI_EVENT te, object eobj)
        {
            switch (te)
            {
                case TAPI3Lib.TAPI_EVENT.TE_CALLNOTIFICATION:
                    addtolist("call notification event has occured");
                    break;
                case TAPI3Lib.TAPI_EVENT.TE_DIGITEVENT:
                    TAPI3Lib.ITDigitDetectionEvent dd = (TAPI3Lib.ITDigitDetectionEvent)eobj;
                    addtolist("Dialed digit" + dd.ToString());
                    break;
                case TAPI3Lib.TAPI_EVENT.TE_GENERATEEVENT:
                    TAPI3Lib.ITDigitGenerationEvent dg = (TAPI3Lib.ITDigitGenerationEvent)eobj;
                    MessageBox.Show("digit dialed!");
                    addtolist("Dialed digit" + dg.ToString());
                    break;
                case TAPI3Lib.TAPI_EVENT.TE_PHONEEVENT:
                    addtolist("A phone event!");
                    break;
                case TAPI3Lib.TAPI_EVENT.TE_GATHERDIGITS:
                    addtolist("Gather digit event!");
                    break;
                case TAPI3Lib.TAPI_EVENT.TE_CALLSTATE:
                    TAPI3Lib.ITCallStateEvent a = (TAPI3Lib.ITCallStateEvent)eobj;
                    TAPI3Lib.ITCallInfo b = a.Call;
                    switch (b.CallState)
                    {
                        case TAPI3Lib.CALL_STATE.CS_INPROGRESS:
                            addtolist("dialing");
                            break;
                        case TAPI3Lib.CALL_STATE.CS_CONNECTED:
                            addtolist("Connected");
                            break;
                        case TAPI3Lib.CALL_STATE.CS_DISCONNECTED:
                            addtolist("Disconnected");
                            break;
                        case TAPI3Lib.CALL_STATE.CS_OFFERING:
                            addtolist("A party wants to communicate with you!");
                            break;
                        case TAPI3Lib.CALL_STATE.CS_IDLE:
                            addtolist("Call is created!");
                            break;
                        case TAPI3Lib.CALL_STATE.CS_HOLD:
                            addtolist("conferenced");
                            break;
                    }
                    break;
            }
        }
    }
}
