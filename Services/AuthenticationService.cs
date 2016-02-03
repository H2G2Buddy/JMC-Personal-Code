using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{

    public class AuthenticatedUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }

    public class AuthenticationService
    {
        public AuthenticatedUser Authenticate(string userName, string password)
        {
            Thread.Sleep(5000);
            return userName.GetAllUsers().Where(q => q.UserName == userName).FirstOrDefault();
        }
        public Task<AuthenticatedUser> AuthenticateAsync(string userName, string password)
        {
            Task<AuthenticatedUser> t = Task.Factory.StartNew<AuthenticatedUser>(() =>
            {
                Thread.Sleep(5000);
                return userName.GetAllUsers().AsParallel().Where(q => q.UserName == userName).FirstOrDefault();
            });

            return t;
            
        }
    }

    public static class AuthenticationHelper
    {
        public static IQueryable<AuthenticatedUser> GetAllUsers(this string name)
        {
            return new List<AuthenticatedUser>(){
                new AuthenticatedUser(){UserName="john",FirstName="John",LastName="Cullen",Token="a4c48f65-138e-4ba6-a63c-ca025e620eca"},
                new AuthenticatedUser(){UserName="",FirstName="Karri",LastName="Olsson",Token="1eef7fda-c0b9-4117-a2f7-b99dc073dcaf"},
                new AuthenticatedUser(){UserName="",FirstName="Violette",LastName="Whiteside",Token="c8bbe699-5dec-48d4-a86f-1cbd36d85bf7"},
                new AuthenticatedUser(){UserName="",FirstName="Waylon",LastName="Vogl",Token="5eb2d0bb-8104-4a2f-8f1e-d75236f86a80"},
                new AuthenticatedUser(){UserName="",FirstName="Jadwiga",LastName="Hartline",Token="fe32be0e-2910-43fb-8126-b78d8f27acc7"},
                new AuthenticatedUser(){UserName="",FirstName="Stefanie",LastName="Ohm",Token="cee869c6-a1b7-4a88-9c09-04a626d20b9b"},
                new AuthenticatedUser(){UserName="",FirstName="Trula",LastName="Fleetwood",Token="c93e3478-3a6d-4b4b-843b-1d1d8170caf7"},
                new AuthenticatedUser(){UserName="",FirstName="Aleshia",LastName="Walts",Token="53cc0a8c-2c29-4572-aea5-9f746f62e41d"},
                new AuthenticatedUser(){UserName="",FirstName="Jani",LastName="Hitchens",Token="86bb7449-e4ed-4725-a151-cb5487642b9b"},
                new AuthenticatedUser(){UserName="",FirstName="Jonathon",LastName="Wolcott",Token="5354c47d-2417-4493-8e2b-e341c26222c7"},
                new AuthenticatedUser(){UserName="",FirstName="Rosalia",LastName="Granville",Token="26c92991-a226-49f1-8953-b3b86762a5bb"}
            }.AsQueryable();
        }
    }
}
