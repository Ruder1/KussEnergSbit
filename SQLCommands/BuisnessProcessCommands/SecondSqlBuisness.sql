use BuisnessTest

SELECT CodeProcess.CodeName, Process.ProcessName, OwnerProcess.OwnerName
From BuisnessProcess, CodeProcess,Process,OwnerProcess
WHERE CodeProcess.ID = BuisnessProcess.CodeId AND Process.ID = BuisnessProcess.ProcessId 
AND OwnerProcess.ID = BuisnessProcess.OwnerId  
AND CodeProcess.CodeName BETWEEN N'À1' AND N'À2' AND OwnerProcess.OwnerName != ''
-- N need to recognize cirillic symobls