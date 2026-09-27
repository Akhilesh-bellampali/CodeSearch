using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using webSearch.Models;

namespace webSearch.Services
{
    public class CodeSearchService
    {
        public List<CodeSearchResult> Search(
            string folderPath,
            string searchPattern)
        {
            List<CodeSearchResult> results =
                new List<CodeSearchResult>();

            if (string.IsNullOrWhiteSpace(folderPath))
            {
                return results;
            }

            if (string.IsNullOrWhiteSpace(searchPattern))
            {
                return results;
            }

            if (!Directory.Exists(folderPath))
            {
                return results;
            }

            string[] files = Directory.GetFiles(
                folderPath,
                "*.*",
                SearchOption.AllDirectories);

            foreach (string filePath in files)
            {
                try
                {
                    int lineNumber = 0;

                    foreach (string line in File.ReadLines(filePath))
                    {
                        lineNumber++;

                        if (line.IndexOf(
                            searchPattern,
                            StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            results.Add(new CodeSearchResult
                            {
                                FileName = Path.GetFileName(filePath),
                                FilePath = filePath,
                                LineNumber = lineNumber,
                                Line = line.Trim()
                            });
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    // Ignore files that cannot be accessed.
                }
                catch (IOException)
                {
                    // Ignore files that cannot be read.
                }
            }

            return results
                .OrderByDescending(x => x.FileName)
                .ThenBy(x => x.LineNumber)
                .ToList();
        }
    }
}