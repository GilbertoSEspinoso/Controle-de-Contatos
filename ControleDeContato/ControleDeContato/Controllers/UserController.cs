using ControleDeContato.Models;
using ControleDeContato.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ControleDeContato.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            List<UserModel> users = _userRepository.GetAll();

            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int Id)
        {
            UserModel user = _userRepository.ListForId(Id);
            return View(user);
        }

        public IActionResult DeleteUser(int id)
        {
            UserModel user = _userRepository.ListForId(id);
            return View(user);
        }



        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user = _userRepository.AddUser(user);

                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch (Exception e)
            {
                TempData["MensagemError"] = $"Ops! Cadastro não realizado. Erro: ( {e.Message} )";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _userRepository.Delete(id);

                if (deleted)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemError"] = "Ops! Não consegui apagar o Usuário.";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                TempData["MensagemError"] = $"Ops! Não consegui apagar o Usuário. Erro: ( {e.Message} )";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(PasswordlessUserModel passwordlessUserModel)
        {
            try
            {
                UserModel user = null;

                if (ModelState.IsValid)
                {
                    user = new UserModel()
                    {
                        Id = passwordlessUserModel.Id,
                        Name = passwordlessUserModel.Name,
                        Login = passwordlessUserModel.Login,
                        Email = passwordlessUserModel.Email,
                        Perfil = passwordlessUserModel.Perfil
                    };

                    user = _userRepository.UpdateUser(user);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch (System.Exception e)
            {
                TempData["MensagemError"] = $"Ops! Não foi possível realizar o Usuário. Erro: ( {e.Message} )";
                return RedirectToAction("Index");
            }
        }




    }
}

