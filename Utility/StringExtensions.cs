using Godot;
using System;
using SI = SimpleInjector;
using static Godot.GD;
using System.Reflection;
using System.Collections;

namespace FarewellToFate;

public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string x) => string.IsNullOrEmpty(x);
    public static string Join(this string joiner, IEnumerable values) => string.Join(joiner, values);
    public static string Join(this IEnumerable values, string joiner) => string.Join(joiner, values);
    public static bool IsNullOrWhiteSpace(this string x) => string.IsNullOrWhiteSpace(x);
}