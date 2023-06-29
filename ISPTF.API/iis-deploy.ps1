# Stop the IIS service

Write-Output "Stopping IIS"
iisreset /stop

Write-Output "IIS Stop successfully"

Write-Output "Copy new files from dist"
Remove-Item -Path C:\inetpub\wwwroot\* -Recurse -Force

# Copy files from the dist folder to the IIS website root directory
Copy-Item -Path "C:\builds\zEdnxcva\0\sarawut_isp\isptfapi\dist\*" -Destination "C:\inetpub\wwwroot" -Recurse

Write-Output "Start IIS"

# Start the IIS service
iisreset /start

Write-Output "Deploy script run successfully"

Remove-Item -Path C:\builds\zEdnxcva\0\* -Recurse -Force
