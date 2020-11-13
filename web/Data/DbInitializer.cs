using web.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(FlatmatesContext context)
        {
            context.Database.EnsureCreated();

             if (context.Chores.Any())
            {
                return;   // DB has been seeded
            }

            var users = new ApplicationUser[]
            {
                new ApplicationUser{Id="1", FirstName="Frodo",LastName="Baggins", Email="frodo@fellowship.com", PhoneNumber="070070070"},
                new ApplicationUser{Id="2", FirstName="Samwise",LastName="Gamgee", Email="sam@fellowship.com", PhoneNumber="060060060"},
                new ApplicationUser{Id="3",FirstName="Merry",LastName="Brandybuck", Email="merry@fellowship.com", PhoneNumber="050050050"},
                new ApplicationUser{Id="4",FirstName="Harry",LastName="Potter", Email="harry@da.com", PhoneNumber="040040040"},
                new ApplicationUser{Id="5",FirstName="Ron",LastName="Weasley", Email="ron@da.com", PhoneNumber="030030030"},
                new ApplicationUser{Id="6",FirstName="Hermione",LastName="Granger", Email="hermione@da.com", PhoneNumber="020020020"}
            };
            foreach (ApplicationUser s in users)
            {
                 if (!context.Users.Any(u => u.UserName == s.UserName))
                {
                    var password = new PasswordHasher<ApplicationUser>();
                    var hashed = password.HashPassword(s,"Testni123!");
                    s.PasswordHash = hashed;
                    context.Users.Add(s);
                    context.SaveChanges();
                    
                }

                context.Users.Add(s);
            }
            context.SaveChanges();  

            var bills = new Bill[]
            {
                new Bill{billID=1,content="Ring, 250, 1. Second breakfast, 10, 2. Sword, 25, 1.",cost=295, paid=false, householdID=1, userID=1},
                new Bill{billID=2,content="Potatoes, 5, 4. Smeagol, 20, 1.",cost=40, paid=true, householdID=1, userID=2},
                new Bill{billID=3,content="Wand, 40, 1. Book, 10, 1.",cost=50, paid=true, householdID=2, userID=6},
                new Bill{billID=4,content="Chocolate frogs, 2, 10. Peppermint toads, 3, 5. Bertie Bott's beans, 4, 5",cost=55, paid=false, householdID=2, userID=5}                
               
                
            };
            foreach (Bill s in bills)
            {
                context.Bills.Add(s);
            }
            context.SaveChanges();

            var chores = new Chore[]
            {
                new Chore{choreID=1, householdID=1, userID=1, choredesc="Destsroy Ring", duration="1 months", repetition="no", finished=true},
                new Chore{choreID=2, householdID=1, userID=2, choredesc="Cook potato stew", duration="1 hour", repetition="daily", finished=false},
                new Chore{choreID=3, householdID=2, userID=4, choredesc="Destroy Voldemort", duration="7 years", repetition="no", finished=true},
                new Chore{choreID=4, householdID=2, userID=6, choredesc="Attend all classes", duration="1 year", repetition="daily", finished=false}
                
            };
            foreach (Chore s in chores)
            {
                context.Chores.Add(s);
            }
            context.SaveChanges();

            var comms = new ForumComment[]
            {
                new ForumComment{commentID=1, postID=1, userID=2, content="PO-TAY-TOES!!!", timestamp=GetTimestamp(DateTime.Now)},
                new ForumComment{commentID=2, postID=1, userID=2, content="Boil 'em, mash 'em, stick 'em in a stew", timestamp=GetTimestamp(DateTime.Now)},
                new ForumComment{commentID=3, postID=2, userID=2, content="Say what?", timestamp=GetTimestamp(DateTime.Now)},
                new ForumComment{commentID=4, postID=2, userID=3, content="Found it! I vacuumed it by accident...", timestamp=GetTimestamp(DateTime.Now)},
                new ForumComment{commentID=5, postID=3, userID=6, content="Ron, just go to sleep already!!!", timestamp=GetTimestamp(DateTime.Now)},
                new ForumComment{commentID=6, postID=4, userID=5, content="Six and a half books!", timestamp=GetTimestamp(DateTime.Now)}
                
            };
            foreach (ForumComment s in comms)
            {
                context.Forum_Comments.Add(s);
            }
            context.SaveChanges();

             var post = new ForumPost[]
            {
                new ForumPost{postID=1, userID=3,householdID=1, content="What's for second breakfast?", timestamp=GetTimestamp(DateTime.Now)},
                new ForumPost{postID=2, userID=1,householdID=1, content="Has anyone seen my ring?", timestamp=GetTimestamp(DateTime.Now)},
                new ForumPost{postID=3, userID=5,householdID=2, content="Has anyone noticed how the Deathly Hallows symbol looks like a nose? Maybe that's why V-dog is after them?", timestamp=GetTimestamp(DateTime.Now)},
                new ForumPost{postID=4, userID=4,householdID=2, content="How long does an owl live? (Asking for a friend)", timestamp=GetTimestamp(DateTime.Now)}
                
                
            };
            foreach (ForumComment s in comms)
            {
                context.Forum_Comments.Add(s);
            }
            context.SaveChanges();

            var houses = new Household[]
            {
                new Household{householdID=1, address="Bag End", code="myPrecious", description="Cozy lil place with even liller ppl"},
                new Household{householdID=2, address="Hogwarts", code="ridARiddle", description="Where magic happens"} 
                
            };
            foreach (Household s in houses)
            {
                context.Households.Add(s);
            }
            context.SaveChanges();


            var invs = new Inventory[]
            {
                new Inventory{itemID=1, householdID=1, categoryName="Jewelry", itemName="Ring", essential=true},
                new Inventory{itemID=2, householdID=1, categoryName="Food", itemName="Potatoes", essential=false},
                new Inventory{itemID=3, householdID=2, categoryName="Food", itemName="Owl food", essential=false},
                new Inventory{itemID=4, householdID=2, categoryName="Equipment", itemName="Wand", essential=true}
                
            };
            foreach (Inventory s in invs)
            {
                context.Inventory.Add(s);
            }
            context.SaveChanges();


            var rents = new Rent[]
            {
                new Rent{rentID=1, month="April", paid=true, amount=500, householdID=1},
                new Rent{rentID=2, month="May", paid=false, amount=495, householdID=1},
                new Rent{rentID=3, month="April", paid=true, amount=600, householdID=2},
                new Rent{rentID=4, month="May", paid=true, amount=550, householdID=2}
                
            };
            foreach (Rent s in rents)
            {
                context.Rent.Add(s);
            }
            context.SaveChanges();


            var stros = new Stroski[]
            {
                new Stroski{strosekID=1, month="April", householdID=1, amount=100, paid=true, description="Heating"},
                new Stroski{strosekID=2, month="May", householdID=1, amount=50, paid=false, description="Water"},
                new Stroski{strosekID=3, month="April", householdID=2, amount=150, paid=true, description="Cleaning"},
                new Stroski{strosekID=4, month="May", householdID=2, amount=100, paid=false, description="Internet"}
                
            };
            foreach (Stroski s in stros)
            {
                context.Stroski.Add(s);
            }
            context.SaveChanges();

            var tents = new Tenant[]
            {
                new Tenant{tenantID=1, userID=1, householdID=1, role="Admin"},
                new Tenant{tenantID=2, userID=2, householdID=1, role="Cook"},
                new Tenant{tenantID=3, userID=3, householdID=1, role="Parasite"},
                new Tenant{tenantID=4, userID=4, householdID=2, role="Celebrity"},
                new Tenant{tenantID=5, userID=5, householdID=2, role="Sidekick"},
                new Tenant{tenantID=6, userID=6, householdID=2, role="Admin"}
            };
            foreach (Tenant s in tents)
            {
                context.Tenants.Add(s);
            }
            context.SaveChanges();





            


            
            context.SaveChanges();
        }

        private static DateTime GetTimestamp(DateTime now)
        {
            throw new NotImplementedException();
        }
    }
}