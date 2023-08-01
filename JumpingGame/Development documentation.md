# Development documentation

This documentation serves as a general overview of the project's structure from the development point of view. Concrete functions have their behavior thoroughly documented in their respective docstrings.

## AnimatedSprite.cs

The AnimatedSprite class is responsible for playing a sequence of sprites at a specified frame rate. It allows to create sprite animations by providing an array of sprites and controlling the animation playback.

## CollectPoints.cs

The CollectPoints script is a class that manages the collection of items for the player when the player's collider collides with the collider of a collectible item (in the current case with the cherry). This script works in conjunction with the GameManager script to keep track of the number of cherries collected by the player. It also destroys the collected item after it has been processed, preventing the player from collecting the same item again.

## DeathAnimation.cs

The DeathAnimation script is a component in Unity that handles the animation when the player dies. When he dies, it will disable physics components and movement scripts, and animate a "jump" motion before disappearing.

## EnemyA.cs

The EnemyA class is responsible for managing the behavior of an enemy of the type A in the game. It handles collisions with the player object and determines the appropriate action based on the player's position relative to the enemy. If the player's legs are above the enemy's head, the enemy will be flattened and destroyed instantly. Otherwise, the enemy will be hit by the player, and a death animation will be played before destroying the enemy after three seconds.

## EnemyB.cs

The EnemyB class is a script used to control the behavior of an enemy of the type B in the game. The enemy changes its movement to sliding when the player collides with it and triggers specific conditions. The enemy can also be pushed in a certain direction and disappear from the scene.

## EntityMovement.cs

The EntityMovement script is a component in Unity used to handle the movement of an entity such as enemies in the game environment. This script controls the entity's movement speed, direction, and handles collisions with obstacles to ensure smooth and realistic movement.

## Extensions.cs

The Extensions class is a static utility class containing extension methods for the Rigidbody2D and Transform classes in the Unity game engine. These extension methods provide additional functionality to perform raycasting and dot product tests.

## FinishLevel.cs

This script is designed to handle the completion of the level. It is responsible for loading the next level when the player enters a trigger, displaying a winner screen UI upon level completion, and providing functionality for starting the game, closing the winner screen, and quitting the application.

## GameManager.cs

This script glues all of the parts of the game together. The GameManager script is responsible for handling game state and logic in a 2D platformer game. It manages various aspects such as the current game state, player lives, collected cherries, level loading, and game over sequences.

## Menu.cs

This script is responsible for handling the main mmenu functionality. For now, there is only implementation of start game button, but if needed, another features can be implemented in this script.

## Player.cs

The Player script is designed to control the behavior of the player character in the game. It allows the player to switch between several states, "normal" and "strong,"(for now, only the default state is implemented, but thanks to the style of the implementation, if the game is changed in the future and another state is added, it can be easily done in this script) and perform a hit action with a cooldown period. Additionally, when the player character dies, a death animation is played, and the level is reset after a short delay.

## PlayerFallDeath.cs

This script is attached to an object in the game that represents a death zone. Its primary responsibility is to handle the player's death when they fall into the designated death zone. When a 2D collider attached to this object collides with another collider marked as a "trigger," this script will execute specific actions based on the type of collider it collides with.

## PlayerMovement.cs

This script handles the movement and physics of the player character in a 2D environment. It allows the player to move horizontally, jump, and interact with objects in the scene.

- This script assumes the player character is facing right by default and will rotate it to face left when moving in the opposite direction.
- The player character can jump when grounded, and a collision from above with an enemy will make the player bounce off.

## PlayerSpriteRenderer.cs

The PlayerSpriteRenderer script is responsible for managing the visibility of the player sprite. It works hand in hand with the PlayerMovement component, which is assumed to be attached to the same GameObject as this script.

When the GameObject containing the PlayerSpriteRenderer script is enabled, the SpriteRenderer component is enabled, making the player sprite visible. Conversely, when the GameObject is disabled, the SpriteRenderer component is disabled, making the player sprite invisible.

## SideScrolling.cs

This script implements a side-scrolling camera in the game. The camera follows the player horizontally (along the X-axis) to provide a smooth side-scrolling effect. It ensures that the camera's X position is always at least as far as the player's X position, preventing the camera from moving behind the player.

## Start.cs

The Start script is responsible for handling the start of the game. It is attached to an object in the scene and contains a public method, StartGame(), which will be called when the player initiates the game start process. The main purpose of this script is to load the next scene in the build index sequence when the game starts.


