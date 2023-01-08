use BuisnessTest

SELECT CodeProcess.CodeName, Process.ProcessName
From BuisnessProcess, CodeProcess,Process
WHERE CodeProcess.ID = BuisnessProcess.CodeId AND Process.ID = BuisnessProcess.ProcessId 
AND CodeProcess.CodeName BETWEEN N'À1' AND N'À2' AND NOT CodeProcess.CodeName = N'À2'
-- N need to recognize cirillic symobls