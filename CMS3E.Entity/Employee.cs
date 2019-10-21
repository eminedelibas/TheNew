using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CMS.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Linkedln { get; set; }
    }
}
