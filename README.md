
# ThePlanetCrafter_Plugins
BepInEx+Harmony plugin/patcher/mods for the Unity/Steam game The Planet Crafter

Steam: https://store.steampowered.com/app/1284190/The_Planet_Crafter/

## Version <a href='https://github.com/Askar0/ThePlanetCrafter-Plugins/releases'><img src='https://img.shields.io/github/v/release/Askar0/ThePlanetCrafter-Plugins' alt='Latest GitHub Release Version'/></a>

:arrow_down_small: Download files from the releases: https://github.com/askar0/ThePlanetCrafter-Plugins/releases

```
Note: 11/23/2023 - (Mods/Plugins Under Construction) - Some testing files have been uploaded. 
 - These will need testing and possibly additional updates before release versions will be made available.
```

## Currently Intended Support for Game Versions:
ℹ️ Current Early Access / Experimental (Possibly)

:warning: I'll do my best to keep my mods up-to-date in case something drastic changes inside the 
 - main game.

:warning: I may not have tested my mods with some versions of the developer/preview/demo releases.
 - They might work just fine or suddenly break.

:warning: I cannot promise to fix my mods for these other versions as they can get quite out-of-sync 
 - with the public release.

**Note:** I am still in the process of creating the form and code for my mods/plugins and currently not
 - working on the release versions yet. Please be patient.

## Preparation

In order to use my or anyone else's mods at this time, you need to install BepInEx first.
 - The wiki has a guide for this:

Planet Crafter Modding Wiki pages: https://planet-crafter.fandom.com/wiki/Modding#Using_Mods

Guide on dnSpy-based manual patches: https://steamcommunity.com/sharedfiles/filedetails/?id=2784319459

## Installation

When installing my mods, unzip the mod into the `BepInEx\Plugins` directory, using the zipfile name
 - (without the zip extension) as the folder to store the plugins in.

You should end up having a directory structure like this:

```
`BepInEx\Plugins\Askar0-(UI) Minimap-Core Plugin\Askar0.Minimap.Core_v1-0.dll`
`BepInEx\Plugins\Askar0-(UI) Minimap-UI Plugin\Askar0.Minimap.UI_v1-0.dll`
`BepInEx\Plugins\Askar0-(UI) Minimap-GUI Plugin\Askar0.Minimap.GUI_v1-0.dll`
`BepInEx\Plugins\Askar0-(UI-Mod) Minimap-Mod-Helper Plugin\Askar0.Minimap.Mod-Helper_v1-0.dll`
`BepInEx\Plugins\Askar0-(UI-Mod) Minimap-Mod-Helper Plugin\mods\` #Etc Etc.
```

Note: I intend to add folder names and subfolders to the release versions of the plugins but at the moment.
 - I am just testing the mods so they may or may not already have folders setup in the zipfiles.

Doing this helps avoid overwriting each others' files if they happen to be named the same as well as allows
 - removing plugin files together by deleting the directory itself.

## Mods

## Mods Descriptions

```
Current Plugin Releases:
- Branch v1.0.0

Askar0-CheatCreativeFlightmodePlugin.zip
+ Enables Creative Flightmode (Pressing shift also allows for zoom mode - much faster travel whilst flying).
+ Default Key H

Askar0-CheatStopPlayerGauges-GameNotFocused.zip
+ When The Planet Crafter game is not the active window will pause all loss of hunger/thirst and oxygen,
  until you have the game as the active window again.

Askar0-CheatToggleDay-NightCycle.zip
+ Toggles if daynight cycle is active, or permanent day
+ Toggle is in Config options set to true Day only, set to false(default) to cycle day/night.

Askar0-CheatUnlockAllBlueprints_PermanentChange.zip
+ Permanent change: Unlocks all blueprints in a savegame. Requires manual savegame edit to remove state.

Current Plugin Releases:
- Branch v1.0.0 Alpha

Askar0-CheatToggleCreativeMode_Debug-Logging_v1.0.0.3.zip
+ Toggles Creative mode and makes all blueprints available and stops all hunger/thirst and oxygen usage
  when active.
+ (Update: 29/11/2023) Added config option for addition debug logging (default) allowing it to be turned off.
+ Default Key K

Askar0-CheatChangeandCustomize_Hunger-Thirst-Oxygen_Consumption.zip
+ Config option allowing different levels of player resource consumption based on predefined setting.
+ Example Image Add: Planetcrafter - Gauge RateOfChange.png
+ TODO: allow fully custom figures for Hunger, Thirst and Oxygen disabled currently

Source code (zip) 
+ Source code download for all my plugins (Auto Generated by Github).
```

### Configuration

Any configuration files generated with the mod:
```
Askar0.Fly.Plugin.cfg
Askar0.StopGauges.Plugin.cfg
Askar0.CreativeModeToggle.Plugin.cfg
Askar0.DayNightToggle.Plugin.cfg
Askar0.UnlockAllBlueprints.Plugin.cfg
```

Basic config settings for the plugins will be like the following:

```
[General]

## Is this mod enabled?
# Setting type: Boolean
# Default value: true
Enabled = true

```
