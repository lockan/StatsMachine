﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using statsmachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace statsmachine
{
    //CONTAINS GLOBAL UTILITY FUNCTIONS
    public class Utility
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        //Returns a UserViewModel object given the user's ID
        public static UserViewModel GetUserViewModel(string userid)
        {
            db = new ApplicationDbContext(); //Need to refresh the context, otherwise updates might return old data. 
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
            
            ApplicationUser user = db.Users.Find(userid);

            if (user == null)
            {
                return null;
            }

            UserViewModel uvm = new UserViewModel();
            uvm.Id = user.Id;
            uvm.firstname = user.firstname;
            uvm.lastname = user.lastname;
            uvm.avatar = user.avatar;
            uvm.iconpath = GetImgPath(user.avatar);
            uvm.username = user.UserName;

            uvm.roles = new List<string>();
            foreach (var role in userManager.GetRoles(user.Id))
            {
                uvm.roles.Add(role);
            }

            return uvm;
        }

        //Retrieve and return List of all available roles
        public static List<string> GetAvailableRoles()
        {
            db = new ApplicationDbContext();
            List<string> allroles = new List<string>();
            foreach (var r in db.Roles)
            {
                allroles.Add(r.Name);
            }
            return allroles;
        }

        // Note: This should only be used if absolutely necessary. There are better ways. 
        // Use Html.Image helper wherever possible. 
        public static string GetImgPath(string imgname)
        {
            return String.Format("/Content/Images/{0}.png", imgname.ToLower());
        }
    }
}