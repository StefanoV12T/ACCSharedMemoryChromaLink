using ChromaSDK;
using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using static ChromaSDK.Keyboard;
using static Telemetry_ACC_with_razer_Chroma.Refer.DataRefer;
using System.Drawing;
using Telemetry_ACC_with_razer_Chroma.Refer;


namespace Telemetry_ACC_with_razer_Chroma
{

    public class Telemetry
    {
        static Excel excel = new Excel();
        static bool ChromaON;
        
    
    static int _mResult;        

        public void Start()
        {
            if (ChromaON)
            {
                if (GetInitResult() == RazerErrors.RZRESULT_SUCCESS)
                {
                    Console.WriteLine("razerChroma attivo e funzionante");
                }
                else { Console.WriteLine("razerChroma in errore"); }
            }

            int[] keys = {
            (int)Keyboard.RZKEY.RZKEY_ESC,
            (int)Keyboard.RZKEY.RZKEY_OEM_1, //backslash \
            (int)Keyboard.RZKEY.RZKEY_TAB,
            (int)Keyboard.RZKEY.RZKEY_CAPSLOCK,
            (int)Keyboard.RZKEY.RZKEY_LSHIFT,
            (int)Keyboard.RZKEY.RZKEY_LCTRL,
            (int)Keyboard.RZKEY.RZKEY_1,
            (int)Keyboard.RZKEY.RZKEY_Q,
            (int)Keyboard.RZKEY.RZKEY_A,
            (int)Keyboard.RZKEY.RZKEY_EUR_2, // simbolo minore < o >
            (int)Keyboard.RZKEY.RZKEY_LWIN,
            (int)Keyboard.RZKEY.RZKEY_Z,
            (int)Keyboard.RZKEY.RZKEY_LALT,
            (int)Keyboard.RZKEY.RZKEY_F1,
            (int)Keyboard.RZKEY.RZKEY_2,
            (int)Keyboard.RZKEY.RZKEY_W,
            (int)Keyboard.RZKEY.RZKEY_S,
            (int)Keyboard.RZKEY.RZKEY_X,
            (int)Keyboard.RZKEY.RZKEY_F2,
            (int)Keyboard.RZKEY.RZKEY_3,
            (int)Keyboard.RZKEY.RZKEY_E,
            (int)Keyboard.RZKEY.RZKEY_D,
            (int)Keyboard.RZKEY.RZKEY_C,
            (int)Keyboard.RZKEY.RZKEY_F3,
            (int)Keyboard.RZKEY.RZKEY_4,
            (int)Keyboard.RZKEY.RZKEY_R,
            (int)Keyboard.RZKEY.RZKEY_F,
            (int)Keyboard.RZKEY.RZKEY_V,
            (int)Keyboard.RZKEY.RZKEY_F4,
            (int)Keyboard.RZKEY.RZKEY_5,
            (int)Keyboard.RZKEY.RZKEY_T,
            (int)Keyboard.RZKEY.RZKEY_G,
            (int)Keyboard.RZKEY.RZKEY_B,
            (int)Keyboard.RZKEY.RZKEY_6,
            (int)Keyboard.RZKEY.RZKEY_Y,
            (int)Keyboard.RZKEY.RZKEY_H,
            (int)Keyboard.RZKEY.RZKEY_N,
            (int)Keyboard.RZKEY.RZKEY_SPACE,
            (int)Keyboard.RZKEY.RZKEY_F5,
            (int)Keyboard.RZKEY.RZKEY_7,
            (int)Keyboard.RZKEY.RZKEY_U,
            (int)Keyboard.RZKEY.RZKEY_J,
            (int)Keyboard.RZKEY.RZKEY_M,
            (int)Keyboard.RZKEY.RZKEY_F6,
            (int)Keyboard.RZKEY.RZKEY_8,
            (int)Keyboard.RZKEY.RZKEY_I,
            (int)Keyboard.RZKEY.RZKEY_K,
            (int)Keyboard.RZKEY.RZKEY_OEM_9, // virgola , o ;
            (int)Keyboard.RZKEY.RZKEY_RALT,
            (int)Keyboard.RZKEY.RZKEY_F7,
            (int)Keyboard.RZKEY.RZKEY_9,
            (int)Keyboard.RZKEY.RZKEY_O,
            (int)Keyboard.RZKEY.RZKEY_L,
            (int)Keyboard.RZKEY.RZKEY_OEM_10, // punto . o : 
            (int)Keyboard.RZKEY.RZKEY_F8,
            (int)Keyboard.RZKEY.RZKEY_0,
            (int)Keyboard.RZKEY.RZKEY_P,
            (int)Keyboard.RZKEY.RZKEY_OEM_7, // o accentata ò o @ o ç
            (int)Keyboard.RZKEY.RZKEY_OEM_11, // simbolo meno - o _
            (int)Keyboard.RZKEY.RZKEY_FN,
            (int)Keyboard.RZKEY.RZKEY_OEM_2, // apostrofo " ' " o  punto interrogativo "?"
            (int)Keyboard.RZKEY.RZKEY_OEM_4, // e accentata è o é o [  o { 
            (int)Keyboard.RZKEY.RZKEY_OEM_8, // a accentata à o ° o #
            (int)Keyboard.RZKEY.RZKEY_RMENU,
            (int)Keyboard.RZKEY.RZKEY_F9,
            (int)Keyboard.RZKEY.RZKEY_OEM_3, // i accentata ì o esponente ^
            (int)Keyboard.RZKEY.RZKEY_OEM_5, // simbolo + o * o ] o }
            (int)Keyboard.RZKEY.RZKEY_EUR_1, // u accentata ù o §
            (int)Keyboard.RZKEY.RZKEY_RSHIFT,
            (int)Keyboard.RZKEY.RZKEY_RCTRL,
            (int)Keyboard.RZKEY.RZKEY_F10,
            (int)Keyboard.RZKEY.RZKEY_F11,
            (int)Keyboard.RZKEY.RZKEY_BACKSPACE,
            (int)Keyboard.RZKEY.RZKEY_ENTER,
            (int)Keyboard.RZKEY.RZKEY_LEFT,
            (int)Keyboard.RZKEY.RZKEY_F12,
            (int)Keyboard.RZKEY.RZKEY_DELETE,
            (int)Keyboard.RZKEY.RZKEY_UP,
            (int)Keyboard.RZKEY.RZKEY_DOWN,
            (int)Keyboard.RZKEY.RZKEY_PRINTSCREEN,
            (int)Keyboard.RZKEY.RZKEY_INSERT,
            (int)Keyboard.RZKEY.RZKEY_END,
            (int)Keyboard.RZKEY.RZKEY_RIGHT,
            (int)Keyboard.RZKEY.RZKEY_SCROLL,
            (int)Keyboard.RZKEY.RZKEY_HOME,
            (int)Keyboard.RZKEY.RZKEY_PAGEDOWN,
            (int)Keyboard.RZKEY.RZKEY_NUMPAD1,
            (int)Keyboard.RZKEY.RZKEY_NUMPAD0,
            (int)Keyboard.RZKEY.RZKEY_PAUSE,
            (int)Keyboard.RZKEY.RZKEY_PAGEUP,
            (int)Keyboard.RZKEY.RZKEY_NUMPAD4,
            (int)Keyboard.RZKEY.RZKEY_NUMPAD2,
            (int)Keyboard.RZKEY.RZKEY_NUMPAD_DECIMAL,
            (int)Keyboard.RZKEY.RZKEY_NUMLOCK,
            (int)Keyboard.RZKEY.RZKEY_NUMPAD7,
            (int)Keyboard.RZKEY.RZKEY_NUMPAD5,
            (int)Keyboard.RZKEY.RZKEY_NUMPAD3,
            (int)Keyboard.RZKEY.RZKEY_NUMPAD_ENTER,
            (int)Keyboard.RZKEY.RZKEY_NUMPAD_DIVIDE,
            (int)Keyboard.RZKEY.RZKEY_NUMPAD8,
            (int)Keyboard.RZKEY.RZKEY_NUMPAD9,
            (int)Keyboard.RZKEY.RZKEY_NUMPAD6,
            (int)Keyboard.RZKEY.RZKEY_NUMPAD_MULTIPLY,
            (int)Keyboard.RZKEY.RZKEY_NUMPAD_ADD,
            (int)Keyboard.RZKEY.RZKEY_NUMPAD_SUBTRACT,
            (int)Keyboard.RZKEY.RZKEY_MACRO1,
            (int)Keyboard.RZKEY.RZKEY_MACRO2,
            (int)Keyboard.RZKEY.RZKEY_MACRO3,
            (int)Keyboard.RZKEY.RZKEY_MACRO4,
            (int)Keyboard.RZKEY.RZKEY_MACRO5,
            (int)Keyboard.RZKEY.RZKEY_OEM_6,
            (int)Keyboard.RZKEY.RZKEY_JPN_1,
            (int)Keyboard.RZKEY.RZKEY_JPN_2,
            (int)Keyboard.RZKEY.RZKEY_JPN_3,
            (int)Keyboard.RZKEY.RZKEY_JPN_4,
            (int)Keyboard.RZKEY.RZKEY_JPN_5,
            (int)Keyboard.RZKEY.RZKEY_KOR_1,
            (int)Keyboard.RZKEY.RZKEY_KOR_2,
            (int)Keyboard.RZKEY.RZKEY_KOR_3,
            (int)Keyboard.RZKEY.RZKEY_KOR_4,
            (int)Keyboard.RZKEY.RZKEY_KOR_5,
            (int)Keyboard.RZKEY.RZKEY_KOR_6,
            (int)Keyboard.RZKEY.RZKEY_KOR_7,
            //(int)Keyboard.RZKEY.RZKEY_INVALID,

            }; //ordine accensione tastiera

            int RPM = 0;
            int frameCount = 120;
            int attempt = 0;
            bool a = true;
            bool b = true;
            bool c = true;
            bool d = true;
            bool p = true;
            bool w = true;
            bool s = false;
            bool start;
            int RPMMax = 7000;
            String MEMORY_LOCATION_PHYSICS = "Local\\acpmf_physics";
            String MEMORY_LOCATION_STATIC = "Local\\acpmf_static";
            String MEMORY_LOCATION_GRAPHICS = "Local\\acpmf_graphics";
            var data = new MyStatic();
            var phisics = new MyPhysics();
            var graphics = new myGraphics();
            //changeLowRpm();
            mapFileStatic();
            string path = "";
            excel.CreateNewFile();
           
            int LastSectorTime = 0;
            int sector2 = 0;
            int split;
            mapFilePhisics();


            void showRpm(int rpm)
            {
                Console.WriteLine("ciao" + rpm);
            }

            void mapFilePhisics()
            {

                do
                {
                    try
                    {
                        using (MemoryMappedFile mmp = MemoryMappedFile.OpenExisting(MEMORY_LOCATION_PHYSICS))
                        {
                            start = true;

                            runStream(mmp);
                            break;
                        }
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("in attesa di connettersi al gioco");
                        Thread.Sleep(1000);
                    }
                } while (true);
            }


            void mapFileStatic()
            {
                trueStart();
                do
                {
                    try
                    {
                        using (MemoryMappedFile mms = MemoryMappedFile.OpenExisting(MEMORY_LOCATION_STATIC))
                        {
                            using (var accessor = mms.CreateViewAccessor())
                            {
                                data.sharedMemoryVersion = "";
                                data.accVersion = "";
                                data.numberSessions = accessor.ReadInt32(60);
                                data.numCars = accessor.ReadInt32(64);
                                data.carModel = "";
                                data.track = "";
                                data.namePilot = "";
                                data.surnamePilot = "";
                                data.nicknamePilot = "";
                                data.sectorCount = accessor.ReadInt32(400); //360
                                data.maxTorque = 0f;
                                data.maxPower = 0f;
                                data.maxRpm = accessor.ReadInt32(412);
                                data.maxFuel = accessor.ReadSingle(416);
                                data.suspensionMaxTravel = accessor.ReadSingle(420);// [4]...//424,428,432
                                data.tyreRadius = accessor.ReadSingle(436); //[4]... //440,444,448
                                data.maxTurboBoost = accessor.ReadSingle(452);
                                data.deprecated1 = accessor.ReadSingle(456);
                                data.deprecated2 = accessor.ReadSingle(460);
                                data.penaltiesEnabled = accessor.ReadInt32(464);
                                data.aidFuelrate = accessor.ReadSingle(468);
                                data.aidTyreRate = accessor.ReadSingle(472);
                                data.aidMechanicalDamage = accessor.ReadSingle(476);
                                data.AllowTyreBlankets = accessor.ReadSingle(480);//??
                                data.aidStability = accessor.ReadSingle(484);
                                data.aidAutoclutch = accessor.ReadInt32(488);
                                data.aidAutoBlip = accessor.ReadInt32(492);
                                data.hasDRS = accessor.ReadInt32(496);//Not used in ACC
                                data.hasERS = accessor.ReadInt32(500); //Not used in ACC
                                data.hasKERS = accessor.ReadInt32(504);//Not used in ACC
                                data.kersMaxJ = accessor.ReadSingle(508); //Not used in ACC
                                data.engineBrakeSettingsCount = accessor.ReadInt32(512);//Not used in ACC
                                data.ersPowerControllerCount = accessor.ReadInt32(516);//Not used in ACC
                                data.trackSplineLength = accessor.ReadInt32(520);//Not used in ACC
                                data.trackConfiguration = "";//Not used in ACC[524]
                                data.ersMaxJ = accessor.ReadInt32(528);//Not used in ACC
                                data.isTimedRace = accessor.ReadInt32(532);//Not used in ACC
                                data.hasExtraLap = accessor.ReadInt32(536);//Not used in ACC
                                data.carSkin = "";//[33]Not used in ACC [540]
                                data.reversedGridPositions = accessor.ReadInt32(570);//Not used in ACC
                                data.PitWindowStart = accessor.ReadInt32(574);//Pit window opening time
                                data.PitWindowEnd = accessor.ReadInt32(578);//Pit windows closing time
                                data.isOnline = accessor.ReadInt32(582);//If is a multiplayer session
                                data.dryTyresName = "";//[33]Name of the dry tyres
                                data.wetTyresName = "";//[33]Name of the wet tyres


                                // Read the data from the accessor
                                //accessor.Read(0, out data);
                                var sharedMemoryVersion = new char[15];
                                var accVersion = new char[15];
                                var carModel = new char[33];
                                var track = new char[33];
                                var namePilot = new char[33];
                                var surnamePilot = new char[33];
                                var nicknamePilot = new char[33];
                                var dryTyresName = new char[33];
                                var wetTyresName = new char[33];
                                var maxTorque = accessor.ReadSingle(197);
                                var maxPower = accessor.ReadSingle(198);
                                var maxRpm = accessor.ReadInt32(199);
                                var maxFuel = accessor.ReadSingle(200);


                                accessor.ReadArray(0, sharedMemoryVersion, 0, 15);
                                accessor.ReadArray(30, accVersion, 0, 15);
                                accessor.ReadArray(68, carModel, 0, 33);
                                accessor.ReadArray(124, track, 0, 33);
                                accessor.ReadArray(156, namePilot, 0, 33);
                                accessor.ReadArray(240, surnamePilot, 0, 33);
                                accessor.ReadArray(296, nicknamePilot, 0, 33);
                                accessor.ReadArray(584, dryTyresName, 0, 33);
                                accessor.ReadArray(614, wetTyresName, 0, 33);

                                data.sharedMemoryVersion = new string(sharedMemoryVersion);
                                data.accVersion = new string(accVersion);
                                data.carModel = new string(carModel);
                                data.track = new string(track);
                                data.namePilot = new string(namePilot);
                                data.surnamePilot = new string(surnamePilot);
                                data.nicknamePilot = new string(nicknamePilot);
                                data.dryTyresName = new string(dryTyresName);
                                data.wetTyresName = new string(wetTyresName);
                                //data.char5 = new string(char1);



                                //accessor.Read(0, out data);
                                // Write the data to the accessor
                                //accessor.Write(0, ref data);
                                Console.WriteLine("Memory Version: " + data.sharedMemoryVersion);
                                Console.WriteLine("ACC Version: " + data.accVersion);
                                Console.WriteLine("Numero Sessione: " + data.numberSessions);
                                Console.WriteLine("Numero di auto in pista: " + data.numCars);
                                Console.WriteLine("Auto: " + data.carModel);
                                Console.WriteLine("Tracciato: " + data.track);
                                Console.WriteLine("Nome Pilota: " + data.namePilot);
                                Console.WriteLine("Cognome Pilota: " + data.surnamePilot);
                                Console.WriteLine("NikcName Pilota: " + data.nicknamePilot);
                                Console.WriteLine("Numero di settori: " + data.sectorCount);
                                Console.WriteLine("Massima Coppia: " + data.maxTorque);
                                Console.WriteLine("Massima Potenza: " + data.maxPower);
                                Console.WriteLine("maxRpm: " + data.maxRpm);
                                Console.WriteLine("Capacità Massima Serbatoio: " + data.maxFuel);
                                Console.WriteLine("Travel " + data.suspensionMaxTravel);
                                Console.WriteLine("Raggio Gomme: " + data.tyreRadius);
                                Console.WriteLine("Pressione Massima Turbo: " + data.maxTurboBoost);
                                Console.WriteLine("Penalità abilitate: " + data.penaltiesEnabled);
                                Console.WriteLine("Consumo Carburante: " + data.aidFuelrate);
                                Console.WriteLine("Consumo Gomme: " + data.aidTyreRate);
                                Console.WriteLine("Danno Meccanico: " + data.aidMechanicalDamage);
                                Console.WriteLine("TermoCoperte: " + data.AllowTyreBlankets);
                                Console.WriteLine("Controllo Stabilità: " + data.aidStability);
                                Console.WriteLine("Frizione Automatica: " + data.aidAutoclutch);
                                Console.WriteLine("Punta Tacco Automatico: " + data.aidAutoBlip);
                                Console.WriteLine("Pit Window Open: " + data.PitWindowStart);
                                Console.WriteLine("Pit Window Closed: " + data.PitWindowEnd);
                                Console.WriteLine("Sessione Online: " + data.isOnline);
                                Console.WriteLine("NomeGomme Asciutto: " + data.dryTyresName);
                                Console.WriteLine("NomeGomme Bagnato: " + data.wetTyresName);
                                break;
                            }
                        }
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("in attesa di leggere le statistiche del gioco");
                        Thread.Sleep(10000);
                    }
                } while (true);
            }

            void runStream(MemoryMappedFile aMemoryMappedFile)
            {
                using (MemoryMappedViewStream myStream = aMemoryMappedFile.CreateViewStream())
                {
                    BinaryReader myReader = new BinaryReader(myStream);

                    int mySleepMillis = 17;


                    while (true)
                    {
                        using (var accessor = aMemoryMappedFile.CreateViewAccessor())
                        {

                            accessor.Read(0, out phisics);
                            //Console.WriteLine(phisics.rpm);
                        }
                        using (MemoryMappedFile mmg = MemoryMappedFile.OpenExisting(MEMORY_LOCATION_GRAPHICS))
                        {
                            using (var accessor2 = mmg.CreateViewAccessor())
                            {
                                graphics.PacketId = accessor2.ReadInt32(0);
                                graphics.GameState = (GameStates)accessor2.ReadChar(4);
                                graphics.Session = (SessionTypes)accessor2.ReadChar(8);
                                graphics.CompletedLaps = accessor2.ReadInt32(132);
                                graphics.Position = accessor2.ReadInt32(136);
                                graphics.CurrentTimeMilliSeconds = accessor2.ReadInt32(140);
                                graphics.LastTimeMilliSeconds = accessor2.ReadInt32(144);
                                graphics.BestTimeMilliSeconds = accessor2.ReadInt32(148);
                                graphics.TimeLeft = accessor2.ReadSingle(152);
                                graphics.DistanceTravelled = accessor2.ReadSingle(156);
                                graphics.IsInPit = accessor2.ReadInt32(160);
                                graphics.CurrentSector = accessor2.ReadInt32(164);
                                graphics.LastSectorTimeMilliSeconds = accessor2.ReadInt32(168);
                                graphics.NumberOfCompletedLaps = accessor2.ReadInt32(172);
                                graphics.ReplayTimeMultiplier = accessor2.ReadSingle(244);
                                graphics.NormalizedCarPosition = accessor2.ReadSingle(248);
                                graphics.ActiveCars = accessor2.ReadInt32(252);
                                ////graphics.CarCoordinatesX = accessor2.ReadSingle(256);
                                ////graphics.CarCoordinatesY = accessor2.ReadSingle(260);
                                ////graphics.CarCoordinatesY = accessor2.ReadSingle(264);
                                graphics.CarId = accessor2.ReadInt32(1216);
                                graphics.PenaltyTime = accessor2.ReadSingle(1220);
                                graphics.Flag = (FlagTypes)accessor2.ReadChar(1224);
                                graphics.Penalty = (PenaltyTypes)accessor2.ReadChar(1228);
                                graphics.IdealLineOn = accessor2.ReadInt32(1232);
                                graphics.IsInPitLane = accessor2.ReadInt32(1236);
                                graphics.SurfaceGrip = accessor2.ReadSingle(1240);
                                graphics.MandatoryPitDone = accessor2.ReadInt32(1244);
                                graphics.WindSpeed = accessor2.ReadSingle(1248);
                                graphics.WindDirection = accessor2.ReadSingle(1252);
                                graphics.IsSetupMenuVisible = accessor2.ReadInt32(1256);
                                graphics.MainDisplayIndex = accessor2.ReadInt32(1260);
                                graphics.SecondaryDisplayIndex = accessor2.ReadInt32(1264);
                                graphics.TC = accessor2.ReadInt32(1268);
                                graphics.TCUT = accessor2.ReadInt32(1272);
                                graphics.EngineMap = accessor2.ReadInt32(1276);
                                graphics.ABS = accessor2.ReadInt32(1280);
                                graphics.FuelXLap = accessor2.ReadSingle(1284);
                                graphics.RainLights = accessor2.ReadInt32(1288);
                                graphics.FlashingLights = accessor2.ReadInt32(1292);
                                graphics.LightsStage = accessor2.ReadInt32(1296);
                                graphics.ExhaustTemperature = accessor2.ReadSingle(1300);
                                graphics.WiperLV = accessor2.ReadInt32(1304);
                                graphics.DriverStingTotalTimeLeft = accessor2.ReadInt32(1308);
                                graphics.DriverStingTimeLeft = accessor2.ReadInt32(1312);
                                graphics.RainTyres = accessor2.ReadInt32(1316);
                                graphics.SessionIndex = accessor2.ReadInt32(1320);
                                graphics.UsedFuel = accessor2.ReadSingle(1324);
                                graphics.DeltaLapTimeInMilliSeconds = accessor2.ReadInt32(1358);
                                graphics.EstimatedLapTimeInMilliSeconds = accessor2.ReadInt32(1392);
                                graphics.IsDeltaPositive = accessor2.ReadInt32(1400);
                                graphics.Isplit = accessor2.ReadInt32(1404);
                                graphics.IsValidLap = accessor2.ReadInt32(1408);
                                graphics.FuelEstimatedLaps = accessor2.ReadSingle(1412);
                                graphics.MissingMandatoryPits = accessor2.ReadInt32(1484);
                                graphics.Clock = accessor2.ReadSingle(1488);
                                graphics.DirectionLightsLeft = accessor2.ReadInt32(1492);
                                graphics.DirectionLightsRight = accessor2.ReadInt32(1496);
                                graphics.GlobalYellow = accessor2.ReadInt32(1500);
                                graphics.GlobalYellow1 = accessor2.ReadInt32(1504);
                                graphics.GlobalYellow2 = accessor2.ReadInt32(1508);
                                graphics.GlobalYellow3 = accessor2.ReadInt32(1512);
                                graphics.GlobalWhite = accessor2.ReadInt32(1516);
                                graphics.GlobalGreen = accessor2.ReadInt32(1520);
                                graphics.GlobalChequered = accessor2.ReadInt32(1524);
                                graphics.GlobalRed = accessor2.ReadInt32(1528);
                                graphics.mfdTyreSet = accessor2.ReadInt32(1532);
                                graphics.mfdFuelAdd = accessor2.ReadSingle(1536);
                                graphics.mfdTyrePressureLF = accessor2.ReadSingle(1540);
                                graphics.mfdTyrePressureRF = accessor2.ReadSingle(1544);
                                graphics.mfdTyrePressureLR = accessor2.ReadSingle(1548);
                                graphics.mfdTyrePressureRR = accessor2.ReadSingle(1552);
                                graphics.GripStatus = (GripStatus)accessor2.ReadChar(1556);
                                graphics.RainIntensity = (RainIntensity)accessor2.ReadChar(1560);
                                graphics.RainIntensity10 = (RainIntensity)accessor2.ReadChar(1564);
                                graphics.RainIntensity30 = (RainIntensity)accessor2.ReadChar(1568);
                                graphics.CurrentTyreSet = accessor2.ReadInt32(1572);
                                graphics.StrategyTyreSet = accessor2.ReadInt32(1576);
                                graphics.GapAhead = accessor2.ReadInt32(1580);
                                graphics.GapBehind = accessor2.ReadInt32(1584);

                                var CurrentTime = new char[15];
                                var LastTime = new char[15];
                                var BestTime = new char[15];
                                var Split = new char[15];
                                var TyreCompound = new char[33];
                                var carCoordinatesReadX = new float[3];
                                var carCoordinatesReadY = new float[3];
                                var carCoordinatesReadZ = new float[3];
                                var CarIds = new int[60];
                                var DeltaLapTime = new char[15];
                                var EstimatedLapTime = new char[15];
                                var TrackStatus = new char[33];

                                accessor2.ReadArray(12, CurrentTime, 0, 15);
                                accessor2.ReadArray(42, LastTime, 0, 15);
                                accessor2.ReadArray(72, BestTime, 0, 15);
                                accessor2.ReadArray(102, Split, 0, 15);
                                accessor2.ReadArray(176, TyreCompound, 0, 33);
                                accessor2.ReadArray(1328, DeltaLapTime, 0, 15);
                                accessor2.ReadArray(1362, EstimatedLapTime, 0, 15);
                                accessor2.ReadArray(1416, TrackStatus, 0, 33);

                                //accessor2.ReadArray(256, carCoordinatesReadX, 0, 3);
                                //accessor2.ReadArray(260, carCoordinatesReadY, 0, 3);
                                //accessor2.ReadArray(264, carCoordinatesReadZ, 0, 3);
                                //accessor2.ReadArray(976, CarIds, 0, 60);

                                graphics.CurrentTime = new string(CurrentTime);
                                graphics.LastTime = new string(LastTime);
                                graphics.BestTime = new string(BestTime);
                                graphics.Split = new string(Split);
                                graphics.TyreCompound = new string(TyreCompound);
                                graphics.DeltaLapTime = new string(DeltaLapTime);
                                graphics.EstimatedLapTime = new string(EstimatedLapTime);
                                //graphics.CarCoordinatesX = carCoordinatesReadX;
                                //graphics.CarCoordinatesY = carCoordinatesReadY;
                                //graphics.CarCoordinatesZ = carCoordinatesReadZ;
                                //graphics.CarIds = CarIds;


                                //foreach (var item in (graphics.CarCoordinatesY))
                                //{
                                //    Console.Write(item);
                                //}
                                //Console.WriteLine(" ");
                                //foreach (var item in (graphics.CarIds))
                                //{
                                //    Console.Write(item);
                                //}

                                //for (int i = 252; i < 1500; i=i+4)
                                //{
                                //    Console.Write("l'id è: " + i + "il valore: ");
                                //    Console.WriteLine(accessor2.ReadInt32(i));

                                //}
                                //Console.WriteLine(graphics.LastTimeMilliSeconds);
                                //Console.WriteLine(graphics.GameState);
                            }
                        }

                        singleReadAndWrite(); 
                        Thread.Sleep(mySleepMillis);
                    }
                }
            }
            void singleReadAndWrite()
            {

                while (start == true)
                {
                    try
                    {
                        string auto = Regex.Replace(data.carModel, "[^a-zA-Z0-9_]", "");
                        switch (auto)
                        {
                            case "amr_v12_vantage_gt3":
                                RPMMax = 7600;
                                break;
                            case "amr_v8_vantage_gt3":
                                RPMMax = 7000;
                                break;
                            case "audi_r8_lms":
                                RPMMax = 7900;
                                break;
                            case "audi_r8_lms_evo":
                                RPMMax = 7900;
                                break;
                            case "audi_r8_lms_evo_ii":
                                RPMMax = 7900;
                                break;
                            case "bentley_continental_gt3_2016":
                                RPMMax = 7000;
                                break;
                            case "bentley_continental_gt3_2018":
                                RPMMax = 7250;
                                break;
                            case "bmw_m4_gt3":
                                RPMMax = 6750;
                                break;
                            case "bmw_m6_gt3":
                                RPMMax = 6280;
                                break;
                            case "jaguar_g3":
                                RPMMax = 8100;
                                break;
                            case "ferrari_296_gt3":
                                RPMMax = 7200;
                                break;
                            case "ferrari_488_gt3":
                                RPMMax = 7100;
                                break;
                            case "ferrari_488_gt3_evo":
                                RPMMax = 7100;
                                break;
                            case "honda_nsx_gt3":
                                RPMMax = 7100;
                                break;
                            case "honda_nsx_gt3_evo":
                                RPMMax = 7000;
                                break;
                            case "lamborghini_huracan_gt3":
                                RPMMax = 7900;
                                break;
                            case "lamborghini_huracan_gt3_evo":
                                RPMMax = 7900;
                                break;
                            case "lamborghini_huracan_gt3_evo2":
                                RPMMax = 7900;
                                break;
                            case "lexus_rc_f_gt3":
                                RPMMax = 7250;
                                break;
                            case "mclaren_650s_gt3":
                                RPMMax = 7000;
                                break;
                            case "mclaren_720s_gt3":
                                RPMMax = 7400;
                                break;
                            case "mclaren_720s_gt3_evo":
                                RPMMax = 7300;
                                break;
                            case "mercedes_amg_gt3":
                                RPMMax = 7100;
                                break;
                            case "mercedes_amg_gt3_evo":
                                RPMMax = 7100;
                                break;
                            case "nissan_gt_r_gt3_2017":
                                RPMMax = 7200;
                                break;
                            case "nissan_gt_r_gt3_2018":
                                RPMMax = 7000;
                                break;
                            case "porsche_991_gt3_r":
                                RPMMax = 9000;
                                break;
                            case "porsche_991ii_gt3_r":
                                RPMMax = 9000;
                                break;
                            case "porsche_992_gt3_r":
                                RPMMax = 9000;
                                break;
                            case "lamborghini_gallardo_rex":
                                RPMMax = 8200;
                                break;
                            case "alpine_a110_gt4":
                                RPMMax = 6300;
                                break;
                            case "amr_v8_vantage_gt4":
                                RPMMax = 6800;
                                break;
                            case "bmw_m4_gt4":
                                RPMMax = 7000;
                                break;
                            case "chevrolet_camaro_gt4r":
                                RPMMax = 7000;
                                break;
                            case "ginetta_g55_gt4":
                                RPMMax = 7000;
                                break;
                            case "ktm_xbow_gt4":
                                RPMMax = 6300;
                                break;
                            case "maserati_mc_gt4":
                                RPMMax = 6800;
                                break;
                            case "mclaren_570s_gt4":
                                RPMMax = 7400;
                                break;
                            case "mercedes_amg_gt4":
                                RPMMax = 6800;
                                break;
                            case "porsche_718_cayman_gt4_mr":
                                RPMMax = 7600;
                                break;
                            case "porsche_991ii_gt3_cup":
                                RPMMax = 8300;
                                break;
                            case "porsche_992_gt3_cup":
                                RPMMax = 8300;
                                break;
                            case "lamborghini_huracan_st":
                                RPMMax = 7900;
                                break;
                            case "lamborghini_huracan_st_evo2":
                                RPMMax = 7900;
                                break;
                            case "ferrari_488_challenge_evo":
                                RPMMax = 7100;
                                break;
                            case "bmw_m2_cs_racing":
                                RPMMax = 7000;
                                break;
                            default:
                                Console.WriteLine("non trovo gli RPMMax, contattare l'amministratore del programma");
                                break;

                        }
                        //Console.WriteLine(start);
                        RPM = 0;
                        //RPM = int.Parse(radiantsminut);
                        RPM = phisics.rpm;
                        Console.WriteLine("L'auto è: " + auto + " e il limitatore è a: " + RPMMax + " rpm");
                        Console.WriteLine("Connesso e in azione");
                        s = true;
                        falseStart();

                        //Console.WriteLine(start);

                    }
                    catch (Exception)
                    {
                        if (attempt > 10)
                        {
                            Console.WriteLine("riavvio");
                            attempt = 0;
                            trueStart();
                            mapFileStatic();
                            mapFilePhisics();
                        }
                        RPM = 0;
                        RPM = phisics.rpm;
                        Console.WriteLine("attesa avvio motore");
                        Thread.Sleep(3000);
                        trueStart();
                        attempt++;

                        Console.WriteLine("ho effettuato " + attempt + " tentativi di connessione al gioco.");
                    }
                }
                RPM = phisics.rpm;
                //Console.WriteLine(phisics.tyreTempFR);

                //string path="";


                split = graphics.LastSectorTimeMilliSeconds;
                //Console.WriteLine(split);

                if ((graphics.GameState) != 0 && graphics.CurrentSector != 0 && split > LastSectorTime)
                {
                    Console.WriteLine($"Giro: {graphics.CompletedLaps + 1} Settore: {graphics.CurrentSector}   {graphics.LastSectorTimeMilliSeconds}");

                    excel.WriteToCell(graphics.CompletedLaps, (graphics.CurrentSector), ((split - LastSectorTime)).ToString());
                    //Console.WriteLine("settore salvato in excel");
                    LastSectorTime = split;
                    if (graphics.CurrentSector == 2)
                    {
                        sector2 = split;
                    }


                }
                if ((graphics.GameState) != 0 && (graphics.CurrentSector) == 0 && (graphics.CompletedLaps) > 0)
                {
                    excel.WriteToCell((graphics.CompletedLaps - 1), 0, "Lap: " + (graphics.CompletedLaps).ToString());
                    excel.WriteToCell((graphics.CompletedLaps - 1), 3, (graphics.LastTimeMilliSeconds - sector2).ToString());
                    Console.WriteLine($"Giro: {graphics.CompletedLaps} Settore: 3   {graphics.LastTimeMilliSeconds - sector2}");
                    LastSectorTime = split;
                }

                if ((graphics.GameState) == 0 && s == true)
                {
                    DateTime dataOdierna = DateTime.Today;
                    DateTime oraCorrente = DateTime.Now;
                    string giorno = dataOdierna.ToString("dd_MM_yyyy");
                    string ora = oraCorrente.ToString("HH_mm");
                    string tracciato = Regex.Replace(data.track, "[^a-zA-Z0-9_]", "");
                    path = $"{giorno}_{ora}_{graphics.Session}_{tracciato}_{data.carModel}";
                    excel.SaveAs(path);
                    excel.Close();
                    s = false;
                }

               

                if (d == true && RPM >= RPMMax && ChromaON)
                {
                    a = true;
                    b = true;
                    c = true;
                    d = false;
                    changeHighRpm();
                    //Thread.Sleep(1);

                }

                if (c == true && RPM < RPMMax && RPM > (RPMMax - 400) && ChromaON)
                {

                    a = true;
                    b = true;
                    c = false;
                    d = true;
                    changeOrangeRpm();
                    //Thread.Sleep(1);

                }
                if (b == true && RPM < (RPMMax - 400) && RPM > (RPMMax - 4000) && ChromaON)
                {
                    a = true;
                    b = false;
                    c = true;
                    d = true;
                    changeGreenRpm();
                    //Thread.Sleep(1);

                }
                if (a == true && RPM < RPMMax - 4000 && ChromaON)
                {
                    a = false;
                    b = true;
                    c = true;
                    d = true;
                    changeLowRpm();
                }
                //showRpm(RPM);


            }
            void falseStart()
            {
                start = false;
            }
            void trueStart()
            {
                start = true;
            }
            void changeHighRpm()
            {
                string baseLayer = "Animations/Blank_Keyboard.chroma";
                // close the blank animation if it's already loaded, discarding any changes
                ChromaAnimationAPI.CloseAnimationName(baseLayer);
                // open the blank animation, passing a reference to the base animation when loading has completed
                ChromaAnimationAPI.GetAnimation(baseLayer);
                // the length of the animation
                frameCount = 6; //scrivere framcount al posto del 6
                // set all frames to white, with all frames set to 30FPS
                ChromaAnimationAPI.MakeBlankFramesRGBName(baseLayer, frameCount, 0.016f, 255, 0, 0);
                // fade the start of the animation starting at frame zero to 40
                ChromaAnimationAPI.FadeStartFramesName(baseLayer, 5);
                // play the animation on the dynamic canvas
                ChromaAnimationAPI.PlayAnimationName(baseLayer, true);

                //void ShowEffect1ChromaLink()
                //{
                string baseLayerChromaLink = "Animations/Blank_ChromaLink.chroma";
                ChromaAnimationAPI.CloseAnimationName(baseLayerChromaLink);
                // open the blank animation, passing a reference to the base animation when loading has completed
                ChromaAnimationAPI.GetAnimation(baseLayerChromaLink);
                // set all frames to white, with all frames set to 30FPS
                ChromaAnimationAPI.MakeBlankFramesRGBName(baseLayerChromaLink, 6, 0.016f, 255, 0, 0);
                // fade the start of the animation starting at frame zero to 40
                ChromaAnimationAPI.FadeStartFramesName(baseLayerChromaLink, 5);
                // play the animation on the dynamic canvas
                ChromaAnimationAPI.PlayAnimationName(baseLayerChromaLink, true);
                //}
            }
            void changeOrangeRpm()
            {
                //blocca il rosso su crhomalink
                string baseLayerChromaLink = "Animations/Blank_ChromaLink.chroma";
                ChromaAnimationAPI.CloseAnimationName(baseLayerChromaLink);
                ChromaAnimationAPI.GetAnimation(baseLayerChromaLink);
                // set all frames to Orange, with all frames
                ChromaAnimationAPI.MakeBlankFramesRGBName(baseLayerChromaLink, frameCount, 0f, 255, 60, 0);
                // play the animation on the dynamic canvas
                ChromaAnimationAPI.PlayAnimationName(baseLayerChromaLink, true);

                string baseLayer = "Animations/Blank_Keyboard.chroma";
                ChromaAnimationAPI.CloseAnimationName(baseLayer);
                ChromaAnimationAPI.GetAnimation(baseLayer);
                ChromaAnimationAPI.SetKeysColorAllFramesRGBName(baseLayer, keys, keys.Length, 255, 60, 0);
                ChromaAnimationAPI.SetChromaCustomColorAllFramesName(baseLayer);
                ChromaAnimationAPI.PlayAnimationName(baseLayer, true);

            }
            void changeGreenRpm()
            {
                //blocca il rosso su chromalink
                string baseLayerChromaLink = "Animations/Blank_ChromaLink.chroma";
                ChromaAnimationAPI.CloseAnimationName(baseLayerChromaLink);
                ChromaAnimationAPI.GetAnimation(baseLayerChromaLink);
                // set all frames to green, with all frames
                ChromaAnimationAPI.MakeBlankFramesRGBName(baseLayerChromaLink, frameCount, 0f, 0, 125, 0);
                // play the animation on the dynamic canvas
                ChromaAnimationAPI.PlayAnimationName(baseLayerChromaLink, true);

                string baseLayer = "Animations/Blank_Keyboard.chroma";
                ChromaAnimationAPI.CloseAnimationName(baseLayer);
                ChromaAnimationAPI.GetAnimation(baseLayer);
                ChromaAnimationAPI.SetKeysColorAllFramesRGBName(baseLayer, keys, keys.Length, 0, 125, 0);
                ChromaAnimationAPI.SetChromaCustomColorAllFramesName(baseLayer);
                ChromaAnimationAPI.PlayAnimationName(baseLayer, true);
            }
            void changeLowRpm()
            {

                //blocca il rosso su chromalink
                string baseLayerChromaLink = "Animations/Blank_ChromaLink.chroma";
                ChromaAnimationAPI.CloseAnimationName(baseLayerChromaLink);
                ChromaAnimationAPI.GetAnimation(baseLayerChromaLink);
                // set all frames to blu, with all frames
                ChromaAnimationAPI.MakeBlankFramesRGBName(baseLayerChromaLink, frameCount, 0f, 0, 0, 125);
                // play the animation on the dynamic canvas
                ChromaAnimationAPI.PlayAnimationName(baseLayerChromaLink, true);

                string baseLayer = "Animations/Blank_Keyboard.chroma";
                ChromaAnimationAPI.CloseAnimationName(baseLayer);
                ChromaAnimationAPI.GetAnimation(baseLayer);
                ChromaAnimationAPI.SetKeysColorAllFramesRGBName(baseLayer, keys, keys.Length, 1, 1, 125);
                ChromaAnimationAPI.SetChromaCustomColorAllFramesName(baseLayer);
                ChromaAnimationAPI.PlayAnimationName(baseLayer, true);

            }

            /////////////////
        }
        public void OnApplicationQuit()
        {
            if (_mResult == RazerErrors.RZRESULT_SUCCESS)
            {
                if (ChromaAnimationAPI.IsInitialized())
                {
                    ChromaAnimationAPI.StopAll();
                    ChromaAnimationAPI.CloseAll();
                    int result = ChromaAnimationAPI.Uninit();
                    ChromaAnimationAPI.UninitAPI();
                    if (result != RazerErrors.RZRESULT_SUCCESS)
                    {
                        Console.Error.WriteLine("Failed to uninitialize Chroma!");
                    }
                }
            }
        }

