﻿public static class Converter
{
    public static string ToBinary(this int source)
    {
        if (source < 2)
        {
            return (source % 2).ToString();
        }

        return (source % 2).ToString() + ToBinary(source / 2);
    }

    public static string ToEightBitBinary(this string source)
    {
        var result = int.Parse(source).ToBinary();
        for (int i = source.Length; i < 8; i++)
        {
            result += "0";
        }

        return result;
    }
}