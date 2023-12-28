SELECT [Order].LastName, [Order].LastNameOfCustomer, [Order].NameOfOrder
FROM [Order]
WHERE [Order].LastName = [Order].LastNameOfCustomer
AND [Order].SumOfOrder <= 2000;