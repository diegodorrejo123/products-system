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
    public partial class MainForm : Form
    {

        private new Form ActiveForm = null;
        
        public MainForm()
        {
            InitializeComponent();
        }
        public void ScreenMode()
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dres = new DialogResult();
            Form message = new ConfirmationForm("Salir","¿Seguro que desea salir del sistema?");
            dres = message.ShowDialog();
            if(dres == DialogResult.OK)
            {
                Application.Exit();
                this.Hide();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FollowButton((Bunifu.Framework.UI.BunifuFlatButton)btnDashboard);
            OpenFormOnWrapper(new DashboardForm());
            ScreenMode();
        }

        public void SelectingButtons(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
            btnDashboard.Textcolor = Color.White;
            btnProducts.Textcolor = Color.White;
            btnSales.Textcolor = Color.White;
            btnShopping.Textcolor = Color.White;
            btnEmployees.Textcolor = Color.White;
            btnClients.Textcolor = Color.White;
            btnProviders.Textcolor = Color.White;
            btnEarnings.Textcolor = Color.White;
            sender.selected = true;
            if (sender.selected)
            {
                sender.Textcolor = Color.Green;
            }
        }

        public void FollowButton(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
            selectedd.Top = sender.Top+3;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SelectingButtons((Bunifu.Framework.UI.BunifuFlatButton)sender);
            FollowButton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            OpenFormOnWrapper(new DashboardForm());
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            SelectingButtons((Bunifu.Framework.UI.BunifuFlatButton)sender);
            FollowButton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            SelectingButtons((Bunifu.Framework.UI.BunifuFlatButton)sender);
            FollowButton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            OpenFormOnWrapper(new ProductsForm());
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            SelectingButtons((Bunifu.Framework.UI.BunifuFlatButton)sender);
            FollowButton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }

        private void btnShopping_Click(object sender, EventArgs e)
        {
            SelectingButtons((Bunifu.Framework.UI.BunifuFlatButton)sender);
            FollowButton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            SelectingButtons((Bunifu.Framework.UI.BunifuFlatButton)sender);
            FollowButton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }

        private void btnProviders_Click(object sender, EventArgs e)
        {
            SelectingButtons((Bunifu.Framework.UI.BunifuFlatButton)sender);
            FollowButton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }

        private void btnEarnings_Click(object sender, EventArgs e)
        {
            SelectingButtons((Bunifu.Framework.UI.BunifuFlatButton)sender);
            FollowButton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }
        private void OpenFormOnWrapper(Form ChildForm)
        {
            if(ActiveForm != null)
            {
                ActiveForm.Close();
            }
            ActiveForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.Dock = DockStyle.Fill;
            pWrapper.Controls.Add(ChildForm);
            pWrapper.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
    }
}
