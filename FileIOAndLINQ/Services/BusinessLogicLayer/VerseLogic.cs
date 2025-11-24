// Citation: Your Name - GCU CST-250 Activity 6 - November 16, 2025

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileIOAndLINQ.Models;
using FileIOAndLINQ.Services.DataAccessLayer;

namespace FileIOAndLINQ.Services.BusinessLogicLayer
{
    public class VerseLogic
    {
        private readonly VerseDAO _dao = new VerseDAO();

        // Add a verse to the in-memory list
        public string AddVerse(VerseRequestModel request)
        {
            if (request == null)
                return "Verse was not added.";

            var data = new VerseDataModel
            {
                Id = _dao.NextId(),
                Book = request.Book,
                Chapter = request.Chapter,
                Verse = request.Verse,
                Text = request.Text,
                Meaning = request.Meaning,
                Importance = request.Importance
            };

            _dao.AddVerse(data);
            return "Verse added.";
        }

        // Return all verses for the grid
        public List<VerseDisplayModel> GetAllVerses()
        {
            return _dao.GetAll()
                       .Select(ToDisplay)
                       .ToList();
        }

        // Return least important verses for the filter
        public List<VerseDisplayModel> GetLeastImportantVerses(int num)
        {
            return _dao.GetAll()
                       .OrderBy(v => v.Importance)
                       .ThenBy(v => v.Book)
                       .ThenBy(v => v.Chapter)
                       .ThenBy(v => v.Verse)
                       .Take(num)
                       .Select(ToDisplay)
                       .ToList();
        }

        // Return most important verses for the filter
        public List<VerseDisplayModel> GetMostImportantVerses(int num)
        {
            return _dao.GetAll()
                       .OrderByDescending(v => v.Importance)
                       .ThenBy(v => v.Book)
                       .ThenBy(v => v.Chapter)
                       .ThenBy(v => v.Verse)
                       .Take(num)
                       .Select(ToDisplay)
                       .ToList();
        }

        private static VerseDisplayModel ToDisplay(VerseDataModel v) =>
            new VerseDisplayModel(
                reference: $"{v.Book} {v.Chapter}:{v.Verse}",
                text: v.Text,
                meaning: v.Meaning,
                importance: v.Importance);

        // Save all verses to TXT / JSON / CSV
        public string WriteVersesToFile(string path)
        {
            try
            {
                _dao.SaveToFile(path);
                return $"Verses saved to {Path.GetFileName(path)}.";
            }
            catch (Exception ex)
            {
                return $"Error saving verses: {ex.Message}";
            }
        }

        // Load verses from TXT / JSON / CSV
        public string ReadVersesFromFile(string path)
        {
            try
            {
                _dao.LoadFromFile(path);
                return $"Verses loaded from {Path.GetFileName(path)}.";
            }
            catch (Exception ex)
            {
                return $"Error loading verses: {ex.Message}";
            }
        }
    }
}
