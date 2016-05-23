# Point and Click  + HOL framework 0.3.3 #
DoTween included.

## Setting up the managers:##
1. Inv data base managers.
2. Global var manager
3. Ui manager
4. HOL item manager(For Hol level)
To create manager:
Assets->Create->Point n Click
Assets->Create->HOL
1. Place all managers in Resources folder.
2. Start with new empty scene delete everything including camera and lights(2d game).
Setting Up Menus And Inventory:
1. Make items list in inventory manager.
2. Make ui prefabe for inventory.(Currently in grid shape)
3. Tag "Slot" to all inv slots.
Setting Up "Game Manager" and "Game Init "prefabe:
1. Assign Ui manager and Inventory manager in Game maneger inspector window.
2. Assign Game Manager and Varible Manager in Game Init.
3. Assign all UI prefabes and cursor prefabe in the Ui manager asset file.
4. Tag "GameManager" to Game Manager prefabe.


##Hotspot and interactions:##
1. Place hotspot and interaction prefabe in the scene, assign interaction in hotspot inspector window.
