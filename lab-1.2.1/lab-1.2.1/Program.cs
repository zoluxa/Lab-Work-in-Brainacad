using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;



namespace CSharp_Net_module1_2_1_lab
{

    public interface ILibraryUser
    {
        void AddBook(string AddBookInfo);
        void RemoveBook();
        void BookInfo(int AddBookInfo);
        int BooksCount();

    }

    class LibraryUser : ILibraryUser {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int id { get; set; }
        public int BookLimit { get; set; }
        public string BookName { get; set; }
        public int Phone { get; set; }
        
        public LibraryUser ()
        {
            FirstName = "Your FirstName";
            LastName = "Your LastName";
            id = 012345;
            BookLimit = 100;
            Phone = 01234567890;
        }

        public LibraryUser(string f_n, string l_n, int i_d, int b_l, int p_n)
        
        {
            FirstName = f_n;
            LastName = l_n;
            id = i_d;
            BookLimit = b_l;
            Phone = p_n;
        }
        private string[] book_list = new string[book_cnt];
        static public int book_cnt = 8;
        int numBook = 0;
        public string this[int index_var]
        {
            get
            {
                string temp;
                if (index_var >= 0 && index_var <= book_cnt - 1)
                {
                    temp = book_list[index_var];
                }
                else
                {
                    temp = "";
                }
                return (temp);
            }
            set
            {
                if (index_var >= 0 && index_var <= book_cnt - 1)
                {
                    book_list[index_var] = value;
                }
            }
        }

        public void AddBook(string AddBookInfo)
        {
            book_list[numBook++] = AddBookInfo;
            Console.WriteLine("Added {0} to Library", AddBookInfo);
        }
        public void RemoveBook()
        {

        }
        public void ListOfBooks() {
            for (int i = 0; i < book_list.Length; i++)
            {
                if (book_list[i] != null)
                    Console.WriteLine(book_list[i]);
            }
        }
        public void BookInfo(int bookNumber)
        {
            if (bookNumber >= 0 && bookNumber <= book_list.Length)
                Console.WriteLine("Name of book: {0}", book_list[bookNumber]);
            else
                Console.WriteLine("There are no books!");
        }
        public int BooksCount()
        {
            int num_books = 0;
            while (book_list[num_books] != null)
            {
                num_books++;
            }
            return num_books;
        }
    }

    
    class Program
    {
        
        static void Main(string[] args)
        {

            // 8) declare 2 objects. Use default and paremeter constructors
            LibraryUser user1 = new LibraryUser("Joe", "Doe", 0001, 15, 0991234567 );
            LibraryUser user2 = new LibraryUser("Lara", "Kroft", 0002, 10, 0997654321);
            

            Console.WriteLine("User FName: {0} LName: {1} id: {2} NumberofBooks: {3} MobilePhone: {4}", user1.FirstName, user1.LastName, user1.id, user1.BookLimit, user1.Phone);
            Console.WriteLine("User FName: {0} LName: {1} id: {2} NumberofBooks: {3} MobilePhone: {4}", user2.FirstName, user2.LastName, user2.id, user2.BookLimit, user2.Phone);
            

            user1.AddBook("Book-1");
            user1.AddBook("Book-2");

            user1.BookInfo(0);
            Console.WriteLine("User 1 have {0} book's", user1.BooksCount());
            Console.ReadKey();
        }
    }



   }
    
