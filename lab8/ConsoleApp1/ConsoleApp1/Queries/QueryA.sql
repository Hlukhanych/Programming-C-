SELECT [Order].LastName, [Order].SumOfOrder, [Order].NameOfOrder
FROM [Order] 
WHERE [Order].SumOfOrder >= 800;