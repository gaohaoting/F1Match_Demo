# 🏎️ F1 Match - Formula 1 Racing Simulator

A Unity-based F1 racing simulator that provides authentic racing experience and immersive Formula 1 competition environment.

## 📋 Project Overview

F1 Match is a comprehensive F1 racing simulation project featuring official F1 team car models, Shanghai International Circuit, complete UI interface system, and realistic racing physics simulation.

## ✨ Key Features

### �� Racing System
- **Multiple F1 Teams Support**:
  - Red Bull RB19 (2023 Season)
  - Mercedes W14 (2023 Season)
  - Ferrari SF23 (2023 Season)
  - McLaren MCL60 (2023 Season)
  - Aston Martin AMR23 (2023 Season)

### 🏁 Track System
- **Shanghai International Circuit** - Complete 3D track model
- **Realistic Track Elements**:
  - Track textures and materials
  - Barriers and obstacles
  - Pit lane
  - Grandstands and advertising boards

### 🎮 Control System
- **Automatic Path Driving** - Intelligent path system based on DOTween
- **Manual Control Mode** - WASD movement and mouse camera control
- **Realistic Racing Physics** - Including launch, cornering, braking and authentic driving experience

### 🖥️ UI Interface System
- **F1-Style UI Design**:
  - Driver information display
  - Real-time position tracking
  - DRS status indicator
  - Tire and pit stop information
  - Weather and track conditions

### 📊 Data Recording System
- **Transform Recorder** - Record and replay vehicle movement trajectories
- **Performance Data Analysis** - Lap times, speed, position and other key metrics

## 🛠️ Technology Stack

- **Game Engine**: Unity 2022.3 LTS
- **Render Pipeline**: Universal Render Pipeline (URP)
- **Animation System**: DOTween Pro
- **3D Models**: GLB/FBX format
- **Version Control**: Git LFS (Large File Storage)
- **Platform Support**: Windows, macOS, VR (Oculus)

## 📁 Project Structure

```
Assets/
├── F1/                    # F1-specific UI resources
│   └── F1UI/             # F1 interface elements
├── Model/                 # 3D model resources
│   ├── Cars/             # F1 car models
│   │   ├── Red Bull_rb19/
│   │   ├── Mercedes_W14/
│   │   ├── Ferrari_sf23/
│   │   ├── McLaren_mcl60/
│   │   └── AstonMartin_amr23/
│   └── cartoon-race-track-china/  # Shanghai Circuit
├── Scripts/               # Core scripts
│   ├── CarManager.cs     # Car manager
│   ├── Controller.cs     # Controller
│   ├── Waypoints.cs      # Waypoint system
│   └── datarecord/       # Data recording system
├── UI/                    # User interface
│   ├── Driver Identifier/ # Driver identification
│   ├── Race Hub/         # Race center
│   └── Sector/           # Track sectors
└── Scenes/               # Game scenes
    └── F1Scene.unity     # Main F1 scene
```

## 🚀 Installation and Setup

### System Requirements
- Unity 2022.3 LTS or higher
- 8GB RAM (16GB recommended)
- DirectX 11 compatible graphics card
- 10GB available disk space

### Installation Steps

1. **Clone Repository**
   ```bash
   git clone https://github.com/gaohaoting/F1Match_Demo.git
   cd F1Match_Demo
   ```

2. **Open Unity Project**
   - Launch Unity Hub
   - Click "Open" → Select F1Match_Demo folder
   - Wait for project import to complete

3. **Run Project**
   - Open `Assets/Scenes/F1Scene.unity` in Project window
   - Click Play button to start the game

### Control Instructions

#### Automatic Mode
- Car will automatically follow preset path
- System automatically handles launch, cornering and braking

#### Manual Mode
- **W/S**: Forward/Backward
- **A/D**: Left/Right movement
- **Right Mouse Button**: Camera control
- **ESC**: Unlock mouse cursor

## 🎯 Core Features

### Intelligent Driving System
- **Adaptive Speed Control** - Automatically adjust speed based on corners
- **Realistic Launch Simulation** - Progressive acceleration process
- **Corner Optimization** - Intelligent braking and cornering

### Immersive Experience
- **High-Precision 3D Models** - Officially licensed F1 car models
- **Authentic Track Environment** - Complete Shanghai International Circuit
- **Professional UI Design** - F1 official-style interface design

### Data-Driven
- **Performance Tracking** - Real-time recording and analysis of driving data
- **Trajectory Replay** - Support for recording and replaying driving trajectories
- **Statistical Analysis** - Lap times, speed and other key metrics

## 🔧 Development Notes

### Script Architecture
- **CarManager**: Responsible for car path following and speed control
- **Controller**: Handles user input and camera control
- **TransformRecorder**: Records vehicle movement data
- **Waypoints**: Manages waypoint system

### Extensibility
- Support for adding new F1 car models
- Extensible track system
- Modular UI components

## 📄 License

This project is for learning and research purposes only. F1-related brands, logos and models are copyrighted by their respective owners.

## 🤝 Contributing

Issues and Pull Requests are welcome to improve the project!

## 📞 Contact

- **Project URL**: https://github.com/gaohaoting/F1Match_Demo
- **Author**: gaohaoting

---

*Experience the authentic F1 racing world and feel the perfect combination of speed and passion! 🏁*
