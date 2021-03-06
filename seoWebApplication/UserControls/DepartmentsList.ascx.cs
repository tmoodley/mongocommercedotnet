﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.Framework;
using seoWebApplication.Service;
using seoWebApplication.Models; 

namespace seoWebApplication.UserControls
{
    public partial class DepartmentsList : System.Web.UI.UserControl
    {
        private DepartmentService _departmentService = new DepartmentService();
        public bool showCategory;
        public int showDeptId;
        public int requestDeptId;
        int Count = 1;
        // Load department details into the DataList
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                requestDeptId = Convert.ToInt32(Request.QueryString["department_id"]);
                showDeptId = 0;
                this.showCategory = true;
            }
            catch
            {
               
                showCategory = false;
            }



            list.DataSource = _departmentService.GetDepartments();
                list.DataBind();
      
             
        
        }

        protected void R1_ItemCreated(Object Sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Departments obj = (Departments)(e.Item.DataItem);

                HyperLink deptHyper = (HyperLink)e.Item.FindControl("deptHyperLink");

                var liProdView = e.Item.FindControl("liProdView") as HtmlGenericControl;

                try
                {
                    if (obj.department_id == requestDeptId)
                    {
                        if (liProdView != null)
                        {
                            liProdView.Attributes["class"] = "active";
                        }
                    }
                    deptHyper.CssClass = "class_menuitem_categorytype";
                    deptHyper.NavigateUrl = LinkMaker.ToDepartment(obj.department_id.ToString());
                    deptHyper.Text = HttpUtility.HtmlEncode(obj.Name.ToString());
                    deptHyper.ToolTip = HttpUtility.HtmlEncode(obj.Description.ToString());
                }
                catch
                { 
                
                } 
            } 
        }  
    }
}