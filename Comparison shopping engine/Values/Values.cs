using System.Collections.Generic;

namespace Comparison_shopping_engine
{
    public class Values
    {
        public static List<string> Urls = new List<string>{
            /*rde,          */ "none",
            /*bigbox,       */ "none",
            /*pigu,         */ "https://pigu.lt/lt/search?q=",
            /*novastar,     */ "https://novastar.lt/search/?q=",
            /*topocentras,  */ "https://topocentras.lt/catalogsearch/result/?q=",
            /*skytech,      */ "http://skytech.lt/search.php?x=0&y=0&search_in_description=0&pagesize=500&keywords=",
            /*senukai       */ "https://senukai.lt/paieska/?q="
        };

        public static int scraperAmount = 3;
        public static int scraperTimeout = 60;
    }
}