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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pnlSeats_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TRAVEGO 12 SIRA
            //NEOPLAN 13 SIRA
            //TRAVEGO LARGE 14 SIRA (SON SIRA 5'Lİ KOLTUK)
            //RAHAT2+1 12 SIRA (2+1)

            //cmbBus.Items.Add("TRAVEGO");
            //cmbBus.Items.Add("NEOPLAN");
            //cmbBus.Items.Add("TRAVEGO LARGE");
            //cmbBus.Items.Add("RAHAT 2+1");

            cmbBus.Items.AddRange(new string[] { "TRAVEGO", "NEOPLAN", "TRAVEGO LARGE", "RAHAT 2+1" });
            cmbBus.SelectedIndex = 0;





        }

        private void cmbBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int order = 12;
            bool isLarge = false, isComfort = false;

            switch (cmbBus.SelectedIndex)
            {
                case 0: break;
                case 1: order = 13; break;
                case 2: order = 14; isLarge = true; break;
                default: isComfort = true; break;
            }
            LoadSeats(order,isComfort, isLarge);
        }

        private void LoadSeats(int order, bool isComfort, bool isLarge)
        {
            pnlSeats.Controls.Clear();
            Button Seat;
            int size = 40, seatNumber = 1;

            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if ((j==2 && !isLarge) || ((j==2&&isLarge&&i<13)||(isComfort&& j==1)) || (i==6 && j>2)) continue;
                    Seat = new Button();
                    Seat.Name = "btn" + i + j;
                    Seat.Size=new Size(size,size);
                    Seat.Location= new Point(size * j+2,size * i+2);
                    Seat.Text=seatNumber++.ToString();
                    Seat.Font =new Font(FontFamily.GenericSansSerif,12);
                    Seat.Click += Seat_Click;
                    pnlSeats.Controls.Add(Seat);
                }
            }
        }

        private void Seat_Click(object sender, EventArgs e)
        {
            Button selected = sender as Button ;
            FrmRezervation frm= new FrmRezervation(selected);
            frm.ShowDialog();
                    
        }
    }
}
