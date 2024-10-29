using EFT;
using EFT.Ballistics;
using EFT.HealthSystem;
using EFT.InventoryLogic;
using HarmonyLib;
using SPT.Reflection.Patching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GetConcussed.Patches
{

    internal class ConcussionPatch : ModulePatch
    {

        public static float GetConcussionStrength(float damage)
        {
            int lowConcussion = 5;
            int mediumConcussion = 7;
            int highConcussion = 9;
            int lowestDamageThreshold = 2;
            int highestDamageThreshold = 5;
            if (damage < lowestDamageThreshold)
            {
                return lowConcussion;
            }
            else if (damage <= highestDamageThreshold)
            {
                return mediumConcussion;
            }
            else
            {
                return highConcussion;
            }
        }

        protected override MethodBase GetTargetMethod()
        {
            return typeof(Player).GetMethod("ApplyShot", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
        }

        [PatchPostfix]
        private static void PatchPostfix(
            Player __instance,
            DamageInfo damageInfo,
            EBodyPart bodyPartType,
            EBodyPartColliderType colliderType,
            EArmorPlateCollider armorPlateCollider,
            GStruct389 shotId)
        {
            // If a player is hit by a headshot and some armor is blocking it
            if (bodyPartType == EBodyPart.Head && !string.IsNullOrEmpty(damageInfo.BlockedBy))
            {
                float damage = damageInfo.Damage;
                float concussionStrength = GetConcussionStrength(damage);
                ActiveHealthController activeHealthController = __instance.ActiveHealthController;
                activeHealthController.DoContusion(concussionStrength, concussionStrength*1.5f);
                activeHealthController.DoStun(1, 0);
            }
        }

    }
}
