using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using lab1.Managers;
using lab1.Models;

namespace lab1.Forms
{
    public partial class SearchForm : Form
    {
        private RichTextBox mainTextBox;
        private SearchManager searchManager;
        private PhoneNumberAutomaton phoneAutomaton;
        private List<SearchResult> currentResults;

        public SearchForm(RichTextBox textBox)
        {
            InitializeComponent();

            this.mainTextBox = textBox;
            this.searchManager = new SearchManager(mainTextBox);
            this.phoneAutomaton = new PhoneNumberAutomaton();
            this.currentResults = new List<SearchResult>();

            this.cmbSearchType.SelectedIndex = 0;
            this.chkIgnoreCase.Checked = false;
            this.chkMultiline.Checked = true;
            this.radRegex.Checked = true; 

            this.TopLevel = true;
            this.ShowInTaskbar = true;

            this.btnSearch.Click += BtnSearch_Click;
            this.btnClear.Click += BtnClear_Click;
            this.dgvResults.SelectionChanged += DgvResults_SelectionChanged;
            this.btnExport.Click += BtnExport_Click;
            this.btnSelectAll.Click += BtnSelectAll_Click;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (searchManager != null)
                    searchManager.ClearHighlights();

                dgvResults.Rows.Clear();

                currentResults = new List<SearchResult>();

                SearchManager.SearchType searchType = (SearchManager.SearchType)cmbSearchType.SelectedIndex;
                string text = mainTextBox.Text;

                if (string.IsNullOrWhiteSpace(text))
                {
                    MessageBox.Show("Нет данных для поиска. Пожалуйста, введите текст.",
                        "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (searchType == SearchManager.SearchType.PhoneNumber)
                {
                    if (radAutomaton.Checked)
                    {
                        var results = phoneAutomaton.FindPhoneNumbers(text);
                        currentResults = new List<SearchResult>(results);
                        lblStatus.Text = $"Поиск (конечный автомат) завершен. Найдено {currentResults.Count} совпадений.";
                    }
                    else
                    {
                        RegexOptions options = RegexOptions.Compiled;
                        if (chkIgnoreCase.Checked)
                            options |= RegexOptions.IgnoreCase;
                        if (chkMultiline.Checked)
                            options |= RegexOptions.Multiline;

                        currentResults = searchManager.PerformSearch(searchType, options);
                        lblStatus.Text = $"Поиск (регулярные выражения) завершен. Найдено {currentResults.Count} совпадений.";
                    }
                }
                else
                {
                    RegexOptions options = RegexOptions.Compiled;
                    if (chkIgnoreCase.Checked)
                        options |= RegexOptions.IgnoreCase;
                    if (chkMultiline.Checked)
                        options |= RegexOptions.Multiline;

                    currentResults = searchManager.PerformSearch(searchType, options);
                    lblStatus.Text = $"Поиск завершен. Найдено {currentResults.Count} совпадений. Тип: {searchManager.GetSearchTypeDescription(searchType)}";
                }

                foreach (var result in currentResults)
                {
                    dgvResults.Rows.Add(
                        result.MatchedText,
                        result.LineNumber,
                        result.CharPosition,
                        result.Length
                    );
                }

                lblCount.Text = $"Найдено: {currentResults.Count}";
                lblStatus.ForeColor = currentResults.Count > 0 ? Color.Green : Color.Orange;

                if (currentResults.Count == 0)
                {
                    MessageBox.Show("Совпадений не найдено.", "Результаты поиска",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выполнении поиска: {ex.Message}\n{ex.StackTrace}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                dgvResults.Rows.Clear();
                currentResults = new List<SearchResult>();
                lblCount.Text = "Найдено: 0";
                lblStatus.Text = "Результаты очищены";
                lblStatus.ForeColor = Color.Gray;

                if (searchManager != null)
                    searchManager.ClearHighlights();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvResults_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvResults.SelectedRows.Count > 0 && currentResults != null && currentResults.Count > 0)
                {
                    int selectedIndex = dgvResults.SelectedRows[0].Index;
                    if (selectedIndex < currentResults.Count)
                    {
                        var result = currentResults[selectedIndex];
                        if (searchManager != null)
                        {
                            searchManager.ClearHighlights();
                            searchManager.HighlightText(result.AbsoluteIndex, result.Length);
                            mainTextBox.ScrollToCaret();
                        }

                        lblStatus.Text = $"Выделен результат {selectedIndex + 1} из {currentResults.Count}: \"{result.MatchedText}\"";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка выделения: {ex.Message}");
            }
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentResults == null || currentResults.Count == 0)
                {
                    MessageBox.Show("Нет результатов для выделения.", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (searchManager != null)
                    searchManager.ClearHighlights();

                foreach (var result in currentResults)
                {
                    if (searchManager != null)
                        searchManager.HighlightText(result.AbsoluteIndex, result.Length);
                }

                lblStatus.Text = $"Выделено {currentResults.Count} совпадений в тексте";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentResults == null || currentResults.Count == 0)
                {
                    MessageBox.Show("Нет результатов для экспорта.", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Текстовые файлы (*.txt)|*.txt|CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
                    saveDialog.FilterIndex = 1;
                    saveDialog.DefaultExt = "txt";
                    saveDialog.FileName = $"search_results_{DateTime.Now:yyyyMMdd_HHmmss}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        StringBuilder sb = new StringBuilder();

                        if (saveDialog.FilterIndex == 2)
                        {
                            sb.AppendLine("\"Найденная подстрока\",\"Строка\",\"Позиция\",\"Длина\"");
                            foreach (var result in currentResults)
                            {
                                sb.AppendLine($"\"{result.MatchedText}\",{result.LineNumber},{result.CharPosition},{result.Length}");
                            }
                        }
                        else
                        {
                            sb.AppendLine("РЕЗУЛЬТАТЫ ПОИСКА");
                            sb.AppendLine(new string('=', 60));
                            sb.AppendLine($"Тип поиска: {cmbSearchType.Text}");
                            sb.AppendLine($"Дата: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
                            sb.AppendLine($"Всего найдено: {currentResults.Count}");
                            sb.AppendLine(new string('=', 60));
                            sb.AppendLine();

                            for (int i = 0; i < currentResults.Count; i++)
                            {
                                var result = currentResults[i];
                                sb.AppendLine($"{i + 1}. Подстрока: \"{result.MatchedText}\"");
                                sb.AppendLine($"   Позиция: строка {result.LineNumber}, символ {result.CharPosition}");
                                sb.AppendLine($"   Длина: {result.Length} символов");
                                sb.AppendLine();
                            }
                        }

                        File.WriteAllText(saveDialog.FileName, sb.ToString(), Encoding.UTF8);

                        MessageBox.Show($"Результаты успешно экспортированы в файл:\n{saveDialog.FileName}",
                            "Экспорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (searchManager != null)
                searchManager.ClearHighlights();
        }
    }
}