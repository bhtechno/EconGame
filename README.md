# EconGame
The EconGame project still does not have a proper name, but for now, this will be its name. The project has several important parts.
All the relevant parts are in the path EconomicsBoardGame/Assets

Scenes: The game is modeled in seperate scenes where each scene represents another page/dimension, it contains all the Gameobjects of the game which may be
present at scene loading, or may be instaniated later, or destroyed. Can only be viewed using Unity.

Materials: Represents a layer pertaining the shader/graphical information about an object, and can be placed into almost any object that takes a 
physical presence in the game world.

Prefabs: Represents complex Gameobjects already tuned, edited, or changed in any way for ease of reusability throughout the game.

Scripts: All scripts in unity that inherit monobehavior are considered components. Components can be attached to any Gameobject, and can control other
components in the object, or other objects, if references are made. All scripts in the above path are custom written.

IMPORTANT NOTE: Unity allows setting refernces and variables from within the editor, and as such some variables might not appear to be set 
in the scripts, because they were set from the editor. Usually if a "variable = default" is found, it's probably being set in the editor.
