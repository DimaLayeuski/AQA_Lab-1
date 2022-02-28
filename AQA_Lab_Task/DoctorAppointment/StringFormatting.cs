using System.Diagnostics;

namespace DoctorAppointment;

public static class StringFormatting
{
    public static string? Formatting(string? input)
    {
        string? refactorInput = null;
        Debug.Assert(input != null, nameof(input) + " != null");
        foreach (var unused in input)
        {
            var inputArray = input.Where(char.IsLetter).ToArray();
            inputArray[0] = char.ToUpper(inputArray[0]);
            refactorInput = string.Join("", inputArray);
        }

        return refactorInput;
    }
}