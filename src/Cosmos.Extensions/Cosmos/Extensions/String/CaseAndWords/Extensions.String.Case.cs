﻿using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class StringExtensions
    {
        public static string ToCapitalCase(this string original)
        {
            var words = original.Split(' ');
            var result = new List<string>();
            foreach (var word in words)
            {
                if (word.Length == 0 || AllCapitals(word))
                    result.Add(word);
                else if (word.Length == 1)
                    result.Add(word.ToUpper());
                else
                    result.Add(char.ToUpper(word[0]) + word.Remove(0, 1).ToLower());
            }

            return string.Join(" ", result).Replace(" Y ", " y ")
                .Replace(" De ", " de ")
                .Replace(" O ", " o ");

        }

        static bool AllCapitals(string input)
        {
            return input.ToCharArray().All(Char.IsUpper);
        }

        public static string ToCamelCase(this string original)
        {
            if (original.Length <= 1)
                return original.ToLower();

            return char.ToLower(original[0]) + original.Substring(1);
        }

    }
}
