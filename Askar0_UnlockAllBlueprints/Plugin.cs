using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using SpaceCraft;
using System.Reflection;

namespace Askar0_UnlockAllBlueprints
{
    /// <summary>
    /// 
    /// </summary>
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {

        static ConfigEntry<bool> isEnabled;

        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            isEnabled = Config.Bind("General", "Enabled", false, "Is the mod enabled? If you enable this mod it will permanently change any of the saves you open to have all blueprints unlocked whilst it is active.");
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "Askar0_UnlockAllBlueprints");

        }
        /// <summary>
        /// 
        /// </summary>
        private void Update() {
            if ( isEnabled.Value) {
                loadAllBlueprints(true);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isActive"></param>
        private void loadAllBlueprints(bool isActive) {
            if (isActive == true)
            {
                Managers.GetManager<GameSettingsHandler>().GetCurrentGameSettings().SetEverythingUnlocked(true);
                Logger.LogInfo("Permanent Change: All Blueprints Unlocked");
                Logger.LogInfo("Will persist even if plugin is disabled again or even removed. To remove this state you will need to edit the unlockedEverything parameter in the save file option near the end of the file to \"unlockedEverything\":false.");
                isEnabled.Value = false; // Failsafe automatically turns off after activating all blueprints in a savefile.
            }

        }
    }
}
