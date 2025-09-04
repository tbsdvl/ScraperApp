// <copyright file="Seeder.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Entities.Lookups;
using Microsoft.EntityFrameworkCore;

namespace Listopotamus.Infrastructure.Data.Seed
{
    /// <summary>
    /// Represents the seed data class.
    /// </summary>
    internal class Seeder()
    {
        /// <summary>
        /// The system user name.
        /// </summary>
        private const string SYSTEM = "SYSTEM";

        /// <summary>
        /// Seeds the database.
        /// </summary>
        /// <param name="builder">The model builder.</param>
        public static void SeedData(ModelBuilder builder)
        {
            SeedMartketplaceTypes(builder);
            SeedCategoryTypes(builder);
            SeedLocationTypes(builder);
        }

        /// <summary>
        /// Seeds the marketplace types.
        /// </summary>
        /// <param name="builder">The model builder.</param>
        private static void SeedMartketplaceTypes(ModelBuilder builder)
        {
            builder.Entity<MarketplaceType>().HasData(new List<MarketplaceType>()
            {
                new ()
                {
                    Id = 1,
                    Name = "Ebay",
                    LookupValue = "Ebay",
                    Description = "The Ebay marketplace type.",
                    CreatedBy = SYSTEM,
                    UpdatedBy = SYSTEM,
                },
            });
        }

