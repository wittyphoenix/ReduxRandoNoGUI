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
        public static void ValidateItems(Items items)
        {
            int mainitems = 2;

            if (items.Bomb) mainitems++;
            if (items.Spazer) mainitems++;
            if (items.VariaSuit) mainitems++;
            if (items.HiJumpBoots) mainitems++;
            if (items.SpeedBooster) mainitems++;
            if (items.WaveBeam) mainitems++;
            if (items.GrappleBeam) mainitems++;
            if (items.GravitySuit) mainitems++;
            if (items.SpaceJump) mainitems++;
            if (items.SpringBall) mainitems++;
            if (items.PlasmaBeam) mainitems++;
            if (items.IceBeam) mainitems++;
            if (items.XRayScope) mainitems++;
            if (items.ScrewAttack) mainitems++;

            int totalitems = mainitems + items.Missiles / 5 + items.PowerBombs / 5 + items.PowerBombs / 5 + items.EnergyTanks + items.ReserveTanks;

            if (totalitems > 100)
            {
                throw new ValidationException($"Total item count cannot exceed 100. You currently have {totalitems}. To determine item count use this formula: 2 + 'true' items + Missiles/5 + PowerBombs/5 + SuperMissiles/5 + EnergyTanks + ReserveTanks.");
            }

            if(!((items.Missiles + items.PowerBombs + items.SuperMissiles) % 5 == 0))
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
