using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkDemo
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.ToList();
            }
        }

        //Bu direkt veri tabanında sorgulama yapar yani daha performanslıdır.
        public List<Product> GetByName(string key)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.Name.Contains(key)).ToList();
            }
        }

        //İki fiyat aralığında bir şey aramak isteseydik linq ile
        public List<Product> GetByUnitPrice(decimal price)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //Veri tabanına sql sorgusu ataması yaptık linq ile
                return context.Products.Where(p => p.UnitPrice>=price).ToList();
            }
        }

        //İki fiyat arasında sorgulama yapar
        public List<Product> GetByUnitPrice(decimal min,decimal max)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //Veri tabanına sql sorgusu ataması yaptık linq ile
                return context.Products.Where(p => p.UnitPrice >= min && p.UnitPrice<=max).ToList();
            }
        }

        //Tek bir ürünü aramak istediğimizde
        public Product GetById(int id)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //data bulamazsan null data bulursan datanın direkt kendisini getir.
                // FirstOrDefault yerine SingleOrDefault da koyulabilir o da birden çok data bulursa hata döndürüyor.
                var result = context.Products.FirstOrDefault(p => p.Id == id);
                return result;
            }
        }

        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //1. Yazım Şekli
                //context.Products.Add(product);
                //context.SaveChanges();

                //2.Yazım Şekli
                var entity = context.Entry(product);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
