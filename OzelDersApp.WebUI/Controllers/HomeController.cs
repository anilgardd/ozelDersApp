using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OzelDersApp.Business.Abstract;
using OzelDersApp.Entity.Concrete;
using OzelDersApp.Entity.Concrete.Identity;
using OzelDersApp.WebUI.Models;
using OzelDersApp.WebUI.Models.ViewModels;
using OzelDersApp.WebUI.Models.ViewModels.AdvertModels;
using System.Diagnostics;
using System.Net;

namespace OzelDersApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ITeacherService _teacherService;
        private IBranchService _branchService;
        private IAdvertService _advertService;

        public HomeController(ITeacherService teacherService, IBranchService branchService, IAdvertService advertService)
        {
            _teacherService = teacherService;
            _branchService = branchService;
            _advertService = advertService;
        }

        public IActionResult Index()
        {
           

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAdverts(AdvertListViewModel advertListViewModel)
        {
            List<Advert> advertList;
            if (advertListViewModel.Adverts == null)
            {
                advertList = await _advertService.GetAllAdvertsAsync(advertListViewModel.ApprovedStatus);
                List<AdvertViewModel> adverts = new List<AdvertViewModel>();
                foreach (var advert in advertList)
                {
                    adverts.Add(new AdvertViewModel
                    {
                        Id = advert.Id,
                        FirstName = advert.Teacher.User.FirstName,
                        LastName = advert.Teacher.User.LastName,
                        CreatedDate = advert.CreatedDate,
                        UpdatedDate = advert.UpdatedDate,
                        IsApproved = advert.IsApproved,
                        Graduation = advert.Teacher.Graduation,
                        Price = advert.Price,
                        Description = advert.Description,
                        Url = advert.Url,
                        Image = advert.Teacher.User.Image,
                        BranchName=advert.Branch.BranchName
                        //Branches=advert.Teacher.TeacherBranches.Select(tb=>tb.Branch).ToList()
                        //Teacher=advert.Teacher
                    });
                }
                advertListViewModel.Adverts = adverts;
            }
            return View(advertListViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AdvertDetails(string url)
        {
            var advertId = await _advertService.GetByUrlAsync(url);
            Advert advert = await _advertService.GetAdvertFullDataAsync(advertId);
            AdvertViewModel advertViewModel = new AdvertViewModel()
            {
                Id= advert.Id,
                FirstName=advert.Teacher.User.FirstName,
                LastName=advert.Teacher.User.LastName,
                Graduation=advert.Teacher.Graduation,
                Image = advert.Teacher.User.Image,
                Description=advert.Description,
                Price=advert.Price,
                UpdatedDate=advert.UpdatedDate,
                CreatedDate = advert.CreatedDate,
                IsApproved = advert.IsApproved,
                BranchName = advert.Branch.BranchName,
                Url =advert.Url,
            };
            return View(advertViewModel);
        }

        


    }
}