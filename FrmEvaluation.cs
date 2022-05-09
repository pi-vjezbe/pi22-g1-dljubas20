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
	public partial class FrmEvaluation : Form
	{
		private Student odabraniStudent;
		public FrmEvaluation(Student odabraniStudent)
		{
			InitializeComponent();
			this.odabraniStudent = odabraniStudent;
		}

		private void FrmEvaluation_Load(object sender, EventArgs e)
		{
			SetFormText();
			var activities = ActivityRepository.GetActivities();
			cboActivities.DataSource = activities;
		}
		private void SetFormText()
		{
			Text = odabraniStudent.FirstName + " " + odabraniStudent.LastName;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