        public string GetEffectName(int index, byte platform)
        {
            switch (index)
            {
                default:
                    return string.Format("Effect{0}", index);
            }
        }
        public void Chroma_APPINFO()
        {
            ChromaSDK.APPINFOTYPE appInfo = new APPINFOTYPE();
            appInfo.Title = "Razer Chroma test";
            appInfo.Description = "A sample application using Razer Chroma SDK";

            appInfo.Author_Name = "Razer";
            appInfo.Author_Contact = "https://developer.razer.com/chroma";

            //appInfo.SupportedDevice = 
            //    0x01 | // Keyboards
            //    0x02 | // Mice
            //    0x04 | // Headset
            //    0x08 | // Mousepads
            //    0x10 | // Keypads
            //    0x20   // ChromaLink devices
            appInfo.SupportedDevice = (0x01 | 0x02 | 0x04 | 0x08 | 0x10 | 0x20);
            //    0x01 | // Utility. (To specifiy this is an utility application)
            //    0x02   // Game. (To specifiy this is a game);
            appInfo.Category = 1;
            _mResult = ChromaAnimationAPI.InitSDK(ref appInfo);
            switch (_mResult)
            {
                case RazerErrors.RZRESULT_DLL_NOT_FOUND:
                    Console.Error.WriteLine("Chroma DLL is not found! {0}", RazerErrors.GetResultString(_mResult));
                    break;
                case RazerErrors.RZRESULT_DLL_INVALID_SIGNATURE:
                    Console.Error.WriteLine("Chroma DLL has an invalid signature! {0}", RazerErrors.GetResultString(_mResult));
                    break;
                case RazerErrors.RZRESULT_SUCCESS:
                    break;
                default:
                    Console.Error.WriteLine("Failed to initialize Chroma! {0}", RazerErrors.GetResultString(_mResult));
                    break;
            }
        }

       

