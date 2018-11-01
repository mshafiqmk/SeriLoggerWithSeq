using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeriLoggerWithSeq
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            dataGridView1.DataSource = StudentFackRepo.GetStudentList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void buttonFindStudent_Click(object sender, EventArgs e)
        {
            var activityId = Guid.NewGuid().ToString();
            var logger = new ShafiqKhuidadAppLogger("ShafiqKhuidadAppLogger", activityId, "FindWindow");
            var name  = textBoxName.Text;
            var count = StudentFackRepo.GetStudentList().Count(x => x.Name.Contains(name));
            if (count>0)
            {
                logger.Info($"Info : Student recored found with Name {name} ");
            }
            else
            {
                logger.Error($"Error : No Record Found for Name {name}");
            }
        }
    }
}
