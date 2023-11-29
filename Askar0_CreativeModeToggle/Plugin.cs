using System;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using SpaceCraft;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Askar0_CreativeModeToggle
{
    /// <summary>
    /// 
    /// </summary>
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        static ConfigEntry<bool> isEnabled;
        static ConfigEntry<Key> isKey;

        static ManualLogSource logger;
        // static PlayerGaugesHandler playerGaugesHandler;
        // private static bool isAppCreative = false;

        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            isEnabled = Config.Bind("General", "Enabled", true, "Is the mod enabled?");

            isKey = Config.Bind("General", "KeyBind", Key.K, "Creative Toggle Keybind");

            logger = base.Logger;

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "Askar0_CreativeModeToggle");
        }
        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            if (isEnabled.Value)
            {


                bool wasPressedThisFrame = Keyboard.current[isKey.Value].wasPressedThisFrame;
                bool flag = wasPressedThisFrame;
                if (flag)
                {
                    logger.LogInfo("=========================================================");
                    logger.LogInfo("=============  Creative Mode Toggle Plugin  =============");
                    logger.LogInfo("=========================================================");
                    logger.LogInfo("== Plugin Update Check Mode: " + isEnabled.Value);
                    logger.LogInfo("== Plugin Update Debug ==");

                    // Toggle Creative Core Call
                    //Debug Log
                    logger.LogInfo("FreeCraft Mode Was: " + Managers.GetManager<GameSettingsHandler>().GetCurrentGameSettings().GetFreeCraft());
                    logger.LogInfo("Save Game Mode: " + Managers.GetManager<GameSettingsHandler>().GetCurrentGameSettings().GetGameMode().ToString());
                    logger.LogInfo("Gauge Oxygen Drain Mode: " + GaugesConsumptionHandler.GetOxygenConsumptionRate());
                    logger.LogInfo("Gauge Thirst Drain Mode: " + GaugesConsumptionHandler.GetThirstConsumptionRate());
                    logger.LogInfo("Gauge Health Drain Mode: " + GaugesConsumptionHandler.GetHealthConsumptionRate());
                    
                    logger.LogInfo("== Changing State ==");
                    Managers.GetManager<GameSettingsHandler>().TogglePlayMode();
                    // Managers.GetManager<GameSettingsHandler>().GetCurrentGameSettings().SetEverythingUnlocked(true);

                    bool gDrain = Managers.GetManager<GameSettingsHandler>().GetCurrentGameSettings().GetFreeCraft();
                    if (gDrain)
                    {
                        Managers.GetManager<GameSettingsHandler>().GetCurrentGameSettings().SetGaugeDrain(0f);
                        logger.LogInfo("Gauge Drain Mode: " + Managers.GetManager<GameSettingsHandler>().GetCurrentGameSettings().GetModifierGaugeDrain());
                    }
                    else
                    {
                        Managers.GetManager<GameSettingsHandler>().GetCurrentGameSettings().SetGaugeDrain(1f);
                        logger.LogInfo("Gauge Drain Mode: " + Managers.GetManager<GameSettingsHandler>().GetCurrentGameSettings().GetModifierGaugeDrain());
                    }

                    logger.LogInfo("FreeCraft Mode is Now: " + Managers.GetManager<GameSettingsHandler>().GetCurrentGameSettings().GetFreeCraft());
                    logger.LogInfo("Save Game Mode: " + Managers.GetManager<GameSettingsHandler>().GetCurrentGameSettings().GetGameMode().ToString());
                    logger.LogInfo("Gauge Oxygen Drain Mode: " + GaugesConsumptionHandler.GetOxygenConsumptionRate());
                    logger.LogInfo("Gauge Thirst Drain Mode: " + GaugesConsumptionHandler.GetThirstConsumptionRate());
                    logger.LogInfo("Gauge Health Drain Mode: " + GaugesConsumptionHandler.GetHealthConsumptionRate());

                    logger.LogInfo("== Changing State Finished ==");


                    //isAppCreative = !isAppCreative;
                    logger.LogInfo("Creative Mode State: " + Managers.GetManager<GameSettingsHandler>().GetCurrentGameSettings().GetFreeCraft());
                    logger.LogInfo("=====      Plugin Update Debug: Done.      =====");

                }
            }
        }
    }
}
