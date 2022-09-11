﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NorthBook.DataAccess.Repository.IRepository;
using NorthBook.Models;
using NorthBook.Models.ViewModels;

namespace NorthBook.Web.Areas.Customer.Controllers;
[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public IActionResult Index()
    {
        IEnumerable<Product?> productList = _unitOfWork.Product.GetAll(includeProperties: "Category,CoverType")!;

        return View(productList);
    }

    public IActionResult Details(int? id)
    {
        ShoppingCart cartObj = new()
        {
            Product = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id, includeProperties: "Category,CoverType")!,
            Count = 1
        };
        return View(cartObj);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}