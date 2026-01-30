#!/bin/bash
# AssetRipper CLI Usage Examples

echo "=== AssetRipper CLI Examples ==="
echo ""

# Example 1: Basic Export
echo "1. Basic Unity Project Export"
echo "   AssetRipper -i /path/to/game -o /path/to/export"
echo ""

# Example 2: Raw Assets
echo "2. Export Raw Assets (PNG, WAV, GLB)"
echo "   AssetRipper -i game.apk -o assets --mode primary"
echo ""

# Example 3: Full Configuration
echo "3. Full Configuration"
echo "   AssetRipper -i game -o export \\"
echo "     --mode unity \\"
echo "     --script-content-level Level0 \\"
echo "     --publicize-assemblies true \\"
echo "     --create-subfolder \\"
echo "     --language en_US"
echo ""

# Example 4: Batch Processing
echo "4. Batch Processing Multiple Games"
echo "   for game in /games/*; do"
echo "     AssetRipper -i \"\$game\" -o \"/exports/\$(basename \$game)\" --create-subfolder"
echo "   done"
echo ""

# Example 5: Fast Preview
echo "5. Quick Preview (Fast Mode)"
echo "   AssetRipper -i game -o preview \\"
echo "     --mode primary \\"
echo "     --script-content-level Level2 \\"
echo "     --disable-script-import true"
echo ""

# Example 6: Validation Only
echo "6. Load and Validate (No Export)"
echo "   AssetRipper -i game_files"
echo ""

# Example 7: Modding Setup
echo "7. Modding Project Setup"
echo "   AssetRipper -i game -o mod_project \\"
echo "     --publicize-assemblies true \\"
echo "     --script-content-level Level0 \\"
echo "     --save-settings"
echo ""

# Example 8: CI/CD Pipeline
echo "8. CI/CD Integration"
echo "   AssetRipper -i \$BUILD_DIR -o \$OUTPUT_DIR \\"
echo "     --create-subfolder \\"
echo "     --log-path \$CI_LOG_PATH \\"
echo "     --script-content-level Level1"
echo ""

echo "For more details, see docs/CLI_GUIDE.md"
