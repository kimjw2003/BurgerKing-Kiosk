﻿using BurgerKing_kiosk.model;
using BurgerKing_kiosk.model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKing_kiosk.viewModel
{
    class UserListViewModel
    {
        UserListDB db = new UserListDB();

        public List<UserModel> GetUser()
        {
            List<UserModel> user = db.GetUser();
           
            return user;
        }
    }
}
