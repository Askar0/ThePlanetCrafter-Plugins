using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using SpaceCraft;
using System.Reflection;
using UnityEngine.InputSystem;

namespace Askar0_DayNightToggle
{
    /// <summary>
    /// 
    /// </summary>
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        static ConfigEntry<bool> isEnabled;
        static ConfigEntry<bool> isDayCycle;

        static ManualLogSource logger;
        // static PlayerGaugesHandler playerGaugesHandler;
        private static bool isAppCreative = false;

        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            isEnabled = Config.Bind("General", "Enabled", true, "Is the mod enabled?");

            isDayCycle = Config.Bind("General", "DayCycle Toggle", false, "Day Night Cycle Toggle");

            logger = base.Logger;

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "Askar0_DayNightToggle");
        }
        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            if (isEnabled.Value)
            {

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HarmonyPrefix]
        [HarmonyPatch(typeof(EnvironmentDayNightCycle), "Start")]
        private static bool day()
        {
            return isDayCycle.Value;
        }
    }
}
