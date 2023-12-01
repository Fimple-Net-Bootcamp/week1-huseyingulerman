using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Yonetim_Sistemi_Odev_1
{
    public class Member
    {
        private string _FirstName, _LastName;
        private List<Book> _Books;
        private int _MemberNo;
        public string FirstName { get { return _FirstName; } set { _FirstName=value; } }
        public string LastName { get { return _LastName; } set { _LastName=value; } }
        public int MemberNo { get { return _MemberNo; } set { _MemberNo=value; } }
        public List<Book> Books { get { return _Books; } set { _Books=value; } }
    }
}
