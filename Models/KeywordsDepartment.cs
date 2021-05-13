using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class KeywordsDepartment
    {
        [Key]
        public int KeywordID { get; set; }
        public string Keyword { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
    }
}