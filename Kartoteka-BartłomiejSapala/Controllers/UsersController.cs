using DataBase;
using DataBase.Dao;
using DataBase.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kartoteka_BartłomiejSapala.Controllers
{
    public class UsersController : Controller
    {
        private readonly Context _context;

        public UsersController(Context context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            IEnumerable<User> result = _context.Users;
            return View(result);
        }

        public ActionResult Create()
        {
            ViewBag.Permissions = new SelectList(_context.Permissions, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Login,Password,ConfirmPassword,Name,LastName,Pesel,PermissionId,PlaceOfBirth,DateOfBirth,Workplace")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool checkLogin = new UserDao().CheckUserLogin(_context, user.Login, null);
                    bool checkPesel = new UserDao().CheckUserPesel(_context, user.Pesel, null);

                    if(checkLogin || checkPesel)
                    {
                        if(checkLogin)
                            ModelState.AddModelError("Login", "Użytkownik o takiej nazwie już istnieje");

                        if(checkPesel)
                            ModelState.AddModelError("Pesel", "Użytkownik o taki numerze Pesel już istnieje");

                        ViewBag.Permissions = new SelectList(_context.Permissions, "Id", "Name");
                        return View();
                    }

                    _context.Users.Add(user);
                    _context.SaveChanges();

                    if (user.PermissionId != null)
                    {
                        Permission permission = _context.Permissions.Find(user.PermissionId);
                        if (permission != null)
                        {
                            UserPermission userPermission = new UserPermission(user.Id, permission);
                            _context.UserPermission.Add(userPermission);
                            _context.SaveChanges();

                        }
                    }

                    return RedirectToAction(nameof(CreateComplete));
                }

                return View();
            }
            catch(Exception e)
            {
                return View();
            }
        }

        public ActionResult CreateComplete()
        {

            return View();
        }

        public ActionResult Edit(int id)
        {
            User user = _context.Users.Where(u => u.Id == id).FirstOrDefault();
            if (user == null)
                return NotFound();
            else
            {
                if (user.Permission != null)
                    ViewBag.Permissions = new SelectList(_context.Permissions, "Id", "Name", user.Permission.Id);
                else
                    ViewBag.Permissions = new SelectList(_context.Permissions, "Id", "Name");

                return View(user);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Login,Password,ConfirmPassword,Name,LastName,Pesel,PermissionId,PlaceOfBirth,DateOfBirth,Workplace")] User user)
        {
            try
            {
                if (id == 0)
                    return NotFound();
                else
                {
                    bool checkLogin = new UserDao().CheckUserLogin(_context, user.Login, user.Id);
                    bool checkPesel = new UserDao().CheckUserPesel(_context, user.Pesel, user.Id);

                    if (checkLogin || checkPesel)
                    {
                        if (checkLogin)
                            ModelState.AddModelError("Login", "Użytkownik o takiej nazwie już istnieje");

                        if (checkPesel)
                            ModelState.AddModelError("Pesel", "Użytkownik o taki numerze Pesel już istnieje");

                        ViewBag.Permissions = new SelectList(_context.Permissions, "Id", "Name");
                        return View();
                    }


                    if (user.PermissionId != null)
                    {
                        var UserPemissionExist = new UserPermissionDao().GetByUserId(user.Id);
                        if (UserPemissionExist == null)
                        {
                            Permission permission = _context.Permissions.Find(user.PermissionId);
                            if (permission != null)
                            {
                                UserPermission userPermission = new UserPermission(user.Id, permission);
                                _context.UserPermission.Add(userPermission);
                                _context.SaveChanges();
                            }
                        }
                        else if (UserPemissionExist != null && UserPemissionExist.PermissionId != user.PermissionId)
                        {
                            UserPemissionExist.Permission = _context.Permissions.Find(user.PermissionId);
                            _context.UserPermission.Update(UserPemissionExist);
                            _context.SaveChanges();
                        }
                    }

                    _context.Users.Update(user);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(CreateComplete));
                }


            }
            catch(Exception e)
            {
                return View();
            }

         }

        [HttpPost]

        public ActionResult Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    User user = _context.Users.Find(id);
                    if (user != null)
                    {
                        UserPermission userPermission = new UserPermissionDao().GetByUserId(user.Id);
                        if(userPermission != null)
                        {
                            _context.UserPermission.Remove(userPermission);
                            _context.Users.Remove(user);
                            _context.SaveChanges();
                            return Json("OK");
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
