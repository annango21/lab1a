using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace lab1a.Models
{
    [Table("Foo")]
    public class Genre
    {
        //SCALAR
       public int Id { get; set; }

        public string Name { get; set; }

    //NAV PROPERTY
    public ICollection<Movie> Movies { get; set; }
    }
}