using DevExpress.Web;
using DevExpress.Web.Mvc;
using wencove.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using wencove.conexion.model.neg;
using wencove.conexion.model.entity;

namespace wencove.Model {
    public static class GridViewHelper {


        
        public static List<Issue> GetIssues() {
            UserNeg userNeg=new  UserNeg();
            return DataProvider.GetIssues();
        }

        public static List<User> getUsers()
        {
            UserNeg userNeg = new UserNeg();
            return userNeg.findAll();
        }
        public static List<Contact> GetCustomers() {
            return DataProvider.GetContacts();
        }
        public static GridViewModel GetGridViewModel() {
            return new GridViewModel();
        }
        public static void AddNewRecord(User issue) {
            UserNeg userNeg = new UserNeg();
            userNeg.create(issue);
        }

        public static void UpdateRecord(User issue) {
            UserNeg userNeg = new UserNeg();
            userNeg.update(issue);
        }

        public static void DeleteRecords(string selectedRowIds) {
            UserNeg userNeg = new UserNeg();
            List<int> selectedIds = selectedRowIds.Split(',').ToList().ConvertAll(id => int.Parse(id));
            userNeg.DeleteUser(selectedIds);
        }
    }
}