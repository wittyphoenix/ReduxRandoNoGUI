using Microsoft.AspNetCore.Components.Forms;

namespace SuperMetroidReduxRandomizer.Settings
{
    public class Validation
    {
        public class ValidationException : Exception
        {
            public ValidationException(string message) : base(message) { }
        }
        public static void ValidateSeed(string value)
        {
            int parsedSeed;
            if (!int.TryParse(value, out parsedSeed) && value != "")
            {
                throw new ValidationException($"Seed must be an integer.");
            }
        }

        public static void ValidateFileExists(string value)
        {
            try 
            {
               byte[] RomImage = File.ReadAllBytes(value);
            }
            catch 
            {
                throw new ValidationException($"{value} is not a valid file path.");
            }
        }

        public static void ValidateDifficulty(string value)
        {
            if(value != "Casual" && value != "Speedrunner")
            {
                throw new ValidationException($"Difficulty must be either 'Casual' or 'Speedrunner'.");
            }
        }
        public static void ValidateItems(int missiles, int bombs, int supers)
        {
            if (missiles + bombs + supers > 330)
            {
                throw new ValidationException($"Total of Missiles, Super Missiles, and Power Bombs should not exceed 330.");
            }

            if(!((missiles + bombs + supers) % 5 == 0))
            {
                throw new ValidationException($"Missiles, Super Missiles, and Power Bombs must be divisble by 5.");
            }
        }

        public static void ValidatePositive(int value)
        {
            if (value < 0)
            {
                throw new ValidationException($"Item counts cannot be negative.");
            }
        }

        public static void ValidateMinimum(int value)
        {
            if (value < 5)
            {
                throw new ValidationException($"Must have at least 5 Super Missiles and Power Bombs.");
            }
        }

        public static void ValidateEnergy(int value)
        {
            if (value > 14)
            {
                throw new ValidationException($"Cannot have more than 14 energy tanks.");
            }
        }

        public static void ValidateReserve(int value)
        {
            if (value > 4)
            {
                throw new ValidationException($"Cannot have more than 4 reserve tanks.");
            }
        }

    }
}
