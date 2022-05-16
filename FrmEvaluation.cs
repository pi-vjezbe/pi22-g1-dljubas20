using Evaluation_Manager.Models;
using Evaluation_Manager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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

			var evaluation = EvaluationRepository.GetEvaluation(odabraniStudent, currentActivity);
			if(evaluation != null)
            {
				txtTeacher.Text = evaluation.Evaluator.ToString();
				txtEvaluatioDate.Text = evaluation.EvaluationDate.ToString();
				numPoints.Value = evaluation.Points;
            }
            else
            {
				txtTeacher.Text = FrmLogin.LoggedTeacher.ToString();
				txtEvaluatioDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
				numPoints.Value = 0;
			}
		}

        private void btnSave_Click(object sender, EventArgs e)
		{
			var currentActivity = cboActivities.SelectedItem as Activity;
			var evaluation = EvaluationRepository.GetEvaluation(odabraniStudent, currentActivity);
			if(evaluation != null)
            {
				EvaluationRepository.UpdateEvaluation(evaluation, FrmLogin.LoggedTeacher, (int)numPoints.Value);
			}
            else
            {
				EvaluationRepository.InsertEvaluation(odabraniStudent, currentActivity, FrmLogin.LoggedTeacher, (int)numPoints.Value);
            }
		}
    }
}
