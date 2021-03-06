// Fill out your copyright notice in the Description page of Project Settings.

using UnrealBuildTool;
using System.IO;
using System;

public class FicsItNetworks : ModuleRules
{
    public FicsItNetworks(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(new string[] {
            "Core", "CoreUObject",
            "Engine",
            "InputCore",
            "OnlineSubsystem", "OnlineSubsystemUtils", "OnlineSubsystemNULL",
            "SignificanceManager",
            "PhysX", "APEX", "PhysXVehicles", "ApexDestruction",
            "AkAudio",
            "ReplicationGraph",
            "UMG",
            "AIModule",
            "NavigationSystem",
            "AssetRegistry",
            "GameplayTasks",
            "AnimGraphRuntime",
            "Slate", "SlateCore",
            "Json",
            "ApplicationCore",
            "Vorbis"
            });


        if (Target.Type == TargetRules.TargetType.Editor) {
			PublicDependencyModuleNames.AddRange(new string[] {"OnlineBlueprintSupport", "AnimGraph"});
		}
        PublicDependencyModuleNames.AddRange(new string[] {"FactoryGame", "SML"});

        string platformName = Enum.GetName(typeof(UnrealTargetPlatform), Target.Platform);
        string projectFilePath = Target.ProjectFile.ToString();
        string projectRootPath = projectFilePath.Substring(0, projectFilePath.LastIndexOf(Path.DirectorySeparatorChar));
        string fullLibPath = Path.Combine(projectRootPath, "Library", platformName);
        Console.WriteLine("Full Library Path: " + fullLibPath);
        PublicAdditionalLibraries.AddRange(new string[] {
            Path.Combine(fullLibPath, "lua53.lib")
        });
        
        bEnableExceptions = true;
        bUseRTTI = true;
    }
}
