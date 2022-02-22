# ChinookAPI

![GitHub repo size](https://img.shields.io/github/repo-size/mikkoryynanen/ChinookAPI)

## Table of Contents

- [General Information](#general-information)
- [Technologies](#technologies)
- [Installation and Usage](#installation-and-usage)
- [Contributors](#contributors)

## General Information

The project currently has nine different methods which can be used for interaction with database:

- Read all customers from database. This method returns: customer's id, first name, last name, country, postal code, phone number and email address.
- Read individual customer by customer id from database. This method returns: customer's id, first name, last name, country, postal code, phone number and email address.
- Read customer with matching part of name. 
- Read page of customers. This method returns limit value of customers, starting from offset value.
- Create new customer to the database. Add following fields to new customer: first name, last name, country, postal code, phone number and email. This method returns new customer if customer is successifully created, or null if customer creation failed.
- Update existing user in database. Update selected customer's phone number and email address. This method returns updated customer if customer is successifully updated, or null if customer update failed.
- Read coutries with amount of customers from database. This method returns all countries with customers in it, along with amount of customers, in descending order (highest to lowest).
- Read highest spending customers from database. This method returns highest spending customers in descending order (highest to lowest).
- Read selected customer's most popular genre. This method returns selected customer's most popular genre. In case of tie, return both of genres.

## Technologies

The project is implemented with following technologies:

- C#

- .NET 5.0

- SQL Server

## Installation and Usage

**NOTE:** You will need SQL Server to be connected with SQL Server Management Studio/Azure Data Studio. You will also need to execute *Chinook* script first.

1. Clone the project repository

```sh
git clone url
```

2. Open project with Visual Studio

3. Navigate to *Program.cs*

4. Add breakpoint for each *return* statement

5. Click *Start* icon along with project name in top bar to see returned data

## Contributors

[Mikko Ryynänen (@mikkoryynanen)](https://github.com/mikkoryynanen)

[Arttu Hartikainen (@arttuhar)](https://github.com/arttuhar)
