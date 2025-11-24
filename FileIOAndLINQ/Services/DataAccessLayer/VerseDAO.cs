// Citation: Your Name - GCU CST-250 Activity 6 - November 16, 2025

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using FileIOAndLINQ.Models;

namespace FileIOAndLINQ.Services.DataAccessLayer
{
    // Data access class that keeps verses in memory and handles saving and loading
    public class VerseDAO
    {
        // In memory list of all verses
        private readonly List<VerseDataModel> _verses = new List<VerseDataModel>();

        // Get the next id for a new verse
        public int NextId() => _verses.Count == 0 ? 1 : _verses.Max(v => v.Id) + 1;

        // Return a copy of all verses so callers cannot change the original list
        public IReadOnlyList<VerseDataModel> GetAll() => _verses.ToList();

        // Add a verse to the in memory list
        public void AddVerse(VerseDataModel verse)
        {
            if (verse == null) return;
            _verses.Add(verse);
        }

        // Save all verses to a file based on the file extension
        public void SaveToFile(string path)
        {
            string ext = Path.GetExtension(path).ToLowerInvariant();

            switch (ext)
            {
                case ".json":
                    SaveJson(path);
                    break;
                case ".csv":
                    SaveCsv(path);
                    break;
                default:
                    SaveText(path);
                    break;
            }
        }

        // Load verses from a file based on the file extension
        public void LoadFromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found.", path);

            string ext = Path.GetExtension(path).ToLowerInvariant();
            List<VerseDataModel> loaded;

            switch (ext)
            {
                case ".json":
                    loaded = LoadJson(path);
                    break;
                case ".csv":
                    loaded = LoadCsv(path);
                    break;
                default:
                    loaded = LoadText(path);
                    break;
            }

            // Replace the in memory list with the loaded verses
            _verses.Clear();
            _verses.AddRange(loaded);
        }

        // ----- JSON -----

        // Save verses as json text
        private void SaveJson(string path)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(_verses, options);
            File.WriteAllText(path, json);
        }

        // Load verses from json text
        private List<VerseDataModel> LoadJson(string path)
        {
            string json = File.ReadAllText(path);
            var list = JsonSerializer.Deserialize<List<VerseDataModel>>(json);
            return list ?? new List<VerseDataModel>();
        }

        // ----- CSV -----

        // Save verses as a csv file
        private void SaveCsv(string path)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Id,Book,Chapter,Verse,Text,Meaning,Importance");

            foreach (var v in _verses)
            {
                sb.AppendLine(string.Join(",",
                    v.Id,
                    EscapeCsv(v.Book),
                    v.Chapter,
                    EscapeCsv(v.Verse),
                    EscapeCsv(v.Text),
                    EscapeCsv(v.Meaning),
                    v.Importance));
            }

            File.WriteAllText(path, sb.ToString());
        }

        // Load verses from a csv file
        private List<VerseDataModel> LoadCsv(string path)
        {
            var lines = File.ReadAllLines(path).Skip(1); // skip header line
            var list = new List<VerseDataModel>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = SplitCsvLine(line);
                if (parts.Length < 7) continue;

                list.Add(new VerseDataModel(
                    id: int.Parse(parts[0]),
                    book: parts[1],
                    chapter: int.Parse(parts[2]),
                    verse: parts[3],
                    text: parts[4],
                    meaning: parts[5],
                    importance: int.Parse(parts[6])));
            }

            return list;
        }

        // ----- Plain text pipe separated -----

        // Save verses as a simple text file with values separated by pipes
        private void SaveText(string path)
        {
            using var writer = new StreamWriter(path, false, Encoding.UTF8);
            foreach (var v in _verses)
            {
                writer.WriteLine(string.Join("|",
                    v.Id,
                    v.Book,
                    v.Chapter,
                    v.Verse,
                    v.Text.Replace("\r", " ").Replace("\n", " "),
                    v.Meaning.Replace("\r", " ").Replace("\n", " "),
                    v.Importance));
            }
        }

        // Load verses from a pipe separated text file
        private List<VerseDataModel> LoadText(string path)
        {
            var list = new List<VerseDataModel>();

            foreach (var line in File.ReadLines(path))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split('|');
                if (parts.Length < 7) continue;

                list.Add(new VerseDataModel(
                    id: int.Parse(parts[0]),
                    book: parts[1],
                    chapter: int.Parse(parts[2]),
                    verse: parts[3],
                    text: parts[4],
                    meaning: parts[5],
                    importance: int.Parse(parts[6])));
            }

            return list;
        }

        // Helpers for CSV

        // Make sure text is safe to write into a csv line
        private static string EscapeCsv(string input)
        {
            if (input == null) return "";
            if (input.Contains("\"") || input.Contains(",") || input.Contains("\n"))
            {
                return "\"" + input.Replace("\"", "\"\"") + "\"";
            }
            return input;
        }

        // Split a csv line into parts and respect quoted values
        private static string[] SplitCsvLine(string line)
        {
            var result = new List<string>();
            var current = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char ch = line[i];

                if (inQuotes)
                {
                    if (ch == '"' && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        // Handle double quote inside quoted text
                        current.Append('"');
                        i++;
                    }
                    else if (ch == '"')
                    {
                        // End of quoted section
                        inQuotes = false;
                    }
                    else
                    {
                        current.Append(ch);
                    }
                }
                else
                {
                    if (ch == ',')
                    {
                        // End of one value
                        result.Add(current.ToString());
                        current.Clear();
                    }
                    else if (ch == '"')
                    {
                        // Start of quoted section
                        inQuotes = true;
                    }
                    else
                    {
                        current.Append(ch);
                    }
                }
            }

            // Add the last value
            result.Add(current.ToString());
            return result.ToArray();
        }
    }
}
