use BuisnessTest

SELECT CodeProcess.CodeName, Process.ProcessName
From BuisnessProcess, CodeProcess,Process
WHERE CodeProcess.ID = BuisnessProcess.CodeId AND Process.ID = BuisnessProcess.ProcessId 
AND CodeProcess.CodeName BETWEEN N'А1' AND N'А2' AND NOT CodeProcess.CodeName = N'А2'
-- N служит для распознания символов кириллицы