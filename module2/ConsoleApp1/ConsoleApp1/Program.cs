using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\GitHub\\Programming-CS\\module2\\ConsoleApp1\\ConsoleApp1\\Database1.mdf;Integrated Security=True";
        string query = "SELECT Aeroport.numberOfRace, Aeroport.placeOfArivale, Aeroport.numberOfSeats, Aeroport.flightTime, Aeroport.priceOfTicket FROM Aeroport";
        int minPrice = 7000;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int numberOfRace = Convert.ToInt32(reader["numberOfRace"]);
                        string placeOfArivale = Convert.ToString(reader["placeOfArivale"]);
                        int numberOfSeats = Convert.ToInt32(reader["numberOfSeats"]);
                        int priceOfTicket = Convert.ToInt32(reader["priceOfTicket"]);

                        Console.WriteLine($"Number of Race: {numberOfRace}, Place of Arrival: {placeOfArivale}, Number of Seats: {numberOfSeats}, Price of Ticket: {priceOfTicket}");
                    }
                }
            }
        }

        Console.WriteLine("=======================================");

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (minPrice <= Convert.ToInt32(reader["priceOfTicket"]))
                        {
                            int numberOfRace = Convert.ToInt32(reader["numberOfRace"]);
                            string placeOfArivale = Convert.ToString(reader["placeOfArivale"]);

                            Console.WriteLine($"Number of Race: {numberOfRace}, Place of Arrival: {placeOfArivale}");
                        }
                    }
                }
            }
        }
    }
}