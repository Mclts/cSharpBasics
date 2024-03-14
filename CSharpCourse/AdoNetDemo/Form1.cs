﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            //ProductDal'ı tekrar tekrar newlemeyelim diye yukarı yazdım
            //ProductDal productDal = new ProductDal();
            //dgwProducts'ın veri kaynağı olarak productDal daki getAll methodunu gösterdim aşağıda
            //Tabloyu güncelledikten sonra güncellenmiş halini de ekrana getirmek için değişiklik yapıyoruz
            //dgwProducts.DataSource = _productDal.GetAll();

            LoadProducts();
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            _productDal.Add(new Product
            {
                Name=tbxName.Text,
                UnitPrice=Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount=Convert.ToInt32(tbxStockAmount.Text)
            });

            //Güncelleme işlemi yapması için LoadProducts methodunu çağırıyoruz
            LoadProducts();

            //Kullanıcıya ürünün girildiğini göstermek için şöyle bir method yazıyoruz
            MessageBox.Show("Product Added!");

        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Burada seçili olan elemanı ilgili textbox'a atamak istiyoruz...
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)
            };

            _productDal.Update(product);
            LoadProducts();
            MessageBox.Show("Update!!");
        }

        //Hangi kayıt seçildiyse o kayıtı silecek
        private void btnRemove_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);
            _productDal.Delete(id);

            LoadProducts();
            MessageBox.Show("Deleted!");

        }
    }
}
