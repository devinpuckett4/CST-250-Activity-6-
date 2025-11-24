

namespace FileIOAndLINQ.Models
{
    public class VerseDisplayModel
    {
        public string Reference { get; set; }
        public string Text { get; set; }
        public string Meaning { get; set; }
        public int Importance { get; set; }

        public VerseDisplayModel() { }

        public VerseDisplayModel(string reference, string text, string meaning, int importance)
        {
            Reference = reference;
            Text = text;
            Meaning = meaning;
            Importance = importance;
        }
    }
}
