// Citation: Devin Puckett - GCU CST-250 Activity 6 - November 20, 2025

#nullable disable

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FileIOAndLINQ.Models;
using FileIOAndLINQ.Services.BusinessLogicLayer;

namespace FileIOAndLINQ.PresentationLayer
{
    // Form that lets the user add Bible verses, save them, load them, and filter them
    public partial class FrmVerseList : Form
    {
        // List of Bible book names used to fill the combo box
        private readonly List<string> _bibleBooks = new List<string>
{
"Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy", "Joshua", "Judges", "Ruth",
"1 Samuel", "2 Samuel", "1 Kings", "2 Kings", "1 Chronicles", "2 Chronicles", "Ezra", "Nehemiah", "Esther",
"Job", "Psalms", "Proverbs", "Ecclesiastes", "Song of Solomon", "Isaiah", "Jeremiah", "Lamentations",
"Ezekiel", "Daniel", "Hosea", "Joel", "Amos", "Obadiah", "Jonah", "Micah", "Nahum", "Habakkuk",
"Zephaniah", "Haggai", "Zechariah", "Malachi", "Matthew", "Mark", "Luke", "John", "Acts", "Romans",
"1 Corinthians", "2 Corinthians", "Galatians", "Ephesians", "Philippians", "Colossians",
"1 Thessalonians", "2 Thessalonians", "1 Timothy", "2 Timothy", "Titus", "Philemon", "Hebrews",
"James", "1 Peter", "2 Peter", "1 John", "2 John", "3 John", "Jude", "Revelation"
};

        // Holds all error labels so they can be shown or hidden together
        private List<Label> _errorLabels;

        // Flags that track if each input is valid
        private bool isValidBook = false;
        private bool isValidChapter = false;
        private bool isValidVerse = false;
        private bool isValidText = false;
        private bool isValidMeaning = false;
        private bool isValidImportance = true;

        // Number of verses to show when filtering most or least important
        private int _numToShow = 10;

        // Binding source for the DataGridView
        private readonly BindingSource _verseBindingSource = new BindingSource();

        // Business logic class that handles verse operations
        private readonly VerseLogic _verseLogic = new VerseLogic();

        // Default file path for saving and loading verses as json
        private readonly string _defaultFilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "verses.json");

        // Form constructor
        public FrmVerseList()
        {
            InitializeComponent();

            // Set up lists and input validation
            SetupErrorLabels();
            HideAllErrors();
            InitializeBooks();
            HookValidationEvents();

            // Connect the grid to the binding source
            dgvVerseDisplay.DataSource = _verseBindingSource;
            rdoShowAll.Checked = true;

            // Set up the track bar defaults
            trbNumberToShow.Minimum = 1;
            trbNumberToShow.Maximum = 50;
            trbNumberToShow.Value = 10;

            // When the form loads try to read any saved verses and then refresh the grid
            this.Load += (s, e) =>
            {
                if (File.Exists(_defaultFilePath))
                {
                    _verseLogic.ReadVersesFromFile(_defaultFilePath);
                }
                RefreshVersesDgv();
            };
        }

        // Store all error labels in a list so they are easy to manage
        private void SetupErrorLabels()
        {
            _errorLabels = new List<Label>
        {
            lblBookError, lblChapterError, lblVerseError,
            lblTextError, lblMeaningError, lblImportanceError
        };
        }

        // Hide all error labels
        private void HideAllErrors()
        {
            foreach (var label in _errorLabels)
                label.Visible = false;
        }

        // Fill the book combo box with the list of Bible books
        private void InitializeBooks()
        {
            cmbVerseBook.DataSource = _bibleBooks;
            cmbVerseBook.SelectedIndex = -1;
        }

        // Hook up leave events for validation on each input control
        private void HookValidationEvents()
        {
            cmbVerseBook.Leave += CmbVerseBookLeaveEH;
            txtVerseChapter.Leave += TxtVerseChapterLeaveEH;
            txtVerseVerse.Leave += TxtVerseVerseLeaveEH;
            txtVerseText.Leave += TxtVerseTextLeaveEH;
            txtVerseMeaning.Leave += TxtVerseMeaningLeaveEH;
            nudVerseImportance.Leave += NudVerseImportanceLeaveEH;
        }

