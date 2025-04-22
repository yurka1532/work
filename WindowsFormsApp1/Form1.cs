using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static dddEntities1 context = new dddEntities1();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var reqs = context.Requests;
            var newitem = new Requests { deviceId = int.Parse(textBox1.Text), problem = textBox2.Text };
            context.Requests.Add(newitem);
            context.SaveChanges();

            // Добавление новой записи
            //var newItem = new YourTable { ColumnName = "New Value" };
            //context.YourTable.Add(newItem);
            //context.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var orders = context.Orders;
            context.Orders.Load();

            Orders order = new Orders {masterId = int.Parse(textBox6.Text), steps = textBox5.Text };

            context.SaveChanges();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var devs = context.Devices;
            context.Devices.Load();

            Devices devices = new Devices {model = textBox8.Text, repair_history = textBox4.Text, serial_number = textBox7.Text };

            context.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var parts = context.Parts_and_Materials;
            context.Parts_and_Materials.Load();

            var ptrs = new Parts_and_Materials { id = int.Parse(textBox11.Text), costs = int.Parse(textBox10.Text) };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
