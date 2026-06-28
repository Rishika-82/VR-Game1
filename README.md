# Unity Interaction Assignment

## Overview

This project is a simple first-person interaction system built in Unity. The player is placed inside a room containing three randomly colored cubes. One cube is randomly selected as the correct cube at the start of the game.

The player interacts with cubes simply by looking at them using a camera raycast.

---

# Features

* First-person camera interaction using Raycast
* Three cubes with random colors
* One randomly selected correct cube
* Correct cube:

  * Changes color to white
  * Plays a success sound
  * Displays "Correct" on the screen
  * Disables further interaction
* Wrong cube:

  * Flashes red briefly
  * Displays "Try Again"
  * Can still be interacted with

---

# Project Structure

```
Assets
│
├── Scripts
│   ├── Managers
│   │   ├── GameManager.cs
│   │   ├── UIManager.cs
│   │   └── AudioManager.cs
│   │
│   ├── Player
│   │   └── PlayerLook.cs
│   │
│   └── Interactable
│       ├── InteractableObject.cs
│       └── CubeInteractable.cs
│
├── Scenes
├── Prefabs
├── Materials
├── Audio
└── UI
```

---

# Architecture

The project follows the **Single Responsibility Principle**, where each script performs only one task.

### PlayerLook.cs

* Performs a raycast from the player's camera.
* Detects interactable objects.
* Calls the interaction method.

### InteractableObject.cs

* Base class for all interactable objects.
* Stores common interaction logic.
* Makes the system reusable.

### CubeInteractable.cs

* Handles cube-specific behavior.
* Determines whether the cube is correct or incorrect.
* Changes colors and communicates with the UI and Audio managers.

### GameManager.cs

* Randomly selects the correct cube.
* Controls overall game state.

### UIManager.cs

* Displays feedback messages.
* Automatically hides messages after a short delay.

### AudioManager.cs

* Plays sound effects.
* Keeps audio logic separate from gameplay.

---

# Part 2 - Supporting Multiple Objects

Instead of designing the interaction system only for cubes, a reusable base class (`InteractableObject`) was created.

Any future object such as a chair, bottle, key, book, or door can inherit from this class and implement its own interaction behavior without modifying the player interaction system.

This makes the project scalable and minimizes future code changes.

---

# Part 3 - Debugging Observations

Given Script:

```csharp
public class CoinManager : MonoBehaviour
{
    public GameObject coinPrefab;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(coinPrefab);
        }
    }
}
```

## Issues Identified

1. **No Spawn Position**

   * The coin is instantiated without specifying a position or rotation.

2. **No Null Check**

   * If `coinPrefab` is not assigned, the script will throw an error.

3. **Mixing Responsibilities**

   * The CoinManager is handling both input and spawning.
   * Input handling should be placed in a separate player input script.

4. **Unlimited Instantiation**

   * Pressing Space repeatedly creates unlimited objects, which may affect performance.

5. **Object Pooling**

   * Frequently instantiated objects should use Object Pooling instead of repeated Instantiate calls.

---

# Part 4 - Design Decisions

## How have you structured your project?

The project is organized into separate folders for Managers, Player, and Interactable scripts. Each script has a single responsibility, making the code easier to understand, maintain, and extend.

---

## If another developer joined tomorrow, how would they understand your code?

The project uses clear naming conventions and a feature-based folder structure. Responsibilities are separated, allowing another developer to quickly locate gameplay, UI, audio, or interaction logic without reading the entire project.

---

## If you had another day, what would you improve?

* Add Object Pooling where appropriate.
* Add interaction highlighting when looking at objects.
* Improve UI animations and transitions.
* Use ScriptableObjects for configurable interaction data.
* Add comments and XML documentation for public methods.
* Improve overall visual polish and game feedback.

---

# Summary

This project focuses on clean architecture, reusable code, and separation of responsibilities. The interaction system is designed to be easily extended from three cubes to many different interactable objects with minimal code changes.
