﻿using System;
using netboilerplate.Models;

namespace netboilerplate.Dtos.Character
{
	public class AddCharacterDto
	{
        public string Name { get; set; } = "Jhon";
        public int HitPoints { get; set; } = 100;
        public int Defence { get; set; } = 100;
        public int Strength { get; set; } = 100;
        public int Intelligence { get; set; } = 100;
        public RpgClass Class { get; set; } = RpgClass.Knight;
        //public AddBackpackDto Backpack { get; set; }
        //public List<AddWeaponDto> Weapons { get; set; }
    }
}

