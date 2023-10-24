# The-Medicine-Isnt-Working  
https://mcfuzzykins.github.io/The-Medicine-Isnt-Working/  
Press P to turn off Post-Processing Layer   

# Referential Material  
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
  
# Changelog  
09/19/2023:  
Repo Created  
HP System created (Enemies die, player damages on collison, etc.)  
  
09/25/2023:  
HP Systems Removed  
New Room Prefabs Created  
Camera Follows Player  
Player Rotates with Movement  
  
*Need to implement:*  
Room Generation (Object Pool, Decorator Pattern)  
Enemy System (Probably with Room Generation or Decorator)  
  
10/02/2023:  
Player can Die  
Enemies Spawn in (No AI)  
Win Condition (Get to thing)  
Win/Loss Screens  

10/09/2023:  
Healthbar, Psychosis Meter, and Pill Count  
More rooms  
  
10/17/2023:  
Post-Processing Stuff to indicate Psychosis stuff  
Enemies move around (some of em)
Scripts control Post-Processing Effects  

10/24/2023:  
More Post-Processing Effects  
Added Icons for Health and Psychosis Meter  
Enemies are now Nurses that have walking animations  
Enemies Chase after player when entering a 10 unit radius  
WinCon items are now Pill Bottles  
Refactored Code to be cleaner and have designated purposes  
Implementing an Observer Pattern, currently not finished  
