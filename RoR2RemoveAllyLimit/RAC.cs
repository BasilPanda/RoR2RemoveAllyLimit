using System;
using BepInEx;
using BepInEx.Configuration;
using RoR2;

namespace RoR2RemoveAllyCap
{
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("com.Basil.RemoveAllyCap", "RemoveAllyCap", "1.0.0")]
    public class RAC : BaseUnityPlugin
    {
        public static ConfigWrapper<bool> RemoveCap;
        public static ConfigWrapper<string> AllyCountCap;

        public void InitConfig()
        {
            RemoveCap = Config.Wrap(
                "Settings",
                "RemoveCap",
                "Removes the default ally cap if true and sets it to theoretically infinity.",
                true);

            AllyCountCap = Config.Wrap(
               "Settings",
               "AllyCountCap",
               "Sets the max number of allies you can have. This will only work if RemoveCap is set to false.",
               "25");
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

            Hooks.main();
        }
        
    }
}
