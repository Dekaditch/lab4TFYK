using System;
using System.Collections.Generic;
using lab1.Models;

namespace lab1.Managers
{
    public class PhoneNumberAutomaton
    {
        public PhoneNumberAutomaton()
        {
        }

        public List<SearchResult> FindPhoneNumbers(string inputText)
        {
            List<SearchResult> results = new List<SearchResult>();

            if (string.IsNullOrWhiteSpace(inputText))
                return results;

            for (int i = 0; i < inputText.Length; i++)
            {
                string phone = TryParsePhoneAtPosition(inputText, i);
                if (phone != null)
                {
                    if (i > 0 && char.IsDigit(inputText[i - 1]))
                        continue;

                    int endPos = i + phone.Length;
                    if (endPos < inputText.Length && char.IsDigit(inputText[endPos]))
                        continue;

                    int lineNumber = GetLineNumber(inputText, i);
                    int charPosition = GetCharPositionInLine(inputText, i);

                    results.Add(new SearchResult(
                        phone,
                        lineNumber,
                        charPosition,
                        phone.Length,
                        i
                    ));

                    i = endPos - 1;
                }
            }

            return results;
        }

        private string TryParsePhoneAtPosition(string text, int start)
        {
            int pos = start;
            string result = "";

            if (pos >= text.Length) return null;

            if (text[pos] == '+')
            {
                result += "+";
                pos++;
                if (pos >= text.Length || text[pos] != '7') return null;
                result += "7";
                pos++;
            }
            else if (text[pos] == '8')
            {
                result += "8";
                pos++;
            }
            else
            {
                return null;
            }

            while (pos < text.Length && (text[pos] == ' ' || text[pos] == '-'))
            {
                result += text[pos];
                pos++;
            }

            bool hasBracket = false;
            if (pos < text.Length && text[pos] == '(')
            {
                result += "(";
                pos++;
                hasBracket = true;

                while (pos < text.Length && text[pos] == ' ')
                {
                    result += text[pos];
                    pos++;
                }
            }

            string code = "";
            int digitCount = 0;
            while (pos < text.Length && char.IsDigit(text[pos]) && digitCount < 3)
            {
                code += text[pos];
                result += text[pos];
                pos++;
                digitCount++;
            }

            if (digitCount != 3) return null;

            if (hasBracket)
            {
                while (pos < text.Length && text[pos] == ' ')
                {
                    result += text[pos];
                    pos++;
                }

                if (pos >= text.Length || text[pos] != ')') return null;
                result += ")";
                pos++;
            }

            while (pos < text.Length && (text[pos] == ' ' || text[pos] == '-'))
            {
                result += text[pos];
                pos++;
            }

            string firstThree = "";
            digitCount = 0;
            while (pos < text.Length && char.IsDigit(text[pos]) && digitCount < 3)
            {
                firstThree += text[pos];
                result += text[pos];
                pos++;
                digitCount++;
            }

            if (digitCount != 3) return null;

            while (pos < text.Length && (text[pos] == ' ' || text[pos] == '-'))
            {
                result += text[pos];
                pos++;
            }

            string nextTwo = "";
            digitCount = 0;
            while (pos < text.Length && char.IsDigit(text[pos]) && digitCount < 2)
            {
                nextTwo += text[pos];
                result += text[pos];
                pos++;
                digitCount++;
            }

            if (digitCount != 2) return null;

            while (pos < text.Length && (text[pos] == ' ' || text[pos] == '-'))
            {
                result += text[pos];
                pos++;
            }

            string lastTwo = "";
            digitCount = 0;
            while (pos < text.Length && char.IsDigit(text[pos]) && digitCount < 2)
            {
                lastTwo += text[pos];
                result += text[pos];
                pos++;
                digitCount++;
            }

            if (digitCount != 2)
            {
                if (firstThree.Length == 3 && nextTwo.Length == 2 && digitCount == 1)
                {
                    lastTwo = lastTwo + text[pos - 1].ToString();
                    result = result + text[pos - 1].ToString();
                }
                else
                {
                    return null;
                }
            }

            return result;
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
    }
}