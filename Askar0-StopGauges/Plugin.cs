using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
using SpaceCraft;
using UnityEngine.InputSystem;

namespace Askar0_StopGauges
{
    /// <summary>
    /// 
    /// </summary>
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private int originalTargetFramerate;

        static ConfigEntry<bool> isEnabled;
        static ConfigEntry<Key> isKey;

        //static bool isAppAFK = false;
        //static bool isAppAFKh = false;

        static ManualLogSource logger;
        private static PlayerGaugesHandler playerGaugesHandler;
        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            // Plugin startup logic
      
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            isEnabled = Config.Bind("General", "Enabled", true, "Is the mod enabled?");
            isKey = Config.Bind("General", "KeyBind", Key.K, "AFK Toggle Keybind (Todo)");

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "Askar0_StopGauges");

            logger = base.Logger;
            Application.focusChanged += Application_focusChanged;

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
                bool isAppAFK;
                if (flag)
                {
                    isAppAFK = flag;
                    // Todo: Code StopGauges whilst window has focus
                    // logger.LogInfo("Toggle AFK Mode: " + isAppAFK);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hasFocus"></param>
        private void Application_focusChanged(bool hasFocus)
        {
            FPS();
            GaugeStatus(!hasFocus);
        }
        /// <summary>
        /// 
        /// </summary>
        private void FPS()
        {
            if (!Application.isFocused)
            {
                originalTargetFramerate = Application.targetFrameRate;
                Application.targetFrameRate = 5;
            }
            else
            {
                if (!originalTargetFramerate.Equals(default))
                Application.targetFrameRate = originalTargetFramerate;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isAFK"></param>
        private void GaugeStatus(bool isAFK)
        {
            playerGaugesHandler = Managers.GetManager<PlayersManager>()?.GetActivePlayerController()?.GetPlayerGaugesHandler();
            playerGaugesHandler?.GetPlayerGaugeHealth()?.SetInfinityStatus(isAFK);
            playerGaugesHandler?.GetPlayerGaugeOxygen()?.SetInfinityStatus(isAFK);
            playerGaugesHandler?.GetPlayerGaugeThirst()?.SetInfinityStatus(isAFK);
            logger.LogInfo("StopGauges AFK Status: " + isAFK);
        }
    }
}