# cookiecutter-rimworld-mod-development
A cookiecutter project that builds the basic Rimworld mod development file structure and sets up a sane build 
environment. Completely restructured and vastly simplified compared to its predecessor, and updated to function with 
RimWorld 1.1 and the Harmony mod

# Setup
### Required Programs
- [git](https://git-scm.com/downloads)
- [python](https://www.python.org/downloads/)
- [cookiecutter](https://github.com/audreyr/cookiecutter) (or `pip install cookiecutter`)

### Usage
1. `cookiecutter gh:thecodewarrior/cookiecutter-rimworld-mod-development`
0. Answer the prompts
0. Open the folder you just created and double-click the `ModName.sln` file

If you're using a standard steam install of RimWorld then the RimWorld dlls should automatically be detected, if not,
see the [automatic RimWorld detection](#automatic-rimworld-dll-detection) section below.

### Installing the Mod Into RimWorld
As it is your mod won't actually load, since it isn't located in your `RimWorld/Mods` folder. To make it work you'll 
have to [create a symlink](#creating-symlinks) in your `RimWorld/Mods` folder that links to the project's mod folder.
(See [folder structure](#folder-structure) for where this is.) Here are some example commands to install the mod into a
standard Steam installation of the game:
##### Windows command prompt: 
```txt
mklink /D "C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\CoolMod" "%userprofile%\Documents\RimWorld_Mods\CoolMod\CoolMod"
```
##### Linux command line:
```txt
ln -s "~/Documents/RimWorld_Mods/CoolMod/CoolMod" "~/.steam/steam/SteamApps/common/RimWorld/Mods"
```
##### macOS terminal:
```txt
ln -s "~/Documents/RimWorld_Mods/CoolMod/CoolMod" "~/Library/Application Support/Steam/steamapps/common/RimWorld/RimWorldMac.app/Mods"
```

# Folder Structure
This cookiecutter builds the entire standard mod folder structure, with empty folders as the default. `namespace_name` is automatically calculated.
```txt
ModName/ <- This is the project folder
  ModName/ <- This is the actual mod folder
    About/
      About.xml
      Preview.png
    Assemblies/
    ... The rest of the mod files
  ModName.sln
  ModName.sln.DotSettings
  ModName.csproj
  Properties/
    AssemblyInfo.cs
  Source/
    Mod.cs
  ThirdParty/
    0Harmony.dll <- Only used for compiling against. Not included in the output
```

# Automatic RimWorld dll Detection
The `.csproj` file is set up to search in the following locations for the RimWorld dlls:
- A custom install location: `../_RimWorldData/Managed/`
- A Windows Steam install: `C:\Program Files (x86)\Steam\steamapps\common\RimWorld\RimWorldWin64_Data\Managed\`
- A Linux Steam install: `$(HOME)/.steam/steam/SteamApps/common/RimWorld/RimWorldLinux_Data/Managed/`
- A macOS Steam install: `$(HOME)/Library/Application Support/Steam/steamapps/common/RimWorld/RimWorldMac.app/Contents/Resources/Data/Managed/`

For custom install locations, [create a symlink](#creating-symlinks) called `_RimWorldData` next to the project directory 
that points to your custom install's data directory. 

# Creating Symlinks
- Linux/macOS command line: `ln -s <what to point to> <where to make the symlink>`
- Windows command prompt: `mklink /D <where to make the symlink> <what to point to>`
