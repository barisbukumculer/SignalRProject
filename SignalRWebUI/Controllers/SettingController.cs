﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto userEditDto=new UserEditDto();
            userEditDto.Surname=value.Surname;
            userEditDto.Username = value.UserName;
            userEditDto.Mail = value.Email;
            userEditDto.Name = value.Name;
            return View(userEditDto);
        }
        [HttpPost]
        public async Task< IActionResult> Index(UserEditDto userEditDto)
        {
           if(userEditDto.Password==userEditDto.ConfirmPassword) 
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Surname = userEditDto.Surname;
                user.Email = userEditDto.Mail;
                user.Name = userEditDto.Name;
                user.UserName = userEditDto.Username;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDto.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index","Category");
            }
            return View(userEditDto);
        }
    }
}
