using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectOne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            // Array to hold scores
            decimal[] scores = new decimal[5];
            // Array of TextBoxes
            TextBox[] inputs = { textBox1, textBox2, textBox3, textBox4, textBox5 };
            // Array of comment Labels
            Label[] comments = { label14, label15, label16, label17, label18 };

            try
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    // Try to parse input
                    if (!decimal.TryParse(inputs[i].Text, out scores[i]))
                        throw new Exception($"Invalid input in TextBox {i + 1}. Please enter a number.");

                    if (scores[i] < 0 || scores[i] > 100)
                        throw new Exception($"Score in TextBox {i + 1} must be between 0 and 100.");

                    // Decision: Pass or Fail
                    comments[i].Text = scores[i] > 50 ? "Pass" : "Fail";
                }

                // Use methods to calculate results
                label11.Text =  CalculateAverage(scores).ToString("F2");
                label12.Text = FindHighest(scores).ToString("F2");
                label13.Text = FindLowest(scores).ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Input Error");
            }
        }

        // Method to calculate average
        private decimal CalculateAverage(decimal[] arr)
        {
            decimal sum = 0;
            foreach (decimal score in arr)
                sum += score;
            return sum / arr.Length;
        }

        // Method to find highest score
        private decimal FindHighest(decimal[] arr)
        {
            decimal max = arr[0];
            foreach (decimal score in arr)
                if (score > max) max = score;
            return max;
        }

        // Method to find lowest score
        private decimal FindLowest(decimal[] arr)
        {
            decimal min = arr[0];
            foreach (decimal score in arr)
                if (score < min) min = score;
            return min;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Clear TextBoxes
            textBox1.Text = "0.00";
            textBox2.Text = "0.00";
            textBox3.Text = "0.00";
            textBox4.Text = "0.00";
            textBox5.Text = "0.00";

            // Reset result Labels
            label11.Text = "0.00"; // Average
            label12.Text = "0.00"; // Highest
            label13.Text = "0.00"; // Lowest
        }
    }
}
