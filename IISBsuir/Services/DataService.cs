using IIsHelper;
using System.Net;
using System.Threading.Tasks;

namespace IISBsuir.Services
{
    internal class DataService
    {
        public IIsClient BsuirClient { get; set; }

        private const string Login = "95100018";
        private const string Password = "Agireh30";

        public static async Task<DataService> BuildDataService()
        {
            var data = await IIsClient.TryAuthAsync(Login, Password);
            return new DataService(data.Item2);
        }

        private DataService(Cookie cookie)
        {
            BsuirClient = new IIsClient(cookie);
        }
    }
}