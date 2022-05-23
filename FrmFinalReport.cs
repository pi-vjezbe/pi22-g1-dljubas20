using Evaluation_Manager.Models;
using Evaluation_Manager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluation_Manager
{
    public partial class FrmFinalReport : Form
    {
        public FrmFinalReport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmFinalReport_Load(object sender, EventArgs e)
        {
            List<StudentReportView> results = GenerateStudentReport();
        }

        private List<StudentReportView> GenerateStudentReport()
        {
            var allStudents = StudentRepository.GetStudents();
            var examReports = new List<StudentReportView>();

            foreach (var student in allStudents)
            {
                if(student.HasSignature() == true)
                {
                    var studentReport= new StudentReportView(student);
                    examReports.Add(studentReport);
                }
            }
            return examReports;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            var form = new FrmFinalReport();
            form.ShowDialog();
        }
    }
}
