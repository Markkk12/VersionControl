using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();

            label1.Text = Resource1.FullName;
            button2.Text = Resource1.Iras;          
            button1.Text = Resource1.Add;
            button3.Text = Resource1.Torles;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text,
                
            };
            users.Add(u);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() != DialogResult.OK) return;

            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {
                foreach (var s in users)
                {
                    sw.WriteLine(s.ID);
                    sw.WriteLine(";");
                    sw.WriteLine(s.FullName);
                    sw.WriteLine();
                }
            }
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            users.Remove((User)listBox1.SelectedItem);
        }
    }
}
