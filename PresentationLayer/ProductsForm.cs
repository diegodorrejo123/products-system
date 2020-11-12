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
    public partial class ProductsForm : Form
    {
        BProducts bprod = new BProducts();
         
        public ProductsForm()
        {
            InitializeComponent();
            ShowTableData();
            HideMoveColumns();
        }

        
        public void ShowTableData()
        {
            ProductsTable.DataSource = bprod.ListProducts();
            ShowTotal();


        }

        public void HideMoveColumns()
        {

            ProductsTable.Columns[2].Visible = false;
            ProductsTable.Columns[5].Visible = false;
            ProductsTable.Columns[7].Visible = false;


            ProductsTable.Columns[0].Width = 150; // Editar
            ProductsTable.Columns[1].Width = 150; // Eliminar
            ProductsTable.Columns[0].DisplayIndex = 11;
            ProductsTable.Columns[1].DisplayIndex = 11;

            ProductsTable.Columns[3].Width = 70; // Codigo
            ProductsTable.Columns[4].Width = 250; // Nombre
            ProductsTable.Columns[5].Width = 200; // Precio compra
            ProductsTable.Columns[6].Width = 200; // Precio venta



        }

        public void SearchProducts(string search)
        {
            try
            {
                ProductsTable.DataSource = bprod.SearchProducts(search);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al listar los datos: " + ex.Message);
            }
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(txtSearch.Text);
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            ProductMaintenanceForm pdm = new ProductMaintenanceForm();
            pdm.ShowDialog();
            pdm.Update = false;
            ShowTableData();
        }
        public void ShowTotal()
        {
            EProducts eprod = new EProducts();
            BProducts bprod = new BProducts();
            bprod.ShowTotals(eprod);
            lblTotalCategories.Text = eprod.TotalCategories;
            lblTotalProducts.Text = eprod.TotalProducts;
            lblTotalBrands.Text = eprod.TotalBrands;
            lblTotalStock.Text = eprod.TotalStock;

        }

        private void ProductsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ProductsTable.Rows[e.RowIndex].Cells["Delete"].Selected)
            {
                Form Message = new ConfirmationForm("Eliminar", "¿Seguro que desea eliminar este producto?");
                DialogResult dr = Message.ShowDialog();
                if(dr == DialogResult.OK)
                {
                    int delete = Convert.ToInt32(ProductsTable.Rows[e.RowIndex].Cells[2].Value.ToString());
                    bprod.DeleteProduct(delete);
                    SuccessForm.ConfirmForm("Eliminado", "Producto eliminado correctamente.");
                    ShowTableData();
                }
            }
            else if (ProductsTable.Rows[e.RowIndex].Cells["Edit"].Selected)
            {
                ProductMaintenanceForm pm = new ProductMaintenanceForm();
                pm.Update = true;
                pm.txtId.Text = ProductsTable.Rows[e.RowIndex].Cells["id"].Value.ToString();
                pm.txtCode.Text = ProductsTable.Rows[e.RowIndex].Cells["code"].Value.ToString();
                pm.txtName.Text = ProductsTable.Rows[e.RowIndex].Cells["name"].Value.ToString();
                pm.txtPurchase_price.Text = ProductsTable.Rows[e.RowIndex].Cells["purchase_price"].Value.ToString();
                pm.txtSale_price.Text = ProductsTable.Rows[e.RowIndex].Cells["sale_price"].Value.ToString();
                pm.txtStock.Text = ProductsTable.Rows[e.RowIndex].Cells["stock"].Value.ToString();
                pm.cmCategory.Text = ProductsTable.Rows[e.RowIndex].Cells["category"].Value.ToString();
                pm.cmBrand.Text = ProductsTable.Rows[e.RowIndex].Cells["brand"].Value.ToString();
                pm.ShowDialog();
                ShowTableData();
            }
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets[1];
            worksheet.Name = "Products";

            for (int i = 3; i < ProductsTable.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = ProductsTable.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < ProductsTable.Rows.Count; i++)
            {
                for(int j = 0; j < ProductsTable.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = ProductsTable.Rows[i].Cells[j].Value.ToString();
                }
            }
            app.Visible = true;
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            CategoryForm cform = new CategoryForm();
            cform.ShowDialog();
        }

        private void btnBrands_Click(object sender, EventArgs e)
        {
            BrandForm bform = new BrandForm();
            bform.ShowDialog();
        }
    }
}
