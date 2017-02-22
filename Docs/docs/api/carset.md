# CarSet

A CarSet represents a set of teams and drivers that can be exported together to a GP.EXE.



## Constructors

| Name            | Description        |
|-----------------|--------------------|
| CarSet() |  Initializes a new instance of a CarSet. 


## Properties

| Name            | Description        |
|-----------------|--------------------|
| Teams   |  List of 18 teams. 


## Methods

| Name            | Description        |
|-----------------|--------------------|
| Drivers   |  Get all Drivers as a single list. 
| Export(Entities.ImportExportSettings settings, GpExeFile exeFile)   |  Exports the CarSet to the specified GP.EXE file.
            
Does not create or set a name file to use.<br />*settings:* ImportExportSettings defining what to export.<br />*exeFile:* GpExeFile.<br /> 
| Export(Entities.ImportExportSettings settings, GpExeFile exeFile, Entities.PreferencesFile preferencesFile, String nameFilePath)   |  Exports the CarSet to the specified GP.EXE file.
            
Only exports the items that have been set to true in the provided ImportExportSettings.
Will create the name file specified in nameFilePath, and set it to load automatically.<br />*settings:* ImportExportSettings defining what to export.<br />*exeFile:* GpExeFile<br />*preferencesFile:* PreferencesFile.<br />*nameFilePath:* Relative path to the name file to create.<br /> 
| Import(GpExeFile exeFile, Entities.NameFile nameFile)   |  Imports all settings into the current CarSet object.<br />*exeFile:* GpExeFile to import data from.<br />*nameFile:* NameFile to import team and driver names from.<br /> 
| Import(Entities.ImportExportSettings settings, GpExeFile exeFile, Entities.NameFile nameFile)   |  Imports the specified settings into the current CarSet object.<br />*settings:* ImportExportSettings defining what to import.<br />*exeFile:* GpExeFile to import data from.<br />*nameFile:* NameFile to import team and driver names from.<br /> 
| Import(Entities.CarSet carSet, Entities.ImportExportSettings settings, GpExeFile exeFile, Entities.NameFile nameFile)   |  Imports the specified settings into an existing CarSet object.<br />*carSet:* CarSet to import data into.<br />*settings:* ImportExportSettings defining what to import.<br />*exeFile:* GpExeFile to import data from.<br />*nameFile:* NameFile to import team and driver names from.<br /> 


