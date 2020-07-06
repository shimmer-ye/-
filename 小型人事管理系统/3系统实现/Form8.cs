using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
namespace WindowsApplication1
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(System.Environment.CurrentDirectory + "\\员工基本信息.xml");  //将XML读入到内存中
            XmlNode root = doc.DocumentElement;//选择XML的根元素
            DataSet ds = new DataSet();
            try
            {
                XmlNode z;
                root = doc.DocumentElement;
                z = root.SelectSingleNode("//S[职工号='" + textBox1.Text.Trim() + "']");//查找数据什等于 学号 的数据。
                StringReader reader = new StringReader(z.OuterXml);//将找到的数据加入到新生成的reader数据流中。
                ds.ReadXml(reader);//以XML方式读取到dataset中。
                textBox2.Text = ds.Tables[0].Rows[0]["职工号"].ToString().Trim();
                textBox3.Text = ds.Tables[0].Rows[0]["姓名"].ToString().Trim();
                textBox4.Text = ds.Tables[0].Rows[0]["性别"].ToString().Trim();
                textBox5.Text = ds.Tables[0].Rows[0]["年龄"].ToString().Trim();
                textBox6 . Text = ds.Tables[0].Rows[0]["住址"].ToString().Trim();
                comboBox1.Text = ds.Tables[0].Rows[0]["部门"].ToString().Trim();
               
                XmlDocument doc1 = new XmlDocument();
                doc1.Load(System.Environment.CurrentDirectory + "\\员工工作信息.xml");  //将XML读入到内存中
                XmlNode root1 = doc1.DocumentElement;//选择XML的根元素
                DataSet ds1 = new DataSet(); 
                XmlNode z1;
                root1 = doc1.DocumentElement;
                z1 = root1.SelectSingleNode("//S[职工号='" + textBox1.Text.Trim() + "']");//查找数据什等于 学号 的数据。
                StringReader reader1 = new StringReader(z1.OuterXml);//将找到的数据加入到新生成的reader数据流中。
                ds1.ReadXml(reader1);//以XML方式读取到dataset中。
                textBox8.Text = ds1.Tables[0].Rows[0]["缺勤一季度"].ToString().Trim();
                textBox9.Text = ds1.Tables[0].Rows[0]["缺勤二季度"].ToString().Trim();
                textBox10.Text = ds1.Tables[0].Rows[0]["缺勤三季度"].ToString().Trim();
                textBox11.Text = ds1.Tables[0].Rows[0]["缺勤四季度"].ToString().Trim();
                textBox12.Text = ds1.Tables[0].Rows[0]["工资一季度"].ToString().Trim();
                textBox13.Text = ds1.Tables[0].Rows[0]["工资二季度"].ToString().Trim();
                textBox14.Text = ds1.Tables[0].Rows[0]["工资三季度"].ToString().Trim();
                textBox15.Text = ds1.Tables[0].Rows[0]["工资四季度"].ToString().Trim();
            }
            catch (Exception e1)
            {
                MessageBox.Show("No matching node exists" + e1.ToString(), "Navigation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(System.Environment.CurrentDirectory + "\\员工基本信息.xml");
            XmlNode root = doc.SelectSingleNode("NewDataSet");//查找
            XmlNode book = root.SelectSingleNode("//S[职工号='" + textBox1.Text.Trim() + "']");
            book.ChildNodes[0].InnerText = textBox2.Text.Trim();
            book.ChildNodes[1].InnerText = textBox3.Text.Trim();
            book.ChildNodes[2].InnerText = textBox4.Text.Trim();
            book.ChildNodes[3].InnerText = textBox5.Text.Trim();
            book.ChildNodes[4].InnerText = textBox6.Text.Trim();

            doc.Save(System.Environment.CurrentDirectory + "\\员工基本信息.xml");

            XmlDocument doc1 = new XmlDocument();
            doc1.Load(System.Environment.CurrentDirectory + "\\员工工作信息.xml");
            XmlNode root1 = doc1.SelectSingleNode("NewDataSet");//查找
            XmlNode book1 = root1.SelectSingleNode("//S[职工号='" + textBox1.Text.Trim() + "']");
            book1.ChildNodes[3].InnerText = textBox8.Text.Trim();
            book1.ChildNodes[4].InnerText = textBox9.Text.Trim();
            book1.ChildNodes[5].InnerText = textBox10.Text.Trim();
            book1.ChildNodes[6].InnerText = textBox11.Text.Trim();
            book1.ChildNodes[7].InnerText = textBox12.Text.Trim();
            book1.ChildNodes[8].InnerText = textBox13.Text.Trim();
            book1.ChildNodes[9].InnerText = textBox14.Text.Trim();
            book1.ChildNodes[10].InnerText = textBox15.Text.Trim();
            doc1.Save(System.Environment.CurrentDirectory + "\\员工工作信息.xml");


            MessageBox.Show("已成功修改！", "提示");


        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}