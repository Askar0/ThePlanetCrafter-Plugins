﻿using System;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using SpaceCraft;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Askar0_RunningSpeed
{
    /// <summary>
    /// 
    /// </summary>
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {

        static ConfigEntry<bool> isEnabled;
        //static ConfigEntry<Key> isKey;
        static ConfigEntry<float> isRunningSpeed;

        //static ManualLogSource logger;
        //static PlayerMovable playerMovable;
        //static float runningSpeed;
        //static bool runningToggle = false;


        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            // Plugin startup logic

            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            isEnabled = Config.Bind("General", "Enabled", true, "Is the mod enabled?");
            //isKey = Config.Bind("General", "KeyBind", Key.T, "Running Toggle Keybind (Todo)");
            isRunningSpeed = Config.Bind("General", "RunSpeed", 9f, "Running Speed Modifier");

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "Askar0_RunningSpeed");

            //logger = base.Logger;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            if (isEnabled.Value)
            {
                Managers.GetManager<PlayerMovable>().SetMoveSpeed(isRunningSpeed.Value); // ?
            }
        }
    }
}
