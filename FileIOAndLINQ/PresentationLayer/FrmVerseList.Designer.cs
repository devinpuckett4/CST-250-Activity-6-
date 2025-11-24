using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace FileIOAndLINQ.PresentationLayer
{
    partial class FrmVerseList
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mnsFileActions = new MenuStrip();
            this.tsmFile = new ToolStripMenuItem();
            this.tsmSave = new ToolStripMenuItem();
            this.tsmLoad = new ToolStripMenuItem();
            this.tsmExit = new ToolStripMenuItem();
            this.grpAddVerse = new GroupBox();
            this.lblBook = new Label();
            this.cmbVerseBook = new ComboBox();
            this.lblBookError = new Label();
            this.lblChapter = new Label();
            this.txtVerseChapter = new TextBox();
            this.lblChapterError = new Label();
            this.lblVerse = new Label();
            this.txtVerseVerse = new TextBox();
            this.lblVerseError = new Label();
            this.lblText = new Label();
            this.txtVerseText = new TextBox();
            this.lblTextError = new Label();
            this.lblMeaning = new Label();
            this.txtVerseMeaning = new TextBox();
            this.lblMeaningError = new Label();
            this.lblImportance = new Label();
            this.nudVerseImportance = new NumericUpDown();
            this.lblImportanceError = new Label();
            this.btnAddVerse = new Button();
            this.grpFilterAndSort = new GroupBox();
            this.rdoShowAll = new RadioButton();
            this.rdoShowLeastValuable = new RadioButton();
            this.rdoShowMostValuable = new RadioButton();
            this.trbNumberToShow = new TrackBar();
            this.dgvVerseDisplay = new DataGridView();

            this.mnsFileActions.SuspendLayout();
            this.grpAddVerse.SuspendLayout();
            ((ISupportInitialize)(this.nudVerseImportance)).BeginInit();
            this.grpFilterAndSort.SuspendLayout();
            ((ISupportInitialize)(this.trbNumberToShow)).BeginInit();
            ((ISupportInitialize)(this.dgvVerseDisplay)).BeginInit();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.ClientSize = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Bible Verses";

            // MenuStrip
            this.mnsFileActions.Dock = DockStyle.Top;
            this.tsmFile.Text = "&File";
            this.tsmSave.Text = "&Save";
            this.tsmLoad.Text = "&Load";
            this.tsmExit.Text = "E&xit";
            this.tsmSave.Click += TsmSaveClickEH;
            this.tsmLoad.Click += TsmLoadClickEH;
            this.tsmExit.Click += TsmExitClickEH;
            this.tsmFile.DropDownItems.AddRange(new ToolStripItem[] { this.tsmSave, this.tsmLoad, this.tsmExit });
            this.mnsFileActions.Items.Add(this.tsmFile);

            // grpAddVerse
            this.grpAddVerse.Text = "Add A Bible Verse";
            this.grpAddVerse.Location = new Point(12, 36);
            this.grpAddVerse.Size = new Size(430, 380);

            this.lblBook.AutoSize = true;
            this.lblBook.Location = new Point(20, 35);
            this.lblBook.Text = "Book:";

            this.cmbVerseBook.Location = new Point(120, 30);
            this.cmbVerseBook.Size = new Size(220, 25);

            this.lblBookError.AutoSize = true;
            this.lblBookError.ForeColor = Color.Red;
            this.lblBookError.Location = new Point(350, 35);
            this.lblBookError.Visible = false;

            this.lblChapter.AutoSize = true;
            this.lblChapter.Location = new Point(20, 70);
            this.lblChapter.Text = "Chapter:";

            this.txtVerseChapter.Location = new Point(120, 65);
            this.txtVerseChapter.Size = new Size(80, 25);

            this.lblChapterError.AutoSize = true;
            this.lblChapterError.ForeColor = Color.Red;
            this.lblChapterError.Location = new Point(210, 70);
            this.lblChapterError.Visible = false;

            this.lblVerse.AutoSize = true;
            this.lblVerse.Location = new Point(20, 105);
            this.lblVerse.Text = "Verse:";

            this.txtVerseVerse.Location = new Point(120, 100);
            this.txtVerseVerse.Size = new Size(80, 25);

            this.lblVerseError.AutoSize = true;
            this.lblVerseError.ForeColor = Color.Red;
            this.lblVerseError.Location = new Point(210, 105);
            this.lblVerseError.Visible = false;

            this.lblText.AutoSize = true;
            this.lblText.Location = new Point(20, 140);
            this.lblText.Text = "Text:";

            this.txtVerseText.Location = new Point(120, 135);
            this.txtVerseText.Size = new Size(280, 70);
            this.txtVerseText.Multiline = true;
            this.txtVerseText.ScrollBars = ScrollBars.Vertical;

            this.lblTextError.AutoSize = true;
            this.lblTextError.ForeColor = Color.Red;
            this.lblTextError.Location = new Point(20, 210);
            this.lblTextError.Visible = false;

            this.lblMeaning.AutoSize = true;
            this.lblMeaning.Location = new Point(20, 225);
            this.lblMeaning.Text = "Meaning:";

            this.txtVerseMeaning.Location = new Point(120, 220);
            this.txtVerseMeaning.Size = new Size(280, 70);
            this.txtVerseMeaning.Multiline = true;
            this.txtVerseMeaning.ScrollBars = ScrollBars.Vertical;

            this.lblMeaningError.AutoSize = true;
            this.lblMeaningError.ForeColor = Color.Red;
            this.lblMeaningError.Location = new Point(20, 295);
            this.lblMeaningError.Visible = false;

            this.lblImportance.AutoSize = true;
            this.lblImportance.Location = new Point(20, 320);
            this.lblImportance.Text = "Importance (1–10):";

            this.nudVerseImportance.Location = new Point(160, 315);
            this.nudVerseImportance.Size = new Size(60, 25);
            this.nudVerseImportance.Minimum = 1;
            this.nudVerseImportance.Maximum = 10;

            this.lblImportanceError.AutoSize = true;
            this.lblImportanceError.ForeColor = Color.Red;
            this.lblImportanceError.Location = new Point(230, 320);
            this.lblImportanceError.Visible = false;

            this.btnAddVerse.Location = new Point(300, 310);
            this.btnAddVerse.Size = new Size(100, 30);
            this.btnAddVerse.Text = "Add Verse";
            this.btnAddVerse.Click += BtnAddVerseClickEH;

            this.grpAddVerse.Controls.Add(this.lblBook);
            this.grpAddVerse.Controls.Add(this.cmbVerseBook);
            this.grpAddVerse.Controls.Add(this.lblBookError);
            this.grpAddVerse.Controls.Add(this.lblChapter);
            this.grpAddVerse.Controls.Add(this.txtVerseChapter);
            this.grpAddVerse.Controls.Add(this.lblChapterError);
            this.grpAddVerse.Controls.Add(this.lblVerse);
            this.grpAddVerse.Controls.Add(this.txtVerseVerse);
            this.grpAddVerse.Controls.Add(this.lblVerseError);
            this.grpAddVerse.Controls.Add(this.lblText);
            this.grpAddVerse.Controls.Add(this.txtVerseText);
            this.grpAddVerse.Controls.Add(this.lblTextError);
            this.grpAddVerse.Controls.Add(this.lblMeaning);
            this.grpAddVerse.Controls.Add(this.txtVerseMeaning);
            this.grpAddVerse.Controls.Add(this.lblMeaningError);
            this.grpAddVerse.Controls.Add(this.lblImportance);
            this.grpAddVerse.Controls.Add(this.nudVerseImportance);
            this.grpAddVerse.Controls.Add(this.lblImportanceError);
            this.grpAddVerse.Controls.Add(this.btnAddVerse);

            // grpFilterAndSort
            this.grpFilterAndSort.Text = "Filter And Sort";
            this.grpFilterAndSort.Location = new Point(460, 36);
            this.grpFilterAndSort.Size = new Size(300, 200);

            this.rdoShowAll.AutoSize = true;
            this.rdoShowAll.Location = new Point(20, 35);
            this.rdoShowAll.Text = "Show All";
            this.rdoShowAll.Checked = true;
            this.rdoShowAll.CheckedChanged += RdoShowAllCheckedChangedEH;

            this.rdoShowLeastValuable.AutoSize = true;
            this.rdoShowLeastValuable.Location = new Point(20, 70);
            this.rdoShowLeastValuable.Text = "Show Least Important";
            this.rdoShowLeastValuable.CheckedChanged += RdoShowLeastImportantCheckChangedEH;

            this.rdoShowMostValuable.AutoSize = true;
            this.rdoShowMostValuable.Location = new Point(20, 105);
            this.rdoShowMostValuable.Text = "Show Most Important";
            this.rdoShowMostValuable.CheckedChanged += RdoShowMostImportantCheckedChangedEH;

            this.trbNumberToShow.Location = new Point(20, 140);
            this.trbNumberToShow.Size = new Size(250, 45);
            this.trbNumberToShow.Minimum = 1;
            this.trbNumberToShow.Maximum = 50;
            this.trbNumberToShow.Value = 10;
            this.trbNumberToShow.Scroll += TrbNumberToShowScrollEH;

            this.grpFilterAndSort.Controls.Add(this.rdoShowAll);
            this.grpFilterAndSort.Controls.Add(this.rdoShowLeastValuable);
            this.grpFilterAndSort.Controls.Add(this.rdoShowMostValuable);
            this.grpFilterAndSort.Controls.Add(this.trbNumberToShow);

            // DataGridView
            this.dgvVerseDisplay.Location = new Point(12, 430);
            this.dgvVerseDisplay.Size = new Size(1170, 250);
            this.dgvVerseDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvVerseDisplay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVerseDisplay.AllowUserToAddRows = false;
            this.dgvVerseDisplay.ReadOnly = true;

            // Add to form
            this.Controls.Add(this.dgvVerseDisplay);
            this.Controls.Add(this.grpFilterAndSort);
            this.Controls.Add(this.grpAddVerse);
            this.Controls.Add(this.mnsFileActions);
            this.MainMenuStrip = this.mnsFileActions;

            this.mnsFileActions.ResumeLayout(false);
            this.mnsFileActions.PerformLayout();
            this.grpAddVerse.ResumeLayout(false);
            this.grpAddVerse.PerformLayout();
            this.grpFilterAndSort.ResumeLayout(false);
            this.grpFilterAndSort.PerformLayout();
            ((ISupportInitialize)(this.nudVerseImportance)).EndInit();
            ((ISupportInitialize)(this.trbNumberToShow)).EndInit();
            ((ISupportInitialize)(this.dgvVerseDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MenuStrip mnsFileActions;
        private ToolStripMenuItem tsmFile;
        private ToolStripMenuItem tsmSave;
        private ToolStripMenuItem tsmLoad;
        private ToolStripMenuItem tsmExit;
        private GroupBox grpAddVerse;
        private GroupBox grpFilterAndSort;
        private Label lblBook;
        private ComboBox cmbVerseBook;
        private Label lblBookError;
        private Label lblChapter;
        private TextBox txtVerseChapter;
        private Label lblChapterError;
        private Label lblVerse;
        private TextBox txtVerseVerse;
        private Label lblVerseError;
        private Label lblText;
        private TextBox txtVerseText;
        private Label lblTextError;
        private Label lblMeaning;
        private TextBox txtVerseMeaning;
        private Label lblMeaningError;
        private Label lblImportance;
        private NumericUpDown nudVerseImportance;
        private Label lblImportanceError;
        private Button btnAddVerse;
        private RadioButton rdoShowAll;
        private RadioButton rdoShowLeastValuable;
        private RadioButton rdoShowMostValuable;
        private TrackBar trbNumberToShow;
        private DataGridView dgvVerseDisplay;
    }
}