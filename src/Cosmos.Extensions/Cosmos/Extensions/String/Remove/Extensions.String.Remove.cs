﻿using System;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions
    {
        public static string Remove(this string text, string removeText)
        {
            return text.Replace(removeText, String.Empty);
        }

        public static string RemoveFromIgnoreCase(this string text, string removeFromThis)
        {
            var index = text.IndexOfIgnoreCase(removeFromThis);
            return index < 0 ? text : text.Substring(0, index);
        }

        public static string RemoveDuplicateSpaces(this string me)
        {
            if (me.IsNullOrEmpty())
                return me;

            string ante = null;
            while (ante != me)
            {
                ante = me;
                me = me.Replace("  ", " ");
            }
            return me;
        }

        public static string RemoveDuplicateChar(this string me, char charRemove)
        {
            if (me.IsNullOrEmpty())
                return me;

            var strChar = charRemove.ToString();
            var charRep = strChar + strChar;

            string ante = null;
            while (ante != me)
            {
                ante = me;
                me = me.Replace(charRep, strChar);
            }
            return me;
        }

        public static string RemoveChars(this string me, params char[] toRemove)
        {
            var res = new StringBuilder(me);
            foreach (var remove in toRemove)
            {
                res.Replace(remove, char.MinValue);
            }
            res.Replace(char.MinValue.ToString(), string.Empty);
            return res.ToString();
        }

        public static string RemoveAccentsIgnoreCaseAndÑ(this string text)
        {
            return text.IsNullOrEmpty() ? text : text.RemoveAccentsIgnoreCase().Replace('Ñ', 'N').Replace('ñ', 'n');
        }

        public static string RemoveAccentsIgnoreCase(this string text)
        {
            if (text.IsNullOrEmpty())
                return text;

            return text.Replace('Á', 'A')
                .Replace('É', 'E')
                .Replace('Í', 'I')
                .Replace('Ó', 'O')
                .Replace('Ú', 'U')
                .Replace('ü', 'u')
                .Replace('Ü', 'U')
                .Replace('á', 'a')
                .Replace('é', 'e')
                .Replace('í', 'i')
                .Replace('ó', 'o')
                .Replace('ú', 'u');
        }
    }
}
