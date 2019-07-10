using System;
using RoR2.CharacterAI;
using UnityEngine;
using UnityEngine.Networking;
using RoR2;

namespace RoR2RemoveAllyCap
{
    public static class Hooks
    {
        public static void main()
        {
            On.RoR2.MasterSummon.Perform += (orig, self) =>
            {
                TeamIndex teamIndex;
                if (self.teamIndexOverride != null)
                {
                    teamIndex = self.teamIndexOverride.Value;
                }
                else
                {
                    if (!self.summonerBodyObject)
                    {
                        Debug.LogErrorFormat("Cannot spawn master {0}: No team specified.", new object[]
                        {
                        self.masterPrefab
                        });
                        return null;
                    }
                    teamIndex = TeamComponent.GetObjectTeam(self.summonerBodyObject);
                }
                if (!self.ignoreTeamMemberLimit)
                {
                    TeamDef teamDef = TeamCatalog.GetTeamDef(teamIndex);
                    if (teamDef == null)
                    {
                        Debug.LogErrorFormat("Attempting to spawn master {0} on TeamIndex.None. Is self intentional?", new object[]
                        {
                        self.masterPrefab
                        });
                        return null;
                    }

                    ////
                    
                    // No hardcap
                    if(teamDef != null && RAC.RemoveCap.Value)
                    {
                    }
                    // Custom cap
                    else if (teamDef != null && (int) RAC.ConfigToFloat(RAC.AllyCountCap.Value) != 25)
                    {
                        if((int)RAC.ConfigToFloat(RAC.AllyCountCap.Value) <= TeamComponent.GetTeamMembers(teamIndex).Count)
                        {
                            return null;
                        }
                    }
                    // default cap
                    else
                    {
                        if (teamDef != null && teamDef.softCharacterLimit <= TeamComponent.GetTeamMembers(teamIndex).Count)
                        {
                            return null;
                        }
                    }

                    ////

                }
                GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(self.masterPrefab, self.position, self.rotation);
                CharacterMaster component = gameObject.GetComponent<CharacterMaster>();
                component.teamIndex = teamIndex;
                if (self.summonerBodyObject)
                {
                    AIOwnership component2 = gameObject.GetComponent<AIOwnership>();
                    if (component2)
                    {
                        CharacterBody component3 = self.summonerBodyObject.GetComponent<CharacterBody>();
                        if (component3)
                        {
                            CharacterMaster master = component3.master;
                            if (master)
                            {
                                component2.ownerMaster = master;
                            }
                        }
                    }
                    BaseAI component4 = gameObject.GetComponent<BaseAI>();
                    if (component4)
                    {
                        component4.leader.gameObject = self.summonerBodyObject;
                    }
                }
                Action<CharacterMaster> action = self.preSpawnSetupCallback;
                if (action != null)
                {
                    action(component);
                }
                NetworkServer.Spawn(gameObject);
                component.Respawn(self.position, self.rotation, false);
                return component;
            };
        }

    }
}
