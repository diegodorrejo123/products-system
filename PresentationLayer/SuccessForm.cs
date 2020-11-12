using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class SuccessForm : Form
    {
        public SuccessForm(string mes1,string mes2)
        {
            InitializeComponent();
            lblMes1.Text = mes1;
            lblMes2.Text = mes2;
        }

        private void SuccessForm_Load(object sender, EventArgs e)
        {
        }
        public static void ConfirmForm(string mes1, string mes2)
        {
            SuccessForm SForm = new SuccessForm(mes1,mes2);
            SForm.ShowDialog();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
