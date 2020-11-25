using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectForDotNet.Models
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            roleManager.Create(role1);
            roleManager.Create(role2);

            var admin = new ApplicationUser { Email = "somemail@mail.ru", UserName = "somemail@mail.ru" };
            string password = "ad46D_ewr3";
            var result = userManager.Create(admin, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }

            //Types: Air, Land, Water, etc.

            context.Types.Add(new Type() { TypeId = 1, Name = "Air", Description = "Air transport is an important enabler to achieving economic growth and development. Air transport facilitates integration into the global economy and provides vital connectivity on a national, regional, and international scale. It helps generate trade, promote tourism, and create employment opportunities. The World Bank has financed aviation-related projects for over sixty years. Today, the WBG remains actively engaged in every region on projects related to air transport policy and regulation, safety, infrastructure rehabilitation, institutional strengthening, and capacity building." });

            context.Types.Add(new Type() { TypeId = 2, Name = "Land", Description = "Land transport – transport or movement of people, animals, and goods from one location to another on land, usually by railway or road." });

            context.Types.Add(new Type() { TypeId = 3, Name = "Water", Description = "Water transport is the process of moving people, goods, etc. by barge, boat, ship or sailboat over a sea, ocean, lake, canal, river, etc. This category does not include articles on the transport of water for the purpose of consuming the water." });

            //Categories: Air: helicopter, airplane, etc.; Land: car, truck, etc.; Water: ship, boat, etc.

            context.Categories.Add(new Category { CategoryId = 1, Name = "Helicopter", TypeId = 1, Description = "A helicopter is a vertical take-off and landing rotorcraft, in which the lifting and driving forces at all stages of flight are created by one or more main rotors driven by one or several engines." });

            context.Categories.Add(new Category { CategoryId = 2, Name = "Airplane", TypeId = 1, Description = "An airplane or aeroplane (informally plane) is a powered, fixed-wing aircraft that is propelled forward by thrust from a jet engine, propeller or rocket engine." });

            context.Categories.Add(new Category { CategoryId = 3, Name = "Automobile", TypeId = 2, Description = "A car (or automobile) is a wheeled motor vehicle used for transportation. Most definitions of cars say that they run primarily on roads, seat one to eight people, have four tires, and mainly transport people rather than goods." });

            context.Categories.Add(new Category { CategoryId = 4, Name = "Train", TypeId = 2, Description = "A train is a form of rail transport consisting of a series of connected vehicles that generally run along a railroad (or railway) track to transport passengers or cargo (also known as 'freight' or 'goods'). The word 'train' comes from the Old French trahiner, derived from the Latin trahere meaning 'to pull' or 'to draw'." });

            context.Categories.Add(new Category { CategoryId = 5, Name = "Ship", TypeId = 3, Description = "A ship is a large watercraft that travels the world's oceans and other sufficiently deep waterways, carrying goods or passengers, or in support of specialized missions, such as defense, research, and fishing. Ships are generally distinguished from boats, based on size, shape, load capacity, and tradition. In the Age of Sail a 'ship' was a sailing vessel defined by its sail plan of at least three square riged masts and a full bowsprit." });

            context.Categories.Add(new Category { CategoryId = 6, Name = "Boat", TypeId = 3, Description = "A boat is a watercraft of a large range of types and sizes, but generally smaller than a ship, which is distinguished by its larger size, shape, cargo or passenger capacity, or its ability to carry boats." });

            //Transport - transport itself

            context.Transports.Add(new Transport() { Name = "EC-135", Price = 174000000, Producer = "Eurocopter", Weight = 2800, Capacity = 145, MaxSpeed = 259, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/8d/EC135Bundespolizei.jpg", CategoryId = 1, Description = "The Eurocopter EC 135 (currently Airbus Helicopters H135) is a multipurpose light helicopter. The development of the helicopter has been carried out since the late 1980s by the consortium Eurocopter(now Airbus Helicopters).On October 15, 1988, technological prototype # D-HBOX made its first flight, powered by a pair of Rolls-Royce 250-C20R engines. On February 15 and 16, 1994, pre-production helicopters No. D-HECX and No. D-HECY with Turbomeca Arrius 2B and Pratt & Whitney Canada PW206B engines, respectively, made their first flight." });

            context.Transports.Add(new Transport() { Name = "650Е", Price = 675000000, Producer = "Embraer Legacy ", Weight = 6500, Capacity = 750, MaxSpeed = 834, ImageUrl = "https://jetvip.ru/upload/shop_5/2/4/2/item_242/shop_property_file_242_2442.jpg", CategoryId = 2, Description = "Embraer EMB-135BJ Legacy 650 is a business-class aircraft of increased comfort. It has several berths on board, which allows passengers to comfortably make long flights, and is equipped with satellite telefax. The quality of the service provided meets all international standards. Manufactured by the Brazilian aircraft manufacturer Embraer." });

            context.Transports.Add(new Transport() { Name = "Duster", Price = 7000000, Producer = "Renault", Weight = 1890, Capacity = 50, MaxSpeed = 180, ImageUrl = "https://cdnimg.rg.ru/img/content/170/77/62/renault_duster_366_d_850.jpeg", CategoryId = 3, Description = "The Renault Duster is a compact crossover developed at the Renault tech center in Guiancourt. First introduced on December 8, 2009 under the Dacia subsidiary for the European markets. Later, versions under the Renault brand were presented, produced in Russia, Brazil, India and Colombia." });

            context.Transports.Add(new Transport() { Name = "N700 Series", Price = 450000000, Producer = "Shinkansen", Weight = 71500, Capacity = 515, MaxSpeed = 300, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/30/N700_Z0_7881A_Hamamatsu_20060128.jpg/450px-N700_Z0_7881A_Hamamatsu_20060128.jpg", CategoryId = 4, Description = "The Shinkansen N700 series electric train is a high-speed Japanese electric train developed jointly by JR Central and JR West for use on the Tokaido and Sanyo lines. Tests of the prototype train began on March 10, 2005. Commissioned on July 1, 2007." });

            context.Transports.Add(new Transport() { Name = "Scarlet Lady", Price = 815000000, Producer = "Virgin Voyages", Weight = 110000, Capacity = 2770, MaxSpeed = 41, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/02/Scarlet_Lady_in_Liverpool_February_2020_%28cropped%29.jpg/450px-Scarlet_Lady_in_Liverpool_February_2020_%28cropped%29.jpg", CategoryId = 5, Description = "Scarlet Lady is a cruise ship operated by Virgin Voyages. She is the inaugural ship for the cruise line and was delivered on 14 February 2020 by Fincantieri of Italy.She is set to debut on 16 October 2020. She will operate exclusively as an 'adults - only' ship for guests aged 18 and over, sailing mainly four-to-five-night Caribbean itineraries from Miami, Florida." });

            context.Transports.Add(new Transport() { Name = "PB52", Price = 22000000, Producer = "Palm Beach Motor Yachts", Weight = 17000, Capacity = 120, MaxSpeed = 65, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuZ8tTRpQjRRouBKA-5szXWWNIFQWP6rDutA&usqp=CAU", CategoryId = 6, Description = "The Palm Beach 52 turns heads in a crowded field of run-of-the-mill yachts. A sleek, contemporary, high-performance vessel, the PB52 boasts an unmatched ride, incredible seaworthiness and meticulous joinery work. Sporty, aggressive power will take you as far as your heart desires, and unique safety features, such as our recessed walk-arounds that provide easy access to the foredecks, ensure you ride in comfort. Inside, the PB52 dazzles as well, with custom upholstery, solid teak cabinetry and an extended teak swim platform. Amenities line the yacht, including an induction cooktop, Fusion Apollo stereo system with Bose® Acoustimass in the salon." });

            base.Seed(context);
        }
    }
}