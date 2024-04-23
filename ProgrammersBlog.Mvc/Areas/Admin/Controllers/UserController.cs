﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ProgrammersBlog.Mvc.Areas.Admin.Models;
using ProgrammersBlog.Entities.Dtos.UserDto;
using System.Text.Json.Serialization;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public UserController(UserManager<User> userManager, IWebHostEnvironment env, IMapper mapper)
        {
            _userManager = userManager;
            _env = env;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(new UserListDto
            {
                Users = users,
                ResultStatus = ResultStatus.Success
            });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var usersListDto = JsonSerializer.Serialize(new UserListDto
            {
                Users = users,
                ResultStatus = ResultStatus.Success
            },
            new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve 
            });
            return Json(usersListDto);
              
        }

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_UserAddPartial");
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            userAddDto.Picture = await ImageUpload(userAddDto);
          

            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(userAddDto);
                var result = await _userManager.CreateAsync(user, userAddDto.Password);
                if (result.Succeeded)
                {
                    var userAddAjaxModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
                    {
                        UserDto = new UserDto
                        {
                            ResultStatus = ResultStatus.Success,
                            Message = $"{user.UserName} adlı kullanıcı adına sahip, kullanıcı başarıyla eklenmiştir.",
                            User = user
                        },
                        UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
                    });
                    return Json(userAddAjaxModel);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    var userAddAjaxErrorModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
                    {
                        UserAddDto = userAddDto,
                        UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
                    });
                    return Json(userAddAjaxErrorModel);
                }

            }
            var userAddAjaxModelStateErrorModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
            {
                UserAddDto = userAddDto,
                UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
            });
            return Json(userAddAjaxModelStateErrorModel);

        }

        public async Task<JsonResult> Delete(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                var deletedUser = JsonSerializer.Serialize(new UserDto
                {
                    ResultStatus = ResultStatus.Success,
                    Message = $"{user.UserName} adlı kullanıcı adına sahip kullanıcı başarıyla silinmiştir.",
                    User = user
                });
                return Json(deletedUser);
            }
            else
            {
                string errorMessages = String.Empty;
                foreach (var error in result.Errors)
                {
                    errorMessages = $"*{error.Description}\n";
                }

                var deletedUserErrorModel = JsonSerializer.Serialize(new UserDto
                {
                    ResultStatus = ResultStatus.Error,
                    Message =
                        $"{user.UserName} adlı kullanıcı adına sahip kullanıcı silinirken bazı hatalar oluştu.\n{errorMessages}",
                    User = user
                });
                return Json(deletedUserErrorModel);
            }
        }


        [HttpGet]
        public async Task<PartialViewResult> Update(int userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var userUpdateDto = _mapper.Map<UserUpdateDto>(user);
            return PartialView("_UserUpdatePartial", userUpdateDto);
        }
        public async Task<string> ImageUpload(UserAddDto userAddDto)
        {
            string wwwroot = _env.WebRootPath;
            if (userAddDto.PictureFile == null)
            {

                userAddDto.Picture = "efebcb8d-ace4-4a2e-b4e4-48dfe1b2bf56.png";
                return userAddDto.Picture;
            }
            else
            {
                // string fileName2 = Path.GetFileNameWithoutExtension(userAddDto.PictureFile.FileName);
                //.png
                string fileExtension = Path.GetExtension(userAddDto.PictureFile.FileName);
                DateTime dateTime = DateTime.Now;
                // kullanici_587_5_38_12_3_10_2020.png
                string fileName = $"{userAddDto.UserName}_{dateTime.FullDateAndTimeStringWithUnderscore()}{fileExtension}";
                var path = Path.Combine($"{wwwroot}/img", fileName);
                await using (var stream = new FileStream(path, FileMode.Create))
                {
                    await userAddDto.PictureFile.CopyToAsync(stream);
                }

                return fileName; // Kullanici_587_5_38_12_3_10_2020.png - "~/img/user.Picture"
            }
            //  Kullanici     

        }
    }
}
