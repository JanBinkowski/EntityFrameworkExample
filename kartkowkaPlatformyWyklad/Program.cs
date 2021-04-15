using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace kartkowkaPlatformyWyklad
{   
    public class Produkt
    {
        public int ID { set; get; }
        public string Nazwa { set; get; }
        public float Cena { set; get; }
    }

    public class Sklep : DbContext
    {
        public virtual DbSet<Produkt> Produkts { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var context = new Sklep();
            context.Produkts.Add(new Produkt { Nazwa = "Chleb", Cena = 2.32f });
            context.Produkts.Add(new Produkt { Nazwa = "Maslo", Cena = 5.89f });
            context.SaveChanges();

            var produkts = (from s in context.Produkts select s).ToList<Produkt>();
            foreach (var pr in produkts)
            {
                Console.WriteLine("ID: {0}, Nazwa: {1}, Cena: {2:0.00} pln", pr.ID, pr.Nazwa, pr.Cena);
            }
            Console.ReadKey();
        }
    }
}
