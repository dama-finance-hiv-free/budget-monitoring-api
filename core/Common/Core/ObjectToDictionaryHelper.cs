﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Dama.Core.Common.Core;

public static class ObjectToDictionaryHelper
{
    public static Dictionary<string, object> ToDictionary(this object source)
    {
        return source.ToDictionary<object>();
    }

    public static Dictionary<string, T> ToDictionary<T>(this object source)
    {
        if (source == null) ThrowExceptionWhenSourceArgumentIsNull();

        var dictionary = new Dictionary<string, T>();
        if (source == null) return dictionary;
        foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
        {
            var value = property.GetValue(source);
            if (IsOfType<T>(value))
            {
                dictionary.Add(property.Name, (T)value);
            }
        }

        return dictionary;
    }

    private static bool IsOfType<T>(object value)
    {
        return value is T;
    }

    private static void ThrowExceptionWhenSourceArgumentIsNull()
    {
        throw new NullReferenceException("Unable to convert anonymous object to a dictionary. The source anonymous object is null.");
    }
}