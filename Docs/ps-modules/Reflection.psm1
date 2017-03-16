
function GetTypesFromAssemblyAt($path)
{
    $assembly = [System.Reflection.Assembly]::LoadFrom($path)

    $types = $assembly.GetTypes() | Where-Object { ($_.IsClass -Or $_.IsEnum -Or $_.IsValueType) -and $_.IsPublic } | Sort-Object Name

    return $types
}

function GetConstructorsFromType($type)
{
    $constructors = $type.GetConstructors() | Where-Object { $_.IsPublic }

    return $constructors
}

function GetMethodsFromType($type)
{
    $ignoreMethods = @("ToString", "Equals", "GetHashCode", "GetType", "CompareTo", "HasFlag", "GetTypeCode")

    $methods = $type.GetMethods() | Where-Object { $_.IsPublic -and $_.IsSpecialName -ne $true -and $ignoreMethods -notcontains $_.Name }

    return $methods
}

function GetPropertiesFromType($type)
{
    # TODO: check if it has a GetGetMethod that's not null?
    $properties = $type.GetProperties()

    return $properties
}

function GetFieldsFromType($type)
{
    $fields = $type.GetFields() | Where-Object { $_.IsPublic -and $_.IsSpecialName -ne $true }

    return $fields
}

function GetParameters($method)
{
    # ???
}

function GetParamsListString($method)
{
    $sig = ""
    $parameters = $method.GetParameters()

    if ($parameters.Length -gt 0)
    {
        $sig = $sig + "("

        foreach ($par in $parameters)
        {
            $sig = $sig + $par.ParameterType.FullName + ","
        }

        $sig = $sig.TrimEnd(',')
        $sig = $sig + ")"
    }

    return $sig
}

function GetParamsListWithNameString($method)
{
    $sig = ""
    $parameters = $method.GetParameters()

    if ($parameters.Length -gt 0)
    {
        $sig = $sig + "("

        foreach ($par in $parameters)
        {
            $paramType = $par.ParameterType.FullName.Replace("ArgData.", "").Replace("Entities.", "").Replace("System.", "")
            $paramName = "*$($par.Name)*"

            $sig = $sig + "$($paramType) $($paramName), "
        }

        $sig = $sig.TrimEnd(' ')
        $sig = $sig.TrimEnd(',')
        $sig = $sig + ")"
    }

    return $sig
}
