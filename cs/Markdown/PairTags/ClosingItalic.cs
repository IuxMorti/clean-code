﻿using Markdown.Interfaces;

namespace Markdown.PairTags
{
    public class ClosingItalic : IPairTag
    {
        public string ViewTag => "_";

        public Tag Tag => Tag.Italic;

        public TagType TagType => TagType.Close;

        public bool CheckForCompliance(string textContext, int position)
        {
            if (textContext[position] != '_' || position < 1)
                return false;

            if (position + 2 < textContext.Length &&
                textContext[position + 1] == '_' && textContext[position + 2] == '_')
                return true;

            if (textContext[position - 1] == '_' ||
                (position + 1 < textContext.Length && textContext[position + 1] == '_'))
                return false;

            if (char.IsWhiteSpace(textContext[position - 1]))
                return false;

            if ((position + 1 < textContext.Length
                 && char.IsDigit(textContext[position + 1])) || char.IsDigit(textContext[position - 1]))
                return false;

            return true;
        }
    }
}