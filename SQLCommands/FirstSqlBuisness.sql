use BuisnessTest

SELECT CodeProcess.CodeName, Process.ProcessName
From BuisnessProcess, CodeProcess,Process
WHERE CodeProcess.ID = BuisnessProcess.CodeId AND Process.ID = BuisnessProcess.ProcessId 
AND CodeProcess.CodeName BETWEEN N'�1' AND N'�2' AND NOT CodeProcess.CodeName = N'�2'
-- N need to recognize cirillic symobls