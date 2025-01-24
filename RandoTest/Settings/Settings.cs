namespace SuperMetroidReduxRandomizer.Settings
{
    public class ItemsCount
    {
        public int Missiles { get; set; }
        public int SuperMissiles { get; set; }
        public int PowerBombs { get; set; }
        public int EnergyTanks { get; set; }
        public int ReserveTanks { get; set; }
    }

    public class Settings
    {
        public string seed { get; set; }
        public string InputFile { get; set; }
        public string OutputFile { get; set; }
        public bool SpoilerLog { get; set; }
        public string Difficulty { get; set; }
        public bool HiddenItems { get; set; }
        public ItemsCount ItemsCount { get; set; }
    }
}
