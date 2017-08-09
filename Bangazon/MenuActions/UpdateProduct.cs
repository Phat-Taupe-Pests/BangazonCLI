using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;


namespace  BangazonCLI.MenuActions
{
    public class UpdateProduct
    {
        public static void UpdateProductMenu(ProductManager pm)
        {
            Console.Clear();
            Console.WriteLine("Select a product you would like to update:");
            int custID = CustomerManager.currentCustomer.customerID;
            int updateCounter = 1;
            List<Product> updateList = pm.GetProductList(custID);
            foreach(Product item in updateList)
            {
                Console.WriteLine($"{updateCounter}. {item.name}");
                updateCounter++;
            }
            Console.Write("> ");
            int updateChoice;
		    Int32.TryParse (Console.ReadLine(), out updateChoice);
            int selectedProductIndex = updateChoice -1;
            Product selectedProduct = updateList[selectedProductIndex];

            Console.Clear();
            Console.WriteLine("Select the field you wish to update:");
            Console.WriteLine($"1. Change Name: {selectedProduct.name}");
            Console.WriteLine($"2. Change Description: {selectedProduct.description}");
            Console.WriteLine($"3. Change Price: {selectedProduct.price}");
            Console.WriteLine($"4. Change Quantity: {selectedProduct.quantity}");
            Console.Write("> ");

            int fieldChoice;
		    Int32.TryParse (Console.ReadLine(), out fieldChoice);

            switch(fieldChoice)
            {
                case 1:
                    UpdateName(selectedProduct, pm);
                    break;
                case 2:
                    UpdateDesc(selectedProduct, pm);
                    break;
                case 3:
                    UpdatePrice(selectedProduct, pm);
                    break;
                case 4:
                    UpdateQuantity(selectedProduct, pm);
                    break;
            }

        }

        public static void UpdateName(Product selectedProduct, ProductManager pm)
        {
            Console.Clear();
            Console.WriteLine("Enter new name:");
            Console.Write("> ");
            string newName = Console.ReadLine();
            string updateString = $"UPDATE product SET name='{newName}' WHERE productID = {selectedProduct.productID}";
            pm.UpdateProduct(updateString);
        }
        public static void UpdateDesc(Product selectedProduct, ProductManager pm)
        {
            Console.Clear();
            Console.WriteLine("Enter new description:");
            Console.Write("> ");
            string newDesc = Console.ReadLine();
            string updateString = $"UPDATE product SET description='{newDesc}' WHERE productID = {selectedProduct.productID}";
            pm.UpdateProduct(updateString);
        }
        public static void UpdatePrice(Product selectedProduct, ProductManager pm)
        {
            Console.Clear();
            Console.WriteLine("Enter New Price:");
            Console.Write("> ");
            Double newPrice;
            Double.TryParse (Console.ReadLine(), out newPrice);
            string updateString = $"UPDATE product SET price='{newPrice}' WHERE productID = {selectedProduct.productID}";
            pm.UpdateProduct(updateString);
        }
        public static void UpdateQuantity(Product selectedProduct, ProductManager pm)
        {
            Console.Clear();
            Console.WriteLine("Enter a new Quantity:");
            Console.Write("> ");
            int newQuantity;
            Int32.TryParse(Console.ReadLine(), out newQuantity);
            string updateString = $"UPDATE product SET quantity='{newQuantity}' WHERE productID = {selectedProduct.productID}";
            pm.UpdateProduct(updateString);
        }
        
    }
}