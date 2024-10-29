# SPT-GetConcussed
Adds the concussion and tinnitus effect to players when helmets receive headshots.

## **Overview**
Headshots will trigger the concussion/tinnitus effects if the bullet is blocked by armor.  The length of the concussion effect ranges based on how much damage is received (five to nine seconds).

## **Background**
Currently for me and at least some other users, there may be an issue where concussion is not properly triggering off of helmet gunshot ricochets.  Concussions caused by other items such as stimulants or grenades are working normally though.  

This mod is a temporary fix for any users like me who are experiencing the issue of not getting the concussive effect whenever their helmet saves them from a headshot.

## **Install**
Extract directly into the SPT folder.  The plugin can be located in BepInEx/plugins/.

## **Specifics**
When the player gets hit by any bullet that is blocked by armor, the concussion and tinnitus effects are played via ActiveHealthController in the Player Class.  Concussion duration and strength varies based on how much damage was applied in the shot.

## **Demo**

https://streamable.com/ztikfb

## **Issues**
Any type of gunshot to the head body part that is blocked by any type of armor will trigger the concussion/tinnitus effect, such as face shields or ballistic masks blocking the shot.
