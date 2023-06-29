# Stop the IIS service

Write-Output "Stopping NodeJS Process at port 3000"
$port = 3000

# Stop all processes running on the specified port
cmd.exe /c "FOR /F ""tokens=5"" %P IN ('netstat -a -n -o ^| findstr :$port') DO TaskKill.exe /PID %P /F"

Write-Output "NodeJS Process at port 3000 Stop successfully"

$projectPath = "C:\Users\vendor\Desktop\front\cimb"

cd $projectPath

npm start

Write-Output "Deploy script run successfully"