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

namespace CSharp_SampleApp
{
    public class SampleApp
    {
        private int _mResult = 0;
        private Random _mRandom = new Random();

        string _mShortcode = ChromaSDK.Stream.Default.Shortcode;
        byte _mLenShortCode = 0;

        string _mStreamId = ChromaSDK.Stream.Default.StreamId;
        byte _mLenStreamId = 0;

        string _mStreamKey = ChromaSDK.Stream.Default.StreamKey;
        byte _mLenStreamKey = 0;

        string _mStreamFocus = ChromaSDK.Stream.Default.StreamFocus;
        byte _mLenStreamFocus = 0;
        string _mStreamFocusGuid = "UnitTest-" + Guid.NewGuid();


        public int GetInitResult()
        {
            return _mResult;
        }

        public string GetShortcode()
        {
            if (_mLenShortCode == 0)
            {
                return "NOT_SET";
            }
            else
            {
                return _mShortcode;
            }
        }

        public string GetStreamId()
        {
            if (_mLenStreamId == 0)
            {
                return "NOT_SET";
            }
            else
            {
                return _mStreamId;
            }
        }

        public string GetStreamKey()
        {
            if (_mLenStreamKey == 0)
            {
                return "NOT_SET";
            }
            else
            {
                return _mStreamKey;
            }
        }

        public string GetStreamFocus()
        {
            if (_mLenStreamFocus == 0)
            {
                return "NOT_SET";
            }
            else
            {
                return _mStreamFocus;
            }
        }

        public void Start()
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

        public void ExecuteItem(int index, bool supportsStreaming, byte platform)
        {
            switch (index)
            {

                case 1:
                    ShowEffect1();
                    ShowEffect1ChromaLink();
                    ShowEffect1Headset();
                    ShowEffect1Keypad();
                    ShowEffect1Mousepad();
                    ShowEffect1Mouse();
                    
                    break;
            }
        }

        #region Autogenerated



        public void ShowEffect1() //ex 45

        {
            
            //bool ok = true;
            //while (ok) {
                //ConsoleKeyInfo keyInfo = Console.ReadKey();

                //if (keyInfo.Key == ConsoleKey.Escape) //blocca l'esecuzione
                //{
                //    break;
                //}
                
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
            //(int)Keyboard.RZKEY.RZKEY_MACRO1,
            //(int)Keyboard.RZKEY.RZKEY_MACRO2,
            //(int)Keyboard.RZKEY.RZKEY_MACRO3,
            //(int)Keyboard.RZKEY.RZKEY_MACRO4,
            //(int)Keyboard.RZKEY.RZKEY_MACRO5,
            //(int)Keyboard.RZKEY.RZKEY_OEM_6,
            //(int)Keyboard.RZKEY.RZKEY_JPN_1,
            //(int)Keyboard.RZKEY.RZKEY_JPN_2,
            //(int)Keyboard.RZKEY.RZKEY_JPN_3,
            //(int)Keyboard.RZKEY.RZKEY_JPN_4,
            //(int)Keyboard.RZKEY.RZKEY_JPN_5,
            //(int)Keyboard.RZKEY.RZKEY_KOR_1,
            //(int)Keyboard.RZKEY.RZKEY_KOR_2,
            //(int)Keyboard.RZKEY.RZKEY_KOR_3,
            //(int)Keyboard.RZKEY.RZKEY_KOR_4,
            //(int)Keyboard.RZKEY.RZKEY_KOR_5,
            //(int)Keyboard.RZKEY.RZKEY_KOR_6,
            //(int)Keyboard.RZKEY.RZKEY_KOR_7,
            //(int)Keyboard.RZKEY.RZKEY_INVALID,

            }; //ordine accensione tastiera
                int RPM=0;
                int frameCount = 120;
                int rpm = 0;
                int attempt = 0;
                bool c = true;
                bool call=false;
                bool start;
                int RPMMax=2;
                String MEMORY_LOCATION_PHYSICS = "Local\\acpmf_physics";
                String MEMORY_LOCATION_STATIC = "Local\\acpmf_static";
                var data = new MyStatic();
                changeLowRpm();
                mapFileStatic();
                mapFilePhisics();
                void changeRpm(int RPM1) {
                    rpm = RPM1;
                    
                    Console.WriteLine("ciao"+rpm);
                    
                }
                //changeRpm(0);
                void changeHighRpm()
                {
                    
                        string baseLayer = "Animations/Blank_Keyboard.chroma";
                    // close the blank animation if it's already loaded, discarding any changes
                        ChromaAnimationAPI.CloseAnimationName(baseLayer);
                        // open the blank animation, passing a reference to the base animation when loading has completed
                        ChromaAnimationAPI.GetAnimation(baseLayer);
                        // the length of the animation
                        frameCount = 6;
                        // set all frames to white, with all frames set to 30FPS
                        ChromaAnimationAPI.MakeBlankFramesRGBName(baseLayer, frameCount, 0.016f, 255, 0, 0);
                        // fade the start of the animation starting at frame zero to 40
                        ChromaAnimationAPI.FadeStartFramesName(baseLayer, 5);
                        // play the animation on the dynamic canvas
                        ChromaAnimationAPI.PlayAnimationName(baseLayer, true);


                    //animazione originale
                    // start with a blank animation
                    //string baseLayer = "Animations/Blank_ChromaLink.chroma";
                    //// close the blank animation if it's already loaded, discarding any changes
                    //ChromaAnimationAPI.CloseAnimationName(baseLayer);
                    //// open the blank animation, passing a reference to the base animation when loading has completed
                    //ChromaAnimationAPI.GetAnimation(baseLayer);
                    //// the length of the animation
                    //int frameCount = 50;
                    //// set all frames to white, with all frames set to 30FPS
                    //ChromaAnimationAPI.MakeBlankFramesRGBName(baseLayer, frameCount, 0.033f, 255, 255, 255);
                    //// fade the start of the animation starting at frame zero to 40
                    //ChromaAnimationAPI.FadeStartFramesName(baseLayer, 40);
                    //// play the animation on the dynamic canvas
                    //ChromaAnimationAPI.PlayAnimationName(baseLayer, true);


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
                    //blocca il rosso su crhomalink
                    string baseLayerChromaLink = "Animations/Blank_ChromaLink.chroma";
                    ChromaAnimationAPI.CloseAnimationName(baseLayerChromaLink);
                    ChromaAnimationAPI.GetAnimation(baseLayerChromaLink);
                    // set all frames to green, with all frames
                    ChromaAnimationAPI.MakeBlankFramesRGBName(baseLayerChromaLink, frameCount, 0f, 0, 125,0 );
                    // play the animation on the dynamic canvas
                    ChromaAnimationAPI.PlayAnimationName(baseLayerChromaLink, true);

                    string baseLayer = "Animations/Blank_Keyboard.chroma";
                    ChromaAnimationAPI.CloseAnimationName(baseLayer);
                    ChromaAnimationAPI.GetAnimation(baseLayer);
                    ChromaAnimationAPI.SetKeysColorAllFramesRGBName(baseLayer, keys, keys.Length, 0, 125,0 );
                    ChromaAnimationAPI.SetChromaCustomColorAllFramesName(baseLayer);
                    ChromaAnimationAPI.PlayAnimationName(baseLayer, true);
                }


