using SuperMetroidRandomizer.Random;

namespace SuperMetroidRandomizer.Rom
{
    public class RomLocationsFactory
    {
        public static IRomLocations GetRomLocations(RandomizerDifficulty difficulty)
        {
            switch (difficulty)
            {
                case RandomizerDifficulty.Casual:
                    return new RomLocationsCasual();
                case RandomizerDifficulty.Masochist:
                    return new RomLocationsMasochist();
                default:
                    return new RomLocationsSpeedrunner();
            }
        }
    }
}
