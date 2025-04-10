using System; // For DBNull, ValueTuple
using System.Configuration; // For potentially reading parts from app.config later
using System.Data.OleDb; // For Access connection
using System.IO;         // For Path.Combine
using System.Windows.Forms; // For Application.StartupPath (consider alternatives for non-WinForms DAL)
using BCrypt.Net; // For password hashing
using System.Data; // For CommandType
using System.Threading.Tasks; // For Task
using WeatherSphereV4.Models;
using System.Collections.Generic; // For List<T>

namespace WeatherSphereV4.Services // Or WeatherSphereV4.DataAccess
{
    public static class DatabaseManager
    {
        private static readonly string connectionString;
        private static bool isInitialized = false;
        private static string databaseFilePath = "";

        // Static constructor: Runs once when the class is first accessed.
        static DatabaseManager()
        {
            try
            {
                // --- VERY IMPORTANT: Adjust this path if needed ---
                // This assumes your DB file is in a "Database" subfolder relative to your executable.
                // If you saved WeatherSphereDB.accdb directly in the output folder (e.g., bin\Debug),
                // change databaseRelativePath to "WeatherSphereDB.accdb".
                // If it's elsewhere, provide the correct relative or absolute path.
                string databaseRelativePath = @"Database\WeatherSphereDB.accdb";
                // --- End Adjustment ---

                // Construct the full path to the database file
                // Application.StartupPath gives the path to the executing assembly (e.g., bin\Debug)
                databaseFilePath = Path.Combine(Application.StartupPath, databaseRelativePath);

                Console.WriteLine($"Database Path: {databaseFilePath}"); // Debugging output

                // Check if the database file actually exists
                if (!File.Exists(databaseFilePath))
                {
                    // Log the error clearly
                    string errorMsg = $"Database file not found at expected location: {databaseFilePath}";
                    Console.WriteLine($"FATAL ERROR: {errorMsg}");
                    // You might throw an exception or use a more robust error handling mechanism
                    // For now, we set connectionString to null, and initialization fails.
                    connectionString = null;
                    MessageBox.Show(errorMsg, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Stop initialization
                }

                // Define the OLEDB Provider.
                // Microsoft.ACE.OLEDB.12.0 is standard for .accdb files (requires Access Database Engine Redistributable).
                // Use Microsoft.Jet.OLEDB.4.0 for older .mdb files (might require 32-bit target).
                string provider = "Microsoft.ACE.OLEDB.12.0"; // Or "Provider=Microsoft.Jet.OLEDB.4.0;" for MDB

                // Construct the connection string
                connectionString = $"Provider={provider};Data Source={databaseFilePath};";

                // Optional: You can add password protection here if your Access DB is password protected:
                // connectionString += "Jet OLEDB:Database Password=YourPassword;";

                isInitialized = true;
                Console.WriteLine("DatabaseManager initialized successfully.");
            }
            catch (Exception ex)
            {
                // Catch any other unexpected errors during initialization
                Console.WriteLine($"FATAL ERROR during DatabaseManager initialization: {ex.ToString()}");
                connectionString = null;
                MessageBox.Show($"Failed to initialize database connection: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isInitialized = false;
            }
        }

        /// <summary>
        /// Checks if the DatabaseManager was initialized successfully.
        /// </summary>
        public static bool IsInitialized => isInitialized;

        /// <summary>
        /// Gets a new OleDbConnection object. Remember to dispose of it using 'using'.
        /// Returns null if the DatabaseManager failed to initialize.
        /// </summary>
        /// <returns>A new OleDbConnection or null.</returns>
        private static OleDbConnection GetConnection()
        {
            if (!isInitialized || connectionString == null)
            {
                Console.WriteLine("Attempted to get connection, but DatabaseManager is not initialized.");
                return null; // Or throw an exception
            }
            return new OleDbConnection(connectionString);
        }

        /// <summary>
        /// Hashes a plain text password using BCrypt.
        /// </summary>
        /// <param name="password">The plain text password to hash.</param>
        /// <returns>A securely hashed password string (including salt).</returns>
        public static string HashPassword(string password)
        {
            // BCrypt.Net automatically generates a salt and includes it in the hash output
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Verifies if a plain text password matches a stored BCrypt hash.
        /// </summary>
        /// <param name="enteredPassword">The plain text password entered by the user.</param>
        /// <param name="storedHash">The BCrypt hash retrieved from the database.</param>
        /// <returns>True if the password matches the hash, false otherwise.</returns>
        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            try
            {
                // BCrypt.Verify extracts the salt from storedHash and compares
                return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
            }
            catch (Exception ex)
            {
                // Handle potential errors during verification (e.g., invalid hash format)
                Console.WriteLine($"Error during password verification: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Attempts to create a new user in the database. Checks for duplicate username first.
        /// </summary>
        /// <param name="username">The desired username.</param>
        /// <param name="passwordHash">The BCrypt hashed password.</param>
        /// <returns>True if user was created successfully, False if username already exists or an error occurred.</returns>
        public static async Task<bool> CreateUserAsync(string username, string passwordHash)
        {
            // Ensure connection string was initialized properly
            if (!IsInitialized)
            {
                Console.WriteLine("CreateUserAsync failed: DatabaseManager not initialized.");
                return false;
            }

            // 1. Check if username already exists
            int userCount = 0;
            string checkUserSql = "SELECT COUNT(*) FROM Users WHERE Username = ?"; // Use ? for OleDb parameters

            using (OleDbConnection connCheck = GetConnection()) // Use using for automatic disposal
            {
                if (connCheck == null) return false; // Initialization failed earlier

                using (OleDbCommand cmdCheck = new OleDbCommand(checkUserSql, connCheck))
                {
                    // Add parameter securely
                    cmdCheck.Parameters.AddWithValue("@p1", username); // Parameter name doesn't matter much for OleDb with '?'

                    try
                    {
                        await connCheck.OpenAsync();
                        object result = await cmdCheck.ExecuteScalarAsync(); // Gets the first column of the first row
                        if (result != null && result != DBNull.Value)
                        {
                            userCount = Convert.ToInt32(result);
                        }
                    }
                    catch (OleDbException ex)
                    {
                        Console.WriteLine($"Database Error checking username '{username}': {ex.Message}");
                        return false; // Indicate failure
                    }
                    catch (Exception ex) // Catch other potential errors
                    {
                        Console.WriteLine($"General Error checking username '{username}': {ex.Message}");
                        return false;
                    }
                    // Connection closed automatically by 'using' block
                }
            }

            // If username exists, return false
            if (userCount > 0)
            {
                Console.WriteLine($"Username '{username}' already exists.");
                return false; // Indicate username taken
            }

            // 2. Insert the new user if username doesn't exist
            string insertSql = "INSERT INTO Users (Username, PasswordHash, DateCreated) VALUES (?, ?, ?)";

            using (OleDbConnection connInsert = GetConnection())
            {
                if (connInsert == null) return false;

                using (OleDbCommand cmdInsert = new OleDbCommand(insertSql, connInsert))
                {
                    // Add parameters securely with specific types
                    cmdInsert.Parameters.Add("@pUsername", OleDbType.VarWChar).Value = username;
                    cmdInsert.Parameters.Add("@pPasswordHash", OleDbType.LongVarWChar).Value = passwordHash; // Use LongVarWChar for Long Text
                    cmdInsert.Parameters.Add("@pDateCreated", OleDbType.Date).Value = DateTime.Now;

                    try
                    {
                        await connInsert.OpenAsync();
                        int rowsAffected = await cmdInsert.ExecuteNonQueryAsync(); // Returns number of rows affected

                        // Check if exactly one row was inserted
                        if (rowsAffected == 1)
                        {
                            Console.WriteLine($"User '{username}' created successfully.");
                            return true; // Success!
                        }
                        else
                        {
                            Console.WriteLine($"Failed to insert user '{username}'. Rows affected: {rowsAffected}");
                            return false; // Insertion failed
                        }
                    }
                    catch (OleDbException ex)
                    {
                        Console.WriteLine($"Database Error creating user '{username}': {ex.Message}");
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"General Error creating user '{username}': {ex.Message}");
                        return false;
                    }
                    // Connection closed automatically by 'using' block
                }
            }
        }

        /// <summary>
        /// Retrieves the stored password hash and UserID for a given username.
        /// </summary>
        /// <param name="username">The username to look up.</param>
        /// <returns>A tuple containing (string PasswordHash, int? UserID). Returns (null, null) if user not found or on error.</returns>
        public static async Task<(string PasswordHash, int? UserID)> GetUserLoginInfoAsync(string username)
        {
            if (!IsInitialized)
            {
                Console.WriteLine("GetUserLoginInfoAsync failed: DatabaseManager not initialized.");
                return (null, null); // Return null tuple on initialization failure
            }

            string sql = "SELECT UserID, PasswordHash FROM Users WHERE Username = ?";
            string foundHash = null;
            int? foundUserID = null;

            using (OleDbConnection conn = GetConnection())
            {
                if (conn == null) return (null, null);

                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@p1", username);

                    try
                    {
                        await conn.OpenAsync();
                        using (OleDbDataReader reader = (OleDbDataReader)await cmd.ExecuteReaderAsync()) // Cast needed for OleDb
                        {
                            if (reader.HasRows)
                            {
                                await reader.ReadAsync(); // Move to the first (and only) row

                                // Get UserID (Column 0) - Access AutoNumber is usually Int32
                                if (!await reader.IsDBNullAsync(0))
                                {
                                    foundUserID = reader.GetInt32(0);
                                }

                                // Get PasswordHash (Column 1) - We stored as Long Text
                                if (!await reader.IsDBNullAsync(1))
                                {
                                    foundHash = reader.GetString(1);
                                }
                            }
                            // If no rows, user not found, foundHash and foundUserID remain null
                        }
                        // Reader disposed automatically by 'using'
                    }
                    catch (OleDbException ex)
                    {
                        Console.WriteLine($"Database Error getting login info for '{username}': {ex.Message}");
                        return (null, null); // Return null tuple on error
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"General Error getting login info for '{username}': {ex.Message}");
                        return (null, null);
                    }
                    // Connection closed automatically by 'using'
                }
            }

            // Return the found hash and UserID (will be null if user wasn't found)
            return (foundHash, foundUserID);
        }

        /// <summary>
        /// Adds a favorite location for a specific user.
        /// </summary>
        /// <param name="userID">The ID of the user adding the favorite.</param>
        /// <param name="locationName">The display name of the location.</param>
        /// <param name="latitude">The latitude (as string).</param>
        /// <param name="longitude">The longitude (as string).</param>
        /// <returns>True if successfully added, false otherwise.</returns>
        public static async Task<bool> AddFavoriteAsync(int userID, string locationName, string latitude, string longitude)
        {
            if (!IsInitialized) return false;

            // Optional: Check if this exact favorite already exists for this user?
            // (Skipping for simplicity now, but consider adding later)

            string sql = "INSERT INTO Favorites (UserID, LocationName, Latitude, Longitude, DateAdded) VALUES (?, ?, ?, ?, ?)";

            using (OleDbConnection conn = GetConnection())
            {
                if (conn == null) return false;
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.Add("@pUserID", OleDbType.Integer).Value = userID;
                    cmd.Parameters.Add("@pLocationName", OleDbType.VarWChar).Value = locationName ?? ""; // Handle potential null
                    cmd.Parameters.Add("@pLatitude", OleDbType.VarWChar).Value = latitude ?? "";
                    cmd.Parameters.Add("@pLongitude", OleDbType.VarWChar).Value = longitude ?? "";
                    cmd.Parameters.Add("@pDateAdded", OleDbType.Date).Value = DateTime.Now;

                    try
                    {
                        await conn.OpenAsync();
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected == 1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Database Error adding favorite for UserID {userID}: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves a list of favorite locations for a specific user.
        /// </summary>
        /// <param name="userID">The ID of the user whose favorites to retrieve.</param>
        /// <returns>A list of FavoriteLocation objects, or an empty list if none found or on error.</returns>
        public static async Task<List<FavoriteLocation>> GetFavoritesAsync(int userID)
        {
            List<FavoriteLocation> favorites = new List<FavoriteLocation>();
            if (!IsInitialized) return favorites; // Return empty list

            string sql = "SELECT FavoriteID, LocationName, Latitude, Longitude, DateAdded FROM Favorites WHERE UserID = ? ORDER BY LocationName";

            using (OleDbConnection conn = GetConnection())
            {
                if (conn == null) return favorites;
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@pUserID", userID);

                    try
                    {
                        await conn.OpenAsync();
                        using (OleDbDataReader reader = (OleDbDataReader)await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                favorites.Add(new FavoriteLocation
                                {
                                    FavoriteID = reader.GetInt32(0), // Assuming FavoriteID is column 0
                                    UserID = userID, // We already know the UserID
                                    LocationName = reader.IsDBNull(1) ? null : reader.GetString(1),
                                    Latitude = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    Longitude = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    DateAdded = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4)
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Database Error getting favorites for UserID {userID}: {ex.Message}");
                        // Return potentially empty list caught so far, or clear it
                        favorites.Clear(); // Clear partial results on error
                        return favorites;
                    }
                }
            }
            return favorites;
        }

        /// <summary>
        /// Removes a specific favorite location entry, ensuring it belongs to the correct user.
        /// </summary>
        /// <param name="favoriteID">The ID of the favorite record to delete.</param>
        /// <param name="userID">The ID of the user attempting the deletion.</param>
        /// <returns>True if successfully deleted, false otherwise.</returns>
        public static async Task<bool> RemoveFavoriteAsync(int favoriteID, int userID)
        {
            if (!IsInitialized) return false;

            string sql = "DELETE FROM Favorites WHERE FavoriteID = ? AND UserID = ?"; // Match both IDs

            using (OleDbConnection conn = GetConnection())
            {
                if (conn == null) return false;
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.Add("@pFavoriteID", OleDbType.Integer).Value = favoriteID;
                    cmd.Parameters.Add("@pUserID", OleDbType.Integer).Value = userID;

                    try
                    {
                        await conn.OpenAsync();
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected == 1; // True if exactly one record matching both IDs was deleted
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Database Error removing favorite ID {favoriteID} for UserID {userID}: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Finds a specific favorite location for a user based on coordinates.
        /// </summary>
        /// <param name="userID">The user's ID.</param>
        /// <param name="latitude">The latitude to search for.</param>
        /// <param name="longitude">The longitude to search for.</param>
        /// <returns>The FavoriteLocation object if found, otherwise null.</returns>
        public static async Task<FavoriteLocation> FindFavoriteAsync(int userID, string latitude, string longitude)
        {
            if (!IsInitialized) return null;

            // Compare coordinates as strings since that's how they are stored
            string sql = "SELECT FavoriteID, LocationName, Latitude, Longitude, DateAdded FROM Favorites WHERE UserID = ? AND Latitude = ? AND Longitude = ?";
            FavoriteLocation foundFavorite = null;

            using (OleDbConnection conn = GetConnection())
            {
                if (conn == null) return null;
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@pUserID", userID);
                    cmd.Parameters.AddWithValue("@pLatitude", latitude ?? "");
                    cmd.Parameters.AddWithValue("@pLongitude", longitude ?? "");

                    try
                    {
                        await conn.OpenAsync();
                        using (OleDbDataReader reader = (OleDbDataReader)await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync()) // Check if any row was returned
                            {
                                foundFavorite = new FavoriteLocation
                                {
                                    FavoriteID = reader.GetInt32(0),
                                    UserID = userID,
                                    LocationName = reader.IsDBNull(1) ? null : reader.GetString(1),
                                    Latitude = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    Longitude = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    DateAdded = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4)
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Database Error finding favorite for UserID {userID} at ({latitude},{longitude}): {ex.Message}");
                        return null; // Return null on error
                    }
                }
            }
            return foundFavorite; // Will be null if not found
        }
    }
}