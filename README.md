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
The following actions are available to the Bangazon customer representative
### Option 1 Create a Customer Account
1. This Method will guide you through creating a new customer
