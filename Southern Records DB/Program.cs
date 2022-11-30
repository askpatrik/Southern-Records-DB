using MySql.Data.MySqlClient;

namespace Southern_Records_DB
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //Vad gäller klasserna har jag valt att bara skapa klasser av de tabeller som jag använder i crud-operations i just denna applikation.
            //Applikationen skulle förstås kunna utvecklas ännu mer med flera procedurer där andra klasser skulle behövas. Tex. purchases. 


            //Uppkoppling till databasen. Har skapat en metod för detta. 
            var connect = ConnectToDatabase();
        
            //Deklarerar här variabel som registrerar console key input
            ConsoleKeyInfo input;

            //Menyval: En huvudmeny sedan 5 stycken undermenyer. Uppbyggd i form av switch-cases i en DO-while loop. 
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Southern Records Database!");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("From here, you can perform CRUD operations on records, artists, genres and sellers.");
                Console.WriteLine("Please select desired operation: ");
                Console.WriteLine();
                Console.WriteLine("1. Add data");
                Console.WriteLine("2. Get data ");
                Console.WriteLine("3. Update data");
                Console.WriteLine("4. Remove data");
                Console.WriteLine("5. Other Procedures");
                Console.WriteLine();
                Console.WriteLine("Press 'X' to exit the database");

                input = Console.ReadKey();
                //Rensar konsollen så att det blir tomt. 
                Console.Clear();

                //Submenyer börjar här
                //konverterar här användarens input till sträng som sen används i switchsatsen. 
                switch (input.KeyChar.ToString())
                {
                    case "1":
                        Console.WriteLine("~ Add data ~");                       
                        Console.WriteLine();
                        Console.WriteLine("1. Add Genre");
                        Console.WriteLine("2. Add Artist To Existing Genre");
                        Console.WriteLine("3. Add Artist To New Genre");
                        Console.WriteLine("4. Add Record To Existing Artist");
                        Console.WriteLine("5. Add Record To New Artist And Existing Genre");
                        Console.WriteLine("6. Add Record To New Artist And New Genre");
                        Console.WriteLine("7. Add Record To Seller");                     
                        input = Console.ReadKey();
                                                               
                        switch (input.KeyChar.ToString())
                        {
                            case "1":
                                Console.Clear();
                                AddGenre(connect);
                                break;

                            case "2":
                                Console.Clear();
                                AddArtistSameGenre(connect);
                                break;
                            case "3":
                                Console.Clear();
                                AddArtistNewGenre(connect);
                                break;
                            case "4":
                                Console.Clear();
                                AddRecordSameArtist(connect);
                                break;
                            case "5":
                                Console.Clear();
                                AddRecordNewArtistSameGenre(connect);
                                break;
                            case "6":
                                Console.Clear();
                                AddRecordNewArtistNewGenre(connect);
                                break;
                            case "7":
                                Console.Clear();
                                DistributeRecordToSeller(connect);
                                break;
                                //Default är det som händer om användaren inte skriver in någon av ovanstående nummer. I detta fallet skrivs ett meddelande ut och man returnas till huvudmenyn.
                            default:
                                Console.Clear();
                                Console.WriteLine("You did not enter a valid number, press any key to return to the main menu. ");
                                Console.ReadKey();
                                break;
                        }
                        break;

                    case "2":
                        Console.WriteLine("~ Read Data ~");
                        Console.WriteLine();
                        Console.WriteLine("1. Read Records Data");
                        Console.WriteLine("2. Read Genre Data");
                        Console.WriteLine("3. Read Artists Data");
                        Console.WriteLine("4. Read Sellers Data");
                        Console.WriteLine("5. Read Customers Data");            
                        input = Console.ReadKey();
                        Console.Clear();

                        switch (input.KeyChar.ToString())
                        {
                            case "1":
                                Console.Clear();
                                RetrieveAndPrintDataFromRecords(connect);
                                break;
                            case "2":
                                Console.Clear();
                                RetrieveAndPrintDataFromGenres(connect);
                                break;
                            case "3":
                                Console.Clear();
                                RetrieveAndPrintDataFromArtists(connect);
                                break;
                            case "4":
                                Console.Clear();
                                RetrieveAndPrintDataFromSellers(connect);
                                break;
                                
                            case "5":
                                Console.Clear();
                                RetrieveDataFromCustomers(connect);
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("You did not enter a valid number, press any key and try again. ");
                                Console.ReadKey();
                                break;                                                      
                        }
                        break;

                    case "3":
                        Console.WriteLine("~ Update Data ~");
                        Console.WriteLine("1. Update Records data");
                        Console.WriteLine("2. Update Genre data");
                        Console.WriteLine("3. Update Artists data");                       
                        input = Console.ReadKey();
                        Console.Clear();

                        switch (input.KeyChar.ToString())
                        {
                            case "1":

                                Console.Clear();
                                UpdateRecords(connect);
                                break;
                            case "2":

                                Console.Clear();
                                UpdateGenres(connect);
                                break;
                            case "3":

                                Console.Clear();
                                UpdateArtists(connect);
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("You did not enter a valid number, press any key to return to the main menu. ");
                                Console.ReadKey();
                                break;
                        }
                        break;
                    case "4":
                        Console.WriteLine("~Remove Data~");
                        Console.WriteLine("1. Remove Records Data");
                        Console.WriteLine("2. Remove Genre Data");
                        Console.WriteLine("3. Remove Artists Data");                      
                        input = Console.ReadKey();
                        Console.Clear();

                        switch (input.KeyChar.ToString())
                        {
                            case "1":

                                Console.Clear();
                                RemoveDataFromRecords(connect);
                                break;
                            case "2":

                                Console.Clear();
                                RemoveDataFromGenres(connect);
                                break;
                            case "3":

                                Console.Clear();
                                RemoveDataFromArtists(connect);
                                break;
                                default:
                                Console.Clear();
                                Console.WriteLine("You did not enter a valid number, press any key to return to the main menu. ");
                                Console.ReadKey(); 
                                break;
                        }
                        break;
                    case "5":
                        Console.WriteLine("~ Other Procedures ~");
                        Console.WriteLine("1. Get cheapest record by searchword");
                        Console.WriteLine("2. Get records by genre searchword");
                        Console.WriteLine("3. Get records in price interval");                                         
                        input = Console.ReadKey();
                        Console.Clear();

                        switch (input.KeyChar.ToString())
                        {
                            case "1":

                                Console.Clear();
                                SearchCheapestRecord(connect);
                                break;
                            case "2":

                                Console.Clear();
                                SearchRecordsByGenre(connect);
                                break;
                            case "3":

                                Console.Clear();
                                EnterPriceInterval(connect);
                                break;
                            default:
                                Console.Clear();
                                Console.Write("You did not enter a valid number, press any key to return to the main menu: ");
                                Console.ReadKey();
                                break;

                        }
                        break;
                }
            }
            while (input.KeyChar.ToString() != "x");
        }
        public static MySqlConnection ConnectToDatabase()
        {
            //Uppkoppling till databasen "southern records"
            string server = "LOCALHOST";
            string database = "southern records";
            string username = "";
            string pass = "";

            string strConn = $"SERVER={server};DATABASE={database};UID={username};PASSWORD={pass};";
            MySqlConnection conn = new MySqlConnection(strConn);

            return conn;
        }
       
        #region AddData Methods
        public static void AddGenre(MySqlConnection conn)
        {
            //Frågar användaren om input
            Console.Write("Enter the name of the new genre: ");
            //Användarens input skickas till metod för att kolla om värdet är null. 
            string genre = ReadNull();
         
            //Skapar SQL-query i stringvariabel      
            string sqlQuery = $"CALL add_genre('{genre}');";

            //Öppnar anslutningen och Skapar MySQLCommand-Object. Initializar ny instance av MySQLCommand med SQL-querien och anslutningen.  
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Exekverar MySQLCommand. Stored prodecuren i MySQL som motsvarar SQL-queryn exekveras. 
            cmd.ExecuteReader();

            Console.Clear();
            //Meddelande 
            Console.WriteLine($"Genre '{genre}' was successfully added to the genre table. " +
               $"Press any button to get the new genre list. ");
            Console.ReadKey();
            Console.Clear();

            //Stänger DB connection
            conn.Close();
            //Hämtar och printar data från metod. 
            RetrieveAndPrintDataFromGenres(conn);          
        }
        public static void AddArtistSameGenre(MySqlConnection conn)
        {                
            Console.Write("Enter the name of the artist: ");
            string artist = ReadNull();
            Console.Clear();
            Console.Write("Enter the country of the artist: ");
            string country = ReadNull();
            Console.Clear();
           Console.WriteLine("Fetching genres...");          
           //Hämtar data och skapar lista
                RetrieveDataFromGenres(conn);
                Console.Clear();
          
            //Count skapas för att räkna fram rätt genre efter användarens val.
            int count = 1;         

            //Foreach på listan där count ökar med 1 för varje nytt element
            foreach (Genre genre in Genre.genres)
            {
                Console.WriteLine($"{count}. {genre.genre}");
                count++;
            }
            Console.WriteLine();
            Console.Write("Enter which existing genre the artist belongs to: ");
            int input = ReadInt();    
            //Minus 1 för att index i listan startar på 0. Annars hade det blivit fel val. 
            int selectedID = Genre.genres[input - 1].id;         
            string sqlQuery = $"CALL add_artist_existing_genre('{artist}','{country}', {selectedID});";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);       
            cmd.ExecuteReader();
            Console.Clear();

            Console.WriteLine($"The artist '{artist}' of the genre {Genre.genres[input - 1].genre} was successfully added to the artist table.");
            Console.WriteLine("Press any button to get the new artist and genres list.");
            Console.ReadKey();
            Console.Clear();            
            conn.Close();
            GetGenresAndArtists(conn);

        }
        public static void AddArtistNewGenre(MySqlConnection conn)
        {
            Console.Write("Enter the name of the artist: ");
            string artist = ReadNull();
            Console.Clear();
            Console.Write("Enter the country of the artist: ");
            string country = ReadNull();
            Console.Clear();
            Console.Write("Enter the name of the new genre which the artist belongs to: ");
            string genre = ReadNull();
            Console.Clear();
            int count = 1;

            conn.Open();           
            string sqlQuery = $"CALL add_genre('{genre}')";              
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            cmd.ExecuteReader();
            conn.Close();
            RetrieveDataFromGenres(conn);
            Console.Clear();

            //Tillvägagångssättet nedan har jag använt i alla metoder där jag addar flera nya data som hör ihop med foreign key. 
            //TEX som i detta fallet: Ny Artist och Ny Genre samtidigt. Då Artist har en foreign key till genre, måste jag hitta
            //maxvärdet i genrelistan och som foreign key i artist, ta det maxvärdet +1, det blir rätt position för den nya genren.  

            //1. Räknar alla element i klassen. Det finns 12 stycken i genre i modellen så vi börjar på 12. 
            //2. Count börjar på 1 vilket gör att Count = 13 efter foreachen. 
            //3. Skapar variabeln max för att få ut maxvärde där jag tar Count - 2 = 11. 
            //4. Sätter in max som önskat index i klassen och sparar det värdet i variabel SelectedID, som blir 12 (den räknar ju index 0-11) 
            //5. I sql-queryn använder jag sedan SelectedID som då kommer att bli nr. 13, det vill säga en ny rad i genre-listan. 
            //6. Exekverar och stänger ner connection. 

            foreach (Genre genree in Genre.genres)
            {
                count++;
            }
            int max = count - 2;           
            int selectedID = Genre.genres[max].id;

            //Nu kan jag adda artist och ange den nya genren som foreign key. Öppnar en ny connection och exekverar. 
            conn.Open();
            string sqlQuery2 = $"CALL add_artist_existing_genre('{artist}','{country}', {selectedID})";
            MySqlCommand cmd2 = new MySqlCommand(sqlQuery2, conn);
            cmd2.ExecuteReader();
            conn.Close();
                  
            Console.WriteLine($"Artist '{artist}' part of the new genre {genre} was successfully added to the artist table. " +
             $"Press any button to get the new artist list. ");
            Console.ReadKey();
            Console.Clear();
            conn.Close();
            GetGenresAndArtists(conn);
        }
        public static void AddRecordSameArtist(MySqlConnection conn)
        {
            Console.Write("Enter the title of the record: ");
            string title = ReadNull();
            Console.Clear();
            Console.Write("Enter the year when the record was recorded: ");
            int year = ReadInt();
            
            Console.WriteLine();
            Console.WriteLine("Fetching artists...");           
            if (Artist.artists.Count == 0)
            {
                RetrieveDataFromArtists(conn);
                Console.Clear();
            }
            int count = 1;           
            foreach (Artist artist in Artist.artists)
            {
                Console.WriteLine($"{count}. {artist.name}");
                count++;
            }           
            Console.WriteLine("Enter which existing artist the record belongs to: ");
            int input = Convert.ToInt32(Console.ReadLine());         
            int selectedID = Artist.artists[input - 1].id;           
            string sqlQuery = $"CALL add_record_existing_artist('{title}','{year}', {selectedID});";         
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);          
            cmd.ExecuteReader();
            Console.Clear();

            Console.WriteLine($"The record '{title}' by the artist '{Artist.artists[input - 1].name}', recorded in {year} was successfully added to the records table");
            Console.WriteLine("Press any button to fetch the new record list."); ;
            Console.ReadKey();
            Console.Clear();          
            conn.Close();
            GetArtistsAndRecords(conn);
        }
        public static void AddRecordNewArtistSameGenre(MySqlConnection conn)
        {
            Console.Write("Enter the title of the record: ");
            string title = ReadNull();
            Console.Clear();
            Console.Write("Enter the year when the record was recorded: ");
            int year = ReadInt();
            Console.Clear();

            Console.Write($"Enter the artist of the record {title}: ");
            string artista = ReadNull();
            Console.Clear();
            Console.Write($"Enter the country of the artist {artista}: ");
            string country = ReadNull();

            int count = 1;
            int count2 = 1;
            int input = 0;
            int selectedID = 0;

            Console.WriteLine("Fetching existing genres...");
            RetrieveDataFromGenres(conn);
            foreach (Genre genre in Genre.genres)
            {
                Console.WriteLine($"{count}. {genre.genre}");
                count++;
            }     
            Console.WriteLine("Enter which existing genre the artist belongs to: ");
            input = ReadInt();  
            selectedID = Genre.genres[input - 1].id;

            conn.Open();
            string sqlQuery = $"CALL add_artist_existing_genre('{artista}','{country}', {selectedID});";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            cmd.ExecuteReader();
            conn.Close();

            RetrieveDataFromArtists(conn);
            Console.Clear();
            foreach (Artist artist in Artist.artists)
                count2++;

            int maxElement = count2 - 2;
            selectedID = Artist.artists[maxElement].id;

            conn.Open();
            string sqlQuery3 = $"CALL add_record_existing_artist('{title}',{year},{selectedID});";
            MySqlCommand cmd3 = new MySqlCommand(sqlQuery3, conn);
            cmd3.ExecuteReader();

            conn.Close();
            Console.Clear();

            Console.WriteLine($"The record '{title}' by the artist '{artista}', recorded in {year} was successfully added to the records table");
            Console.WriteLine("Press any button to get the new record list. "); 
            Console.ReadKey();
            GetArtistsAndRecords(conn);
        }
        public static void AddRecordNewArtistNewGenre(MySqlConnection conn)
        {

            Console.Write("Enter the title of the record: ");
            string title = ReadNull();
            Console.Clear();

            Console.Write($"Enter the year when '{title}' was recorded: ");
            int year = ReadInt();
            Console.Clear();

            Console.Write($"Enter the artist of the record {title}: ");
            string artist = ReadNull();
            Console.Clear();

            Console.Write($"Enter the country of the artist {artist}: ");
            string country = ReadNull();
            Console.Clear();

            Console.WriteLine("Enter the genre of the artist and record: ");
            string genre = ReadNull();
            Console.Clear();

            int count = 1;
            int count2 = 1;
            int selectedID = 0;
            int max = 0;
        
            conn.Open();
            string sqlQuery = $"CALL add_genre('{genre}')";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            cmd.ExecuteReader();
            conn.Close();

            RetrieveDataFromGenres(conn);
            Console.Clear();

            foreach (Genre genree in Genre.genres)
                count++;

            max = count - 2;
            selectedID = Genre.genres[max].id;

            conn.Open();
            string sqlQuery2 = $"CALL add_artist_existing_genre('{artist}','{country}', {selectedID});";
            MySqlCommand cmd2 = new MySqlCommand(sqlQuery2, conn);
            cmd2.ExecuteReader();
            conn.Close();
            RetrieveDataFromArtists(conn);
            Console.Clear();
            foreach (Artist artiste in Artist.artists)
                count2++;

            int maxElement2 = count2 - 2;
            int selectedID2 = Artist.artists[maxElement2].id;

            conn.Open();
            string sqlQuery3 = $"CALL add_record_existing_artist('{title}',{year},{selectedID2});";
            MySqlCommand cmd3 = new MySqlCommand(sqlQuery3, conn);
            cmd3.ExecuteReader();


            Console.WriteLine($"The record '{title}' by the artist '{artist}', recorded in {year} was successfully added to the records table");
            Console.WriteLine("Press any button to get the new record list. ");
            Console.ReadKey();
            conn.Close();
            GetArtistsAndRecords(conn);  
        }
        public static void DistributeRecordToSeller(MySqlConnection conn)
        {
            //Fetch Records and let user chose one
            Console.WriteLine("Fetching records from the database...");
                RetrieveDataFromRecords(conn);
                Console.Clear();
            
            int count2 = 1;
            foreach (Record record in Record.records)
            {
                Console.WriteLine($"{count2}. {record.title}");
                count2++;
            }

            Console.WriteLine();
            Console.Write("Enter the number of the record you want to distribute: ");
            int title = ReadInt();
            int selectedID = Record.records[title - 1].id;
            Console.Clear();

            Console.WriteLine("Fetching sellers from the databse...");
            //Fetch sellers and let user chose one                   
            if (Seller.sellers.Count == 0)
            {
                RetrieveDataFromSellers(conn);
                Console.Clear();
            }
            int count = 1;
            foreach (Seller seller in Seller.sellers)
            {
                Console.WriteLine($"{count}. {seller.name}");
                count++;
            }

            Console.Write($"Enter which seller to distribute the chosen record '{Record.records[title - 1].title}' to: ");
            int sellerPick = ReadInt();
            int selectedSellerID = Seller.sellers[sellerPick - 1].id;
            Console.Clear();

            //Seller_has_records
            Console.Write($"Enter {Seller.sellers[sellerPick - 1].name}'s price for the record '{Record.records[title - 1].title}' (In Swedish Crones [kr]: ");
            int price = ReadInt();
            Console.Write("Which condition is the record in? (M/NM/M/VG/G/P): ");
            string condition = ReadNull();

            string sqlQuery = $"CALL distribute_record_to_seller({selectedSellerID},{selectedID},{price},'{condition}');";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            cmd.ExecuteReader();
        
            //Close DB connection
            conn.Close();
            Console.WriteLine($"The record {Record.records[title - 1].title} was successfully distributed to the seller {Seller.sellers[sellerPick - 1].name}");
            Console.WriteLine($"The price is {price} and the condition is {condition}. ");
            Console.Write("Press any key to get the sellers records list");
            Console.ReadKey();
            conn.Close();
            Console.Clear();
            GetSellersRecords(conn);
        }            
          

        #endregion
        #region RetrieveData Methods
       
        public static void RetrieveAndPrintDataFromRecords(MySqlConnection conn)
        {
            //SQL-query for INSERT
            string sqlQuery = "CALL records_select();";

            //Create SQLComman object
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Execute MySQlCommand  
            MySqlDataReader reader = cmd.ExecuteReader();

            //Empty records list
            Record.records.Clear();

            //While loop to write out the results to console
            while (reader.Read())
            {               
                //Write record to Console
                Console.WriteLine($"Title: {reader["records_title"]}   Recorded: {reader["records_year"]}");

                //Save data to list
                new Record(Convert.ToInt32(reader["records_id"]), reader["records_title"].ToString(), Convert.ToInt32(reader["records_year"]));
            }

            //Close database connection
            conn.Close();

            Console.Write("Data retrieved successfully! Press any key to continue: ");
            Console.ReadKey();
        }
        public static void RetrieveDataFromRecords(MySqlConnection conn)
        {
            //SQL-query for INSERT
            string sqlQuery = "CALL records_select();";

            //Create SQLComman object
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Execute MySQlCommand  
            MySqlDataReader reader = cmd.ExecuteReader();

            //Empty records list
            Record.records.Clear();

            //While loop to write out the results to console
            while (reader.Read())
            {
              
                new Record(Convert.ToInt32(reader["records_id"]), reader["records_title"].ToString(), Convert.ToInt32(reader["records_year"]));
            }

            //Close database connection
            conn.Close();

          
        }
        public static void RetrieveAndPrintDataFromGenres(MySqlConnection conn)
        {
            //SQL-query for INSERT
            string sqlQuery = "CALL genres_select();";

            //Create SQLComman object
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Execute MySQlCommand  
            MySqlDataReader reader = cmd.ExecuteReader();

            //Empty records list
            Record.records.Clear();

            //While loop to write out the results to console
            while (reader.Read())
            {
                //Write record to Console
                Console.WriteLine($"Genre: {reader["genres_genre"]}");

                //Save data to list
                new Genre(Convert.ToInt32(reader["genres_id"]),
                    reader["genres_genre"].ToString());
            }

            //Close database connection
            conn.Close();


            Console.Write("Data retrieved successfully! Press any key to continue: ");
            Console.ReadKey();
        }
        public static void RetrieveDataFromGenres(MySqlConnection conn)
        {
            //SQL-query for INSERT
            string sqlQuery = "CALL genres_select();";

            //Create SQLComman object
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Execute MySQlCommand  
            MySqlDataReader reader = cmd.ExecuteReader();

            //Empty records list
            Record.records.Clear();

            //While loop to write out the results to console
            while (reader.Read())
            {
                
                //Save data to list
                new Genre(Convert.ToInt32(reader["genres_id"]),
                    reader["genres_genre"].ToString());
            }

            //Close database connection
            conn.Close();


        }
        public static void RetrieveAndPrintDataFromArtists(MySqlConnection conn)
        {
            //SQL-query for INSERT
            string sqlQuery = "CALL artists_select();";

            //Create SQLComman object
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Execute MySQlCommand  
            MySqlDataReader reader = cmd.ExecuteReader();

            //Empty records list
            Artist.artists.Clear();

            //While loop to write out the results to console
            while (reader.Read())
            {
                //Write record to Console
                Console.WriteLine($"Artist: {reader["artists_name"]} Nationality: {reader["artists_nationality"]}");

                //Save data to list
                new Artist(Convert.ToInt32(reader["artists_id"]),
                    reader["artists_name"].ToString(), reader["artists_nationality"].ToString());
            }

            //Close database connection
            conn.Close();

            Console.Write("Data retrieved successfully! Press any key to continue: ");
            Console.ReadKey();
        }
        public static void RetrieveDataFromArtists(MySqlConnection conn)
        {
            //SQL-query for INSERT
            string sqlQuery = "CALL artists_select();";

            //Create SQLComman object
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Execute MySQlCommand  
            MySqlDataReader reader = cmd.ExecuteReader();

            //Empty records list
            Artist.artists.Clear();

            //While loop to write out the results to console
            while (reader.Read())
            {
                
                new Artist(Convert.ToInt32(reader["artists_id"]),
                    reader["artists_name"].ToString(), reader["artists_nationality"].ToString());
            }

            //Close database connection
            conn.Close();

      
        }
        public static void RetrieveAndPrintDataFromSellers(MySqlConnection conn)
        {
            //SQL-query for INSERT
            string sqlQuery = "CALL sellers_select();";

            //Create SQLComman object
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Execute MySQlCommand  
            MySqlDataReader reader = cmd.ExecuteReader();

            //Empty records list
            Seller.sellers.Clear();

            //While loop to write out the results to console
            while (reader.Read())
            {
                //Write record to Console
                Console.WriteLine($"Seller: {reader["sellers_name"]}");

                //Save data to list
                new Seller(Convert.ToInt32(reader["sellers_id"]),
                    reader["sellers_name"].ToString());
            }

            //Close database connection
            conn.Close();

            Console.Write("Data retrieved successfully! Press any key to continue: ");
            Console.ReadKey();
        }
        public static void RetrieveDataFromSellers(MySqlConnection conn)
        {
            //SQL-query for INSERT
            string sqlQuery = "CALL sellers_select();";

            //Create SQLComman object
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Execute MySQlCommand  
            MySqlDataReader reader = cmd.ExecuteReader();

            //Empty records list
            Seller.sellers.Clear();

            //While loop to write out the results to console
            while (reader.Read())
            {
               
                //Save data to list
                new Seller(Convert.ToInt32(reader["sellers_id"]),
                    reader["sellers_name"].ToString());
            }

            //Close database connection
            conn.Close();

        
        }
        public static void RetrieveDataFromSellersHasRecords(MySqlConnection conn)
        {
            //SQL-query for INSERT
            string sqlQuery = "CALL sellers_has_records_select();";

            //Create SQLComman object
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Execute MySQlCommand  
            MySqlDataReader reader = cmd.ExecuteReader();

            

            //While loop to write out the results to console
            while (reader.Read())
            {
                //Write record to Console
                Console.WriteLine($"Seller: {reader["sellers_sellers_id"]}");

                //Save data to list
                new Seller(Convert.ToInt32(reader["sellers_id"]),
                    reader["sellers_name"].ToString());
            }

            //Close database connection
            conn.Close();

            Console.Write("Data retrieved successfully! Press any key to continue: ");
            Console.ReadKey();
        }
        public static void RetrieveDataFromCustomers(MySqlConnection conn)
        {
            //SQL-query for INSERT
            string sqlQuery = "CALL customers_select();";

            //Create SQLComman object
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Execute MySQlCommand  
            MySqlDataReader reader = cmd.ExecuteReader();
            //While loop to write out the results to console
            while (reader.Read())
            {
                //Write record to Console
                Console.WriteLine($"Customer: {reader["customers_firstname"]}  {reader["customers_lastname"]}");

                //Save data to list
                new Customer(Convert.ToInt32(reader["customers_id"]),
                    reader["customers_firstname"].ToString(), reader["customers_lastname"].ToString());


            
            }

            //Close database connection
            conn.Close();

            Console.Write("Data retrieved successfully! Press any key to continue: ");
            Console.ReadKey();
        }
        public static void GetArtistsAndRecords(MySqlConnection conn)
        {
            //SQL-query for INSERT
            string sqlQuery = "CALL get_artists_and_records();";

            //Create SQLComman object
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Execute MySQlCommand  
            MySqlDataReader reader = cmd.ExecuteReader();

            //Empty records list
            Record.records.Clear();

            //While loop to write out the results to console
            while (reader.Read())
            {
                //Write record to Console
                Console.WriteLine($"Artist: {reader["artists_name"]} Record: {reader["records_title"]}\t  Recorded: {reader["records_year"]}");

                //Save  new Record(Convert.ToInt32(reader["records_id"]), reader["records_title"].ToString(), Convert.ToInt32(reader["records_year"]));
            }

            //Close database connection
            conn.Close();

            Console.WriteLine("Data retrieved with great success! Press any key to continue");
            Console.ReadKey();
        }
        public static void GetSellersRecords(MySqlConnection conn)
        {
            //SQL-query for INSERT
            string sqlQuery = "CALL get_sellers_records();";

            //Create SQLComman object
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Execute MySQlCommand  
            MySqlDataReader reader = cmd.ExecuteReader();

            //Empty records list
            Record.records.Clear();

            //While loop to write out the results to console
            while (reader.Read())
            {
                //Write record to Console
                Console.WriteLine($"Seller: {reader["sellers_name"]} Record: {reader["records_title"]}  Condition: {reader["sellers_has_records_condition"]} Price: {reader["sellers_has_records_price"]}");

                //Save  new Record(Convert.ToInt32(reader["records_id"]), reader["records_title"].ToString(), Convert.ToInt32(reader["records_year"]));
            }

            //Close database connection
            conn.Close();

            Console.WriteLine("Data retrieved with great success! Press any key to continue");
            Console.ReadKey();
        }
        public static void GetGenresAndArtists(MySqlConnection conn)
        {
            //SQL-query for INSERT
            string sqlQuery = "CALL get_genres_and_artists();";

            //Create SQLComman object
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Execute MySQlCommand  
            MySqlDataReader reader = cmd.ExecuteReader();

            //While loop to write out the results to console
            while (reader.Read())
            {
                //Write record to Console
                Console.WriteLine($"Genre: {reader["genres_genre"]}  Artist: {reader["artists_name"]}");              
            }

            //Close database connection
            conn.Close();

            Console.WriteLine("Data retrieved with great success! Press any key to continue");
            Console.ReadKey();
        }

        #endregion
        #region RemoveData Methods
        public static void RemoveDataFromRecords(MySqlConnection conn)
        {
                //Hämtar datan i klassen          
                RetrieveDataFromRecords(conn);
                Console.Clear();
            
            int count = 1;
            //Write list to console
            foreach (Record record in Record.records)
            {
                Console.WriteLine($"{count}. {record.title}  - {record.year}" );
                count++;
                
            }
            Console.WriteLine();

            //Användaren anger numret Count för den person som den vill ta bort.
            Console.WriteLine("Enter the number of the record that you want to remove");
            int input = Convert.ToInt32(Console.ReadLine());

            // Get the ID value from the chosen object
            int selectedID = Record.records[input - 1].id;

            //Anropa Stored Procuedure med det valda värdet -1's ID värde
            // SQL Querry för INSERT
            string sqlQuerry = $"CALL delete_record({selectedID});";

            // Skapa MySQLCOmmand objekt
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuerry, conn);

            //Exekvera MySQLCommand.
            cmd.ExecuteReader();

            //Stänger kopplingen
            conn.Close();

            Console.WriteLine($"The record {Record.records[input - 1].title} was successfully removed from the database");
            Console.Write("Press any key to fetch the new records list. ");
            Console.ReadKey();
            Console.Clear();         
            RetrieveAndPrintDataFromRecords(conn);
           
        }
        public static void RemoveDataFromGenres(MySqlConnection conn)
        {
            //If no data has earlier been fetched, get data
            if (Genre.genres.Count == 0)
            {
                RetrieveDataFromGenres(conn);
                Console.Clear();
            }
            int count = 1;
            //Write list to console
            foreach (Genre genre in Genre.genres)
            {
                Console.WriteLine($"{count}. {genre.genre}");
                count++;

            }
            Console.WriteLine("Enter the number of the genre that you want to remove");
            int genreNo = Convert.ToInt32(Console.ReadLine());

            // Get the ID value from the chosen object
            int selectedID = Genre.genres[genreNo - 1].id;
      

            //CALL SP Insert query
            string sqlQuery = $"CALL delete_genre({selectedID});";

            // Skapa MySQLCOmmand objekt
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Exekvera MySQLCommand.
            cmd.ExecuteReader();

            //Stänger kopplingen
            conn.Close();
            Console.Clear();
            Console.WriteLine($"The genre {Genre.genres[genreNo - 1].genre} was successfully removed from the database");
            Console.Write("Press any key to fetch the new genre list. ");
            Console.ReadKey();
            Console.Clear();


            //Anropa och skriv ut den nya tabellen
       
            RetrieveAndPrintDataFromGenres(conn);

        }
        public static void RemoveDataFromArtists(MySqlConnection conn)
        {
            //If no data has earlier been fetched, get data
            if (Artist.artists.Count == 0)
            {
                RetrieveDataFromArtists(conn);
                Console.Clear();
            }
            int count = 1;
            //Write list to console
            foreach (Artist artist in Artist.artists)
            {
                Console.WriteLine($"{count}. {artist.name}");
                count++;

            }
            Console.WriteLine("Enter the number of the artist that you want to delete");
            int artistNo = Convert.ToInt32(Console.ReadLine());

            // Get the ID value from the chosen object
            int selectedID = Artist.artists[artistNo - 1].id;


            //CALL SP Insert query
            string sqlQuery = $"CALL delete_artist({selectedID});";

            // Skapa MySQLCOmmand objekt
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Exekvera MySQLCommand.
            cmd.ExecuteReader();

            //Stänger kopplingen
            conn.Close();
            Console.Clear();

            Console.WriteLine($"The artist {Artist.artists[artistNo - 1].name} was successfully removed from the database");
            Console.Write("Press any key to fetch the new artists list. ");
            Console.ReadKey();
            Console.Clear();
      
            RetrieveAndPrintDataFromArtists(conn);
        
    }
        #endregion
        #region UpdateData Methods
        public static void UpdateRecords(MySqlConnection conn)
        {
           
            RetrieveDataFromRecords(conn);
            Console.Clear();           
            int count = 1;
            //Write list to console
            foreach (Record record in Record.records)
            {
                Console.WriteLine($"{count}. {record.title}  - {record.year}");
                count++;
            }
            Console.WriteLine("Enter the number of the record that you want to update");
            int recordNo = ReadInt();
            int selectedID = Record.records[recordNo - 1].id;

            Console.Clear();
            Console.WriteLine("Chose what you want to update");
            Console.WriteLine("1: Update only the record title");
            Console.WriteLine("2: Update only the record year");
            Console.WriteLine("3: Update both the title and year");
            Console.WriteLine();
            Console.WriteLine("4: Cancel update and return to main menu");


            int choice = ReadInt();
            string title = "";
            int year = 0;
            string sqlQuery = "";
            switch (choice)
            {
                case 1:
                    Console.Write($"To which name do you want to change {Record.records[recordNo - 1].title}?: ");
                    title = ReadNull();            
                    sqlQuery = $"CALL update_record_title({selectedID},'{title}');";
                    break;
                case 2:
                    Console.Write($"To which year do you want to change {Record.records[recordNo - 1].title} which currently has the year {Record.records[recordNo - 1].year}: ");
                    year = ReadInt();
                    sqlQuery = $"CALL update_record_year({selectedID},{year});";
                    break;
                case 3:
                    Console.Write($"To which name do you want to change {Record.records[recordNo - 1].title}?: ");
                    title = ReadNull();
                    Console.Write($"To which year do you want to change {Record.records[recordNo - 1].title} which currently has the year {Record.records[recordNo - 1].year}: ");
                    year = ReadInt();
                    sqlQuery = $"CALL update_record_title({selectedID},'{title}'); CALL update_record_year({selectedID}, {year});";
                    break;
                case 4: return;
                default: return;
            }         
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            cmd.ExecuteReader();       
            conn.Close();
            Console.Clear();

            Console.Write("Data was successfully updated. Press any key to get the updated list of records: ");
            Console.ReadKey();
            RetrieveAndPrintDataFromRecords(conn);
        }
        public static void UpdateGenres(MySqlConnection conn)
        {
          
                RetrieveDataFromGenres(conn);
                Console.Clear();
            
            int count = 1;
            //Write list to console
            foreach (Genre genre in Genre.genres)
            {
                Console.WriteLine($"{count}. {genre.genre}");
                count++;

            }
            Console.WriteLine("Enter the number of the genre that you want to update");
            int genreNo = ReadInt();
            int selectedID = Genre.genres[genreNo - 1].id;

            Console.Write($"To what do you want to rename {Genre.genres[genreNo - 1].genre} to?: ");
            string newGenre = ReadNull();  
            string sqlQuery = $"CALL update_genre({selectedID},'{newGenre}');";
        
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);          
            cmd.ExecuteReader();      
            conn.Close();
            Console.Clear();

            Console.Write("Data was successfully updated. Press any key to get the updated list of genres: ");
            Console.ReadKey();
            RetrieveAndPrintDataFromGenres(conn);
        }
        public static void UpdateArtists(MySqlConnection conn)
        {
          
                RetrieveDataFromArtists(conn);
                Console.Clear();
            
            int count = 1;
            //Write list to console
            foreach (Artist artist in Artist.artists)
            {
                Console.WriteLine($"{count}. {artist.name}");
                count++;
            }
            Console.Write("Enter the number of the artist that you want to update: ");
            int artistNo = ReadInt();

            int selectedID = Artist.artists[artistNo - 1].id;
            string selectedName = Artist.artists[artistNo - 1].name;
            string selectedCountry = Artist.artists[artistNo - 1].nationality;
            int input = 0;
            string newArtist = "";
            string newCountry = "";
            string sqlQuery = "";

            Console.Clear();
            Console.WriteLine($"You picked the artist {selectedName} from the country {selectedCountry}.");
            Console.WriteLine();
            Console.WriteLine("Chose what you want to update");
            Console.WriteLine("1: Update only the artist's name");
            Console.WriteLine("2: Update only the artist's country");
            Console.WriteLine("3: Update both the name and country");
            Console.WriteLine();
            Console.WriteLine("4: Cancel update and return to main menu");

            input = ReadInt();

            switch (input)
            {
                case 1:
                    Console.Write($"Enter the new name for artist {selectedName}: ");
                    newArtist = ReadNull();
                    Console.Clear();
                    sqlQuery = $"CALL update_artist({selectedID},'{newArtist}');";
                    break;

                case 2:
                    Console.Write($"Enter the new country for {selectedName}: ");
                    newCountry = ReadNull();
                    Console.Clear();
                    sqlQuery = $"CALL update_artist_country({selectedID},'{newCountry}');";
                    break;
                case 3:
                    Console.Write($"To what do you want to change {selectedName} name to?: ");
                    newArtist = ReadNull();
                    Console.Write($"Enter the new country of the artist: ");
                    newCountry = ReadNull();
                    Console.Clear();
                    sqlQuery = $"CALL update_artist({selectedID},'{newArtist}'); CALL update_artist_country({selectedID},'{newCountry}');";
                    break;

                case 4: return;
                default: return;
                  
            }

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Exekvera MySQLCommand.
            cmd.ExecuteReader();

            //Stänger kopplingen
            conn.Close();

            //Anropa och skriv ut den nya tabellen
            Console.Clear();

            Console.Write("Data was successfully updated. Press any key to get the updated list of artists: ");
            Console.ReadKey();
            RetrieveAndPrintDataFromArtists(conn);

        }

        #endregion
        #region Exceptions
        //Två metoder här för att hantera om användaren ej skriver siffra i int eller strängen är null. 
        static int ReadInt()
        {
            //Returnerar INT om den går att parsa, annars får användaren ange ett nytt värde
            int heltal;
            while (int.TryParse(Console.ReadLine(), out heltal) == false)
            {
                Console.WriteLine("You did not enter a number. Please try again.");
            }
            return heltal;
        }      
        // Läser av om strängen är tom. Är den det så får användaren skriva in igen. Annars returnerar värdet. 
        static string ReadNull()
        {
            string input = Console.ReadLine();
            while (input.Trim(' ') == String.Empty)
            {
                
                Console.Write("You did not write anything. Please try again.");
                input = Console.ReadLine();
            }
            return input;
        }

        #endregion
        #region Other Procedures
       
        public static void SearchCheapestRecord(MySqlConnection conn)
        {
            Console.WriteLine("Enter a searchword and the Datebase will return the cheapest records to that searchword.");
            Console.WriteLine("You will also see which seller has that record, the price and its condition");
            Console.WriteLine();
            Console.WriteLine("Enter searchword for records");
            string input = Console.ReadLine();


            //SQL-query for INSERT
            string sqlQuery = $"CALL search_cheapest_record('{input}');";

            //Create SQLComman object
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Execute MySQlCommand  
            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                //Write record to Console
                Console.WriteLine($"Record: {reader["records_title"]} Price: {reader["records_price"]} Condition: {reader["records_condition"]} Seller: {reader["sellers_name"]}");

                //Save  new Record(Convert.ToInt32(reader["records_id"]), reader["records_title"].ToString(), Convert.ToInt32(reader["records_year"]));
            }

            //Close database connection
            conn.Close();

            Console.WriteLine("Data retrieved with great success! Press any key to continue");
            Console.ReadKey();
        }

        public static void SearchRecordsByGenre(MySqlConnection conn)
        {
            Console.WriteLine("Enter a genre and the datebase will return all artists and records connected to that genre");
           
          
                string input = ReadNull();
       
            
            
           
           
            
            string sqlQuery = $"CALL search_records_by_genre('{input}');";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);     
            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
               
                    Console.WriteLine($"Genre: {reader["genres_genre"]} Artist: {reader["artists_name"]} Record: {reader["records_title"]}");
              
                
          
               


            }

            //Close database connection
            conn.Close();

            Console.WriteLine("Data retrieved with great success! Press any key to continue");
            Console.ReadKey();
        }
   
        public static void EnterPriceInterval(MySqlConnection conn)
        {
            Console.WriteLine("Enter a price interval and the database will return records of that interval");
            Console.Write("Enter max price: ");
            int priceMax = ReadInt();
            Console.Write("Enter min price: ");
            int priceMin = ReadInt();


            //SQL-query for INSERT
            string sqlQuery = $"CALL records_price_interval({priceMin}, {priceMax});";

            //Create SQLComman object
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            //Execute MySQlCommand  
            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                //Write record to Console
                Console.WriteLine($"Record: {reader["records_title"]} Price: {reader["sellers_has_records_price"]}");

                //Save  new Record(Convert.ToInt32(reader["records_id"]), reader["records_title"].ToString(), Convert.ToInt32(reader["records_year"]));
            }

            //Close database connection
            conn.Close();

            Console.WriteLine("Data retrieved with great success! Press any key to continue");
            Console.ReadKey();



        }















        #endregion
    }
}