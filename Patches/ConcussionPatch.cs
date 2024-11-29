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

        protected override MethodBase GetTargetMethod()
        {
            return typeof(Player).GetMethod("ApplyShot", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
        }

        [PatchPostfix]
        private static void PatchPostfix(
            Player __instance,
            DamageInfoStruct damageInfo,
            EBodyPart bodyPartType,
            EBodyPartColliderType colliderType,
            EArmorPlateCollider armorPlateCollider,
            ShotIdStruct shotId)
        {
            // If a player is hit by a headshot and some armor is blocking it or damage is less than 10 (I cannot for the life of me figure out why rarely helmet armor reduces the shot damage but the game doesn't keep track of it in damageInfo.BlockedBy)
            if (bodyPartType == EBodyPart.Head && (!string.IsNullOrEmpty(damageInfo.BlockedBy) || damageInfo.Damage < 10))
            {
                Plugin.LogSource.LogWarning($"Concussion activated. Damage taken at {bodyPartType}, amount of damage is {damageInfo.Damage}, blocked by: {damageInfo.BlockedBy}.");
                float damage = damageInfo.Damage;
                float concussionStrength = Plugin.ConcussionStrength.Value;
                float concussionDuration = Plugin.ConcussionDuration.Value;
                ActiveHealthController activeHealthController = __instance.ActiveHealthController;
                activeHealthController.DoContusion(concussionDuration, concussionStrength);
                if (Plugin.TinnitusEffect.Value)
                {
                    activeHealthController.DoStun(1, 0);
                }
            }
            else if (bodyPartType == EBodyPart.Head)
            {
                Plugin.LogSource.LogWarning($"No concussion. Damage taken at {bodyPartType}, amount of damage is {damageInfo.Damage}, blocked by: {damageInfo.BlockedBy}.");
            }
        }

    }
}
