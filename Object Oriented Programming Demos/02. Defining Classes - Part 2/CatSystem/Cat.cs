﻿namespace CatSystem
{
    public class Cat
    {
        // constructor
        public Cat(CatColor color)
        {
            this.Color = color;
        }

        // properties
        public string Name { get; set; }

        public int Аgе { get; private set; }

        public Owner Owner { get; set; }

        public CatColor Color { get; private set; }
    }
}
