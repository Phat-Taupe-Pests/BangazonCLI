INSERT into PRODUCTORDER values (null, 1, 3);

INSERT INTO `Order` VALUES (null, 2, null, "08-04-2016");

SELECT p.*
FROM Product p, `Order` o
INNER JOIN ProductOrder po
ON p.productID = po.productID
WHERE p.customerID = 1
AND o.paymentTypeID IS NULL
AND o.DateCreated <= date('now', '-90 days')
GROUP BY p.Name;

SELECT p.Name
FROM Product p
WHERE strftime('%Y-%m-%d',p.DateCreated) >= date('now','-180 days') AND 
strftime('%Y-%m-%d', p.DateCreated)<=date('now') ;

SELECT p.Name, p.productID
FROM Product p, `Order` o, ProductOrder po
WHERE p.productID = po.productID
AND p.customerID = 1
AND o.paymentTypeID IS NULL
GROUP BY p.Name;

DELETE from ProductOrder
WHERE ProductID = 3;

SELECT p.*
FROM Product p
INNER JOIN ProductOrder po
On p.ProductID = po.ProductID
INNER JOIN `Order` o
ON po.OrderID = o.OrderID
WHERE p.customerID = 1
AND o.PaymentTypeID IS NOT NULL
AND p.Quantity != 0
AND p.DateCreated < date('now','-180 days')
UNION
SELECT p.*
FROM Product p, `Order` o
INNER JOIN ProductOrder po
ON p.productID = po.productID
WHERE p.customerID = 1
AND o.paymentTypeID IS NULL
AND o.DateCreated <= date('now', '-90 days')
UNION 
SELECT p.*
FROM Product p
LEFT JOIN ProductOrder po
ON p.ProductID = po.ProductID
WHERE p.customerID = 1
AND po.ProductID IS NULL
AND p.DateCreated <= date('now','-180 days') 
GROUP BY p.Name;