# 2D-Unity-Game-scripts

A collection of completed and polished scripts for a 2D platformer game in Unity.

## Unity Version
**Unity 2023.1**

## Scripts Included

### Player Scripts
- **CharacterMovement.cs** - Handles player movement, jumping, climbing stairs, and health system
- **HealthBar.cs** - UI health bar with gradient color feedback

### Enemy Scripts
- **AIPatrol.cs** - Enemy patrol behavior with player detection and chase mechanics
- **EnemyAi.cs** - Alternative enemy AI with force-based movement toward the player
- **EagleDeath.cs** - Handles eagle enemy death when colliding with player
- **FrogDeath.cs** - Handles frog enemy death when colliding with player

### Collectibles & Objects
- **Cherry.cs** - Health pickup collectible
- **Gems.cs** - Score-based collectible that integrates with ScoreManager
- **CrateDestroy.cs** - Destroys crates when they touch spikes

### Managers
- **ScoreManager.cs** - Singleton score manager with TextMeshPro UI integration

## Fixes Applied

### AIPatrol.cs
- Added proper enemy facing direction when chasing player
- Enemy now flips to face the player during chase

### CharacterMovement.cs
- Added `groundLayer` field for better ground detection
- Made `lookingRight` variable private for encapsulation
- Added Escape key to quit application
- Improved code organization

### CrateDestroy.cs
- Fixed logic - now destroys the crate instead of the spike
- Corrected destroy target from `collision.gameObject` to `gameObject`

### Cherry.cs, EagleDeath.cs, FrogDeath.cs, Gems.cs
- Replaced `.tag` property with `CompareTag()` method for better performance
- Added null checks for animator and ScoreManager references
- Fixed call order in death scripts (trigger animation before destroy)

### ScoreManager.cs
- Added proper singleton pattern with `Awake()` method
- Added singleton duplicate prevention
- Made `score` variable private
- Added `UpdateScoreText()` helper method
- Added null check for text field
- Initialized score to 0 on Start

### HealthBar.cs
- No changes needed - script was already complete

## Tags Required
Ensure your Unity project has these tags configured:
- Player
- Platform
- Crate
- Cherry
- Spike
- Stairs
- Hop

## Setup Instructions
1. Assign scripts to appropriate GameObjects
2. Configure public fields in the Inspector
3. Set up required tags in Tag Manager
4. Assign layers for ground detection in CharacterMovement and AIPatrol scripts
