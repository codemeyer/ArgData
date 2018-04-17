# PreferencesWriter

Writes preferences to the F1PREFS.DAT file.

## Methods

| Name  | Description  |
|-------|--------------|
| For(PreferencesFile *preferencesFile*)  | Creates a PreferencesWriter for the specified F1PREFS.DAT file.<br />*preferencesFile*: PreferencesFile to read from.<br />  |
| SetAutoLoadedNameFile(String *nameFilePath*)  | Sets the auto-loaded name file.<br />*nameFilePath*: Relative path to F1GP installation. Max 31 chars.<br />  |
| SetAutoLoadedSetupFile(String *setupFilePath*)  | Sets the auto-loaded setup file.<br />*setupFilePath*: Relative path to F1GP installation. Max 31 chars.<br />  |
| DisableAutoLoadedNameFile()  | Disables auto-loading of any name file in the game.  |
| DisableAutoLoadedSetupFile()  | Disables auto-loading of any setup file in the game.  |


