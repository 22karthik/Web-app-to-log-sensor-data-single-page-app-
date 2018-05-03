using System;
using System.IO;
using System.IO.Ports;
using MySql.Data.MySqlClient;

using System.Collections.Generic;
using System.Collections;
class PortDataReceived
{

    //global data to connect to database
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    //constructor
    public PortDataReceived()
    {
        InitializetoDB();
    }
    public static void Main()
    {
        //connecting to database
        PortDataReceived pdr = new PortDataReceived();
        SerialPort mySerialPort = new SerialPort("COM3");

        mySerialPort.BaudRate = 115200;
        mySerialPort.Parity = Parity.None;
        mySerialPort.StopBits = StopBits.One;
        mySerialPort.DataBits = 8;
        mySerialPort.Handshake = Handshake.None;
        mySerialPort.ReadTimeout = 100;
        mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

        mySerialPort.Open();

        Console.WriteLine("Press any key to continue...");
        Console.WriteLine();
        Console.ReadKey();
        mySerialPort.Close();
    }


    private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string indata = sp.ReadExisting();
        DateTime timeStamp = DateTime.Now;
        string timedata = timeStamp.ToString();
        PortDataReceived pdr = new PortDataReceived();
        pdr.InsertToDB(timedata, indata);
        Console.WriteLine("Data Received:");
        Console.Write(indata);

    }


    //connecting to database
    //Initialize values
    private void InitializetoDB()
    {
        server = "localhost";
        database = "lora";
        uid = "root";
        password = " ";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        connection = new MySqlConnection(connectionString);
        bool isOk = OpenConnection();
        try
        {

        }
        finally
        {
            bool close = CloseConnection();
        }

    }

    private bool OpenConnection()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("cannnot connect to database" + ex);


        }
        return false;
    }
    //close connection

    private bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }

    //Insert statement
    public void InsertToDB(string timedata, string indata)
    {
        //try{
        int dest = 0;
        int src = 0;
        int packetno = 0;
        int packetlength = 0;
        
        string payload = null;
       
        string[] strArr = indata.Split(' ');




        try
        {

            dest = Int32.Parse(strArr[1]);
            src = Int32.Parse(strArr[2]);
            packetno = Int32.Parse(strArr[3]);
            packetlength = Int32.Parse(strArr[4]);
            

            payload = strArr[6];
          }


        catch (Exception e)
        {
           

            int i = 0;
            while (i != 100000)
            {
                i++;
            }

        }
       
        storeData(timedata, dest, src, packetno, packetlength, payload);
        



    }

    private void storeData(string timedata, int dest, int src, int packetno, int packetlength, string payload)
    {
        
        if (payload== null)
        { 
            int i = 0;
            while (i != 100000)
            {
                i++;
            }

        }
        string query = null;

        query = "insert into encrypted_data (time,dest,src,packetno,packetlength,encrypted_data) values('" + timedata + "','" + dest + "','" + src + "','" + packetno + "','" + packetlength + "','" + payload + "')";



        //open connection
        if (this.OpenConnection() == true)
        {
            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, connection);

            //execute command
            cmd.ExecuteNonQuery();

            //close  connection
            this.CloseConnection();


        }

    }

}
























