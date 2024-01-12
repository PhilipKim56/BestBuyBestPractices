using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using BestBuyBestPractices;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

//var departmentRepo = new DepartmentRepo(conn);

//departmentRepo.InsertDepartment("Returns");

//var departments = departmentRepo.GetAllDepartments();

//foreach(var dept in departments)
//{
//    Console.WriteLine($"{dept.DepartmentID} | {dept.Name}");
//}

var repo = new ProductRepo(conn);

//repo.CreateProduct("Samsung TV", 500.00, 1, false, 1);

//repo.UpdateProductName(940, "Samsung LED TV");

//repo.DeleteProduct(940);

var products = repo.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine($"{product.ProductID}, | {product.Name} | {product.Price} | {product.CategoryID} | {product.OnSale} | {product.StockLevel}");
}