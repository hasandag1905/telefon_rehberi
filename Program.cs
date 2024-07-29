namespace telefon_rehberi
{
    class Program
    {
        static void Main(string[] args)
        {

            var phoneBook = new PhoneBook();
            while (true)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("*******************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı Güncelleme");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapmak");
                Console.WriteLine("*******************************************");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Lütfen isim giriniz:");
                        var firstName = Console.ReadLine();
                        Console.WriteLine("Lütfen soyisim giriniz:");
                        var lastName = Console.ReadLine();
                        Console.WriteLine("Lütfen telefon numarası giriniz:");
                        var phoneNumber = Console.ReadLine();
                        phoneBook.AddContact(new Contact(firstName, lastName, phoneNumber));
                        break;
                    case "2":
                        Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz");
                        var deleteName = Console.ReadLine();
                        phoneBook.RemoveContact(deleteName);
                        break;

                    case "3":
                        Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
                        var updateName = Console.ReadLine();
                        Console.WriteLine("Lütfen yeni telefon numarasını giriniz:");
                        var newPhoneNumber = Console.ReadLine();
                        phoneBook.UpdateContact(updateName, newPhoneNumber);
                        break;
                    case "4":
                        Console.WriteLine("Rehberi A-Z sıralamak için (1)");
                        Console.WriteLine("Rehberi Z-A sıralamak için (2)");
                        var sortOrder = Console.ReadLine();
                        bool ascending = sortOrder == "2";
                        phoneBook.ListContacts(ascending);
                        break;
                    case "5":
                        Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
                        Console.WriteLine("**********************************************");
                        Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
                        Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
                        var searchType = Console.ReadLine();
                        Console.WriteLine("Arama kriterini giriniz:");
                        var searchValue = Console.ReadLine();
                        phoneBook.SearchContacts(searchType, searchValue);
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyiniz.");
                        break;


                }
            }


        }
        
    }
}