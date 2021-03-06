using System;
using MySql.Data.MySqlClient;

class Sensors : Connect
{
    //Constructor call to base case - selecting 'u_gardens' database
    public Sensors() : base("sensors") { }

    //This function needs to be called after each query function to close the connection
    public new void Close() { base.Close(); }

    //public wrapper for 'Select * FROM __' in SelectALL in Connection - return type may need to be changed after talking to Zack
    public MySqlDataReader ShowAll(string tableName) { return SelectAll(tableName); }

    public void CreateTable(string address)
    {
        //constructing query
        string query = "CREATE TABLE "+address+"(timeStamp BIGINT(20) NOT NULL PRIMARY KEY, photo BIGINT(20) NOT NULL, humidity BIGINT(20) NOT NULL, temp BIGINT(20) NOT NULL);";
        Console.Write(query);
        //Open connection
        Open();

        //Create Command
        MySqlCommand cmd = new MySqlCommand(query, connection);

        Close();

        //Create a data reader and Execute the command
        //MySqlDataReader dataReader = cmd.ExecuteReader();

    }
}
