namespace lab1.Models
{
    public class SearchResult
    {
        public string MatchedText { get; set; }
        public int LineNumber { get; set; }
        public int CharPosition { get; set; }
        public int Length { get; set; }
        public int AbsoluteIndex { get; set; }

        public SearchResult(string matchedText, int lineNumber, int charPosition, int length, int absoluteIndex)
        {
            MatchedText = matchedText;
            LineNumber = lineNumber;
            CharPosition = charPosition;
            Length = length;
            AbsoluteIndex = absoluteIndex;
        }
    }
}