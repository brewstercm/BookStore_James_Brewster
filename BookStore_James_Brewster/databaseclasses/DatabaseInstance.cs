using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Collections;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using BookStore_James_Brewster.databaseclasses;

namespace BlazorBookStore1
{
    /// <summary>
    /// TODO: Make queries for searching by book title, etc. Make query to add books to cart. Make query to change order. Make query to place order.
    /// 
    /// </summary>
    public static class DatabaseInstance
    {
        private static string connectionString = @"Server=(LocalDB)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\Legen\source\repos\BookStore_James_Brewster\BookStore_James_Brewster\database\BookStoreDB.mdf;Connection Lifetime=120;MultipleActiveResultSets=true;";
        public static void createCategory(string catName)
        {
            string query = $"INSERT INTO dbo.Categories VALUES('{catName}')";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                using(SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<Category> viewCategories()
        {
            List<Category> categories = new List<Category>();
            string query = $"SELECT * FROM dbo.Categories";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int catCode = reader.GetInt32(reader.GetOrdinal("catCode"));
                            string name = reader.GetString(reader.GetOrdinal("catDesc"));
                            categories.Add(new Category(catCode, name));
                        }
                    }
                }
            }
            return categories;
        }
        public static void addBookToOrder(Book book, int customerID)
        {
            List<decimal> prices = new List<decimal>();
            int orderID = -1;
            string query = $"SELECT orderID FROM dbo.Orders WHERE customerID={customerID} and isPlaced=0";
            using (SqlConnection conn = new SqlConnection(connectionString))
            { 
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orderID = reader.GetInt32(reader.GetOrdinal("orderID"));
                        }
                    }
                }
                if (orderID == -1)
                {
                    query = $"INSERT INTO dbo.Orders VALUES('{DateTime.Now.ToShortDateString().Replace("/", string.Empty)}', {book.price}, {customerID}, {0})";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.ExecuteNonQuery();
                    }

					query = $"SELECT orderID FROM dbo.Orders WHERE customerID={customerID} and isPlaced=0";
					using (SqlCommand command = new SqlCommand(query, conn))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								orderID = reader.GetInt32(reader.GetOrdinal("orderID"));
							}
						}
					}
				}


				query = $"INSERT INTO dbo.Order_Item VALUES({book.price}, {orderID}, '{book.isbnNum}')";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
                query = $"SELECT * FROM dbo.Order_Item WHERE orderID={orderID}";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            prices.Add(reader.GetDecimal(reader.GetOrdinal("itemPrice")));
                        }
                    }
                }
                decimal total = 0;
                foreach(decimal price in prices)
                {
                    total += price;
                }

                query = $"UPDATE dbo.Orders SET orderVal={total} WHERE orderID={orderID}";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public static void CreateAccount(string fName, string lName, string email, string password, bool isAdministrator, string address, string phone)
        {
            int adminPrivileges = 0;
            if (isAdministrator)
            {
                adminPrivileges = 1;
            }
            string query = $"INSERT INTO dbo.Customer VALUES ('{fName}', '{lName}')";
            int customerID = 0;
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();

                query = $"SELECT * FROM dbo.Customer WHERE fName='{fName}' AND lName='{lName}'";
                command = new SqlCommand(query, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customerID = reader.GetInt32(reader.GetOrdinal("customerID"));
                    }
                }
                query = $"INSERT INTO dbo.Login VALUES ({customerID}, '{email}', '{password}', {adminPrivileges})";
                command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                query = $"INSERT INTO dbo.CustomerContactDetails VALUES ({customerID}, '{address}', '{email}', '{phone}')";
                command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
        }

        public static void Login(string email, string password)
        {
            int customerID = -1;
            string query = $"SELECT * FROM dbo.Login WHERE email='{email}' AND password='{password}'";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer.customerID = reader.GetInt32(reader.GetOrdinal("customerID"));
                            Customer.email = reader.GetString(reader.GetOrdinal("email"));
                            Customer.password = reader.GetString(reader.GetOrdinal("password"));
                            int isAdministrator = reader.GetInt32(reader.GetOrdinal("isAdministrator"));
                            if (isAdministrator == 1)
                                Customer.isAdministrator = true;
                            else
                                Customer.isAdministrator = false;
                            break;
                        }
                    }
                }
                
                query = $"SELECT * FROM dbo.Customer WHERE customerID={customerID}";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer.fName = reader.GetString(reader.GetOrdinal("fName"));
                            Customer.lName = reader.GetString(reader.GetOrdinal("lName"));
                            break;
                        }
                    }
                }
               

                query = $"SELECT * FROM dbo.CustomerContactDetails WHERE customerID={customerID}";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer.address = reader.GetString(reader.GetOrdinal("address"));
                            Customer.phone = reader.GetString(reader.GetOrdinal("phone"));
                        }
                    }
                }
            }
        }

        public static void UpdateAccount(int customerID, string fName, string lName, string address, string email, string phone, string password)
        {
            string query = $"UPDATE dbo.Customer SET fName='{fName}', lName='{lName}' WHERE customerID={customerID}";
            string query2 = $"UPDATE dbo.CustomerContactDetails SET address='{address}', email='{email}', phone='{phone}' WHERE customerID={customerID}";
            string query3 = $"UPDATE dbo.Login SET email='{email}', password='{password}' WHERE customerID={customerID}";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(query, conn);
                SqlCommand command2 = new SqlCommand(query2, conn);
                SqlCommand command3 = new SqlCommand(query3, conn);

                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                command3.ExecuteNonQuery();

                Customer.customerID = customerID;
                Customer.fName = fName;
                Customer.lName = lName;
                Customer.address = address;
                Customer.email = email;
                Customer.phone = phone;
                Customer.password = password;
            }
           
        }

        public static void Logout()
        {
            Customer.customerID = -1;
            Customer.isAdministrator = false;
        }

        public static List<CustomerDetails> viewCustomers()
        {
            List<CustomerDetails> customers = new List<CustomerDetails>();
            string query = $"SELECT * FROM dbo.Customer JOIN dbo.CustomerContactDetails ON dbo.Customer.customerID = dbo.CustomerContactDetails.customerID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int customerID = reader.GetInt32(reader.GetOrdinal("customerID"));
                        string fName = reader.GetString(reader.GetOrdinal("fName"));
                        string lName = reader.GetString(reader.GetOrdinal("lName"));
                        string email = reader.GetString(reader.GetOrdinal("email"));
                        string phone = reader.GetString(reader.GetOrdinal("phone"));
                        string address = reader.GetString(reader.GetOrdinal("address"));

                        CustomerDetails newCustomer = new CustomerDetails(customerID, fName, lName, email, phone, address);
                        customers.Add(newCustomer);
                    }
                }
            }
            return customers;
        }

        public static CustomerDetails getCustomer(int customerID)
        {
            CustomerDetails customer = null;
            string query = $"SELECT * FROM dbo.Customer JOIN dbo.CustomerContactDetails ON dbo.Customer.customerID = dbo.CustomerContactDetails.customerID JOIN dbo.Login ON dbo.CustomerContactDetails.customerID = dbo.Login.customerID WHERE dbo.Customer.customerID={customerID}";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string fName = reader.GetString(reader.GetOrdinal("fName"));
                        string lName = reader.GetString(reader.GetOrdinal("lName"));
                        string email = reader.GetString(reader.GetOrdinal("email"));
                        string phone = reader.GetString(reader.GetOrdinal("phone"));
                        string address = reader.GetString(reader.GetOrdinal("address"));
                        string password = reader.GetString(reader.GetOrdinal("password"));

                        customer = new CustomerDetails(customerID, fName, lName, email, phone, address, password);
                    }
                }
            }
            return customer;
        }

        public static void editCustomer(int customerID, string fName, string lName, string email, string phone, string address)
        {
            string query = $"UPDATE dbo.Customer SET fName='{fName}', lName='{lName}' WHERE customerID={customerID}";
            string query2 = $"UPDATE dbo.CustomerContactDetails SET email='{email}', phone='{phone}', address='{address}' WHERE customerID={customerID}";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                SqlCommand command2 = new SqlCommand(query, conn);
                conn.Open();
                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
            }
        }

        public static void deleteCustomer(int customerID)
        {
            string query = $"DELETE FROM dbo.Customer WHERE customerID={customerID}";
            string query2 = $"DELETE FROM dbo.CustomerContactDetails WHERE customerID={customerID}";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                SqlCommand command2 = new SqlCommand(query2, conn);
                conn.Open();
                command2.ExecuteNonQuery();
                command.ExecuteNonQuery();
            }
        }

        public static List<Order> viewAllOrders()
        {
            List<Order> orders = new List<Order>();
            string query = $"SELECT * FROM dbo.Orders";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int orderID = reader.GetInt32(reader.GetOrdinal("orderID"));
                        string orderDate = reader.GetString(reader.GetOrdinal("orderDate"));
                        decimal orderVal = reader.GetDecimal(reader.GetOrdinal("orderVal"));
                        int customerID = reader.GetInt32(reader.GetOrdinal("customerID"));
                        int isPlaced = reader.GetInt32(reader.GetOrdinal("isPlaced"));

                        Order newOrder = new Order(orderID, orderDate, orderVal, customerID, isPlaced);
                        orders.Add(newOrder);
                    }
                }
            }
            return orders;
        }

        public static List<Order> viewCustomerOrders(int customerID)
        {
            List<Order> orders = new List<Order>();
            string query = $"SELECT * FROM dbo.Orders WHERE customerID={customerID}";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int orderID = reader.GetInt32(reader.GetOrdinal("orderID"));
                        string orderDate = reader.GetString(reader.GetOrdinal("orderDate"));
                        decimal orderVal = reader.GetDecimal(reader.GetOrdinal("orderVal"));
                        int isPlaced = reader.GetInt32(reader.GetOrdinal("isPlaced"));

                        Order newOrder = new Order(orderID, orderDate, orderVal, customerID, isPlaced);
                        orders.Add(newOrder);
                    }
                }
            }
            return orders;
        }

        public static Order getOrder(int orderID)
        {
            Order order = null;
            string query = $"SELECT * FROM dbo.Orders WHERE orderID={orderID}";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string orderDate = reader.GetString(reader.GetOrdinal("orderDate"));
                        decimal orderVal = reader.GetDecimal(reader.GetOrdinal("orderVal"));
                        int customerID = reader.GetInt32(reader.GetOrdinal("customerID"));
                        int isPlaced = reader.GetInt32(reader.GetOrdinal("isPlaced"));

                        order = new Order(orderID, orderDate, orderVal, customerID, isPlaced);
                    }
                }
            }
            return order;
        }

        public static void editOrder(int orderID, string orderDate, decimal orderVal, int customerID)
        {
            string query = $"UPDATE dbo.Orders SET orderDate='{orderDate}', orderVal={orderVal}, customerID={customerID} WHERE orderID={orderID}";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void deleteOrder(int orderID)
        {
            string query = $"DELETE FROM dbo.Orders WHERE orderID={orderID}";
            string query2 = $"DELETE FROM dbo.Order_Item WHERE orderID={orderID}";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                SqlCommand command2 = new SqlCommand(query2, conn);
                conn.Open();
                command2.ExecuteNonQuery();
                command.ExecuteNonQuery();
            }
        }
        public static List<Book> viewBooks()
        {
            List<Book> books = new List<Book>();
            string query = $"SELECT * FROM dbo.Books JOIN dbo.BookCategories ON dbo.Books.isbnNum = dbo.BookCategories.isbnNum JOIN dbo.Categories ON dbo.BookCategories.catCode = dbo.BookCategories.catCode";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string isbnNum = reader.GetString(reader.GetOrdinal("isbnNum"));
                            string title = reader.GetString(reader.GetOrdinal("title"));
                            string pubDate = reader.GetString(reader.GetOrdinal("pubDate"));
                            decimal price = reader.GetDecimal(reader.GetOrdinal("price"));
                            decimal reviews = reader.GetDecimal(reader.GetOrdinal("reviews"));
                            int supplierID = reader.GetInt32(reader.GetOrdinal("supplierID"));
                            string name = reader.GetString(reader.GetOrdinal("catDesc"));
                            Book newBook = new Book(isbnNum, title, pubDate, price, reviews, supplierID, name);
                            books.Add(newBook);
                        }
                    }
                }
            }
            return books;
        }
        public static List<Book> searchBooks(string searchTerm)
        {
            List<Book> books = new List<Book>();
            string query = $"SELECT * FROM dbo.Books JOIN dbo.BookCategories ON dbo.Books.isbnNum = dbo.BookCategories.isbnNum JOIN dbo.Categories ON dbo.BookCategories.catCode = dbo.BookCategories.catCode WHERE dbo.Books.isbnNum like '%{searchTerm}%' or title like '%{searchTerm}%'";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string isbnNum = reader.GetString(reader.GetOrdinal("isbnNum"));
                        string title = reader.GetString(reader.GetOrdinal("title"));
                        string pubDate = reader.GetString(reader.GetOrdinal("pubDate"));
                        decimal price = reader.GetDecimal(reader.GetOrdinal("price"));
                        decimal reviews = reader.GetDecimal(reader.GetOrdinal("reviews"));
                        int supplierID = reader.GetInt32(reader.GetOrdinal("supplierID"));
                        string name = reader.GetString(reader.GetOrdinal("catDesc"));
                        Book newBook = new Book(isbnNum, title, pubDate, price, reviews, supplierID, name);
                        books.Add(newBook);
                    }
                }
            }
            return books;
        }

        public static List<Book> browseBooksByTitle()
        {
            List<Book> books = new List<Book>();
            string query = $"SELECT * FROM dbo.Books JOIN dbo.BookCategories ON dbo.Books.isbnNum = dbo.BookCategories.isbnNum JOIN dbo.Categories ON dbo.BookCategories.catCode = dbo.BookCategories.catCode order by title asc";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string isbnNum = reader.GetString(reader.GetOrdinal("isbnNum"));
                        string title = reader.GetString(reader.GetOrdinal("title"));
                        string pubDate = reader.GetString(reader.GetOrdinal("pubDate"));
                        decimal price = reader.GetDecimal(reader.GetOrdinal("price"));
                        decimal reviews = reader.GetDecimal(reader.GetOrdinal("reviews"));
                        int supplierID = reader.GetInt32(reader.GetOrdinal("supplierID"));
                        string name = reader.GetString(reader.GetOrdinal("catDesc"));

                        Book newBook = new Book(isbnNum, title, pubDate, price, reviews, supplierID, name);
                        books.Add(newBook);
                    }
                }
            }
            return books;
        }
        public static List<Book> browseBooksByPubDate()
        {
            List<Book> books = new List<Book>();
            string query = $"SELECT * FROM dbo.Books JOIN dbo.BookCategories ON dbo.Books.isbnNum = dbo.BookCategories.isbnNum JOIN dbo.Categories ON dbo.BookCategories.catCode = dbo.BookCategories.catCode order by pubDate asc";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string isbnNum = reader.GetString(reader.GetOrdinal("isbnNum"));
                        string title = reader.GetString(reader.GetOrdinal("title"));
                        string pubDate = reader.GetString(reader.GetOrdinal("pubDate"));
                        decimal price = reader.GetDecimal(reader.GetOrdinal("price"));
                        decimal reviews = reader.GetDecimal(reader.GetOrdinal("reviews"));
                        int supplierID = reader.GetInt32(reader.GetOrdinal("supplierID"));
                        string name = reader.GetString(reader.GetOrdinal("catDesc"));

                        Book newBook = new Book(isbnNum, title, pubDate, price, reviews, supplierID, name);
                        books.Add(newBook);
                    }
                }
            }
            return books;
        }
        public static List<Book> browseBooksByReviews()
        {
            List<Book> books = new List<Book>();
            string query = $"SELECT * FROM dbo.Books JOIN dbo.BookCategories ON dbo.Books.isbnNum = dbo.BookCategories.isbnNum JOIN dbo.Categories ON dbo.BookCategories.catCode = dbo.BookCategories.catCode order by reviews desc";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string isbnNum = reader.GetString(reader.GetOrdinal("isbnNum"));
                        string title = reader.GetString(reader.GetOrdinal("title"));
                        string pubDate = reader.GetString(reader.GetOrdinal("pubDate"));
                        decimal price = reader.GetDecimal(reader.GetOrdinal("price"));
                        decimal reviews = reader.GetDecimal(reader.GetOrdinal("reviews"));
                        int supplierID = reader.GetInt32(reader.GetOrdinal("supplierID"));
                        string name = reader.GetString(reader.GetOrdinal("catDesc"));

                        Book newBook = new Book(isbnNum, title, pubDate, price, reviews, supplierID, name);
                        books.Add(newBook);
                    }
                }
            }
            return books;
        }
        public static List<Book> browseBooksByCategory()
        {
            List<Book> books = new List<Book>();
            string query = $"SELECT * FROM dbo.Books JOIN dbo.BookCategories ON dbo.Books.isbnNum = dbo.BookCategories.isbnNum JOIN dbo.Categories ON dbo.BookCategories.catCode = dbo.BookCategories.catCode order by dbo.Categories.catDesc asc";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string isbnNum = reader.GetString(reader.GetOrdinal("isbnNum"));
                        string title = reader.GetString(reader.GetOrdinal("title"));
                        string pubDate = reader.GetString(reader.GetOrdinal("pubDate"));
                        decimal price = reader.GetDecimal(reader.GetOrdinal("price"));
                        decimal reviews = reader.GetDecimal(reader.GetOrdinal("reviews"));
                        int supplierID = reader.GetInt32(reader.GetOrdinal("supplierID"));
                        string name = reader.GetString(reader.GetOrdinal("catDesc"));

                        Book newBook = new Book(isbnNum, title, pubDate, price, reviews, supplierID, name);
                        books.Add(newBook);
                    }
                }
            }
            return books;
        }

        public static Book getBook(string isbnNum)
        {
            Book book = null;
            string query = $"SELECT * FROM dbo.Books JOIN dbo.BookCategories ON dbo.Books.isbnNum = dbo.BookCategories.isbnNum JOIN dbo.Categories ON dbo.BookCategories.catCode = dbo.BookCategories.catCode WHERE dbo.Books.isbnNum='{isbnNum}'";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string title = reader.GetString(reader.GetOrdinal("title"));
                        string pubDate = reader.GetString(reader.GetOrdinal("pubDate"));
                        decimal price = reader.GetDecimal(reader.GetOrdinal("price"));
                        decimal reviews = reader.GetDecimal(reader.GetOrdinal("reviews"));
                        int supplierID = reader.GetInt32(reader.GetOrdinal("supplierID"));
                        string name = reader.GetString(reader.GetOrdinal("catDesc"));
                        book = new Book(isbnNum, title, pubDate, price, reviews, supplierID, name);
                    }
                }
            }
            return book;
        }

        public static void editBook(string isbnNum, string title, string pubDate, decimal price, decimal reviews, int supplierID)
        {
            string query = $"UPDATE dbo.Books SET isbnNum='{isbnNum}', title='{title}', pubDate='{pubDate}', price={price}, reviews={reviews}, supplierID={supplierID} WHERE isbnNum='{isbnNum}'";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void addBook(string isbnNum, string title, string pubDate, decimal price, decimal reviews, int supplierID, int categoryID, int AuthorID)
        {
            string query = $"INSERT INTO dbo.Books VALUES('{isbnNum}', '{title}', '{pubDate}', {price}, {reviews}, {supplierID})";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
                query = $"INSERT INTO dbo.BookCategories VALUES('{isbnNum}', {categoryID})";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
                query = $"INSERT INTO dbo.BookAuthor VALUES({AuthorID}, '{isbnNum}')";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public static void deleteBook(string isbnNum)
        {
            string query = $"DELETE FROM dbo.Books WHERE isbnNum='{isbnNum}'";
            string query2 = $"DELETE FROM dbo.BookCategories WHERE isbnNum='{isbnNum}'";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                SqlCommand command2 = new SqlCommand(query2, conn);
                command2.ExecuteNonQuery();
                command.ExecuteNonQuery();
            }
        }

        public static List<AuthorDetails> viewAuthors()
        {
            List<AuthorDetails> authors = new List<AuthorDetails>();
            string query = $"SELECT * FROM dbo.Author JOIN dbo.AuthorContactDetails ON dbo.Author.authorID = dbo.AuthorContactDetails.authorID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int authorID = reader.GetInt32(reader.GetOrdinal("authorID"));
                        string fName = reader.GetString(reader.GetOrdinal("fName"));
                        string lName = reader.GetString(reader.GetOrdinal("lName"));
                        string gender = reader.GetString(reader.GetOrdinal("gender"));
                        string DOB = reader.GetString(reader.GetOrdinal("DOB"));
                        string address = reader.GetString(reader.GetOrdinal("address"));
                        string email = reader.GetString(reader.GetOrdinal("email"));
                        string phone = reader.GetString(reader.GetOrdinal("phone"));

                        AuthorDetails newAuthor = new AuthorDetails(authorID, fName, lName, gender, DOB, address, email, phone);
                        authors.Add(newAuthor);
                    }
                }
            }
            return authors;
        }
        public static List<Supplier> viewSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();
            string query = $"SELECT * FROM dbo.Supplier";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int supplierID = reader.GetInt32(reader.GetOrdinal("supplierID"));
                        string name = reader.GetString(reader.GetOrdinal("name"));

                        Supplier newSupplier = new Supplier(supplierID, name);
                        suppliers.Add(newSupplier);
                    }
                }
            }
            return suppliers;
        }

        public static AuthorDetails getAuthor(int authorID)
        {
            AuthorDetails author = null;
            string query = $"SELECT * FROM dbo.Author JOIN dbo.AuthorContactDetails ON dbo.Author.authorID=dbo.AuthorContactDetails.authorID WHERE dbo.Author.authorID={authorID}";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string fName = reader.GetString(reader.GetOrdinal("fName"));
                        string lName = reader.GetString(reader.GetOrdinal("lName"));
                        string gender = reader.GetString(reader.GetOrdinal("gender"));
                        string DOB = reader.GetString(reader.GetOrdinal("DOB"));
                        string address = reader.GetString(reader.GetOrdinal("address"));
                        string email = reader.GetString(reader.GetOrdinal("email"));
                        string phone = reader.GetString(reader.GetOrdinal("phone"));

                        author = new AuthorDetails(authorID, fName, lName, gender, DOB, address, email, phone);
                    }
                }
            }
            return author;
        }

        public static void editAuthor(int authorID, string fName, string lName, string gender, string DOB, string address, string email, string phone)
        {
            string query1 = $"UPDATE dbo.Author SET fName='{fName}', lName='{lName}', gender='{gender}', DOB='{DOB}' WHERE authorID={authorID}";
            string query2 = $"UPDATE dbo.AuthorContactDetails SET address='{address}', email='{email}', phone='{phone}' WHERE authorID={authorID}";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(SqlCommand command = new SqlCommand(query1, conn))
                {
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand(query2, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        

        public static Supplier getSupplier(int supplierID)
        {
            Supplier supplier = null;
            string query = $"SELECT * FROM dbo.Supplier WHERE supplierID={supplierID}";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(reader.GetOrdinal("name"));

                        supplier = new Supplier(supplierID, name);
                    }
                }
            }
            return supplier;
        }

        public static void editSupplier(int supplierID, string name)
        {
            string query = $"UPDATE dbo.Supplier SET name='{name}' WHERE supplierID={supplierID}";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void deleteSupplier(int supplierID)
        {
            string query = $"DELETE FROM dbo.Supplier WHERE supplierID={supplierID}";
            string query2 = $"DELETE FROM dbo.SupplierRep WHERE supplierID={supplierID}";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                SqlCommand command2 = new SqlCommand(query2, conn);
                conn.Open();
                command2.ExecuteNonQuery();
                command.ExecuteNonQuery();
            }
        }
        public static void addSupplierRep(string fName, string lName, string workNum, string cellNum, string email, int supplierID)
        {
            string query = $"INSERT INTO dbo.SupplierRep VALUES('{fName}', '{lName}', '{workNum}', '{cellNum}', '{email}', {supplierID})";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void deleteSupplierRep(string fName, string lName, int supplierID)
        {
            string query = $"DELETE FROM dbo.SupplierRep WHERE fName='{fName}' and lName='{lName}' and supplierID={supplierID}";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void createSupplier(string supplierName)
        {
            string query = $"INSERT INTO dbo.Supplier VALUES('{supplierName}')";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void editSupplierRep(string fName, string lName, string workNum, string cellNum, string email, int supplierID)
        {
			string query = $"UPDATE dbo.SupplierRep SET name='{fName}' , '{lName}', '{workNum}' , '{cellNum}' , '{email}' WHERE supplierID={supplierID}";
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				using (SqlCommand command = new SqlCommand(query, conn))
				{
					command.ExecuteNonQuery();
				}
			}
		}

        public static void addAuthor(string fName, string lName, string gender, string DOB, string address, string email, string phone)
        {
            string query = $"INSERT INTO dbo.Author VALUES('{fName.Trim()}', '{lName.Trim()}', '{gender.Trim()}', '{DOB.Trim()}')";
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
                query = $"SELECT * FROM dbo.Author WHERE fName='{fName.Trim()}' and lName='{lName.Trim()}' and gender='{gender.Trim()}' and DOB='{DOB.Trim()}'";
                int authorID = -1;
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            authorID = reader.GetInt32(reader.GetOrdinal("authorID"));
                            break;
                        }
                    }
                }
                string query2 = $"INSERT INTO dbo.AuthorContactDetails VALUES({authorID}, '{address}', '{email}', '{phone}')";
                using (SqlCommand command2 = new SqlCommand(query2, conn))
                {
                    command2.ExecuteNonQuery();
                }
            }
		}

        public static void deleteAuthor(int authorID)
        {
            string query = $"DELETE FROM dbo.BookAuthor WHERE authorID={authorID}";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
				conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
                query = $"DELETE FROM dbo.BookCategories WHERE authorID={authorID}";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
                query = $"DELETE FROM dbo.Author WHERE authorID={authorID}";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void addSupplier(string name) 
        {
			string query = $"INSERT INTO dbo.Supplier VALUES('{name}')";
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				using (SqlCommand command = new SqlCommand(query, conn))
				{
					command.ExecuteNonQuery();
				}
			}
		}

        public static List<OrderItem> getOrderItems(int orderID)
        {
            string query = $"SELECT * FROM dbo.Order_Item WHERE orderID={orderID}";
            List<OrderItem> items = new List<OrderItem>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int itemNum = reader.GetInt32(reader.GetOrdinal("itemNum"));
                            decimal itemPrice = reader.GetDecimal(reader.GetOrdinal("itemPrice"));
                            string isbnNum = reader.GetString(reader.GetOrdinal("isbnNum"));

                            items.Add(new OrderItem(itemNum, itemPrice, orderID, isbnNum));
                        }
                    }
                }
            }
            return items;
        }
    }
}
