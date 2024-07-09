-- Insert products
INSERT INTO Products (Title, Price) VALUES ('Product 1', 100);
INSERT INTO Products (Title, Price) VALUES ('Product 2', 200);
INSERT INTO Products (Title, Price) VALUES ('Product 3', 300);
INSERT INTO Products (Title, Price) VALUES ('Product 4', 400);
INSERT INTO Products (Title, Price) VALUES ('Product 5', 500);

-- Variables for order number
WITH RECURSIVE DateRange AS (
    SELECT date('2024-07-07', '-9 days') AS Date
    UNION ALL
    SELECT date(Date, '+1 day')
    FROM DateRange
    WHERE Date < date('2024-07-07')
),
OrderNumber AS (
    SELECT 'Order' || (ROW_NUMBER() OVER (ORDER BY Date) + (RowNum - 1) * 4) AS Number, Date
    FROM DateRange, (SELECT 1 AS RowNum UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4)
)
-- Insert orders
INSERT INTO Orders (Number, TotalPrice, Date)
SELECT Number, 0, Date
FROM OrderNumber;

-- Insert order lines
WITH OrderData AS (
    SELECT o.Id AS OrderId, p.Id AS ProductId, p.Price
    FROM Orders o, Products p
    ORDER BY o.Id
),
OrderLinesData AS (
    SELECT OrderId, ProductId, Price, 1 + (ROW_NUMBER() OVER (PARTITION BY OrderId ORDER BY ProductId) % 3) AS Quantity
    FROM OrderData
)
INSERT INTO OrderLines (OrderId, ProductId, Quantity, Price)
SELECT OrderId, ProductId, Quantity, Price
FROM OrderLinesData;

-- Update total prices
UPDATE Orders
SET TotalPrice = (
    SELECT SUM(ol.Quantity * ol.Price)
    FROM OrderLines ol
    WHERE ol.OrderId = Orders.Id
);
