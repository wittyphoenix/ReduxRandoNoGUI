namespace SuperMetroidReduxRandomizer.Settings
{
    public class Items
    {
        public int Missiles { get; set; }
        public int SuperMissiles { get; set; }
        public int PowerBombs { get; set; }
        public int EnergyTanks { get; set; }
        public int ReserveTanks { get; set; }
        public bool Bomb { get; set; }
        public bool Spazer { get; set; }
        public bool VariaSuit { get; set; }
        public bool HiJumpBoots { get; set; }
        public bool SpeedBooster { get; set; }
        public bool WaveBeam { get; set; }
        public bool GrappleBeam { get; set; }
        public bool GravitySuit { get; set; }
        public bool SpaceJump { get; set; }
        public bool SpringBall { get; set; }
        public bool PlasmaBeam { get; set; }
        public bool IceBeam { get; set; }
        public bool XRayScope { get; set; }
        public bool ScrewAttack { get; set; }

    }

    public class Settings
    {
        public string seed { get; set; }
        public string InputFile { get; set; }
        public string OutputFile { get; set; }
        public bool SpoilerLog { get; set; }
        public string Difficulty { get; set; }
        public bool HiddenItems { get; set; }
        public Items Items { get; set; }
    }
}
