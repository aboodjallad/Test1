using BookShare.Models;
using Firebase.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShare.Services
{

    public interface IOperations
    {
        Task<List<Post>> GetAllPosts();
    }
    public class BookShareDB : IOperations
    {
        FirebaseClient firebase = new FirebaseClient("https://bookshare-898ba-default-rtdb.europe-west1.firebasedatabase.app/");
        public async Task<List<Post>> GetAllPosts()
        {
            var posts = await firebase.Child("Persons").OnceAsync<Post>();
            return posts.Select(item => new Post
            {
                BookName = item.Object.BookName,
                UserName = item.Object.UserName,
                Details = item.Object.Details,
                ContactLink = item.Object.ContactLink,
                ID = item.Object.ID,
                Status = item.Object.Status
            }).ToList();
        }
    }
}