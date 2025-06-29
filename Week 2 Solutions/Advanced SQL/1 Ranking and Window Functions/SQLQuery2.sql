SELECT *
FROM (
    SELECT 
        Rank() OVER (PARTITION BY Category ORDER BY Price DESC) AS Rank,
        *
    FROM Products
) AS RankedProducts1
WHERE Rank <= 3
ORDER BY Price DESC;

SELECT *
FROM (
    SELECT 
        Dense_Rank() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRank,
        *
    FROM Products
) AS RankedProducts1
WHERE DenseRank <= 3
ORDER BY Price DESC;
