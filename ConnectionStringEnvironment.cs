using System;

namespace Chat_AspnetCore;

public class ConnectionStringEnvironment
{
    private string _userid;
   
    private string _server;
   
    private string _database;

    private string _password;
   
    private string _encrypt;
    
    private string _trustedconnection;

    public ConnectionStringEnvironment()
    {
        var env = new DotEnv();

        _userid = env.Get("USER_ID");
        _server = env.Get("SERVER");
        _password = env.Get("PASSWORD");
        _encrypt = env.Get("ENCRYPT");
        _trustedconnection = env.Get("TRUSTED_CONNECTION");
        _database = env.Get("DATABASE");
    }

    public override string ToString()
    {
        return $"Server={_server},1433;User Id={_userid};"
        + $"Password={_password};Database={_database};"
        + $"Encrypt={_encrypt};Trusted_Connection={_trustedconnection};"
        ;
    }
}
