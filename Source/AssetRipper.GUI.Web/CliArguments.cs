using AssetRipper.Import.Configuration;
using Ookii.CommandLine;
using System.ComponentModel;

namespace AssetRipper.GUI.Web;

/// <summary>
/// Command-line arguments for CLI mode (non-interactive)
/// </summary>
[GeneratedParser]
[ParseOptions(IsPosix = true)]
internal sealed partial class CliArguments
{
	[CommandLineArgument("input", ShortName = 'i', IsPositional = true)]
	[Description("Input path to Unity game files or directory to load.")]
	public string? InputPath { get; set; }

	[CommandLineArgument("output", ShortName = 'o')]
	[Description("Output path where assets will be exported. If not provided, assets will only be loaded.")]
	public string? OutputPath { get; set; }

	[CommandLineArgument("mode", ShortName = 'm', DefaultValue = "unity")]
	[Description("Export mode: 'unity' (full Unity project) or 'primary' (raw assets only). Default: unity")]
	public string? ExportMode { get; set; }

	[CommandLineArgument("create-subfolder", DefaultValue = false)]
	[Description("Create a timestamped subfolder in the output directory. Default: false")]
	public bool CreateSubfolder { get; set; }

	[CommandLineArgument("script-content-level", DefaultValue = null)]
	[Description("Script content level: Level0 (all code), Level1 (stubs), Level2 (minimal). Default: from config")]
	public ScriptContentLevel? ScriptContentLevel { get; set; }

	[CommandLineArgument("ignore-streaming-assets", DefaultValue = null)]
	[Description("Ignore StreamingAssets folder during import. Default: from config")]
	public bool? IgnoreStreamingAssets { get; set; }

	[CommandLineArgument("disable-script-import", DefaultValue = null)]
	[Description("Disable script import completely (sets ScriptContentLevel to Level0). Default: from config")]
	public bool? DisableScriptImport { get; set; }

	[CommandLineArgument("publicize-assemblies", DefaultValue = null)]
	[Description("Make internal types public in exported assemblies. Default: from config")]
	public bool? PublicizeAssemblies { get; set; }

	[CommandLineArgument("language", ShortName = 'l', DefaultValue = null)]
	[Description("Language code for localization (e.g., en_US, ja, ko). Default: from config")]
	public string? LanguageCode { get; set; }

	[CommandLineArgument("log", DefaultValue = true)]
	[Description("Enable logging to file. Default: true")]
	public bool Log { get; set; }

	[CommandLineArgument("log-path", DefaultValue = null)]
	[Description("Custom log file path. Default: auto-generated in current directory")]
	public string? LogPath { get; set; }

	[CommandLineArgument("save-settings", DefaultValue = false)]
	[Description("Save the provided settings as defaults for future runs. Default: false")]
	public bool SaveSettings { get; set; }

	[CommandLineArgument("cli", DefaultValue = false)]
	[Description("Run in CLI mode (non-interactive, no web interface). Default: false")]
	public bool CliMode { get; set; }
}
