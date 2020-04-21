using System;
using RoR2.CharacterAI;
using UnityEngine;
using UnityEngine.Networking;
using RoR2;
using HarmonyLib;

namespace RoR2RemoveAllyCap
{
    [HarmonyPatch(typeof(MasterSummon), "Perform")]
    class Patches
    {

        static bool Prefix(MasterSummon __instance)
        {
            __instance.ignoreTeamMemberLimit = RAC.RemoveCap.Value;
            TeamIndex teamIndex;
            if (__instance.teamIndexOverride != null)
            {
                teamIndex = __instance.teamIndexOverride.Value;
            }
            else
            {
                teamIndex = TeamComponent.GetObjectTeam(__instance.summonerBodyObject);
            }
            TeamDef teamDef = TeamCatalog.GetTeamDef(teamIndex);
            if (teamDef != null)
            {
                teamDef.softCharacterLimit = (int)RAC.ConfigToFloat(RAC.AllyCountCap.Value);
            }
            return true;
        }
    }
}
