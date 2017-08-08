DELETE FROM Product;
DELETE FROM `Order`;
DELETE FROM Customer;
DELETE FROM ProductOrder;
DELETE FROM ProductType;
DELETE FROM PaymentType;

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

INSERT INTO Product VALUES (null, "Bananas", "Turn them into banana bread!", 3, 0.99, 1, 08-04-2017);
INSERT INTO Product VALUES (null, "Pumped Up Kicks", "They better run, better run...", 8, 15.50, 1, 06-04-2017);
INSERT INTO Product VALUES (null, "1987 BMW Motorcycle", "Does it even run?", 1, 1500, 1, 08-04-2016);
INSERT INTO Product VALUES (null, "Fishnet Leg Lamp", "Weird? Oh yeah.", 2, 50.75, 2, 05-04-2017);
INSERT INTO Product VALUES (null, "Monopoly", "Hate your friends, play monopoly!", 9, 25, 2, 08-04-2017);
INSERT INTO Product VALUES (null, "Wheelbarrow", "Really good at breeding mosquitos", 7, 35.95, 2, 02-04-2017);
INSERT INTO Product VALUES (null, "Linkin Park CD", "Probably not as good as you remember", 6, 8.99, 3, 04-04-2017);
INSERT INTO Product VALUES (null, "Nintendo 64", "Bring back the memories", 6, 50, 3, 08-04-2015);
INSERT INTO Product VALUES (null, "1950s TV", "Hope it's not haunted!", 10, 150, 3, 08-04-2016);

INSERT INTO `Order` VALUES (null, 1, 1);
INSERT INTO `Order` VALUES (null, 1, 2);
INSERT INTO `Order` VALUES (null, 2, 3);
INSERT INTO `Order` VALUES (null, 2, 4);
INSERT INTO `Order` VALUES (null, 3, 5);
INSERT INTO `Order` VALUES (null, 3, 6);