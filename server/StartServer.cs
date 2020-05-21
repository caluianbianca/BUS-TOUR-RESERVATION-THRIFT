using System;
using System.Collections.Generic;
using System.Text;


using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;


namespace server
{
    class StartServer
    {
        static void Main(string[] args)
        {
            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();
            IDictionary props = new Hashtable();

            props["port"] = 55555;
            TcpChannel channel = new TcpChannel(props, clientProv, serverProv);
            ChannelServices.RegisterChannel(channel, false);

         

            ServerImpl service = new ServerImpl();

            RemotingServices.Marshal(service, "Chat");
            //server.Start();
            Console.WriteLine("Server started...");
            Console.ReadLine();
        }
    }
}
