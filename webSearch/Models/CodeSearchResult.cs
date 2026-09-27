using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webSearch.Models
{
    public class CodeSearchResult
    {
        public string FileName { get; set; }

        public string FilePath { get; set; }

        public int LineNumber { get; set; }

        public string Line { get; set; }
    }
}