                    void changeLowRpm()
                {
                    //blocca il rosso su crhomalink
                    string baseLayerChromaLink = "Animations/Blank_ChromaLink.chroma";
                    ChromaAnimationAPI.CloseAnimationName(baseLayerChromaLink);
                    ChromaAnimationAPI.GetAnimation(baseLayerChromaLink);
                    // set all frames to blu, with all frames
                    ChromaAnimationAPI.MakeBlankFramesRGBName(baseLayerChromaLink, frameCount, 0f, 0, 0,125);
                    // play the animation on the dynamic canvas
                    ChromaAnimationAPI.PlayAnimationName(baseLayerChromaLink, true);

                    string baseLayer = "Animations/Blank_Keyboard.chroma";
                    ChromaAnimationAPI.CloseAnimationName(baseLayer);
                    ChromaAnimationAPI.GetAnimation(baseLayer);
                    ChromaAnimationAPI.SetKeysColorAllFramesRGBName(baseLayer, keys, keys.Length, 0,0,125);
                    ChromaAnimationAPI.SetChromaCustomColorAllFramesName(baseLayer);
                    ChromaAnimationAPI.PlayAnimationName(baseLayer, true);


                    //animazione originale 45

                    //        string baseLayer = "Animations/Blank_Keyboard.chroma";
                    //        ChromaAnimationAPI.CloseAnimationName(baseLayer);
                    //        ChromaAnimationAPI.GetAnimation(baseLayer);
                    //        int frameCount = 120;
                    //        ChromaAnimationAPI.MakeBlankFramesRGBName(baseLayer, frameCount, 0.1f, 64, 64, 64);
                    //        int[] keys = {
                    //    (int)Keyboard.RZKEY.RZKEY_W,
                    //    (int)Keyboard.RZKEY.RZKEY_A,
                    //    (int)Keyboard.RZKEY.RZKEY_S,
                    //    (int)Keyboard.RZKEY.RZKEY_D,
                    //};
                    //        ChromaAnimationAPI.SetKeysColorAllFramesRGBName(baseLayer, keys, keys.Length, 255, 255, 0);
                    //        keys = new int[] {
                    //    (int)Keyboard.RZKEY.RZKEY_F1,
                    //    (int)Keyboard.RZKEY.RZKEY_F2,
                    //    (int)Keyboard.RZKEY.RZKEY_F3,
                    //    (int)Keyboard.RZKEY.RZKEY_F4,
                    //    (int)Keyboard.RZKEY.RZKEY_F5,
                    //    (int)Keyboard.RZKEY.RZKEY_F6,
                    //};
                    //        float t = 0;
                    //        float speed = 0.05f;
                    //        for (int frameId = 0; frameId < frameCount; ++frameId)
                    //        {
                    //            t += speed;
                    //            float hp = (float)Math.Abs(Math.Cos(Math.PI / 2.0f + t));
                    //            for (int i = 0; i < keys.Length; ++i)
                    //            {
                    //                float ratio = (i + 1) / keys.Length;
                    //                int color = ChromaAnimationAPI.GetRGB(0, (int)(255 * (1 - hp)), 0);
                    //                if ((i + 1) / (float)(keys.Length + 1) < hp)
                    //                {
                    //                    color = ChromaAnimationAPI.GetRGB(0, 255, 0);
                    //                }
                    //                else
                    //                {
                    //                    color = ChromaAnimationAPI.GetRGB(0, 100, 0);
                    //                }
                    //                int key = keys[i];
                    //                ChromaAnimationAPI.SetKeyColorName(baseLayer, frameId, key, color);
                    //            }
                    //        }
                    //        ChromaAnimationAPI.SetChromaCustomFlagName(baseLayer, true);
                    //        ChromaAnimationAPI.SetChromaCustomColorAllFramesName(baseLayer);
                    //        ChromaAnimationAPI.OverrideFrameDurationName(baseLayer, 0.033f);
                    //        ChromaAnimationAPI.PlayAnimationName(baseLayer, true);


                }
                void mapFilePhisics()
                {

                    do
                    {
                        try
                        {
                            using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(MEMORY_LOCATION_PHYSICS))
                            {
                            start = true;
                            runStream(mmf);
                                break;
                            }
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("in attesa di connettersi al gioco");
                            Thread.Sleep(10000);
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
                        int myPrevPacketId = 0;

                        while (true)
                        {
                            int myPacketId = myReader.ReadInt32();
                            singleReadAndWrite(myReader, myPacketId, mySleepMillis);

                            myPrevPacketId = myPacketId;
                            myStream.Position = 0;
                            Thread.Sleep(mySleepMillis);
                        }
                    }
                }
                void singleReadAndWrite(BinaryReader aReader, int aPacketId, int aSleepMillis)
                {

                    String myOutput = String.Format("{1}{2:F3}{3:F3}{4:F3}{5}rpm:{6} sterzoangle: {7:F3}  (sleep: {0})",
                        aSleepMillis, aPacketId, aReader.ReadSingle(), aReader.ReadSingle(), aReader.ReadSingle(), aReader.ReadInt32(), aReader.ReadInt32(), aReader.ReadSingle());
                //Console.WriteLine(myOutput);


                //estrapolo gli rpm
                string[] rad0 = myOutput.ToString().Split(':');

                //Console.WriteLine(rad0[1] + "rad0");

                char[] radiant = new char[] { rad0[1][0], rad0[1][1], rad0[1][2], rad0[1][3] };
                string radiantsminut = new string(radiant);
                //Console.WriteLine(radiantsminut);
                //Console.WriteLine(RPM);

                while (start == true)
                {
                        try
                        {
                        string auto = Regex.Replace(data.carModel, "[^a-zA-Z0-9_]", "");
                        switch (auto)
                        {
                            case "ferrari_488_gt3":
                                RPMMax = 7100;
                                break;
                            case "ferrari_296_gt3":
                                RPMMax = 7200;
                                break;
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
                            default:
                                Console.WriteLine("non trovo gli RPMMax, contattare l'amministratore del programma");
                                break;

                        }
                        //Console.WriteLine(start);
                        RPM = 0;
                        RPM = int.Parse(radiantsminut);
                        Console.WriteLine("l'auto è: " + auto + " e il limitatore è a: " + RPMMax + " rpm");
                        Console.WriteLine("Connesso e in azione");
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
                            Console.WriteLine("attesa avvio motore");
                            Thread.Sleep(3000);
                            trueStart();
                            attempt++;
                            Console.WriteLine("ho effettuato "+attempt+" tentativi di connessione al gioco.");
                        }
                    } 
                    if (RPM!=0)
                    {
                        
                        RPM = int.Parse(radiantsminut);
                   
                        if ( c == true && RPM >= RPMMax && call==false)
                    {

                        rpm = 7200;
                        c = false;
                        changeHighRpm();
                        ShowEffect1ChromaLink();
                        call = true;
                        //Thread.Sleep(1);

                    }
                    
                    if ( c == false && RPM < RPMMax &&RPM>(RPMMax-400) && call==true)
                        {
                        
                        rpm = RPM;
                        c = true;
                        changeOrangeRpm() ;
                        call = false;
                        //Thread.Sleep(1);

                    }
                    if (c == true && RPM<(RPMMax - 400) && RPM > (RPMMax - 4000) && call==false)
                    {

                        rpm = RPM;
                        c = false;
                        changeGreenRpm();
                        call = true;
                        //Thread.Sleep(1);

                    }
                    if (RPM < RPMMax-4000)
                    {
                        c = true;
                        changeLowRpm();
                        call = false;
                    }
                   
                    }

                }
            void falseStart()
            {
                start = false;
            }
            void trueStart() 
            {
                start = true;
            }
        }
        


