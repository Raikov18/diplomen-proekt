using System.Linq;
using Microsoft.AspNetCore.Mvc;
using diplomen_proekt.Models; // Замени с твоето пространство от имена
using Microsoft.EntityFrameworkCore;
using diplomen_proekt.Data;
using diplomen_proekt.Models; // За работа с Entity Framework

public class PizzaController : Controller
{
    private readonly ApplicationDbContext _context;

    public PizzaController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Показване на менюто с пици
    public IActionResult Menu()
    {
        // Зареждаме пиците от базата данни
        var pizzas = _context.Pizzas.ToList();  // Получаваме всички пици от базата данни
        return View(pizzas);  // Връщаме пиците на изгледа
    }

    // Логика за добавяне на пица в кошницата
    [HttpPost]
    public IActionResult AddToCart(int pizzaId)
    {
        // Проверка дали пицата съществува в базата данни
        var pizza = _context.Pizzas.Find(pizzaId);

        if (pizza != null)
        {
            // Добавяме пицата в сесията (или в база данни, ако предпочиташ)
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
            cart.AddItem(pizza, 1);  // Добавяме пицата с количество 1
            HttpContext.Session.SetObjectAsJson("Cart", cart);
        }

        // Пренасочваме обратно към менюто
        return RedirectToAction("Menu");
    }

    // Логика за показване на кошницата
    public IActionResult Cart()
    {
        var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
        return View(cart);
    }

    // Логика за премахване на пица от кошницата
    public IActionResult RemoveFromCart(int pizzaId)
    {
        var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
        cart.RemoveItem(pizzaId);  // Премахваме пицата от кошницата
        HttpContext.Session.SetObjectAsJson("Cart", cart);

        return RedirectToAction("Cart");
    }
}