        // Validate that a book was selected
        private void CmbVerseBookLeaveEH(object sender, EventArgs e)
        {
            isValidBook = cmbVerseBook.SelectedIndex >= 0;
            lblBookError.Text = isValidBook ? "" : "*";
            lblBookError.Visible = !isValidBook;
        }

        // Validate that chapter is made of digits only
        private void TxtVerseChapterLeaveEH(object sender, EventArgs e)
        {
            isValidChapter = Regex.IsMatch(txtVerseChapter.Text, @"^\d+$");
            lblChapterError.Text = isValidChapter ? "" : "*";
            lblChapterError.Visible = !isValidChapter;
        }

        // Validate that verse is a number or a range like 1-3
        private void TxtVerseVerseLeaveEH(object sender, EventArgs e)
        {
            isValidVerse = Regex.IsMatch(txtVerseVerse.Text, @"^(\d+)(-\d+)?$");
            lblVerseError.Text = isValidVerse ? "" : "*";
            lblVerseError.Visible = !isValidVerse;
        }

        // Validate that verse text is not empty
        private void TxtVerseTextLeaveEH(object sender, EventArgs e)
        {
            isValidText = !string.IsNullOrWhiteSpace(txtVerseText.Text);
            lblTextError.Text = isValidText ? "" : "*";
            lblTextError.Visible = !isValidText;
        }

        // Validate that meaning text is not empty
        private void TxtVerseMeaningLeaveEH(object sender, EventArgs e)
        {
            isValidMeaning = !string.IsNullOrWhiteSpace(txtVerseMeaning.Text);
            lblMeaningError.Text = isValidMeaning ? "" : "*";
            lblMeaningError.Visible = !isValidMeaning;
        }

        // Importance is always valid here so just hide the error
        private void NudVerseImportanceLeaveEH(object sender, EventArgs e)
        {
            isValidImportance = true;
            lblImportanceError.Visible = false;
        }

        // Add verse button click event handler
        private void BtnAddVerseClickEH(object sender, EventArgs e)
        {
            // Recheck all validation when the user clicks add
            isValidBook = cmbVerseBook.SelectedIndex >= 0;
            isValidChapter = Regex.IsMatch(txtVerseChapter.Text, @"^\d+$");
            isValidVerse = Regex.IsMatch(txtVerseVerse.Text, @"^(\d+)(-\d+)?$");
            isValidText = !string.IsNullOrWhiteSpace(txtVerseText.Text);
            isValidMeaning = !string.IsNullOrWhiteSpace(txtVerseMeaning.Text);
            isValidImportance = true;

            HideAllErrors();

            // Show error stars next to any bad inputs
            if (!isValidBook) { lblBookError.Text = "*"; lblBookError.Visible = true; }
            if (!isValidChapter) { lblChapterError.Text = "*"; lblChapterError.Visible = true; }
            if (!isValidVerse) { lblVerseError.Text = "*"; lblVerseError.Visible = true; }
            if (!isValidText) { lblTextError.Text = "*"; lblTextError.Visible = true; }
            if (!isValidMeaning) { lblMeaningError.Text = "*"; lblMeaningError.Visible = true; }

            // If any field is still invalid stop here
            if (!isValidBook || !isValidChapter || !isValidVerse || !isValidText || !isValidMeaning)
                return;

            // Build a request model from the form values
            var request = new VerseRequestModel(
                cmbVerseBook.Text,
                int.Parse(txtVerseChapter.Text),
                txtVerseVerse.Text,
                txtVerseText.Text,
                txtVerseMeaning.Text,
                (int)nudVerseImportance.Value);

            // Let the logic layer add the verse
            var msg = _verseLogic.AddVerse(request);

            // Also write the current list to the default file
            msg += Environment.NewLine + _verseLogic.WriteVersesToFile(_defaultFilePath);

            // Show the result of adding and saving
            MessageBox.Show(msg, "Add Verse");

            // Clear the form so the user can add another verse
            cmbVerseBook.SelectedIndex = -1;
            txtVerseChapter.Clear();
            txtVerseVerse.Clear();
            txtVerseText.Clear();
            txtVerseMeaning.Clear();
            nudVerseImportance.Value = 5;

            // Reset validation flags
            isValidBook = isValidChapter = isValidVerse = isValidText = isValidMeaning = false;

            // Refresh the grid so the new verse shows
            RefreshVersesDgv();
        }

