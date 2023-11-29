using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Test_Taste_Console_Application.Domain.DataTransferObjects;

namespace Test_Taste_Console_Application.Domain.Objects
{
    public class Planet
    {
        public string Id { get; set; }
        public float SemiMajorAxis { get; set; }
        public ICollection<Moon> Moons { get; set; }
        
        public float AverageMoonGravity
        {
            get
            {
                if (Moons != null && Moons.Any())
                {
                    // Calculate the average gravity based on the Moons collection
                    float totalGravity = Moons.Sum(moon => moon.Gravity);
                    return totalGravity / Moons.Count;
                }
                else
                {
                    // Return a default value or handle the case where there are no moons
                    return 0.0f;
                }
            }
        }

        public Planet(PlanetDto planetDto)
        {
            Id = planetDto.Id;
            SemiMajorAxis = planetDto.SemiMajorAxis;
            Moons = new Collection<Moon>();
            if(planetDto.Moons != null)
            {
                foreach (MoonDto moonDto in planetDto.Moons)
                {
                    Moons.Add(new Moon(moonDto));
                }
            }
        }

        public Boolean HasMoons()
        {
            return (Moons != null && Moons.Count > 0);
        }
       
    }
}
