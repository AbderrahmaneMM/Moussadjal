using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moussadjal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        } 
        public void Errorprovider(Guna2TextBox x,string m)
        {
           ErrorProvider ep = new ErrorProvider();
            ep.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            ep.SetError(x,m);
            x.BorderColor = Color.Red;
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
