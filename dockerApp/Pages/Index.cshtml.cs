using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace dockerApp.Pages.Index
{
    public class IndexModel : PageModel
    {
        public List<KeyValuePair<string,string>>  pageconfig;
        public IndexModel(IConfiguration configuration)
        {
        pageconfig = ConfigurationExtensions.AsEnumerable(configuration).ToList();
        }


    }
}
