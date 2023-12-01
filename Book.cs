using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Yonetim_Sistemi_Odev_1
{
    public class Book : Literature
    {
        public Book(int id, string name, string writer) : base(id, name, writer)
        {
        }
    }
}
