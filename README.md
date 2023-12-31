# The-Medicine-Isnt-Working  
https://mcfuzzykins.github.io/The-Medicine-Isnt-Working/  
Settings Menu on Start Screen has toggle for Post Processing Effects   

# Trailer
  https://youtu.be/xK4Sez5BH5Y  
  

# Referential/Implemented Material  
This section is not just to cite what material I reviewed to help me produce this,  
but for others that view this project to learn cool new things  
- Post-Processing Setup with URP:  
  https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@14.0/manual/integration-with-post-processing.html  
- Editing Post-Process effects in Scirpts:  
  https://forum.unity.com/threads/how-to-modify-post-processing-profiles-in-script.758375/  
  https://forum.unity.com/threads/urp-volume-cs-how-to-access-the-override-settings-at-runtime-via-script.813093/#post-5415663  
  https://forum.unity.com/threads/how-do-i-change-post-processing-effects-with-a-script-urp.1277198/  
- Nurse Model and Animations:  
  https://www.mixamo.com/#/
- Various Textures and Models:  
  https://assetstore.unity.com/packages/3d/environments/hospital-horror-pack-44045
  
# Bug Log
## 11/21/2023:  
Not all medication pickups display pickup prompt  
Can infinitely pick up pickups even after they disable  
Enemies cannot die  
  
### UNITY BUGS:  
There seems to be a bug with importing images while having the HDRP Package installed  
  
# Changelog  
## 09/19/2023:  
Repo Created  
HP System created (Enemies die, player damages on collison, etc.)  
  
## 09/25/2023:  
HP Systems Removed  
New Room Prefabs Created  
Camera Follows Player  
Player Rotates with Movement  
  
*Need to implement:*  
Room Generation (Object Pool, Decorator Pattern)  
Enemy System (Probably with Room Generation or Decorator)  
  
## 10/02/2023:  
Player can Die  
Enemies Spawn in (No AI)  
Win Condition (Get to thing)  
Win/Loss Screens  

## 10/09/2023:  
Healthbar, Psychosis Meter, and Pill Count  
More rooms  
  
## 10/17/2023:  
Post-Processing Stuff to indicate Psychosis stuff  
Enemies move around (some of em)
Scripts control Post-Processing Effects  

## 10/24/2023:  
More Post-Processing Effects  
Added Icons for Health and Psychosis Meter  
Enemies are now Nurses that have walking animations  
Enemies Chase after player when entering a 10 unit radius  
WinCon items are now Pill Bottles  
Refactored Code to be cleaner and have designated purposes  
Implementing an Observer Pattern, currently not finished  

## 10/31/2023:  
Bloom Effect on hit from Enemies  
Starting to implement state machine for Enemies  
Psychosis Meter has gradual decay, Post-Processing Effects tied to it show gradual change  
  
## 11/14/2023:  
New Start Menu with Settings Sub-Menu implemented  
New Textures and imported assets from a free Horror Hospital pack in the Unity Asset Store  
Loss Screen allows for Replay  
  
## 11/21/2023:  
Remaking the Map
New additions to aid in immersion   
Button system to collect medications  
