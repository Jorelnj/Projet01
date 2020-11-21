using Projet01.Interfaces;
using Projet01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet01
{
    public partial class FrmProduct : Form
    {
        private bool isEditMode;
        private Product oldProduct;

        private IProductRepository productRepository { get; }
        public FrmProduct(IProductRepository productRepository)
        {
            InitializeComponent();
            this.productRepository = productRepository;
            dataGridView1.AutoGenerateColumns = false;
        }
        private void LoadGrid(IEnumerable<Product> products)
        {           
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = products;
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product
                (
                    txtReference.Text, 
                    txtName.Text, 
                    double.Parse(txtPrice.Text),
                    (float)nudTax.Value
                );
                if(this.oldProduct == null)
                    this.productRepository.Add(product, LoadGrid);
                else
                    this.productRepository.Set(this.oldProduct, product, LoadGrid);
                //LoadGrid(this.productRepository.GetAll());
                MessageBox.Show
                (
                    "Save done",
                    "Confirmation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                this.oldProduct = null;
                txtPrice.Clear();
                txtName.Clear();
                txtReference.Clear();
                nudTax.Value = 19,25M;
            }

            catch(Exception ex)
            {
                //TODO log error
                MessageBox.Show
                (
                    "An error occured",
                    "Error  ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                
            }
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            LoadGrid(this.productRepository.GetAll());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                List<Product> products = new List<Product>();
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    products.Add(dataGridView1.SelectedRows[i].DataBoundItem as Product);

                }
                this.productRepository.Delete(products, LoadGrid);
                MessageBox.Show
                (
                    "Delete done",
                    "Confirmation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.oldProduct = dataGridView1.SelectedRows[0].DataBoundItem as Product;
            txtPrice.Text = this.oldProduct.Price.ToString();
            txtName.Text = this.oldProduct.Name;
            txtReference.Text = this.oldProduct.Reference;
            nudTax.Value = (decimal) this.oldProduct.Tax;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.productRepository.Find
            (
                x => 
                x.Reference.ToLower().Contains(txtSearch.Text.ToLower()) ||
                x.Name.ToLower().Contains(txtSearch.Text.ToLower()),
                LoadGrid
             );
        }
    }
}
