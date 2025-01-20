using System;
using System.IO;
using SuperMetroidRandomizer.IO;
using SuperMetroidRandomizer.Properties;
using SuperMetroidRandomizer.Random;
using SuperMetroidRandomizer.Rom;

namespace SuperMetroidRandomizer
{
    public class MainFunction
    {

        public void CreateRom(string difficultytext, string inputfile, string outputfile)
        {
            RandomizerDifficulty difficulty = GetDifficultyFromString(difficultytext);
            string seedV11 = SetSeedBasedOnDifficulty(difficulty);

            int parsedSeed;
            if (!int.TryParse(seedV11, out parsedSeed))
            {
                return;
            }
            else
            {
                var romLocations = RomLocationsFactory.GetRomLocations(difficulty);
                RandomizerLog log = null;

                
                
                log = new RandomizerLog(string.Format(romLocations.SeedFileString, parsedSeed));
                

                seedV11 = string.Format(romLocations.SeedFileString, parsedSeed);
                var randomizerV11 = new RandomizerV11(parsedSeed, romLocations, log, inputfile);
                randomizerV11.CreateRom(outputfile);
                string SaveFile = outputfile.Substring(0, outputfile.Length - 3) + "srm";
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
