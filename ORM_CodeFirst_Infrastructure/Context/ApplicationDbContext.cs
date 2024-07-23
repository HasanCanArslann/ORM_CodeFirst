using Microsoft.EntityFrameworkCore;
using ORM_CodeFirst_Domain.Entities;
using ORM_CodeFirst_Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_CodeFirst_Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // Kullanılan Database'e göre connection stringlere www.connectionstrings.com adresinden ulaşabilir, Server adı ve Database adını güncelleyerek kullanabilirsiniz.


            optionsBuilder.UseSqlServer("Server=DESKTOP-64P9140\\SQLEXPRESS;Database=ORM_CodeFirst;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuration işlemleri farklı metodlar ile yapılabilir Bunlar,

            //1-) Configuration işlemlerininin hespini burada yapabiliriz. Eğer bu metod ile ilerlemeyi düşünüyorsak Configurations klasörü ve içerisindeki configuration class'larına ihtiyacımız kalmamaktadır. Çünkü bütün işlemler burada yapılacaktır.

            modelBuilder.Entity<Author>().Property(x => x.FullName).IsRequired().HasMaxLength(64);
            modelBuilder.Entity<Book>().Property(x => x.Name).IsRequired().HasMaxLength(128);
            modelBuilder.Entity<Book>().Property(x => x.Description).IsRequired().HasMaxLength(128);
            base.OnModelCreating(modelBuilder);

            // 2-) Bu metodda oluşturmuş olduğumuz configuration class'larını buraya çağırarak configuration yaparız. Sadece configuration class'ları çağırıldığı için burada kod kalabalığı oluşmaz.

            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());


            // 3-) Assembly ile tüm configurationları tek satırda oluşturma.

            // Burada  Configurations klasörüne eklemiş olduğumuz ' IEntityConfiguration' adlı interface'i kullanarak, bu interface'in bulunduğu klasördeki tüm configuration'ları oluşturması sağlıyoruz. Bu metodda tek tek configuration yazmak yerine toplu şekilde yapıyoruz.

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityConfiguration).Assembly);
        }



        // Buradaki işlemlerimizi tamamladıktan sonra Package Manager Console üzerinden  add-migration (herhangi bir isim veya harf) ve update-database komutları ile SQL bağlantısını sağlamış oluyoruz.


        /*
         Migration işlemleri için NuGet Package üzerinden, 
         * Microsoft.EntityFrameworkCore.Tools
         * Microsoft.EntityFrameworkCore.SqlServer
         * Microsoft.EntityFrameworkCore.Design
         peketlerinin indirilmesi gerekmektedir.
        */

    }


}
