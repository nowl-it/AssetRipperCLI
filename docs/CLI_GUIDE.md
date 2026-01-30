# AssetRipper CLI Usage Guide

## 🚀 Quick Start

AssetRipper can now run in two modes:

1. **Web Interface Mode** (default) - Interactive browser-based UI
2. **CLI Mode** - Command-line non-interactive batch processing

---

## 📖 CLI Mode Usage

### Basic Syntax

```bash
# Load and export in one command
AssetRipper --cli --input <path> --output <path>

# Or use short form
AssetRipper -i <input> -o <output>
```

### Examples

#### 1. Load and Export Unity Project

```bash
# Export as full Unity project
AssetRipper --cli --input /path/to/game --output /path/to/export

# Short form
AssetRipper -i /path/to/game -o /path/to/export
```

#### 2. Export Only Raw Assets (Primary Content)

```bash
# Export textures, audio, models as PNG, WAV, GLB
AssetRipper --cli -i /path/to/game -o /path/to/export --mode primary

# Or use 'raw' alias
AssetRipper -i /path/to/game -o /path/to/export -m raw
```

#### 3. Load Without Exporting

```bash
# Just load and process (useful for validation)
AssetRipper --cli --input /path/to/game
```

#### 4. Create Timestamped Subfolder

```bash
# Exports to /output/AssetRipper_export_20260129_143022/
AssetRipper -i game.unity3d -o /output --create-subfolder
```

---

## ⚙️ Configuration Options

### Script Processing

```bash
# Full script recovery (slowest, most complete)
AssetRipper -i game -o export --script-content-level Level0

# Method stubs only (faster)
AssetRipper -i game -o export --script-content-level Level1

# Minimal script info (fastest)
AssetRipper -i game -o export --script-content-level Level2

# Disable script import completely
AssetRipper -i game -o export --disable-script-import true
```

### Assembly Processing

```bash
# Make internal types public (useful for modding)
AssetRipper -i game -o export --publicize-assemblies true
```

### Import Options

```bash
# Ignore StreamingAssets folder
AssetRipper -i game -o export --ignore-streaming-assets true
```

### Localization

```bash
# Use Japanese localization
AssetRipper -i game -o export --language ja

# Available: en_US, ja, ko, zh_Hans, zh_Hant, fr, de, es, etc.
AssetRipper -i game -o export -l ko
```

### Logging

```bash
# Disable logging
AssetRipper -i game -o export --log false

# Custom log path
AssetRipper -i game -o export --log-path /var/log/assetripper.log
```

### Save Settings

```bash
# Save these settings as defaults for future runs
AssetRipper -i game -o export --script-content-level Level1 --save-settings
```

---

## 🎯 Complete Example

```bash
# Full featured export with all options
AssetRipper \
  --cli \
  --input /games/MyGame/Data \
  --output /exports/MyGame \
  --mode unity \
  --create-subfolder \
  --script-content-level Level0 \
  --publicize-assemblies true \
  --ignore-streaming-assets false \
  --language en_US \
  --log-path /logs/assetripper.log \
  --save-settings
```

---

## 📋 All CLI Arguments

| Argument                    | Short | Type   | Description                                               |
| --------------------------- | ----- | ------ | --------------------------------------------------------- |
| `--input`                   | `-i`  | string | **Required**. Input path to Unity game files or directory |
| `--output`                  | `-o`  | string | Output path for exported assets                           |
| `--mode`                    | `-m`  | string | Export mode: `unity` (default) or `primary`/`raw`         |
| `--create-subfolder`        |       | bool   | Create timestamped subfolder in output                    |
| `--script-content-level`    |       | enum   | Script recovery level: `Level0`, `Level1`, `Level2`       |
| `--ignore-streaming-assets` |       | bool   | Skip StreamingAssets folder                               |
| `--disable-script-import`   |       | bool   | Disable script import completely                          |
| `--publicize-assemblies`    |       | bool   | Make internal types public                                |
| `--language`                | `-l`  | string | Language code (e.g., `en_US`, `ja`)                       |
| `--log`                     |       | bool   | Enable/disable file logging (default: true)               |
| `--log-path`                |       | string | Custom log file path                                      |
| `--save-settings`           |       | bool   | Save settings as defaults                                 |
| `--cli`                     |       | bool   | Force CLI mode (auto-detected from `--input`)             |

---

## 🌐 Web Interface Mode (Default)

When run without CLI arguments, AssetRipper starts the web interface:

```bash
# Start web interface on random port
AssetRipper

# Start on specific port
AssetRipper --port 8080

# Start without auto-launching browser
AssetRipper --launch-browser=false

# Combine options
AssetRipper --port 8080 --launch-browser=false --log-path custom.log
```

