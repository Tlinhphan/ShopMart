USE ShopMart;
GO

CREATE OR ALTER PROCEDURE dbo.GetRevenueDaily
    @fromDate DATE,
    @toDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        CAST(b.DateCreated AS DATE) AS [Date],
        SUM(bd.Quantity * bd.Price) AS Revenue,
        SUM(bd.Quantity * (bd.Price - p.OriginalPrice)) AS Profit
    FROM dbo.Bills b
    INNER JOIN dbo.BillDetails bd
        ON b.Id = bd.BillId
    INNER JOIN dbo.Products p
        ON bd.ProductId = p.Id
    WHERE b.DateCreated >= @fromDate
      AND b.DateCreated < DATEADD(DAY, 1, @toDate)
    GROUP BY CAST(b.DateCreated AS DATE)
    ORDER BY [Date];
END
GO
GO

EXEC dbo.GetRevenueDaily
    @fromDate = '2025-12-01',
    @toDate   = '2026-10-13';
GO