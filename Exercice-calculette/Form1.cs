using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercice_calculette
{
    public partial class Form1 : Form
    {
        string operateur = "";
        double resultvalue = 0;
        bool isoperation = false;

        #region Constructor
        public Form1()  
        {
            InitializeComponent();
        }
        #endregion

        #region numbers button
        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (txtAffiche.Text == "0" || isoperation)
            {
                txtAffiche.Clear();
            }
            isoperation = false;
            Button btn = (Button)sender;
            if (btn.Text == ".")
            {
                if(!txtAffiche.Text.Contains("."))
                    txtAffiche.Text = txtAffiche.Text + btn.Text;
            }
            else
            txtAffiche.Text = txtAffiche.Text + btn.Text;
        }
        #endregion

        #region Operations button
        private void btnOperation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (resultvalue != 0)
            {
                btnegale.PerformClick();
                operateur = btn.Text;
                lbl1.Text = resultvalue + " " + operateur;
                isoperation = true;
            }
            else
            {
                operateur = btn.Text;
                resultvalue = double.Parse(txtAffiche.Text);
                lbl1.Text = resultvalue + " " + operateur;
                isoperation = true;
            }
        }


        private void btnegale_Click(object sender, EventArgs e)
        {
        
            switch (operateur)
            {
                case "+":
                    txtAffiche.Text = (resultvalue + double.Parse(txtAffiche.Text)).ToString();
                    break;
                case "-":
                    txtAffiche.Text = (resultvalue - double.Parse(txtAffiche.Text)).ToString();
                    break;
                case "*":
                    txtAffiche.Text = (resultvalue * double.Parse(txtAffiche.Text)).ToString();
                    break;
                case "/":
                    txtAffiche.Text = (resultvalue / double.Parse(txtAffiche.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultvalue = double.Parse(txtAffiche.Text);
            lbl1.Text = "";
        }
        private void btnPlusMoins_Click(object sender, EventArgs e)
        {
            if (txtAffiche.Text.Contains("-"))
            {
                txtAffiche.Text = txtAffiche.Text.Trim('-');

            }
            else
            {
                txtAffiche.Text = "-" + txtAffiche.Text;
            }
        }
        #endregion

        #region Methods
        private void btnCE_Click(object sender, EventArgs e)
        {
            txtAffiche.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtAffiche.Text = "0";
            resultvalue = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (this.txtAffiche.Text.Length >0)
            {
                txtAffiche.Text = txtAffiche.Text.Remove(txtAffiche.Text.Length - 1, 1);
            }
            if (txtAffiche.Text == "")
            {
                txtAffiche.Text = "0"; 
            } 
        }

        

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Button button1 = new Button();
            button1.Text = e.KeyChar.ToString();
            if(e.KeyChar>= 48 && e.KeyChar <= 57)
            {
                btnNumber_Click(button1, e);
            }
            string operand = "/*+-";
            if (operand.Contains(e.KeyChar))
            {
                btnOperation_Click(button1, e);
            }
            if (e.KeyChar == '=')
            {
                btnegale_Click(button1, e);
            }
            if(e.KeyChar=='\r')
            {
                button1.Text = "=";
                btnegale_Click(button1, e);
            }
        }
#endregion
    }
}
