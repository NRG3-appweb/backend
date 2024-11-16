using System.Text.RegularExpressions;

namespace NRG3.Bliss.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

/// <summary>
/// Contains extension methods for the <see cref="string"/> class.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// Converts a string to kebab-case.
    /// </summary>
    /// <param name="text">
    /// The text to convert to kebab-case.
    /// </param>
    /// <returns>
    /// The text converted to kebab-case.
    /// </returns>
    public static string ToKebabCase(this string text)
    {
        return string.IsNullOrEmpty(text) 
            ? text 
            : KebabCaseRegex().Replace(text, "-$1").Trim().ToLower();
    }

    [GeneratedRegex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", RegexOptions.Compiled)]
    private static partial Regex KebabCaseRegex();
}