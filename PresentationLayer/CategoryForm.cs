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
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private string id;
        private bool Editable = false;
        ECategory eCat = new ECategory();
        BCategory bCat = new BCategory();
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            ShowTableData("");
            TableActions();
            
        }

        public void TableActions()
        {
            CategoryTable.Columns[0].Visible = false;
            CategoryTable.Columns[1].Width = 105;
            CategoryTable.Columns[2].Width = 135;
            CategoryTable.ClearSelection();
        }
        public void ShowTableData(string search)
        {
            CategoryTable.DataSource = bCat.ListCategories(search);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowTableData(txtSearch.Text);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        public void ClearText()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtDescription.Text = "";
            txtName.Focus();
            Editable = false;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            // BOTON DE EDITAR
            if(CategoryTable.SelectedRows.Count > 0)
            {
                id = CategoryTable.CurrentRow.Cells[0].Value.ToString();
                txtCode.Text = CategoryTable.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = CategoryTable.CurrentRow.Cells[2].Value.ToString();
                txtDescription.Text = CategoryTable.CurrentRow.Cells[3].Value.ToString();
                Editable = true;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una categoría.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Editable == false)
            {
                try
                {
                    
                    eCat.Code = txtCode.Text.ToUpper();
                    eCat.Name = txtName.Text.ToUpper();
                    eCat.Description = txtDescription.Text.ToUpper();
                    bCat.InsertCategory(eCat);
                    SuccessForm.ConfirmForm("Guardado", "La Categoría se guardó correctamente.");
                    ShowTableData("");
                    ClearText();
                    TableActions();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error: " + ex.Message);
                }
                
            }
            if(Editable == true)
            {
                try
                {
                    eCat.Id = Convert.ToInt32(id);
                    eCat.Code = txtCode.Text.ToUpper();
                    eCat.Name = txtName.Text.ToUpper();
                    eCat.Description = txtDescription.Text.ToUpper();
                    bCat.UpdateCategory(eCat);
                    SuccessForm.ConfirmForm("Actualizado", "La Categoría se actualizó correctamente.");
                    ShowTableData("");
                    ClearText();
                    Editable = false;
                    TableActions();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(CategoryTable.SelectedRows.Count > 0)
            {
                ClearText();
                try
                {
                    eCat.Id = Convert.ToInt32(CategoryTable.CurrentRow.Cells[0].Value.ToString());
                    bCat.DeleteCategory(eCat);
                    SuccessForm.ConfirmForm("Eliminado", "La Categoría se eliminó correctamente.");
                    ShowTableData("");
                    TableActions();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar la categoría que desea eliminar.");
            }
        }
    }
}
