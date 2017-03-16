
function LoadDocumentAt($path)
{
    $xmlData = [System.IO.File]::ReadAllText($path)
    $xmlDoc = new-object System.Xml.XmlDocument
    $xmlDoc.LoadXml($xmlData)

    return $xmlDoc
}

function GetTypeXmlDocSignature($type)
{
    $sig = "T:" + $type.FullName

    return $sig
}

function GetConstructorXmlDocSignature($method)
{
    $sig = "M:$($method.ReflectedType.FullName).#ctor"
    $pars = GetParamsListString $method
    $sig = $sig + $pars

    return $sig
}

function GetMethodXmlDocSignature($method)
{
    $sig = "M:$($method.ReflectedType.FullName).$($method.Name)"
    $pars = GetParamsListString $method
    $sig = $sig + $pars

    return $sig
}

function GetPropertyXmlDocSignature($property)
{
    $sig = "P:$($property.ReflectedType.FullName).$($property.Name)"

    return $sig
}

function GetFieldXmlDocSignature($field)
{
    $sig = "F:$($field.DeclaringType.FullName).$($field.Name)"

    return $sig
}


function GetSummaryForElement($elementName, $xmlDoc)
{
    $xpath = "/doc/members/member[@name='$($elementName)']/summary"
    $node = $xmlDoc.DocumentElement.SelectSingleNode($xpath)
    $text = $node.InnerText

    if ($text -eq $null)
    {
        return ""
        exit
    }

    $s = @([System.Environment]::NewLine)
    $list = $text.Split($s, [System.StringSplitOptions]::None)

    $sb = new-object -TypeName "System.Text.StringBuilder"

    foreach($st in $list)
    {
        $tst = $st.Trim()
        [void]$sb.AppendLine($tst)
    }

    $summary = $sb.ToString().TrimStart().TrimEnd()

    return $summary
}

function GetParameterDescription($parameter, $methodSignature, $xmlDoc)
{
    $xpath = "/doc/members/member[@name='$($methodSignature)']/param[@name='$($parameter)']"
    $node = $xmlDoc.DocumentElement.SelectSingleNode($xpath)
    $text = $node.InnerText

    # TODO: maybe this needs to have its lines handled like in GetSummaryForElement?

    return $text
}
