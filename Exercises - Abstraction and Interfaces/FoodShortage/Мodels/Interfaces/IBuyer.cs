﻿namespace FoodShortage.Мodels.Interfaces
{
    public interface IBuyer
    {
        public string Name { get; }
        public int Food { get; }
        public void BuyFood();
    }
}
