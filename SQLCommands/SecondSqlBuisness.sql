use BuisnessTest

SELECT CodeProcess.CodeName, Process.ProcessName, OwnerProcess.OwnerName
From BuisnessProcess, CodeProcess,Process,OwnerProcess
WHERE CodeProcess.ID = BuisnessProcess.CodeId AND Process.ID = BuisnessProcess.ProcessId 
AND OwnerProcess.ID = BuisnessProcess.OwnerId  
AND CodeProcess.CodeName BETWEEN N'А1' AND N'А2' AND OwnerProcess.OwnerName != ''
-- N служит для распознания символов кириллицы