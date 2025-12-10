using System;
using System.Collections.Generic;
using System.Text;

namespace Cardagain.Sessions
{
    public class UserInfo
    {
        public ulong UserId;
        public string UserName;

        public List<UserSession> Sessions = new List<UserSession>();
    }

    public class UserSession
    {
        public Session Session;
        public UserInfo User;
        public List<Decks.Card> Hand = new List<Decks.Card>();

        public UserSession(Session session, UserInfo user)
        {
            Session = session;
            User = user;
        }
    }
}