### Web Mode Arguments

| Argument           | Type     | Default    | Description                  |
| ------------------ | -------- | ---------- | ---------------------------- |
| `--port`           | int      | 0 (random) | Web server port              |
| `--launch-browser` | bool     | true       | Auto-open browser            |
| `--log`            | bool     | true       | Enable logging               |
| `--log-path`       | string   | auto       | Log file path                |
| `--local-web-file` | string[] |            | Replace online web resources |

---

## 🔄 Mode Detection

AssetRipper automatically detects the mode:

- **CLI Mode**: When `--cli`, `--input`, or `-i` is present
- **Web Mode**: All other cases

```bash
# These all trigger CLI mode:
AssetRipper --cli
AssetRipper --input game
AssetRipper -i game

# These trigger Web mode:
AssetRipper
AssetRipper --port 8080
AssetRipper --launch-browser=false
```

---

## 💡 Tips & Best Practices

### 1. Test First

```bash
# Load without exporting to check for errors
AssetRipper -i game_files
```

### 2. Use Timestamped Exports

```bash
# Prevents overwriting previous exports
AssetRipper -i game -o exports --create-subfolder
```

### 3. Fast Previews

```bash
# Quick export for preview (raw assets only)
AssetRipper -i game -o preview -m raw --script-content-level Level2
```

### 4. Full Recovery

```bash
# Complete project with full scripts
AssetRipper -i game -o full_project -m unity --script-content-level Level0
```

### 5. Batch Processing

```bash
#!/bin/bash
# Process multiple games
for game in /games/*; do
  AssetRipper -i "$game" -o "/exports/$(basename $game)" --create-subfolder
done
```

### 6. Pipeline Integration

```bash
# Exit codes: 0 = success, 1 = error
AssetRipper -i game -o export || echo "Export failed!"
```

---

## 📊 Output Structure

### Unity Project Mode (`--mode unity`)

```
export/
├── Assets/
│   ├── Scenes/
│   ├── Prefabs/
│   ├── Materials/
│   ├── Textures/
│   ├── Scripts/
│   └── Resources/
├── ProjectSettings/
│   └── ProjectVersion.txt
├── Packages/
│   └── manifest.json
└── StreamingAssets/
```

### Primary Content Mode (`--mode primary`)

```
export/
├── Texture2D/
│   ├── icon.png
│   └── background.png
├── Mesh/
│   └── character.glb
├── AudioClip/
│   └── music.wav
└── MonoScript/
    └── PlayerController.cs
```

---

## 🚨 Error Handling

Exit codes:

- `0`: Success
- `1`: Error (invalid input, export failure, etc.)

Errors are logged to:

- Console (stderr)
- Log file (if enabled)

```bash
# Check exit code
AssetRipper -i game -o export
echo $?  # 0 on success, 1 on error

# Redirect errors
AssetRipper -i game -o export 2> errors.log
```

---

## 📝 Settings File

Settings are stored in:

- Windows: `%APPDATA%/AssetRipper/Settings.json`
- Linux: `~/.config/AssetRipper/Settings.json`
- macOS: `~/Library/Application Support/AssetRipper/Settings.json`

You can:

1. Edit manually
2. Save from CLI: `--save-settings`
3. Configure via Web UI

---

## 🔍 Help Command

```bash
# Show help for web mode
AssetRipper --help

# Show help for CLI mode (when available)
AssetRipper --cli --help
```

---

## 🎓 Common Use Cases

### Game Modding

```bash
AssetRipper -i game -o mod_project \
  --mode unity \
  --publicize-assemblies true \
  --script-content-level Level0
```

### Asset Extraction

```bash
AssetRipper -i game.apk -o assets \
  --mode primary \
  --disable-script-import true
```

### Research/Analysis

```bash
AssetRipper -i game -o analysis \
  --mode unity \
  --script-content-level Level1 \
  --log-path detailed.log
```

### CI/CD Pipeline

```bash
AssetRipper -i $BUILD_DIR -o $OUTPUT_DIR \
  --create-subfolder \
  --log-path $CI_LOG_PATH \
  --script-content-level Level2
```

---

## ⚡ Performance Tuning

- **Faster**: `--mode primary --script-content-level Level2`
- **Balanced**: `--mode unity --script-content-level Level1`
- **Complete**: `--mode unity --script-content-level Level0`

Disable features you don't need:

```bash
AssetRipper -i game -o export \
  --disable-script-import true \
  --ignore-streaming-assets true
```

---

## 🔗 See Also

- [README.md](../README.md) - General information
- [WORKFLOW_ANALYSIS.md](../WORKFLOW_ANALYSIS.md) - Technical workflow details
- [Discord](https://discord.gg/XqXa53W2Yh) - Community support
