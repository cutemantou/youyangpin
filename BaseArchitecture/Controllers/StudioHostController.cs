﻿using Microsoft.AspNetCore.Mvc;
using YYP.ComLib;
using Infrastructure.Helper;
using YYP.Entities;
using YYP.Services;

namespace WebAPI.Controllers
{
    //主播用户管理
    [Route("api/[controller]/[action]")]
    public class StudioHostController : Controller
    {
        private readonly IUserService _userService;

        public StudioHostController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public UserServiceResult Register(string telphone, string pwd)
        {
            var user = new User() {Account = telphone, TelPhone = telphone, Pwd = pwd, UserType = UserType.StudioHost};
            return _userService.Register(user);
        }
    }
}
