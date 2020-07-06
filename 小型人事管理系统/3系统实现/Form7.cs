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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(System.Environment.CurrentDirectory + "\\员工基本信息.xml");  //将XML读入到内存中
            XmlNode root = doc.DocumentElement;//选择XML的根元素
            root = doc.DocumentElement;
            XmlElement no;
            no = (XmlElement)root.SelectSingleNode("//S[职工号='" + Class1 .ygh  + "']");//查找数据什等于 影片名稱 的数据。
            root.RemoveChild(no);
            doc.Save(System.Environment.CurrentDirectory + "\\员工基本信息.xml");

            XmlDocument doc1 = new XmlDocument();
            doc1.Load(System.Environment.CurrentDirectory + "\\员工工作信息.xml");  //将XML读入到内存中
            XmlNode root1 = doc1.DocumentElement;//选择XML的根元素
            root1 = doc1.DocumentElement;
            XmlElement no1;
            no1 = (XmlElement)root1.SelectSingleNode("//S[职工号='" + Class1.ygh + "']");//查找数据什等于 影片名稱 的数据。
            root1.RemoveChild(no1);
            doc1.Save(System.Environment.CurrentDirectory + "\\员工工作信息.xml");
            MessageBox.Show("已成功删除此信息！", "恭喜");
            
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(System.Environment.CurrentDirectory + "\\员工基本信息.xml");  //将XML读入到内存中
            XmlNode root = doc.DocumentElement;//选择XML的根元素
            DataSet ds = new DataSet();
            XmlNode z;
            root = doc.DocumentElement;
            z = root.SelectSingleNode("//S[部门=" + "'" + Class1 .bm + "'" + "and" + " 职工号=" + "'" + Class1 .ygh + "'" + "]");//查找数据什等于 学号 的数据。
            StringReader reader = new StringReader(z.OuterXml);
            ds.ReadXml(reader);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}