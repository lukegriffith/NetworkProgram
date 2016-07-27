using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
          
			var listener = new Listener(10003);
			listener.Start();
			listener.Listen();

        }
    }

	public class Listener 
	{

		private TcpListener listener;

		public IPAddress Ip;

		public int Port;		

		/*
			Method constructs the TCP listener, and initiates the end point.
			After this the machine is listening on the desired port. 

		*/

		// Methods	
		public void  Start() 
		{

			Logger.log(Ip.ToString());

			Logger.log(Port.ToString());

			var endPoint = new System.Net.IPEndPoint(Ip, Port);

			listener = new TcpListener(endPoint);
			listener.Start();	
		}	


		public void Listen() 
		{

			Logger.log("Starting to listen.");


			while (true) 
			{
				/*

					Need to learn more about Task type, and c# async programming.

				*/

				Task client = this.listener.AcceptTcpClientAsync();
				
				Logger.log("Connecting");

				while (client.IsCompleted == false)
				{
					

					

				}
	

			}

		}


		// Constructors
		public Listener(int Port) 
		{
			// This puts any IP address into the listener. 
			this.Ip = IPAddress.Any;
			this.Port = Port;

		}

		public Listener(string Ip, int Port)
	 	{
			this.Ip = System.Net.IPAddress.Parse(Ip);
			this.Port = Port;
		}




	
	}

	/*
		Abstract static logger, used to write output for program. 
		This can be changed to debug, log4net, etc at a later date. 

	*/
	public static class Logger
	{

		public static void log(string message)
		{
	
			Console.WriteLine(message);
			

		}


	}

}
