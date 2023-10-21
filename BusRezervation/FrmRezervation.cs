using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusRezervation
{
    public partial class FrmRezervation : Form
    {
        Button passenger;
        public FrmRezervation(Button selected)
        {
            InitializeComponent();
            passenger = selected;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FrmRezervation_Load(object sender, EventArgs e)
        {
            this.Text=passenger.Text+" No'lu koltuk";
            if(passenger.Tag !=null)
            {
                txtNameSurname.Text=passenger.Tag.ToString();
                
                if (passenger.BackColor==Color.Aqua)
                {
                    rbtnMale.Checked=true;
                }
                else
                {
                    rbtnFemale.Checked=true;
                }
                btnRezCancel.Visible=true;
                btnOk.Text = "UPDATE";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            passenger.Tag= txtNameSurname.Text;

            if (rbtnMale.Checked)
            {
                passenger.BackColor=Color.Aqua;
            }
            else
            {
                passenger.BackColor=Color.Pink;
            }
            this.Close();   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRezCancel_Click(object sender, EventArgs e)
        {
            passenger.Tag = null;
            btnRezCancel.Visible=false;
            passenger.BackColor=SystemColors.Control;
            passenger.UseVisualStyleBackColor=true;
            this.Close();
        }
    }
}
