using GenericRepo.Models;
using GR.Data;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepo.Controllers
{
    public class AuthorController : Controller
    {
        private IRepository<Author> repoAuthor;
        private IRepository<Book> repoBook;
        public AuthorController(IRepository<Author> _repoAuthor, IRepository<Book> _repoBook)
        {
            this.repoAuthor = _repoAuthor;
            this.repoBook = _repoBook;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<AuthorListingViewModel> model = new List<AuthorListingViewModel>();
            repoAuthor.GetAll().ToList().ForEach(a => {
                AuthorListingViewModel author = new AuthorListingViewModel
                {
                    Id = a.Id,
                    Name = a.FirstName + a.LastName,
                    Email = a.Email,
                };
                author.TotalBooks = repoBook.GetAll().Count(x => x.AuthorId == a.Id);
                model.Add(author);
            });
            return View();
        }
    }
}
