# Bangazon

## The Command Line Ordering System

This system allows an employee to interact with a basic product ordering database via a command line interface.

## Requirements

### For OSX Users

```
brew install sqlite
```

### For Windows Users

Visit the [SQLite downloads](https://www.sqlite.org/download.html) and download the 64-bit DLL (x64) for SQLite version, unzip and install it.

## Visual Studio Code

[Visual Studio Code](https://code.visualstudio.com/download) is Microsoft's cross-platform editor that we'll be using during orientation for writing C# and building .NET applications. Make sure you add the [C# extension](https://code.visualstudio.com/Docs/languages/csharp) immediately after installation completes.

## Windows

### Install .NET Core

https://www.microsoft.com/net/core#windows

  1. Click the link to download the .NET Core SDK for Windows (https://go.microsoft.com/fwlink/?LinkID=827524)
  2. Once installed open a command line app to intialize some code.
  3. Make a directory for your app: mkdir HelloWorld
  4. Move to the newly created directory. : cd HelloWorld
  5. Create a new app: dotnet new
  6. Build the app and restore any get any missing libraries (packages) : dotnet restore
  7. Run the app: dotnet run
  8. You should see the test "Hello World".
  9. Navigate to the folder where the app was created and https://docs.asp.net/en/latest/getting-started.html

## OSX

### Install .NET Core

https://www.microsoft.com/net/core#macos

Create and run an ASP.NET application using .NET Core

https://docs.asp.net/en/latest/getting-started.html


### Review .NET Core Documentation

https://docs.microsoft.com/en-us/dotnet/

# Installing Bangazon CLI

As of now, the database is going to be hosted on your local computer. There are a few things you need to make sure are in place before the database can be up and running.
 1. Fork and clone the repo on to you local machine. 
 2. Run `dotnet restore`
 3. Run `dotnet run` 
 > This will run everything as well as initalizing the database with some data to get started

#  Running the Bangazon CLI

## Ordering System Interface

```bash
*********************************************************
**  Welcome to Bangazon! Command Line Ordering System  **
*********************************************************
1. Create a customer account
2. Choose active customer
3. Create a payment option
4. Add product to sell
5. Add product to shopping cart
6. Complete an order
7. Remove customer product
8. Update product information
9. Show stale products
10. Show customer revenue report
11. Show overall product popularity
12. Leave Bangazon!
>
```

The Main menu is quite user-friendly.
The following actions are available to the Bangazon customer representative through the CLI

### Option 1 Create a Customer Account
1. This Method will guide you through creating a new customer
2. You are required to add a first name, last name, city, state, postal code, phonenumber

### Option 2 Choose an Active Customer
1. This Method will write a list of previously added customers
2. Select a customer.

### Option 3 Create a Payment Option
1. This Method will guide you through creating a new payment option
2. You are required to have chosen an active customer
3. You are required to add a Payment Type(e.g. AmEx, Visa, Checking), and an account number

### Option 4 Add a Product to Sell
1. This Method will guide you through adding a product to sell
2. You are required to have chosen an active customer
3. You will be required to provide a name, a short description, an asking price, a product type from a list, and how many you are posting for sale.

### Option 5 Add a Product to Shopping Cart
1. This Method will guide you through adding an item to a shopping cart
2. You are required to have chosen an active customer
3. You will be provided with a list of products that are available to add, select one.
4. Boom.

### Option 6 Complete an Order
1. This Method will guide you through completing an Order
2. You are required to have chosen an active customer
3. It will ask you if you are sure, and provide you will your shopping cart total
4. Type Y or N to confirm

### Option 7 Remove a Customer's Product
1. This Method will guide you through removing a customers product that is up for sale
2. You are required to have chosen an active customer
3. A list of removable products will be presented
4. Select one... Boom it's gone.

### Option 8 Update Product Information
1. This Method will guide you Updating product information
2. You are required to have chosen an active customer
3. You will be presented with a list of products you can update. Select one.
4. Then select the field you would like to update
5. Then update the field.

### Option 9 Show Stale Products
1. This Method will guide you through checking for a stale product
2. A stale product has a) never been added to an order, and has been in the system for more than 180 days
b) Has been added to an order, but the order hasn't been completed, and the order was created more than 90 days ago
c) Has been added to one, or more orders, and the order were completed, but there is remaining quantity for the product, and the product has been in the system for more than 180 days
3. You are required to have chosen an active customer
4. The stale products will be displayed

### Option 10 Show Customer Revenue Report
1. This Method will guide you through checking a revenue report
2. You are required to have chosen an active customer
3. The Revenue Report will be displayed

### Option 11 Show Overall Product Popularity
1. This Method will guide you through viewing product popularity
2. Select the method and see the magic.

### Option 12 Exit the Bangazon System
1. This Method will exit the Bangazon CLI

