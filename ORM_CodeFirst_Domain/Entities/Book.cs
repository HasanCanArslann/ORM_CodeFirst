using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_CodeFirst_Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Navigation Properties = Tablolar arasında ilişki kurulması için yazılır. 

        //Burada bir kitaba ait bir yazar olduğunu belirmek için yazarın nesnesini ve Id'sini tutuyoruz.

        public Author Author { get; set; }
        public Guid AuthorId { get; set; }

    }
}
