using System;
using System.Collections.Generic;
using WebApiMemoryLimit.Models;

namespace WebApiMemoryLimit.Repository
{
    public class ThingInitializer 
    {
        

        public static IList<Thing> GetThings()
        {
            return  new List<Thing>()
            {
                new Thing() {Id = new Guid("78510c96-e0b8-45e5-95d9-3eab0b5e8215"),Name="Thing 1",CreatedDateTime = DateTime.UtcNow, Description = "An interesting description"},
                new Thing() {Id = new Guid("e8309210-186e-499f-ac9a-486ba4aa1fbb"),Name="Thing 2",CreatedDateTime = DateTime.UtcNow, Description = "An interesting description"},
                new Thing() {Id = new Guid("58d04164-4a50-42d9-a7da-16470038304e"),Name="Thing 3",CreatedDateTime = DateTime.UtcNow, Description = "An interesting description"},
                new Thing() {Id = new Guid("a203e7af-6fa5-4fe0-a7e8-4b9628c7ee78"),Name="Thing 4",CreatedDateTime = DateTime.UtcNow, Description = "An interesting description"},
                new Thing() {Id = new Guid("c39af352-67a2-4903-a70f-434899e1c2dc"),Name="Thing 5",CreatedDateTime = DateTime.UtcNow, Description = "An interesting description"},
            };
        }
    }
}