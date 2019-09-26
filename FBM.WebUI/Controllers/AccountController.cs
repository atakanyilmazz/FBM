using FBM.Data.API;
using FBM.Data.DTO;
using FBM.WebUI.Models;
using FBM.WebUI.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FBM.WebUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult LoginRegister()
        {
            LoginRegisterVM vm = new LoginRegisterVM();
            return View(vm);
        }
        [HttpPost]
        public ActionResult Login(LoginRegisterVM vm)
        {
            //LoginBindingModel LoginModel = new LoginBindingModel();
            //LoginModel.Password = vm.Password;
            //LoginModel.UserName = vm.UserName;
            //LoginModel.RememberMe = vm.RememberMe;
            //ClientServiceProxy.AccountService().Login(LoginModel);

            //ClientServiceProxy.AccountService().GetUserInfo();

            //ClientServiceProxy.AccountService().Logout();

            return RedirectToAction("index", "Home");
        }
        [HttpPost]
        public ActionResult Register(LoginRegisterVM vm)
        {
            RegisterBindingModel registerModel = new RegisterBindingModel();
            registerModel.Email = vm.Email;
            registerModel.Password = vm.Password;
            registerModel.ConfirmPassword = vm.ConfirmPassword;
            registerModel.UserName = vm.UserName;
            ClientServiceProxy.AccountService().Register(registerModel);
            return RedirectToAction("index", "Home");
        }
    }
}