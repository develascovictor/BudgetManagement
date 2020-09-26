using System.Runtime.CompilerServices;

namespace BudgetManagement.Shared.Extensions
{
    public class CallerExtensions
    {
        public class Caller
        {
            public string Method { get; set; }
            public string Location { get; set; }
        }

        public static Caller LogCaller([CallerMemberName] string method = "", [CallerFilePath] string path = "")
        {
            var location = path;

            if (!(location ?? string.Empty).Contains("\\"))
            {
                return new Caller
                {
                    Method = method,
                    Location = location
                };
            }

            var temp = location.Split('\\');
            location = temp[temp.Length - 1].Replace(".cs", "");

            return new Caller
            {
                Method = method,
                Location = location
            };
        }
    }
}