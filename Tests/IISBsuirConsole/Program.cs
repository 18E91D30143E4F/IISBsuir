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

            var info = await helper.GetUserInfoAsync();
            info.PhotoUrl = "https://motor.ru/imgs/2017/06/21/12/1303239/cb589e6d68a72e8476054cb90319d287b7a5dd7d.jpg";
            info.References = null;
            var data = await helper.PutStudentInfoAsync(info);

            Console.ReadLine();
        }
    }
}
