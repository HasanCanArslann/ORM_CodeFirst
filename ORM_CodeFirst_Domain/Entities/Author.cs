using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_CodeFirst_Domain.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }

        //Navigation Properties = Tablolar arasında ilişki kurulması için yazılır. 

        //Burada bir yazara ait birden fazla kitap olduğunu belirtmek için collection tutuyoruz.

        public IEnumerable<Book> Books { get; set; }
    }
}
