# Downloads the argdata-testdata.zip file and unpacks it in this folder

$url = "http://manicomio.se/argdata-testdata/files-v4.zip"
$file = "files-v4.zip"
$path = (Get-Location).Path + "\" + $file

Write-Host "Downloading $file... " -NoNewLine

$webClient = new-object System.Net.WebClient
$webClient.DownloadFile($url, $path)

Write-Host "Done!"

Write-Host "Unzipping files... " -NoNewLine

$shellApp = new-object -com shell.application 
$zipFile = $shellApp.namespace($path) 
$destination = $shellApp.namespace((Get-Location).Path) 
$destination.Copyhere($zipFile.items(), 0x14)

Write-Host "Done!"

Write-Host "Deleting zip file... " -NoNewLine
Remove-Item $path
Write-Host "Done!"
