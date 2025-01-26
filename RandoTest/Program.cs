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
                Validation.ValidateFileExists(Settings.InputFile);
                Validation.ValidateDifficulty(Settings.Difficulty);
                Validation.ValidateItems(Settings.Items);
                Validation.ValidatePositive(Settings.Items.Missiles);
                Validation.ValidatePositive(Settings.Items.SuperMissiles);
                Validation.ValidatePositive(Settings.Items.PowerBombs);
                Validation.ValidatePositive(Settings.Items.EnergyTanks);
                Validation.ValidatePositive(Settings.Items.ReserveTanks);
                Validation.ValidateEnergy(Settings.Items.EnergyTanks);
                Validation.ValidateReserve(Settings.Items.ReserveTanks);
                Validation.ValidateMinimum(Settings.Items.SuperMissiles);
                Validation.ValidateMinimum(Settings.Items.PowerBombs);
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
