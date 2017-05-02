using Whois.NET;

namespace LogParser.WebSiteRequest
{
    public class WhoIsSite
    {
        public static string GetCompanyName(string ip)
        {
            var result = WhoisClient.Query(ip);
            return result.OrganizationName;
        }
    }
}
