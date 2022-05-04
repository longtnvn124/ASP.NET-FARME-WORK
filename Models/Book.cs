using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestBaiThi1.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public string NamXB { get; set; }

        public string ImageCover { get; set; }

    }
}