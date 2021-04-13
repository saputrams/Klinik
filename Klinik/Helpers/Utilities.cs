using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Klinik.Helpers
{
    public class Utilities
    {
        public void Alert(Page xPage)
        {
            
            ClientScriptManager cs = xPage.ClientScript;
            Type cstype = this.GetType();
            cs.RegisterStartupScript(cstype, null,
                "<script language='javascript'>" +
                "swal('Good job!','You clicked the button!', 'success')" +
                "</script>");
        }

        public static string SaveSuccess()
        {
            return "Data Successfully Saved";
        }
        public static string DeleteSuccess()
        {
            return "Data Successfully Deleted";
        }

        public static string SubmitSuccess()
        {
            return "Data Successfully Submitted";
        }
        public static string MessageDeleteConfirm()
        {
            return "Are you sure to delete the data ?";
        }

    }
}