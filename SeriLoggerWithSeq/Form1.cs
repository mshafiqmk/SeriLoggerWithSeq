using System;
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
            var someLogger = new SomeLogger("ShafiqKhuidadAppLogger", Guid.NewGuid().ToString(), "LogInWindow");
            someLogger.Info($"Info : Student Recored is added {student}");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }
    }
}
