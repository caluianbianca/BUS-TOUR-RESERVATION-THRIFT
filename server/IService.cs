using model;
using System;
using System.Collections.Generic;
using System.Text;

namespace server
{
    public interface IService
    {
        void reservationSaved();
        void loggedIn(User1 user, IObserver observer);
    }
}