        /// <summary>
        /// Seeds the category types.
        /// </summary>
        /// <param name="builder">The model builder.</param>
        private static void SeedCategoryTypes(ModelBuilder builder)
        {
            builder.Entity<CategoryType>().HasData(new List<CategoryType>()
            {
                new () { Id = 1,  MarketplaceTypeId = 1, Name = "eBay Motors",                                 LookupValue = "6000",   Description = "The eBay Motors category type.",                                 CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 2,  MarketplaceTypeId = 1, Name = "Parts & Accessories",                         LookupValue = "6028",   Description = "The Parts & Accessories category type.",                         CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 3,  MarketplaceTypeId = 1, Name = "Car & Truck Parts & Accessories",             LookupValue = "6030",   Description = "The Car & Truck Parts & Accessories category type.",             CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 4,  MarketplaceTypeId = 1, Name = "Performance & Racing Parts",                  LookupValue = "107057", Description = "The Performance & Racing Parts category type.",                  CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 5,  MarketplaceTypeId = 1, Name = "Motorcycle & Scooter Parts & Accessories",    LookupValue = "10063",  Description = "The Motorcycle & Scooter Parts & Accessories category type.",    CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 6,  MarketplaceTypeId = 1, Name = "In-Car Technology, GPS & Security Devices",   LookupValue = "38635",  Description = "The In-Car Technology, GPS & Security Devices category type.",  CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 7,  MarketplaceTypeId = 1, Name = "Vehicle Repair Manuals & Literature",         LookupValue = "6029",   Description = "The Vehicle Repair Manuals & Literature category type.",       CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 8,  MarketplaceTypeId = 1, Name = "Boat Parts",                                  LookupValue = "26443",  Description = "The Boat Parts category type.",                                  CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 9,  MarketplaceTypeId = 1, Name = "Other Vehicles & Trailers",                   LookupValue = "6038",   Description = "The Other Vehicles & Trailers category type.",                 CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 10,  MarketplaceTypeId = 1, Name = "RVs & Campers",                               LookupValue = "50054",  Description = "The RVs & Campers category type.",                               CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 11,  MarketplaceTypeId = 1, Name = "Commercial Trucks",                           LookupValue = "63732",  Description = "The Commercial Trucks category type.",                           CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 12,  MarketplaceTypeId = 1, Name = "Buses",                                       LookupValue = "6728",   Description = "The Buses category type.",                                       CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 13,  MarketplaceTypeId = 1, Name = "Military Vehicles",                           LookupValue = "80765",  Description = "The Military Vehicles category type.",                           CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 14,  MarketplaceTypeId = 1, Name = "Vehicle Trailers",                            LookupValue = "66468",  Description = "The Vehicle Trailers category type.",                            CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 15,  MarketplaceTypeId = 1, Name = "Golf Carts",                                  LookupValue = "181476", Description = "The Golf Carts category type.",                                  CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 16,  MarketplaceTypeId = 1, Name = "Motorcycles",                                 LookupValue = "6024",   Description = "The Motorcycles category type.",                                 CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 17,  MarketplaceTypeId = 1, Name = "Harley-Davidson Motorcycles",                 LookupValue = "49992",  Description = "The Harley-Davidson Motorcycles category type.",                 CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 18,  MarketplaceTypeId = 1, Name = "Honda Motorcycles",                           LookupValue = "49998",  Description = "The Honda Motorcycles category type.",                           CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 19,  MarketplaceTypeId = 1, Name = "Indian Motorcycles",                          LookupValue = "6709",   Description = "The Indian Motorcycles category type.",                          CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 20,  MarketplaceTypeId = 1, Name = "Suzuki Motorcycles",                          LookupValue = "50025",  Description = "The Suzuki Motorcycles category type.",                          CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 21,  MarketplaceTypeId = 1, Name = "Yamaha Motorcycles",                          LookupValue = "50041",  Description = "The Yamaha Motorcycles category type.",                          CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 22,  MarketplaceTypeId = 1, Name = "Triumph Motorcycles",                         LookupValue = "50035",  Description = "The Triumph Motorcycles category type.",                         CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 23,  MarketplaceTypeId = 1, Name = "Powersports",                                 LookupValue = "66466",  Description = "The Powersports category type.",                                 CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 24,  MarketplaceTypeId = 1, Name = "ATVs",                                        LookupValue = "6723",   Description = "The ATVs category type.",                                        CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 25,  MarketplaceTypeId = 1, Name = "UTVs",                                        LookupValue = "173665", Description = "The UTVs category type.",                                        CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 26,  MarketplaceTypeId = 1, Name = "Scooters & Mopeds",                           LookupValue = "6720",   Description = "The Scooters & Mopeds category type.",                           CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 27,  MarketplaceTypeId = 1, Name = "Personal Watercraft",                         LookupValue = "1295",   Description = "The Personal Watercraft category type.",                         CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 28,  MarketplaceTypeId = 1, Name = "Dune Buggies & Sand Rails",                   LookupValue = "133220", Description = "The Dune Buggies & Sand Rails category type.",                   CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 29,  MarketplaceTypeId = 1, Name = "Snowmobiles",                                 LookupValue = "42595",  Description = "The Snowmobiles category type.",                                 CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 30,  MarketplaceTypeId = 1, Name = "Automotive Tools & Supplies",                 LookupValue = "34998",  Description = "The Automotive Tools & Supplies category type.",                 CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 31,  MarketplaceTypeId = 1, Name = "Automotive Hand Tools",                       LookupValue = "43990",  Description = "The Automotive Hand Tools category type.",                       CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 32,  MarketplaceTypeId = 1, Name = "Automotive Shop Equipment & Supplies",        LookupValue = "183745", Description = "The Automotive Shop Equipment & Supplies category type.",        CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 33,  MarketplaceTypeId = 1, Name = "Automotive Diagnostic Service Tools",         LookupValue = "179474", Description = "The Automotive Diagnostic Service Tools category type.",         CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 34,  MarketplaceTypeId = 1, Name = "Automotive Tool Boxes & Storage",             LookupValue = "179443", Description = "The Automotive Tool Boxes & Storage category type.",             CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 35,  MarketplaceTypeId = 1, Name = "Automotive Air Tools",                        LookupValue = "43985",  Description = "The Automotive Air Tools category type.",                        CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 36,  MarketplaceTypeId = 1, Name = "Automotive Paints & Supplies",                LookupValue = "179421", Description = "The Automotive Paints & Supplies category type.",                CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 37,  MarketplaceTypeId = 1, Name = "Boats",                                       LookupValue = "26429",  Description = "The Boats category type.",                                       CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 38,  MarketplaceTypeId = 1, Name = "Powerboats & Motorboats",                     LookupValue = "31269",  Description = "The Powerboats & Motorboats category type.",                     CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 39,  MarketplaceTypeId = 1, Name = "Fishing Boats",                               LookupValue = "63723",  Description = "The Fishing Boats category type.",                               CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 40,  MarketplaceTypeId = 1, Name = "Sailboats",                                   LookupValue = "63728",  Description = "The Sailboats category type.",                                   CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 41,  MarketplaceTypeId = 1, Name = "Other Boats",                                 LookupValue = "26434",  Description = "The Other Boats category type.",                                 CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 42,  MarketplaceTypeId = 1, Name = "Safety & Security Accessories",               LookupValue = "262266", Description = "The Safety & Security Accessories category type.",               CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 43,  MarketplaceTypeId = 1, Name = "Car & Truck Safety",                          LookupValue = "180136", Description = "The Car & Truck Safety category type.",                          CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 44,  MarketplaceTypeId = 1, Name = "Car & Truck Security",                        LookupValue = "180141", Description = "The Car & Truck Security category type.",                        CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                // Popular Topics (unique numeric categories only)
                new () { Id = 45,  MarketplaceTypeId = 1, Name = "Cars & Trucks",                               LookupValue = "6001",   Description = "The Cars & Trucks category type.",                               CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 46,  MarketplaceTypeId = 1, Name = "Complete Engines",                            LookupValue = "33615",  Description = "The Complete Engines category type.",                            CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                // Computers / Tablets / Networking
                new () { Id = 47,  MarketplaceTypeId = 1, Name = "Computers/Tablets & Networking",            LookupValue = "58058",  Description = "Computers/Tablets & Networking.",            CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 48,  MarketplaceTypeId = 1, Name = "Laptops & Netbooks",                         LookupValue = "175672", Description = "Laptops & Netbooks.",                         CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 49,  MarketplaceTypeId = 1, Name = "Computer Components & Parts",                LookupValue = "175673", Description = "Computer Components & Parts.",                CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 50,  MarketplaceTypeId = 1, Name = "Tablets & eReaders",                         LookupValue = "171485", Description = "Tablets & eReaders.",                         CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 51,  MarketplaceTypeId = 1, Name = "Desktops & All-In-One Computers",            LookupValue = "171957", Description = "Desktops & All-In-One Computers.",            CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 52,  MarketplaceTypeId = 1, Name = "Computer Drives, Storage & Blank Media",     LookupValue = "165",    Description = "Computer Drives, Storage & Blank Media.",   CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 53,  MarketplaceTypeId = 1, Name = "Computer Monitors, Projectors & Accessories", LookupValue = "162497", Description = "Computer Monitors, Projectors & Accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Cell Phones & Accessories
                new () { Id = 54,  MarketplaceTypeId = 1, Name = "Cell Phones & Accessories",                  LookupValue = "15032",  Description = "Cell Phones & Accessories.",                  CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 55,  MarketplaceTypeId = 1, Name = "Cell Phones & Smartphones",                  LookupValue = "9355",   Description = "Cell Phones & Smartphones.",                  CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 56,  MarketplaceTypeId = 1, Name = "Cell Phone Accessories",                     LookupValue = "9394",   Description = "Cell Phone Accessories.",                     CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 57,  MarketplaceTypeId = 1, Name = "Portable Audio & Headphones",                LookupValue = "15052",  Description = "Portable Audio & Headphones.",                CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 58,  MarketplaceTypeId = 1, Name = "Smart Watches",                              LookupValue = "178893", Description = "Smart Watches.",                              CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 59,  MarketplaceTypeId = 1, Name = "Cell Phone & Smartphone Parts",              LookupValue = "43304",  Description = "Cell Phone & Smartphone Parts.",              CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 60,  MarketplaceTypeId = 1, Name = "Smart Watch Accessories",                    LookupValue = "182064", Description = "Smart Watch Accessories.",                    CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Video Games & Consoles
                new () { Id = 61,  MarketplaceTypeId = 1, Name = "Video Games & Consoles",                     LookupValue = "1249",   Description = "Video Games & Consoles.",                     CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 62,  MarketplaceTypeId = 1, Name = "Video Games",                                LookupValue = "139973", Description = "Video Games.",                                CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 63,  MarketplaceTypeId = 1, Name = "Video Game Accessories",                     LookupValue = "54968",  Description = "Video Game Accessories.",                     CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 64,  MarketplaceTypeId = 1, Name = "Video Game Consoles",                        LookupValue = "139971", Description = "Video Game Consoles.",                        CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 65,  MarketplaceTypeId = 1, Name = "Video Game Merchandise",                     LookupValue = "38583",  Description = "Video Game Merchandise.",                     CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 66,  MarketplaceTypeId = 1, Name = "Video Game Replacement Parts & Tools",       LookupValue = "171833", Description = "Video Game Replacement Parts & Tools.",       CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 67,  MarketplaceTypeId = 1, Name = "Video Game Strategy Guides & Cheats",        LookupValue = "156595", Description = "Video Game Strategy Guides & Cheats.",        CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Cameras & Photo
                new () { Id = 68,  MarketplaceTypeId = 1, Name = "Cameras & Photo",                            LookupValue = "625",    Description = "Cameras & Photo.",                            CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 69,  MarketplaceTypeId = 1, Name = "Digital Cameras",                            LookupValue = "31388",  Description = "Digital Cameras.",                            CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 70,  MarketplaceTypeId = 1, Name = "Camera Lenses & Filters",                    LookupValue = "78997",  Description = "Camera Lenses & Filters.",                    CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 71,  MarketplaceTypeId = 1, Name = "Film Photography Equipment",                 LookupValue = "69323",  Description = "Film Photography Equipment.",                 CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 72,  MarketplaceTypeId = 1, Name = "Camcorders",                                 LookupValue = "11724",  Description = "Camcorders.",                                 CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 73,  MarketplaceTypeId = 1, Name = "Camera, Drone & Photo Accessories",          LookupValue = "15200",  Description = "Camera, Drone & Photo Accessories.",          CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 74,  MarketplaceTypeId = 1, Name = "Camera Drones",                              LookupValue = "179697", Description = "Camera Drones.",                              CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // TV, Video & Home Audio
                new () { Id = 75,  MarketplaceTypeId = 1, Name = "TV, Video & Home Audio",                     LookupValue = "32852",  Description = "TV, Video & Home Audio.",                     CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 76,  MarketplaceTypeId = 1, Name = "Home Audio Equipment",                       LookupValue = "184973", Description = "Home Audio Equipment.",                       CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 77,  MarketplaceTypeId = 1, Name = "TV & Video Equipment",                       LookupValue = "184972", Description = "TV & Video Equipment.",                       CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 78,  MarketplaceTypeId = 1, Name = "Media Streamers",                            LookupValue = "168058", Description = "Media Streamers.",                            CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 79,  MarketplaceTypeId = 1, Name = "TV, Video & Audio Accessories",              LookupValue = "14961",  Description = "TV, Video & Audio Accessories.",              CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 80,  MarketplaceTypeId = 1, Name = "TV, Video & Audio Parts",                    LookupValue = "71582",  Description = "TV, Video & Audio Parts.",                    CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 81,  MarketplaceTypeId = 1, Name = "Other TV, Video & Home Audio Equipment",     LookupValue = "163829", Description = "Other TV, Video & Home Audio Equipment.",     CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Portable Audio & Headphones (subs)
                new () { Id = 82,  MarketplaceTypeId = 1, Name = "Headphones",                                 LookupValue = "112529", Description = "Headphones.",                                 CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 83,  MarketplaceTypeId = 1, Name = "MP3 Players",                                LookupValue = "73839",  Description = "MP3 Players.",                                CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 84,  MarketplaceTypeId = 1, Name = "Audio Player Docks & Mini Speakers",         LookupValue = "111694", Description = "Audio Player Docks & Mini Speakers.",         CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 85,  MarketplaceTypeId = 1, Name = "Personal CD Players",                        LookupValue = "15054",  Description = "Personal CD Players.",                        CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 86,  MarketplaceTypeId = 1, Name = "Portable Stereos & Boomboxes",               LookupValue = "48626",  Description = "Portable Stereos & Boomboxes.",               CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 87,  MarketplaceTypeId = 1, Name = "Personal Cassette Players",                  LookupValue = "15053",  Description = "Personal Cassette Players.",                  CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Vehicle Electronics & GPS
                new () { Id = 88,  MarketplaceTypeId = 1, Name = "Vehicle Electronics & GPS",                  LookupValue = "3270",   Description = "Vehicle Electronics & GPS.",                  CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 89,  MarketplaceTypeId = 1, Name = "Car Audio in Consumer Electronics",          LookupValue = "175716", Description = "Car Audio in Consumer Electronics.",          CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 90,  MarketplaceTypeId = 1, Name = "Car GPS Units",                              LookupValue = "156955", Description = "Car GPS Units.",                              CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 91,  MarketplaceTypeId = 1, Name = "Car Audio & Video Installation Equipment",   LookupValue = "32806",  Description = "Car Audio & Video Installation Equipment.",   CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 92,  MarketplaceTypeId = 1, Name = "Marine Audio in Consumer Electronics",       LookupValue = "168105", Description = "Marine Audio in Consumer Electronics.",       CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 93,  MarketplaceTypeId = 1, Name = "Car Video Monitors & Equipment",             LookupValue = "48604",  Description = "Car Video Monitors & Equipment.",             CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 94,  MarketplaceTypeId = 1, Name = "Car Electronics Accessories",                LookupValue = "60207",  Description = "Car Electronics Accessories.",                CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Surveillance & Smart Home
                new () { Id = 95,  MarketplaceTypeId = 1, Name = "Surveillance & Smart Home Electronics",      LookupValue = "185067", Description = "Surveillance & Smart Home Electronics.",      CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 96,  MarketplaceTypeId = 1, Name = "Home Surveillance Systems",                  LookupValue = "48633",  Description = "Home Surveillance Systems.",                  CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 97,  MarketplaceTypeId = 1, Name = "Smart Speakers, Hubs & Accessories",         LookupValue = "185034", Description = "Smart Speakers, Hubs & Accessories.",         CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 98,  MarketplaceTypeId = 1, Name = "Other Smart Home Electronics",               LookupValue = "185065", Description = "Other Smart Home Electronics.",               CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 99,  MarketplaceTypeId = 1, Name = "Smart Plugs",                                LookupValue = "185061", Description = "Smart Plugs.",                                CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Home Surveillance (subs)
                new () { Id = 100, MarketplaceTypeId = 1, Name = "Home Security Cameras",                      LookupValue = "48638",  Description = "Home Security Cameras.",                      CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 101, MarketplaceTypeId = 1, Name = "IP & Smart Security Camera Systems",         LookupValue = "185053", Description = "IP & Smart Security Camera Systems.",         CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 102, MarketplaceTypeId = 1, Name = "Home Surveillance Parts & Accessories",      LookupValue = "185048", Description = "Home Surveillance Parts & Accessories.",      CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 103, MarketplaceTypeId = 1, Name = "Home Sensors & Motion Detectors",            LookupValue = "115940", Description = "Home Sensors & Motion Detectors.",            CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 104, MarketplaceTypeId = 1, Name = "Dummy Home Security Cameras",                LookupValue = "75395",  Description = "Dummy Home Security Cameras.",                CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 105, MarketplaceTypeId = 1, Name = "Home CCTV Systems",                          LookupValue = "159909", Description = "Home CCTV Systems.",                          CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Major Appliances
                new () { Id = 106, MarketplaceTypeId = 1, Name = "Major Appliances",                           LookupValue = "20710",  Description = "Major Appliances.",                           CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 107, MarketplaceTypeId = 1, Name = "Refrigerators, Freezers, Parts & Accessories", LookupValue = "71258",  Description = "Refrigerators, Freezers, Parts & Accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 108, MarketplaceTypeId = 1, Name = "Major Appliances Parts & Accessories",       LookupValue = "260308", Description = "Major Appliances Parts & Accessories.",       CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 109, MarketplaceTypeId = 1, Name = "Ranges & Cooking Appliances",                LookupValue = "43563",  Description = "Ranges & Cooking Appliances.",                CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 110, MarketplaceTypeId = 1, Name = "Washers, Dryers, Parts & Accessories",       LookupValue = "42231",  Description = "Washers, Dryers, Parts & Accessories.",       CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 111, MarketplaceTypeId = 1, Name = "Dishwashers",                                LookupValue = "116023", Description = "Dishwashers.",                                CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 112, MarketplaceTypeId = 1, Name = "Other Major Home Appliances",                LookupValue = "20715",  Description = "Other Major Home Appliances.",                CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Virtual Reality
                new () { Id = 113, MarketplaceTypeId = 1, Name = "Virtual Reality",                            LookupValue = "183067", Description = "Virtual Reality.",                            CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 114, MarketplaceTypeId = 1, Name = "VR Headsets",                                LookupValue = "183068", Description = "VR Headsets.",                                CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 115, MarketplaceTypeId = 1, Name = "Smartphone VR Headsets",                     LookupValue = "183069", Description = "Smartphone VR Headsets.",                     CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 116, MarketplaceTypeId = 1, Name = "VR Controllers & Motion Sensors",            LookupValue = "183071", Description = "VR Controllers & Motion Sensors.",            CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 117, MarketplaceTypeId = 1, Name = "Other Virtual Reality Accessories",          LookupValue = "183073", Description = "Other Virtual Reality Accessories.",          CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 118, MarketplaceTypeId = 1, Name = "VR Cases, Covers & Skins",                   LookupValue = "183070", Description = "VR Cases, Covers & Skins.",                   CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 119, MarketplaceTypeId = 1, Name = "Standalone VR Headsets",                     LookupValue = "184645", Description = "Standalone VR Headsets.",                     CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Popular Topics (unique numeric codes only)
                new () { Id = 120, MarketplaceTypeId = 1, Name = "NVIDIA Computer Graphics, Video Cards",      LookupValue = "27386",  Description = "NVIDIA Computer Graphics, Video Cards.",      CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 121, MarketplaceTypeId = 1, Name = "Dell Laptops & Netbooks",                    LookupValue = "177",    Description = "Dell Laptops & Netbooks.",                    CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 122, MarketplaceTypeId = 1, Name = "MacBook Pro",                                LookupValue = "111422", Description = "MacBook Pro.",                                CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Sports Mem, Cards & Fan Shop
                new () { Id = 123, MarketplaceTypeId = 1, Name = "Sports Mem, Cards & Fan Shop",                LookupValue = "64482",  Description = "Sports memorabilia, cards, and fan shop.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 124, MarketplaceTypeId = 1, Name = "Sports Trading Cards & Accessories",          LookupValue = "212",    Description = "Sports trading cards & accessories.",      CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 125, MarketplaceTypeId = 1, Name = "Sports Fan Apparel & Souvenirs",              LookupValue = "24409",  Description = "Sports fan apparel & souvenirs.",          CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 126, MarketplaceTypeId = 1, Name = "Vintage Sports Memorabilia",                  LookupValue = "50123",  Description = "Vintage sports memorabilia.",              CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 127, MarketplaceTypeId = 1, Name = "Original Sport Autographed Items",            LookupValue = "51",     Description = "Original autographed items.",             CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 128, MarketplaceTypeId = 1, Name = "Game Used Sports Memorabilia",                LookupValue = "50116",  Description = "Game-used sports memorabilia.",            CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 129, MarketplaceTypeId = 1, Name = "Collectible Sports Stickers, Collections & Albums", LookupValue = "262343", Description = "Sports stickers, collections & albums.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Collectibles
                new () { Id = 130, MarketplaceTypeId = 1, Name = "Collectibles",                                LookupValue = "1",      Description = "Collectibles.",                            CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 131, MarketplaceTypeId = 1, Name = "Comic Books, Manga & Memorabilia",            LookupValue = "63",     Description = "Comics, manga, and memorabilia.",         CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 132, MarketplaceTypeId = 1, Name = "Decorative Collectibles",                     LookupValue = "13777",  Description = "Decorative collectibles.",                 CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 133, MarketplaceTypeId = 1, Name = "Collectible Knives, Swords, Blades, Armors & Accessories", LookupValue = "1401", Description = "Collectible knives and related.",   CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 134, MarketplaceTypeId = 1, Name = "Non-Sport Trading Cards & Accessories",       LookupValue = "182982", Description = "Non-sport trading cards.",                  CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 135, MarketplaceTypeId = 1, Name = "Holiday & Seasonal Collectibles",             LookupValue = "907",    Description = "Holiday & seasonal collectibles.",        CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 136, MarketplaceTypeId = 1, Name = "Collectible Figures & Supplies",              LookupValue = "263076", Description = "Collectible figures & supplies.",           CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Dolls & Bears
                new () { Id = 137, MarketplaceTypeId = 1, Name = "Dolls & Bears",                               LookupValue = "237",    Description = "Dolls & teddy bears.",                    CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 138, MarketplaceTypeId = 1, Name = "Dolls, Clothing & Accessories",               LookupValue = "238",    Description = "Dolls, clothing & accessories.",          CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 139, MarketplaceTypeId = 1, Name = "Dollhouses & Dollhouse Miniatures",           LookupValue = "1202",   Description = "Dollhouses & miniatures.",                CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 140, MarketplaceTypeId = 1, Name = "Teddy Bears, Clothing & Accessories",         LookupValue = "262353", Description = "Teddy bears and accessories.",              CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 141, MarketplaceTypeId = 1, Name = "Paper Dolls, Paper Doll Clothes & Accessories", LookupValue = "2440", Description = "Paper dolls and accessories.",              CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Vintage & Antique Jewelry
                new () { Id = 142, MarketplaceTypeId = 1, Name = "Vintage & Antique Jewelry",                   LookupValue = "262024", Description = "Vintage & antique jewelry.",                 CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 143, MarketplaceTypeId = 1, Name = "Vintage & Antique Necklaces & Pendants",      LookupValue = "262013", Description = "Vintage & antique necklaces & pendants.",    CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 144, MarketplaceTypeId = 1, Name = "Vintage & Antique Collections & Lots",        LookupValue = "262016", Description = "Vintage & antique collections & lots.",       CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 145, MarketplaceTypeId = 1, Name = "Vintage & Antique Rings",                     LookupValue = "262014", Description = "Vintage & antique rings.",                    CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 146, MarketplaceTypeId = 1, Name = "Vintage & Antique Bracelets & Charms",        LookupValue = "262003", Description = "Vintage & antique bracelets & charms.",       CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 147, MarketplaceTypeId = 1, Name = "Vintage & Antique Brooches & Pins",           LookupValue = "262004", Description = "Vintage & antique brooches & pins.",          CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 148, MarketplaceTypeId = 1, Name = "Vintage & Antique Earrings",                  LookupValue = "262008", Description = "Vintage & antique earrings.",                 CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Coins & Paper Money
                new () { Id = 149, MarketplaceTypeId = 1, Name = "Coins & Paper Money",                         LookupValue = "11116",  Description = "Coins and paper money.",                     CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 150, MarketplaceTypeId = 1, Name = "US Coins",                                    LookupValue = "253",    Description = "US coins.",                                CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 151, MarketplaceTypeId = 1, Name = "Bullion",                                     LookupValue = "39482",  Description = "Bullion.",                                   CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 152, MarketplaceTypeId = 1, Name = "World Coins",                                 LookupValue = "256",    Description = "World coins.",                              CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 153, MarketplaceTypeId = 1, Name = "US Paper Money",                              LookupValue = "3412",   Description = "US paper money.",                           CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 154, MarketplaceTypeId = 1, Name = "World Paper Money",                           LookupValue = "3411",   Description = "World paper money.",                        CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 155, MarketplaceTypeId = 1, Name = "Virtual Currency",                            LookupValue = "179197", Description = "Virtual currency.",                           CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Pottery & Glass
                new () { Id = 156, MarketplaceTypeId = 1, Name = "Pottery & Glass",                             LookupValue = "870",    Description = "Pottery & glass.",                          CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 157, MarketplaceTypeId = 1, Name = "Decorative Cookware, Dinnerware & Serveware", LookupValue = "262364", Description = "Decorative cookware/dinnerware/serveware.",    CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 158, MarketplaceTypeId = 1, Name = "Decorative Pottery & Glassware",              LookupValue = "262384", Description = "Decorative pottery & glassware.",             CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 159, MarketplaceTypeId = 1, Name = "Pottery & Glass Drinkware & Barware",         LookupValue = "262359", Description = "Drinkware & barware.",                          CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 160, MarketplaceTypeId = 1, Name = "Pottery & Glass Lamps, Lighting",             LookupValue = "262410", Description = "Lamps & lighting.",                              CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 161, MarketplaceTypeId = 1, Name = "Pottery & Glass Price Guides & Publications", LookupValue = "170129", Description = "Price guides & publications.",                    CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 162, MarketplaceTypeId = 1, Name = "Other Pottery & Glass",                       LookupValue = "262365", Description = "Other pottery & glass.",                         CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Art
                new () { Id = 163, MarketplaceTypeId = 1, Name = "Art",                                         LookupValue = "550",    Description = "Art.",                                        CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 164, MarketplaceTypeId = 1, Name = "Art Paintings",                               LookupValue = "551",    Description = "Paintings.",                                  CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 165, MarketplaceTypeId = 1, Name = "Art Prints",                                  LookupValue = "360",    Description = "Prints.",                                      CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 166, MarketplaceTypeId = 1, Name = "Art Photographs",                             LookupValue = "2211",   Description = "Photographs.",                                CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 167, MarketplaceTypeId = 1, Name = "Art Posters",                                 LookupValue = "28009",  Description = "Posters.",                                      CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 168, MarketplaceTypeId = 1, Name = "Art Sculptures",                              LookupValue = "553",    Description = "Sculptures.",                                 CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 169, MarketplaceTypeId = 1, Name = "Art Drawings",                                LookupValue = "552",    Description = "Drawings.",                                   CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Antiques
                new () { Id = 170, MarketplaceTypeId = 1, Name = "Antiques",                                    LookupValue = "20081",  Description = "Antiques.",                                     CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 171, MarketplaceTypeId = 1, Name = "Antique Furniture",                           LookupValue = "20091",  Description = "Antique furniture.",                          CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 172, MarketplaceTypeId = 1, Name = "Silver Antiques",                             LookupValue = "20096",  Description = "Silver antiques.",                             CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 173, MarketplaceTypeId = 1, Name = "Antique Rugs & Carpets",                      LookupValue = "37978",  Description = "Rugs & carpets.",                              CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 174, MarketplaceTypeId = 1, Name = "Asian Antiques",                              LookupValue = "20082",  Description = "Asian antiques.",                              CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 175, MarketplaceTypeId = 1, Name = "Architectural & Garden Antiques",             LookupValue = "4707",   Description = "Architectural & garden antiques.",            CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 176, MarketplaceTypeId = 1, Name = "Sewing Antiques",                             LookupValue = "156323", Description = "Sewing antiques.",                             CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Crafts
                new () { Id = 177, MarketplaceTypeId = 1, Name = "Crafts",                                      LookupValue = "14339",  Description = "Art & craft supplies.",                        CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 178, MarketplaceTypeId = 1, Name = "Fabric",                                      LookupValue = "28162",  Description = "Fabric.",                                        CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 179, MarketplaceTypeId = 1, Name = "Yarn, Sewing & Needlecraft Supplies",         LookupValue = "160706", Description = "Yarn and needlecraft.",                         CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 180, MarketplaceTypeId = 1, Name = "Sewing Tools & Supplies",                     LookupValue = "160737", Description = "Sewing tools & supplies.",                      CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 181, MarketplaceTypeId = 1, Name = "Art Supplies",                                LookupValue = "11783",  Description = "Art supplies.",                                 CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 182, MarketplaceTypeId = 1, Name = "Scrapbooking & Paper Craft Supplies",         LookupValue = "11788",  Description = "Scrapbooking & paper craft.",                 CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 183, MarketplaceTypeId = 1, Name = "Home Arts & Crafts",                          LookupValue = "160667", Description = "Home arts & crafts.",                           CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Stamps
                new () { Id = 184, MarketplaceTypeId = 1, Name = "Stamps",                                      LookupValue = "260",    Description = "Postage stamps.",                            CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 185, MarketplaceTypeId = 1, Name = "Middle Eastern Stamps",                       LookupValue = "181422", Description = "Middle Eastern stamps.",                        CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 186, MarketplaceTypeId = 1, Name = "United States Stamps",                        LookupValue = "261",    Description = "United States stamps.",                      CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 187, MarketplaceTypeId = 1, Name = "European Stamps",                             LookupValue = "4742",   Description = "European stamps.",                           CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 188, MarketplaceTypeId = 1, Name = "Worldwide Stamps",                            LookupValue = "181420", Description = "Worldwide stamps.",                            CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 189, MarketplaceTypeId = 1, Name = "Asian Stamps",                                LookupValue = "181416", Description = "Asian stamps.",                                 CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 190, MarketplaceTypeId = 1, Name = "British Colony & Territory Stamps",           LookupValue = "65174",  Description = "British colony & territory stamps.",          CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Entertainment Memorabilia
                new () { Id = 191, MarketplaceTypeId = 1, Name = "Entertainment Memorabilia",                   LookupValue = "45100",  Description = "Entertainment memorabilia.",                  CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 192, MarketplaceTypeId = 1, Name = "Music Memorabilia",                           LookupValue = "2329",   Description = "Music memorabilia.",                         CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 193, MarketplaceTypeId = 1, Name = "Movie Memorabilia",                           LookupValue = "196",    Description = "Movie memorabilia.",                         CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 194, MarketplaceTypeId = 1, Name = "Video Game Collectibles",                     LookupValue = "45101",  Description = "Video game collectibles.",                    CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 195, MarketplaceTypeId = 1, Name = "Original Autographed Entertainment Memorabilia", LookupValue = "57",  Description = "Autographed entertainment items.",            CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 196, MarketplaceTypeId = 1, Name = "Theater Memorabilia",                         LookupValue = "2362",   Description = "Theater memorabilia.",                       CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 197, MarketplaceTypeId = 1, Name = "TV Memorabilia",                              LookupValue = "1424",   Description = "TV memorabilia.",                            CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Popular Topics (unique numeric codes only)
                new () { Id = 198, MarketplaceTypeId = 1, Name = "Trading Card Singles",                        LookupValue = "261328", Description = "Trading card singles.",                         CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 199, MarketplaceTypeId = 1, Name = "Barbie Dolls & Doll Playsets",                LookupValue = "262346", Description = "Barbie dolls & playsets.",                      CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 200, MarketplaceTypeId = 1, Name = "Funko Pop!",                                  LookupValue = "149372", Description = "Funko Pop!",                                      CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 201, MarketplaceTypeId = 1, Name = "US comics, graphic novels & TPBs",            LookupValue = "259104", Description = "US comics, graphic novels & TPBs.",              CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Top category
                new () { Id = 202, MarketplaceTypeId = 1, Name = "Home & Garden",                        LookupValue = "11700",  Description = "Home & Garden root.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Home Décor
                new () { Id = 203, MarketplaceTypeId = 1, Name = "Home Décor",                           LookupValue = "10033",  Description = "Home décor.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 204, MarketplaceTypeId = 1, Name = "Home Décor Posters & Prints",          LookupValue = "41511",  Description = "Décor posters and prints.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 205, MarketplaceTypeId = 1, Name = "Decorative Clocks",                    LookupValue = "258031", Description = "Decorative clocks.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 206, MarketplaceTypeId = 1, Name = "Décor Decals, Stickers & Vinyl Art",   LookupValue = "159889", Description = "Decals, stickers, vinyl art.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Yard, Garden & Outdoor Living
                new () { Id = 207, MarketplaceTypeId = 1, Name = "Yard, Garden & Outdoor Living",        LookupValue = "159912", Description = "Yard, garden & outdoor.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 208, MarketplaceTypeId = 1, Name = "Plants, Seeds & Bulbs",                LookupValue = "181003", Description = "Plants, seeds, bulbs.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 209, MarketplaceTypeId = 1, Name = "Outdoor Power Equipment",              LookupValue = "29518",  Description = "Outdoor power equipment.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 210, MarketplaceTypeId = 1, Name = "Lawn Mowers, Parts & Accessories",     LookupValue = "43560",  Description = "Mowers and parts.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 211, MarketplaceTypeId = 1, Name = "Pools & Spas",                         LookupValue = "20727",  Description = "Pools and spas.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 212, MarketplaceTypeId = 1, Name = "Patio & Garden Furniture",             LookupValue = "25863",  Description = "Patio & garden furniture.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 213, MarketplaceTypeId = 1, Name = "Outdoor Lighting",                     LookupValue = "42154",  Description = "Outdoor lighting.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Kitchen, Dining & Bar
                new () { Id = 214, MarketplaceTypeId = 1, Name = "Kitchen, Dining & Bar",                LookupValue = "20625",  Description = "Kitchen, dining & bar.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 215, MarketplaceTypeId = 1, Name = "Small Kitchen Appliances",             LookupValue = "20667",  Description = "Small kitchen appliances.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 216, MarketplaceTypeId = 1, Name = "Kitchen, Dining & Bar Storage Equipment", LookupValue = "20652", Description = "Kitchen storage equipment.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 217, MarketplaceTypeId = 1, Name = "Flatware, Knives & Cutlery",           LookupValue = "20637",  Description = "Flatware and cutlery.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 218, MarketplaceTypeId = 1, Name = "Dinnerware & Serveware",               LookupValue = "36027",  Description = "Dinnerware and serveware.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 219, MarketplaceTypeId = 1, Name = "Cookware",                             LookupValue = "259322", Description = "Cookware.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 220, MarketplaceTypeId = 1, Name = "Kitchen Tools & Gadgets",              LookupValue = "20635",  Description = "Kitchen tools & gadgets.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Home Improvement
                new () { Id = 221, MarketplaceTypeId = 1, Name = "Home Improvement",                      LookupValue = "159907", Description = "Home improvement.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 222, MarketplaceTypeId = 1, Name = "Home HVAC, Parts & Accessories",        LookupValue = "30565",  Description = "Home HVAC parts and accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 223, MarketplaceTypeId = 1, Name = "Electrical Supplies",                   LookupValue = "259482", Description = "Electrical supplies.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 224, MarketplaceTypeId = 1, Name = "Building & Hardware Supplies",          LookupValue = "3187",   Description = "Building and hardware supplies.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 225, MarketplaceTypeId = 1, Name = "Home Security Equipment",               LookupValue = "41968",  Description = "Home security equipment.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 226, MarketplaceTypeId = 1, Name = "Home Plumbing & Fixtures",              LookupValue = "20601",  Description = "Plumbing and fixtures.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 227, MarketplaceTypeId = 1, Name = "Other Home Improvement Supplies",       LookupValue = "160038", Description = "Other home improvement supplies.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Furniture
                new () { Id = 228, MarketplaceTypeId = 1, Name = "Furniture",                             LookupValue = "3197",   Description = "Home furniture.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 229, MarketplaceTypeId = 1, Name = "Sofas, Armchairs & Couches",            LookupValue = "38208",  Description = "Sofas, armchairs, couches.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 230, MarketplaceTypeId = 1, Name = "Beds & Headboards",                     LookupValue = "32254",  Description = "Beds and headboards.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 231, MarketplaceTypeId = 1, Name = "Chairs",                                LookupValue = "54235",  Description = "Chairs.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 232, MarketplaceTypeId = 1, Name = "Tables",                                LookupValue = "38204",  Description = "Tables.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 233, MarketplaceTypeId = 1, Name = "Bookcases & Shelving",                  LookupValue = "3199",   Description = "Bookcases and shelving.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 234, MarketplaceTypeId = 1, Name = "Home Office Desks",                     LookupValue = "88057",  Description = "Home office desks.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Tools & Workshop Equipment
                new () { Id = 235, MarketplaceTypeId = 1, Name = "Tools & Workshop Equipment",            LookupValue = "631",    Description = "Tools and workshop equipment.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 236, MarketplaceTypeId = 1, Name = "Power Tools",                           LookupValue = "3247",   Description = "Power tools.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 237, MarketplaceTypeId = 1, Name = "Hand Tools",                            LookupValue = "3244",   Description = "Hand tools.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 238, MarketplaceTypeId = 1, Name = "Power Tool & Air Tool Accessories",     LookupValue = "260176", Description = "Power/air tool accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 239, MarketplaceTypeId = 1, Name = "Tool Boxes & Storage",                  LookupValue = "130140", Description = "Tool boxes and storage.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 240, MarketplaceTypeId = 1, Name = "Air Tools & Air Compressors",           LookupValue = "85759",  Description = "Air tools and compressors.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 241, MarketplaceTypeId = 1, Name = "Measuring & Layout Tools",              LookupValue = "29523",  Description = "Measuring and layout tools.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Bedding
                new () { Id = 242, MarketplaceTypeId = 1, Name = "Bedding",                               LookupValue = "20444",  Description = "Bedding.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 243, MarketplaceTypeId = 1, Name = "Bed Sheets",                            LookupValue = "20460",  Description = "Bed sheets.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 244, MarketplaceTypeId = 1, Name = "Quilts, Bedspreads & Coverlets",        LookupValue = "175749", Description = "Quilts and coverlets.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 245, MarketplaceTypeId = 1, Name = "Duvet Covers & Bedding Sets",           LookupValue = "37644",  Description = "Duvet covers and sets.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 246, MarketplaceTypeId = 1, Name = "Blankets & Throws",                     LookupValue = "175750", Description = "Blankets and throws.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 247, MarketplaceTypeId = 1, Name = "Comforters & Sets",                     LookupValue = "262977", Description = "Comforters and sets.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 248, MarketplaceTypeId = 1, Name = "Nursery Bedding",                       LookupValue = "20416",  Description = "Nursery bedding.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Household Supplies & Cleaning
                new () { Id = 249, MarketplaceTypeId = 1, Name = "Household Supplies & Cleaning",         LookupValue = "299",    Description = "Household supplies and cleaning.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 250, MarketplaceTypeId = 1, Name = "Vacuum Cleaners",                       LookupValue = "20614",  Description = "Vacuum cleaners.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 251, MarketplaceTypeId = 1, Name = "Home Organization Supplies",            LookupValue = "43502",  Description = "Home organization supplies.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 252, MarketplaceTypeId = 1, Name = "General Household Supplies",            LookupValue = "259345", Description = "General household supplies.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 253, MarketplaceTypeId = 1, Name = "Household Laundry Supplies",            LookupValue = "20620",  Description = "Laundry supplies.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 254, MarketplaceTypeId = 1, Name = "Vacuum Cleaner Parts",                  LookupValue = "42146",  Description = "Vacuum cleaner parts.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 255, MarketplaceTypeId = 1, Name = "Household Cleaning Tools",              LookupValue = "259338", Description = "Cleaning tools.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Lamps, Lighting & Ceiling Fans
                new () { Id = 256, MarketplaceTypeId = 1, Name = "Lamps, Lighting & Ceiling Fans",        LookupValue = "20697",  Description = "Lighting and ceiling fans.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 257, MarketplaceTypeId = 1, Name = "Lamps",                                 LookupValue = "112581", Description = "Lamps.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 258, MarketplaceTypeId = 1, Name = "Chandeliers & Ceiling Fixtures",        LookupValue = "117503", Description = "Chandeliers and ceiling fixtures.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 259, MarketplaceTypeId = 1, Name = "Ceiling Fans",                          LookupValue = "176937", Description = "Ceiling fans.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 260, MarketplaceTypeId = 1, Name = "Light Bulbs",                           LookupValue = "20706",  Description = "Light bulbs.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 261, MarketplaceTypeId = 1, Name = "Wall Lighting Fixtures",                LookupValue = "116880", Description = "Wall lighting fixtures.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Major Appliances
                new () { Id = 262, MarketplaceTypeId = 1, Name = "Major Appliances",                      LookupValue = "20710",  Description = "Major appliances.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 263, MarketplaceTypeId = 1, Name = "Refrigerators, Freezers, Parts & Accessories", LookupValue = "71258", Description = "Refrigerators and freezers.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 264, MarketplaceTypeId = 1, Name = "Ranges & Cooking Appliances",           LookupValue = "43563",  Description = "Ranges and cooking appliances.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 265, MarketplaceTypeId = 1, Name = "Washers, Dryers, Parts & Accessories",  LookupValue = "42231",  Description = "Washers, dryers, and parts.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 266, MarketplaceTypeId = 1, Name = "Dishwashers",                           LookupValue = "116023", Description = "Dishwashers.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 267, MarketplaceTypeId = 1, Name = "Other Major Home Appliances",           LookupValue = "20715",  Description = "Other major appliances.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Bath
                new () { Id = 268, MarketplaceTypeId = 1, Name = "Bath",                                  LookupValue = "26677",  Description = "Bathroom fixtures and supplies.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 269, MarketplaceTypeId = 1, Name = "Bathroom Supplies & Accessories",       LookupValue = "260590", Description = "Bathroom supplies and accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 270, MarketplaceTypeId = 1, Name = "Showers, Bathtubs & Parts",             LookupValue = "260565", Description = "Showers, bathtubs, and parts.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 271, MarketplaceTypeId = 1, Name = "Shower & Bathtub Accessories",          LookupValue = "260560", Description = "Shower and bathtub accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 272, MarketplaceTypeId = 1, Name = "Bathroom Sinks & Vanities",             LookupValue = "260556", Description = "Sinks and vanities.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 273, MarketplaceTypeId = 1, Name = "Toilets & Bidets",                      LookupValue = "260575", Description = "Toilets and bidets.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 274, MarketplaceTypeId = 1, Name = "Medicine Cabinets",                     LookupValue = "176991", Description = "Medicine cabinets.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Rugs & Carpets
                new () { Id = 275, MarketplaceTypeId = 1, Name = "Rugs & Carpets",                        LookupValue = "20571",  Description = "Rugs and carpets.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 276, MarketplaceTypeId = 1, Name = "Area Rugs",                             LookupValue = "262983", Description = "Area rugs.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 277, MarketplaceTypeId = 1, Name = "Door Mats & Floor Mats",                LookupValue = "20573",  Description = "Door and floor mats.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 278, MarketplaceTypeId = 1, Name = "Leather, Fur & Sheepskin Rugs",         LookupValue = "91421",  Description = "Leather, fur, sheepskin rugs.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 279, MarketplaceTypeId = 1, Name = "Runner Rugs",                           LookupValue = "20574",  Description = "Runner rugs.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 280, MarketplaceTypeId = 1, Name = "Carpet Tiles",                          LookupValue = "136820", Description = "Carpet tiles.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 281, MarketplaceTypeId = 1, Name = "Stair Treads",                          LookupValue = "175517", Description = "Stair treads.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Food & Beverages
                new () { Id = 282, MarketplaceTypeId = 1, Name = "Food & Beverages",                      LookupValue = "14308",  Description = "Food and beverages.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 283, MarketplaceTypeId = 1, Name = "Pantry",                                LookupValue = "257942", Description = "Pantry.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 284, MarketplaceTypeId = 1, Name = "Coffee, Tea & Soft Drinks",             LookupValue = "185035", Description = "Coffee, tea, and soft drinks.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 285, MarketplaceTypeId = 1, Name = "Beer, Wine & Spirits",                  LookupValue = "179836", Description = "Beer, wine, and spirits.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 286, MarketplaceTypeId = 1, Name = "Cheese",                                LookupValue = "62706",  Description = "Cheese.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 287, MarketplaceTypeId = 1, Name = "Other Food & Beverages",                LookupValue = "79631",  Description = "Other food & beverages.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 288, MarketplaceTypeId = 1, Name = "Hampers & Gift Assortments",            LookupValue = "258026", Description = "Hampers and gift assortments.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Candles & Home Fragrance
                new () { Id = 289, MarketplaceTypeId = 1, Name = "Candles & Home Fragrance",              LookupValue = "262975", Description = "Candles and home fragrance.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 290, MarketplaceTypeId = 1, Name = "Home Fragrance",                        LookupValue = "20552",  Description = "Home fragrance.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 291, MarketplaceTypeId = 1, Name = "Candles",                               LookupValue = "46782",  Description = "Candles.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 292, MarketplaceTypeId = 1, Name = "Candle Holders & Accessories",          LookupValue = "16102",  Description = "Candle holders and accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Window Treatments & Hardware
                new () { Id = 293, MarketplaceTypeId = 1, Name = "Window Treatments & Hardware",          LookupValue = "63514",  Description = "Window treatments and hardware.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 294, MarketplaceTypeId = 1, Name = "Window Curtains & Drapes",              LookupValue = "45515",  Description = "Curtains and drapes.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 295, MarketplaceTypeId = 1, Name = "Window Blinds & Shades",                LookupValue = "20585",  Description = "Blinds and shades.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 296, MarketplaceTypeId = 1, Name = "Curtain Rods & Hardware",               LookupValue = "103459", Description = "Curtain rods and hardware.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 297, MarketplaceTypeId = 1, Name = "Window Film",                           LookupValue = "175757", Description = "Window film.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 298, MarketplaceTypeId = 1, Name = "Window Shutters",                       LookupValue = "66799",  Description = "Window shutters.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 299, MarketplaceTypeId = 1, Name = "Window Cornices & Valances",            LookupValue = "260060", Description = "Cornices and valances.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Holiday & Seasonal Décor
                new () { Id = 300, MarketplaceTypeId = 1, Name = "Holiday & Seasonal Décor",              LookupValue = "170090", Description = "Holiday & seasonal décor.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 301, MarketplaceTypeId = 1, Name = "Christmas Trees",                       LookupValue = "117414", Description = "Christmas trees.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 302, MarketplaceTypeId = 1, Name = "Seasonal Ornaments",                    LookupValue = "166725", Description = "Seasonal ornaments.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 303, MarketplaceTypeId = 1, Name = "String Lights",                         LookupValue = "38229",  Description = "String lights.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 304, MarketplaceTypeId = 1, Name = "Seasonal Figurines",                    LookupValue = "117413", Description = "Seasonal figurines.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 305, MarketplaceTypeId = 1, Name = "Seasonal Yard Décor",                   LookupValue = "156812", Description = "Seasonal yard décor.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 306, MarketplaceTypeId = 1, Name = "Advent Calendars",                      LookupValue = "156813", Description = "Advent calendars.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Pillows
                new () { Id = 307, MarketplaceTypeId = 1, Name = "Pillows",                               LookupValue = "20563",  Description = "Home décor pillows.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Greeting Cards & Party Supply
                new () { Id = 308, MarketplaceTypeId = 1, Name = "Greeting Cards & Party Supply",         LookupValue = "16086",  Description = "Greeting cards and party supplies.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 309, MarketplaceTypeId = 1, Name = "Party Supplies",                        LookupValue = "3205",   Description = "Party supplies.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 310, MarketplaceTypeId = 1, Name = "Greeting Cards & Invitations",          LookupValue = "170098", Description = "Greeting cards and invitations.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 311, MarketplaceTypeId = 1, Name = "Gift Wrapping Supplies",                LookupValue = "102378", Description = "Gift wrapping supplies.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 312, MarketplaceTypeId = 1, Name = "Gift Baskets",                          LookupValue = "16091",  Description = "Gift baskets.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 313, MarketplaceTypeId = 1, Name = "Personal Stationery & Note Pads",       LookupValue = "177761", Description = "Stationery and note pads.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 314, MarketplaceTypeId = 1, Name = "Other Gift & Party Supplies",           LookupValue = "170115", Description = "Other gift and party supplies.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Kitchen Fixtures
                new () { Id = 315, MarketplaceTypeId = 1, Name = "Kitchen Fixtures",                      LookupValue = "177073", Description = "Kitchen fixtures.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 316, MarketplaceTypeId = 1, Name = "Kitchen Faucets",                       LookupValue = "29508",  Description = "Kitchen faucets.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 317, MarketplaceTypeId = 1, Name = "Kitchen Cabinets",                      LookupValue = "85879",  Description = "Kitchen cabinets.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 318, MarketplaceTypeId = 1, Name = "Kitchen Sinks",                         LookupValue = "260611", Description = "Kitchen sinks.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 319, MarketplaceTypeId = 1, Name = "Kitchen Cabinet Doors & Drawer Fronts", LookupValue = "259154", Description = "Cabinet doors and drawer fronts.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 320, MarketplaceTypeId = 1, Name = "Kitchen Sink Parts",                    LookupValue = "260624", Description = "Kitchen sink parts.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 321, MarketplaceTypeId = 1, Name = "Kitchen Countertops",                   LookupValue = "259157", Description = "Kitchen countertops.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Popular Topics (unique numeric codes only)
                new () { Id = 322, MarketplaceTypeId = 1, Name = "Stanley Vacuum Flasks & Mugs",          LookupValue = "177006", Description = "Stanley flasks and mugs.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 323, MarketplaceTypeId = 1, Name = "Riding Lawn Mower Lawn Mowers",         LookupValue = "260921", Description = "Riding lawn mowers.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 324, MarketplaceTypeId = 1, Name = "Flowering Plants & Seedlings",          LookupValue = "19617",  Description = "Flowering plants and seedlings.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

// Top category
                new () { Id = 325, MarketplaceTypeId = 1, Name = "Clothing, Shoes & Accessories",            LookupValue = "11450",  Description = "CSA root.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Women
                new () { Id = 326, MarketplaceTypeId = 1, Name = "Women",                                    LookupValue = "260010", Description = "Women's clothing, shoes & accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 327, MarketplaceTypeId = 1, Name = "Women's Clothing",                         LookupValue = "15724",  Description = "Women's clothing.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 328, MarketplaceTypeId = 1, Name = "Women's Bags & Handbags",                  LookupValue = "169291", Description = "Women's bags and handbags.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 329, MarketplaceTypeId = 1, Name = "Women's Shoes",                            LookupValue = "3034",   Description = "Women's shoes.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 330, MarketplaceTypeId = 1, Name = "Women's Accessories",                      LookupValue = "4251",   Description = "Women's accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Men
                new () { Id = 331, MarketplaceTypeId = 1, Name = "Men",                                       LookupValue = "260012", Description = "Men's clothing, shoes & accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 332, MarketplaceTypeId = 1, Name = "Men's Clothing",                            LookupValue = "1059",   Description = "Men's clothing.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 333, MarketplaceTypeId = 1, Name = "Men's Shoes",                               LookupValue = "93427",  Description = "Men's shoes.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 334, MarketplaceTypeId = 1, Name = "Men's Accessories",                         LookupValue = "4250",   Description = "Men's accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 335, MarketplaceTypeId = 1, Name = "Men's Jewelry",                             LookupValue = "10290",  Description = "Men's jewelry.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Kids
                new () { Id = 336, MarketplaceTypeId = 1, Name = "Kids",                                      LookupValue = "171146", Description = "Kids’ clothing, shoes & accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 337, MarketplaceTypeId = 1, Name = "Boy's Clothing, Shoes & Accessories",       LookupValue = "260013", Description = "Boys’ clothing, shoes & accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 338, MarketplaceTypeId = 1, Name = "Girls' Clothing, Shoes & Accessories",      LookupValue = "260015", Description = "Girls’ clothing, shoes & accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 339, MarketplaceTypeId = 1, Name = "Unisex Kids",                               LookupValue = "260017", Description = "Unisex kids.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 340, MarketplaceTypeId = 1, Name = "Kids' Backpacks & Bags",                    LookupValue = "260988", Description = "Kids’ backpacks and bags.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Baby
                new () { Id = 341, MarketplaceTypeId = 1, Name = "Baby",                                      LookupValue = "260018", Description = "Baby clothing, shoes & accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 342, MarketplaceTypeId = 1, Name = "Baby & Toddler Clothing",                   LookupValue = "260019", Description = "Baby & toddler clothing.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 343, MarketplaceTypeId = 1, Name = "Baby Shoes",                                LookupValue = "147285", Description = "Baby shoes.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 344, MarketplaceTypeId = 1, Name = "Baby Accessories",                          LookupValue = "163222", Description = "Baby accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Specialty
                new () { Id = 345, MarketplaceTypeId = 1, Name = "Specialty",                                 LookupValue = "260033", Description = "Specialty apparel categories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 346, MarketplaceTypeId = 1, Name = "Sports Fan Apparel & Souvenirs",            LookupValue = "24409",  Description = "Sports fan apparel & souvenirs.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 347, MarketplaceTypeId = 1, Name = "Vintage Clothing, Shoes & Accessories",     LookupValue = "175759", Description = "Vintage apparel & accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 348, MarketplaceTypeId = 1, Name = "Costume, Reenactment & Theater Apparel",    LookupValue = "163147", Description = "Costumes and reenactment apparel.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 349, MarketplaceTypeId = 1, Name = "Wedding & Formal Wear",                     LookupValue = "3259",   Description = "Wedding and formal wear.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 350, MarketplaceTypeId = 1, Name = "Uniforms & Work Clothing",                  LookupValue = "28015",  Description = "Uniforms and work clothing.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 351, MarketplaceTypeId = 1, Name = "World & Traditional Clothing",              LookupValue = "155240", Description = "World & traditional clothing.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Luggage
                new () { Id = 352, MarketplaceTypeId = 1, Name = "Luggage",                                   LookupValue = "16080",  Description = "Travel luggage.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Popular Topics (unique numeric codes only)
                new () { Id = 353, MarketplaceTypeId = 1, Name = "T-Shirts for Men",                          LookupValue = "15687",  Description = "Men’s T-shirts.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 354, MarketplaceTypeId = 1, Name = "Wedding Dresses",                           LookupValue = "63861",  Description = "Wedding dresses.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 355, MarketplaceTypeId = 1, Name = "Men's Polyester Hats",                      LookupValue = "52365",  Description = "Polyester hats for men.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 356, MarketplaceTypeId = 1, Name = "Toys & Hobbies",                         LookupValue = "220",     Description = "Toys & Hobbies root.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Collectible Card Games
                new () { Id = 357, MarketplaceTypeId = 1, Name = "Collectible Card Games",                 LookupValue = "2536",    Description = "CCGs & accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 358, MarketplaceTypeId = 1, Name = "Collectible Card Game Singles",          LookupValue = "183454",  Description = "Individual CCG cards.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 359, MarketplaceTypeId = 1, Name = "Sealed Collectible Card Game Boxes",     LookupValue = "261044",  Description = "Sealed CCG boxes.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 360, MarketplaceTypeId = 1, Name = "Sealed Collectible Card Game Packs",     LookupValue = "183456",  Description = "Sealed CCG packs.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 361, MarketplaceTypeId = 1, Name = "Sealed Collectible Card Game Decks & Kits", LookupValue = "183457", Description = "Sealed CCG decks & kits.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 362, MarketplaceTypeId = 1, Name = "Sealed Collectible Card Game Cases",     LookupValue = "261045",  Description = "Sealed CCG cases.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 363, MarketplaceTypeId = 1, Name = "Collectible Card Game Sets",             LookupValue = "183459",  Description = "CCG sets.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Action Figures & Accessories
                new () { Id = 364, MarketplaceTypeId = 1, Name = "Action Figures & Accessories",           LookupValue = "246",     Description = "Action figures & related.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 365, MarketplaceTypeId = 1, Name = "Action Figures",                         LookupValue = "261068",  Description = "Action figures.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 366, MarketplaceTypeId = 1, Name = "Action Figures Mixed Lots",              LookupValue = "49018",   Description = "Action figure lots.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 367, MarketplaceTypeId = 1, Name = "Action Figures Playsets",                LookupValue = "261069",  Description = "Action figure playsets.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 368, MarketplaceTypeId = 1, Name = "Action Figures Accessories",             LookupValue = "261070",  Description = "Accessories for action figures.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 369, MarketplaceTypeId = 1, Name = "Action Figures Parts",                   LookupValue = "261071",  Description = "Parts for action figures.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 370, MarketplaceTypeId = 1, Name = "Action Figures Supplies & Storage",      LookupValue = "261943",  Description = "Supplies & storage.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Video Games
                new () { Id = 371, MarketplaceTypeId = 1, Name = "Video Games",                            LookupValue = "139973",  Description = "Video games marketplace.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Building Toys
                new () { Id = 372, MarketplaceTypeId = 1, Name = "Building Toys",                          LookupValue = "183446",  Description = "Building toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 373, MarketplaceTypeId = 1, Name = "LEGO (R) Building Toys",                 LookupValue = "183447",  Description = "LEGO brand building toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 374, MarketplaceTypeId = 1, Name = "Building Toys & Blocks",                 LookupValue = "263016",  Description = "Blocks & building toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Diecast & Toy Vehicles
                new () { Id = 375, MarketplaceTypeId = 1, Name = "Diecast & Toy Vehicles",                 LookupValue = "222",     Description = "Diecast & toy vehicles.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 376, MarketplaceTypeId = 1, Name = "Diecast Cars, Trucks & Vans",            LookupValue = "180273",  Description = "Diecast cars, trucks & vans.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 377, MarketplaceTypeId = 1, Name = "Diecast Racing Cars",                    LookupValue = "171127",  Description = "Diecast racing cars.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 378, MarketplaceTypeId = 1, Name = "Diecast Farm Vehicles",                  LookupValue = "180275",  Description = "Diecast farm vehicles.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 379, MarketplaceTypeId = 1, Name = "Diecast Aircraft & Spacecraft",          LookupValue = "180268",  Description = "Diecast aircraft & spacecraft.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 380, MarketplaceTypeId = 1, Name = "Diecast Construction Equipment",         LookupValue = "180274",  Description = "Diecast construction equipment.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 381, MarketplaceTypeId = 1, Name = "Diecast Tanks & Military Vehicles",      LookupValue = "171138",  Description = "Diecast military vehicles.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Model Railroads & Trains
                new () { Id = 382, MarketplaceTypeId = 1, Name = "Model Railroads & Trains (Parent)",      LookupValue = "180250",  Description = "Model trains parent.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 383, MarketplaceTypeId = 1, Name = "Model Railroads & Trains",               LookupValue = "262301",  Description = "Model RR items.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 384, MarketplaceTypeId = 1, Name = "Model Railroad & Train Power & Controls", LookupValue = "180339",  Description = "Power, control, DCC.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 385, MarketplaceTypeId = 1, Name = "Model Railroads & Trains Mixed Lots",    LookupValue = "165991",  Description = "Mixed lots.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 386, MarketplaceTypeId = 1, Name = "Model Railroad & Train Storage & Display", LookupValue = "114299", Description = "Storage & display.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 387, MarketplaceTypeId = 1, Name = "Model Railroad & Train Books & Guides",  LookupValue = "9047",    Description = "Books & guides.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Games
                new () { Id = 388, MarketplaceTypeId = 1, Name = "Games",                                  LookupValue = "233",     Description = "Games parent.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 389, MarketplaceTypeId = 1, Name = "Miniatures & War Games",                 LookupValue = "16486",   Description = "Tabletop minis & war games.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 390, MarketplaceTypeId = 1, Name = "Board & Traditional Games",              LookupValue = "2550",    Description = "Board & classic games.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 391, MarketplaceTypeId = 1, Name = "Chess",                                  LookupValue = "40852",   Description = "Chess sets & accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 392, MarketplaceTypeId = 1, Name = "Electronic Games",                       LookupValue = "2540",    Description = "Electronic handheld/table games.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 393, MarketplaceTypeId = 1, Name = "Role Playing Games",                     LookupValue = "2543",    Description = "RPGs.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 394, MarketplaceTypeId = 1, Name = "Card Games & Poker",                     LookupValue = "180350",  Description = "Card games & poker.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Radio Control & Control Line
                new () { Id = 395, MarketplaceTypeId = 1, Name = "Radio Control & Control Line",           LookupValue = "2562",    Description = "RC & control line.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 396, MarketplaceTypeId = 1, Name = "Hobby RC Model Vehicles & Kits",         LookupValue = "182181",  Description = "RC vehicles & kits.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 397, MarketplaceTypeId = 1, Name = "Hobby RC Model Vehicle Parts & Accessories", LookupValue = "182187", Description = "RC parts & accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 398, MarketplaceTypeId = 1, Name = "Control Line Tether Car Models & Kits",  LookupValue = "168247",  Description = "Tether car kits.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 399, MarketplaceTypeId = 1, Name = "Control Line & Freeflight Models & Kits", LookupValue = "34054",   Description = "Control line/freeflight kits.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 400, MarketplaceTypeId = 1, Name = "Remote-Controlled Toys",                 LookupValue = "84912",   Description = "RC toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 401, MarketplaceTypeId = 1, Name = "Hobby RC Simulators",                    LookupValue = "171145",  Description = "RC simulators.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Models & Kits
                new () { Id = 402, MarketplaceTypeId = 1, Name = "Models & Kits",                           LookupValue = "1188",    Description = "Model kits.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 403, MarketplaceTypeId = 1, Name = "Automotive Models & Kits",                LookupValue = "262320",  Description = "Automotive model kits.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 404, MarketplaceTypeId = 1, Name = "Aircraft Models & Kits",                  LookupValue = "262319",  Description = "Aircraft model kits.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 405, MarketplaceTypeId = 1, Name = "Boat & Ship Models & Kits",               LookupValue = "262321",  Description = "Boat/ship model kits.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 406, MarketplaceTypeId = 1, Name = "Figure Models & Kits",                    LookupValue = "262324",  Description = "Figure model kits.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 407, MarketplaceTypeId = 1, Name = "Spacecraft Models & Kits",                LookupValue = "262325",  Description = "Spacecraft model kits.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 408, MarketplaceTypeId = 1, Name = "Model & Kit Tools, Supplies & Engines",   LookupValue = "262327",  Description = "Tools, supplies & engines.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Slot Cars
                new () { Id = 409, MarketplaceTypeId = 1, Name = "Slot Cars",                               LookupValue = "2616",    Description = "Slot cars & accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 410, MarketplaceTypeId = 1, Name = "HO Scale Slot Cars",                      LookupValue = "164787",  Description = "HO slot cars.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 411, MarketplaceTypeId = 1, Name = "1/32 Scale Slot Cars",                    LookupValue = "164791",  Description = "1/32 slot cars.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 412, MarketplaceTypeId = 1, Name = "1/24 Scale Slot Cars",                    LookupValue = "164789",  Description = "1/24 slot cars.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 413, MarketplaceTypeId = 1, Name = "1/43 Scale Slot Cars",                    LookupValue = "164793",  Description = "1/43 slot cars.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 414, MarketplaceTypeId = 1, Name = "Slot Car Accessories",                    LookupValue = "164785",  Description = "Slot car accessories.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 415, MarketplaceTypeId = 1, Name = "Other Slot Cars",                         LookupValue = "776",     Description = "Other slot cars.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Preschool Toys & Pretend Play
                new () { Id = 416, MarketplaceTypeId = 1, Name = "Preschool Toys & Pretend Play",           LookupValue = "19169",   Description = "Preschool toys & pretend play.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 417, MarketplaceTypeId = 1, Name = "Fisher-Price Preschool Toys",             LookupValue = "2524",    Description = "Fisher-Price preschool.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 418, MarketplaceTypeId = 1, Name = "Littlest Pet Shop Toys",                  LookupValue = "150925",  Description = "LPS toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 419, MarketplaceTypeId = 1, Name = "Playmobil Preschool Toys",                LookupValue = "19854",   Description = "Playmobil preschool.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 420, MarketplaceTypeId = 1, Name = "Puppets",                                 LookupValue = "19180",   Description = "Puppets.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 421, MarketplaceTypeId = 1, Name = "Playskool Preschool Toys",                LookupValue = "2576",    Description = "Playskool preschool.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 422, MarketplaceTypeId = 1, Name = "Wooden & Handcrafted Pretend Play Toys",  LookupValue = "1197",    Description = "Wooden/handcrafted pretend play.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Vintage & Antique Toys
                new () { Id = 423, MarketplaceTypeId = 1, Name = "Vintage & Antique Toys",                  LookupValue = "717",     Description = "Vintage & antique toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 424, MarketplaceTypeId = 1, Name = "Other Vintage & Antique Toys",            LookupValue = "30",      Description = "Other vintage/antique toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 425, MarketplaceTypeId = 1, Name = "Vintage & Antique Cast Iron Toys",        LookupValue = "721",     Description = "Cast iron toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 426, MarketplaceTypeId = 1, Name = "Vintage & Antique Play Sets",             LookupValue = "727",     Description = "Vintage play sets.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 427, MarketplaceTypeId = 1, Name = "Vintage & Antique Tin Toys",              LookupValue = "735",     Description = "Tin toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 428, MarketplaceTypeId = 1, Name = "Vintage & Antique Cap Guns",              LookupValue = "2660",    Description = "Cap guns.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 429, MarketplaceTypeId = 1, Name = "Vintage & Antique Cowboy & Western Toys", LookupValue = "19252",   Description = "Cowboy & Western toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Stuffed Animals
                new () { Id = 430, MarketplaceTypeId = 1, Name = "Stuffed Animals",                         LookupValue = "436",     Description = "Plush / stuffed animals.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 431, MarketplaceTypeId = 1, Name = "Jellycat Stuffed Animals",                LookupValue = "158786",  Description = "Jellycat plush.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 432, MarketplaceTypeId = 1, Name = "Other Stuffed Animals",                   LookupValue = "230",     Description = "Other plush.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 433, MarketplaceTypeId = 1, Name = "Webkinz & Lil'Kinz Stuffed Animals",      LookupValue = "158769",  Description = "Webkinz/Lil'Kinz plush.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 434, MarketplaceTypeId = 1, Name = "Vintage Stuffed Animals",                 LookupValue = "165956",  Description = "Vintage plush.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 435, MarketplaceTypeId = 1, Name = "Neopets Stuffed Animals",                 LookupValue = "74985",   Description = "Neopets plush.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 436, MarketplaceTypeId = 1, Name = "Gund Stuffed Animals",                    LookupValue = "2598",    Description = "Gund plush.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Outdoor Toys & Structures
                new () { Id = 437, MarketplaceTypeId = 1, Name = "Outdoor Toys & Structures",               LookupValue = "11743",   Description = "Outdoor toys & structures.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 438, MarketplaceTypeId = 1, Name = "Dart Guns & Soft Darts",                  LookupValue = "158749",  Description = "Dart guns & darts.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 439, MarketplaceTypeId = 1, Name = "Pedal Cars",                              LookupValue = "19021",   Description = "Pedal cars.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 440, MarketplaceTypeId = 1, Name = "Inflatable Bouncers",                     LookupValue = "145979",  Description = "Inflatable bouncers.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 441, MarketplaceTypeId = 1, Name = "Sand & Water Toys",                       LookupValue = "145986",  Description = "Sand & water toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 442, MarketplaceTypeId = 1, Name = "Tricycles & Ride On Toys",                LookupValue = "19023",   Description = "Trikes & ride-ons.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 443, MarketplaceTypeId = 1, Name = "Toy Kites",                               LookupValue = "2569",    Description = "Kites.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Beanbag Plush
                new () { Id = 444, MarketplaceTypeId = 1, Name = "Beanbag Plush",                           LookupValue = "49019",   Description = "Beanbag plushies.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 445, MarketplaceTypeId = 1, Name = "Ty Beanbag Plushies",                     LookupValue = "19203",   Description = "Ty beanbag plush.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 446, MarketplaceTypeId = 1, Name = "Meanies Beanbag Plushies",                LookupValue = "1621",    Description = "Meanies beanbag plush.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 447, MarketplaceTypeId = 1, Name = "Grateful Dead Beanbag Plushies",          LookupValue = "1620",    Description = "Grateful Dead beanbag plush.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 448, MarketplaceTypeId = 1, Name = "Bammers & Bamm Beanos",                   LookupValue = "1522",    Description = "Bammers/Bamm Beanos.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 449, MarketplaceTypeId = 1, Name = "Disney Beanbag Plushies",                 LookupValue = "439",     Description = "Disney beanbag plush.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 450, MarketplaceTypeId = 1, Name = "Other Beanbag Plushies",                  LookupValue = "49020",   Description = "Other beanbag plush.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Robots, Monsters & Space Toys
                new () { Id = 451, MarketplaceTypeId = 1, Name = "Robots, Monsters & Space Toys",           LookupValue = "19192",   Description = "Robots/monsters/space toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 452, MarketplaceTypeId = 1, Name = "Monster Toys",                            LookupValue = "19193",   Description = "Monster toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 453, MarketplaceTypeId = 1, Name = "Robot Toys",                              LookupValue = "19197",   Description = "Robot toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 454, MarketplaceTypeId = 1, Name = "Space Toys",                              LookupValue = "19200",   Description = "Space toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Puzzles
                new () { Id = 455, MarketplaceTypeId = 1, Name = "Puzzles",                                 LookupValue = "2613",    Description = "Puzzles.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 456, MarketplaceTypeId = 1, Name = "Contemporary Puzzles",                    LookupValue = "19182",   Description = "Modern puzzles.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 457, MarketplaceTypeId = 1, Name = "Vintage Puzzles",                         LookupValue = "19188",   Description = "Vintage puzzles.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Electronic, Battery & Wind-Up
                new () { Id = 458, MarketplaceTypeId = 1, Name = "Electronic, Battery & Wind-Up",           LookupValue = "19071",   Description = "Electronic/battery/wind-up toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 459, MarketplaceTypeId = 1, Name = "Electronic & Interactive Toys",           LookupValue = "1082",    Description = "Electronic & interactive.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 460, MarketplaceTypeId = 1, Name = "Battery Operated Toys",                   LookupValue = "19072",   Description = "Battery operated toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 461, MarketplaceTypeId = 1, Name = "Wind-Up & Walking Toys",                  LookupValue = "19075",   Description = "Wind-up & walking.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 462, MarketplaceTypeId = 1, Name = "Friction Toys",                           LookupValue = "19073",   Description = "Friction toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Toy Soldiers
                new () { Id = 463, MarketplaceTypeId = 1, Name = "Toy Soldiers",                            LookupValue = "2631",    Description = "Toy soldiers.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 464, MarketplaceTypeId = 1, Name = "Toy Soldiers (1970-Now)",                 LookupValue = "2638",    Description = "Modern toy soldiers.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 465, MarketplaceTypeId = 1, Name = "Toy Soldiers (Pre-1970)",                 LookupValue = "734",     Description = "Pre-1970 toy soldiers.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Fast Food & Cereal Premiums
                new () { Id = 466, MarketplaceTypeId = 1, Name = "Fast Food & Cereal Premiums",             LookupValue = "19077",   Description = "Fast food/cereal toys.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 467, MarketplaceTypeId = 1, Name = "Fast Food Premiums",                      LookupValue = "767",     Description = "Restaurant premiums.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 468, MarketplaceTypeId = 1, Name = "Cereal Premiums",                         LookupValue = "19078",   Description = "Cereal premiums.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 469, MarketplaceTypeId = 1, Name = "Other Fast Food & Cereal Toys",           LookupValue = "1196",    Description = "Other premiums.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

        // Popular Topics (unique numeric codes only)
                new () { Id = 470, MarketplaceTypeId = 1, Name = "LEGO Complete Sets & Packs",              LookupValue = "19006",   Description = "LEGO complete sets & packs.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1000, MarketplaceTypeId = 1, Name = "Sporting Goods", LookupValue = "888", Description = "The Sporting Goods category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1001, MarketplaceTypeId = 1, Name = "Sports Mem, Cards & Fan Shop", LookupValue = "64482", Description = "The Sports Mem, Cards & Fan Shop category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1002, MarketplaceTypeId = 1, Name = "Sports Trading Cards & Accessories", LookupValue = "212", Description = "The Sports Trading Cards & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1003, MarketplaceTypeId = 1, Name = "Sports Fan Apparel & Souvenirs", LookupValue = "24409", Description = "The Sports Fan Apparel & Souvenirs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1004, MarketplaceTypeId = 1, Name = "Vintage Sports Memorabilia", LookupValue = "50123", Description = "The Vintage Sports Memorabilia category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1005, MarketplaceTypeId = 1, Name = "Original Sport Autographed Items", LookupValue = "51", Description = "The Original Sport Autographed Items category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1006, MarketplaceTypeId = 1, Name = "Game Used Sports Memorabilia", LookupValue = "50116", Description = "The Game Used Sports Memorabilia category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1007, MarketplaceTypeId = 1, Name = "Collectible Sports Stickers, Collections & Albums", LookupValue = "262343", Description = "The Collectible Sports Stickers, Collections & Albums category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1010, MarketplaceTypeId = 1, Name = "Golf", LookupValue = "1513", Description = "The Golf category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1011, MarketplaceTypeId = 1, Name = "Golf Clubs & Equipment", LookupValue = "181153", Description = "The Golf Clubs & Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1012, MarketplaceTypeId = 1, Name = "Golf Clothing, Shoes & Accessories", LookupValue = "181130", Description = "The Golf Clothing, Shoes & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1013, MarketplaceTypeId = 1, Name = "Golf Club Components", LookupValue = "47323", Description = "The Golf Club Components category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1014, MarketplaceTypeId = 1, Name = "Golf Accessories", LookupValue = "181128", Description = "The Golf Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1015, MarketplaceTypeId = 1, Name = "Golf Tech", LookupValue = "260373", Description = "The Golf Tech category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1016, MarketplaceTypeId = 1, Name = "Vintage Golf Equipment", LookupValue = "83041", Description = "The Vintage Golf Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1020, MarketplaceTypeId = 1, Name = "Cycling", LookupValue = "7294", Description = "The Cycling category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1021, MarketplaceTypeId = 1, Name = "Bike Components & Parts", LookupValue = "57262", Description = "The Bike Components & Parts category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1022, MarketplaceTypeId = 1, Name = "Bikes", LookupValue = "177831", Description = "The Bikes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1023, MarketplaceTypeId = 1, Name = "Electric Bikes", LookupValue = "74469", Description = "The Electric Bikes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1024, MarketplaceTypeId = 1, Name = "Bike Frames", LookupValue = "22679", Description = "The Bike Frames category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1025, MarketplaceTypeId = 1, Name = "Bicycle Tires, Tubes & Wheels", LookupValue = "185023", Description = "The Bicycle Tires, Tubes & Wheels category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1026, MarketplaceTypeId = 1, Name = "Vintage Cycling Equipment", LookupValue = "158999", Description = "The Vintage Cycling Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1030, MarketplaceTypeId = 1, Name = "Hunting", LookupValue = "7301", Description = "The Hunting category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1031, MarketplaceTypeId = 1, Name = "Hunting Scopes, Optics & Lasers", LookupValue = "31710", Description = "The Hunting Scopes, Optics & Lasers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1032, MarketplaceTypeId = 1, Name = "Hunting Holsters, Belts & Pouches", LookupValue = "262433", Description = "The Hunting Holsters, Belts & Pouches category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1033, MarketplaceTypeId = 1, Name = "Gun Parts", LookupValue = "73943", Description = "The Gun Parts category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1034, MarketplaceTypeId = 1, Name = "Range & Shooting Equipment", LookupValue = "177904", Description = "The Range & Shooting Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1035, MarketplaceTypeId = 1, Name = "Vintage Hunting Equipment", LookupValue = "71131", Description = "The Vintage Hunting Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1036, MarketplaceTypeId = 1, Name = "Hunting Clothing, Shoes & Accessories", LookupValue = "36239", Description = "The Hunting Clothing, Shoes & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1040, MarketplaceTypeId = 1, Name = "Fishing", LookupValue = "1492", Description = "The Fishing category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1041, MarketplaceTypeId = 1, Name = "Fishing Reels", LookupValue = "261030", Description = "The Fishing Reels category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1042, MarketplaceTypeId = 1, Name = "Fishing Rods & Poles", LookupValue = "261028", Description = "The Fishing Rods & Poles category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1043, MarketplaceTypeId = 1, Name = "Fishing Baits, Lures & Flies", LookupValue = "179961", Description = "The Fishing Baits, Lures & Flies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1044, MarketplaceTypeId = 1, Name = "Vintage Fishing Equipment", LookupValue = "180001", Description = "The Vintage Fishing Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1045, MarketplaceTypeId = 1, Name = "Fishfinders", LookupValue = "29723", Description = "The Fishfinders category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1046, MarketplaceTypeId = 1, Name = "Fishing Equipment", LookupValue = "179985", Description = "The Fishing Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1050, MarketplaceTypeId = 1, Name = "Outdoor Sports", LookupValue = "159043", Description = "The Outdoor Sports category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1051, MarketplaceTypeId = 1, Name = "Archery Equipment", LookupValue = "20835", Description = "The Archery Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1052, MarketplaceTypeId = 1, Name = "Air Guns & Slingshots", LookupValue = "178886", Description = "The Air Guns & Slingshots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1053, MarketplaceTypeId = 1, Name = "Scooters", LookupValue = "11330", Description = "The Scooters category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1054, MarketplaceTypeId = 1, Name = "Skateboarding & Longboarding Equipment", LookupValue = "16262", Description = "The Skateboarding & Longboarding Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1055, MarketplaceTypeId = 1, Name = "Equestrian Equipment", LookupValue = "3153", Description = "The Equestrian Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1056, MarketplaceTypeId = 1, Name = "Airsoft Equipment", LookupValue = "31680", Description = "The Airsoft Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1060, MarketplaceTypeId = 1, Name = "Team Sports", LookupValue = "159049", Description = "The Team Sports category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1061, MarketplaceTypeId = 1, Name = "Baseball & Softball Equipment", LookupValue = "16021", Description = "The Baseball & Softball Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1062, MarketplaceTypeId = 1, Name = "Soccer Equipment", LookupValue = "20862", Description = "The Soccer Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1063, MarketplaceTypeId = 1, Name = "Football Gear", LookupValue = "261242", Description = "The Football Gear category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1064, MarketplaceTypeId = 1, Name = "Bowling Equipment", LookupValue = "20846", Description = "The Bowling Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1065, MarketplaceTypeId = 1, Name = "Field, Ice & Roller Hockey Gear", LookupValue = "261245", Description = "The Field, Ice & Roller Hockey Gear category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1066, MarketplaceTypeId = 1, Name = "Basketball Equipment", LookupValue = "21194", Description = "The Basketball Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1070, MarketplaceTypeId = 1, Name = "Fitness, Running & Yoga", LookupValue = "15273", Description = "The Fitness, Running & Yoga category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1071, MarketplaceTypeId = 1, Name = "Fitness Technology", LookupValue = "44075", Description = "The Fitness Technology category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1072, MarketplaceTypeId = 1, Name = "Cardio Equipment", LookupValue = "28059", Description = "The Cardio Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1073, MarketplaceTypeId = 1, Name = "Strength Training Equipment", LookupValue = "28066", Description = "The Strength Training Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1074, MarketplaceTypeId = 1, Name = "Fitness Equipment & Gear", LookupValue = "28064", Description = "The Fitness Equipment & Gear category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1075, MarketplaceTypeId = 1, Name = "Fitness & Running Shoes", LookupValue = "158916", Description = "The Fitness & Running Shoes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1076, MarketplaceTypeId = 1, Name = "Exercise Clothing & Accessories", LookupValue = "158913", Description = "The Exercise Clothing & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1080, MarketplaceTypeId = 1, Name = "Camping & Hiking", LookupValue = "16034", Description = "The Camping & Hiking category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1081, MarketplaceTypeId = 1, Name = "Camping & Hiking Backpacks & Bags", LookupValue = "181378", Description = "The Camping & Hiking Backpacks & Bags category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1082, MarketplaceTypeId = 1, Name = "Camping Tents & Canopies", LookupValue = "181404", Description = "The Camping Tents & Canopies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1083, MarketplaceTypeId = 1, Name = "Camping Cooking Supplies", LookupValue = "181381", Description = "The Camping Cooking Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1084, MarketplaceTypeId = 1, Name = "Camping & Hiking Knives & Tools", LookupValue = "75232", Description = "The Camping & Hiking Knives & Tools category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1085, MarketplaceTypeId = 1, Name = "Camping & Hiking Lighting", LookupValue = "106983", Description = "The Camping & Hiking Lighting category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1086, MarketplaceTypeId = 1, Name = "Camping & Hiking Hydration & Water Bottles", LookupValue = "181405", Description = "The Camping & Hiking Hydration & Water Bottles category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1090, MarketplaceTypeId = 1, Name = "Winter Sports", LookupValue = "36259", Description = "The Winter Sports category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1091, MarketplaceTypeId = 1, Name = "Winter Sports Clothing", LookupValue = "21233", Description = "The Winter Sports Clothing category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1092, MarketplaceTypeId = 1, Name = "Skiing, Snowboarding & Snowshoeing", LookupValue = "260696", Description = "The Skiing, Snowboarding & Snowshoeing category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1093, MarketplaceTypeId = 1, Name = "Ice Skating Equipment", LookupValue = "21225", Description = "The Ice Skating Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1094, MarketplaceTypeId = 1, Name = "Sledding Equipment", LookupValue = "260717", Description = "The Sledding Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1095, MarketplaceTypeId = 1, Name = "Other Winter Sports", LookupValue = "1303", Description = "The Other Winter Sports category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1096, MarketplaceTypeId = 1, Name = "Winter Sports Tech", LookupValue = "260376", Description = "The Winter Sports Tech category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1100, MarketplaceTypeId = 1, Name = "Water Sports", LookupValue = "159136", Description = "The Water Sports category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1101, MarketplaceTypeId = 1, Name = "Kayaking, Canoeing & Rafting Equipment", LookupValue = "36121", Description = "The Kayaking, Canoeing & Rafting Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1102, MarketplaceTypeId = 1, Name = "Scuba & Snorkeling Equipment", LookupValue = "16052", Description = "The Scuba & Snorkeling Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1103, MarketplaceTypeId = 1, Name = "Wetsuits & Drysuits", LookupValue = "159149", Description = "The Wetsuits & Drysuits category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1104, MarketplaceTypeId = 1, Name = "Swimwear & Safety Equipment", LookupValue = "159137", Description = "The Swimwear & Safety Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1105, MarketplaceTypeId = 1, Name = "Wakeboarding & Waterskiing Equipment", LookupValue = "23806", Description = "The Wakeboarding & Waterskiing Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1106, MarketplaceTypeId = 1, Name = "Kitesurfing Equipment", LookupValue = "114262", Description = "The Kitesurfing Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1110, MarketplaceTypeId = 1, Name = "Boxing, Martial Arts & MMA", LookupValue = "179767", Description = "The Boxing, Martial Arts & MMA category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1111, MarketplaceTypeId = 1, Name = "Boxing Gloves", LookupValue = "30102", Description = "The Boxing Gloves category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1112, MarketplaceTypeId = 1, Name = "Boxing & Martial Arts Apparel & Accessories", LookupValue = "73980", Description = "The Boxing & Martial Arts Apparel & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1113, MarketplaceTypeId = 1, Name = "Boxing & MMA Training Equipment & Supplies", LookupValue = "179784", Description = "The Boxing & MMA Training Equipment & Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1114, MarketplaceTypeId = 1, Name = "Boxing & MMA Protective Gear", LookupValue = "179775", Description = "The Boxing & MMA Protective Gear category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1115, MarketplaceTypeId = 1, Name = "Martial Arts Weapons", LookupValue = "179792", Description = "The Martial Arts Weapons category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1116, MarketplaceTypeId = 1, Name = "Martial Arts Gloves", LookupValue = "97042", Description = "The Martial Arts Gloves category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1120, MarketplaceTypeId = 1, Name = "Indoor Games", LookupValue = "36274", Description = "The Indoor Games category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1121, MarketplaceTypeId = 1, Name = "Billiards Equipment", LookupValue = "21567", Description = "The Billiards Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1122, MarketplaceTypeId = 1, Name = "Table Tennis Equipment", LookupValue = "97072", Description = "The Table Tennis Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1123, MarketplaceTypeId = 1, Name = "Dart Equipment", LookupValue = "26328", Description = "The Dart Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1124, MarketplaceTypeId = 1, Name = "Foosball Equipment", LookupValue = "36276", Description = "The Foosball Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1125, MarketplaceTypeId = 1, Name = "Air Hockey Equipment", LookupValue = "36275", Description = "The Air Hockey Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1126, MarketplaceTypeId = 1, Name = "Indoor Roller Skating", LookupValue = "165938", Description = "The Indoor Roller Skating category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1130, MarketplaceTypeId = 1, Name = "Tactical & Duty Gear", LookupValue = "177890", Description = "The Tactical & Duty Gear category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1131, MarketplaceTypeId = 1, Name = "Tactical Bags & Packs", LookupValue = "177899", Description = "The Tactical Bags & Packs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1132, MarketplaceTypeId = 1, Name = "Tactical Chest Rigs & Tactical Vests", LookupValue = "177891", Description = "The Tactical Chest Rigs & Tactical Vests category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1133, MarketplaceTypeId = 1, Name = "Tactical Body Armor & Plates", LookupValue = "102537", Description = "The Tactical Body Armor & Plates category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1134, MarketplaceTypeId = 1, Name = "Tactical & MOLLE Pouches", LookupValue = "177900", Description = "The Tactical & MOLLE Pouches category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1135, MarketplaceTypeId = 1, Name = "Hunting & Tactical Clothing", LookupValue = "177896", Description = "The Hunting & Tactical Clothing category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1136, MarketplaceTypeId = 1, Name = "Tactical Leg Rigs & Belts", LookupValue = "177893", Description = "The Tactical Leg Rigs & Belts category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1140, MarketplaceTypeId = 1, Name = "Tennis & Racquet Sports", LookupValue = "159134", Description = "The Tennis & Racquet Sports category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1141, MarketplaceTypeId = 1, Name = "Tennis Equipment", LookupValue = "13340", Description = "The Tennis Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1142, MarketplaceTypeId = 1, Name = "Other Tennis & Racquet Sports", LookupValue = "159135", Description = "The Other Tennis & Racquet Sports category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1143, MarketplaceTypeId = 1, Name = "Tennis & Racquet Sport Apparel & Accessories", LookupValue = "62229", Description = "The Tennis & Racquet Sport Apparel & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1144, MarketplaceTypeId = 1, Name = "Badminton Equipment", LookupValue = "106460", Description = "The Badminton Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1145, MarketplaceTypeId = 1, Name = "Racquetball Equipment", LookupValue = "62168", Description = "The Racquetball Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1146, MarketplaceTypeId = 1, Name = "Squash Equipment", LookupValue = "62166", Description = "The Squash Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1150, MarketplaceTypeId = 1, Name = "Wholesale Lots", LookupValue = "40146", Description = "The Wholesale Lots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1151, MarketplaceTypeId = 1, Name = "Golf Equipment Wholesale Lots", LookupValue = "40148", Description = "The Golf Equipment Wholesale Lots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1152, MarketplaceTypeId = 1, Name = "Fishing Equipment Wholesale Lots", LookupValue = "40147", Description = "The Fishing Equipment Wholesale Lots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1153, MarketplaceTypeId = 1, Name = "Paintball Equipment Wholesale Lots", LookupValue = "47258", Description = "The Paintball Equipment Wholesale Lots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1154, MarketplaceTypeId = 1, Name = "Other Wholesale Sporting Goods", LookupValue = "26423", Description = "The Other Wholesale Sporting Goods category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1155, MarketplaceTypeId = 1, Name = "Cycling Equipment Wholesale Lots", LookupValue = "107000", Description = "The Cycling Equipment Wholesale Lots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1156, MarketplaceTypeId = 1, Name = "Hunting Equipment Wholesale Lots", LookupValue = "42307", Description = "The Hunting Equipment Wholesale Lots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1160, MarketplaceTypeId = 1, Name = "Other Sporting Goods", LookupValue = "310", Description = "The Other Sporting Goods category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

// Popular Topics (deep links)
                new () { Id = 1165, MarketplaceTypeId = 1, Name = "Baseball Trading Card Singles", LookupValue = "261328", Description = "The Baseball Trading Card Singles category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1166, MarketplaceTypeId = 1, Name = "Football Trading Card Singles", LookupValue = "261328", Description = "The Football Trading Card Singles category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1167, MarketplaceTypeId = 1, Name = "Basketball Trading Card Singles", LookupValue = "261328", Description = "The Basketball Trading Card Singles category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1168, MarketplaceTypeId = 1, Name = "Soccer Trading Card Singles", LookupValue = "261328", Description = "The Soccer Trading Card Singles category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1169, MarketplaceTypeId = 1, Name = "Topps Sports Trading Cards", LookupValue = "212", Description = "The Topps Sports Trading Cards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1170, MarketplaceTypeId = 1, Name = "Bowman Sports Trading Cards", LookupValue = "212", Description = "The Bowman Sports Trading Cards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1171, MarketplaceTypeId = 1, Name = "PSA Grade 10 Baseball Trading Cards", LookupValue = "212", Description = "The PSA Grade 10 Baseball Trading Cards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1172, MarketplaceTypeId = 1, Name = "Jayden Daniels Trading Cards", LookupValue = "212", Description = "The Jayden Daniels Trading Cards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1173, MarketplaceTypeId = 1, Name = "Caitlin Clark Trading Cards", LookupValue = "212", Description = "The Caitlin Clark Trading Cards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1174, MarketplaceTypeId = 1, Name = "Panini Sports Trading Cards", LookupValue = "212", Description = "The Panini Sports Trading Cards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1200, MarketplaceTypeId = 1, Name = "Books, Movies & Music", LookupValue = "bn_7000259849", Description = "The Books, Movies & Music category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1201, MarketplaceTypeId = 1, Name = "Books & Magazines", LookupValue = "267", Description = "The Books & Magazines category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1202, MarketplaceTypeId = 1, Name = "Comic Books, Manga & Memorabilia", LookupValue = "63", Description = "The Comic Books, Manga & Memorabilia category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1203, MarketplaceTypeId = 1, Name = "Books", LookupValue = "261186", Description = "The Books category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1204, MarketplaceTypeId = 1, Name = "Tablets & eReaders", LookupValue = "171485", Description = "The Tablets & eReaders category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1205, MarketplaceTypeId = 1, Name = "Magazines", LookupValue = "280", Description = "The Magazines category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1206, MarketplaceTypeId = 1, Name = "Catalogs", LookupValue = "118254", Description = "The Catalogs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1207, MarketplaceTypeId = 1, Name = "Antiquarian & Collectible Books", LookupValue = "29223", Description = "The Antiquarian & Collectible Books category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1210, MarketplaceTypeId = 1, Name = "Music", LookupValue = "11233", Description = "The Music category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1211, MarketplaceTypeId = 1, Name = "Vinyl Records", LookupValue = "176985", Description = "The Vinyl Records category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1212, MarketplaceTypeId = 1, Name = "Music CDs", LookupValue = "176984", Description = "The Music CDs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1213, MarketplaceTypeId = 1, Name = "Music Cassettes", LookupValue = "176983", Description = "The Music Cassettes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1214, MarketplaceTypeId = 1, Name = "Other Music Formats", LookupValue = "618", Description = "The Other Music Formats category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1215, MarketplaceTypeId = 1, Name = "Audio Media Accessories", LookupValue = "52473", Description = "The Audio Media Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1216, MarketplaceTypeId = 1, Name = "Music NFTs", LookupValue = "262054", Description = "The Music NFTs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1220, MarketplaceTypeId = 1, Name = "Musical Instruments & Gear", LookupValue = "619", Description = "The Musical Instruments & Gear category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1221, MarketplaceTypeId = 1, Name = "Guitars & Basses", LookupValue = "3858", Description = "The Guitars & Basses category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1222, MarketplaceTypeId = 1, Name = "Pro Audio Equipment", LookupValue = "180014", Description = "The Pro Audio Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1223, MarketplaceTypeId = 1, Name = "Brass Instruments", LookupValue = "16212", Description = "The Brass Instruments category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1224, MarketplaceTypeId = 1, Name = "Wind & Woodwind Instruments", LookupValue = "10181", Description = "The Wind & Woodwind Instruments category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1225, MarketplaceTypeId = 1, Name = "Percussion Instruments", LookupValue = "180012", Description = "The Percussion Instruments category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1226, MarketplaceTypeId = 1, Name = "DJ Equipment", LookupValue = "48458", Description = "The DJ Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1230, MarketplaceTypeId = 1, Name = "Movies & TV", LookupValue = "11232", Description = "The Movies & TV category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1231, MarketplaceTypeId = 1, Name = "DVDs & Blu-ray Discs", LookupValue = "617", Description = "The DVDs & Blu-ray Discs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1232, MarketplaceTypeId = 1, Name = "VHS Tapes", LookupValue = "309", Description = "The VHS Tapes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1233, MarketplaceTypeId = 1, Name = "LaserDisc Movies", LookupValue = "381", Description = "The LaserDisc Movies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1234, MarketplaceTypeId = 1, Name = "Other Movie Formats", LookupValue = "41676", Description = "The Other Movie Formats category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1235, MarketplaceTypeId = 1, Name = "Movie Film Stock", LookupValue = "63821", Description = "The Movie Film Stock category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1236, MarketplaceTypeId = 1, Name = "Movie UMDs", LookupValue = "132975", Description = "The Movie UMDs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

// Popular Topics (deep links)
                new () { Id = 1240, MarketplaceTypeId = 1, Name = "US comics, graphic novels & TPBs", LookupValue = "259104", Description = "The US comics, graphic novels & TPBs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1241, MarketplaceTypeId = 1, Name = "DVDs", LookupValue = "617", Description = "The DVDs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1242, MarketplaceTypeId = 1, Name = "Blu-ray Discs", LookupValue = "617", Description = "The Blu-ray Discs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1243, MarketplaceTypeId = 1, Name = "Fiction Books", LookupValue = "261186", Description = "The Fiction Books category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1244, MarketplaceTypeId = 1, Name = "4K UHD Blu-ray Discs", LookupValue = "617", Description = "The 4K UHD Blu-ray Discs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1245, MarketplaceTypeId = 1, Name = "Tablets", LookupValue = "171485", Description = "The Tablets category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1246, MarketplaceTypeId = 1, Name = "Medical Books", LookupValue = "261186", Description = "The Medical Books category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1247, MarketplaceTypeId = 1, Name = "LP Vinyl Records", LookupValue = "176985", Description = "The LP Vinyl Records category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1248, MarketplaceTypeId = 1, Name = "War Comics, Graphic Novels & TPBs", LookupValue = "259104", Description = "The War Comics, Graphic Novels & TPBs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1249, MarketplaceTypeId = 1, Name = "Batman Comics", LookupValue = "259103", Description = "The Batman Comics category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1300, MarketplaceTypeId = 1, Name = "Health & Beauty", LookupValue = "26395", Description = "The Health & Beauty category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1301, MarketplaceTypeId = 1, Name = "Fragrances", LookupValue = "180345", Description = "The Fragrances category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1302, MarketplaceTypeId = 1, Name = "Fragrances for Men", LookupValue = "29585", Description = "The Fragrances for Men category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1303, MarketplaceTypeId = 1, Name = "Fragrances for Women", LookupValue = "11848", Description = "The Fragrances for Women category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1304, MarketplaceTypeId = 1, Name = "Unisex Fragrances", LookupValue = "112661", Description = "The Unisex Fragrances category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1305, MarketplaceTypeId = 1, Name = "Fragrances for Children", LookupValue = "159719", Description = "The Fragrances for Children category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1306, MarketplaceTypeId = 1, Name = "Skin Care", LookupValue = "11863", Description = "The Skin Care category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1307, MarketplaceTypeId = 1, Name = "Anti-Aging Products", LookupValue = "33164", Description = "The Anti-Aging Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1308, MarketplaceTypeId = 1, Name = "Skin Care Moisturizers", LookupValue = "21205", Description = "The Skin Care Moisturizers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1309, MarketplaceTypeId = 1, Name = "Skin Cleansers & Toners", LookupValue = "177765", Description = "The Skin Cleansers & Toners category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1310, MarketplaceTypeId = 1, Name = "Lip Balm & Treatments", LookupValue = "36870", Description = "The Lip Balm & Treatments category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1311, MarketplaceTypeId = 1, Name = "Skin Brightening Creams", LookupValue = "40088", Description = "The Skin Brightening Creams category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1312, MarketplaceTypeId = 1, Name = "Eye Treatments & Masks", LookupValue = "177764", Description = "The Eye Treatments & Masks category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1313, MarketplaceTypeId = 1, Name = "Vitamins & Lifestyle Supplements", LookupValue = "180959", Description = "The Vitamins & Lifestyle Supplements category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1314, MarketplaceTypeId = 1, Name = "Vitamin & Mineral Health Supplements", LookupValue = "11776", Description = "The Vitamin & Mineral Health Supplements category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1315, MarketplaceTypeId = 1, Name = "Dietary Sports Supplements", LookupValue = "97033", Description = "The Dietary Sports Supplements category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1316, MarketplaceTypeId = 1, Name = "Weight Management Supplements", LookupValue = "31817", Description = "The Weight Management Supplements category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1317, MarketplaceTypeId = 1, Name = "Endurance & Energy Bars, Drinks & Pills", LookupValue = "1278", Description = "The Endurance & Energy Bars, Drinks & Pills category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1318, MarketplaceTypeId = 1, Name = "Dietary Supplements", LookupValue = "180960", Description = "The Dietary Supplements category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1319, MarketplaceTypeId = 1, Name = "Other Vitamins & Supplements", LookupValue = "19262", Description = "The Other Vitamins & Supplements category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1320, MarketplaceTypeId = 1, Name = "Hair Care & Styling", LookupValue = "11854", Description = "The Hair Care & Styling category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1321, MarketplaceTypeId = 1, Name = "Hair Extensions & Wigs", LookupValue = "182101", Description = "The Hair Extensions & Wigs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1322, MarketplaceTypeId = 1, Name = "Shampoos & Conditioners", LookupValue = "177661", Description = "The Shampoos & Conditioners category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1323, MarketplaceTypeId = 1, Name = "Hair Styling Devices", LookupValue = "260773", Description = "The Hair Styling Devices category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1324, MarketplaceTypeId = 1, Name = "Hair Loss Treatments", LookupValue = "31413", Description = "The Hair Loss Treatments category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1325, MarketplaceTypeId = 1, Name = "Hair Styling Products", LookupValue = "11860", Description = "The Hair Styling Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1326, MarketplaceTypeId = 1, Name = "Hair Color Products", LookupValue = "31412", Description = "The Hair Color Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1327, MarketplaceTypeId = 1, Name = "Makeup", LookupValue = "31786", Description = "The Makeup category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1328, MarketplaceTypeId = 1, Name = "Face Makeup Products", LookupValue = "172025", Description = "The Face Makeup Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1329, MarketplaceTypeId = 1, Name = "Eye Makeup", LookupValue = "172020", Description = "The Eye Makeup category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1330, MarketplaceTypeId = 1, Name = "Lip Makeup", LookupValue = "172027", Description = "The Lip Makeup category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1331, MarketplaceTypeId = 1, Name = "Makeup Bags & Cases", LookupValue = "36413", Description = "The Makeup Bags & Cases category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1332, MarketplaceTypeId = 1, Name = "Makeup Tools & Accessories", LookupValue = "36409", Description = "The Makeup Tools & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1333, MarketplaceTypeId = 1, Name = "Makeup Mixed Lots", LookupValue = "11985", Description = "The Makeup Mixed Lots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1334, MarketplaceTypeId = 1, Name = "Health Care", LookupValue = "67588", Description = "The Health Care category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1335, MarketplaceTypeId = 1, Name = "Over-The-Counter Medications & Treatments", LookupValue = "75036", Description = "The Over-The-Counter Medications & Treatments category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1336, MarketplaceTypeId = 1, Name = "First Aid Products", LookupValue = "180931", Description = "The First Aid Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1337, MarketplaceTypeId = 1, Name = "Diabetic Care", LookupValue = "72873", Description = "The Diabetic Care category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1338, MarketplaceTypeId = 1, Name = "Foot Creams & Treatments", LookupValue = "36431", Description = "The Foot Creams & Treatments category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1339, MarketplaceTypeId = 1, Name = "Medical Monitoring & Testing Equipment", LookupValue = "30115", Description = "The Medical Monitoring & Testing Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1340, MarketplaceTypeId = 1, Name = "Vision Care", LookupValue = "31414", Description = "The Vision Care category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1341, MarketplaceTypeId = 1, Name = "Eyeglass Frames", LookupValue = "180957", Description = "The Eyeglass Frames category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1342, MarketplaceTypeId = 1, Name = "Reading Glasses", LookupValue = "67670", Description = "The Reading Glasses category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1343, MarketplaceTypeId = 1, Name = "Eyeglass Cases & Storage", LookupValue = "116183", Description = "The Eyeglass Cases & Storage category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1344, MarketplaceTypeId = 1, Name = "Special Purpose Eyeglasses for Vision Care", LookupValue = "31416", Description = "The Special Purpose Eyeglasses for Vision Care category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1345, MarketplaceTypeId = 1, Name = "Eye Drops & Wash", LookupValue = "122773", Description = "The Eye Drops & Wash category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1346, MarketplaceTypeId = 1, Name = "Low Vision Magnifiers", LookupValue = "67678", Description = "The Low Vision Magnifiers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1347, MarketplaceTypeId = 1, Name = "Medical & Mobility", LookupValue = "11778", Description = "The Medical & Mobility category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1348, MarketplaceTypeId = 1, Name = "Mobility/Walking Equipment", LookupValue = "28175", Description = "The Mobility/Walking Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1349, MarketplaceTypeId = 1, Name = "Daily Living Aids", LookupValue = "182118", Description = "The Daily Living Aids category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1350, MarketplaceTypeId = 1, Name = "Orthopedic Products & Supports", LookupValue = "182132", Description = "The Orthopedic Products & Supports category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1351, MarketplaceTypeId = 1, Name = "Mobility Furniture & Fixtures", LookupValue = "182113", Description = "The Mobility Furniture & Fixtures category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1352, MarketplaceTypeId = 1, Name = "Shaving & Hair Removal", LookupValue = "31762", Description = "The Shaving & Hair Removal category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1353, MarketplaceTypeId = 1, Name = "Electric Shaver Parts", LookupValue = "260783", Description = "The Electric Shaver Parts category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1354, MarketplaceTypeId = 1, Name = "Razors & Razor Blades", LookupValue = "179841", Description = "The Razors & Razor Blades category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1355, MarketplaceTypeId = 1, Name = "Shaving Creams, Foams & Gels", LookupValue = "31763", Description = "The Shaving Creams, Foams & Gels category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1356, MarketplaceTypeId = 1, Name = "Tweezers", LookupValue = "67416", Description = "The Tweezers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1357, MarketplaceTypeId = 1, Name = "Shaving Brushes & Mugs", LookupValue = "168191", Description = "The Shaving Brushes & Mugs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1358, MarketplaceTypeId = 1, Name = "Hair Removal Creams & Sprays", LookupValue = "47925", Description = "The Hair Removal Creams & Sprays category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1359, MarketplaceTypeId = 1, Name = "Natural & Alternative Remedies", LookupValue = "67659", Description = "The Natural & Alternative Remedies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1360, MarketplaceTypeId = 1, Name = "Herbal Remedies & Resins", LookupValue = "180954", Description = "The Herbal Remedies & Resins category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1361, MarketplaceTypeId = 1, Name = "Aromatherapy Supplies", LookupValue = "19258", Description = "The Aromatherapy Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1362, MarketplaceTypeId = 1, Name = "Other Natural & Alternative Remedies", LookupValue = "1279", Description = "The Other Natural & Alternative Remedies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1363, MarketplaceTypeId = 1, Name = "Light Therapy", LookupValue = "159881", Description = "The Light Therapy category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1364, MarketplaceTypeId = 1, Name = "Magnetic Therapy Devices", LookupValue = "11777", Description = "The Magnetic Therapy Devices category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1365, MarketplaceTypeId = 1, Name = "Ion Foot Baths", LookupValue = "159879", Description = "The Ion Foot Baths category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1366, MarketplaceTypeId = 1, Name = "Bath & Body", LookupValue = "11838", Description = "The Bath & Body category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1367, MarketplaceTypeId = 1, Name = "Body Bar Soaps", LookupValue = "180924", Description = "The Body Bar Soaps category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1368, MarketplaceTypeId = 1, Name = "Deodorants & Antiperspirants", LookupValue = "29580", Description = "The Deodorants & Antiperspirants category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1369, MarketplaceTypeId = 1, Name = "Body Washes & Shower Gels", LookupValue = "31754", Description = "The Body Washes & Shower Gels category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1370, MarketplaceTypeId = 1, Name = "Body Sprays & Mists", LookupValue = "31753", Description = "The Body Sprays & Mists category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1371, MarketplaceTypeId = 1, Name = "Hand Washes", LookupValue = "180918", Description = "The Hand Washes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1372, MarketplaceTypeId = 1, Name = "Scar & Stretch Mark Reducers", LookupValue = "74994", Description = "The Scar & Stretch Mark Reducers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1373, MarketplaceTypeId = 1, Name = "Massage", LookupValue = "36447", Description = "The Massage category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1374, MarketplaceTypeId = 1, Name = "Body Massagers", LookupValue = "36449", Description = "The Body Massagers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1375, MarketplaceTypeId = 1, Name = "Electric Massage Chairs", LookupValue = "36448", Description = "The Electric Massage Chairs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1376, MarketplaceTypeId = 1, Name = "Massage Tables & Chairs", LookupValue = "36454", Description = "The Massage Tables & Chairs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1377, MarketplaceTypeId = 1, Name = "Massage Oils & Lotions", LookupValue = "36453", Description = "The Massage Oils & Lotions category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1378, MarketplaceTypeId = 1, Name = "Massage Stones & Rocks", LookupValue = "67661", Description = "The Massage Stones & Rocks category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1379, MarketplaceTypeId = 1, Name = "Massage Pillows & Bolsters", LookupValue = "101972", Description = "The Massage Pillows & Bolsters category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1380, MarketplaceTypeId = 1, Name = "Nail Care, Manicure & Pedicure", LookupValue = "47945", Description = "The Nail Care, Manicure & Pedicure category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1381, MarketplaceTypeId = 1, Name = "Nail Polish & Powders", LookupValue = "260758", Description = "The Nail Polish & Powders category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1382, MarketplaceTypeId = 1, Name = "Nail Art Products", LookupValue = "260764", Description = "The Nail Art Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1383, MarketplaceTypeId = 1, Name = "Nail Care Tools", LookupValue = "260772", Description = "The Nail Care Tools category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1384, MarketplaceTypeId = 1, Name = "Nail Polish Remover", LookupValue = "47940", Description = "The Nail Polish Remover category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1385, MarketplaceTypeId = 1, Name = "Nail Care & Treatments", LookupValue = "260762", Description = "The Nail Care & Treatments category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1386, MarketplaceTypeId = 1, Name = "Nail Practice & Display Products", LookupValue = "112563", Description = "The Nail Practice & Display Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1387, MarketplaceTypeId = 1, Name = "Oral Care", LookupValue = "31769", Description = "The Oral Care category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1388, MarketplaceTypeId = 1, Name = "Electric Oral & Dental Care", LookupValue = "260774", Description = "The Electric Oral & Dental Care category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1389, MarketplaceTypeId = 1, Name = "Teeth Whitening Products", LookupValue = "113913", Description = "The Teeth Whitening Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1390, MarketplaceTypeId = 1, Name = "Toothpaste", LookupValue = "67422", Description = "The Toothpaste category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1391, MarketplaceTypeId = 1, Name = "Dental Floss & Flossers", LookupValue = "159758", Description = "The Dental Floss & Flossers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1392, MarketplaceTypeId = 1, Name = "Standard Toothbrushes", LookupValue = "67421", Description = "The Standard Toothbrushes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1393, MarketplaceTypeId = 1, Name = "Mouthwash", LookupValue = "180266", Description = "The Mouthwash category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1394, MarketplaceTypeId = 1, Name = "Sun Protection & Tanning", LookupValue = "31772", Description = "The Sun Protection & Tanning category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1395, MarketplaceTypeId = 1, Name = "Sunscreen Products", LookupValue = "31774", Description = "The Sunscreen Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1396, MarketplaceTypeId = 1, Name = "Self-Tanning Products", LookupValue = "31773", Description = "The Self-Tanning Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1397, MarketplaceTypeId = 1, Name = "Tanning Lotions", LookupValue = "31776", Description = "The Tanning Lotions category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1398, MarketplaceTypeId = 1, Name = "Tanning Beds & Booths", LookupValue = "50101", Description = "The Tanning Beds & Booths category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1399, MarketplaceTypeId = 1, Name = "After Sun Skin Care", LookupValue = "74996", Description = "The After Sun Skin Care category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1400, MarketplaceTypeId = 1, Name = "Tanning Body Stickers", LookupValue = "180919", Description = "The Tanning Body Stickers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1401, MarketplaceTypeId = 1, Name = "Tattoos & Body Art", LookupValue = "33914", Description = "The Tattoos & Body Art category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1402, MarketplaceTypeId = 1, Name = "Tattoo Machines", LookupValue = "33917", Description = "The Tattoo Machines category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1403, MarketplaceTypeId = 1, Name = "Tattoo Supplies", LookupValue = "260797", Description = "The Tattoo Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1404, MarketplaceTypeId = 1, Name = "Tattoo Needles", LookupValue = "179276", Description = "The Tattoo Needles category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1405, MarketplaceTypeId = 1, Name = "Temporary Tattoos", LookupValue = "260799", Description = "The Temporary Tattoos category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1406, MarketplaceTypeId = 1, Name = "Other Tattoos & Body Art", LookupValue = "16705", Description = "The Other Tattoos & Body Art category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1407, MarketplaceTypeId = 1, Name = "Tattoo Complete Kits", LookupValue = "57589", Description = "The Tattoo Complete Kits category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1408, MarketplaceTypeId = 1, Name = "Salon & Spa Equipment", LookupValue = "177731", Description = "The Salon & Spa Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1409, MarketplaceTypeId = 1, Name = "Salon Scissors & Shears", LookupValue = "101915", Description = "The Salon Scissors & Shears category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1410, MarketplaceTypeId = 1, Name = "Salon Styling Capes & Gowns", LookupValue = "96428", Description = "The Salon Styling Capes & Gowns category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1411, MarketplaceTypeId = 1, Name = "Stylist Stations & Furniture", LookupValue = "177738", Description = "The Stylist Stations & Furniture category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1412, MarketplaceTypeId = 1, Name = "Salon & Spa Sterilizers & Towel Warmers", LookupValue = "177739", Description = "The Salon & Spa Sterilizers & Towel Warmers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1413, MarketplaceTypeId = 1, Name = "Backwash Units & Shampoo Bowls", LookupValue = "117338", Description = "The Backwash Units & Shampoo Bowls category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1414, MarketplaceTypeId = 1, Name = "Hair & Makeup Mannequins", LookupValue = "177732", Description = "The Hair & Makeup Mannequins category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1415, MarketplaceTypeId = 1, Name = "Baby Safety & Health", LookupValue = "20433", Description = "The Baby Safety & Health category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1416, MarketplaceTypeId = 1, Name = "Baby Monitors", LookupValue = "20435", Description = "The Baby Monitors category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1417, MarketplaceTypeId = 1, Name = "Baby Safety Gates", LookupValue = "117029", Description = "The Baby Safety Gates category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1418, MarketplaceTypeId = 1, Name = "Baby Bed Rails", LookupValue = "162183", Description = "The Baby Bed Rails category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1419, MarketplaceTypeId = 1, Name = "Toddler Safety Harnesses", LookupValue = "134761", Description = "The Toddler Safety Harnesses category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1420, MarketplaceTypeId = 1, Name = "Baby Shopping Cart Covers", LookupValue = "73470", Description = "The Baby Shopping Cart Covers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1421, MarketplaceTypeId = 1, Name = "Baby Proofing", LookupValue = "184339", Description = "The Baby Proofing category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1422, MarketplaceTypeId = 1, Name = "Other Health & Beauty", LookupValue = "1277", Description = "The Other Health & Beauty category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1423, MarketplaceTypeId = 1, Name = "Wholesale Lots", LookupValue = "40965", Description = "The Health & Beauty Wholesale Lots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1424, MarketplaceTypeId = 1, Name = "Beauty & Personal Care Wholesale Lots", LookupValue = "51005", Description = "The Beauty & Personal Care Wholesale Lots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1425, MarketplaceTypeId = 1, Name = "Wholesale Medical & Special Needs", LookupValue = "40967", Description = "The Wholesale Medical & Special Needs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1426, MarketplaceTypeId = 1, Name = "Other Health & Beauty Wholesale Lots", LookupValue = "31822", Description = "The Other Health & Beauty Wholesale Lots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1427, MarketplaceTypeId = 1, Name = "Health Care Wholesale Lots", LookupValue = "40968", Description = "The Health Care Wholesale Lots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

// Popular Topics (deep links)
                new () { Id = 1428, MarketplaceTypeId = 1, Name = "Sex Dolls & Masturbators", LookupValue = "260751", Description = "The Sex Dolls & Masturbators category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1429, MarketplaceTypeId = 1, Name = "Capsule Vitamins & Minerals", LookupValue = "11776", Description = "The Capsule Vitamins & Minerals category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1430, MarketplaceTypeId = 1, Name = "Dyson Hair Care & Styling Products", LookupValue = "11854", Description = "The Dyson Hair Care & Styling Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1431, MarketplaceTypeId = 1, Name = "Men's Hair Clippers & Trimmers", LookupValue = "67408", Description = "The Men's Hair Clippers & Trimmers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1432, MarketplaceTypeId = 1, Name = "Unisex Vitamins & Minerals", LookupValue = "11776", Description = "The Unisex Vitamins & Minerals category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1433, MarketplaceTypeId = 1, Name = "Women's Perfume", LookupValue = "11848", Description = "The Women's Perfume category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1434, MarketplaceTypeId = 1, Name = "Adult Vitamins & Minerals", LookupValue = "11776", Description = "The Adult Vitamins & Minerals category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1435, MarketplaceTypeId = 1, Name = "Sports Diet & Weight Loss Powders", LookupValue = "21561", Description = "The Sports Diet & Weight Loss Powders category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1436, MarketplaceTypeId = 1, Name = "Dyson Hair Curling & Straightening Irons", LookupValue = "177659", Description = "The Dyson Hair Curling & Straightening Irons category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1437, MarketplaceTypeId = 1, Name = "Bath & Body Works Health & Beauty", LookupValue = "26395", Description = "The Bath & Body Works Health & Beauty category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1438, MarketplaceTypeId = 1, Name = "Business & Industrial", LookupValue = "12576", Description = "The Business & Industrial category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1439, MarketplaceTypeId = 1, Name = "Restaurant & Food Service", LookupValue = "11874", Description = "The Restaurant & Food Service category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1440, MarketplaceTypeId = 1, Name = "Food Trucks, Trailers & Carts", LookupValue = "67145", Description = "The Food Trucks, Trailers & Carts category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1441, MarketplaceTypeId = 1, Name = "Commercial Kitchen Equipment", LookupValue = "25367", Description = "The Commercial Kitchen Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1442, MarketplaceTypeId = 1, Name = "Commercial Bar & Beverage Equipment", LookupValue = "25362", Description = "The Commercial Bar & Beverage Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1443, MarketplaceTypeId = 1, Name = "Commercial Refrigeration Equipment", LookupValue = "25375", Description = "The Commercial Refrigeration Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1444, MarketplaceTypeId = 1, Name = "Vending Machines & Dispensers", LookupValue = "259270", Description = "The Vending Machines & Dispensers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1445, MarketplaceTypeId = 1, Name = "Commercial Tabletop Concession Machines", LookupValue = "46589", Description = "The Commercial Tabletop Concession Machines category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1446, MarketplaceTypeId = 1, Name = "Healthcare, Lab & Dental", LookupValue = "11815", Description = "The Healthcare, Lab & Dental category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1447, MarketplaceTypeId = 1, Name = "Medical & Lab Equipment, Devices", LookupValue = "184520", Description = "The Medical & Lab Equipment, Devices category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1448, MarketplaceTypeId = 1, Name = "Handpieces & Instruments", LookupValue = "185155", Description = "The Handpieces & Instruments category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1449, MarketplaceTypeId = 1, Name = "Medical, Lab & Dental Supplies", LookupValue = "185284", Description = "The Medical, Lab & Dental Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1450, MarketplaceTypeId = 1, Name = "Medical/Lab Equipment Attachments & Accessories", LookupValue = "184512", Description = "The Medical/Lab Equipment Attachments & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1451, MarketplaceTypeId = 1, Name = "Medical, Lab & Caregiving Furniture", LookupValue = "184500", Description = "The Medical, Lab & Caregiving Furniture category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1452, MarketplaceTypeId = 1, Name = "Other Healthcare, Lab & Dental", LookupValue = "3179", Description = "The Other Healthcare, Lab & Dental category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1453, MarketplaceTypeId = 1, Name = "Test, Measurement & Inspection", LookupValue = "181939", Description = "The Test, Measurement & Inspection category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1454, MarketplaceTypeId = 1, Name = "Test Meters & Detectors", LookupValue = "181968", Description = "The Test Meters & Detectors category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1455, MarketplaceTypeId = 1, Name = "Analyzers & Data Acquisition Equipment", LookupValue = "181940", Description = "The Analyzers & Data Acquisition Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1456, MarketplaceTypeId = 1, Name = "Levels & Surveying Equipment", LookupValue = "42297", Description = "The Levels & Surveying Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1457, MarketplaceTypeId = 1, Name = "Test, Measurement & Inspection Cameras & Imaging Equipment", LookupValue = "181948", Description = "The Test, Measurement & Inspection Cameras & Imaging Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1458, MarketplaceTypeId = 1, Name = "Testers & Calibrators", LookupValue = "181998", Description = "The Testers & Calibrators category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1459, MarketplaceTypeId = 1, Name = "Signal Sources & Signal Conditioning Equipment", LookupValue = "181992", Description = "The Signal Sources & Signal Conditioning Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1460, MarketplaceTypeId = 1, Name = "CNC, Metalworking & Manufacturing", LookupValue = "11804", Description = "The CNC, Metalworking & Manufacturing category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1461, MarketplaceTypeId = 1, Name = "Metalworking Equipment", LookupValue = "258061", Description = "The Metalworking Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1462, MarketplaceTypeId = 1, Name = "Metalworking Inspection & Measurement", LookupValue = "185130", Description = "The Metalworking Inspection & Measurement category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1463, MarketplaceTypeId = 1, Name = "Welding & Soldering Equipment", LookupValue = "182941", Description = "The Welding & Soldering Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1464, MarketplaceTypeId = 1, Name = "Woodworking Equipment", LookupValue = "259031", Description = "The Woodworking Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1465, MarketplaceTypeId = 1, Name = "Workholding & Toolholding Supplies", LookupValue = "185133", Description = "The Workholding & Toolholding Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1466, MarketplaceTypeId = 1, Name = "Textile & Apparel Equipment", LookupValue = "45033", Description = "The Textile & Apparel Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1467, MarketplaceTypeId = 1, Name = "Heavy Equipment, Parts & Attachments", LookupValue = "257887", Description = "The Heavy Equipment, Parts & Attachments category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1468, MarketplaceTypeId = 1, Name = "Heavy Equipment", LookupValue = "177641", Description = "The Heavy Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1469, MarketplaceTypeId = 1, Name = "Heavy Equipment Parts & Accessories", LookupValue = "41489", Description = "The Heavy Equipment Parts & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1470, MarketplaceTypeId = 1, Name = "Heavy Equipment Attachments", LookupValue = "177647", Description = "The Heavy Equipment Attachments category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1471, MarketplaceTypeId = 1, Name = "Electrical Equipment & Supplies", LookupValue = "92074", Description = "The Electrical Equipment & Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1472, MarketplaceTypeId = 1, Name = "Circuit Breakers & Disconnectors", LookupValue = "181815", Description = "The Circuit Breakers & Disconnectors category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1473, MarketplaceTypeId = 1, Name = "Electronic Components & Semiconductors", LookupValue = "182412", Description = "The Electronic Components & Semiconductors category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1474, MarketplaceTypeId = 1, Name = "Electrical Boxes, Panels & Boards", LookupValue = "181917", Description = "The Electrical Boxes, Panels & Boards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1475, MarketplaceTypeId = 1, Name = "Industrial Switches", LookupValue = "181845", Description = "The Industrial Switches category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1476, MarketplaceTypeId = 1, Name = "Wire, Cable & Conduit", LookupValue = "73136", Description = "The Wire, Cable & Conduit category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1477, MarketplaceTypeId = 1, Name = "Industrial Transformers", LookupValue = "181929", Description = "The Industrial Transformers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1478, MarketplaceTypeId = 1, Name = "Light Equipment & Tools", LookupValue = "61573", Description = "The Light Equipment & Tools category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1479, MarketplaceTypeId = 1, Name = "Industrial Generators", LookupValue = "106437", Description = "The Industrial Generators category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1480, MarketplaceTypeId = 1, Name = "Electrical Tools", LookupValue = "185136", Description = "The Electrical Tools category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1481, MarketplaceTypeId = 1, Name = "Pipe Tools", LookupValue = "184042", Description = "The Pipe Tools category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1482, MarketplaceTypeId = 1, Name = "Industrial Hand Tools", LookupValue = "46576", Description = "The Industrial Hand Tools category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1483, MarketplaceTypeId = 1, Name = "Industrial Drills & Hammers", LookupValue = "42294", Description = "The Industrial Drills & Hammers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1484, MarketplaceTypeId = 1, Name = "Industrial Stationary Engines, Parts & Accessories", LookupValue = "58175", Description = "The Industrial Stationary Engines, Parts & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1485, MarketplaceTypeId = 1, Name = "Office", LookupValue = "25298", Description = "The Office category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1486, MarketplaceTypeId = 1, Name = "Office Equipment", LookupValue = "50203", Description = "The Office Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1487, MarketplaceTypeId = 1, Name = "Office Furniture", LookupValue = "11828", Description = "The Office Furniture category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1488, MarketplaceTypeId = 1, Name = "Office Supplies", LookupValue = "58271", Description = "The Office Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1489, MarketplaceTypeId = 1, Name = "Projectors & Presentation Equipment", LookupValue = "25319", Description = "The Projectors & Presentation Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1490, MarketplaceTypeId = 1, Name = "Telecom Systems", LookupValue = "11907", Description = "The Telecom Systems category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1491, MarketplaceTypeId = 1, Name = "Microfilm & Microfiche", LookupValue = "61673", Description = "The Microfilm & Microfiche category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1492, MarketplaceTypeId = 1, Name = "Facility Maintenance & Safety", LookupValue = "11897", Description = "The Facility Maintenance & Safety category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1493, MarketplaceTypeId = 1, Name = "Personal Protective Equipment (PPE)", LookupValue = "183970", Description = "The Personal Protective Equipment (PPE) category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1494, MarketplaceTypeId = 1, Name = "Industrial Fire Protection Equipment", LookupValue = "57017", Description = "The Industrial Fire Protection Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1495, MarketplaceTypeId = 1, Name = "Public Safety Staff Equipment", LookupValue = "183853", Description = "The Public Safety Staff Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1496, MarketplaceTypeId = 1, Name = "Access Control Equipment", LookupValue = "183810", Description = "The Access Control Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1497, MarketplaceTypeId = 1, Name = "Safety Signs & Traffic Control", LookupValue = "183887", Description = "The Safety Signs & Traffic Control category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1498, MarketplaceTypeId = 1, Name = "Industrial Surveillance & Alarm Equipment", LookupValue = "183868", Description = "The Industrial Surveillance & Alarm Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1499, MarketplaceTypeId = 1, Name = "HVAC & Refrigeration", LookupValue = "42909", Description = "The HVAC & Refrigeration category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1500, MarketplaceTypeId = 1, Name = "HVAC & Refrigeration Tools", LookupValue = "66996", Description = "The HVAC & Refrigeration Tools category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1501, MarketplaceTypeId = 1, Name = "Industrial HVAC & Refrigeration: Parts & Accessories", LookupValue = "53295", Description = "The Industrial HVAC & Refrigeration: Parts & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1502, MarketplaceTypeId = 1, Name = "Industrial HVAC & Refrigeration Components", LookupValue = "260068", Description = "The Industrial HVAC & Refrigeration Components category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1503, MarketplaceTypeId = 1, Name = "Other HVAC & Refrigeration", LookupValue = "42912", Description = "The Other HVAC & Refrigeration category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1504, MarketplaceTypeId = 1, Name = "Industrial Heating & Cooling Appliances", LookupValue = "260499", Description = "The Industrial Heating & Cooling Appliances category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1505, MarketplaceTypeId = 1, Name = "Industrial Refrigeration Equipment", LookupValue = "260062", Description = "The Industrial Refrigeration Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1506, MarketplaceTypeId = 1, Name = "Industrial Automation & Motion Controls", LookupValue = "42892", Description = "The Industrial Automation & Motion Controls category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1507, MarketplaceTypeId = 1, Name = "Control Systems & PLCs", LookupValue = "57516", Description = "The Control Systems & PLCs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1508, MarketplaceTypeId = 1, Name = "Industrial Electric Motors", LookupValue = "181730", Description = "The Industrial Electric Motors category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1509, MarketplaceTypeId = 1, Name = "Component Sensors", LookupValue = "181784", Description = "The Component Sensors category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1510, MarketplaceTypeId = 1, Name = "Drives & Starters", LookupValue = "78186", Description = "The Drives & Starters category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1511, MarketplaceTypeId = 1, Name = "Rotary & Linear Motion", LookupValue = "181736", Description = "The Rotary & Linear Motion category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1512, MarketplaceTypeId = 1, Name = "Industrial Robotic Arms", LookupValue = "50924", Description = "The Industrial Robotic Arms category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1513, MarketplaceTypeId = 1, Name = "Hydraulics, Pneumatics, Pumps & Plumbing", LookupValue = "183978", Description = "The Hydraulics, Pneumatics, Pumps & Plumbing category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1514, MarketplaceTypeId = 1, Name = "Pumps & Pump Accessories", LookupValue = "184062", Description = "The Pumps & Pump Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1515, MarketplaceTypeId = 1, Name = "Air Compressors & Blowers", LookupValue = "183979", Description = "The Air Compressors & Blowers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1516, MarketplaceTypeId = 1, Name = "Valves & Manifolds", LookupValue = "184112", Description = "The Valves & Manifolds category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1517, MarketplaceTypeId = 1, Name = "Fittings & Adapters", LookupValue = "183997", Description = "The Fittings & Adapters category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1518, MarketplaceTypeId = 1, Name = "Hydraulic & Pneumatic Cylinders", LookupValue = "184027", Description = "The Hydraulic & Pneumatic Cylinders category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1519, MarketplaceTypeId = 1, Name = "Pipe, Hose & Tubing", LookupValue = "184037", Description = "The Pipe, Hose & Tubing category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1520, MarketplaceTypeId = 1, Name = "Agriculture & Forestry", LookupValue = "11748", Description = "The Agriculture & Forestry category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1521, MarketplaceTypeId = 1, Name = "Livestock Supplies", LookupValue = "46526", Description = "The Livestock Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1522, MarketplaceTypeId = 1, Name = "Forestry Equipment & Supplies", LookupValue = "61787", Description = "The Forestry Equipment & Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1523, MarketplaceTypeId = 1, Name = "Other Agriculture & Forestry Equipment", LookupValue = "1269", Description = "The Other Agriculture & Forestry Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1524, MarketplaceTypeId = 1, Name = "Agriculture & Forestry GPS & Guidance Equipment", LookupValue = "159685", Description = "The Agriculture & Forestry GPS & Guidance Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1525, MarketplaceTypeId = 1, Name = "Agriculture & Forestry Wholesale Lots", LookupValue = "45013", Description = "The Agriculture & Forestry Wholesale Lots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1526, MarketplaceTypeId = 1, Name = "Retail & Services", LookupValue = "11890", Description = "The Retail & Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1527, MarketplaceTypeId = 1, Name = "Point of Sale & Money Handling", LookupValue = "71465", Description = "The Point of Sale & Money Handling category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1528, MarketplaceTypeId = 1, Name = "Mannequins & Dress Forms", LookupValue = "257915", Description = "The Mannequins & Dress Forms category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1529, MarketplaceTypeId = 1, Name = "Dry Cleaning & Laundromat Equipment", LookupValue = "73175", Description = "The Dry Cleaning & Laundromat Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1530, MarketplaceTypeId = 1, Name = "Retail Racks & Fixtures", LookupValue = "109430", Description = "The Retail Racks & Fixtures category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1531, MarketplaceTypeId = 1, Name = "Retail Security & Surveillance Equipment", LookupValue = "71479", Description = "The Retail Security & Surveillance Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1532, MarketplaceTypeId = 1, Name = "Retail Labeling & Tagging Supplies", LookupValue = "109415", Description = "The Retail Labeling & Tagging Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1533, MarketplaceTypeId = 1, Name = "Material Handling", LookupValue = "26221", Description = "The Material Handling category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1534, MarketplaceTypeId = 1, Name = "Packing & Shipping", LookupValue = "19273", Description = "The Packing & Shipping category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1535, MarketplaceTypeId = 1, Name = "Hoists, Winches & Rigging", LookupValue = "109551", Description = "The Hoists, Winches & Rigging category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1536, MarketplaceTypeId = 1, Name = "Warehouse Loading & Unloading", LookupValue = "184174", Description = "The Warehouse Loading & Unloading category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1537, MarketplaceTypeId = 1, Name = "Shipping Containers", LookupValue = "92079", Description = "The Shipping Containers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1538, MarketplaceTypeId = 1, Name = "Shelving & Storage", LookupValue = "57004", Description = "The Shelving & Storage category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1539, MarketplaceTypeId = 1, Name = "Casters & Wheels", LookupValue = "184161", Description = "The Casters & Wheels category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1540, MarketplaceTypeId = 1, Name = "Printing & Graphic Arts", LookupValue = "26238", Description = "The Printing & Graphic Arts category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1541, MarketplaceTypeId = 1, Name = "Commercial Screen & Specialty Printing Equipment", LookupValue = "46743", Description = "The Commercial Screen & Specialty Printing Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1542, MarketplaceTypeId = 1, Name = "Printing & Graphics Essentials", LookupValue = "46727", Description = "The Printing & Graphics Essentials category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1543, MarketplaceTypeId = 1, Name = "Plotters & Wide Format Printers", LookupValue = "46723", Description = "The Plotters & Wide Format Printers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1544, MarketplaceTypeId = 1, Name = "Bindery & Finishing Equipment", LookupValue = "26240", Description = "The Bindery & Finishing Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1545, MarketplaceTypeId = 1, Name = "Commercial Printing Presses", LookupValue = "26247", Description = "The Commercial Printing Presses category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1546, MarketplaceTypeId = 1, Name = "Commercial Printing Essentials", LookupValue = "97232", Description = "The Commercial Printing Essentials category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1547, MarketplaceTypeId = 1, Name = "Modular & Prefabricated Buildings", LookupValue = "55805", Description = "The Modular & Prefabricated Buildings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1548, MarketplaceTypeId = 1, Name = "Fasteners & Hardware", LookupValue = "183900", Description = "The Fasteners & Hardware category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1549, MarketplaceTypeId = 1, Name = "Industrial Screws & Bolts", LookupValue = "26217", Description = "The Industrial Screws & Bolts category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1550, MarketplaceTypeId = 1, Name = "Industrial Magnets", LookupValue = "119111", Description = "The Industrial Magnets category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1551, MarketplaceTypeId = 1, Name = "Industrial Clamps, Ties & Cords", LookupValue = "183949", Description = "The Industrial Clamps, Ties & Cords category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1552, MarketplaceTypeId = 1, Name = "Other Industrial Fasteners & Hardware", LookupValue = "42905", Description = "The Other Industrial Fasteners & Hardware category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1553, MarketplaceTypeId = 1, Name = "Industrial Fastener Nuts", LookupValue = "183905", Description = "The Industrial Fastener Nuts category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1554, MarketplaceTypeId = 1, Name = "Industrial Hardware Washers", LookupValue = "42904", Description = "The Industrial Hardware Washers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1555, MarketplaceTypeId = 1, Name = "Building Materials & Supplies", LookupValue = "41498", Description = "The Building Materials & Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1556, MarketplaceTypeId = 1, Name = "Industrial Insulation & Accessories", LookupValue = "260908", Description = "The Industrial Insulation & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1557, MarketplaceTypeId = 1, Name = "Industrial Paint, Coatings & Supplies", LookupValue = "46544", Description = "The Industrial Paint, Coatings & Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1558, MarketplaceTypeId = 1, Name = "Commercial Doors & Door Hardware", LookupValue = "260851", Description = "The Commercial Doors & Door Hardware category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1559, MarketplaceTypeId = 1, Name = "Industrial Windows & Window Hardware", LookupValue = "260901", Description = "The Industrial Windows & Window Hardware category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1560, MarketplaceTypeId = 1, Name = "Vintage Construction Equipment", LookupValue = "116996", Description = "The Vintage Construction Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1561, MarketplaceTypeId = 1, Name = "Other Industrial Building Materials & Supplies", LookupValue = "1268", Description = "The Other Industrial Building Materials & Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1562, MarketplaceTypeId = 1, Name = "Adhesives, Sealants & Tapes", LookupValue = "109471", Description = "The Adhesives, Sealants & Tapes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1563, MarketplaceTypeId = 1, Name = "Industrial Adhesive Tapes", LookupValue = "109475", Description = "The Industrial Adhesive Tapes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1564, MarketplaceTypeId = 1, Name = "Industrial Glues, Epoxies & Cements", LookupValue = "183746", Description = "The Industrial Glues, Epoxies & Cements category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1565, MarketplaceTypeId = 1, Name = "Industrial Adhesive Guns & Dispensers", LookupValue = "183780", Description = "The Industrial Adhesive Guns & Dispensers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1566, MarketplaceTypeId = 1, Name = "Industrial Caulks, Sealants & Removers", LookupValue = "184304", Description = "The Industrial Caulks, Sealants & Removers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

// Popular Topics (deep links)
                new () { Id = 1567, MarketplaceTypeId = 1, Name = "Food Trucks", LookupValue = "184249", Description = "The Food Trucks category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1568, MarketplaceTypeId = 1, Name = "Food Trucks, Trailers & Carts", LookupValue = "67145", Description = "The Food Trucks, Trailers & Carts category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1569, MarketplaceTypeId = 1, Name = "Fluke Test Equipment Multimeters", LookupValue = "58277", Description = "The Fluke Test Equipment Multimeters category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1570, MarketplaceTypeId = 1, Name = "Instantaneous Circuit Breakers", LookupValue = "185134", Description = "The Instantaneous Circuit Breakers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1571, MarketplaceTypeId = 1, Name = "Backhoe Loaders", LookupValue = "95493", Description = "The Backhoe Loaders category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1572, MarketplaceTypeId = 1, Name = "Metal Detectors", LookupValue = "14955", Description = "The Metal Detectors category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1573, MarketplaceTypeId = 1, Name = "Heavy Equipment", LookupValue = "177641", Description = "The Heavy Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1574, MarketplaceTypeId = 1, Name = "Industrial Mini Excavators", LookupValue = "97122", Description = "The Industrial Mini Excavators category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1575, MarketplaceTypeId = 1, Name = "Skid Steer Loaders", LookupValue = "95494", Description = "The Skid Steer Loaders category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1576, MarketplaceTypeId = 1, Name = "Poultry Hatching Eggs", LookupValue = "46532", Description = "The Poultry Hatching Eggs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1577, MarketplaceTypeId = 1, Name = "Jewelry & Watches", LookupValue = "281", Description = "The Jewelry & Watches category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1578, MarketplaceTypeId = 1, Name = "Watches, Parts & Accessories", LookupValue = "260324", Description = "The Watches, Parts & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1579, MarketplaceTypeId = 1, Name = "Watches", LookupValue = "260325", Description = "The Watches category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1580, MarketplaceTypeId = 1, Name = "Watch Accessories", LookupValue = "260328", Description = "The Watch Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1581, MarketplaceTypeId = 1, Name = "Watch Parts, Tools & Guides", LookupValue = "173696", Description = "The Watch Parts, Tools & Guides category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1582, MarketplaceTypeId = 1, Name = "Wholesale Watches", LookupValue = "51020", Description = "The Wholesale Watches category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1583, MarketplaceTypeId = 1, Name = "Fine Jewelry", LookupValue = "4196", Description = "The Fine Jewelry category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1584, MarketplaceTypeId = 1, Name = "Fine Rings", LookupValue = "261994", Description = "The Fine Rings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1585, MarketplaceTypeId = 1, Name = "Fine Necklaces & Pendants", LookupValue = "261993", Description = "The Fine Necklaces & Pendants category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1586, MarketplaceTypeId = 1, Name = "Fine Bracelets & Charms", LookupValue = "261988", Description = "The Fine Bracelets & Charms category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1587, MarketplaceTypeId = 1, Name = "Fine Earrings", LookupValue = "261990", Description = "The Fine Earrings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1588, MarketplaceTypeId = 1, Name = "Fine Brooches & Pins", LookupValue = "261989", Description = "The Fine Brooches & Pins category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1589, MarketplaceTypeId = 1, Name = "Fine Anklets", LookupValue = "101437", Description = "The Fine Anklets category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1590, MarketplaceTypeId = 1, Name = "Vintage & Antique Jewelry", LookupValue = "262024", Description = "The Vintage & Antique Jewelry category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1591, MarketplaceTypeId = 1, Name = "Vintage & Antique Necklaces & Pendants", LookupValue = "262013", Description = "The Vintage & Antique Necklaces & Pendants category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1592, MarketplaceTypeId = 1, Name = "Vintage & Antique Collections & Lots", LookupValue = "262016", Description = "The Vintage & Antique Collections & Lots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1593, MarketplaceTypeId = 1, Name = "Vintage & Antique Rings", LookupValue = "262014", Description = "The Vintage & Antique Rings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1594, MarketplaceTypeId = 1, Name = "Vintage & Antique Bracelets & Charms", LookupValue = "262003", Description = "The Vintage & Antique Bracelets & Charms category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1595, MarketplaceTypeId = 1, Name = "Vintage & Antique Brooches & Pins", LookupValue = "262004", Description = "The Vintage & Antique Brooches & Pins category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1596, MarketplaceTypeId = 1, Name = "Vintage & Antique Earrings", LookupValue = "262008", Description = "The Vintage & Antique Earrings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1597, MarketplaceTypeId = 1, Name = "Fashion Jewelry", LookupValue = "10968", Description = "The Fashion Jewelry category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1598, MarketplaceTypeId = 1, Name = "Fashion Necklaces & Pendants", LookupValue = "155101", Description = "The Fashion Necklaces & Pendants category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1599, MarketplaceTypeId = 1, Name = "Fashion Bracelets & Charms", LookupValue = "261987", Description = "The Fashion Bracelets & Charms category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1600, MarketplaceTypeId = 1, Name = "Fashion Earrings", LookupValue = "50647", Description = "The Fashion Earrings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1601, MarketplaceTypeId = 1, Name = "Fashion Rings", LookupValue = "67681", Description = "The Fashion Rings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1602, MarketplaceTypeId = 1, Name = "Fashion Brooches & Pins", LookupValue = "50677", Description = "The Fashion Brooches & Pins category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1603, MarketplaceTypeId = 1, Name = "Fashion Jewelry Sets", LookupValue = "50692", Description = "The Fashion Jewelry Sets category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1604, MarketplaceTypeId = 1, Name = "Ethnic, Regional & Tribal", LookupValue = "262025", Description = "The Ethnic, Regional & Tribal category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1605, MarketplaceTypeId = 1, Name = "Ethnic & Regional Necklaces & Pendants", LookupValue = "261984", Description = "The Ethnic & Regional Necklaces & Pendants category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1606, MarketplaceTypeId = 1, Name = "Ethnic & Regional Bracelets & Charms", LookupValue = "261979", Description = "The Ethnic & Regional Bracelets & Charms category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1607, MarketplaceTypeId = 1, Name = "Ethnic & Regional Rings", LookupValue = "261985", Description = "The Ethnic & Regional Rings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1608, MarketplaceTypeId = 1, Name = "Ethnic & Regional Earrings", LookupValue = "261981", Description = "The Ethnic & Regional Earrings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1609, MarketplaceTypeId = 1, Name = "Ethnic & Regional Brooches & Pins", LookupValue = "261980", Description = "The Ethnic & Regional Brooches & Pins category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1610, MarketplaceTypeId = 1, Name = "Ethnic & Regional Jewelry Sets", LookupValue = "261983", Description = "The Ethnic & Regional Jewelry Sets category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1611, MarketplaceTypeId = 1, Name = "Men's Jewelry", LookupValue = "10290", Description = "The Men's Jewelry category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1612, MarketplaceTypeId = 1, Name = "Men's Necklaces & Pendants", LookupValue = "137839", Description = "The Men's Necklaces & Pendants category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1613, MarketplaceTypeId = 1, Name = "Men's Rings", LookupValue = "137856", Description = "The Men's Rings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1614, MarketplaceTypeId = 1, Name = "Men's Cufflinks", LookupValue = "137843", Description = "The Men's Cufflinks category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1615, MarketplaceTypeId = 1, Name = "Men's Bracelets & Charms", LookupValue = "261999", Description = "The Men's Bracelets & Charms category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1616, MarketplaceTypeId = 1, Name = "Men's Bolo Ties", LookupValue = "10292", Description = "The Men's Bolo Ties category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1617, MarketplaceTypeId = 1, Name = "Men's Tie Clasps & Tacks", LookupValue = "10298", Description = "The Men's Tie Clasps & Tacks category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1618, MarketplaceTypeId = 1, Name = "Engagement & Wedding", LookupValue = "91427", Description = "The Engagement & Wedding category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1619, MarketplaceTypeId = 1, Name = "Engagement Rings", LookupValue = "261975", Description = "The Engagement Rings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1620, MarketplaceTypeId = 1, Name = "Engagement & Wedding Ring Sets", LookupValue = "261976", Description = "The Engagement & Wedding Ring Sets category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1621, MarketplaceTypeId = 1, Name = "Wedding & Anniversary Bands", LookupValue = "261977", Description = "The Wedding & Anniversary Bands category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1622, MarketplaceTypeId = 1, Name = "Jewelry Mixed Lots", LookupValue = "262022", Description = "The Jewelry Mixed Lots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1623, MarketplaceTypeId = 1, Name = "Jewelry Care, Design & Repair", LookupValue = "164352", Description = "The Jewelry Care, Design & Repair category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1624, MarketplaceTypeId = 1, Name = "Jewelry Boxes, Organizers & Packaging", LookupValue = "262017", Description = "The Jewelry Boxes, Organizers & Packaging category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1625, MarketplaceTypeId = 1, Name = "Jewelry Tools & Workbenches", LookupValue = "262020", Description = "The Jewelry Tools & Workbenches category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1626, MarketplaceTypeId = 1, Name = "Jewelry Cleaners & Polish", LookupValue = "67720", Description = "The Jewelry Cleaners & Polish category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1627, MarketplaceTypeId = 1, Name = "Jewelry Findings", LookupValue = "262018", Description = "The Jewelry Findings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1628, MarketplaceTypeId = 1, Name = "Jewelry Settings", LookupValue = "262019", Description = "The Jewelry Settings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1629, MarketplaceTypeId = 1, Name = "Jewelry for Parts or Repair", LookupValue = "262021", Description = "The Jewelry for Parts or Repair category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1630, MarketplaceTypeId = 1, Name = "Loose Diamonds & Gemstones", LookupValue = "491", Description = "The Loose Diamonds & Gemstones category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1631, MarketplaceTypeId = 1, Name = "Loose Gemstones", LookupValue = "262027", Description = "The Loose Gemstones category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1632, MarketplaceTypeId = 1, Name = "Loose Diamonds", LookupValue = "262026", Description = "The Loose Diamonds category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1633, MarketplaceTypeId = 1, Name = "Loose Cubic Zirconia", LookupValue = "10285", Description = "The Loose Cubic Zirconia category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1634, MarketplaceTypeId = 1, Name = "Handcrafted & Artisan Jewelry", LookupValue = "110633", Description = "The Handcrafted & Artisan Jewelry category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1635, MarketplaceTypeId = 1, Name = "Handcrafted Necklaces & Pendants", LookupValue = "110655", Description = "The Handcrafted Necklaces & Pendants category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1636, MarketplaceTypeId = 1, Name = "Handcrafted Earrings", LookupValue = "110645", Description = "The Handcrafted Earrings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1637, MarketplaceTypeId = 1, Name = "Handcrafted Rings", LookupValue = "110666", Description = "The Handcrafted Rings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1638, MarketplaceTypeId = 1, Name = "Handcrafted Bracelets & Charms", LookupValue = "261996", Description = "The Handcrafted Bracelets & Charms category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1639, MarketplaceTypeId = 1, Name = "Handcrafted Brooches & Pins", LookupValue = "152807", Description = "The Handcrafted Brooches & Pins category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1640, MarketplaceTypeId = 1, Name = "Handcrafted Jewelry Sets", LookupValue = "34071", Description = "The Handcrafted Jewelry Sets category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1641, MarketplaceTypeId = 1, Name = "Body Jewelry", LookupValue = "261986", Description = "The Body Jewelry category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1642, MarketplaceTypeId = 1, Name = "Loose Beads", LookupValue = "261997", Description = "The Loose Beads category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1643, MarketplaceTypeId = 1, Name = "Children's Jewelry", LookupValue = "84605", Description = "The Children's Jewelry category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1644, MarketplaceTypeId = 1, Name = "Children's Bracelets & Charms", LookupValue = "261974", Description = "The Children's Bracelets & Charms category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1645, MarketplaceTypeId = 1, Name = "Children's Earrings", LookupValue = "98476", Description = "The Children's Earrings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1646, MarketplaceTypeId = 1, Name = "Children's Rings", LookupValue = "98477", Description = "The Children's Rings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1647, MarketplaceTypeId = 1, Name = "Children's Necklaces & Pendants", LookupValue = "84607", Description = "The Children's Necklaces & Pendants category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1648, MarketplaceTypeId = 1, Name = "Children's Jewelry Sets", LookupValue = "98478", Description = "The Children's Jewelry Sets category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1649, MarketplaceTypeId = 1, Name = "Other Jewelry", LookupValue = "262023", Description = "The Other Jewelry category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

// Popular Topics (deep links)
                new () { Id = 1650, MarketplaceTypeId = 1, Name = "Seiko Watches, Parts & Accessories", LookupValue = "260324", Description = "The Seiko Watches, Parts & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1651, MarketplaceTypeId = 1, Name = "Rolex Watches, Parts & Accessories", LookupValue = "260324", Description = "The Rolex Watches, Parts & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1652, MarketplaceTypeId = 1, Name = "Rolex Watches", LookupValue = "31387", Description = "The Rolex Watches category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1653, MarketplaceTypeId = 1, Name = "Vintage & Antique Fashion Necklaces & Pendants", LookupValue = "262013", Description = "The Vintage & Antique Fashion Necklaces & Pendants category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1654, MarketplaceTypeId = 1, Name = "Vintage Watches", LookupValue = "31387", Description = "The Vintage Watches category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1655, MarketplaceTypeId = 1, Name = "Casio Watches, Parts & Accessories", LookupValue = "260324", Description = "The Casio Watches, Parts & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1656, MarketplaceTypeId = 1, Name = "Wristwatches", LookupValue = "31387", Description = "The Wristwatches category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1657, MarketplaceTypeId = 1, Name = "Van Cleef & Arpels Fine Jewelry", LookupValue = "4196", Description = "The Van Cleef & Arpels Fine Jewelry category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1658, MarketplaceTypeId = 1, Name = "Luxury Watches", LookupValue = "31387", Description = "The Luxury Watches category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1659, MarketplaceTypeId = 1, Name = "Seiko Watches", LookupValue = "31387", Description = "The Seiko Watches category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1660, MarketplaceTypeId = 1, Name = "Baby Essentials", LookupValue = "2984", Description = "The Baby Essentials category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1661, MarketplaceTypeId = 1, Name = "Baby", LookupValue = "260018", Description = "The Baby category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1662, MarketplaceTypeId = 1, Name = "Baby & Toddler Clothing", LookupValue = "260019", Description = "The Baby & Toddler Clothing category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1663, MarketplaceTypeId = 1, Name = "Baby Shoes", LookupValue = "147285", Description = "The Baby Shoes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1664, MarketplaceTypeId = 1, Name = "Baby Accessories", LookupValue = "163222", Description = "The Baby Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1665, MarketplaceTypeId = 1, Name = "Strollers & Accessories", LookupValue = "66698", Description = "The Strollers & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1666, MarketplaceTypeId = 1, Name = "Strollers", LookupValue = "66700", Description = "The Strollers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1667, MarketplaceTypeId = 1, Name = "Stroller Accessories", LookupValue = "180911", Description = "The Stroller Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1668, MarketplaceTypeId = 1, Name = "Stroller Parts", LookupValue = "121634", Description = "The Stroller Parts category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1669, MarketplaceTypeId = 1, Name = "Other Strollers", LookupValue = "2989", Description = "The Other Strollers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1670, MarketplaceTypeId = 1, Name = "Feeding", LookupValue = "20400", Description = "The Feeding category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1671, MarketplaceTypeId = 1, Name = "Baby Bottle Feeding", LookupValue = "184344", Description = "The Baby Bottle Feeding category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1672, MarketplaceTypeId = 1, Name = "Breastfeeding/Nursing", LookupValue = "23590", Description = "The Breastfeeding/Nursing category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1673, MarketplaceTypeId = 1, Name = "Baby High Chairs", LookupValue = "2986", Description = "The Baby High Chairs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1674, MarketplaceTypeId = 1, Name = "Baby Cups, Dishes & Utensils", LookupValue = "157325", Description = "The Baby Cups, Dishes & Utensils category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1675, MarketplaceTypeId = 1, Name = "Baby Pacifiers", LookupValue = "32872", Description = "The Baby Pacifiers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1676, MarketplaceTypeId = 1, Name = "Baby Bibs & Burp Cloths", LookupValue = "20408", Description = "The Baby Bibs & Burp Cloths category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1677, MarketplaceTypeId = 1, Name = "Nursery Bedding", LookupValue = "20416", Description = "The Nursery Bedding category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1678, MarketplaceTypeId = 1, Name = "Nursery Blankets & Throws", LookupValue = "3081", Description = "The Nursery Blankets & Throws category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1679, MarketplaceTypeId = 1, Name = "Nursery Bedding Sets", LookupValue = "162040", Description = "The Nursery Bedding Sets category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1680, MarketplaceTypeId = 1, Name = "Crib Quilts & Coverlets", LookupValue = "180908", Description = "The Crib Quilts & Coverlets category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1681, MarketplaceTypeId = 1, Name = "Nursery Sheets & Sets", LookupValue = "180909", Description = "The Nursery Sheets & Sets category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1682, MarketplaceTypeId = 1, Name = "Baby Sleeping Bags & Sleepsacks", LookupValue = "100989", Description = "The Baby Sleeping Bags & Sleepsacks category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1683, MarketplaceTypeId = 1, Name = "Baby Pillows", LookupValue = "180907", Description = "The Baby Pillows category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1684, MarketplaceTypeId = 1, Name = "Diapering", LookupValue = "45455", Description = "The Diapering category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1685, MarketplaceTypeId = 1, Name = "Diaper Bags", LookupValue = "15558", Description = "The Diaper Bags category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1686, MarketplaceTypeId = 1, Name = "Baby Disposable Diapers", LookupValue = "15559", Description = "The Baby Disposable Diapers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1687, MarketplaceTypeId = 1, Name = "Baby Cloth Diapers", LookupValue = "146531", Description = "The Baby Cloth Diapers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1688, MarketplaceTypeId = 1, Name = "Baby Wipes", LookupValue = "45456", Description = "The Baby Wipes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1689, MarketplaceTypeId = 1, Name = "Baby Changing Pads & Covers", LookupValue = "66674", Description = "The Baby Changing Pads & Covers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1690, MarketplaceTypeId = 1, Name = "Diaper Disposal Supplies", LookupValue = "20397", Description = "The Diaper Disposal Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1691, MarketplaceTypeId = 1, Name = "Toys for Baby", LookupValue = "19068", Description = "The Toys for Baby category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1692, MarketplaceTypeId = 1, Name = "Developmental Baby Toys", LookupValue = "100227", Description = "The Developmental Baby Toys category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1693, MarketplaceTypeId = 1, Name = "Plush Baby Toys", LookupValue = "131084", Description = "The Plush Baby Toys category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1694, MarketplaceTypeId = 1, Name = "Baby Gyms, Play Mats & Jigsaw Mats", LookupValue = "131082", Description = "The Baby Gyms, Play Mats & Jigsaw Mats category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1695, MarketplaceTypeId = 1, Name = "Crib Toys", LookupValue = "100226", Description = "The Crib Toys category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1696, MarketplaceTypeId = 1, Name = "Baby Rattles", LookupValue = "131081", Description = "The Baby Rattles category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1697, MarketplaceTypeId = 1, Name = "Baby Blocks & Sorters", LookupValue = "100225", Description = "The Baby Blocks & Sorters category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1698, MarketplaceTypeId = 1, Name = "Car Safety Seats", LookupValue = "66692", Description = "The Car Safety Seats category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1699, MarketplaceTypeId = 1, Name = "Baby Car Seat Accessories", LookupValue = "66693", Description = "The Baby Car Seat Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1700, MarketplaceTypeId = 1, Name = "Infant Car Seats (5-20lbs)", LookupValue = "66696", Description = "The Infant Car Seats (5-20lbs) category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1701, MarketplaceTypeId = 1, Name = "Convertible Baby Car Seats (5-40lbs)", LookupValue = "66695", Description = "The Convertible Baby Car Seats (5-40lbs) category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1702, MarketplaceTypeId = 1, Name = "Child Car Booster Seats up to 80lbs", LookupValue = "66694", Description = "The Child Car Booster Seats up to 80lbs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1703, MarketplaceTypeId = 1, Name = "Baby Gear", LookupValue = "100223", Description = "The Baby Gear category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1704, MarketplaceTypeId = 1, Name = "Baby Playpens & Play Yards", LookupValue = "2988", Description = "The Baby Playpens & Play Yards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1705, MarketplaceTypeId = 1, Name = "Baby Swings", LookupValue = "2990", Description = "The Baby Swings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1706, MarketplaceTypeId = 1, Name = "Baby Walkers", LookupValue = "134282", Description = "The Baby Walkers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1707, MarketplaceTypeId = 1, Name = "Baby Bouncers & Vibrating Chairs", LookupValue = "117034", Description = "The Baby Bouncers & Vibrating Chairs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1708, MarketplaceTypeId = 1, Name = "Baby Jumpers", LookupValue = "117032", Description = "The Baby Jumpers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1709, MarketplaceTypeId = 1, Name = "Baby Activity Centers", LookupValue = "20413", Description = "The Baby Activity Centers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1710, MarketplaceTypeId = 1, Name = "Carriers, Slings & Backpacks", LookupValue = "100982", Description = "The Carriers, Slings & Backpacks category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1711, MarketplaceTypeId = 1, Name = "Baby Safety & Health", LookupValue = "20433", Description = "The Baby Safety & Health category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1712, MarketplaceTypeId = 1, Name = "Baby Monitors", LookupValue = "20435", Description = "The Baby Monitors category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1713, MarketplaceTypeId = 1, Name = "Baby Safety Gates", LookupValue = "117029", Description = "The Baby Safety Gates category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1714, MarketplaceTypeId = 1, Name = "Baby Bed Rails", LookupValue = "162183", Description = "The Baby Bed Rails category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1715, MarketplaceTypeId = 1, Name = "Toddler Safety Harnesses", LookupValue = "134761", Description = "The Toddler Safety Harnesses category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1716, MarketplaceTypeId = 1, Name = "Baby Shopping Cart Covers", LookupValue = "73470", Description = "The Baby Shopping Cart Covers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1717, MarketplaceTypeId = 1, Name = "Baby Proofing", LookupValue = "184339", Description = "The Baby Proofing category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1718, MarketplaceTypeId = 1, Name = "Nursery Furniture", LookupValue = "20422", Description = "The Nursery Furniture category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1719, MarketplaceTypeId = 1, Name = "Bassinets & Cradles", LookupValue = "20423", Description = "The Bassinets & Cradles category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1720, MarketplaceTypeId = 1, Name = "Cribs", LookupValue = "2985", Description = "The Cribs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1721, MarketplaceTypeId = 1, Name = "Crib Mattresses", LookupValue = "117035", Description = "The Crib Mattresses category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1722, MarketplaceTypeId = 1, Name = "Changing Tables", LookupValue = "20424", Description = "The Changing Tables category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1723, MarketplaceTypeId = 1, Name = "Baby Rockers & Gliders", LookupValue = "66690", Description = "The Baby Rockers & Gliders category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1724, MarketplaceTypeId = 1, Name = "Baby Moses Baskets", LookupValue = "94931", Description = "The Baby Moses Baskets category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1725, MarketplaceTypeId = 1, Name = "Nursery Décor", LookupValue = "66697", Description = "The Nursery Décor category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1726, MarketplaceTypeId = 1, Name = "Nursery Mobiles", LookupValue = "20429", Description = "The Nursery Mobiles category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1727, MarketplaceTypeId = 1, Name = "Nursery Wall Décor", LookupValue = "37633", Description = "The Nursery Wall Décor category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1728, MarketplaceTypeId = 1, Name = "Nursery Lamps & Shades", LookupValue = "20428", Description = "The Nursery Lamps & Shades category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1729, MarketplaceTypeId = 1, Name = "Nursery Window Treatments", LookupValue = "20431", Description = "The Nursery Window Treatments category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1730, MarketplaceTypeId = 1, Name = "Nursery Night Lights", LookupValue = "121153", Description = "The Nursery Night Lights category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1731, MarketplaceTypeId = 1, Name = "Nursery Mats & Rugs", LookupValue = "37632", Description = "The Nursery Mats & Rugs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1732, MarketplaceTypeId = 1, Name = "Bathing & Grooming", LookupValue = "20394", Description = "The Bathing & Grooming category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1733, MarketplaceTypeId = 1, Name = "Baby Bath Tubs", LookupValue = "113814", Description = "The Baby Bath Tubs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1734, MarketplaceTypeId = 1, Name = "Baby Towels & Washcloths", LookupValue = "45453", Description = "The Baby Towels & Washcloths category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1735, MarketplaceTypeId = 1, Name = "Skincare for Babies", LookupValue = "20398", Description = "The Skincare for Babies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1736, MarketplaceTypeId = 1, Name = "Baby Shampoos & Soaps", LookupValue = "82563", Description = "The Baby Shampoos & Soaps category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1737, MarketplaceTypeId = 1, Name = "Baby Scales", LookupValue = "117016", Description = "The Baby Scales category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1738, MarketplaceTypeId = 1, Name = "Baby Health & Grooming Products", LookupValue = "45452", Description = "The Baby Health & Grooming Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1739, MarketplaceTypeId = 1, Name = "Keepsakes & Baby Announcements", LookupValue = "117388", Description = "The Keepsakes & Baby Announcements category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1740, MarketplaceTypeId = 1, Name = "Baby Books & Albums", LookupValue = "117389", Description = "The Baby Books & Albums category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1741, MarketplaceTypeId = 1, Name = "Baby Handprint Kits", LookupValue = "162037", Description = "The Baby Handprint Kits category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1742, MarketplaceTypeId = 1, Name = "Baby Picture Frames", LookupValue = "117392", Description = "The Baby Picture Frames category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1743, MarketplaceTypeId = 1, Name = "Tooth Fairy Pillows", LookupValue = "162038", Description = "The Tooth Fairy Pillows category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1744, MarketplaceTypeId = 1, Name = "Baby Keepsake Boxes", LookupValue = "117390", Description = "The Baby Keepsake Boxes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1745, MarketplaceTypeId = 1, Name = "Birth Announcements & Cards", LookupValue = "117391", Description = "The Birth Announcements & Cards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1746, MarketplaceTypeId = 1, Name = "Children's Jewelry", LookupValue = "84605", Description = "The Children's Jewelry category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1747, MarketplaceTypeId = 1, Name = "Children's Bracelets & Charms", LookupValue = "261974", Description = "The Children's Bracelets & Charms category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1748, MarketplaceTypeId = 1, Name = "Children's Earrings", LookupValue = "98476", Description = "The Children's Earrings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1749, MarketplaceTypeId = 1, Name = "Children's Rings", LookupValue = "98477", Description = "The Children's Rings category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1750, MarketplaceTypeId = 1, Name = "Children's Necklaces & Pendants", LookupValue = "84607", Description = "The Children's Necklaces & Pendants category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1751, MarketplaceTypeId = 1, Name = "Children's Jewelry Sets", LookupValue = "98478", Description = "The Children's Jewelry Sets category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1752, MarketplaceTypeId = 1, Name = "Potty Training", LookupValue = "37631", Description = "The Potty Training category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1753, MarketplaceTypeId = 1, Name = "Other Baby", LookupValue = "1261", Description = "The Other Baby category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1754, MarketplaceTypeId = 1, Name = "Wholesale Lots", LookupValue = "48757", Description = "The Wholesale Lots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

// Popular Topics (deep links)
                new () { Id = 1755, MarketplaceTypeId = 1, Name = "Baby Girls Clothes", LookupValue = "260024", Description = "The Baby Girls Clothes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1756, MarketplaceTypeId = 1, Name = "Multicolor Baby & Toddler Clothing", LookupValue = "260019", Description = "The Multicolor Baby & Toddler Clothing category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1757, MarketplaceTypeId = 1, Name = "Newborn Baby Clothing", LookupValue = "260019", Description = "The Newborn Baby Clothing category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1758, MarketplaceTypeId = 1, Name = "Strollers", LookupValue = "66700", Description = "The Strollers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1759, MarketplaceTypeId = 1, Name = "Baby Clothing Size 3T", LookupValue = "260019", Description = "The Baby Clothing Size 3T category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1760, MarketplaceTypeId = 1, Name = "Jordan Baby Shoes", LookupValue = "147285", Description = "The Jordan Baby Shoes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1761, MarketplaceTypeId = 1, Name = "2T Size Baby & Toddler Clothing", LookupValue = "260019", Description = "The 2T Size Baby & Toddler Clothing category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1762, MarketplaceTypeId = 1, Name = "Disney Baby & Toddler Clothing", LookupValue = "260019", Description = "The Disney Baby & Toddler Clothing category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1763, MarketplaceTypeId = 1, Name = "Nike Baby & Toddler Shoes", LookupValue = "147285", Description = "The Nike Baby & Toddler Shoes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1764, MarketplaceTypeId = 1, Name = "Infant Car Seats (5-20lbs)", LookupValue = "66696", Description = "The Infant Car Seats (5-20lbs) category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1765, MarketplaceTypeId = 1, Name = "Pet Supplies", LookupValue = "1281", Description = "The Pet Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1766, MarketplaceTypeId = 1, Name = "Dog Supplies", LookupValue = "20742", Description = "The Dog Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1767, MarketplaceTypeId = 1, Name = "Dog Dishes, Feeders & Fountains", LookupValue = "177789", Description = "The Dog Dishes, Feeders & Fountains category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1768, MarketplaceTypeId = 1, Name = "Dog Training & Obedience Supplies", LookupValue = "116381", Description = "The Dog Training & Obedience Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1769, MarketplaceTypeId = 1, Name = "Dog Collars", LookupValue = "63057", Description = "The Dog Collars category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1770, MarketplaceTypeId = 1, Name = "Dog Clothing & Shoes", LookupValue = "177796", Description = "The Dog Clothing & Shoes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1771, MarketplaceTypeId = 1, Name = "Dog Grooming Supplies", LookupValue = "177792", Description = "The Dog Grooming Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1772, MarketplaceTypeId = 1, Name = "Dog Transport & Travel Supplies", LookupValue = "178061", Description = "The Dog Transport & Travel Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1773, MarketplaceTypeId = 1, Name = "Fish & Aquariums", LookupValue = "20754", Description = "The Fish & Aquariums category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1774, MarketplaceTypeId = 1, Name = "Aquariums & Tanks", LookupValue = "20755", Description = "The Aquariums & Tanks category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1775, MarketplaceTypeId = 1, Name = "Aquarium Filters", LookupValue = "46310", Description = "The Aquarium Filters category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1776, MarketplaceTypeId = 1, Name = "Aquarium Decorations", LookupValue = "66789", Description = "The Aquarium Decorations category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1777, MarketplaceTypeId = 1, Name = "Aquarium Lighting & Bulbs", LookupValue = "46314", Description = "The Aquarium Lighting & Bulbs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1778, MarketplaceTypeId = 1, Name = "Fish Food", LookupValue = "20759", Description = "The Fish Food category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1779, MarketplaceTypeId = 1, Name = "Live Aquarium Fish", LookupValue = "168141", Description = "The Live Aquarium Fish category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1780, MarketplaceTypeId = 1, Name = "Cat Supplies", LookupValue = "20737", Description = "The Cat Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1781, MarketplaceTypeId = 1, Name = "Cat Furniture & Scratchers", LookupValue = "20740", Description = "The Cat Furniture & Scratchers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1782, MarketplaceTypeId = 1, Name = "Cat Litter Boxes", LookupValue = "100411", Description = "The Cat Litter Boxes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1783, MarketplaceTypeId = 1, Name = "Cat Food Supplies", LookupValue = "63073", Description = "The Cat Food Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1784, MarketplaceTypeId = 1, Name = "Cat Toys", LookupValue = "20741", Description = "The Cat Toys category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1785, MarketplaceTypeId = 1, Name = "Cat Topical Flea & Tick Remedies & Collars", LookupValue = "20738", Description = "The Cat Topical Flea & Tick Remedies & Collars category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1786, MarketplaceTypeId = 1, Name = "Cat Litter", LookupValue = "116363", Description = "The Cat Litter category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1787, MarketplaceTypeId = 1, Name = "Bird Supplies", LookupValue = "20734", Description = "The Bird Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1788, MarketplaceTypeId = 1, Name = "Bird Cages", LookupValue = "46289", Description = "The Bird Cages category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1789, MarketplaceTypeId = 1, Name = "Bird Incubators", LookupValue = "46292", Description = "The Bird Incubators category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1790, MarketplaceTypeId = 1, Name = "Bird Toys", LookupValue = "20736", Description = "The Bird Toys category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1791, MarketplaceTypeId = 1, Name = "Other Bird Supplies", LookupValue = "3211", Description = "The Other Bird Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1792, MarketplaceTypeId = 1, Name = "Bird Perches", LookupValue = "46291", Description = "The Bird Perches category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1793, MarketplaceTypeId = 1, Name = "Bird Feeders", LookupValue = "46290", Description = "The Bird Feeders category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1794, MarketplaceTypeId = 1, Name = "Small Animal Supplies", LookupValue = "259320", Description = "The Small Animal Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1795, MarketplaceTypeId = 1, Name = "Small Animal Cages, Hutches & Enclosures", LookupValue = "63108", Description = "The Small Animal Cages, Hutches & Enclosures category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1796, MarketplaceTypeId = 1, Name = "Small Animal Feeding & Watering Equipment", LookupValue = "63116", Description = "The Small Animal Feeding & Watering Equipment category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1797, MarketplaceTypeId = 1, Name = "Small Animal Beds, Hammocks & Nesters", LookupValue = "149074", Description = "The Small Animal Beds, Hammocks & Nesters category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1798, MarketplaceTypeId = 1, Name = "Small Animal Exercise & Toys", LookupValue = "63113", Description = "The Small Animal Exercise & Toys category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1799, MarketplaceTypeId = 1, Name = "Small Animal Collars, Leads & Harnesses", LookupValue = "63112", Description = "The Small Animal Collars, Leads & Harnesses category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1800, MarketplaceTypeId = 1, Name = "Other Small Animal Supplies", LookupValue = "11289", Description = "The Other Small Animal Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1801, MarketplaceTypeId = 1, Name = "Reptile Supplies", LookupValue = "1285", Description = "The Reptile Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1802, MarketplaceTypeId = 1, Name = "Backyard Poultry Supplies", LookupValue = "177801", Description = "The Backyard Poultry Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1803, MarketplaceTypeId = 1, Name = "Pet Memorials & Urns", LookupValue = "116391", Description = "The Pet Memorials & Urns category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1804, MarketplaceTypeId = 1, Name = "Other Pet Supplies", LookupValue = "301", Description = "The Other Pet Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1805, MarketplaceTypeId = 1, Name = "Trackers", LookupValue = "259319", Description = "The Trackers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1806, MarketplaceTypeId = 1, Name = "Cameras", LookupValue = "259318", Description = "The Cameras category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1807, MarketplaceTypeId = 1, Name = "Wholesale Lots", LookupValue = "48760", Description = "The Wholesale Lots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

// Popular Topics (deep links)
                new () { Id = 1808, MarketplaceTypeId = 1, Name = "Dog Food Dispensers & Scoops", LookupValue = "177789", Description = "The Dog Food Dispensers & Scoops category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1809, MarketplaceTypeId = 1, Name = "Aquariums & Tanks", LookupValue = "20755", Description = "The Aquariums & Tanks category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1810, MarketplaceTypeId = 1, Name = "Dog Food", LookupValue = "66780", Description = "The Dog Food category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1811, MarketplaceTypeId = 1, Name = "Cat Scratching Trees", LookupValue = "20740", Description = "The Cat Scratching Trees category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1812, MarketplaceTypeId = 1, Name = "Bird Cages", LookupValue = "46289", Description = "The Bird Cages category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1813, MarketplaceTypeId = 1, Name = "Dog Toys", LookupValue = "177791", Description = "The Dog Toys category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1814, MarketplaceTypeId = 1, Name = "Dog Costumes", LookupValue = "52352", Description = "The Dog Costumes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1815, MarketplaceTypeId = 1, Name = "Dog Beds", LookupValue = "20744", Description = "The Dog Beds category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1816, MarketplaceTypeId = 1, Name = "Dog Clothing & Shoes", LookupValue = "177796", Description = "The Dog Clothing & Shoes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1817, MarketplaceTypeId = 1, Name = "Dog Strollers", LookupValue = "116380", Description = "The Dog Strollers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1818, MarketplaceTypeId = 1, Name = "Tickets & Travel", LookupValue = "7000259668", Description = "The Tickets & Travel category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1819, MarketplaceTypeId = 1, Name = "Travel", LookupValue = "3252", Description = "The Travel category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1820, MarketplaceTypeId = 1, Name = "Travel Luggage", LookupValue = "16080", Description = "The Travel Luggage category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1821, MarketplaceTypeId = 1, Name = "Vintage Luggage & Vintage Travel Accessories", LookupValue = "183477", Description = "The Vintage Luggage & Vintage Travel Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1822, MarketplaceTypeId = 1, Name = "Travel Lodging", LookupValue = "16123", Description = "The Travel Lodging category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1823, MarketplaceTypeId = 1, Name = "Travel Accessories", LookupValue = "93838", Description = "The Travel Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1824, MarketplaceTypeId = 1, Name = "Travel Luggage Accessories", LookupValue = "173520", Description = "The Travel Luggage Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1825, MarketplaceTypeId = 1, Name = "Travel Vacation Packages", LookupValue = "29578", Description = "The Travel Vacation Packages category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1826, MarketplaceTypeId = 1, Name = "Tickets & Experiences", LookupValue = "1305", Description = "The Tickets & Experiences category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1827, MarketplaceTypeId = 1, Name = "Sports Tickets", LookupValue = "173633", Description = "The Sports Tickets category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1828, MarketplaceTypeId = 1, Name = "Concert Tickets", LookupValue = "173634", Description = "The Concert Tickets category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1829, MarketplaceTypeId = 1, Name = "Theater Tickets", LookupValue = "173635", Description = "The Theater Tickets category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1830, MarketplaceTypeId = 1, Name = "Other Tickets & Experiences", LookupValue = "1306", Description = "The Other Tickets & Experiences category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1831, MarketplaceTypeId = 1, Name = "Parking Passes", LookupValue = "178892", Description = "The Parking Passes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1832, MarketplaceTypeId = 1, Name = "Theme Park & Club Passes", LookupValue = "170594", Description = "The Theme Park & Club Passes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

// Popular Topics (deep links)
                new () { Id = 1833, MarketplaceTypeId = 1, Name = "RIMOWA Travel Luggage", LookupValue = "16080", Description = "The RIMOWA Travel Luggage category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1834, MarketplaceTypeId = 1, Name = "Louis Vuitton Carry-On Luggage", LookupValue = "16080", Description = "The Louis Vuitton Carry-On Luggage category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1835, MarketplaceTypeId = 1, Name = "Tumi Carry-On Luggage", LookupValue = "16080", Description = "The Tumi Carry-On Luggage category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1836, MarketplaceTypeId = 1, Name = "Travel Luggage", LookupValue = "16080", Description = "The Travel Luggage category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1837, MarketplaceTypeId = 1, Name = "RIMOWA Suitcases", LookupValue = "16080", Description = "The RIMOWA Suitcases category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1838, MarketplaceTypeId = 1, Name = "Louis Vuitton Travel Luggage", LookupValue = "16080", Description = "The Louis Vuitton Travel Luggage category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1839, MarketplaceTypeId = 1, Name = "Concert Tickets", LookupValue = "173634", Description = "The Concert Tickets category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1840, MarketplaceTypeId = 1, Name = "Tumi Travel Luggage", LookupValue = "16080", Description = "The Tumi Travel Luggage category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1841, MarketplaceTypeId = 1, Name = "RIMOWA Carry-On Luggage", LookupValue = "16080", Description = "The RIMOWA Carry-On Luggage category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1842, MarketplaceTypeId = 1, Name = "Louis Vuitton Suitcases", LookupValue = "16080", Description = "The Louis Vuitton Suitcases category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1843, MarketplaceTypeId = 1, Name = "Everything Else", LookupValue = "99", Description = "The Everything Else category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1844, MarketplaceTypeId = 1, Name = "eBay Special Offers", LookupValue = "177600", Description = "The eBay Special Offers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1845, MarketplaceTypeId = 1, Name = "eBay Special Offer 1", LookupValue = "177601", Description = "The eBay Special Offer 1 category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1846, MarketplaceTypeId = 1, Name = "eBay Special Offer 3", LookupValue = "177603", Description = "The eBay Special Offer 3 category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1847, MarketplaceTypeId = 1, Name = "Gifts that Give Back", LookupValue = "177602", Description = "The Gifts that Give Back category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1848, MarketplaceTypeId = 1, Name = "Funeral & Cemetery", LookupValue = "88739", Description = "The Funeral & Cemetery category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1849, MarketplaceTypeId = 1, Name = "Cemetery Plots", LookupValue = "88741", Description = "The Cemetery Plots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1850, MarketplaceTypeId = 1, Name = "Cremation Urns", LookupValue = "88742", Description = "The Cremation Urns category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1851, MarketplaceTypeId = 1, Name = "Funeral Caskets", LookupValue = "88740", Description = "The Funeral Caskets category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1852, MarketplaceTypeId = 1, Name = "Cemetery Headstones & Grave Markers", LookupValue = "179692", Description = "The Cemetery Headstones & Grave Markers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1853, MarketplaceTypeId = 1, Name = "Funeral Casket Parts & Accessories", LookupValue = "179691", Description = "The Funeral Casket Parts & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1854, MarketplaceTypeId = 1, Name = "Other Funeral & Cemetery Items", LookupValue = "88744", Description = "The Other Funeral & Cemetery Items category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1855, MarketplaceTypeId = 1, Name = "Weird Stuff", LookupValue = "1466", Description = "The Weird Stuff category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1856, MarketplaceTypeId = 1, Name = "Really Weird Stuff", LookupValue = "1468", Description = "The Really Weird Stuff category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1857, MarketplaceTypeId = 1, Name = "Totally Bizarre Stuff", LookupValue = "1469", Description = "The Totally Bizarre Stuff category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1858, MarketplaceTypeId = 1, Name = "Slightly Unusual Stuff", LookupValue = "1467", Description = "The Slightly Unusual Stuff category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1859, MarketplaceTypeId = 1, Name = "Personal Security", LookupValue = "102535", Description = "The Personal Security category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1860, MarketplaceTypeId = 1, Name = "Personal Security Stun Guns", LookupValue = "79850", Description = "The Personal Security Stun Guns category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1861, MarketplaceTypeId = 1, Name = "Personal Security Pepper Spray", LookupValue = "79849", Description = "The Personal Security Pepper Spray category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1862, MarketplaceTypeId = 1, Name = "Personal Security Surveillance Cameras", LookupValue = "102543", Description = "The Personal Security Surveillance Cameras category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1863, MarketplaceTypeId = 1, Name = "Personal Security Handcuffs", LookupValue = "102538", Description = "The Personal Security Handcuffs category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1864, MarketplaceTypeId = 1, Name = "Other Personal Security Products", LookupValue = "3204", Description = "The Other Personal Security Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1865, MarketplaceTypeId = 1, Name = "Personal Security Safes", LookupValue = "102542", Description = "The Personal Security Safes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1866, MarketplaceTypeId = 1, Name = "Metaphysical", LookupValue = "19266", Description = "The Metaphysical category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1867, MarketplaceTypeId = 1, Name = "Psychic & Paranormal Items", LookupValue = "102513", Description = "The Psychic & Paranormal Items category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1868, MarketplaceTypeId = 1, Name = "Crystal Healing Items", LookupValue = "102493", Description = "The Crystal Healing Items category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1869, MarketplaceTypeId = 1, Name = "Tarot Cards", LookupValue = "102520", Description = "The Tarot Cards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1870, MarketplaceTypeId = 1, Name = "Wiccan Products", LookupValue = "116109", Description = "The Wiccan Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1871, MarketplaceTypeId = 1, Name = "Feng Shui Items", LookupValue = "102502", Description = "The Feng Shui Items category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1872, MarketplaceTypeId = 1, Name = "Metaphysical Reiki", LookupValue = "102518", Description = "The Metaphysical Reiki category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1873, MarketplaceTypeId = 1, Name = "Genealogy", LookupValue = "20925", Description = "The Genealogy category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1874, MarketplaceTypeId = 1, Name = "Genealogy Family Trees", LookupValue = "116100", Description = "The Genealogy Family Trees category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1875, MarketplaceTypeId = 1, Name = "Genealogy Coat of Arms", LookupValue = "116098", Description = "The Genealogy Coat of Arms category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1876, MarketplaceTypeId = 1, Name = "Genealogy Maps", LookupValue = "102363", Description = "The Genealogy Maps category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1877, MarketplaceTypeId = 1, Name = "Genealogy City & State Directories", LookupValue = "20928", Description = "The Genealogy City & State Directories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1878, MarketplaceTypeId = 1, Name = "Genealogy County & State History", LookupValue = "116099", Description = "The Genealogy County & State History category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1879, MarketplaceTypeId = 1, Name = "Genealogy Immigration & Passenger Lists", LookupValue = "20929", Description = "The Genealogy Immigration & Passenger Lists category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1880, MarketplaceTypeId = 1, Name = "Every Other Thing", LookupValue = "88433", Description = "The Every Other Thing category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1881, MarketplaceTypeId = 1, Name = "Religious Products & Supplies", LookupValue = "102545", Description = "The Religious Products & Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1882, MarketplaceTypeId = 1, Name = "Religious Rosaries", LookupValue = "102552", Description = "The Religious Rosaries category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1883, MarketplaceTypeId = 1, Name = "Religious Bible Covers & Accessories", LookupValue = "116118", Description = "The Religious Bible Covers & Accessories category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1884, MarketplaceTypeId = 1, Name = "Communion Products & Supplies", LookupValue = "102548", Description = "The Communion Products & Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1885, MarketplaceTypeId = 1, Name = "Religious Clothing & Supplies", LookupValue = "102547", Description = "The Religious Clothing & Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1886, MarketplaceTypeId = 1, Name = "Religious Crosses", LookupValue = "102549", Description = "The Religious Crosses category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1887, MarketplaceTypeId = 1, Name = "Religious Art Products & Supplies", LookupValue = "102546", Description = "The Religious Art Products & Supplies category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1888, MarketplaceTypeId = 1, Name = "Reward Points & Incentives", LookupValue = "102553", Description = "The Reward Points & Incentives category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1889, MarketplaceTypeId = 1, Name = "Career Development & Education", LookupValue = "3143", Description = "The Career Development & Education category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1890, MarketplaceTypeId = 1, Name = "Certification & Licenses Career Development Essentials", LookupValue = "16708", Description = "The Certification & Licenses Career Development Essentials category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1891, MarketplaceTypeId = 1, Name = "Real Estate Career Development Essentials", LookupValue = "102328", Description = "The Real Estate Career Development Essentials category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1892, MarketplaceTypeId = 1, Name = "Direct Selling Career Development Essentials", LookupValue = "102325", Description = "The Direct Selling Career Development Essentials category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1893, MarketplaceTypeId = 1, Name = "Computer & Technical Career Development Essentials", LookupValue = "21255", Description = "The Computer & Technical Career Development Essentials category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1894, MarketplaceTypeId = 1, Name = "Other Education & Career Development Essentials", LookupValue = "3144", Description = "The Other Education & Career Development Essentials category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1895, MarketplaceTypeId = 1, Name = "Healthcare & Nursing Career Development Essentials", LookupValue = "4256", Description = "The Healthcare & Nursing Career Development Essentials category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1896, MarketplaceTypeId = 1, Name = "Information Products", LookupValue = "102480", Description = "The Information Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1897, MarketplaceTypeId = 1, Name = "Wholesale Lists", LookupValue = "102487", Description = "The Wholesale Lists category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1898, MarketplaceTypeId = 1, Name = "How-To Guides", LookupValue = "102481", Description = "The How-To Guides category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1899, MarketplaceTypeId = 1, Name = "Other Information Products", LookupValue = "47103", Description = "The Other Information Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1900, MarketplaceTypeId = 1, Name = "Personal Development", LookupValue = "102329", Description = "The Personal Development category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1901, MarketplaceTypeId = 1, Name = "Personal Finance Products", LookupValue = "102332", Description = "The Personal Finance Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1902, MarketplaceTypeId = 1, Name = "Other Personal Development Products", LookupValue = "3149", Description = "The Other Personal Development Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1903, MarketplaceTypeId = 1, Name = "Leadership & Self-Confidence Products", LookupValue = "102330", Description = "The Leadership & Self-Confidence Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1904, MarketplaceTypeId = 1, Name = "Memory Improvement Products", LookupValue = "102331", Description = "The Memory Improvement Products category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1905, MarketplaceTypeId = 1, Name = "eBay User Tools", LookupValue = "20924", Description = "The eBay User Tools category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1906, MarketplaceTypeId = 1, Name = "Blocked Category For Internal Use", LookupValue = "263529", Description = "The Blocked Category For Internal Use category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

// Popular Topics (deep links)
                new () { Id = 1907, MarketplaceTypeId = 1, Name = "eBay Special Offers", LookupValue = "177600", Description = "The eBay Special Offers category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1908, MarketplaceTypeId = 1, Name = "California Cemetery Plots", LookupValue = "88741", Description = "The California Cemetery Plots category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1909, MarketplaceTypeId = 1, Name = "Weird Stuff", LookupValue = "1466", Description = "The Weird Stuff category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1910, MarketplaceTypeId = 1, Name = "TASER Personal Security Stun Guns", LookupValue = "79850", Description = "The TASER Personal Security Stun Guns category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1911, MarketplaceTypeId = 1, Name = "Mace Personal Security Pepper Sprays", LookupValue = "79849", Description = "The Mace Personal Security Pepper Sprays category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1912, MarketplaceTypeId = 1, Name = "Personal Security Pepper Spray", LookupValue = "79849", Description = "The Personal Security Pepper Spray category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1913, MarketplaceTypeId = 1, Name = "Personal Security Stun Guns", LookupValue = "79850", Description = "The Personal Security Stun Guns category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1914, MarketplaceTypeId = 1, Name = "Really Weird Stuff", LookupValue = "1468", Description = "The Really Weird Stuff category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1915, MarketplaceTypeId = 1, Name = "Flashlight Personal Security Stun Guns", LookupValue = "79850", Description = "The Flashlight Personal Security Stun Guns category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1916, MarketplaceTypeId = 1, Name = "SABRE Personal Security Pepper Sprays", LookupValue = "79849", Description = "The SABRE Personal Security Pepper Sprays category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1917, MarketplaceTypeId = 1, Name = "Real Estate", LookupValue = "10542", Description = "The Real Estate category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1918, MarketplaceTypeId = 1, Name = "Land", LookupValue = "15841", Description = "The Land category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1919, MarketplaceTypeId = 1, Name = "Manufactured Homes", LookupValue = "94825", Description = "The Manufactured Homes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1920, MarketplaceTypeId = 1, Name = "Timeshares for Sale", LookupValue = "15897", Description = "The Timeshares for Sale category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1921, MarketplaceTypeId = 1, Name = "Residential", LookupValue = "12605", Description = "The Residential category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1922, MarketplaceTypeId = 1, Name = "Commercial", LookupValue = "15825", Description = "The Commercial category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1923, MarketplaceTypeId = 1, Name = "Other Real Estate", LookupValue = "1607", Description = "The Other Real Estate category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

// Popular Topics (deep links)
                new () { Id = 1924, MarketplaceTypeId = 1, Name = "Gold Mining Claim", LookupValue = "15841", Description = "The Gold Mining Claim category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1925, MarketplaceTypeId = 1, Name = "Land Real Estate", LookupValue = "15841", Description = "The Land Real Estate category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1926, MarketplaceTypeId = 1, Name = "Manufactured Homes", LookupValue = "94825", Description = "The Manufactured Homes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1927, MarketplaceTypeId = 1, Name = "Wyndham Property", LookupValue = "15897", Description = "The Wyndham Property category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1928, MarketplaceTypeId = 1, Name = "California Land Real Estate", LookupValue = "15841", Description = "The California Land Real Estate category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1929, MarketplaceTypeId = 1, Name = "1 to 5 acres Acreage Land Real Estate", LookupValue = "15841", Description = "The 1 to 5 acres Acreage Land Real Estate category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1930, MarketplaceTypeId = 1, Name = "Less than 1 Acre Land Real Estate", LookupValue = "15841", Description = "The Less than 1 Acre Land Real Estate category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1931, MarketplaceTypeId = 1, Name = "Residential Existing Homes", LookupValue = "12605", Description = "The Residential Existing Homes category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1932, MarketplaceTypeId = 1, Name = "Florida Timeshares", LookupValue = "15897", Description = "The Florida Timeshares category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1933, MarketplaceTypeId = 1, Name = "Recreational, Acreage Land Real Estate", LookupValue = "15841", Description = "The Recreational, Acreage Land Real Estate category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1934, MarketplaceTypeId = 1, Name = "Gift Cards & Coupons", LookupValue = "172008", Description = "The Gift Cards & Coupons category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1935, MarketplaceTypeId = 1, Name = "Gift Cards", LookupValue = "172009", Description = "The Gift Cards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1936, MarketplaceTypeId = 1, Name = "eBay Gift Cards", LookupValue = "172036", Description = "The eBay Gift Cards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1937, MarketplaceTypeId = 1, Name = "Coupons", LookupValue = "172010", Description = "The Coupons category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1938, MarketplaceTypeId = 1, Name = "Gift Certificates", LookupValue = "31411", Description = "The Gift Certificates category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1939, MarketplaceTypeId = 1, Name = "Digital Gifts", LookupValue = "176950", Description = "The Digital Gifts category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

// Popular Topics (deep links)
                new () { Id = 1940, MarketplaceTypeId = 1, Name = "Gift Cards", LookupValue = "172009", Description = "The Gift Cards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1941, MarketplaceTypeId = 1, Name = "Amazon Gift Cards", LookupValue = "172009", Description = "The Amazon Gift Cards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1942, MarketplaceTypeId = 1, Name = "eBay Gift Cards", LookupValue = "172036", Description = "The eBay Gift Cards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1943, MarketplaceTypeId = 1, Name = "US-Nationwide Gift Cards", LookupValue = "172009", Description = "The US-Nationwide Gift Cards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1944, MarketplaceTypeId = 1, Name = "Home & Garden Coupons", LookupValue = "172010", Description = "The Home & Garden Coupons category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1945, MarketplaceTypeId = 1, Name = "Toys & Games Gift Cards", LookupValue = "172009", Description = "The Toys & Games Gift Cards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1946, MarketplaceTypeId = 1, Name = "Coupons", LookupValue = "172010", Description = "The Coupons category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1947, MarketplaceTypeId = 1, Name = "Travel Gift Cards", LookupValue = "172009", Description = "The Travel Gift Cards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1948, MarketplaceTypeId = 1, Name = "AMC Movie Ticket", LookupValue = "31411", Description = "The AMC Movie Ticket category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1949, MarketplaceTypeId = 1, Name = "The Home Depot Gift Cards", LookupValue = "172009", Description = "The The Home Depot Gift Cards category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1950, MarketplaceTypeId = 1, Name = "Specialty Services", LookupValue = "316", Description = "The Specialty Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1951, MarketplaceTypeId = 1, Name = "eBay Auction Services", LookupValue = "50349", Description = "The eBay Auction Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1952, MarketplaceTypeId = 1, Name = "eBay Listing Services", LookupValue = "50351", Description = "The eBay Listing Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1953, MarketplaceTypeId = 1, Name = "Other eBay Auction Services", LookupValue = "50354", Description = "The Other eBay Auction Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1954, MarketplaceTypeId = 1, Name = "eBay Shopping Assistance Services", LookupValue = "50353", Description = "The eBay Shopping Assistance Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1955, MarketplaceTypeId = 1, Name = "eBay Store Design Services", LookupValue = "152950", Description = "The eBay Store Design Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1956, MarketplaceTypeId = 1, Name = "eBay Packing & Shipping Services", LookupValue = "50352", Description = "The eBay Packing & Shipping Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1957, MarketplaceTypeId = 1, Name = "eBay Auction Appraisal & Authentication Services", LookupValue = "50350", Description = "The eBay Auction Appraisal & Authentication Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1958, MarketplaceTypeId = 1, Name = "Graphic & Logo Design", LookupValue = "47131", Description = "The Graphic & Logo Design category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1959, MarketplaceTypeId = 1, Name = "Web & Computer Services", LookupValue = "47104", Description = "The Web & Computer Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1960, MarketplaceTypeId = 1, Name = "Domain Name Services", LookupValue = "3767", Description = "The Domain Name Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1961, MarketplaceTypeId = 1, Name = "Web Hosting Services", LookupValue = "47106", Description = "The Web Hosting Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1962, MarketplaceTypeId = 1, Name = "Other Web & Computer Services", LookupValue = "45209", Description = "The Other Web & Computer Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1963, MarketplaceTypeId = 1, Name = "Web Design Services", LookupValue = "47105", Description = "The Web Design Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1964, MarketplaceTypeId = 1, Name = "Technical Support Services", LookupValue = "50334", Description = "The Technical Support Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1965, MarketplaceTypeId = 1, Name = "Other Specialty Services", LookupValue = "317", Description = "The Other Specialty Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1966, MarketplaceTypeId = 1, Name = "Printing & Personalization", LookupValue = "20943", Description = "The Printing & Personalization category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1967, MarketplaceTypeId = 1, Name = "Pen & Pencil Personalization Services", LookupValue = "171530", Description = "The Pen & Pencil Personalization Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1968, MarketplaceTypeId = 1, Name = "Business Card Printing Services", LookupValue = "47112", Description = "The Business Card Printing Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1969, MarketplaceTypeId = 1, Name = "Other Printing & Personalization Services", LookupValue = "20947", Description = "The Other Printing & Personalization Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1970, MarketplaceTypeId = 1, Name = "Graphic Address Label Printing Services", LookupValue = "47107", Description = "The Graphic Address Label Printing Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1971, MarketplaceTypeId = 1, Name = "Stationery Printing Services", LookupValue = "47118", Description = "The Stationery Printing Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1972, MarketplaceTypeId = 1, Name = "Sign Printing Services", LookupValue = "20946", Description = "The Sign Printing Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1973, MarketplaceTypeId = 1, Name = "Restoration & Repair", LookupValue = "47119", Description = "The Restoration & Repair category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1974, MarketplaceTypeId = 1, Name = "Jewelry & Watch Restoration & Repair Services", LookupValue = "47122", Description = "The Jewelry & Watch Restoration & Repair Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1975, MarketplaceTypeId = 1, Name = "Other Restoration & Repair Services", LookupValue = "45210", Description = "The Other Restoration & Repair Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1976, MarketplaceTypeId = 1, Name = "Computer Restoration & Repair Services", LookupValue = "50422", Description = "The Computer Restoration & Repair Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1977, MarketplaceTypeId = 1, Name = "Car & Other Vehicle Restoration & Repair Services", LookupValue = "47121", Description = "The Car & Other Vehicle Restoration & Repair Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1978, MarketplaceTypeId = 1, Name = "Musical Instrument Restoration & Repair Services", LookupValue = "47125", Description = "The Musical Instrument Restoration & Repair Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1979, MarketplaceTypeId = 1, Name = "Electronics Restoration & Repair Services", LookupValue = "47123", Description = "The Electronics Restoration & Repair Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1980, MarketplaceTypeId = 1, Name = "Artistic Services", LookupValue = "47126", Description = "The Artistic Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1981, MarketplaceTypeId = 1, Name = "Photography Services", LookupValue = "165993", Description = "The Photography Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1982, MarketplaceTypeId = 1, Name = "Music Composition & Poetry Services", LookupValue = "47128", Description = "The Music Composition & Poetry Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1983, MarketplaceTypeId = 1, Name = "Interior Design Services", LookupValue = "50342", Description = "The Interior Design Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1984, MarketplaceTypeId = 1, Name = "Painting & Drawing Services", LookupValue = "47129", Description = "The Painting & Drawing Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1985, MarketplaceTypeId = 1, Name = "Other Artistic Services", LookupValue = "45208", Description = "The Other Artistic Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1986, MarketplaceTypeId = 1, Name = "Custom Craft Services", LookupValue = "47127", Description = "The Custom Craft Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1987, MarketplaceTypeId = 1, Name = "Home Improvement Services", LookupValue = "170048", Description = "The Home Improvement Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1988, MarketplaceTypeId = 1, Name = "Landscaping Services", LookupValue = "170055", Description = "The Landscaping Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1989, MarketplaceTypeId = 1, Name = "Home Flooring Improvement Services", LookupValue = "170052", Description = "The Home Flooring Improvement Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1990, MarketplaceTypeId = 1, Name = "Home Window Services", LookupValue = "170059", Description = "The Home Window Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1991, MarketplaceTypeId = 1, Name = "Deck & Porch Improvement Services", LookupValue = "170050", Description = "The Deck & Porch Improvement Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1992, MarketplaceTypeId = 1, Name = "Other Home Improvement Services", LookupValue = "170060", Description = "The Other Home Improvement Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1993, MarketplaceTypeId = 1, Name = "Home Plumbing Services", LookupValue = "170057", Description = "The Home Plumbing Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 1994, MarketplaceTypeId = 1, Name = "Custom Clothing & Jewelry", LookupValue = "50343", Description = "The Custom Clothing & Jewelry category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1995, MarketplaceTypeId = 1, Name = "Custom Jewelry Services", LookupValue = "50346", Description = "The Custom Jewelry Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1996, MarketplaceTypeId = 1, Name = "Custom Costume Services", LookupValue = "50344", Description = "The Custom Costume Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1997, MarketplaceTypeId = 1, Name = "Custom Hat, Handbag & Accessory Services", LookupValue = "50345", Description = "The Custom Hat, Handbag & Accessory Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1998, MarketplaceTypeId = 1, Name = "Other Custom Clothing & Jewelry Services", LookupValue = "47130", Description = "The Other Custom Clothing & Jewelry Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 1999, MarketplaceTypeId = 1, Name = "Custom Shirt Services", LookupValue = "50347", Description = "The Custom Shirt Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 2000, MarketplaceTypeId = 1, Name = "Custom Baby Clothing Services", LookupValue = "50348", Description = "The Custom Baby Clothing Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 2001, MarketplaceTypeId = 1, Name = "Item Based Services", LookupValue = "175814", Description = "The Item Based Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 2002, MarketplaceTypeId = 1, Name = "Warranty & Insurance Services", LookupValue = "175815", Description = "The Warranty & Insurance Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 2003, MarketplaceTypeId = 1, Name = "Installation & Support Services", LookupValue = "175816", Description = "The Installation & Support Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 2004, MarketplaceTypeId = 1, Name = "Other Item Based Services", LookupValue = "175818", Description = "The Other Item Based Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 2005, MarketplaceTypeId = 1, Name = "Credit Services", LookupValue = "175817", Description = "The Credit Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

                new () { Id = 2006, MarketplaceTypeId = 1, Name = "Media Editing & Duplication", LookupValue = "50355", Description = "The Media Editing & Duplication category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 2007, MarketplaceTypeId = 1, Name = "Music Editing & Duplication Services", LookupValue = "50356", Description = "The Music Editing & Duplication Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 2008, MarketplaceTypeId = 1, Name = "Photo & Video Editing & Duplication Services", LookupValue = "50357", Description = "The Photo & Video Editing & Duplication Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 2009, MarketplaceTypeId = 1, Name = "Other Media Editing & Duplication Services", LookupValue = "50358", Description = "The Other Media Editing & Duplication Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },

// Popular Topics (deep links)
                new () { Id = 2010, MarketplaceTypeId = 1, Name = "eBay Auction Services", LookupValue = "50349", Description = "The eBay Auction Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 2011, MarketplaceTypeId = 1, Name = "Graphic & Logo Design Services", LookupValue = "47131", Description = "The Graphic & Logo Design Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 2012, MarketplaceTypeId = 1, Name = "Domain Name Domain Name Services", LookupValue = "3767", Description = "The Domain Name Domain Name Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 2013, MarketplaceTypeId = 1, Name = "Web Hosting Services", LookupValue = "47106", Description = "The Web Hosting Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 2014, MarketplaceTypeId = 1, Name = "4 Letter Domain Name", LookupValue = "3767", Description = "The 4 Letter Domain Name category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 2015, MarketplaceTypeId = 1, Name = "Unlock Service", LookupValue = "317", Description = "The Unlock Service category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 2016, MarketplaceTypeId = 1, Name = "Domain Name Services", LookupValue = "3767", Description = "The Domain Name Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 2017, MarketplaceTypeId = 1, Name = "Pen & Pencil Personalization Services", LookupValue = "171530", Description = "The Pen & Pencil Personalization Services category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 2018, MarketplaceTypeId = 1, Name = "iPhone iCloud Removal Service", LookupValue = "317", Description = "The iPhone iCloud Removal Service category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
                new () { Id = 2019, MarketplaceTypeId = 1, Name = "Instagram Follower Service", LookupValue = "45209", Description = "The Instagram Follower Service category type.", CreatedBy = SYSTEM, UpdatedBy = SYSTEM },
            });
        }

        /// <summary>
        /// Seeds the location types.
        /// </summary>
        /// <param name="builder">The model builder.</param>
        private static void SeedLocationTypes(ModelBuilder builder)
        {
            builder.Entity<LocationType>().HasData(new List<LocationType>()
            {
                new ()
                {
                    Id = 1,
                    MarketplaceTypeId = 1,
                    Name = "USA",
                    LookupValue = "USA",
                    Description = "The USA location type.",
                    CreatedBy = SYSTEM,
                    UpdatedBy = SYSTEM,
                },
            });
        }
    }
}
