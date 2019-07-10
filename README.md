# Remove Ally Cap
## By Basil

A mod that **removes** ally caps!

If you haven't noticed, the Backup Drone equipment isn't usable if you have over 25 allies! This mod helps remove that and relive the dream of spamming Backup Drones!

## Installation
1. Install [BepInEx Mod Pack](https://thunderstore.io/package/bbepis/BepInExPack/)
2. Install [R2API](https://thunderstore.io/package/tristanmcpherson/R2API/)
3. Download the latest RemoveAllyCap.dll here.
4. Move RemoveAllyCap.dll to your \BepInEx\plugins folder

## Configuration

1. To find the config file, first start up the game with RemoveAllyCap.dll in your \BepInEx\plugins folder already!
2. Then go to \BepInEx\config and open com.Basil.RemoveAllyCap.cfg

**I highly recommend deleting the config file if you previously installed this mod so it can be updated with the most recent config layout.**

## Default Config

[Settings]

* Removes the default ally cap if true and sets it to theoretically infinity.
RemoveCap = true

* Sets the max number of allies you can have. This will only work if RemoveCap is set to false.
AllyCountCap = 25

## Changelog

**v1.0.0**

- Default ally cap of 25 is removed and theoretically set to infinity!
- Allowed custom ally caps w/ CustomCap setting (default to	25)