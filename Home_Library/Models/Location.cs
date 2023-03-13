﻿namespace HomeLibrary.BusinessLogic.Models
{
    public class Location
    {
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        public Location(string building, string floor, string room)
        {
            Building = building;
            Floor = floor;
            Room = room;
        }
    }
}