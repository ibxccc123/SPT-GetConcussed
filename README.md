# SPT-GetConcussed
Adds the concussion and tinnitus effect to players when helmets receive headshots.

## **Overview**
Headshots will trigger the concussion/tinnitus effects if the bullet is blocked by armor.  Like Live EFT, tinnitus will only occur if you do not have a headset equipped.

## **Background**
Currently for me and some other people, there seems to be an issue where concussion is not properly triggering off of helmet gunshot ricochets.  Concussions caused by other items such as stimulants or grenades are working normally though.  

This mod is just a temporary fix for any users like me who have the same issue and want to get the concussive effect whenever their helmet protects them from a headshot.

## **Install**
Extract directly into the SPT folder.  The plugin can be located in BepInEx/plugins/.

## **Specifics**
When the player gets headshot by any bullet that is blocked by armor, the concussion and tinnitus effects are played via ActiveHealthController in the Player Class.  Concussion duration and strength varies based on how much damage was applied in the shot.  The length of the concussion effect ranges from five to nine seconds depending on how much damage was received.

## **Demo**

[Showcase of Concussion + Tinnitus Effects](https://streamable.com/vard1w)

## **Issues**
Headshots that are blocked by any type of armor, such as face shields, will trigger the concussion/tinnitus effect. 
