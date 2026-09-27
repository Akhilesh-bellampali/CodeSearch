using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webSearch.Models
{
    public class CodeSearchViewModel
    {
        public string FolderPath { get; set; }

        public string SearchPattern { get; set; }

        public List<CodeSearchResult> Results { get; set; }

        public CodeSearchViewModel()
        {
            Results = new List<CodeSearchResult>();
        }
    }
}