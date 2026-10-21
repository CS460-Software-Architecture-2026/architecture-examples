using System.Globalization;
using System.Reflection;

namespace Reflections.Exercise;

public static class ArgumentConverter
{
    public static object?[] Convert(string[] arguments, ParameterInfo[] parameters)
    {
        if (arguments.Length != parameters.Length)
            throw new ArgumentException($"Expected {parameters.Length} arguments, received {arguments.Length}.");

        var converted = new object?[parameters.Length];
        for (var i = 0; i < parameters.Length; i++)
        {
            var parameter = parameters[i];
            var text = arguments[i];

            if (parameter.ParameterType == typeof(string))
                converted[i] = text;
            else if (parameter.ParameterType == typeof(int)
                && int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var number))
                converted[i] = number;
            else if (parameter.ParameterType == typeof(bool) && bool.TryParse(text, out var flag))
                converted[i] = flag;
            else
                throw new ArgumentException($"Argument '{parameter.Name}' must be {parameter.ParameterType.Name}; received '{text}'.");
        }

        return converted;
    }
}