        void ShowEffect1ChromaLink()
        {   string baseLayerChromaLink = "Animations/Blank_ChromaLink.chroma";
            ChromaAnimationAPI.CloseAnimationName(baseLayerChromaLink);
            // open the blank animation, passing a reference to the base animation when loading has completed
            ChromaAnimationAPI.GetAnimation(baseLayerChromaLink);
            // the length of the animation
           int frameCount = 6;
            // set all frames to white, with all frames set to 30FPS
            ChromaAnimationAPI.MakeBlankFramesRGBName(baseLayerChromaLink, frameCount, 0.016f, 255, 0, 0);
            // fade the start of the animation starting at frame zero to 40
            ChromaAnimationAPI.FadeStartFramesName(baseLayerChromaLink, 5);
            // play the animation on the dynamic canvas
            ChromaAnimationAPI.PlayAnimationName(baseLayerChromaLink, true);


            //codice originale


            //string baseLayer = "Animations/Blank_ChromaLink.chroma";
            //ChromaAnimationAPI.CloseAnimationName(baseLayer);
            //ChromaAnimationAPI.GetAnimation(baseLayer);
            //int frameCount = 50;
            //ChromaAnimationAPI.MakeBlankFramesRGBName(baseLayer, frameCount, 0.1f, 255, 255, 255);
            //ChromaAnimationAPI.FadeStartFramesName(baseLayer, frameCount / 2);
            //ChromaAnimationAPI.FadeEndFramesName(baseLayer, frameCount / 2);
            //int color1 = ChromaAnimationAPI.GetRGB(0, 64, 0);
            //int color2 = ChromaAnimationAPI.GetRGB(0, 255, 0);
            //ChromaAnimationAPI.MultiplyTargetColorLerpAllFramesName(baseLayer, color1, color2);
            //ChromaAnimationAPI.OverrideFrameDurationName(baseLayer, 0.033f);
            //ChromaAnimationAPI.PlayAnimationName(baseLayer, true);
        }
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

        
        #endregion
    }

    public struct MyStatic
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string sharedMemoryVersion;

        public string accVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public int numberSessions;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public int numCars;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string carModel;
        public string track;
        public string namePilot;
        public string surnamePilot;
        public string nicknamePilot;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public int sectorCount;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public float maxTorque;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public float maxPower;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public int maxRpm;
        public float maxFuel;
        public float suspensionMaxTravel;// [4]
        public float tyreRadius;//[4]
        public float maxTurboBoost;
        public float deprecated1;
        public float deprecated2;
        public int penaltiesEnabled;
        public float aidFuelrate;
        public float aidTyreRate;
        public float aidMechanicalDamage;
        public float AllowTyreBlankets;
        public float aidStability;
        public int aidAutoclutch;
        public int aidAutoBlip;
        public int hasDRS;//Not used in ACC
        public int hasERS; //Not used in ACC
        public int hasKERS;//Not used in ACC
        public float kersMaxJ; //Not used in ACC
        public int engineBrakeSettingsCount;//Not used in ACC
        public int ersPowerControllerCount;//Not used in ACC
        public float trackSplineLength;//Not used in ACC
        public string trackConfiguration;//Not used in ACC
        public float ersMaxJ;//Not used in ACC
        public int isTimedRace;//Not used in ACC
        public int hasExtraLap;//Not used in ACC
        public string carSkin;//[33]Not used in ACC
        public int reversedGridPositions;//Not used in ACC
        public int PitWindowStart;//Pit window opening time
        public int PitWindowEnd;//Pit windows closing time
        public int isOnline;//If is a multiplayer session
        public string dryTyresName;//[33]Name of the dry tyres
        public string wetTyresName;//[33]Name of the wet tyres

    }
}
