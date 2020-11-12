using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;

namespace PresentationLayer
{
    public partial class BrandForm : Form
    {
        public BrandForm()
        {
            InitializeComponent();
        }
        string id;
        Boolean editable = false;
        BBrand bb = new BBrand();
        EBrand eb = new EBrand();
        private void BrandForm_Load(object sender, EventArgs e)
        {
            ShowTableData("");
            TableActions();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        

        public void ShowTableData(string search)
        {
            BrandTable.DataSource = bb.ListBrands(search);
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void TableActions()
        {
            BrandTable.Columns[0].Visible = false;
            BrandTable.Columns[1].Width = 105;
            BrandTable.Columns[2].Width = 135;
            BrandTable.ClearSelection();

        }
        public void ClearText()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtDescription.Text = "";
            TableActions();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(editable == false)
            {
                eb.Name = txtName.Text.ToUpper();
                eb.Description = txtDescription.Text.ToUpper();
                bb.InsertBrand(eb);
                ShowTableData("");
                ClearText();
                SuccessForm.ConfirmForm("Datos guardados","Los datos se han guardado correctamente.");
            }
            if(editable == true)
            {
                try
                {
                    eb.Id = Convert.ToInt32(id);
                    eb.Name = txtName.Text.ToUpper();
                    eb.Description = txtDescription.Text.ToUpper();
                    bb.UpdateBrand(eb);
                    ShowTableData("");
                    ClearText();
                    editable = false;
                    SuccessForm.ConfirmForm("Cambios guardados","Se han guardado los cambios correctamente.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error: " + ex.Message);
                }
                
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(BrandTable.SelectedRows.Count > 0)
            {
                id = BrandTable.CurrentRow.Cells[0].Value.ToString();
                txtCode.Text = BrandTable.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = BrandTable.CurrentRow.Cells[2].Value.ToString();
                txtDescription.Text = BrandTable.CurrentRow.Cells[3].Value.ToString();
                editable = true;
            }
            else
            {
                MessageBox.Show("Debes seleccionar una marcar para editar.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            if(BrandTable.SelectedRows.Count > 0)
            {
                try
                {
                    DialogResult result = new DialogResult();
                    ConfirmationForm cform = new ConfirmationForm("Eliminar", "Eliminarás esta marca. ");
                    result = cform.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        eb.Id = Convert.ToInt32(BrandTable.CurrentRow.Cells[0].Value.ToString());
                        bb.DeleteBrand(eb);
                        ShowTableData("");
                        TableActions();
                        SuccessForm.ConfirmForm("Datos eliminados", "Se han eliminado los datos correctamente.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al eliminar la marca: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar la marca que desea eliminar.");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            editable = false;
            ClearText();
        }
    }
}
