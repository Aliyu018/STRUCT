using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_Struct
{
    public partial class Form1 : Form
    {
        List<Records> items = new List<Records>();
        private int AutoID;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoID = 1;
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("ID", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Word", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Meaning", 100, HorizontalAlignment.Center);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            items.Add(new Records { id = AutoID, word = textBox2.Text, mean = textBox3.Text });
            AutoID++;
            refresh();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        private void refresh()
        {
            listView1.Items.Clear();
            int i;
            for (i = 0; i < items.Count; i++)
            {
                ListViewItem R = new ListViewItem(items[i].id.ToString());
                ListViewItem.ListViewSubItem C2 = new ListViewItem.ListViewSubItem(R, items[i].word);
                ListViewItem.ListViewSubItem C3 = new ListViewItem.ListViewSubItem(R, items[i].mean);
                R.SubItems.Add(C2);
                R.SubItems.Add(C3);
                listView1.Items.Add(R);

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text=listView1.FocusedItem.SubItems[0].Text;
            textBox2.Text = listView1.FocusedItem.SubItems[1].Text;
            textBox3.Text = listView1.FocusedItem.SubItems[2].Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = int.Parse(textBox1.Text);
            index--;
            items.Remove(items[index]);

            for (int i = index; i < items.Count; i++)
                items[i].id--;
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = int.Parse(textBox1.Text);
            index--;
            items[index].word=textBox2.Text;
            items[index].mean=textBox3.Text;
            refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label5.Text = "Meaning: ";
            for (int i = 0; i < items.Count; i++)
            {
                if (textBox4.Text == items[i].word)
                {
                    label5.Text += items[i].mean;
                    return;
                }
            }
            MessageBox.Show("Not Found");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
