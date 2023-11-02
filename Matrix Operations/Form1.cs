using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_Operations
{
    public partial class Form1 : Form
    {
        TextBox[,] tb;
        TextBox[,] tb2;
        int a =2, b =2, a2 = 2, b2 = 2;
        public Form1()
        {
           

            InitializeComponent();
            tb = new TextBox[,] { {textBox1,textBox2,textBox4,textBox3, textBox5 },
                                    {textBox10, textBox9, textBox8, textBox7, textBox6 },
                                    {textBox15, textBox14, textBox13, textBox12, textBox11 },
                                    {textBox20, textBox19, textBox18, textBox17, textBox16 },
                                    {textBox25, textBox24, textBox23, textBox22, textBox21 }
            };
            tb2 = new TextBox[,] { {textBox50,textBox49,textBox48,textBox47, textBox46 },
                                    {textBox45, textBox44, textBox43, textBox42, textBox41 },
                                    {textBox40, textBox39, textBox38, textBox37, textBox36 },
                                    {textBox35, textBox34, textBox33, textBox32, textBox31 },
                                    {textBox30, textBox29, textBox28, textBox27, textBox26 }
            };
            UpdateTextBoxVisibility();
            UpdateTextBoxVisibility2();

            numericUpDown1.Maximum = 5; numericUpDown1.Minimum = 0;
            numericUpDown2.Maximum = 5; numericUpDown2.Minimum = 0;
            numericUpDown3.Maximum = 5; numericUpDown3.Minimum = 0;
            numericUpDown4.Maximum = 5; numericUpDown4.Minimum = 0;

        }

   


        //Matrix 1
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            b = (int)numericUpDown2.Value;
            UpdateTextBoxVisibility();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            a = (int)numericUpDown1.Value;
            UpdateTextBoxVisibility();
        }

        private void UpdateTextBoxVisibility()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    // Set visibility based on a and b values
                    tb[i, j].Visible = (i < a) && (j < b);
                }
            }
        }

        //Matrix 2
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            a2 = (int)numericUpDown4.Value;
            UpdateTextBoxVisibility2();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            b2 = (int)numericUpDown3.Value;
            UpdateTextBoxVisibility2();
        }

        private void UpdateTextBoxVisibility2()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    // Set visibility based on a and b values
                    tb2[i, j].Visible = (i < a2) && (j < b2);
                }
            }
        }

        //Operations
        private void button1_Click(object sender, EventArgs e)
        {
            double[,] m1 = new double[a, b];
            double[,] m2 = new double[a2, b2];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    m1[i, j] = Int32.Parse(tb[i, j].Text);
                }
            }
            for (int i = 0; i < a2; i++)
            {
                for (int j = 0; j < b2; j++)
                {
                    m2[i, j] = Int32.Parse(tb2[i, j].Text);
                }
            }

            double[,] result = MatrixMath.AddMatrices(m1, m2);
            displayMatrix(result);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            double[,] m1 = new double[a, b];
            double[,] m2 = new double[a2, b2];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    m1[i, j] = Int32.Parse(tb[i, j].Text);
                }
            }
            for (int i = 0; i < a2; i++)
            {
                for (int j = 0; j < b2; j++)
                {
                    m2[i, j] = Int32.Parse(tb2[i, j].Text);
                }
            }

            double[,] result = MatrixMath.SubtractMatrices(m1, m2);
            displayMatrix(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double[,] m1 = new double[a, b];
            double[,] m2 = new double[a2, b2];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    m1[i, j] = Int32.Parse(tb[i, j].Text);
                }
            }
            for (int i = 0; i < a2; i++)
            {
                for (int j = 0; j < b2; j++)
                {
                    m2[i, j] = Int32.Parse(tb2[i, j].Text);
                }
            }

            double[,] result = MatrixMath.MultiplyMatrices(m1, m2);
            displayMatrix(result);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(a2 != 1 || b2 != 1)
            {
                MessageBox.Show("Matrix 2 must be a scalar aka 1x1 matrix.");
            }
            else
            {
                double[,] m1 = new double[a, b];
                double[,] m2 = new double[a2, b2];
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        m1[i, j] = Int32.Parse(tb[i, j].Text);
                    }
                }
                for (int i = 0; i < a2; i++)
                {
                    for (int j = 0; j < b2; j++)
                    {
                        m2[i, j] = Int32.Parse(tb2[i, j].Text);
                    }
                }

                double[,] result = MatrixMath.ScaleMatrix(m1, double.Parse(tb2[0,0].Text));
                displayMatrix(result);
            }
        }

        private static void displayMatrix(double[,] resultMatrix)
        {
            string result = string.Empty;
            if (resultMatrix == null) return;
            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    result += resultMatrix[i, j].ToString() + ", ";
                   // Console.Write(resultMatrix[i, j] + " ");
                }
                result += "\n";
               // Console.WriteLine();
            }
            MessageBox.Show(result);
           // Console.ReadLine();
        }
    }
}
