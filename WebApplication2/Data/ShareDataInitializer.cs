using Microsoft.AspNetCore.Identity;
using ShareApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ShareApi.Data
{
    public class ShareDataInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ShareContext _dbContext;


        public ShareDataInitializer(ShareContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;

        }

        public async Task InitializeData()
        {
             // _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {

                //  List<Share> shares = new List<Share>();

                User zowie = new User { FirstName = "Zowie", LastName = "Verschuere", Email = "Zowie.verschuere@gmail.com" };
                _dbContext.Customers.Add(zowie);
                await CreateUser(zowie.Email, "Z@wie123");
                User jari = new User { FirstName = "Jari", LastName = "Vdc", Email = "Jari.vdc@gmail.com" };
                _dbContext.Customers.Add(jari);
                await CreateUser(jari.Email, "J@ri12345");
                _dbContext.SaveChanges();

                jari.Shares = new List<Share>();
                zowie.Shares = new List<Share>();

                Share tesla = new Share { Name = "Tesla", StockName = "TSLA", BuyPrice = 700, Discription = "Tesla is in 2003 opgericht door een groep ingenieurs die wilden bewijzen dat er geen concessies hoeven te worden gedaan om elektrisch te rijden – dat elektrische voertuigen zelfs beter, sneller en leuker kunnen zijn dan benzineauto's. Tegenwoordig bouwt Tesla niet alleen volledig elektrische voertuigen, maar ook onbeperkt schaalbare producten voor de opwekking en opslag van schone energie." };
         //       _dbContext.Shares.Add(tesla);
                jari.Shares.Add(tesla);
                Share nio = new Share {  Name = "Nio", StockName = "NIO", BuyPrice = 43 };
          //      _dbContext.Shares.Add(nio);
                zowie.Shares.Add(nio);
                Share gamestop = new Share { Name = "GameStop", StockName = "GME", BuyPrice = 161 };
         //      _dbContext.Shares.Add(gamestop);
                zowie.Shares.Add(gamestop);
                Share apple = new Share {  Name = "Apple", StockName = "AAPL", BuyPrice = 146 };
         //       _dbContext.Shares.Add(apple);
                zowie.Shares.Add(apple);
                Share shell = new Share {  Name = "Shell", StockName = "RDSA", BuyPrice = 18 };
         //       _dbContext.Shares.Add(shell);
                zowie.Shares.Add(shell);
                _dbContext.SaveChanges();

                /* shares.Add(tesla);
                     shares.Add(nio);
                     shares.Add(gamestop);
                     shares.Add(apple);
                     shares.Add(shell);




                 zowie.Shares = shares;*/



            }
        }

        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}
