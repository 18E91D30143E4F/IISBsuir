using BsuirHelper;
using System.Net;
using System.Threading.Tasks;

namespace IISBsuir.Services
{
    internal class DataService
    {
        public BsuirClient BsuirClient { get; set; }

        private const string Login = "95100018";
        private const string Password = "Agireh30";

        public static async Task<DataService> BuildDataService()
        {
            var data = await BsuirClient.TryAuthAsync(Login, Password);
            return new DataService(data.Item2);
        }

        private DataService(Cookie cookie)
        {
            BsuirClient = new BsuirClient(cookie);
        }
    }
}