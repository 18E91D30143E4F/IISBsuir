using System;
using System.Threading.Tasks;
using IIsHelper;

namespace IISBsuirConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var helper = new IIsClient() { Login = "95100018", Password = "Agireh30" };
            Console.WriteLine(await helper.AuthAsync());
            var data = await helper.GetUserInfoAsync();

            Console.ReadLine();
        }
    }
}
