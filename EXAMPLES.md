# ArgData API Usage Examples

To change car, pit crew or helmet colors, or driver performance you need an instance of a GpExeFile object to work with.

```csharp
var exeFile = new GpExeFile("path-to-GP.EXE");
```

## Car colors

Reading car colors...

```csharp
var carColorReader = new CarColorReader(exeFile);
```

Writing...
