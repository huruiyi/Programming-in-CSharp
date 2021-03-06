﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace AsynchronousServer
{
    public class StateObject
    {
        // Client socket.
        public Socket WorkSocket;

        // Size of receive buffer.
        public const int BufferSize = 1024;

        // Receive buffer.
        public byte[] Buffer = new byte[BufferSize];

        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    public class AsynchronousServer
    {
        // Thread signal.
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public static void StartListening()
        {
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket. The DNS name of the computer running the
            // listener is "host.contoso.com".
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());

            //IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            //IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(hostEntry.AddressList[0], 11000);

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(localEndPoint);
            listener.Listen(100);

            while (true)
            {
                // Set the event to nonsignaled state.
                allDone.Reset();

                // Start an asynchronous socket to listen for connections.
                Console.WriteLine("Waiting for a connection...");
                listener.BeginAccept(AcceptCallback, listener);

                // Wait until a connection is made before continuing.
                allDone.WaitOne();
            }
        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();

            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            StateObject state = new StateObject
            {
                WorkSocket = handler
            };
            handler.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, ReadCallback, state);
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            String content;

            // Retrieve the state object and the handler socket from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.WorkSocket;

            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There might be more data, so store the data received so far.
                state.sb.Append(Encoding.ASCII.GetString(state.Buffer, 0, bytesRead));

                // Check for end-of-file tag. If it is not there, read more data.
                content = state.sb.ToString();
                if (content.IndexOf("<EOF>") > -1)
                {
                    // All the data has been read from the client. Display it on the console.
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}", content.Length, content);
                    // Echo the data back to the client.
                    Send(handler, content);
                }
                else
                {
                    // Not all data received. Get more.
                    handler.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, ReadCallback, state);
                }
            }
        }

        private static void Send(Socket handler, String data)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            handler.BeginSend(byteData, 0, byteData.Length, 0, SendCallback, handler);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            Socket handler = (Socket)ar.AsyncState;

            int bytesSent = handler.EndSend(ar);
            Console.WriteLine("Sent {0} bytes to client.", bytesSent);

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }

        public static int Main(String[] args)
        {
            StartListening();
            return 0;
        }
    }
}