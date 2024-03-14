using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemo
{
    //Veri tabanında veri silme, ekleme, güncelleme işlemlerini yapacağımız yer burasıdır.
    internal class ProductDal
    {
        //class'ın içinde parametrelerin dışında bi kullanım yaptığımız için alt çizgi isimlendirme kuralı ile değiştiriyoruz.
        //SqlConnection connection = new SqlConnection(@"server=(localdb)\mssqllocaldb; initial catalog=ETrade;integrated security=true");

        SqlConnection _connection = new SqlConnection(@"server=(localdb)\mssqllocaldb; initial catalog=ETrade;integrated security=true");

        public List<Product> GetAll2()
        {
            //Bağlantı Kontrolünü de method içine aldık
            //if (_connection.State==ConnectionState.Closed)
            //{
            //    _connection.Open();
            //}
            ConnectionControl();


            SqlCommand command = new SqlCommand("Select * from Products",_connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Product> products = new List<Product>();

            //reader.Read() metodu şu anlama geliyor gelen verileri tek tek oku okuyabildiğin sürece döngüyü devam ettir
            while (reader.Read())
            {
                Product product = new Product
                {
                    //kısaca her okunulan elemanı producta aktarıyorum onu da listeye ekliyorum 
                    //en sonunda da o listeyi döndürüyorum
                    Id = Convert.ToInt32(reader["ID"]),
                    Name = reader["Name"].ToString(),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                };
                //ürünü oluşturduk ama kullanmadık henüz şimdi aşağıdaki line'da bu kodu yazıcaz
                products.Add(product);
            }

            reader.Close();
            _connection.Close();

            return products;
        }

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public DataTable GetAll()
        {
            //@ string ifade içindeki her şeyi string kabul et demektir.
            
            //SqlConnection connection = new SqlConnection(@"server=(localdb)\mssqllocaldb; initial catalog=ETrade;integrated security=true");
            
            //kendi bilgisayarımızıdaki kullanıcı kimliğinden ulaşım sağlayacaksak integrated security'yi true yapıyoruz.Başka bilgisayardan ulaşım sağlıyacaksak ise
            //uid=engin;password=12345 giirişi yapıyoruz.
            //şuan bağlantı nesnesi oluşturduk bağlantıyı açmadık.
            if (_connection.State == ConnectionState.Closed)
            {
                //Eğer bağlantı kapalıysa bağlantıyı aç diyoruz burada
                _connection.Open();
            }
            //Sql server ile iletişim kurmanın bir yöntemi var o da sql dediğimiz query language dediğimiz dille iletişim kuruyoruz
            //bu dili çalıştırmak için sqlcommand komutundan yararlanıyoruz.
            //"Select * from Products" diye bir sorgumuz var ve bunu connection'a gönderiyoruz
            SqlCommand command = new SqlCommand("Select * from Products", _connection);
            //şimdi komutu da oluştuduk ama bunu bir de çalıştırmamız lazım onun kodunu yazalım.
            //Verileri gösteren select * from komutunu çalışırmak için aşağıdaki line'ı kullanıyoruz
            SqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();
            //IDataReader sqldatareader'ın base'i dir.
            dataTable.Load(reader);
            //data'yı yolladıktan sonra da yapılması gerekn işlemler vardır
            reader.Close();
            _connection.Close();

            //Burada datatable ile çalıştık ama günümüzde datatable kullanılmaz ve kullanılmaması gerekir
            //Datatable cell leştirme özelliği olmayan bir nesnedir bu yüzden ya hiç kullanılmaz ya da datalayer da kullanılığ değiştirilebilir.

            return dataTable;
        }

        public void Add(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand
                ("Insert into Products values(@name,@unitPrice,@stockAmount)",_connection);

            //eğer parametre varsa şöyle bir değer yazıyoruz.Eğer string birleştirerek yaparsak sql enjection denilen saldırıya mağruz kalırız
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Update(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand
                ("Update Products Set Name=@name,UnitPrice=@unitPrice, StockAmount=@stockAmount where ID=@id", _connection);

            //eğer parametre varsa şöyle bir değer yazıyoruz.Eğer string birleştirerek yaparsak sql enjection denilen saldırıya mağruz kalırız
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.Parameters.AddWithValue("@id", product.Id);
            command.ExecuteNonQuery();

            _connection.Close();
        }

        //Burada bir silme işlemi yapıcaz silme işlemini bir ürünün id'si üzerinden yapıcaz
        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand
                ("Delete from Products where Id=@id", _connection);

            //eğer parametre varsa şöyle bir değer yazıyoruz.Eğer string birleştirerek yaparsak sql enjection denilen saldırıya mağruz kalırız
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
