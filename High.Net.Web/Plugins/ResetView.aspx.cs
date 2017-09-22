using System;
using System.Web.Security;
using EPiServer.PlugIn;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ViewComposition;

namespace High.Net.Web.Plugins
{
    [GuiPlugIn(DisplayName = "Reset Views for all users", Description = "Reset Views for all users", Area = PlugInArea.AdminMenu, Url = "~/Plugins/ResetView.aspx")]
    public partial class ResetView : System.Web.UI.Page
    {

        // TODO: Add your Plugin Control Code here.

        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            ResetViewForAllUser();
            labelMessage.Text = "Done";
        }

        private void ResetViewForAllUser()
        {
            var viewSettingsRepository = ServiceLocator.Current.GetInstance<IPersonalizedViewSettingsRepository>();
            var users = Membership.GetAllUsers();
            foreach (MembershipUser user in users)
            {
                var principal = PrincipalInfo.CreatePrincipal(user.UserName);
                foreach (var personalizedViewSettings in viewSettingsRepository.Load(principal))
                {
                    viewSettingsRepository.Delete(principal, personalizedViewSettings.ViewName);
                }
            }
        }
    }
}