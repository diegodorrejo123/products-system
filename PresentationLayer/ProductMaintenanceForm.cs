using BusinessLayer;
using EntityLayer;
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
    public partial class ProductMaintenanceForm : Form
    {
        public bool Update = false;
        EProducts product = new EProducts();
        BProducts bprod = new BProducts();
        public ProductMaintenanceForm()
        {
            InitializeComponent();
            FillComboCategory();
            FillComboBrand();
        }
        public void FillComboCategory()
        {
            BCategory bcat = new BCategory();
            cmCategory.DataSource = bcat.ListCategories("");
            cmCategory.ValueMember = "Id";
            cmCategory.DisplayMember = "Name";
        }
        public void FillComboBrand()
        {
            BBrand bbrand = new BBrand();
            cmBrand.DataSource = bbrand.ListBrands("");
            cmBrand.ValueMember = "Id";
            cmBrand.DisplayMember = "Name";
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Update == false)
            {
                try
                {
                    product.Name = txtName.Text;
                    product.Purchase_price = Convert.ToDecimal(txtPurchase_price.Text);
                    product.Sale_price = Convert.ToDecimal(txtSale_price.Text);
                    product.Stock = Convert.ToInt32(txtStock.Text);
                    product.Idcategory = Convert.ToInt32(cmCategory.SelectedValue);
                    product.Idbrand = Convert.ToInt32(cmBrand.SelectedValue);

                    bprod.InsertProduct(product);
                    SuccessForm.ConfirmForm("Guardado","Se ha guardado el producto correctamente");
                    Close();
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al guardar los datos: " + ex.Message);
                }
            }
            if(Update == true)
            {
                try
                {
                    product.Name = txtName.Text;
                    product.Id = Convert.ToInt32(txtId.Text);
                    product.Purchase_price = Convert.ToDecimal(txtPurchase_price.Text);
                    product.Sale_price = Convert.ToDecimal(txtSale_price.Text);
                    product.Stock = Convert.ToInt32(txtStock.Text);
                    product.Idcategory = Convert.ToInt32(cmCategory.SelectedValue);
                    product.Idbrand = Convert.ToInt32(cmBrand.SelectedValue);

                    bprod.UpdateProduct(product);
                    SuccessForm.ConfirmForm("Actualizado", "Se han actualizado los datos correctamente");
                    Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar los datos: " + ex.Message);
                }
            }
        }
    }
}
