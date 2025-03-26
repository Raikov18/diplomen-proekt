namespace diplomen_proekt.Models
{
    using System.Collections.Generic;

    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        // Добавяне на пица в кошницата
        public void AddItem(Pizza pizza, int quantity)
        {
            var cartItem = Items.FirstOrDefault(i => i.Pizza.PizzaId == pizza.PizzaId);
            if (cartItem == null)
            {
                Items.Add(new CartItem
                {
                    Pizza = pizza,
                    Quantity = quantity
                });
            }
            else
            {
                cartItem.Quantity += quantity;  // Увеличаваме количеството на съществуващия елемент
            }
        }

        // Премахване на пица от кошницата
        public void RemoveItem(int pizzaId)
        {
            var cartItem = Items.FirstOrDefault(i => i.Pizza.PizzaId == pizzaId);
            if (cartItem != null)
            {
                Items.Remove(cartItem);
            }
        }

        // Изчистване на кошницата
        public void Clear() => Items.Clear();

        // Изчисляване на общата стойност на кошницата
        public decimal GetTotal() => Items.Sum(i => i.Pizza.Price * i.Quantity);
    }

    public class CartItem
    {
        public Pizza Pizza { get; set; }
        public int Quantity { get; set; }
    }
}