        // Save menu item uses the default json file
        private void TsmSaveClickEH(object sender, EventArgs e)
        {
            var msg = _verseLogic.WriteVersesToFile(_defaultFilePath);
            MessageBox.Show($"{msg}\nSaved to: {_defaultFilePath}", "Save Verses");
        }

        // Load menu item reads from the default json file
        private void TsmLoadClickEH(object sender, EventArgs e)
        {
            var msg = _verseLogic.ReadVersesFromFile(_defaultFilePath);
            RefreshVersesDgv();
            MessageBox.Show($"{msg}\nLoaded from: {_defaultFilePath}", "Load Verses");
        }

        // Exit the form
        private void TsmExitClickEH(object sender, EventArgs e) => Close();

        // Track bar scroll event updates how many verses to show
        private void TrbNumberToShowScrollEH(object sender, EventArgs e)
        {
            _numToShow = trbNumberToShow.Value;

            // Update radio button text to show the number selected
            rdoShowLeastValuable.Text = $"Show Least Important ({_numToShow})";
            rdoShowMostValuable.Text = $"Show Most Important ({_numToShow})";

            // If a filter is active refresh that view
            if (rdoShowLeastValuable.Checked)
                RdoShowLeastImportantCheckChangedEH(sender, e);
            if (rdoShowMostValuable.Checked)
                RdoShowMostImportantCheckedChangedEH(sender, e);
        }

        // Radio button to show all verses
        private void RdoShowAllCheckedChangedEH(object sender, EventArgs e)
        {
            if (rdoShowAll.Checked)
                RefreshVersesDgv();
        }

        // Radio button to show the least important verses
        private void RdoShowLeastImportantCheckChangedEH(object sender, EventArgs e)
        {
            if (rdoShowLeastValuable.Checked)
            {
                _verseBindingSource.DataSource = _verseLogic.GetLeastImportantVerses(_numToShow);
                FormatVersesDgv();
            }
        }

        // Radio button to show the most important verses
        private void RdoShowMostImportantCheckedChangedEH(object sender, EventArgs e)
        {
            if (rdoShowMostValuable.Checked)
            {
                _verseBindingSource.DataSource = _verseLogic.GetMostImportantVerses(_numToShow);
                FormatVersesDgv();
            }
        }

        // Get all verses from the logic layer and show them in the grid
        private void RefreshVersesDgv()
        {
            var verses = _verseLogic.GetAllVerses();
            _verseBindingSource.DataSource = verses;
            FormatVersesDgv();

            // Adjust the track bar maximum based on how many verses exist
            int max = verses.Count == 0 ? 1 : verses.Count;
            trbNumberToShow.Maximum = max;
            _numToShow = Math.Min(_numToShow, max);
            if (_numToShow < 1) _numToShow = 1;
            trbNumberToShow.Value = _numToShow;

            // Make sure the labels for most and least important stay in sync
            TrbNumberToShowScrollEH(null, null);
        }

        // Set friendly headers on the DataGridView columns
        private void FormatVersesDgv()
        {
            if (dgvVerseDisplay.Columns.Count == 0) return;

            dgvVerseDisplay.Columns["Reference"].HeaderText = "Verse Reference";
            dgvVerseDisplay.Columns["Text"].HeaderText = "Verse Text";
            dgvVerseDisplay.Columns["Meaning"].HeaderText = "Meaning";
            dgvVerseDisplay.Columns["Importance"].HeaderText = "Importance (1-10)";
        }
    }
}

