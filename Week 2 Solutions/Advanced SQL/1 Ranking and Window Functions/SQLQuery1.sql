SELECT *
FROM (
    SELECT 
        row_number() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum,
        *
    FROM Products
) AS RankedProducts1
WHERE RowNum <= 3
ORDER BY Price DESC;


