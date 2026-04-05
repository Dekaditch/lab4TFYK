using lab1.Forms;
using lab1.Managers;
using System;
using System.Windows.Forms;
using TextEditor.Managers;

namespace lab1
{
    public partial class MainForm : Form
    {
        private DocumentManager documentManager;
        private EditManager editManager;
        private ClipboardManager clipboardManager;
        private FileService fileService;
        private HelpManager helpManager;
        private TextInfoManager textInfoManager;

        public MainForm()
        {
            InitializeComponent();
            InitializeManagers();
            SubscribeToEvents();
            UpdateUIState();
            SetupShortcutKeys();
        }

        private void InitializeManagers()
        {
            fileService = new FileService();
            documentManager = new DocumentManager(richTextBox1, fileService, this);
            editManager = new EditManager(richTextBox1);
            clipboardManager = new ClipboardManager();
            helpManager = new HelpManager();
            textInfoManager = new TextInfoManager();
        }

        private void SubscribeToEvents()
        {
            richTextBox1.TextChanged += RichTextBox_TextChanged;
        }

        private void SetupShortcutKeys()
        {
            this.KeyPreview = true;

            createFileStrip.ShortcutKeys = Keys.Control | Keys.N;
            openFileStrip.ShortcutKeys = Keys.Control | Keys.O;
            saveFileStrip.ShortcutKeys = Keys.Control | Keys.S;
            undoStrip.ShortcutKeys = Keys.Control | Keys.Z;
            redoStrip.ShortcutKeys = Keys.Control | Keys.Y;
            cutStrip.ShortcutKeys = Keys.Control | Keys.X;
            copyStrip.ShortcutKeys = Keys.Control | Keys.C;
            pasteStrip.ShortcutKeys = Keys.Control | Keys.V;
            selectAllStrip.ShortcutKeys = Keys.Control | Keys.A;
            infoShowStrip.ShortcutKeys = Keys.F1;
        }

        private void createFileStrip_Click(object sender, EventArgs e)
        {
            documentManager.NewDocument();
        }

        private void openFileStrip_Click(object sender, EventArgs e)
        {
            documentManager.OpenDocument();
        }

        private void saveFileStrip_Click(object sender, EventArgs e)
        {
            documentManager.SaveDocument();
        }

        private void saveHowStrip_Click(object sender, EventArgs e)
        {
            documentManager.SaveDocumentAs();
        }

        private void exitStrip_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void undoStrip_Click(object sender, EventArgs e)
        {
            editManager.Undo();
            UpdateUIState();
        }

        private void redoStrip_Click(object sender, EventArgs e)
        {
            editManager.Redo();
            UpdateUIState();
        }

        private void cutStrip_Click(object sender, EventArgs e)
        {
            editManager.Cut();
            UpdateUIState();
        }

        private void copyStrip_Click(object sender, EventArgs e)
        {
            editManager.Copy();
        }

        private void pasteStrip_Click(object sender, EventArgs e)
        {
            editManager.Paste();
            UpdateUIState();
        }

        private void deleteStrip_Click(object sender, EventArgs e)
        {
            editManager.Delete();
            UpdateUIState();
        }

        private void selectAllStrip_Click(object sender, EventArgs e)
        {
            editManager.SelectAll();
        }

        private void taskDescStrip_Click(object sender, EventArgs e)
        {
            textInfoManager.ShowTaskStatement();
        }

        private void grammarStrip_Click(object sender, EventArgs e)
        {
            textInfoManager.ShowGrammar();
        }

        private void gramClassStrip_Click(object sender, EventArgs e)
        {
            textInfoManager.ShowGrammarClassification();
        }

        private void parsingMethod_Click(object sender, EventArgs e)
        {
            textInfoManager.ShowAnalysisMethod();
        }

        private void testStrip_Click(object sender, EventArgs e)
        {
            textInfoManager.ShowTestExample();
        }

        private void literatStrip_Click(object sender, EventArgs e)
        {
            textInfoManager.ShowReferences();
        }

        private void codeStrip_Click(object sender, EventArgs e)
        {
            textInfoManager.ShowSourceCode();
        }

        private void startStrip_Click(object sender, EventArgs e)
        {
           
        }

        private void infoShowStrip_Click(object sender, EventArgs e)
        {
            helpManager.ShowHelp();
        }

        private void aboutStrip_Click(object sender, EventArgs e)
        {
            helpManager.ShowAbout();
        }

        private void createToolStrip_Click(object sender, EventArgs e)
        {
            documentManager.NewDocument();
        }

        private void browseToolStrip_Click(object sender, EventArgs e)
        {
            documentManager.OpenDocument();
        }

        private void saveToolStrip_Click(object sender, EventArgs e)
        {
            documentManager.SaveDocument();
        }

        private void undoToolStrip_Click(object sender, EventArgs e)
        {
            editManager.Undo();
            UpdateUIState();
        }

        private void redoToolStrip_Click(object sender, EventArgs e)
        {
            editManager.Redo();
            UpdateUIState();
        }

        private void copyToolStrip_Click(object sender, EventArgs e)
        {
            editManager.Copy();
        }

        private void cutToolStrip_Click(object sender, EventArgs e)
        {
            editManager.Cut();
            UpdateUIState();
        }

        private void pasteToolStrip_Click(object sender, EventArgs e)
        {
            editManager.Paste();
            UpdateUIState();
        }

        private void runToolStrip_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функция запуска анализатора будет реализована позже.",
                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aboutToolStrip_Click(object sender, EventArgs e)
        {
            helpManager.ShowAbout();
        }

        private void infoToolStrip_Click(object sender, EventArgs e)
        {
            helpManager.ShowHelp();
        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            documentManager.SetHasChanges(true);
            UpdateUIState();
        }

        private void UpdateUIState()
        {
            undoStrip.Enabled = editManager.CanUndo;
            redoStrip.Enabled = editManager.CanRedo;
            cutStrip.Enabled = editManager.CanCut;
            copyStrip.Enabled = editManager.CanCopy;
            pasteStrip.Enabled = editManager.CanPaste;
            deleteStrip.Enabled = editManager.CanDelete;

            undoToolStrip.Enabled = editManager.CanUndo;
            redoToolStrip.Enabled = editManager.CanRedo;
            cutToolStrip.Enabled = editManager.CanCut;
            copyToolStrip.Enabled = editManager.CanCopy;
            pasteToolStrip.Enabled = editManager.CanPaste;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!documentManager.PromptSaveChanges())
            {
                e.Cancel = true;
            }
        }

        public void UpdateFormTitle(string title)
        {
            this.Text = title;
        }

        private void searchStrip_Click(object sender, EventArgs e)
        {
            var searchForm = new lab1.Forms.SearchForm(richTextBox1);
            searchForm.Show();
        }
    }
}