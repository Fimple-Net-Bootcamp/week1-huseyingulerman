using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kutuphane_Yonetim_Sistemi_Odev_1
{
    public class Literature
    {
        private int _Id;
        private string _Name, _Writer;
        private DateTime _YearOfPublication;
        public int Id { get { return _Id; } set { _Id=value; } }
        public string Name { get { return _Name; } set { _Name=value; } }
        public string Writer { get { return _Writer; } set { _Writer=value; } }
        public DateTime YearOfPublication { get { return _YearOfPublication; } set { _YearOfPublication=value; } }
        public Literature(int id, string name, string writer)
        {
            _Id=id;
            _Name=name;
            _Writer=writer;
            _YearOfPublication=DateTime.Now;
        }
    }
}
