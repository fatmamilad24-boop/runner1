# Runner Subway Game

**Author:** Fatema Milad
**Student ID:** 232400612

---

## Description

Runner Subway Game is a Unity-based 3D runner game where the player navigates through lanes, collects coins, and avoids obstacles. The game features smooth player movement, dynamic lighting, and interactive sound effects. All characters and scenes were created from scratch without using ready-made environments.

---

## Features

* **Player Movement:** Smooth lane switching and forward motion
* **Jump & Fall:** Controlled with arrow keys (Up → Jump, Down → Fall)
* **Animations:** Running, jumping, and falling (with controlled physics)
* **Menu System:** Play, Replay, Resume, Quit
* **Sound Effects:** Coin collection and game feedback sounds
* **Collectibles:** Coins to increase score
* **Dynamic Lighting:** Light follows the player for visual enhancement

---

## Scripts

* `PlayerMovement`: Controls forward motion and lane switching
* `PlayerJumpFall`: Handles jump, fall, and collision with trees
* `ScoreManager`: Tracks player score
* `TimerManager`: Tracks gameplay time
* `CoinCollectible`: Detects coin pickups
* `PauseManager`: Pause and resume game

---

## Challenges Faced

* Implementing a full ready-made environment caused heavy lag
* Running and falling animations sometimes made the player fall through the road or get stuck
* Collision detection issues with obstacles and trees

---

## How to Play

1. Open the Unity project in **Unity Editor**.
2. Press **Play** to start the game.
3. Use the arrow keys:

   * **Up Arrow** → Jump
   * **Down Arrow** → Force fall
   * **Left/Right Arrow** → Switch lanes
4. Collect coins and avoid obstacles.

---

## Demo Video

Include a short gameplay video in the presentation to showcase player movement, coin collection, and menu interactions.

---

## Future Improvements

* Add more obstacle types and environment variety
* Implement more polished animations for jump and fall
* Add scoring UI enhancements and power-ups
