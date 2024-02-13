using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsCalculator
{
    public partial class Form1 : Form
    {
        double resultValue = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '.':
                    button_click(GetButtonByValue(e.KeyChar.ToString()), EventArgs.Empty);
                    break;
                case '+':
                case '-':
                case '*':
                case '/':
                    operator_click(GetButtonByValue(e.KeyChar.ToString()), EventArgs.Empty);
                    break;
                case '=':
                    button19_Click(button19, EventArgs.Empty);
                    break;
                case (char)Keys.Enter:
                    button19_Click(button19, EventArgs.Empty);
                    break;
                case (char)Keys.Back:
                    button16_Click(button16, EventArgs.Empty);
                    break;
                default:
                    break;
            }
        }

        private Button GetButtonByValue(string value)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button && button.Text == value)
                {
                    return button;
                }
            }
            return null;
        }

        private void button_click(object sender, EventArgs e)
        {
            if (tbDisplayResult.Text == "0" || isOperationPerformed)
                tbDisplayResult.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!tbDisplayResult.Text.Contains("."))
                {
                    tbDisplayResult.Text += button.Text;
                }
            }
            else
            {
                tbDisplayResult.Text += button.Text;
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operationPerformed = button.Text;
            resultValue = Convert.ToDouble(tbDisplayResult.Text);
            lbCurrentOp.Text += resultValue + " " + operationPerformed;
            isOperationPerformed = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            tbDisplayResult.Text = "0";
            resultValue = 0;
            lbCurrentOp.Text = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            tbDisplayResult.Text = "0";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    tbDisplayResult.Text = Convert.ToString(resultValue + Convert.ToDouble(tbDisplayResult.Text));
                    break;

                case "-":
                    tbDisplayResult.Text = Convert.ToString(resultValue - Convert.ToDouble(tbDisplayResult.Text));
                    break;

                case "*":
                    tbDisplayResult.Text = Convert.ToString(resultValue * Convert.ToDouble(tbDisplayResult.Text));
                    break;

                case "/":
                    tbDisplayResult.Text = Convert.ToString(resultValue / Convert.ToDouble(tbDisplayResult.Text));
                    break;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (tbDisplayResult.Text.Length > 0)
            {
                tbDisplayResult.Text = tbDisplayResult.Text.Remove(tbDisplayResult.Text.Length - 1, 1);
            }
            if(tbDisplayResult.Text == "")
            {
                tbDisplayResult.Text = "0";
;            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            lbCurrentOp.Text = $"({tbDisplayResult.Text})^2";
            tbDisplayResult.Text = Convert.ToString(Convert.ToDouble(tbDisplayResult.Text) * Convert.ToDouble(tbDisplayResult.Text));
        }

        private void button20_Click(object sender, EventArgs e)
        {
            lbCurrentOp.Text = $"SQRT({tbDisplayResult.Text})";
            tbDisplayResult.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(tbDisplayResult.Text)));
        }
    }
}