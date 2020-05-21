using model;
using System;
using System.Collections.Generic;
using System.Text;

namespace server
{
    public class ServerImpl : IService
    {
        private readonly IDictionary<User1, IObserver> loggedClients;

        public ServerImpl()
        {
            loggedClients = new Dictionary<User1, IObserver>();
        }

        public void loggedIn(User1 user, IObserver observer)
        {
            loggedClients[user] = observer;
        }

        public void reservationSaved()
        {
            savedNotifyAll();
        }

        private void savedNotifyAll()
        {
            foreach (IObserver observer in loggedClients.Values)
            {
                observer.seatsReserved();
            
            }
        }
    }
}
