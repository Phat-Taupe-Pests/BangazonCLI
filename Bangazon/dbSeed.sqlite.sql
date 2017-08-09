DELETE FROM Product;
DELETE FROM `Order`;
DELETE FROM Customer;
DELETE FROM ProductOrder;
DELETE FROM ProductType;
DELETE FROM PaymentType;

DROP TABLE Product;
DROP TABLE `Order`;
DROP TABLE Customer;
DROP TABLE ProductOrder;
DROP TABLE ProductType;
DROP TABLE PaymentType;

CREATE TABLE `customer`     (
                            `customerID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `firstName`	varchar(80) not null, 
                            `lastName`	varchar(80) not null, 
                            `streetAddress`	varchar(160) not null, 
                            `state`	varchar(80) not null, 
                            `postalCode` integer not null,
                            `phoneNumber`	varchar(20) not null
                            );
CREATE TABLE `paymentType`  (
                            `PaymentTypeID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `AccountNumber`	integer not null,
                            `CustomerID`	integer not null,
                            `Name`   varchar(80) not null,
                            FOREIGN KEY(`CustomerID`) REFERENCES `Customer`(`CustomerID`)
                            );
CREATE TABLE `productType`  (
                            `ProductTypeID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `Name`	varchar(80) not null
                            );
CREATE TABLE `order`        (
                            `orderID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `customerID`	integer not null,
                            `paymentTypeID`	integer not null,
                            `DateCreated`   varchar(80) not null,
                            FOREIGN KEY(`customerID`) REFERENCES `customer`(`id`),
                            FOREIGN KEY(`paymentTypeID`) REFERENCES `paymentType`(`id`)
                            );
CREATE TABLE `product`      (
                            `ProductID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `Name`	varchar(80) not null, 
                            `Description`	varchar(1000) not null, 
                            `Price`	double not null,
                            `DateCreated`   varchar(80) not null,
                            `Quantity` int not null,
                            `CustomerID`	integer not null,
                            `ProductTypeID`	integer not null,
                            FOREIGN KEY(`CustomerID`) REFERENCES `Customer`(`CustomerID`),
                            FOREIGN KEY(`ProductTypeID`) REFERENCES `ProductType`(`ProductTypeID`)
                            );
CREATE TABLE `productOrder` (
                            `ProductOrderID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `OrderID`	integer not null,
                            `ProductID`	integer not null,
                            FOREIGN KEY(`OrderID`) REFERENCES `Order`(`OrderID`),
                            FOREIGN KEY(`ProductID`) REFERENCES `Product`(`ProductID`)
                            );

INSERT INTO ProductType VALUES (null, 'Auto');
INSERT INTO ProductType VALUES (null, 'Home');
INSERT INTO ProductType VALUES (null, 'Groceries');
INSERT INTO ProductType VALUES (null, 'Electronics');
INSERT INTO ProductType VALUES (null, 'Tickets');
INSERT INTO ProductType VALUES (null, 'Media');
INSERT INTO ProductType VALUES (null, 'Garden');
INSERT INTO ProductType VALUES (null, 'Clothing');
INSERT INTO ProductType VALUES (null, 'Toys and Games');
INSERT INTO ProductType VALUES (null, 'Antiques');

INSERT INTO Customer VALUES (null, "Kid", "Rock", "14 Bowling Green Ave, Nashville", "TN", "37211", "672-192-1967");
INSERT INTO Customer VALUES (null, "Will", "Smith", "1591 Alison Place, New York", "NY", "92310", "827-192-3938");
INSERT INTO Customer VALUES (null, "Bon", "Jovi", "918 Market Square", "CO", "67288", "682-391-1911");

INSERT INTO PaymentType VALUES (null, 1920192847, 1, "Visa");
INSERT INTO PaymentType VALUES (null, 4901423323, 1, "Mastercard");
INSERT INTO PaymentType VALUES (null, 1093488932, 2, "Bank Draft");
INSERT INTO PaymentType VALUES (null, 5425232312, 2, "Venmo");
INSERT INTO PaymentType VALUES (null, 6354654355, 3, "Paypal");
INSERT INTO PaymentType VALUES (null, 8654733123, 3, "Amex");

INSERT INTO Product VALUES (null, "Bananas", "Turn them into banana bread!", 0.99, "08-04-2017", 56, 1, 3);
INSERT INTO Product VALUES (null, "Pumped Up Kicks", "They better run, better run...", 15.50, "06-04-2017", 6, 1, 8);
INSERT INTO Product VALUES (null, "1987 BMW Motorcycle", "Does it even run?", 1500, "08-04-2016", 1, 1, 1);
INSERT INTO Product VALUES (null, "Fishnet Leg Lamp", "Weird? Oh yeah.", 50.75, "05-04-2017", 2, 2, 2);
INSERT INTO Product VALUES (null, "Monopoly", "Hate your friends, play monopoly!", 25, "08-04-2017", 15, 2, 9);
INSERT INTO Product VALUES (null, "Wheelbarrow", "Really good at breeding mosquitos", 35.95, "02-04-2017", 3, 2, 7);
INSERT INTO Product VALUES (null, "Linkin Park's HyBrid Theory", "Probably not as good as you remember", 8.99, "04-04-2017", 200, 3, 6);
INSERT INTO Product VALUES (null, "Nintendo 64", "Bring back the memories", 50, "08-04-2015", 3,  3, 4);
INSERT INTO Product VALUES (null, "1950s TV", "Hope it's not haunted!", 150, "08-04-2016", 1, 3, 10);

INSERT INTO `Order` VALUES (null, 1, 1);
INSERT INTO `Order` VALUES (null, 1, 2);
INSERT INTO `Order` VALUES (null, 2, 3);
INSERT INTO `Order` VALUES (null, 2, 4);
INSERT INTO `Order` VALUES (null, 3, 5);
INSERT INTO `Order` VALUES (null, 3, 6);