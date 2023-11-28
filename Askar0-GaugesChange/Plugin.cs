using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using SpaceCraft;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using HarmonyLib;
using System.Reflection;
using static UnityEngine.ParticleSystem.PlaybackState;

namespace Askar0_GaugesChange
{
    /// <summary>
    /// 
    /// </summary>
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        static ConfigEntry<bool> isEnabled;
        //static ConfigEntry<Key> isKey;
        /// <summary>
        /// 
        /// </summary>
        public static ConfigEntry<float> custHealth;
        /// <summary>
        /// 
        /// </summary>
        public static ConfigEntry<float> custThirst;
        /// <summary>
        /// 
        /// </summary>
        public static ConfigEntry<float> custOxygen;
        /// <summary>
        /// 
        /// </summary>
        public static ConfigEntry<string> custModifier;
        static bool dLog;
        //static PlayerGaugesHandler playerGaugesHandler;


        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            isEnabled = Config.Bind("General", "Enable", true, "Is Plugin Enabled?");
            custModifier = Config.Bind("General", "CustomModifier", "Casual", "Choose one from the following: Custom, AFK, Baby, Lite, Casual, Standard, Intense, Hard, HC Plus, Nightmare, Hell");
            
            custHealth = Config.Bind("General", "CustomHealth", -0.060f, "Default: -0.060f  (Disabled at the moment)");
            custThirst = Config.Bind("General", "CustomThirst", -0.130f, "Default: -0.130f  (Disabled at the moment)");
            custOxygen = Config.Bind("General", "CustomOxygen", -1.900f, "Default: -1.900f  (Disabled at the moment)");

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "Askar0_GaugesChange");

        }

        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            if (isEnabled.Value)
            {
                dLog = true;
                float modValue = 0f;
                modValue = GetModifierValue(custModifier.Value);
                // playerGaugesHandler = Managers.GetManager<PlayersManager>()?.GetActivePlayerController()?.GetPlayerGaugesHandler();

                if (modValue != 0f)
                {
                    Managers.GetManager<GameSettingsHandler>().GetCurrentGameSettings().SetGaugeDrain(modValue);
                }
                if (dLog)
                {
                    Logger.LogInfo("================================================================");
                    Logger.LogInfo("Gauge Oxygen Drain Mode: " + GaugesConsumptionHandler.GetOxygenConsumptionRate());
                    Logger.LogInfo("Gauge Thirst Drain Mode: " + GaugesConsumptionHandler.GetThirstConsumptionRate());
                    Logger.LogInfo("Gauge Health Drain Mode: " + GaugesConsumptionHandler.GetHealthConsumptionRate());
                    Logger.LogInfo("Gauge Drain Mode: " + Managers.GetManager<GameSettingsHandler>().GetCurrentGameSettings().GetModifierGaugeDrain());
                    Logger.LogInfo("================================================================");
                    dLog = false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Modifier"></param>
        /// <returns></returns>
        private float GetModifierValue(string _Modifier)
        {
            float modifierValue = 0f;
            if (_Modifier != null) {
                if (_Modifier == "AFK") { modifierValue = 0.025f; }  
                if (_Modifier == "Baby") { modifierValue = 0.4f; }   
                if (_Modifier == "Lite") { modifierValue = 0.65f; }  
                if (_Modifier == "Casual") { modifierValue = 0.8f; } //  Basegame and Standard Gauge States (-0.060f, -0.130f, -1.900f)
                if (_Modifier == "Custom") { modifierValue = 1f; }   //  Basegame I am using as defaults    (1.0f Modifier)
                if (_Modifier == "Standard") { modifierValue = 1.25f; } 
                if (_Modifier == "Intense") { modifierValue = 1.5f; }
                if (_Modifier == "Hardcore") { modifierValue = 2f; }
                if (_Modifier == "HC Plus") { modifierValue = 2.75f; }
                if (_Modifier == "Nightmare") { modifierValue = 3.75f; }
                if (_Modifier == "Hell") { modifierValue = 5f; }
                if (modifierValue == 0f) { modifierValue = 1f; } // If incorrect spelling/case reset to default
            }
            return modifierValue;
        }

        /* NOT WORKING Looking for work around
        private class o2Thirst
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="___healthChangeValuePerSec"></param>
            /// <param name="___thirstChangeValuePerSec"></param>
            /// <param name="___oxygenChangeValuePerSec"></param>
            [HarmonyPrefix]
            [HarmonyPatch(typeof(PlayerGaugesHandler), "StartGaugesConsumption")]
            private static void o2Water(ref float ___healthChangeValuePerSec, ref float ___thirstChangeValuePerSec, ref float ___oxygenChangeValuePerSec)
            {
            ___thirstChangeValuePerSec = Plugin.custThirst.Value;
            ___oxygenChangeValuePerSec = Plugin.custOxygen.Value;
            ___healthChangeValuePerSec = Plugin.custHealth.Value;
            }
        }
        */
    }
}
