Import-Module $PSScriptRoot/Xml.psm1 -Force


function WriteReadersAndWriterClasses($sb, $classes, $xmlDoc)
{
    [void]$sb.AppendLine("## Readers and Writers")
    [void]$sb.AppendLine()

    [void]$sb.AppendLine("The Reader and Writer classes perform the basic editing of GP.EXE and other files.")  
    [void]$sb.AppendLine("Reader classes are used to fetch data from the F1GP files into their respective representations as .NET classes.")
    [void]$sb.AppendLine("The Writer classes update GP.EXE and other files.")
    [void]$sb.AppendLine()

    WriteClassTable $sb $classes $xmlDoc

    [void]$sb.AppendLine()
    [void]$sb.AppendLine()
}

function WriteOtherClasses($sb, $classes, $xmlDoc)
{
    [void]$sb.AppendLine("## Other Classes")
    [void]$sb.AppendLine()

    WriteClassTable $sb $classes $xmlDoc

    [void]$sb.AppendLine()
    [void]$sb.AppendLine()
}


function WriteClassHeader($type, $sb)
{
    [void]$sb.AppendLine("# $($type.Name)")
    [void]$sb.AppendLine()
}

function WriteClassTable($sb, $classes, $xmlDoc)
{
    WriteMemberTableHeader($sb)

    foreach ($class in $classes)
    {
        $signatureInXml = GetTypeXmlDocSignature $class
        $summary = GetSummaryForElement $signatureInXml $xmlDoc
        $sumsum = $summary.Replace([System.Environment]::NewLine, "<br />")
        $link = "[$($class.Name)](./$($class.Name.ToLowerInvariant()))"

        WriteMemberTableData $sb $link $sumsum
    }
}

function WriteMemberTableHeader($sb)
{
    [void]$sb.AppendLine("| Name  | Description  |")
    [void]$sb.AppendLine("|-------|--------------|")
}

function WriteMemberTableData($sb, $name, $description)
{
    [void]$sb.AppendLine("| $($name)  | $($description)  |")
}


function WriteConstructorsBlock($constructors, $type, $sb, $xmlDoc)
{
    if ($constructors.Length -eq 0)
    {
        return
    }

    [void]$sb.AppendLine("## Constructors")
    [void]$sb.AppendLine()

    WriteMemberTableHeader $sb

    foreach ($constructor in $constructors)
    {
        $signatureInXml = GetConstructorXmlDocSignature $constructor
        $summary = GetSummaryForElement $signatureInXml $xmlDoc

        $sig = GetParamsListWithNameString $constructor
        if ($sig.Length -eq 0)
        {
            $sig = $type.Name + "()"
        }
        else
        {
            $sig = $type.Name + $sig
        }

        $sumsum = $summary.Replace([System.Environment]::NewLine, "<br />")
        $parameterHtml = ParametersFromConstructor $constructor $xmlDoc
        $newsum = $sumsum + $parameterHtml

        WriteMemberTableData $sb $sig $newsum
    }

    [void]$sb.AppendLine()
    [void]$sb.AppendLine()
}

function ParametersFromConstructor($method, $xmlDoc)
{
    $parameters = $method.GetParameters()

    if ($parameters.Length -eq 0)
    {
        return ""
    }

    $paramcode = "<br />"

    foreach ($par in $parameters)
    {
        $methodSig = GetConstructorXmlDocSignature $method
        $desc = GetParameterDescription $par.Name $methodSig $xmlDoc
        $desc2 = $summary.Replace([System.Environment]::NewLine, "<br />")

        $paramcode = $paramcode + "*$($par.Name)*: $($desc2)"
    }

    return $paramcode
}


function WriteMethodsBlock($methods, $sb, $xmlDoc)
{
    if ($methods.Length -eq 0)
    {
        return
    }

    [void]$sb.AppendLine("## Methods")
    [void]$sb.AppendLine()

    WriteMemberTableHeader $sb

    foreach ($method in $methods)
    {
        $signatureInXml = GetMethodXmlDocSignature $method
        $summary = GetSummaryForElement $signatureInXml $xmlDoc
        $sumsum = $summary.Replace([System.Environment]::NewLine, "<br />")
        $parameterHtml = ParametersFromMethod $method $xmlDoc
        $newsum = $sumsum + $parameterHtml

        $sig = GetParamsListWithNameString $method
        if ($sig.Length -eq 0)
        {
            $sig = $type.Name + "()"
        }
        else
        {
            $sig = $type.Name + $sig
        }

        $fullSig = "$($method.Name)$($sig)"

        # TODO: output return value?

        WriteMemberTableData $sb $fullSig $newsum
    }

    [void]$sb.AppendLine()
    [void]$sb.AppendLine()
}

function ParametersFromMethod($method, $xmlDoc)
{
    $parameters = $method.GetParameters()

    if ($parameters.Length -eq 0)
    {
        return ""
    }

    $paramcode = "<br />"

    foreach ($par in $parameters)
    {
        $methodSig = GetMethodXmlDocSignature $method
        $desc = GetParameterDescription $par.Name $methodSig $xmlDoc

        $paramcode = $paramcode + "*$($par.Name)*: $($desc)<br />"
    }

    return $paramcode
}


function WritePropertiesBlock($properties, $sb, $xmlDoc)
{
    if ($properties.Length -eq 0)
    {
        return
    }

    [void]$sb.AppendLine("## Properties")
    [void]$sb.AppendLine()

    WriteMemberTableHeader $sb

    foreach ($prop in $properties)
    {
        $signatureInXml = GetPropertyXmlDocSignature $prop
        $summary = GetSummaryForElement $signatureInXml $xmlDoc

        WriteMemberTableData $sb $prop.Name $summary
    }

    [void]$sb.AppendLine()
    [void]$sb.AppendLine()
}


function WriteFieldsBlock($fields, $sb, $xmlDoc)
{
    if ($fields.Length -eq 0)
    {
        return
    }

    [void]$sb.AppendLine("## Fields")
    [void]$sb.AppendLine()

    WriteMemberTableHeader $sb

    foreach ($field in $fields)
    {
        $signatureInXml = GetFieldXmlDocSignature $field
        $summary = GetSummaryForElement $signatureInXml $xmlDoc

        WriteMemberTableData $sb $field.Name $summary
    }

    [void]$sb.AppendLine()
    [void]$sb.AppendLine()
}


function GetAdditionalSummary($type)
{
    $filePath = Join-Path -Path $(Get-Location) -ChildPath "docs\api\static\$($type.Name.ToLowerInvariant()).md"
    
    if ([System.IO.File]::Exists($filePath))
    {
        $fileData = [System.IO.File]::ReadAllText($filePath)
        return $fileData
    }
    else
    {
        return ""
    }
}
