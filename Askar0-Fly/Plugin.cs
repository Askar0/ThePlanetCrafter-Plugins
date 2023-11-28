using System;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using SpaceCraft;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Askar0_Fly
{
    /// <summary>
    /// Sets the base name of the plugin extending the BaseUnityPlugin Class
    /// </summary>
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        static ConfigEntry<bool> isEnabled;
        // static ConfigEntry<bool> isFlying;
        static ConfigEntry<Key> isKey;
        static ManualLogSource logger;
        static PlayerMovable playerMovable;

        /// <summary>
        /// Awake() Initialize the Plugin
        /// </summary>
        private void Awake()
        {
            // Plugin startup logic

            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            isEnabled = Config.Bind("General", "Enabled", true, "Is the mod enabled?");
         // isFlying = Config.Bind("General", "Enabled", true, "Is flight enabled?");
            isKey = Config.Bind("General", "KeyBind", Key.H, "Flight Toggle Keybind");
            Plugin.logger = base.Logger;

            Harmony.CreateAndPatchAll(typeof(Plugin));
        }
        /// <summary>
        /// When an event occures it also triggers this module.
        /// This module is used to activate or deactive creative flying.
        /// (Also updates config so state persists between sessions)
        /// </summary>
        private void Update()
        {
            if (isEnabled.Value)
            {
                playerMovable = UnityEngine.Object.FindAnyObjectByType<PlayerMovable>();
                bool wasPressedThisFrame = Keyboard.current[Plugin.isKey.Value].wasPressedThisFrame;
                bool flag = wasPressedThisFrame;
                if (flag)
                {
                    logger.LogInfo("FlightMode Key: Was pressed.");
                    bool flag2 = playerMovable != null;
                    bool flag3 = flag2;
                    if (flag3)
                    {
                        playerMovable.flyMode = !playerMovable.flyMode;
                        logger.LogInfo("FlightMode State Changed: Flying = " + !playerMovable.flyMode);
                    }
                }
            }
        }
    }
}
