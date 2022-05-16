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

        private void cboActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
			var currentActivity = cboActivities.SelectedItem as Activity;
			txtActivityDescription.Text = currentActivity.Description;
			txtMinForGrade.Text = currentActivity.MinPointsForGrade + "/" +
			currentActivity.MaxPoints;
			txtMinForSignature.Text = currentActivity.MinPointsForSignature + "/" +
			currentActivity.MaxPoints;
			numPoints.Minimum = 0;
			numPoints.Maximum = currentActivity.MaxPoints;

		}
	}
}
