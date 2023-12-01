using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Kutuphane_Yonetim_Sistemi_Odev_1
{

    public class Library : IPrintable
    {/// <summary>
    /// Program çalıştığı anda dataların tutulduğu liste
    /// </summary>
        private List<Book> books = new List<Book>();
        /// <summary>
        /// Program çalıştığı anda dataların tutulduğu liste
        /// </summary>
        private List<Member> members = new List<Member>();
        /// <summary>
        /// Program Yönetiminin Yapıldığı Metot
        /// </summary>
        public void Print()
        {
            SeedData();
            bool _continue = true;

            while (_continue)
            {
                Console.WriteLine("Lütfen Yapmak İstediğiniz İşlemi Seçiniz:");
                Console.WriteLine("***************************************");
                Console.WriteLine("(1) Yeni Kitap Ekleme");
                Console.WriteLine("(2) Varolan Kitabı Silmek");
                Console.WriteLine("(3) Kitap Ödünç Almak");
                Console.WriteLine("(4) Kitap İade Etmek");
                Console.WriteLine("(0) Programdan Çık");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        RemoveBook();
                        break;
                    case 3:
                        ToLend();
                        break;
                    case 4:
                        ToReturn();
                        break;
                    case 0:
                        _continue = false;
                        break;
                    default:
                        Console.WriteLine("Geçersiz bir seçim yaptınız.");
                        break;
                }
            }
            Console.WriteLine("Kitap sayısı:"+books.Count);
            Console.WriteLine("Üye sayısı:"+members.Count);
        }
        /// <summary>
        /// Kitap ekleme metodu
        /// </summary>
        private void AddBook()
        {
            Console.Write("Lütfen Kitap Id'si Giriniz: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Lütfen Kitap İsmi Giriniz: ");
            string name = Console.ReadLine();



            Console.Write("Lütfen Yazar İsmi Giriniz: ");
            string writer = Console.ReadLine();

            Book newBook = new Book(id, name, writer);
            books.Add(newBook);

            Console.WriteLine("Yeni Kitap Kaydedildi.");
        }
        /// <summary>
        /// Kitap silme metodu
        /// </summary>
        private void RemoveBook()
        {
            Console.Write("Lütfen Silmek İstediğiniz Kitabın Adını Giriniz: ");
            string search = Console.ReadLine();

            Book foundPerson = books.FirstOrDefault(book =>
                book.Name.Equals(search, StringComparison.OrdinalIgnoreCase));

            if (foundPerson == null)
            {
                Console.WriteLine("Aradığınız Kriterlere Uygun Veri Bulunamadı.");
                Console.WriteLine("Lütfen Bir Seçim Yapınız:");
                Console.WriteLine("(1) Silmeyi Sonlandırmak İçin");
                Console.WriteLine("(2) Yeniden Denemek İçin");

                int _continue = int.Parse(Console.ReadLine());

                switch (_continue)
                {
                    case 1:
                        break;
                    case 2:
                        RemoveBook();
                        break;
                    default:
                        Console.WriteLine("Geçersiz Bir Seçim Yaptınız.");
                        break;
                }
            }
            else
            {
                Console.Write($"{foundPerson.Name} İsimli Kitap Silinmek Üzere, Onaylıyor Musunuz? (y/n): ");
                string approval = Console.ReadLine();

                if (approval.Equals("y", StringComparison.OrdinalIgnoreCase)||approval.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    books.Remove(foundPerson);
                    Console.WriteLine("Kitap Silindi.");
                }
                else
                {
                    Console.WriteLine("İşlem İptal Edildi.");
                }
            }
        }
        /// <summary>
        /// Üyenin kitap ödünç alma işlemlerinin yapıldığı metot
        /// </summary>
        public void ToLend()
        {
            Console.Write("Lütfen Ödünç Almak İstediğiniz Kitabın Adını Giriniz: ");
            string search = Console.ReadLine();
            Console.Write("Lütfen Üye Id'si Giriniz: ");
            int searchMember = int.Parse(Console.ReadLine());


            Book foundBook = books.FirstOrDefault(book =>
                book.Name.Equals(search, StringComparison.OrdinalIgnoreCase));

            Member foundMember = members.FirstOrDefault(x => x.MemberNo==searchMember);

            if (foundBook == null || foundMember==null)
            {
                Console.WriteLine("Aradığınız Kriterlere Uygun Veri Bulunamadı.");
                Console.WriteLine("Lütfen Bir Seçim Yapınız:");
                Console.WriteLine("(1) Ödünç Almayı Sonlandırmak İçin");
                Console.WriteLine("(2) Yeniden Denemek İçin");

                int _continue = int.Parse(Console.ReadLine());

                switch (_continue)
                {
                    case 1:
                        break;
                    case 2:
                        ToLend();
                        break;
                    default:
                        Console.WriteLine("Geçersiz Bir Seçim Yaptınız.");
                        break;
                }
            }
            else
            {
                Console.Write($"{foundBook.Name} İsimli Kitap Ödünç Alınmak Üzere, Onaylıyor Musunuz? (y/n): ");
                string approval = Console.ReadLine();

                if (approval.Equals("y", StringComparison.OrdinalIgnoreCase)||approval.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    foundMember.Books.Add(foundBook);
                    books.Remove(foundBook);
                    Console.WriteLine("Kitap Ödünç Alındı.");
                }
                else
                {
                    Console.WriteLine("İşlem İptal Edildi.");
                }
            }
        }
        /// <summary>
        /// Üyenin kitap iadesi işlemlerinin yapıldığı metot
        /// </summary>
        public void ToReturn()
        {
            Console.Write("Lütfen İade Etmek İstediğiniz Kitabın Adını Giriniz: ");
            string search = Console.ReadLine();
            Console.Write("Lütfen Üye Id'si Giriniz: ");
            int searchMember = int.Parse(Console.ReadLine());

            Member foundMember = members.FirstOrDefault(x => x.MemberNo==searchMember);
            var foundBook1 = foundMember.Books.FirstOrDefault(x =>
                  x.Name==search);
            if (foundBook1==null || foundMember==null)
            {
                Console.WriteLine("Aradığınız Kriterlere Uygun Veri Bulunamadı.");
                Console.WriteLine("Lütfen Bir Seçim Yapınız:");
                Console.WriteLine("(1) İade Etmeyi Sonlandırmak İçin");
                Console.WriteLine("(2) Yeniden Denemek İçin");

                int _continue = int.Parse(Console.ReadLine());

                switch (_continue)
                {
                    case 1:
                        break;
                    case 2:
                        ToReturn();
                        break;
                    default:
                        Console.WriteLine("Geçersiz Bir Seçim Yaptınız.");
                        break;
                }
            }
            else
            {


                Console.Write($"{search} İsimli Kitap İade Edilmek Üzere, Onaylıyor Musunuz? (y/n): ");
                string approval = Console.ReadLine();

                if (approval.Equals("y", StringComparison.OrdinalIgnoreCase)||approval.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {


                    var foundBook = foundMember.Books.FirstOrDefault(x =>
                   x.Name==search);
                       foundMember.Books.Remove(foundBook);
                        books.Add(foundBook);
                        Console.WriteLine("Kitap İade Edildi.");
                }
                else
                {
                    Console.WriteLine("İşlem İptal Edildi.");
                }
            }
        }
        /// <summary>
        /// Program başlangıcında data eklemesinin yapıldığı metot
        /// </summary>

        public void SeedData()
        {
            Member member = new Member()
            {
                FirstName="Hüseyin",
                LastName="Gülerman",
                Books=new List<Book>()
            {
                new Book(1,"kitap1","hüseyin")
                { }
            },
                MemberNo=1
            };


            Book book = new Book(1, "kitap1", "hüseyin")
            { };
            books.Add(book);
            members.Add(member);
        }
 
    }

}

