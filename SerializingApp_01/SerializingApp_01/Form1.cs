using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Web.Script.Serialization;

namespace SerializingApp_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Person p1 = new Person() { FirstName = textBox1.Text, LastName = textBox2.Text, Age = textBox3.Text };
            string OutPutJson = ser.Serialize(p1);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Json Files|*.json";
            sfd.Title = "Save a Json File";
            if(sfd.ShowDialog()== DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, OutPutJson);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Json Files|*.json";
            ofd.Title = "Open a Json File";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = File.ReadAllText(ofd.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(XmlPerson));
            SaveFileDialog sfd2 = new SaveFileDialog();
            sfd2.Filter = "Xml Files|*.xml";
            sfd2.Title = "Save an Xml File";
            if (sfd2.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd2.FileName))
                {
                    XmlPerson xp = new XmlPerson()
                    {
                        FirstName = textBox1.Text, LastName = textBox2.Text, Age = textBox3.Text
                    };
                    xs.Serialize(sw, xp);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd2 = new OpenFileDialog();
            ofd2.Filter = "Xml Files|*.xml";
            ofd2.Title = "Open an Xml File";

            if (ofd2.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = File.ReadAllText(ofd2.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
