using TheJituBlog.Controller;
using TheJituBlog.Models;

class Program 
{
    public async static Task Main(string[] args)
    {
        await UserController.Init();
    }
}