using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSEPM.Web.Controllers.BaseControllers;
using KSEPM.Web.Infrastructure.Attributes;
using KSEPM.Web.Infrastructure.Identity;

namespace KSEPM.Web.Controllers
{
    [CustomValidateAntiForgeryToken]
    [RoutePrefix("Callback")]
    public class CallbackController : ManagerBaseController
    {
        [Route("SendWish")]
        [HttpPost]
        //не вижу смысла пока возращать что-то больше, чем просто текст
        public JsonResult SendWish(string text)
        {
            //получить все пользователей по ролям
            var admins = GetUsersByRole(AccessIdentityRole.SubAdmin);
            foreach (var admin in admins)
            {
                //ПОШТА!
                var mail = admin.Email;

                //тебе надо сделать отправку писем на эти почтовые ящики. Ну там уже сам придумаешь, я хз как оно. Смотри в других проектах.
            }

            //отправка назад , типо всё заебца! если подставить null, то возвратит ошибку
            return Json("", JsonRequestBehavior.DenyGet);
        }
    }
}