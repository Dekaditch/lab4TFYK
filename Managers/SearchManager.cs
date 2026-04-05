using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using lab1.Models;

namespace lab1.Managers
{
    public class SearchManager
    {
        public enum SearchType
        {
            Identifier,      
            PhoneNumber,     
            WindowsFilePath  
        }

        public enum SearchMethod
        {
            Regex,      
            Automaton   
        }

        private RichTextBox textBox;
        private PhoneNumberAutomaton phoneAutomaton;

        public SearchManager(RichTextBox textBox)
        {
            this.textBox = textBox;
            this.phoneAutomaton = new PhoneNumberAutomaton();
        }

        public List<SearchResult> PerformSearch(SearchType searchType, RegexOptions options)
        {
            List<SearchResult> results = new List<SearchResult>();

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show("Нет данных для поиска. Пожалуйста, введите текст.",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return results;
            }

            Regex selectedRegex = GetRegexByType(searchType, options);
            string text = textBox.Text;

            MatchCollection matches = selectedRegex.Matches(text);

            foreach (Match match in matches)
            {
                if (match.Success && !string.IsNullOrWhiteSpace(match.Value))
                {
                    string matchedText;
                    int actualIndex;

                    if (searchType == SearchType.Identifier)
                    {
                        matchedText = match.Groups[1].Value;
                        actualIndex = match.Index + match.Value.IndexOf(matchedText);
                    }
                    else
                    {
                        matchedText = match.Value;
                        actualIndex = match.Index;
                    }

                    if (searchType == SearchType.WindowsFilePath && string.IsNullOrWhiteSpace(matchedText))
                    {
                        continue;
                    }

                    int lineNumber = GetLineNumber(text, actualIndex);
                    int charPosition = GetCharPositionInLine(text, actualIndex);

                    results.Add(new SearchResult(
                        matchedText,
                        lineNumber,
                        charPosition,
                        matchedText.Length,
                        actualIndex
                    ));
                }
            }

            return results;
        }


        private Regex GetRegexByType(SearchType searchType, RegexOptions options)
        {
            string pattern;
            switch (searchType)
            {
                case SearchType.Identifier:
                    pattern = @"(?:^|[\s])([a-zA-Z]+|[$_][a-zA-Z]+)(?=[\s]|$)";
                    break;

                case SearchType.PhoneNumber:
                    pattern = @"(?<!\d)((?:\+7|8)[\s\-]*(?:\(?\d{3}\)?[\s\-]*)?\d{3}[\s\-]*\d{2}[\s\-]*\d{2})(?!\d)";
                    break;

                case SearchType.WindowsFilePath:
                    pattern = @"[a-zA-Z]:\\(?:[^\\:*?""<>|\r\n]+\\)*[^\\:*?""<>|\r\n]+\.(?:docx?|pdf|txt|xlsx?|pptx?|jpg|png|exe|dll|ini|cfg|xml|json|log|tmp|bak)";
                    options |= RegexOptions.IgnoreCase;
                    break;

                default:
                    pattern = @"(?:^|[\s])([a-zA-Z]+|[$_][a-zA-Z]+)(?=[\s]|$)";
                    break;
            }

            return new Regex(pattern, options);
        }

        private int GetLineNumber(string text, int position)
        {
            if (position < 0 || position > text.Length)
                return 1;

            int lineNumber = 1;
            for (int i = 0; i < position && i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    lineNumber++;
                }
            }
            return lineNumber;
        }

        private int GetCharPositionInLine(string text, int position)
        {
            if (position < 0 || position > text.Length)
                return 1;

            int lastNewLine = -1;
            for (int i = 0; i < position; i++)
            {
                if (text[i] == '\n')
                {
                    lastNewLine = i;
                }
            }

            return position - lastNewLine;
        }

        public void HighlightText(int startIndex, int length)
        {
            if (textBox == null || startIndex < 0 || length <= 0)
                return;

            try
            {
                textBox.Focus();
                textBox.Select(startIndex, length);
                textBox.SelectionBackColor = System.Drawing.Color.Yellow;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при подсветке текста: {ex.Message}");
            }
        }

        public void ClearHighlights()
        {
            if (textBox == null)
                return;

            try
            {
                int selectionStart = textBox.SelectionStart;
                int selectionLength = textBox.SelectionLength;

                textBox.SelectAll();
                textBox.SelectionBackColor = System.Drawing.Color.White;

                textBox.Select(selectionStart, selectionLength);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при очистке подсветки: {ex.Message}");
            }
        }

        public string GetSearchTypeDescription(SearchType searchType)
        {
            switch (searchType)
            {
                case SearchType.Identifier:
                    return "Идентификаторы (буквы ИЛИ $/_, за которой обязательно идет буква)";
                case SearchType.PhoneNumber:
                    return "Российские номера телефонов (+7 или 8, 11 цифр)";
                case SearchType.WindowsFilePath:
                    return "Пути к файлам Windows (C:\\folder\\file.docx, D:\\file.txt)";
                default:
                    return "";
            }
        }
    }
}