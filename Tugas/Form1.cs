using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas
{
    public partial class Form1 : Form
    {
        Nilai[] obj = new Nilai[3];
   
        double gpa;
        int i;


        public Form1()
        {
            InitializeComponent();
            i = 0;
        }

        private void result_Click(object sender, EventArgs e)
        {
            obj[i] = new Nilai();

            obj[i].module_name = module_text.Text;
            double testValue, assignmentValue, creditValue,grade_Value;
            if (!double.TryParse(num1.Value.ToString(), out testValue) || !double.TryParse(num2.Value.ToString(), out assignmentValue) || !double.TryParse(txtSks.Value.ToString(), out creditValue))
            {
                MessageBox.Show("Masukkan harus berupa angka untuk nilai tes, tugas, dan SKS.");
                return;
            }
            obj[i].module_test = testValue;
            obj[i].assigment = assignmentValue;
            obj[i].credit_value = creditValue;

            if (string.IsNullOrEmpty(obj[i].module_name))
            {
                MessageBox.Show("Nama modul harus diisi!");
                return;
            }
            if (obj[i].module_test == 0 || obj[i].assigment == 0)
            {
                MessageBox.Show("Nilai tes tidak boleh 0");
                return;
            }

        
            hasil.Text = obj[i].Calculate().ToString();

            if (obj[i].result >= 80 && obj[i].result <= 100)
            {
                label2.Text = "A";
                obj[i].grade = "A";
                obj[i].grade_Val = 4;
            }
            else if (obj[i].result >= 70 && obj[i].result < 80)
            {
                label2.Text = "B";
                obj[i].grade = "B";
                obj[i].grade_Val = 3;
            }
            else if (obj[i].result >= 60 && obj[i].result < 70)
            {
                label2.Text = "C";
                obj[i].grade = "C";
                obj[i].grade_Val = 2;
            }
            else if (obj[i].result >= 50 && obj[i].result < 60)
            {
                label2.Text = "D";
                obj[i].grade = "D";
                obj[i].grade_Val = 1;
            }
            else if (obj[i].result < 50)
            {
                label2.Text = "E";
                obj[i].grade = "E";
                obj[i].grade_Val = 0;
            }
            else
            {
                label2.Text = "Error";
                obj[i].grade = "Error";
                obj[i].grade_Val= -1;
            }
            switch (obj[i].grade)
            {
                case "A":
                    MessageBox.Show("Excellent");
                    break;
                case "B":
                    MessageBox.Show("Very Good");
                    break;
                case "C":
                    MessageBox.Show("Good");
                    break;
                case "D":
                    MessageBox.Show("Fair");
                    break;
                case "E":
                    MessageBox.Show("Poor");
                    break;
                case "Error":
                    MessageBox.Show("Error occurred");
                    break;
                default:
                    MessageBox.Show("Unknown grade");
                    break;
            }
            i++;


            }
                
            
        

        private void btnGpa_Click(object sender, EventArgs e)
        {
            gpa = getTotalGV() / getTotalCredit();
            MessageBox.Show("GPA: " +  gpa);
        }

        private double getTotalCredit()
        {
            double totalCredit = 0;
            foreach (Nilai mod in obj)
            {
                totalCredit += mod.credit_value;
            }
            return totalCredit;
        }

        private double getTotalGV()
        {
            double totalGV = 0;
            for (int j = 0; j < 3; j++)
            {
                totalGV = totalGV + (obj[j].credit_value * obj[j].grade_Val);
            }
 return totalGV;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}