using System;
using System.IO;
using SuperMetroidRandomizer.IO;
using SuperMetroidRandomizer.Random;
using SuperMetroidRandomizer.Rom;
using SuperMetroidReduxRandomizer.Settings;

namespace SuperMetroidRandomizer
{
    public class MainFunction
    {

        public void CreateRom(Settings Settings)
        {
            RandomizerDifficulty difficulty = GetDifficultyFromString(Settings.Difficulty);
            string seedV11 = "";

            if (string.IsNullOrWhiteSpace(Settings.seed))
            {
                seedV11 = SetSeedBasedOnDifficulty(difficulty);
            }
            else
            {
                seedV11 = Settings.seed;
            }

            int parsedSeed;
            if (!int.TryParse(seedV11, out parsedSeed))
            {
                return;
            }
            else
            {
                var romLocations = RomLocationsFactory.GetRomLocations(difficulty);
                RandomizerLog log = null;


                if (Settings.SpoilerLog == true)
                {
                    log = new RandomizerLog(string.Format(romLocations.SeedFileString, parsedSeed));
                }
                

                seedV11 = string.Format(romLocations.SeedFileString, parsedSeed);
                var randomizerV11 = new RandomizerV11(parsedSeed, romLocations, log, Settings);
                randomizerV11.CreateRom(Settings.OutputFile);
                string SaveFile = Settings.OutputFile.Substring(0, Settings.OutputFile.Length - 3) + "srm";
                if (File.Exists(SaveFile))
                {
                    File.Delete(SaveFile);
                }
            }
        }
        private string SetSeedBasedOnDifficulty(RandomizerDifficulty difficulty)
        {
            switch (difficulty)
            {
                case RandomizerDifficulty.Casual:
                    return string.Format("{0:0000000}", (new SeedRandom()).Next(10000000));
                case RandomizerDifficulty.Masochist:
                    return string.Format("{0:0000000}", (new SeedRandom()).Next(10000000));
                case RandomizerDifficulty.Insane:
                    return  string.Format("{0:0000000}", (new SeedRandom()).Next(10000000));
                default:
                    return string.Format("{0:0000000}", (new SeedRandom()).Next(10000000));
            }

        }
        private RandomizerDifficulty GetDifficultyFromString(string str)
        {
            switch (str)
            {
                case "Casual":
                    return RandomizerDifficulty.Casual;
                case "Speedrunner":
                    return RandomizerDifficulty.Speedrunner;
                case "Masochist":
                    return RandomizerDifficulty.Masochist;
                default:
                    return RandomizerDifficulty.Casual;
            }
        }
    }
}
