using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Data.SqlClient;


namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private XmlDocument doc;
        private XmlNode currentNode;
        public DataSet ds;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(System.Environment.CurrentDirectory+"\\登录表.xml");  //将XML读入到内存中
            XmlNode root = doc.DocumentElement;//选择XML的根元素
            DataSet ds = new DataSet();
            
            
               XmlNode S;
                root = doc.DocumentElement;
                S = root.SelectSingleNode("//S[用户名='" + textBox1.Text.Trim() + "']");//查找数据什等于 checi 的数据。
                StringReader reader = new StringReader(S.OuterXml);//将找到的数据加入到新生成的reader数据流中。
                ds.ReadXml(reader);//以XML方式读取到dataset中。
                try
                {
                    if (textBox2.Text == ds.Tables[0].Rows[0]["密码"].ToString().Trim())
                    {
                        // Class1.xm = ds.Tables[0].Rows[0]["姓名"].ToString().Trim();
                        Form2 myf = new Form2();
                        this.Opacity = 0;
                        myf.ShowDialog();
                        this.Opacity = 100;
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码不存在！", "错误");
                    }
                }
                catch(Exception s)
                {
                    MessageBox.Show(s.Message);
                }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 myf = new Form3();
            myf.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int i;
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity =Opacity + 0.008;
            i=i+1;
            if (i == 125)
            {
                timer1.Enabled = false;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}