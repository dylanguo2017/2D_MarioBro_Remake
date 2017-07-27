Group 4

Each team member has two code reviews in the "Code Reviews" folder under Sprint 6. The group reflection and discussion on the Burndown Chart is in the "Burndown Chart Reflections" folder. The game is "Game.sln" and all related files are in the "Game1" folder.

New Feature: 
- Bat Mario: Rezeki Utomo
	added bat state mario and the item required to change mario into bat state. the bat state will only last for a couple seconds due to gameplay balancing. After the bat state is over, mario would turn back into the previous state he was before
	he entered the bat state. Research into random number generators were done in order to simulate the wind movement as the bat flies. This could clearly be seen when the bat is stationary or moving as it will shake up, down, and back independent
	of the user control. While in the bat state, mario is vulnerable despite the previous state he was in. If he got hit during bat state, he would die instantly. This is a design decision to prevent the game from being too easy. For testing purposes,
	the "y" key has been changed to turn mario into the bat state. During normal gameplay, mario has to pick up the powerup item hidden in boxes in order to turn into a bat.

***We ran Code Analysis and received 0 errors and 0 warnings. Below is the output:
	1>------ Rebuild All started: Project: Game, Configuration: Debug x86 ------
1>  Game -> C:\Users\Admin\Source\Repos\Mario4.02\Game1\bin\Windows\x86\Debug\Game1.exe
1>  Running Code Analysis...
1>  Code Analysis Complete -- 0 error(s), 0 warning(s)
========== Rebuild All: 1 succeeded, 0 failed, 0 skipped ==========

