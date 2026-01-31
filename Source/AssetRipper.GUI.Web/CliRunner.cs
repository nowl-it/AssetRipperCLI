using AssetRipper.Export.UnityProjects.Configuration;
using AssetRipper.Import.Configuration;
using AssetRipper.Import.Logging;

namespace AssetRipper.GUI.Web;

/// <summary>
/// CLI runner for non-interactive mode - load, process, and export without web interface
/// </summary>
internal static class CliRunner
{
	internal static void RunCliMode(CliArguments args)
	{
		WelcomeMessage.Print();

		// Setup logging
		if (args.Log)
		{
			string logPath = string.IsNullOrEmpty(args.LogPath)
				? Path.Combine(AppContext.BaseDirectory, $"AssetRipper_{DateTime.Now:yyyyMMdd_HHmmss}.log")
				: args.LogPath;
			Logger.Add(new FileLogger(logPath));
		}
		Logger.Add(new ConsoleLogger());
		Logger.LogSystemInformation("AssetRipper CLI");

		// Load settings
		LibraryConfiguration settings = GameFileLoader.Settings;
		ApplyCliSettings(settings, args);
		
		Localization.LoadLanguage(settings.LanguageCode);

		// Set export handler
		GameFileLoader.ExportHandler = new(settings);

		// Validate input
		if (string.IsNullOrEmpty(args.InputPath))
		{
			Logger.Error(LogCategory.General, "No input path specified. Use --input <path>");
			Environment.Exit(1);
			return;
		}

		if (!Directory.Exists(args.InputPath) && !File.Exists(args.InputPath))
		{
			Logger.Error(LogCategory.General, $"Input path does not exist: {args.InputPath}");
			Environment.Exit(1);
			return;
		}

		// Validate output if provided
		if (!string.IsNullOrEmpty(args.OutputPath))
		{
			string? outputDir = Path.GetDirectoryName(args.OutputPath);
			if (!string.IsNullOrEmpty(outputDir) && !Directory.Exists(outputDir))
			{
				try
				{
					Directory.CreateDirectory(outputDir);
				}
				catch (Exception ex)
				{
					Logger.Error(LogCategory.General, $"Failed to create output directory: {ex.Message}");
					Environment.Exit(1);
					return;
				}
			}
		}

		// Load and process
		try
		{
			Logger.Info(LogCategory.General, "=== PHASE 1: LOADING ===");
			string[] paths = Directory.Exists(args.InputPath)
				? [args.InputPath]
				: [args.InputPath];

			GameFileLoader.LoadAndProcess(paths);
			Logger.Info(LogCategory.General, "Successfully loaded and processed assets");
		}
		catch (Exception ex)
		{
			Logger.Error(LogCategory.Import, $"Failed to load assets: {ex.Message}");
			Logger.Error(ex);
			Environment.Exit(1);
			return;
		}

		// Export if output path is provided
		if (!string.IsNullOrEmpty(args.OutputPath))
		{
			try
			{
				Logger.Info(LogCategory.General, "=== PHASE 2: EXPORTING ===");

				string exportPath = args.OutputPath;
				if (args.CreateSubfolder)
				{
					string timestamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");
					string subfolder = $"AssetRipper_export_{timestamp}";
					exportPath = Path.Combine(args.OutputPath, subfolder);
				}

				switch (args.ExportMode?.ToLowerInvariant())
				{
					case "primary":
					case "raw":
						Logger.Info(LogCategory.Export, "Export mode: Primary Content (raw assets)");
						GameFileLoader.ExportPrimaryContent(exportPath);
						break;
					case "unity":
					case "project":
					case null:
					default:
						Logger.Info(LogCategory.Export, "Export mode: Unity Project");
						GameFileLoader.ExportUnityProject(exportPath);
						break;
				}

				Logger.Info(LogCategory.General, $"Successfully exported to: {exportPath}");
			}
			catch (Exception ex)
			{
				Logger.Error(LogCategory.Export, $"Failed to export assets: {ex.Message}");
				Logger.Error(ex);
				Environment.Exit(1);
				return;
			}
		}
		else
		{
			Logger.Info(LogCategory.General, "No output path specified. Assets loaded but not exported.");
			Logger.Info(LogCategory.General, "Use --output <path> to export assets.");
		}

		Logger.Info(LogCategory.General, "=== COMPLETED ===");
	}

	private static void ApplyCliSettings(LibraryConfiguration settings, CliArguments args)
	{
		// Handle DisableScriptImport first (it affects ScriptContentLevel)
		if (args.DisableScriptImport.HasValue && args.DisableScriptImport.Value)
		{
			// DisableScriptImport is achieved by setting ScriptContentLevel to Level0
			settings.ImportSettings.ScriptContentLevel = ScriptContentLevel.Level0;
			Logger.Info(LogCategory.General, "DisableScriptImport: true (ScriptContentLevel set to Level0)");
		}
		else if (args.ScriptContentLevel.HasValue)
		{
			// Only set ScriptContentLevel if DisableScriptImport is not true
			settings.ImportSettings.ScriptContentLevel = args.ScriptContentLevel.Value;
			Logger.Info(LogCategory.General, $"ScriptContentLevel set to: {args.ScriptContentLevel.Value}");
		}

		if (args.IgnoreStreamingAssets.HasValue)
		{
			settings.ImportSettings.IgnoreStreamingAssets = args.IgnoreStreamingAssets.Value;
			Logger.Info(LogCategory.General, $"IgnoreStreamingAssets: {args.IgnoreStreamingAssets.Value}");
		}

		if (args.PublicizeAssemblies.HasValue)
		{
			settings.ProcessingSettings.PublicizeAssemblies = args.PublicizeAssemblies.Value;
			Logger.Info(LogCategory.General, $"PublicizeAssemblies: {args.PublicizeAssemblies.Value}");
		}

		if (!string.IsNullOrEmpty(args.LanguageCode))
		{
			settings.LanguageCode = args.LanguageCode;
			Logger.Info(LogCategory.General, $"Language: {args.LanguageCode}");
		}

		// Save settings if requested
		if (args.SaveSettings)
		{
			settings.SaveToDefaultPath();
			Logger.Info(LogCategory.General, "Settings saved to default path");
		}
	}
}
