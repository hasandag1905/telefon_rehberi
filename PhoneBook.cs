using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace telefon_rehberi
{
    public class PhoneBook
    {
        private List<Contact> contacts;
        public PhoneBook()
        {
            contacts = new List<Contact>();
            {
                contacts.Add(new Contact("Ali", "Yılmaz", "1234567890"));
                contacts.Add(new Contact("Ayşe", "Kara", "2345678901"));
                contacts.Add(new Contact("Mehmet", "Demir", "3456789012"));
                contacts.Add(new Contact("Fatma", "Çelik", "4567890123"));
                contacts.Add(new Contact("Ahmet", "Şahin", "5678901234"));
            }
        }
        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }
        public void RemoveContact(string searchName)
        {
            var contactToRemove = contacts.FirstOrDefault(c => c.FirstName.Contains(searchName) || c.LastName.Contains(searchName));
            if (contactToRemove != null)
            {
                Console.WriteLine($"{contactToRemove} rehberden silinmek üzere, onaylıyor musunuz? (y/n)");
                if (Console.ReadLine().ToLower() == "y")
                {
                    contacts.Remove(contactToRemove);
                    Console.WriteLine("Kişi rehberden silindi.");
                }
                else
                {
                    Console.WriteLine("Silme işlemi iptal edildi.");
                }
            }
            else
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı.");
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için      : (2)");
                if (Console.ReadLine() == "2")
                {
                    // İlgili işlem yeniden başlatılabilir.
                }
            }
        }

        public void UpdateContact(string searchName, string newNo)
        {
            var contactToUpdate = contacts.FirstOrDefault(c => c.FirstName.Contains(searchName));
            if (contactToUpdate != null)
            {
                contactToUpdate.No = newNo;
                Console.WriteLine("Kişi güncellendi");
            }
            else
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("Güncellemeyi sonlandırmak için: (1)");
                Console.WriteLine("Yeniden denemek için (2)");
                if (Console.ReadLine() == "2")
                {
                    Console.WriteLine("Lütfen yeni bir arama terimi girin:");
                    string newSearchName = Console.ReadLine();
                    UpdateContact(newSearchName, newNo);
                }
                else
                {
                    Console.WriteLine("Güncelleme işlemi sonlandırıldı.");
                }
            }
        }

        public void ListContacts(bool ascending)
        {
            var sortedContacts = ascending ? contacts.OrderBy(c => c.LastName).ThenBy(c => c.FirstName) : contacts.OrderByDescending(c => c.LastName).ThenByDescending(c => c.FirstName);
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("**********************************************");
            foreach (var contact in sortedContacts)
            {
                Console.WriteLine(contact);
            }
        }
        public void SearchContacts(string searchType, string searchValue)
        {
            IEnumerable<Contact> result;
            if (searchType == "1")
            {
                result = contacts.Where(c => c.FirstName.Contains(searchValue) || c.LastName.Contains(searchValue));
            }
            else
            {
                result = contacts.Where(c => c.No.Contains(searchValue));
            }

            Console.WriteLine("Arama Sonuçlarınız:");
            Console.WriteLine("**********************************************");
            foreach (var contact in result)
            {
                Console.WriteLine(contact);
            }
        }

    }
}