param (
    [Parameter(Mandatory=$true)]$docFolder
)

if ([System.IO.Directory]::Exists($docFolder) -eq $false)
{
    Write-Output "MkDocs site folder '$($docFolder)' does not exist! Terminating the script..."
    Exit
}


$items = Get-ChildItem -Path $docFolder -Filter *.html -Recurse

foreach ($file in $items)
{
    $filePath = $file.FullName
    $start = 0
    $end = 0

    $lines = [System.IO.File]::ReadAllLines($filePath)

    for ($i = 0; $i -le $lines.Length - 1; $i++)
    {
        $line = $lines[$i]

        if ($line.Contains(">Remove"))
        {
            $start = $i - 1
        }

        if ($start -gt 0 -and $line.Contains("               </li>") -and $line.Contains("                  </li>") -ne $true)
        {
            $end = $i + 1
            break
        }
    }

    $count = $end - $start

    if ($count -gt 0)
    {
        [Collections.Generic.List[String]]$linesList = $lines
        $linesList.RemoveRange($start, $count)
        $newLines = $linesList.ToArray()

        [System.IO.File]::WriteAllLines($filePath, $newLines)
    }
}
