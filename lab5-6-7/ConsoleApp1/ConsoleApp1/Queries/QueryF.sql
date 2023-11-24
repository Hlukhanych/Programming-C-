SELECT COUNT(*) AS NameOfOrderCount, NameOfOrder
FROM [Order]
GROUP BY NameOfOrder
HAVING COUNT(*)>=1;