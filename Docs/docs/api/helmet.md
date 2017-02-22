# Helmet

A Helmet represents a helmet with its various colors.



## Constructors

| Name            | Description        |
|-----------------|--------------------|
| Helmet() |  Initializes a new instance of a Helmet with all colors set to 0 (black). 
| Helmet(Byte[] helmetColorBytes) |  Initializes a new instance of a Helmet with the specified colors.<br />*helmetColorBytes:* The colors to set. Must be exactly 14 or 16 bytes.<br /> 


## Properties

| Name            | Description        |
|-----------------|--------------------|
| Stripes   |  Gets or sets the color of the 13 horizontal stripes of the helmet. 
| Visor   |  Gets or sets the color of the visor. Default is 0. 
| VisorSurround   |  Gets or sets the color of the visor surround. Default is 6. 


## Methods

| Name            | Description        |
|-----------------|--------------------|
| Copy(Entities.Helmet source)   |  Copies all colors from the source into this Helmet.<br />*source:* Source Helmet to copy colors from.<br /> 


