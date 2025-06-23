# 🎇 Unity Interactive Particle Background System

A dynamic Unity visual effect where glowing particles form a black-and-white image and respond to mouse interaction. Ideal for animated backgrounds, splash screens, or creative UI experiences.

---

## ✨ Features

- 🖼️ Converts any **black & white illustration** into a glowing particle formation
- 🧲 Mouse proximity **repels particles**
- 💤 Subtle idle motion gives particles a lively feel
- 🔁 Toggleable UI elements & custom cursors
- 💡 **URP Bloom** integration for glow effect
- 🎥 Supports both **main camera** and **separate particle camera** setups
- 🎛 Fully configurable via the **Unity Inspector**

---

## ⚠️ Requirements & Warnings

- ✅ Only use **black and white images** (greyscale or complex images may crash Unity)
- ✅ Use **Unity URP** (Universal Render Pipeline)
- ✅ Ensure your image is marked as **readable** in the Texture Import Settings
- 🖼️ Recommended canvas size: **1920×1080**
- ⚠️ Avoid complex images with too many details or high resolution
- ❌ Do **not include `Library/`** or Unity will crash during GitHub upload

---

## 🛠️ Setup Instructions

### 📁 Step 1: Import the Package
1. Download or clone this repository
2. Open your Unity project
3. Import the `.unitypackage` via `Assets → Import Package → Custom Package`

---

### 👇 Option A: Use with Main Camera (Simple Scenes)

1. Drag **`ParticleGenerator`**, **`Global Volume`**, and your **`Main Camera`** into the scene
2. In the `ParticleGenerator` script, assign:
   - `Global Volume` (for bloom)
   - `Main Camera`

---

### 👇 Option B: Use with UI or Existing Scene (Separate Camera Setup)

1. Drag in:
   - `ParticleGenerator`
   - `Particle Camera` prefab
2. Create a new Layer (e.g., `Particles`)
3. Assign this Layer to:
   - The **Particle Camera**
   - The **Particle Prefab**
4. Set the **Main Camera** to **exclude** this layer from the Culling Mask
5. In `ParticleGenerator`, assign `Particle Camera` as the rendering camera

---

## 🎛 Customization

| Property                | Description                                     |
|------------------------|-------------------------------------------------|
| `Spacing`              | Distance between particles                      |
| `Particle Size`        | Scale of each particle                          |
| `Idle Amplitude`       | How much particles move in idle state           |
| `Repel Radius`         | How far the mouse affects particles             |
| `Repel Strength`       | How strongly particles move away from cursor    |
| `Bloom Intensity`      | Controls glow strength via Global Volume        |
| `Rotation`             | Rotate full image via camera or prefab rotation |

🛠 You can reposition and rotate the full particle image by adjusting the **camera** that renders the particles.  
📏 To scale the system, scale the camera (it must be **Orthographic**).

---

## 💡 Tips & Troubleshooting

- If **UI text glows too much**, try:
  - Reducing **opacity** or **whiteness**
  - Increasing **threshold** in the Bloom component
- To **disable bloom** entirely, reduce intensity in the Inspector
- To prevent cursor interaction mismatch:
  - Make sure the interaction camera is correctly assigned
  - Use `Camera.ScreenToWorldPoint` carefully with correct Z-depth

---

## 📦 License & Contribution

Free to use and modify for commercial or personal use.  
Give credit if you publish something based on this system. Contributions welcome!

---

Enjoy building with it!  
Made with ❤️ in Unity.
