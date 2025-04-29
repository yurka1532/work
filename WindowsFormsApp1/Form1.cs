using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static dddEntities1 context = new dddEntities1();
        
        public Form1()
        {
            InitializeComponent();
            var reqs = context.Requests.ToArray();
            context.Requests.Load();
            foreach (var item in reqs) {
                listBox1.Items.Add($"устройство {item.Devices.model} проблема {item.problem}");
            }
            var orders = context.Orders.ToArray();
            context.Orders.Load();
            foreach(var item in orders) {
                listBox2.Items.Add($"{item.id} заказ мастер {item.Masters.Name}");
            }
            var devices = context.Devices.ToArray();
            context.Devices.Load();
            foreach (var item in devices)
            {
                listBox3.Items.Add(item.model);
            }
            var matandparts = context.Parts_and_Materials.ToArray();
            context.Parts_and_Materials.Load();
            foreach (var item in matandparts)
            {
                listBox4.Items.Add($"устройство {item.Devices.model} списание {item.costs} остатки {item.lefted}");
            }
            var results = context.Results.ToArray();
            context.Results.Load();
            foreach (var item in results)
            {
                listBox5.Items.Add(item.id);
            }
            var masters = context.Masters.ToArray();
            context.Masters.Load();
            foreach (var item in masters)
            {
                listBox6.Items.Add(item.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var reqs = context.Requests;

            try
            {
                var newitem = new Requests { deviceId = int.Parse(textBox1.Text), problem = textBox2.Text };
                context.Requests.Add(newitem);
                context.SaveChanges();
                listBox1.Items.Clear();
                foreach (var item in reqs)
                {
                    listBox1.Items.Add(item.id);
                }
            }
            catch
            {
                MessageBox.Show("устройства с таким id не существует");
            }

            // Добавление новой записи
            //var newItem = new YourTable { ColumnName = "New Value" };
            //context.YourTable.Add(newItem);
            //context.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var orders = context.Orders;
            context.Orders.Load();
            try
            {
                Orders order = new Orders { masterId = int.Parse(textBox6.Text), steps = textBox5.Text };
                context.Orders.Add(order);
                context.SaveChanges();
                listBox2.Items.Clear();
                foreach (var item in orders)
                {
                    listBox2.Items.Add(item.id);
                }
            }
            catch
            {
                MessageBox.Show("мастера с таким id не существует");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var devices = context.Devices;
            context.Devices.Load();

            Devices device = new Devices {model = textBox8.Text, repair_history = textBox4.Text, serial_number = textBox7.Text };
            context.Devices.Add(device);
            context.SaveChanges();
            listBox3.Items.Clear();
            foreach (var item in devices)
            {
                listBox3.Items.Add(item.model);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var parts = context.Parts_and_Materials;
            context.Parts_and_Materials.Load();

            var ptrs = new Parts_and_Materials { id = int.Parse(textBox11.Text), costs = int.Parse(textBox10.Text) };
            parts.Add(ptrs);
            context.SaveChanges();
            listBox4.Items.Clear();
            foreach (var item in parts)
            {
                listBox4.Items.Add(item.id);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var results = context.Results;
            context.Results.Load();

            var result = new Results { Result = $"{textBox14.Text} ${textBox13.Text} ${textBox12.Text}" };
            results.Add(result);
            context.SaveChanges();
            listBox5.Items.Clear();
            foreach (var item in results)
            {
                listBox5.Items.Add(item.id);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            var masters = context.Masters;
            context.Masters.Load();

            var master = new Masters { Name = textBox16.Text };
            masters.Add(master);
            context.SaveChanges();
            listBox6.Items.Clear();
            foreach (var item in masters)
            {
                listBox6.Items.Add(item.Name);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var reqs = context.Requests;
            context.Requests.Load();
            int deviceid = int.Parse(textBox1.Text);
            List<Requests> reqlist = context.Requests.Where(a => a.Devices.id == deviceid).ToList();
            if (reqlist != null)
            {
                foreach (var req in reqlist)
                {
                    context.Requests.Remove(req);
                    context.SaveChanges();
                    listBox1.Items.Clear();
                    foreach (var item in reqs)
                    {
                        listBox1.Items.Add($"устройство {item.Devices.model} проблема {item.problem}");
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var orders = context.Orders;
            context.Orders.Load();
            int id = int.Parse(listBox2.SelectedItem.ToString()[0].ToString());
            orders.Remove(orders.Where(a => a.id == id).First());
            context.SaveChanges();
            listBox2.Items.Clear();
            foreach (var item in orders)
            {
                listBox2.Items.Add($"{item.id} заказ мастер {item.Masters.Name}");
            }
        }
    }
}
