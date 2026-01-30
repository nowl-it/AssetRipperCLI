# AssetRipper

[![](https://img.shields.io/github/downloads/AssetRipper/AssetRipper/total.svg)](https://github.com/AssetRipper/AssetRipper/releases)
[![](https://img.shields.io/github/downloads/AssetRipper/AssetRipper/latest/total.svg)](https://github.com/AssetRipper/AssetRipper/releases/latest)
[![](https://img.shields.io/github/v/release/AssetRipper/AssetRipper)](https://github.com/AssetRipper/AssetRipper/releases/latest)
[![](https://weblate.samboy.dev/widgets/assetripper/-/gui/svg-badge.svg)](http://weblate.samboy.dev/engage/assetripper/)

AssetRipper is a tool for extracting assets from Unity serialized files (_CAB-_\*, _\*.assets_, _\*.sharedAssets_, etc.) and asset bundles (_\*.unity3d_, _\*.bundle_, etc.) and converting them into the native Unity engine format.

AssetRipper supports Unity versions from `3.5.0` to `6000.2.X`. However, support quality may vary slightly for different Unity versions.

# Usage

AssetRipper can be used in two modes:

## GUI Mode (Default)

Simply run the application without any arguments to launch the web-based interface:

```bash
AssetRipper
```

## CLI Mode

For command-line automation and scripting, use the `--cli` flag:

```bash
# Basic usage
AssetRipper --cli -i "/path/to/game" -o "/path/to/output"

# With custom settings
AssetRipper --cli -i "/path/to/game" -o "/path/to/output" --export-mode Unity --ignore-streaming-assets
```

### CLI Options

- `-i, --input` - Path to Unity game folder or file (required)
- `-o, --output` - Output directory for exported assets (required)
- `--export-mode` - Export format: `Unity` (editable project) or `Primary` (raw assets)
- `--script-content-level` - Script export detail: `Level0` (full), `Level1` (stubs), `Level2` (minimal)
- `--ignore-streaming-assets` - Skip StreamingAssets folder
- `--disable-script-import` - Don't import script files
- `--log-level` - Logging verbosity: `Verbose`, `Info`, `Warning`, `Error`
- `--quiet` - Suppress all console output

For complete CLI documentation, see [CLI_GUIDE.md](docs/CLI_GUIDE.md) or run:

```bash
AssetRipper --help
```

# Premium Edition

[Patreon](https://www.patreon.com/ds5678) supporters at the `Premium` tier or higher receive access to the premium edition of AssetRipper. This edition includes additional [features and improvements](https://assetripper.github.io/AssetRipper/articles/PremiumFeatures.html).

# Donations

Your support helps maintain and improve AssetRipper. If you find this tool useful, please consider donating:

- [GitHub Sponsors](https://github.com/sponsors/ds5678)
- [Patreon](https://www.patreon.com/ds5678)
- [PayPal](https://paypal.me/ds5678)

Patreon donors receive special roles on our [Discord server](https://discord.gg/XqXa53W2Yh).

# Links

[Website](https://assetripper.github.io/AssetRipper/)

[Downloads](https://assetripper.github.io/AssetRipper/articles/Downloads.html)

[Road Map](https://assetripper.github.io/AssetRipper/articles/RoadMap.html)

[Credits](https://assetripper.github.io/AssetRipper/articles/Credits.html)

# Discord [![](https://img.shields.io/discord/867514400701153281?color=blue&label=AssetRipper)](https://discord.gg/XqXa53W2Yh)

The development of this project has a dedicated [Discord server](https://discord.gg/XqXa53W2Yh).

# Legal Disclaimers

AssetRipper is licensed under the [GNU General Public License v3.0](LICENSE.md).

Please be aware that using or distributing the output from this software may be against copyright legislation in your jurisdiction. You are responsible for ensuring that you're not breaking any laws.

This software is not sponsored by or affiliated with Unity Technologies or its affiliates. "Unity" is a registered trademark of Unity Technologies or its affiliates in the U.S. and elsewhere.
