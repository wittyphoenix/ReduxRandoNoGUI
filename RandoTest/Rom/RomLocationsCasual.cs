using System;
using System.Collections.Generic;
using System.Linq;
using SuperMetroidRandomizer.Random;

namespace SuperMetroidRandomizer.Rom
{
    public class RomLocationsCasual : IRomLocations
    {
        public List<Location> Locations { get; set; }
        public string DifficultyName { get { return "Casual"; } }
        public string SeedFileString { get { return "C{0:0000000}" ; } }
        public string SeedRomString { get { return "SMR C{0}"; } }

        public void ResetLocations()
        {
            Locations = new List<Location>
                       {
                           new Location
                               {
                                   NoHidden = false,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Power Bomb (Crateria surface)",
                                   Address = 0x781CC,
                                   MapAddress = 0x17c8e,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have) 
                                       && (have.Contains(ItemType.SpeedBooster) 
                                           || have.Contains(ItemType.SpaceJump)),
                               },
                           new Location
                               { 
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (outside Wrecked Ship bottom)",
                                   Address = 0x781E8,
                                   MapAddress = 0x17c96,
                                   CanAccess =
                                       have => 
                                       CanAccessWs(have),
                               },
                           new Location
                               {     
                                   NoHidden = false,
                                   GravityOkay = false,                                   
                                   Region = Region.Crateria,
                                   Name = "Missile (outside Wrecked Ship top)",
                                   Address = 0x781EE,
                                   MapAddress = 0x17c9e,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanDefeatPhantoon(have),
                               },
                           new Location
                               {       
                                   NoHidden = false,
                                   GravityOkay = false,  
                                   Region = Region.Crateria,
                                   Name = "Missile (outside Wrecked Ship middle)",
                                   Address = 0x781F4,
                                   MapAddress = 0x17ca6,
                                   CanAccess =
                                       have => 
                                       CanDefeatPhantoon(have),
                               },
                           new Location
                               {        
                                   NoHidden = true,
                                   GravityOkay = false,   
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria moat)",
                                   Address = 0x78248,
                                   MapAddress = 0x17cae,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile) 
                                       && CanUsePowerBombs(have),
                               },
                           new Location
                               {       
                                   NoHidden = true,
                                   GravityOkay = false,    
                                   Region = Region.Crateria,
                                   Name = "Energy Tank (Crateria gauntlet)",
                                   Address = 0x78264,
                                   MapAddress = 0x17cb6,
                                   CanAccess =
                                       have =>
                                       CanEnterAndLeaveGauntlet(have)
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.SpeedBooster)),
                               },
                           new Location
                               {        
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria bottom)",
                                   Address = 0x783EE,
                                   MapAddress = 0x17cbe,
                                   CanAccess =
                                       have => 
                                       CanDestroyBombWalls(have),
                               },
                           new Location
                               {        
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Crateria,
                                   Name = "Bomb",
                                   Address = 0x78404,
                                   MapAddress = 0x17cc6,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
                                       && CanPassBombPassages(have),
                               },
                           new Location
                               {     
                                   NoHidden = true,
                                   GravityOkay = false,   
                                   Region = Region.Crateria,
                                   Name = "Energy Tank (Crateria tunnel to Brinstar)",
                                   Address = 0x78432,
                                   MapAddress = 0x17cce,
                                   CanAccess = 
                                       have => 
                                       CanDestroyBombWalls(have),
                               },
                           new Location
                               {       
                                   NoHidden = false,
                                   GravityOkay = false,   
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria gauntlet right)",
                                   Address = 0x78464,
                                   MapAddress = 0x17cd6,
                                   ItemID = "x09",
                                   CanAccess =
                                       have =>
                                       CanEnterAndLeaveGauntlet(have) 
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.SpeedBooster))
                                       && CanPassBombPassages(have),
                               },
                           new Location
                               {     
                                   NoHidden = false,
                                   GravityOkay = false,   
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria gauntlet left)",
                                   Address = 0x7846A,
                                   MapAddress = 0x17cd6,
                                   ItemID = "x0A",
                                   CanAccess =
                                       have =>
                                       CanEnterAndLeaveGauntlet(have) 
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.SpeedBooster))
                                       && CanPassBombPassages(have),
                               },
                           new Location
                               {     
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Crateria,
                                   Name = "Super Missile (Crateria)",
                                   Address = 0x78478,
                                   MapAddress = 0x17cde,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                                       && have.Contains(ItemType.SpeedBooster) 
                                       && (EnergyReserveCount(have) >= 1 
                                           || have.Contains(ItemType.VariaSuit) 
                                           || have.Contains(ItemType.GravitySuit)),
                               },
                           new Location
                               {       
                                   NoHidden = false,
                                   GravityOkay = false,     
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria middle)",
                                   Address = 0x78486,
                                   MapAddress = 0x17ce6,
                                   CanAccess =
                                       have =>
                                       CanPassBombPassages(have),
                               },
                           new Location
                               {        
                                   NoHidden = false,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Power Bomb (green Brinstar bottom)",
                                   Address = 0x784AC,
                                   MapAddress = 0x17cf0,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have => 
                                       CanUsePowerBombs(have),
                               },
                           new Location
                               {        
                                   NoHidden = false,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "Super Missile (pink Brinstar)",
                                   Address = 0x784E4,
                                   MapAddress = 0x17cf8,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanPassBombPassages(have) 
                                       && have.Contains(ItemType.SuperMissile),
                               },
                           new Location
                               {            
                                   NoHidden = true,
                                   GravityOkay = false, 
                                   Region = Region.Brinstar,
                                   Name = "Missile (green Brinstar below super missile)",
                                   Address = 0x78518,
                                   MapAddress = 0x17d00,
                                   CanAccess =
                                       have =>
                                       CanPassBombPassages(have) 
                                       && CanOpenMissileDoors(have),
                               },
                           new Location
                               {            
                                   NoHidden = false,
                                   GravityOkay = false,   
                                   Region = Region.Brinstar,
                                   Name = "Super Missile (green Brinstar top)",
                                   Address = 0x7851E,
                                   MapAddress = 0x17d08,
                                   CanAccess =
                                       have =>
                                       CanDestroyBombWalls(have) 
                                       && CanOpenMissileDoors(have) 
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {           
                                   NoHidden = false,
                                   GravityOkay = false,   
                                   Region = Region.Brinstar,
                                   Name = "Reserve Tank (Brinstar)",
                                   Address = 0x7852C,
                                   MapAddress = 0x17d10,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanDestroyBombWalls(have) 
                                       && CanOpenMissileDoors(have) 
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {            
                                   NoHidden = false,
                                   GravityOkay = false,   
                                   Region = Region.Brinstar,
                                   Name = "Missile (green Brinstar behind missile)",
                                   Address = 0x78532,
                                   MapAddress = 0x17d18,
                                   ItemID = "x12",
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanPassBombPassages(have) 
                                       && CanOpenMissileDoors(have) 
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {             
                                   NoHidden = false,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "Missile (green Brinstar behind Reserve Tank)",
                                   Address = 0x78538,
                                   MapAddress = 0x17d18,
                                   ItemID = "x13",
                                   CanAccess =
                                       have =>
                                       CanDestroyBombWalls(have) 
                                       && CanOpenMissileDoors(have) 
                                       && have.Contains(ItemType.SpeedBooster)
                                       && have.Contains(ItemType.MorphingBall),
                               },
                           new Location
                               {             
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Brinstar,
                                   Name = "Missile (pink Brinstar top)",
                                   Address = 0x78608,
                                   MapAddress = 0x17d20,
                                   CanAccess =
                                       have =>
                                       CanDestroyBombWalls(have) 
                                       && CanOpenMissileDoors(have)
                                       && (have.Contains(ItemType.GrappleBeam) 
                                           || have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.SpeedBooster))
                               },
                           new Location
                               {            
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Brinstar,
                                   Name = "Missile (pink Brinstar bottom)",
                                   Address = 0x7860E,
                                   MapAddress = 0x17d28,
                                   CanAccess =
                                       have =>
                                       (CanDestroyBombWalls(have) 
                                           && CanOpenMissileDoors(have))
                                       || CanUsePowerBombs(have),
                               },
                           new Location
                               {             
                                   NoHidden = false,
                                   GravityOkay = false,      
                                   Region = Region.Brinstar,
                                   Name = "Charge Beam",
                                   Address = 0x78614,
                                   MapAddress = 0x17d30,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       (CanPassBombPassages(have) 
                                           && CanOpenMissileDoors(have))
                                       || CanUsePowerBombs(have),
                               },
                           new Location
                               {            
                                   NoHidden = false,
                                   GravityOkay = false,     
                                   Region = Region.Brinstar,
                                   Name = "Power Bomb (pink Brinstar)",
                                   Address = 0x7865C,
                                   MapAddress = 0x17d38,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have) 
                                       && have.Contains(ItemType.SuperMissile)
                                       && (have.Contains(ItemType.GrappleBeam) 
                                           || have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.SpeedBooster))
                              },
                           new Location
                               {           
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Brinstar,
                                   Name = "Missile (green Brinstar pipe)",
                                   Address = 0x78676,
                                   MapAddress = 0x17d40,
                                   CanAccess =
                                       have =>
                                       ((CanPassBombPassages(have) 
                                               && have.Contains(ItemType.SuperMissile))
                                           || CanUsePowerBombs(have))
                                       && (have.Contains(ItemType.HiJumpBoots) 
                                           || have.Contains(ItemType.SpaceJump)),
                               },
                           new Location
                               {           
                                   NoHidden = true,
                                   GravityOkay = false,              
                                   Region = Region.Brinstar,
                                   Name = "Morphing Ball",         
                                   Address = 0x786DE,
                                   MapAddress = 0x17d48,
                                   CanAccess = 
                                       have => 
                                       true,
                               },
                           new Location
                               {              
                                   NoHidden = false,
                                   GravityOkay = false,      
                                   Region = Region.Brinstar,
                                   Name = "Power Bomb (blue Brinstar)",
                                   Address = 0x7874C,
                                   MapAddress = 0x17d50,
                                   CanAccess =
                                       have => 
                                       CanUsePowerBombs(have),
                               },
                           new Location
                               {              
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Brinstar,
                                   Name = "Missile (blue Brinstar middle)",
                                   Address = 0x78798,
                                   MapAddress = 0x17d58,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have) 
                                       && have.Contains(ItemType.MorphingBall),
                               },
                           new Location
                               {            
                                   NoHidden = false,
                                   GravityOkay = false,   
                                   Region = Region.Brinstar,
                                   Name = "Energy Tank (blue Brinstar)",
                                   Address = 0x7879E,
                                   MapAddress = 0x17d60,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have) 
                                       && (have.Contains(ItemType.HiJumpBoots) 
                                           || have.Contains(ItemType.SpeedBooster) 
                                           || have.Contains(ItemType.SpaceJump)),
                               },
                           new Location
                               {            
                                   NoHidden = false,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "Energy Tank (green Brinstar bottom)",
                                   Address = 0x787C2,
                                   MapAddress = 0x17d68,
                                   CanAccess =
                                       have => 
                                       CanUsePowerBombs(have),
                               },
                           new Location
                               {            
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Brinstar,
                                   Name = "Super Missile (green Brinstar bottom)",
                                   Address = 0x787D0,
                                   MapAddress = 0x17d70,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have) 
                                       && have.Contains(ItemType.SuperMissile),
                               },
                           new Location
                               {          
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Brinstar,
                                   Name = "Energy Tank (pink Brinstar bottom)",
                                   Address = 0x787FA,
                                   MapAddress = 0x17d78,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have) 
                                       && CanOpenMissileDoors(have)
                                       && have.Contains(ItemType.SpeedBooster) 
                                       && have.Contains(ItemType.GravitySuit),
                               },
                           new Location
                               {            
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Brinstar,
                                   Name = "Missile (blue Brinstar bottom)",
                                   Address = 0x78802,
                                   MapAddress = 0x17d80,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess = 
                                       have => 
                                       have.Contains(ItemType.MorphingBall),
                               },
                           new Location
                               {             
                                   NoHidden = false,
                                   GravityOkay = false,     
                                   Region = Region.Brinstar,
                                   Name = "Energy Tank (pink Brinstar top)",
                                   Address = 0x78824,
                                   MapAddress = 0x17d88,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have) 
                                       && have.Contains(ItemType.WaveBeam),
                               },
                           new Location
                               {           
                                   NoHidden = false,
                                   GravityOkay = false,    
                                   Region = Region.Brinstar,
                                   Name = "Missile (blue Brinstar top)",
                                   Address = 0x78836,
                                   MapAddress = 0x17d90,
                                   ItemID = "x24",
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have) 
                                       && CanUsePowerBombs(have) 
                                       && (have.Contains(ItemType.SpeedBooster) 
                                           || have.Contains(ItemType.SpaceJump)),
                               },
                           new Location
                               {           
                                   NoHidden = false,
                                   GravityOkay = false,   
                                   Region = Region.Brinstar,
                                   Name = "Missile (blue Brinstar behind missile)",
                                   Address = 0x7883C,
                                   MapAddress = 0x17d90,
                                   ItemID = "x25",
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have) 
                                       && CanUsePowerBombs(have) 
                                       && (have.Contains(ItemType.SpeedBooster) 
                                           || have.Contains(ItemType.SpaceJump)),
                               },
                           new Location
                               {           
                                   NoHidden = false,
                                   GravityOkay = false,      
                                   Region = Region.Brinstar,
                                   Name = "X-Ray Visor",
                                   Address = 0x78876,
                                   MapAddress = 0x17d98,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have) 
                                       && CanUsePowerBombs(have) 
                                       && (have.Contains(ItemType.GrappleBeam) 
                                           || have.Contains(ItemType.SpaceJump)),
                               },
                           new Location
                               {           
                                   NoHidden = false,
                                   GravityOkay = false,            
                                   Region = Region.Brinstar,
                                   Name = "Power Bomb (red Brinstar sidehopper room)",
                                   Address = 0x788CA,
                                   MapAddress = 0x17da0,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have) 
                                       && CanUsePowerBombs(have), 
                               },
                           new Location
                               {            
                                   NoHidden = false,
                                   GravityOkay = false,        
                                   Region = Region.Brinstar,
                                   Name = "Power Bomb (red Brinstar spike room)",
                                   Address = 0x7890E,
                                   MapAddress = 0x17da8,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have) 
                                       && CanUsePowerBombs(have), 
                               },
                           new Location
                               {              
                                   NoHidden = false,
                                   GravityOkay = false,     
                                   Region = Region.Brinstar,
                                   Name = "Missile (red Brinstar spike room)",
                                   Address = 0x78914,
                                   MapAddress = 0x17db0,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have) 
                                       && CanUsePowerBombs(have), 
                               },
                           new Location
                               {            
                                   GravityOkay = false, 
                                   Region = Region.Brinstar,
                                   Name = "Spazer",
                                   Address = 0x7896E,
                                   MapAddress = 0x17db8,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have) 
                                       && CanPassBombPassages(have)
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.HiJumpBoots)),
                               },
                           new Location
                               {           
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Energy Tank (Kraid)",
                                   Address = 0x7899C,
                                   MapAddress = 0x17dc0,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessKraid(have),
                               },
                           new Location
                               {           
                                   NoHidden = false,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "Missile (Kraid)",
                                   Address = 0x789EC,
                                   MapAddress = 0x17dc8,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessKraid(have)
                                       && CanUsePowerBombs(have),
                               },
                           new Location
                               {            
                                   NoHidden = false,
                                   GravityOkay = false,  
                                   Region = Region.Brinstar,
                                   Name = "Varia Suit",
                                   Address = 0x78ACA,
                                   MapAddress = 0x17dd0,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessKraid(have),
                               },
                           new Location
                               {              
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (lava room)",
                                   Address = 0x78AE4,
                                   MapAddress = 0x17dda,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have),
                               },
                           new Location
                               {                    
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Ice Beam",
                                   Address = 0x78B24,
                                   MapAddress = 0x17de2,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessKraid(have)
                                       && (have.Contains(ItemType.GravitySuit) 
                                           || have.Contains(ItemType.VariaSuit))
                                       && have.Contains(ItemType.SpeedBooster)
                                       && (CanUsePowerBombs(have) 
                                           || have.Contains(ItemType.IceBeam)),
                               },
                           new Location
                               {                  
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (below Ice Beam)",
                                   Address = 0x78B46,
                                   MapAddress = 0x17dea,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have)
                                       && CanUsePowerBombs(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {                   
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Energy Tank (Crocomire)",
                                   Address = 0x78BA4,
                                   MapAddress = 0x17df2,
                                   CanAccess =
                                       have =>
                                       CanAccessCrocomire(have),
                               },
                           new Location
                               {                    
                                   NoHidden = false,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Hi-Jump Boots",
                                   Address = 0x78BAC,
                                   MapAddress = 0x17dfa,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have), 
                               },
                           new Location
                               {                   
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (above Crocomire)",
                                   Address = 0x78BC0,
                                   MapAddress = 0x17e02,
                                   CanAccess =
                                       have =>
                                       CanAccessCrocomire(have)
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.GrappleBeam)),
                               },
                           new Location
                               {                   
                                   NoHidden = false,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Missile (Hi-Jump Boots)",
                                   Address = 0x78BE6,
                                   MapAddress = 0x17e0a,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have), 
                               },
                           new Location
                               {                    
                                   NoHidden = false,
                                   GravityOkay = false,  
                                   Region = Region.Norfair,
                                   Name = "Energy Tank (Hi-Jump Boots)",
                                   Address = 0x78BEC,
                                   MapAddress = 0x17e12,
                                   CanAccess =
                                       have =>
                                       CanAccessRedBrinstar(have), 
                               },
                           new Location
                               {                    
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Power Bomb (Crocomire)",
                                   Address = 0x78C04,
                                   MapAddress = 0x17e1a,
                                   CanAccess =
                                       have =>
                                       CanAccessCrocomire(have)
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.GrappleBeam)),
                               },
                           new Location
                               {                    
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (below Crocomire)",
                                   Address = 0x78C14,
                                   MapAddress = 0x17e22,
                                   CanAccess =
                                       have =>
                                       CanAccessCrocomire(have),
                               },
                           new Location
                               {                   
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (Grapple Beam)",
                                   Address = 0x78C2A,
                                   MapAddress = 0x17e2a,
                                   CanAccess =
                                       have =>
                                       CanAccessCrocomire(have)
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.GrappleBeam) 
                                           || have.Contains(ItemType.SpeedBooster)),
                               },
                           new Location
                               {                     
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Grapple Beam",
                                   Address = 0x78C36,
                                   MapAddress = 0x17e32,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessCrocomire(have)
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || (have.Contains(ItemType.SpeedBooster)
                                               && have.Contains(ItemType.HiJumpBoots))),
                               },
                           new Location
                               {                  
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Reserve Tank (Norfair)",
                                   Address = 0x78C3E,
                                   MapAddress = 0x17e3a,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have) 
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.GrappleBeam)),
                               },
                           new Location
                               {                  
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (Norfair Reserve Tank)",
                                   Address = 0x78C44,
                                   MapAddress = 0x17e3a,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have) 
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.GrappleBeam)),
                               },
                           new Location
                               {                 
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (bubble Norfair green door)",
                                   Address = 0x78C52,
                                   MapAddress = 0x17e42,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have) 
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.GrappleBeam)),
                               },
                           new Location
                               {                       
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (bubble Norfair)",
                                   Address = 0x78C66,
                                   MapAddress = 0x17e4a,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have), 
                               },
                           new Location
                               {                     
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (Speed Booster)",
                                   Address = 0x78C74,
                                   MapAddress = 0x17e52,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have), 
                               },
                           new Location
                               {                     
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Speed Booster",
                                   Address = 0x78C82,
                                   MapAddress = 0x17e5a,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have), 
                               },
                           new Location
                               {                      
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Missile (Wave Beam)",
                                   Address = 0x78CBC,
                                   MapAddress = 0x17e62,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have), 
                               },
                           new Location
                               {                     
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Norfair,
                                   Name = "Wave Beam",
                                   Address = 0x78CCA,
                                   MapAddress = 0x17e6a,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessHeatedNorfair(have)
                                       && (have.Contains(ItemType.SpaceJump) 
                                           || have.Contains(ItemType.GrappleBeam)),
                               },
                           new Location
                               {                     
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (Gold Torizo)",
                                   Address = 0x78E6E,
                                   MapAddress = 0x17e72,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Location
                               {                     
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Super Missile (Gold Torizo)",
                                   Address = 0x78E74,
                                   MapAddress = 0x17e7a,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Location
                               {                         
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (Mickey Mouse room)",
                                   Address = 0x78F30,
                                   MapAddress = 0x17e82,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Location
                               {                           
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (lower Norfair above fire flea room)",
                                   Address = 0x78FCA,
                                   MapAddress = 0x17e8a,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Location
                               {                             
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Power Bomb (lower Norfair above fire flea room)",
                                   Address = 0x78FD2,
                                   MapAddress = 0x17e92,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Location
                               {                         
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Power Bomb (above Ridley)",
                                   Address = 0x790C0,
                                   MapAddress = 0x17e9a,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Location
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (lower Norfair near Wave Beam)",
                                   Address = 0x79100,
                                   MapAddress = 0x17ea2,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Location
                               {                         
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Energy Tank (Ridley)",
                                   Address = 0x79108,
                                   MapAddress = 0x17eaa,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have)
                                       && have.Contains(ItemType.ChargeBeam)
                                       && EnergyReserveCount(have) >= 4,
                               },
                           new Location
                               {                        
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Screw Attack",
                                   Address = 0x79110,
                                   MapAddress = 0x17eb2,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Location
                               {                        
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.LowerNorfair,
                                   Name = "Energy Tank (lower Norfair fire flea room)",
                                   Address = 0x79184,
                                   MapAddress = 0x17eba,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Location
                               {                         
                                   NoHidden = false,
                                   GravityOkay = false,  
                                   Region = Region.WreckedShip,
                                   Name = "Missile (Wrecked Ship middle)",
                                   Address = 0x7C265,
                                   MapAddress = 0x17ec4,
                                   CanAccess =
                                       have => 
                                       CanAccessWs(have),
                               },
                           new Location
                               {                           
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "Reserve Tank (Wrecked Ship)",
                                   Address = 0x7C2E9,
                                   MapAddress = 0x17ecc,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanDefeatPhantoon(have) 
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {                           
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "Missile (Gravity Suit)",
                                   Address = 0x7C2EF,
                                   MapAddress = 0x17ed4,
                                   CanAccess =
                                       have => 
                                       CanDefeatPhantoon(have)
                               },
                           new Location
                               {                          
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "Missile (Wrecked Ship top)",
                                   Address = 0x7C319,
                                   MapAddress = 0x17edc,
                                   CanAccess =
                                       have => 
                                       CanDefeatPhantoon(have)
                               },
                           new Location
                               {                           
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "Energy Tank (Wrecked Ship)",
                                   Address = 0x7C337,
                                   MapAddress = 0x17ee4,
                                   CanAccess =
                                       have => 
                                       CanDefeatPhantoon(have) 
                                       && have.Contains(ItemType.GravitySuit) 
                                       && (have.Contains(ItemType.GrappleBeam) 
                                           || have.Contains(ItemType.SpaceJump)),
                               },
                           new Location
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "Super Missile (Wrecked Ship left)",
                                   Address = 0x7C357,
                                   MapAddress = 0x17eec,
                                   CanAccess =
                                       have => 
                                       CanDefeatPhantoon(have)
                               },
                           new Location
                               {                           
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "Super Missile (Wrecked Ship right)",
                                   Address = 0x7C365,
                                   MapAddress = 0x17ef4,
                                   CanAccess =
                                       have => 
                                       CanDefeatPhantoon(have)
                               },
                           new Location
                               {                           
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.WreckedShip,
                                   Name = "Gravity Suit",
                                   Address = 0x7C36D,
                                   MapAddress = 0x17efc,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have => 
                                       CanDefeatPhantoon(have)
                               },
                           new Location
                               {                           
                                   NoHidden = true,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (green Maridia shinespark)",
                                   Address = 0x7C437,
                                   MapAddress = 0x17f06,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Super Missile (green Maridia)",
                                   Address = 0x7C43D,
                                   MapAddress = 0x17f0e,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have),
                               },
                           new Location
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Energy Tank (green Maridia)",
                                   Address = 0x7C47D,
                                   MapAddress = 0x17f16,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have)
                                       && (have.Contains(ItemType.SpeedBooster) 
                                           || have.Contains(ItemType.GrappleBeam) 
                                           || have.Contains(ItemType.SpaceJump)),
                               },
                           new Location
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (green Maridia tatori)",
                                   Address = 0x7C483,
                                   MapAddress = 0x17f1e,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have),
                               },
                           new Location
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Super Missile (yellow Maridia)",
                                   Address = 0x7C4AF,
                                   MapAddress = 0x17f26,
                                   ItemID = "x8c",
                                   CanAccess =
                                       have =>
                                       CanAccessInnerMaridia(have),
                               },
                           new Location
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (yellow Maridia super missile)",
                                   Address = 0x7C4B5,
                                   MapAddress = 0x17f26,
                                   ItemID = "x8d",
                                   CanAccess =
                                       have =>
                                       CanAccessInnerMaridia(have),
                               },
                           new Location
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (yellow Maridia false wall)",
                                   Address = 0x7C533,
                                   MapAddress = 0x17f2e,
                                   CanAccess =
                                       have =>
                                       CanAccessInnerMaridia(have),
                               },
                           new Location
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Plasma Beam",
                                   Address = 0x7C559,
                                   MapAddress = 0x17f36,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanDefeatDraygon(have)
                                       && have.Contains(ItemType.SpaceJump)
                                       && (have.Contains(ItemType.ScrewAttack)
                                           || have.Contains(ItemType.PlasmaBeam)),
                               },
                           new Location
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (left Maridia sand pit room)",
                                   Address = 0x7C5DD,
                                   MapAddress = 0x17f3e,
                                   ItemID = "x90",
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have)
                                       && have.Contains(ItemType.SpringBall),
                               },
                           new Location
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Reserve Tank (Maridia)",
                                   Address = 0x7C5E3,
                                   MapAddress = 0x17f3e,
                                   ItemID = "x91",
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have)
                                       && have.Contains(ItemType.SpringBall),
                               },
                           new Location
                               {                           
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (right Maridia sand pit room)",
                                   Address = 0x7C5EB,
                                   MapAddress = 0x17f46,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have),
                               },
                           new Location
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Power Bomb (right Maridia sand pit room)",
                                   Address = 0x7C5F1,
                                   MapAddress = 0x17f4e,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have),
                               },
                           new Location
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (pink Maridia)",
                                   Address = 0x7C603,
                                   MapAddress = 0x17f56,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Super Missile (pink Maridia)",
                                   Address = 0x7C609,
                                   MapAddress = 0x17f5e,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Spring Ball",
                                   Address = 0x7C6E5,
                                   MapAddress = 0x17f66,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessOuterMaridia(have)
                                       && have.Contains(ItemType.GrappleBeam)
                                       && have.Contains(ItemType.SpaceJump),
                               },
                           new Location
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Missile (Draygon)",
                                   Address = 0x7C74D,
                                   MapAddress = 0x17f6e,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanDefeatDraygon(have),
                               },
                           new Location
                               {                             
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Energy Tank (Botwoon)",
                                   Address = 0x7C755,
                                   MapAddress = 0x17f76,
                                   CanAccess =
                                       have =>
                                       CanDefeatBotwoon(have),
                               },
                           new Location
                               {                            
                                   NoHidden = false,
                                   GravityOkay = true,  
                                   Region = Region.Maridia,
                                   Name = "Space Jump",
                                   Address = 0x7C7A7,
                                   MapAddress = 0x17f7e,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanDefeatDraygon(have),
                               },
                       };
        }

        private bool CanDefeatDraygon(List<ItemType> have)
        {
            return CanDefeatBotwoon(have)
                && have.Contains(ItemType.SpaceJump)
                && EnergyReserveCount(have) >= 3;
        }

        private bool CanDefeatBotwoon(List<ItemType> have)
        {
            return CanAccessInnerMaridia(have)
                && (have.Contains(ItemType.IceBeam) 
                    || have.Contains(ItemType.SpeedBooster));
        }

        private bool CanAccessInnerMaridia(List<ItemType> have)
        {
            return CanAccessOuterMaridia(have)
                && (have.Contains(ItemType.SpaceJump) 
                    || have.Contains(ItemType.GrappleBeam) 
                    || have.Contains(ItemType.SpeedBooster));
        }

        private bool CanAccessOuterMaridia(List<ItemType> have)
        {
            return CanAccessRedBrinstar(have)
                && have.Contains(ItemType.PowerBomb)
                && have.Contains(ItemType.GravitySuit)
                && (have.Contains(ItemType.SpaceJump) 
                    || have.Contains(ItemType.HiJumpBoots));
        }

        private bool CanAccessLowerNorfair(List<ItemType> have)
        {
            return CanAccessHeatedNorfair(have)
                && have.Contains(ItemType.PowerBomb)
                && have.Contains(ItemType.GravitySuit)
                && have.Contains(ItemType.SpaceJump);
        }

        private bool CanAccessCrocomire(List<ItemType> have)
        {
            return CanAccessHeatedNorfair(have)
                && ((have.Contains(ItemType.SpeedBooster) && CanUsePowerBombs(have)) 
                    || have.Contains(ItemType.WaveBeam));
        }

        private bool CanAccessHeatedNorfair(List<ItemType> have)
        {
            return CanAccessRedBrinstar(have)
                && (have.Contains(ItemType.SpaceJump) 
                    || have.Contains(ItemType.HiJumpBoots))
                && (have.Contains(ItemType.VariaSuit) 
                    || have.Contains(ItemType.GravitySuit));
        }

        private static int EnergyReserveCount(List<ItemType> have)
        {
            var energyTankCount = have.Count(x => x == ItemType.EnergyTank);
            var reserveTankCount = Math.Min(have.Count(x => x == ItemType.ReserveTank), energyTankCount + 1);
            return energyTankCount + reserveTankCount;
        }
        private bool CanAccessKraid(List<ItemType> have)
        {
            return CanAccessRedBrinstar(have)
                && (have.Contains(ItemType.SpaceJump) 
                    || have.Contains(ItemType.HiJumpBoots))
                && CanPassBombPassages(have);
        }

        private bool CanAccessRedBrinstar(List<ItemType> have)
        {
            return have.Contains(ItemType.SuperMissile)
                && ((CanDestroyBombWalls(have) 
                        && have.Contains(ItemType.MorphingBall)) 
                    || (CanUsePowerBombs(have)));
        }

        private bool CanPassBombPassages(List<ItemType> have)
        {
            return (have.Contains(ItemType.Bomb) 
                    && have.Contains(ItemType.MorphingBall)) 
                || (have.Contains(ItemType.PowerBomb) 
                    && have.Contains(ItemType.MorphingBall));
        }

        private static bool CanUsePowerBombs(List<ItemType> have)
        {
            return have.Contains(ItemType.PowerBomb) 
                && have.Contains(ItemType.MorphingBall);
        }

        private static bool CanOpenMissileDoors(List<ItemType> have)
        {
            return have.Contains(ItemType.Missile) 
                || have.Contains(ItemType.SuperMissile);
        }

        private static bool CanDestroyBombWalls(List<ItemType> have)
        {
            return (have.Contains(ItemType.Bomb) 
                    && have.Contains(ItemType.MorphingBall)) 
                || CanUsePowerBombs(have) 
                || have.Contains(ItemType.ScrewAttack);
        }

        private static bool CanEnterAndLeaveGauntlet(List<ItemType> have)
        {
            return (have.Contains(ItemType.Bomb) 
                    && have.Contains(ItemType.MorphingBall))
                || (have.Count(x => x == ItemType.PowerBomb) >= 2 
                    && have.Contains(ItemType.MorphingBall))
                || have.Contains(ItemType.ScrewAttack);
        }

        private static bool CanDefeatPhantoon(List<ItemType> have)
        {
            return CanAccessWs(have) 
                && have.Contains(ItemType.ChargeBeam)
                && (have.Contains(ItemType.GravitySuit) 
                    || have.Contains(ItemType.VariaSuit) 
                    || EnergyReserveCount(have) >= 2);
        }

        private static bool CanAccessWs(List<ItemType> have)
        {
            return have.Contains(ItemType.SuperMissile) 
                && CanUsePowerBombs(have)
                && (have.Contains(ItemType.SpaceJump) 
                    || have.Contains(ItemType.GrappleBeam) 
                    || have.Contains(ItemType.SpeedBooster));
        }

        public RomLocationsCasual()
        {
            ResetLocations();
        }

        public List<Location> GetAvailableLocations(List<ItemType> haveItems)
        {
            var retVal = (from Location location in Locations where (location.Item == null) && location.CanAccess(haveItems) select location).ToList();
            var currentWeight = (from item in retVal orderby item.Weight descending select item.Weight).First() + 1;

            foreach (var item in retVal.Where(item => item.Weight == 0))
            {
                item.Weight = currentWeight;
            }

            var addedItems = new List<List<Location>>();
            for (int i = 1; i < currentWeight; i++)
            {
                addedItems.Add(retVal.Where(x => x.Weight > i).ToList());
            }

            foreach (var list in addedItems)
            {
                retVal.AddRange(list);
            }

            return retVal;
        }

        public List<Location> GetUnavailableLocations(List<ItemType> haveItems)
        {
            return (from Location location in Locations where location.Item == null && !location.CanAccess(haveItems) select location).ToList();
        }

        public void TryInsertCandidateItem(List<Location> currentLocations, List<ItemType> candidateItemList, ItemType candidateItem)
        {
			// only try gravity if gravity is okay in this spot
			// only insert multiples of an item into the candidate list if we aren't looking at the morph ball slot.
			if (currentLocations.All(x => x.Name != "Morphing Ball") || !candidateItemList.Contains(candidateItem))
            {
                candidateItemList.Add(candidateItem);
            }
        }

        public int GetInsertedLocation(List<Location> currentLocations, ItemType insertedItem, SeedRandom random)
        {
            return random.Next(currentLocations.Count);
        }

        public ItemType GetInsertedItem(List<Location> currentLocations, List<ItemType> itemPool, SeedRandom random)
        {
            return itemPool[random.Next(itemPool.Count)];
        }

        public List<ItemType> GetItemPool(SeedRandom random)
        {
            return new List<ItemType>
                       {
                           ItemType.MorphingBall,
                           ItemType.Bomb,
                           ItemType.ChargeBeam,
                           ItemType.Spazer,
                           ItemType.VariaSuit,
                           ItemType.HiJumpBoots,
                           ItemType.SpeedBooster,
                           ItemType.WaveBeam,
                           ItemType.GrappleBeam,
                           ItemType.GravitySuit,
                           ItemType.SpaceJump,
                           ItemType.SpringBall,
                           ItemType.PlasmaBeam,
                           ItemType.IceBeam,
                           ItemType.ScrewAttack,
                           ItemType.XRayScope,
                       };
        }
    }
}
