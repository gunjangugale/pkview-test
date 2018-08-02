@echo off
powershell Set-ExecutionPolicy -Scope Process -ExecutionPolicy AllSigned
powershell -Command $pword = read-host "Enter Password" -AsSecureString ; ^
$BSTR=[System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($pword); ^
[System.Runtime.InteropServices.Marshal]::PtrToStringAuto($BSTR) > .tmp.txt
			  