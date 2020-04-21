using System;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using RoR2;

namespace RoR2RemoveAllyCap
{
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("com.Basil.RemoveAllyCap", "RemoveAllyCap", "1.0.3")]
    public class RAC : BaseUnityPlugin
    {
        public static ConfigEntry<bool> RemoveCap;
        public static ConfigEntry<string> AllyCountCap;

        public void InitConfig()
        {
            RemoveCap = Config.Bind(
                "Settings",
                "RemoveCap",
                true,
                "Removes the default ally cap if true and sets it to theoretically infinity."
                );

            AllyCountCap = Config.Bind(
               "Settings",
               "AllyCountCap",
               "20",
               "Sets the max number of allies you can have. This will only work if RemoveCap is set to false."
               );
        }

        public static float ConfigToFloat(string configline)
        {
            if (float.TryParse(configline, out float x))
            {
                return x;
            }
            return 1f;
        }

        public void Awake()
        {
            InitConfig();
            try
            {
                Harmony harmony = new Harmony("RAC");
                harmony.PatchAll();

            }
            catch (Exception ex)
            {
                FileLog.Log("Overall Patcher " + ex.Message);
            }
        }
        
    }
}
