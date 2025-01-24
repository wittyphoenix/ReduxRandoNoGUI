using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuperMetroidReduxRandomizer.Settings;

namespace SuperMetroidRandomizer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            
            //// Convert Settings JSON into Settings Class
            string settingspath = args[0];
            JsonSerializer serializer = new JsonSerializer();
            StreamReader file = File.OpenText(settingspath);
            JsonTextReader json = new JsonTextReader(file);

            Settings Settings = null;
            try
            {
                Settings = serializer.Deserialize<Settings>(json);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }

            try
            {
                Validation.ValidateSeed(Settings.seed);
                Validation.ValidateFilePath(Settings.InputFile);
                Validation.ValidateFilePath(Settings.OutputFile);
                Validation.ValidateDifficulty(Settings.Difficulty);
                Validation.ValidateItems(Settings.ItemsCount.Missiles, Settings.ItemsCount.SuperMissiles,Settings.ItemsCount.PowerBombs);
                Validation.ValidatePositive(Settings.ItemsCount.Missiles);
                Validation.ValidatePositive(Settings.ItemsCount.SuperMissiles);
                Validation.ValidatePositive(Settings.ItemsCount.PowerBombs);
                Validation.ValidatePositive(Settings.ItemsCount.EnergyTanks);
                Validation.ValidatePositive(Settings.ItemsCount.ReserveTanks);
                Validation.ValidateEnergy(Settings.ItemsCount.EnergyTanks);
                Validation.ValidateReserve(Settings.ItemsCount.ReserveTanks);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }

            var MainFunction = new MainFunction();
            MainFunction.CreateRom(Settings);
            
        }
    }
}
