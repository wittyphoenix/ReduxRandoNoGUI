using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
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
            string settingspath = args[0];
            JsonSerializer serializer = new JsonSerializer();
            StreamReader file = File.OpenText(settingspath);
            JsonTextReader json = new JsonTextReader(file);
            Settings Settings = serializer.Deserialize<Settings>(json);

            var MainFunction = new MainFunction();
            MainFunction.CreateRom(Settings);
            
        }
    }
}
