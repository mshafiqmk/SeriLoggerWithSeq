using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Serilog;
namespace SeriLoggerWithSeq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var student = new Student()
            {
                Name = textBoxName.Text,
                Age = textBoxAge.Text
            };
            label1.Text = student.Name + " " + student.Age;
            var someLogger = new ShafiqKhuidadAppLogger("ShafiqKhuidadAppLogger", Guid.NewGuid().ToString(), "LogInWindow");
            var props = new Dictionary<string, string>();
            props.Add("Name", student.Name);
            props.Add("Age", student.Age);
            someLogger.Info($"Info : Student Recored is added ",props);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }
    }
}