        #region Autogenerated



  

       

         

        


        


        void ShowEffect1Headset()
        {
            string baseLayer = "Animations/Blank_Headset.chroma";
            ChromaAnimationAPI.CloseAnimationName(baseLayer);
            ChromaAnimationAPI.GetAnimation(baseLayer);
            int frameCount = 50;
            ChromaAnimationAPI.MakeBlankFramesRGBName(baseLayer, frameCount, 0.1f, 255, 255, 255);
            ChromaAnimationAPI.FadeStartFramesName(baseLayer, frameCount / 2);
            ChromaAnimationAPI.FadeEndFramesName(baseLayer, frameCount / 2);
            int color1 = ChromaAnimationAPI.GetRGB(0, 64, 0);
            int color2 = ChromaAnimationAPI.GetRGB(0, 255, 0);
            ChromaAnimationAPI.MultiplyTargetColorLerpAllFramesName(baseLayer, color1, color2);
            ChromaAnimationAPI.OverrideFrameDurationName(baseLayer, 0.033f);
            ChromaAnimationAPI.PlayAnimationName(baseLayer, true);
        }
        void ShowEffect1Mousepad()
        {
            string baseLayer = "Animations/Blank_Mousepad.chroma";
            ChromaAnimationAPI.CloseAnimationName(baseLayer);
            ChromaAnimationAPI.GetAnimation(baseLayer);
            int frameCount = 50;
            ChromaAnimationAPI.MakeBlankFramesRGBName(baseLayer, frameCount, 0.1f, 255, 255, 255);
            ChromaAnimationAPI.FadeStartFramesName(baseLayer, frameCount / 2);
            ChromaAnimationAPI.FadeEndFramesName(baseLayer, frameCount / 2);
            int color1 = ChromaAnimationAPI.GetRGB(0, 64, 0);
            int color2 = ChromaAnimationAPI.GetRGB(0, 255, 0);
            ChromaAnimationAPI.MultiplyTargetColorLerpAllFramesName(baseLayer, color1, color2);
            ChromaAnimationAPI.OverrideFrameDurationName(baseLayer, 0.033f);
            ChromaAnimationAPI.PlayAnimationName(baseLayer, true);
        }
        void ShowEffect1Mouse()
        {
            string baseLayer = "Animations/Blank_Mouse.chroma";
            ChromaAnimationAPI.CloseAnimationName(baseLayer);
            ChromaAnimationAPI.GetAnimation(baseLayer);
            int frameCount = 50;
            ChromaAnimationAPI.MakeBlankFramesRGBName(baseLayer, frameCount, 0.1f, 255, 255, 255);
            ChromaAnimationAPI.FadeStartFramesName(baseLayer, frameCount / 2);
            ChromaAnimationAPI.FadeEndFramesName(baseLayer, frameCount / 2);
            int color1 = ChromaAnimationAPI.GetRGB(0, 64, 0);
            int color2 = ChromaAnimationAPI.GetRGB(0, 255, 0);
            ChromaAnimationAPI.MultiplyTargetColorLerpAllFramesName(baseLayer, color1, color2);
            ChromaAnimationAPI.OverrideFrameDurationName(baseLayer, 0.033f);
            ChromaAnimationAPI.PlayAnimationName(baseLayer, true);
        }
        void ShowEffect1Keypad()
        {
            string baseLayer = "Animations/Blank_Keypad.chroma";
            ChromaAnimationAPI.CloseAnimationName(baseLayer);
            ChromaAnimationAPI.GetAnimation(baseLayer);
            int frameCount = 50;
            ChromaAnimationAPI.MakeBlankFramesRGBName(baseLayer, frameCount, 0.1f, 255, 255, 255);
            ChromaAnimationAPI.FadeStartFramesName(baseLayer, frameCount / 2);
            ChromaAnimationAPI.FadeEndFramesName(baseLayer, frameCount / 2);
            int color1 = ChromaAnimationAPI.GetRGB(0, 64, 0);
            int color2 = ChromaAnimationAPI.GetRGB(0, 255, 0);
            ChromaAnimationAPI.MultiplyTargetColorLerpAllFramesName(baseLayer, color1, color2);
            ChromaAnimationAPI.OverrideFrameDurationName(baseLayer, 0.033f);
            ChromaAnimationAPI.PlayAnimationName(baseLayer, true);
        }

        void NewExcel(string path)
        {
            Excel newFile = new Excel();
            newFile.CreateNewFile();
            //newFile.CreateNewsheet(); //aggiunge una seconda tabella al nuvovo file
            newFile.SaveAs(path);
            newFile.Close();
        }
        public void CurrentDomain_ProcessExit()
        {
            excel.SaveAs("recovery.xlsx");
            //excel.Save();
            //excel.Close();
        }

        #endregion
        public void ChromaOnTrue()
        {
            ChromaON = true;
        }
        public int GetInitResult()
        {
            return _mResult;
        }
    }

    

    
}
