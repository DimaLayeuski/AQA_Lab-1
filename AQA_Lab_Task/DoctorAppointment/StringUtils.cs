namespace DoctorAppointment;

public static class StringUtils
{
    public static string? StringConversion(string? input)
    {
        string? refactorInput = null;
        if (input != null)
            foreach (var unused in input)
            {
                var inputArray = input.Where(char.IsLetter).ToArray();
                inputArray[0] = char.ToUpper(inputArray[0]);
                refactorInput = string.Join("", inputArray);
            }

        return refactorInput;
    }
}