using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClassLibrary1.Class1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Делегаты
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        Account ac;
        void DisplayMessage(Account sender, AccountEventArgs e)
        {
            MessageBox.Show($"Владелец счета: {ac.fio}\nСумма зачисления: {e.Sum} руб.\n" + e.Message + $"\nТекущая сумма на счете: {sender.sum} руб.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ac.Notify += DisplayMessage;   // Добавляем обработчик для события Notify
            ac.Add(Convert.ToInt32(textBox3.Text));
            listBox1.Items.Clear();
            listBox1.Items.Add($"Владелец: {ac.fio}, счет: {ac.sum}");
            ac.Notify -= DisplayMessage;   // Добавляем обработчик для события Notify  
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox4.Text);
            if (ac.sum < x)
            {
                ac.Notify += DisplayMessage;   // Добавляем обработчик для события Notify
                listBox1.Items.Clear();
                listBox1.Items.Add("На счету недостаточно средств");
                ac.Notify -= DisplayMessage;   // Добавляем обработчик для события Notify
            }
            else
            {
                ac.Notify += DisplayMessage;   // Добавляем обработчик для события Notify
                ac.Take(Convert.ToInt32(textBox4.Text));
                listBox1.Items.Clear();
                listBox1.Items.Add($"Владелец: {ac.fio}, счет: {ac.sum}");
                ac.Notify -= DisplayMessage;   // Добавляем обработчик для события Notify
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ac = new Account(Convert.ToInt32(textBox2.Text), textBox1.Text);
            listBox1.Items.Clear();
            listBox1.Items.Add($"Владелец: {ac.fio}, счет: {ac.sum}");
            button2.Visible = true;
            button3.Visible = true;
            textBox3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
