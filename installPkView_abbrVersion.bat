@set /p folderPath= "Enter location to create the PkView output folder : "
@echo off
@cd %~dp0
call test_pwd.bat
set /p password=<.tmp.txt & del .tmp.txt

@echo off
@rmdir %folderPath% /q /s

@md %folderPath%
@cd %~dp0
@xcopy "Installation Package\OCP" %folderPath% /E /K

@cd %folderPath%\iPortal\webroot\App_Data\userData
@ren Peter %username%

@cd %folderPath%\iPortal 
@icacls webroot /grant %username%:(RX,R) /t
@cd %folderPath%\iPortal\webroot\App_Data
@icacls userData /grant %username%:F /t

@cd %folderPath%\Sasjobs.Api
@icacls webroot /grant %username%:(RX,R) /t

@net share clinical /delete
@net share "Output Files" /delete

@cd %folderPath%\data
@net share clinical=%folderPath%\data\clinical /GRANT:everyone,FULL
@icacls "%folderPath%\Sasjobs.Standalone\Stored Procedures\Output Files" /grant %username%:F /t
@net share "output files"="%folderPath%\Sasjobs.Standalone\Stored Procedures\Output Files" /GRANT:everyone,FULL

@cd %windir%\system32\inetsrv
@appcmd delete site "Default Web Site"
@appcmd delete apppool "DefaultAppPool"
@appcmd delete apppool "iPortal Pool"
@appcmd delete apppool "SasJobs Pool"
@appcmd delete site "iPortal"
@appcmd delete site "SasJobs.Api"

@appcmd add apppool /name:"iPortal Pool" /managedRuntimeVersion:"v4.0" /autoStart:"true" /managedPipelineMode:"Integrated" /processModel.identityType:"SpecificUser" /processModel.userName:"%username%" /processModel.password:"%password%"

@appcmd add site /name:"iPortal" /id:1 /physicalPath:"%folderPath%\iPortal\webroot" /bindings:http/"*:80:" /serverAutoStart:"true"
@appcmd set app "iPortal/" /applicationPool:"iPortal Pool"
@appcmd set config -section:system.applicationHost/sites /[name='iPortal'].logFile.logFormat:"W3C"
@appcmd set config -section:system.applicationHost/sites /[name='iPortal'].logFile.period:"Daily"
@appcmd set config -section:system.applicationHost/sites /[name='iPortal'].logFile.directory:"%folderPath%\iPortal\logs"
@appcmd set config /section:windowsAuthentication /enabled:true
@appcmd set config /section:staticContent /+[fileExtension='.woff',mimeType='application/x-font-woff']

@appcmd add apppool /name:"SasJobs Pool" /managedRuntimeVersion:"v4.0" /autoStart:"true" /managedPipelineMode:"Integrated" /processModel.identityType:"SpecificUser" /processModel.userName:"%username%" /processModel.password:"%password%" 

@appcmd add site /name:"SasJobs.Api" /id:2 /physicalPath:"%folderPath%\SasJobs.Api\webroot" /bindings:http/"*:5455:" /serverAutoStart:"true"
@appcmd set app "SasJobs.Api/" /applicationPool:"SasJobs Pool"
@appcmd set config -section:system.applicationHost/sites /[name='SasJobs.Api'].logFile.logFormat:"W3C"
@appcmd set config -section:system.applicationHost/sites /[name='SasJobs.Api'].logFile.period:"Daily"
@appcmd set config -section:system.applicationHost/sites /[name='SasJobs.Api'].logFile.directory:"%folderPath%\SasJobs.Api\logs"

@rmdir %folderPath%\iPortal_Publish /q /s
@rmdir %folderPath%\SasJobs_Publish /q /s

@md %folderPath%\iPortal_Publish
@md %folderPath%\SasJobs_Publish

@xcopy "%~dp0\Installation Package\iPortal-Publish" %folderPath%\iPortal_Publish /E /K /I /Y
@xcopy "%~dp0\Installation Package\SasJobs.Api-Publish" %folderPath%\SasJobs_Publish /E /K /I /Y

@cd %~dp0
@call iPortalDeploy.bat %folderPath%
@call SasJobsDeploy.bat %folderPath%

@netsh http add urlacl url=http://+:5454/ user=%username%

@cd %windir%\system32\inetsrv
@appcmd stop apppool "iPortal Pool"
@appcmd start apppool  "iPortal Pool"
@appcmd stop apppool  "SasJobs Pool"
@appcmd start apppool  "SasJobs Pool"
@appcmd stop site  "iPortal"
@appcmd start site  "iPortal"
@appcmd stop site  "SasJobs.Api"
@appcmd start site  "SasJobs.Api"

@taskkill /F /IM cmd.exe