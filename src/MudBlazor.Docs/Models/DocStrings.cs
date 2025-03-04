﻿using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MudBlazor.Docs.Models
{
    // this is needed for the api docs 
    public static partial class DocStrings
    {
        public static string GetPropertyDescription(Type t, string property)
        {
            var name = $"{GetSaveTypename(t).Replace("<T>", "").TrimEnd('_')}_{property}";
            var field = typeof(DocStrings).GetField(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField);
            if (field == null)
                return null;
            return (string)field.GetValue(null);
        }

        public static string GetSaveTypename(Type t) => Regex.Replace(t.ConvertToCSharpSource(), @"[\.]", "_");
    }
}
