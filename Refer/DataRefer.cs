using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace CSharp_SampleApp.Refer
{
    public class DataRefer
    {
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
        public struct MyPhysics
        {
            public int packetId;
            public float gas;
            public float brake;
            public float fuel;
            public int gear;
            public int rpm;
            public float steerAngle;
            public float speedKmh;
            public float velocityX;//[3]
            public float velocityY;//[3]
            public float velocityZ;//[3]
            public float accGX;//[3]
            public float accGY;//[3]
            public float accGZ;//[3]
            public float wheelSlipFL;//[4]
            public float wheelSlipFR;//[4]
            public float wheelSlipRL;//[4]
            public float wheelSlipRR;//[4]
            public float wheelLoadFL;//[4]
            public float wheelLoadFR;//[4]
            public float wheelLoadRL;//[4]
            public float wheelLoadRR;//[4]
            public float wheelPressureFL;//[4]
            public float wheelPressureFR;//[4]
            public float wheelPressureRL;//[4]
            public float wheelPressureRR;//[4]
            public float wheelAngularSpeedFL;//[4]
            public float wheelAngularSpeedFR;//[4]
            public float wheelAngularSpeedRL;//[4]
            public float wheelAngularSpeedRR;//[4]
            public float TyreWearFL;// [4]
            public float TyreWearFR;// [4]
            public float TyreWearRL;// [4]
            public float TyreWearRR;// [4]
            public float tyreDirtyLevelFL;//[4]
            public float tyreDirtyLevelFR;//[4]
            public float tyreDirtyLevelRL;//[4]
            public float tyreDirtyLevelRR;//[4]
            public float tyreCoreTempFL;//[4]
            public float tyreCoreTempFR;//[4]
            public float tyreCoreTempRL;//[4]
            public float tyreCoreTempRR;//[4]
            public float camberRadFL;//[4]
            public float camberRadFR;//[4]
            public float camberRadRL;//[4]
            public float camberRadRR;//[4]
            public float suspensionTravelFL;//[4]
            public float suspensionTravelFR;//[4]
            public float suspensionTravelRL;//[4]
            public float suspensionTravelRR;//[4]
            public float drs;
            public float tc;
            public float heading;
            public float pitch;
            public float roll;
            public float cgHeight;
            public float carDamageF; //[5]
            public float carDamageRe; //[5]
            public float carDamageL; //[5]
            public float carDamageRi; //[5]
            public float carDamageC; //[5]
            public int numberOfTyresOut;
            public int pitLimiteOn;
            public float abs;
            public float kersCharge;//Not used in ACC
            public float kersInput;//Not used in ACC
            public int autoshifterOn;
            public float rideHieghtF;//[2]
            public float rideHieghtR;//[2]
            public float turboBoost;
            public float ballast;
            public float airDensity;
            public float airTemp;
            public float roadTemp;
            public float localAngularVelX;//[3]
            public float localAngularVelY;//[3]
            public float localAngularVelZ;//[3]
            public float finalFF;
            public float perfmonanceMeter;//Not used in ACC
            public int engineBrake;//Not used in ACC
            public int ersRecoveryLevel;//Not used in ACC
            public int ersPowerLevel;// Not used in ACC
            public int ersHeatCharging;//Not used in ACC
            public int ersIsCharging;//Not used in ACC
            public float kersCurrentKJ;//Not used in ACC
            public int drsAvaible;//Not used in ACC
            public int drsEnabled;//Not used in ACC
            public float brakeTempFL;//[4]
            public float brakeTempFR;//[4]
            public float brakeTempRL;//[4]
            public float brakeTempRR;//[4]
            public float clutch;
            public float TyreTempIFL;//[4]Not show in ACC
            public float TyreTempIFR;//[4]Not show in ACC
            public float TyreTempIRL;//[4]Not show in ACC
            public float TyreTempIRR;//[4]Not show in ACC
            public float TyreTempMFL;//[4]Not show in ACC
            public float TyreTempMFR;//[4]Not show in ACC
            public float TyreTempMRL;//[4]Not show in ACC
            public float TyreTempMRR;//[4]Not show in ACC
            public float TyreTempOFL;//[4]Not show in ACC
            public float TyreTempOFR;//[4]Not show in ACC
            public float TyreTempORL;//[4]Not show in ACC
            public float TyreTempORR;//[4]Not show in ACC
            public int isAiControlled;
            public float tyreContactPointFLX; //[4][3] [fl, fr, rl, rr][x,y,z]
            public float tyreContactPointFLY; //[4][3] [fl, fr, rl, rr][x,y,z]
            public float tyreContactPointFLZ; //[4][3] [fl, fr, rl, rr][x,y,z]
            public float tyreContactPointFRX; //[4][3] [fl, fr, rl, rr][x,y,z]
            public float tyreContactPointFRY; //[4][3] [fl, fr, rl, rr][x,y,z]
            public float tyreContactPointFRZ; //[4][3] [fl, fr, rl, rr][x,y,z]
            public float tyreContactPointRLX; //[4][3] [fl, fr, rl, rr][x,y,z]
            public float tyreContactPointRLY; //[4][3] [fl, fr, rl, rr][x,y,z]
            public float tyreContactPointRLZ; //[4][3] [fl, fr, rl, rr][x,y,z]
            public float tyreContactPointRRX; //[4][3] [fl, fr, rl, rr][x,y,z]
            public float tyreContactPointRRY; //[4][3] [fl, fr, rl, rr][x,y,z]
            public float tyreContactPointRRZ; //[4][3] [fl, fr, rl, rr][x,y,z]
            public float tyreContactNormalFLX; //[4][3] [fl, fr, rl, rr][x,y,z]
            public float tyreContactNormalFLY;
            public float TyreContactNormalFLZ;
            public float TyreContactNormalFRX;
            public float TyreContactNormalFRY;
            public float TyreContactNormalFRZ;
            public float TyreContactNormalRLX;
            public float TyreContactNormalRLY;
            public float TyreContactNormalRLZ;
            public float TyreContactNormalRRX;
            public float TyreContactNormalRRY;
            public float TyreContactNormalRRZ;
            public float tyreContactHeadingFLX; //[4][3] [fl, fr, rl, rr][x,y,z]
            public float TyreContactHeadingFLY;
            public float TyreContactHeadingFLZ;
            public float TyreContactHeadingFRX;
            public float TyreContactHeadingFRY;
            public float TyreContactHeadingFRZ;
            public float TyreContactHeadingRLX;
            public float TyreContactHeadingRLY;
            public float TyreContactHeadingRLZ;
            public float TyreContactHeadingRRX;
            public float TyreContactHeadingRRY;
            public float TyreContactHeadingRRZ;
            public float brakeBias;
            public float localVelocityX; //[3]
            public float localVelocityY; //[3]
            public float localVelocityZ; //[3]
            public int P2PActivation;//Not used in ACC
            public int P2PStatus;//Not used in ACC
            public float currentMaxRpm;
            public float mz1;//[4] Not show in ACC
            public float mz2;//[4] Not show in ACC
            public float mz3;//[4] Not show in ACC
            public float mz4;//[4] Not show in ACC
            public float fx1;//[4] Not show in ACC
            public float fx2;//[4] Not show in ACC
            public float fx3;//[4] Not show in ACC
            public float fx4;//[4] Not show in ACC
            public float fy1;//[4] Not show in ACC
            public float fy2;//[4] Not show in ACC
            public float fy3;//[4] Not show in ACC
            public float fy4;//[4] Not show in ACC
            public float slipRatioFL;//[4]
            public float slipRatioFR;//[4]
            public float slipRatioRL;//[4]
            public float slipRatioRR;//[4]
            public float slipAngleFL;//[4]
            public float slipAngleFR;//[4]
            public float slipAngleRL;//[4]
            public float slipAngleRR;//[4]
            public int tcInAction;
            public int absInAction;
            public float suspensionIsDamageFL;//[4]
            public float suspensionIsDamageFR;//[4]
            public float suspensionIsDamageRL;//[4]
            public float suspensionIsDamageRR;//[4]
            public float tyreTempFL;//[4]
            public float tyreTempFR;//[4]
            public float tyreTempRL;//[4]
            public float tyreTempRR;//[4]
            public float waterTemp;
            public float brakPressureFL;//[4]
            public float brakPressureFR;//[4]
            public float brakPressureRL;//[4]
            public float brakPressureRR;//[4]
            public int frontBrakeCompound;
            public int rearBrakeCompound;
            public float padLifeFL;//[4]
            public float padLifeFR;//[4]
            public float padLifeRL;//[4]
            public float padLifeRR;//[4]
            public float discLifeFL;//[4]
            public float discLifeFR;//[4]
            public float discLifeRL;//[4]
            public float discLifeRR;//[4]
            public int ignitionOn;
            public int startEngineOn;
            public int isEngineRun;
            public float kerbVibration;
            public float slipVibrations;
            public float gVibrations;
            public float absVibrations;
        }
        public struct myGraphics
        {
            public int PacketId;
            public GameStates GameState;
            public SessionTypes Session;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
            public string CurrentTime;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
            public string LastTime;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
            public string BestTime;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
            public string Split;
            public int CompletedLaps;
            public int Position;
            public int CurrentTimeMilliSeconds;
            public int LastTimeMilliSeconds;
            public int BestTimeMilliSeconds;
            public float TimeLeft;
            public float DistanceTravelled;
            public int IsInPit;
            public int CurrentSector;
            public int LastSectorTimeMilliSeconds;
            public int NumberOfCompletedLaps;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
            public string TyreCompound;
            [Obsolete]
            public float ReplayTimeMultiplier;
            public float NormalizedCarPosition;
            public int ActiveCars;
            
            public float CarCoordinatesX;
            
            public float CarCoordinatesY;
            
            public float CarCoordinatesZ;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
            public CarCoordinates[] CarCoordinates;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
            public int[] CarIds;//60
            public int CarId;
            public float PenaltyTime;
            public FlagTypes Flag;
            public PenaltyTypes Penalty;
            public int IdealLineOn;
            public int IsInPitLane;
            public float SurfaceGrip;
            public int MandatoryPitDone;
            public float WindSpeed;
            public float WindDirection;
            public int IsSetupMenuVisible;
            public int MainDisplayIndex;
            public int SecondaryDisplayIndex;
            public int TC;
            public int TCUT;
            public int EngineMap;
            public int ABS;
            public float FuelXLap;
            public int RainLights;
            public int FlashingLights;
            public int LightsStage;
            public float ExhaustTemperature;
            public int WiperLV;
            public int DriverStingTotalTimeLeft;
            public int DriverStingTimeLeft;
            public int RainTyres;
            public int SessionIndex;
            public float UsedFuel; //Since last refuel
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
            public String DeltaLapTime;
            public int DeltaLapTimeInMilliSeconds;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
            public String EstimatedLapTime;
            public int EstimatedLapTimeInMilliSeconds;
            public int IsDeltaPositive;
            public int Isplit; //Last split time in ms
            public int IsValidLap;
            public float FuelEstimatedLaps;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
            public String TrackStatus;
            public int MissingMandatoryPits;
            public float Clock;
            public int DirectionLightsLeft;
            public int DirectionLightsRight;
            public int GlobalYellow;
            public int GlobalYellow1;
            public int GlobalYellow2;
            public int GlobalYellow3;
            public int GlobalWhite;
            public int GlobalGreen;
            public int GlobalChequered;
            public int GlobalRed;
            public int mfdTyreSet;
            public float mfdFuelAdd;
            public float mfdTyrePressureLF;
            public float mfdTyrePressureRF;
            public float mfdTyrePressureLR;
            public float mfdTyrePressureRR;
            public GripStatus GripStatus;
            public RainIntensity RainIntensity;
            public RainIntensity RainIntensity10;
            public RainIntensity RainIntensity30;
            public int CurrentTyreSet;
            public int StrategyTyreSet;
            public int GapAhead;
            public int GapBehind;
        }
        public enum RainIntensity
        {
            NO_RAIN = 0,
            DRIZZLE = 1,
            LIGHT_RAIN = 2,
            MEDIUM_RAIN = 3,
            HEAVY_RAIN = 4,
            THUNDERSTORM = 5
        }
        public enum GameStates
        {
            Off = 0,
            Replay = 1,
            Live = 2,
            Pause = 3
        }
        public enum SessionTypes
        {
            Unknown = -1,
            Practice = 0,
            Qualification = 1,
            Race = 2,
            HotLap = 3,
            TimeAttack = 4,
            Drift = 5,
            Drag = 6,
            HotStint = 7,
            HotStintSuperPole = 8
        }
        public struct CarCoordinates
        {
            public float X;
            public float Y;
            public float Z;
        }
        public enum FlagTypes
        {
            None = 0,
            Blue = 1,
            Yellow = 2,
            Black = 3,
            White = 4,
            Checkered = 5,
            Penalty = 6,
            Green = 7,
            Orange = 8
        }
        public enum PenaltyTypes
        {
            None = 0,
            DriveThrough_Cutting = 1,
            StopAndGo_10_Seconds_Cutting = 2,
            StopAndGo_20_Seconds_Cutting = 3,
            StopAndGo_30_Seconds_Cutting = 4,
            Disqualified_Cutting = 5,
            BestLapTimeRemoved_Cutting = 6,
            DriveThrough_SpeedingInPitLane = 7,
            StopAndGo_10_Seconds_SpeedingInPitLane = 8,
            StopAndGo_20_Seconds_SpeedingInPitLane = 9,
            StopAndGo_30_Seconds_SpeedingInPitLane = 10,
            Disqualified_SpeedingInPitLane = 11,
            BestLapTimeRemoved_SpeedingInPitLane = 12,
            Disqualified_IgnoringMandatoryPitStop = 13,
            PostRaceTimeAdded = 14,
            Disqualified_Trolling = 15,
            Disqualified_PitEntry = 16,
            Disqualified_PitExit = 17,
            Disqualified_GoingWrongWay = 18,
            DriveThrough_IgnoringDriverStint = 19,
            Disqualified_IgnoringDriverStint = 20,
            Disqualified_ExceedingDriverStintLimit = 21,
            Disqualified_WrongWay_MayBe = 22,
        }
        public enum GripStatus
        {
            GREEN = 0,
            FAST = 1,
            OPTIMUM = 2,
            GREASY = 3,
            DAMP = 4,
            WET = 5,
            FLOODED = 6
        }

    }
}
