using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_Manager.Models
{
    internal class StudentReportView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string K1 { get; set; }
        public string K2 { get; set; }
        public string Z1 { get; set; }
        public string Z2 { get; set; }
        public string Z3 { get; set; }

        public string HasSignature { get; set; }
        public string HasGrade { get; set; }
        public string TotalPoints { get; set; }
        public string Grade { get; set; }

        public StudentReportView(Student student)
        {
            FirstName = student.FirstName;
            LastName = student.LastName;

            var evaluations = student.GetEvaluations();

            Evaluation kolokvij1 = evaluations.FirstOrDefault(e => e.Activity.Name == "Kolokvij 1");
            Evaluation kolokvij2 = evaluations.FirstOrDefault(e => e.Activity.Name == "Kolokvij 2");
            Evaluation zadaca1 = evaluations.FirstOrDefault(e => e.Activity.Name == "Zadaca 1");
            Evaluation zadaca2 = evaluations.FirstOrDefault(e => e.Activity.Name == "Zadaca 2");
            Evaluation zadaca3 = evaluations.FirstOrDefault(e => e.Activity.Name == "Zadaca 3");

            K1 = kolokvij1.Points.ToString();
            K2 = kolokvij2.Points.ToString();
            Z1 = zadaca1.Points.ToString();
            Z2 = zadaca2.Points.ToString();
            Z3 = zadaca3.Points.ToString();

            HasSignature = student.HasSignature() == true ? "DA" : "NE";
            HasGrade = student.HasGrade() == true ? "DA" : "NE";

            TotalPoints = student.CalculateTotalPoints().ToString();

            Grade = student.CalculateGrade().ToString();
        }

    }
}
