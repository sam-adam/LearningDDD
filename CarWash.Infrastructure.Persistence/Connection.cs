using System;

namespace CarWash.Infrastructure.Persistence
{
    public class Connection
    {
        private readonly String _host;
        private readonly String _database;
        private readonly String _username;
        private readonly String _password;

        public Connection(String host, String database, String username, String password)
        {
            _host = host;
            _database = database;
            _username = username;
            _password = password;
        }

        public String Host
        {
            get { return _host; }
        }

        public String Database
        {
            get { return _database; }
        }

        public String Username
        {
            get { return _username; }
        }

        public String Password
        {
            get { return _password; }
        }
    }
}