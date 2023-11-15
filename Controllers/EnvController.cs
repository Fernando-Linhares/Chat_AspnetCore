using Microsoft.AspNetCore.Mvc;

namespace Chat_AspnetCore.Controllers;

public class EnvController: Controller
{
    public object App()
    {
        var dotenv = new DotEnv();

        return new 
        {
            app=dotenv.Get("APP_NAME"),
            version=dotenv.Get("APP_VERSION")
        };
    }
}