using AlphaProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaProject.ViewModel
{
    public class Product_VM
    {
        public int id { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public int price { get; set; }
        public string group { get; set; }
        public Status status { get; set; }
        public string UserID { get; set; }
    }
}