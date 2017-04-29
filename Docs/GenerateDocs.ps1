param (
    [Parameter(Mandatory=$true)]$dllPath,
    [Parameter(Mandatory=$true)]$xmlPath,
    [Parameter(Mandatory=$true)]$mkdocsYmlPath
)

$ignoreTypes = @("ReadOnlyList``1")

if ([System.IO.File]::Exists($dllPath) -eq $false)
{
    Write-Output "ArgData.DLL path or file '$($dllPath)' does not exist! Terminating the script..."
    Exit
}

if ([System.IO.File]::Exists($xmlPath) -eq $false)
{
    Write-Output "ArgData.xml path or file '$($xmlPath)' does not exist! Terminating the script..."
    Exit
}

if ([System.IO.File]::Exists($mkdocsYmlPath) -eq $false)
{
    Write-Output "mkdocs.yml path or file '$($mkdocsYmlPath)' does not exist! Terminating the script..."
    Exit
}


Import-Module .\ps-modules\Markdown.psm1 -Force
Import-Module .\ps-modules\Reflection.psm1 -Force
Import-Module .\ps-modules\Xml.psm1 -Force

function GenerateClassDocumentation()
{
    Write-Output "Generating class documentation..."

    $xmlDoc = LoadDocumentAt $xmlPath
    $types = GetTypesFromAssemblyAt $dllPath

    foreach ($type in $types)
    {
        $fileText = new-object -TypeName "System.Text.StringBuilder"
        WriteClassHeader $type $fileText

        $typeSignatureInXml = GetTypeXmlDocSignature $type
        $typeSummary = GetSummaryForElement $typeSignatureInXml $xmlDoc

        [void]$fileText.AppendLine($typeSummary)
        [void]$fileText.AppendLine()

        $additionalSummary = GetAdditionalSummary $type
        if ($additionalSummary.Length -gt 0)
        {
            [void]$fileText.AppendLine($additionalSummary)
            [void]$fileText.AppendLine()
        }

        $constructors = GetConstructorsFromType $type        
        WriteConstructorsBlock $constructors $type $fileText $xmlDoc

        $properties = GetPropertiesFromType $type
        WritePropertiesBlock $properties $fileText $xmlDoc
        
        $methods = GetMethodsFromType $type
        WriteMethodsBlock $methods $fileText $xmlDoc

        $fields = GetFieldsFromType $type
        WriteFieldsBlock $fields $fileText $xmlDoc


        $filePath = Join-Path -Path $(Get-Location) -ChildPath "docs\api\$($type.Name.ToLowerInvariant()).md"

        [System.IO.File]::WriteAllText($filePath, $fileText.ToString())
    }
}



function GenerateClassListReference
{
    Write-Output "Generating class list reference (reference.md)..."

    $xmlDoc = LoadDocumentAt $xmlPath
    $types = GetTypesFromAssemblyAt $dllPath

    $readersWriters = $types | Where-Object { $_.Name.EndsWith("Reader") -or $_.Name.EndsWith("Writer") }
    $other = $types | Where-Object { $_.Name.EndsWith("Reader") -ne $true -and $_.Name.EndsWith("Writer") -ne $true -and $ignoreTypes.Contains($_.Name) -eq $false }

    $fileText = new-object -TypeName "System.Text.StringBuilder"

    [void]$fileText.AppendLine("# ArgData API Reference")
    [void]$fileText.AppendLine()

    [void]$fileText.AppendLine("This is a list of the classes that make up the ArgData API.")
    [void]$fileText.AppendLine("Click on the name of a class for more information.")

    [void]$fileText.AppendLine()

    WriteReadersAndWriterClasses $fileText $readersWriters $xmlDoc
    WriteOtherClasses $fileText $other $xmlDoc


    $filePath = Join-Path -Path $(Get-Location) -ChildPath "docs\api\reference.md"

    [System.IO.File]::WriteAllText($filePath, $fileText.ToString())
}

function GeneratePaletteColorsPage
{
    Write-Output "Generating palette colors page (palette-colors.md)..."

    Add-Type -Path $dllPath

    $sb = new-object -TypeName "System.Text.StringBuilder"

    [void]$sb.AppendLine("# Palette Colors");
    [void]$sb.AppendLine()

    [void]$sb.AppendLine("The palette in F1GP contains 256 colors.")
    [void]$sb.AppendLine()
    [void]$sb.AppendLine("When setting a color on a Car, Helmet or PitCrew, the index values in the left-most")
    [void]$sb.AppendLine("column are the values to use.")

    [void]$sb.AppendLine()
    [void]$sb.AppendLine("| Index   | Color   | Example   | Comment   |")
    [void]$sb.AppendLine("|---------|---------|-----------|-----------|")

    for ($i = 0; $i -le 255; $i++)
    {
        $c = [ArgData.Palette]::GetColor($i)
        $cc = "#$($c.R.ToString("X2"))$($c.G.ToString("X2"))$($c.B.ToString("X2"))"
        $comment = ""

        [void]$sb.AppendLine("| $($i)   | $($cc)   | <div class=`"palette-color`" style=`"background-color: $($cc)`">  |  $($comment)  |")
    }

    [void]$sb.AppendLine()

    $text = $sb.ToString()

    $filePath = Join-Path -Path $(Get-Location) -ChildPath "docs\api\palette-colors.md"

    [System.IO.File]::WriteAllText($filePath, $text)
}

function InsertClassReferencePagesInMkDocsYml
{
    $sb = new-object -TypeName "System.Text.StringBuilder"

    $types = GetTypesFromAssemblyAt $dllPath

    [void]$sb.AppendLine("- Remove:")

    foreach ($type in $types)
    {
        if ($ignoreTypes.Contains($type.Name))
        {
            continue
        }

        [void]$sb.AppendLine("  - $($type.Name): api/$($type.Name.ToLowerInvariant()).md")
    }

    $yml = [System.IO.File]::ReadAllText($mkdocsYmlPath)
    $yml = $yml.Replace("#RemovePagesBlock", $sb.ToString())
    $newMkdocsYmlPath = $mkdocsYmlPath.Replace(".template", "")
    [System.IO.File]::WriteAllText($newMkdocsYmlPath, $yml)
}


GenerateClassDocumentation
GenerateClassListReference
GeneratePaletteColorsPage
InsertClassReferencePagesInMkDocsYml
