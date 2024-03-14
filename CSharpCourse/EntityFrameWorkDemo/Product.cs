using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkDemo
{
    //Entity Framework de en önemli kurallardan birisi sizin veritabanınızdaki tabloya karşılık gelen bir classınız olmasıdır
    //Bizim entityframework'e şunu söylememiz lazım bizim şu classımız veritabanındaki şu tabloya karşılık geliyor.
    //YoutubeWord tasarım deseni??
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }

    }
}
