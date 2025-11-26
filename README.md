# 🎮 Rock Paper Scissors Game

A fun and interactive Rock Paper Scissors game built with **Unity** featuring animations, sound effects, and engaging UI.

---

## 📋 Table of Contents

- [Game Overview](#game-overview)
- [Features](#features)
- [How to Play](#how-to-play)
- [Controls](#controls)
- [Installation & Setup](#installation--setup)
- [Game Scenes](#game-scenes)
- [Scripts Overview](#scripts-overview)
- [Customization](#customization)
- [Troubleshooting](#troubleshooting)

---

## 🎯 Game Overview

**Rock Paper Scissors** is a classic hand game brought to life in Unity. You compete against an AI computer opponent in a best-of-5 match. The game features smooth animations, dynamic sound effects, and visual feedback for every action.

**Winning Condition:** First player to reach **5 points** wins the game!

---

## ✨ Features

✅ **Interactive Gameplay**
- Click buttons to make your choice (Rock, Paper, or Scissors)
- Computer makes random selections
- Real-time score tracking

✅ **Audio Effects**
- Button click sounds
- Choice-specific sound effects
- Win/Lose/Draw result sounds
- Background music support

✅ **Visual Effects**
- Bouncing & rotating title animation
- Hand gesture shake animations
- Button highlighting when clicked
- Victory/Defeat screens with shaking text

✅ **Multi-Scene Navigation**
- Main Menu with tutorials
- Gameplay scene
- Victory screen
- Defeat screen
- Tutorial/Help scene

✅ **Custom Font Support**
- Uses ALPnL custom font for stylish text
- Easy font customization

---

## 🎮 How to Play

### Game Rules
- **Rock** beats **Scissors**
- **Paper** beats **Rock**
- **Scissors** beats **Paper**
- Same choice = **Draw** (no points awarded)

### Gameplay Steps
1. **Start the game** from Main Menu
2. **Click one of three buttons:** Rock, Paper, or Scissors
3. **Computer makes its choice** automatically
4. **Result is displayed** in the center
5. **Scores update** in real-time
6. **First to 5 wins** advances to victory screen

### Round Results
- **"You Win!"** - Your choice beat the computer's
- **"Computer Wins!"** - Computer's choice beat yours
- **"Draw!"** - Both chose the same hand

---

## 🕹️ Controls

| Action | Button/Control |
|--------|----------------|
| Play Game | Click "PLAY" button |
| View Tutorial | Click "TUTORIALS" button |
| Choose Rock | Click "Rock" button (in game) |
| Choose Paper | Click "Paper" button (in game) |
| Choose Scissors | Click "Scissors" button (in game) |
| Play Again | Click "PLAY AGAIN" button (victory screen) |
| Return to Menu | Click "BACK" button |

---

## 💾 Installation & Setup

### Requirements
- Unity 2022.3+ (or compatible version)
- TextMeshPro (included with Unity)

### Steps
1. **Open the project** in Unity
2. **Navigate to Assets/Scenes**
3. **Open "Main Menu"** scene
4. **Press Play** to start the game

### First-Time Setup
1. Import your **audio files** into `Assets/Audio/` folder
2. Import your **font file** into `Assets/Fonts/` folder
3. Assign sounds in each scene's scripts (see Customization)

---

## 🎬 Game Scenes

### 1. **Main Menu** (Menu Entry Point)
- Title: "ROCK PAPER AND SCISSORS" with bouncing animation
- Two main buttons: Play & Tutorials
- Background music (optional)
- Button click sounds

### 2. **SampleScene** (Main Gameplay)
- Game board with two hand displays
- Three choice buttons (Rock, Paper, Scissors)
- Score display
- Result message in center
- Button highlighting on click

### 3. **WeWin** (Victory Screen)
- "CONGRATULATION YOU WIN" message
- Shaking text animation
- Victory sound effect
- "PLAY AGAIN" button
- "BACK" button

### 4. **BotWin** (Defeat Screen)
- "BOT WINS" message
- Shaking text animation
- Defeat sound effect
- "PLAY AGAIN" button
- "BACK" button

### 5. **Tutorial** (Help/Instructions)
- Game rules and instructions
- "BACK" button to return to menu

---

## 📝 Scripts Overview

### **MainMenu.cs**
- Handles Main Menu interactions
- Plays button click sounds
- Manages scene transitions
- Implements title bouncing & rotating animation

**Key Methods:**
- `PlayGame()` - Load game scene
- `PlayTutorial()` - Load tutorial scene
- `BounceAnimation()` - Title animation coroutine

### **GameManager.cs** (ButtonChoice.cs)
- Controls all gameplay logic
- Manages scoring system
- Handles win/lose/draw detection
- Plays choice and result sounds
- Highlights clicked buttons

**Key Methods:**
- `OnPlayerChoice(int choice)` - Called when button clicked
- `CheckWinCondition()` - Determines game winner
- `PlayChoiceSound()` - Plays choice sound effect
- `HighlightButton()` - Highlights selected button

### **backToMainScreen.cs**
- Handles victory/defeat screen buttons
- Manages scene transitions with sound

**Key Methods:**
- `PlayAgain()` - Reload game scene
- `BackToMenu()` - Return to main menu

### **backToHome.cs**
- Handles Tutorial scene back button
- Returns to main menu with sound

### **WeWinScreen.cs**
- Victory screen animations and sounds
- Text shaking effect

### **BotWinScreen.cs**
- Defeat screen animations and sounds
- Text shaking effect

---

## 🎨 Customization

### Change Colors
1. Select UI element in scene
2. Find **Image** or **Text** component
3. Modify **Color** property

### Change Fonts
1. Select text element
2. In **TextMeshPro** component
3. Change **Font Asset** field
4. Select your imported font

### Adjust Animations
- **Title Bounce Speed:** MainMenu script → `Bounce Speed` (1.5 recommended)
- **Title Bounce Height:** MainMenu script → `Bounce Height` (15 recommended)
- **Hand Shake Amount:** GameManager script → `shakeAmount` variable

### Add/Change Sounds
1. **Import audio files** into Assets/Audio/
2. **Select the script** that needs sound
3. **Drag audio file** into the audio clip field in Inspector

### Modify Winning Score
1. Open **GameManager.cs** (ButtonChoice.cs)
2. Find `private const int WINNING_SCORE = 5;`
3. Change `5` to desired value

---

## 🐛 Troubleshooting

| Problem | Solution |
|---------|----------|
| Sounds not playing | Check audio clips are assigned in Inspector |
| Buttons don't respond | Verify button's On Click event calls correct method |
| Score not updating | Check TextYou and TextCom are assigned |
| Hand images not showing | Verify handSprites array has 3 sprites in correct order |
| Scene won't load | Ensure scene names match exactly in code |
| Text not bouncing | Assign title text to Title Text field in MainMenu script |
| Font looks wrong | Create Font Asset from .ttf file before assigning |

---

## 🎵 Audio Setup Guide

### Required Audio Files
1. **Rock sound** - Choice effect for rock
2. **Paper sound** - Choice effect for paper
3. **Scissors sound** - Choice effect for scissors
4. **Win sound** - Victory result
5. **Lose sound** - Defeat result
6. **Draw sound** - Draw result
7. **Button click sound** - Menu/screen buttons
8. **Background music** (optional)

### Where to Add Them
- **Game Scene:** GameManager script
- **Menu:** MainMenu script
- **Tutorial:** backToHome script
- **Victory/Defeat:** backToMainScreen script

---

## 📊 Score System

- **Win:** +1 point to winner
- **Lose:** +1 point to loser
- **Draw:** No points awarded
- **Match Win:** First to 5 points

---

## 🎓 Tips for Playing

1. **No Strategy Needed** - Computer is random, just have fun!
2. **Quick Rounds** - Each round is fast-paced
3. **Watch Animations** - Enjoy the visual effects
4. **Play Multiple Games** - Try different strategies
5. **Use Tutorials** - Learn the rules if needed

---

## 📱 Supported Platforms

- Windows
- macOS
- Linux
- Web (WebGL)
- Mobile (Android/iOS with adjustments)

---

## 🔧 Development Notes

### Code Structure
- Clean, modular script design
- Coroutines for smooth animations
- TextMeshPro for professional text
- AudioSource for sound playback

### Performance
- Optimized animations using coroutines
- Efficient scene management
- Minimal memory footprint

### Future Enhancement Ideas
- Difficulty levels
- Multiplayer support
- Leaderboard system
- More visual effects
- Power-ups
- Different game modes

---

## 📄 License

This game is created for educational purposes. Feel free to modify and enhance it!

---

## 🎮 Enjoy the Game!

Have fun playing **Rock Paper Scissors**! May the best player win! 🏆

For any issues or questions, check the Troubleshooting section or review the script comments.

---

**Version:** 1.0  
**Last Updated:** November 2025  
**Engine:** Unity 2022.3+