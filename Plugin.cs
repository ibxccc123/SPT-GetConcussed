using BepInEx;
using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetConcussed.Patches;
using BepInEx.Configuration;

namespace GetConcussed
{
    // first string below is your plugin's GUID, it MUST be unique to any other mod. Read more about it in BepInEx docs. Be sure to update it if you copy this project.
    [BepInPlugin("com.penguingreentea.GetConcussed", "GetConcussed", "1.0.2")]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource LogSource;
        internal static ConfigEntry<float> ConcussionStrength;
        internal static ConfigEntry<int> ConcussionDuration;
        internal static ConfigEntry<bool> TinnitusEffect;

        // BaseUnityPlugin inherits MonoBehaviour, so you can use base unity functions like Awake() and Update()
        private void Awake()
        {

            ConcussionStrength = Config.Bind("", "Concussion Strength", 0.75f, new ConfigDescription("Determines the strength of concussion effect", new AcceptableValueRange<float>(0.5f, 1.0f)));
            ConcussionDuration = Config.Bind("", "Concussion Duration", 5, new ConfigDescription("Determines how long the concussion lasts in seconds", new AcceptableValueRange<int>(0, 60)));
            TinnitusEffect = Config.Bind("", "Tinnitus effect", true, new ConfigDescription("Turns tinnitus effect on/off (tinnitus only occurs if no headset is equipped)"));
            // save the Logger to variable so we can use it elsewhere in the project
            LogSource = Logger;
            new ConcussionPatch().Enable();
        }
    }
}
