using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApplication.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Question")]
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}