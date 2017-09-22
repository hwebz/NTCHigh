using EPiServer.ServiceLocation;
using High.Net.Core;
using High.Net.Models.Shared.Pages;
using High.Net.Models.Shared.ViewModels;
using System;

namespace High.Net.Web.Business.Helpers
{
    public static class MailHelpers
    {
        public static string GetBusinessMail(string businessRecipientsEmail, bool uniqueEmailAdress = false)
        {
            if (uniqueEmailAdress) return businessRecipientsEmail;
            if (string.IsNullOrEmpty(businessRecipientsEmail)) { return string.Empty; }

            string businessMail = String.Empty;
            foreach (string _businessRecipientsEmail in businessRecipientsEmail.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                businessMail += " " + _businessRecipientsEmail;
            }
            return businessMail;
        }

        public static bool SendEmailToAdmin(ContactUsPage contactUsPage, ContactUsForm contactUsForm, IHome homePage, EmailContentModel emailContentModel)
        {
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            // send mail to high
            string businessEmailSubject = String.Empty;
            if (!String.IsNullOrEmpty(contactUsPage.BusinessEmailSubject))
            {
                businessEmailSubject = string.Format(Convert.ToString(contactUsPage.BusinessEmailSubject), emailContentModel.ConfirmationSubjectArgs);
            }

            string mailBody = string.Empty;
            if (contactUsPage.BusinessEmailBody != null)
            {
                mailBody = String.Format(Convert.ToString(contactUsPage.BusinessEmailBody), emailContentModel.EmailBodyArgs);
            }

            return dataLocator.sendMail(businessEmailSubject, mailBody, contactUsPage.BusinessRecipientsEmail, null, "", true, null, contactUsForm.Email);
        }

        public static bool SendEmailToUser(ContactUsPage currentPage, ContactUsForm contactUsForm, IHome homePage, EmailContentModel emailContentModel)
        {
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            //send mail to end user
            String EmailConfirmationSubject = String.Empty;
            if (!String.IsNullOrEmpty(currentPage.EmailConfirmationSubject))
            {
                EmailConfirmationSubject = string.Format(Convert.ToString(currentPage.EmailConfirmationSubject), emailContentModel.ConfirmationSubjectArgs);
            }

            var emailConfirmationMessageFormat = currentPage.EmailConfirmationMessage != null ? currentPage.EmailConfirmationMessage.ToString() : string.Empty;
            string EmailConfimationMailBody = string.Format(Convert.ToString(currentPage.EmailConfirmationMessage), emailContentModel.EmailBodyArgs);

            return dataLocator.sendMail(EmailConfirmationSubject, EmailConfimationMailBody, contactUsForm.Email, null, "", true, null, currentPage.BusinessRecipientsEmail, homePage.NameInEmail);
        }

        public static EmailContentModel CreateEmailContentModel(ContactUsPage contactUsPage, ContactUsForm contactUsForm, IHome homePage, bool isMailForAdmin = true)
        {
            var result = new EmailContentModel();
            if (!isMailForAdmin)
            {
                result.ConfirmationSubjectArgs = new string[] { homePage.NameInEmail };

                result.EmailBodyArgs = GetEmailBodyArgs(contactUsPage, contactUsForm, homePage, false);
            }
            else
            {
                result.ConfirmationSubjectArgs = new string[] { homePage.NameInEmail };
                result.EmailBodyArgs = GetEmailBodyArgs(contactUsPage, contactUsForm, homePage, true);
            }
            return result;
        }

        /// <summary>
        /// GetEmailBodyArgs:  Name : {0}  Email : {1} Title: {2} Company: {3}  Phone : {4} Message : {5} chkSpecialOffers:{6} Address : {7}
        /// </summary>
        /// <param name="contactUsPage"></param>
        /// <param name="contactUsForm"></param>
        /// <param name="homePage"></param>
        /// <param name="isMailForAdmin"></param>
        /// <returns></returns>
        private static string[] GetEmailBodyArgs(ContactUsPage contactUsPage, ContactUsForm contactUsForm, IHome homePage, bool isMailForAdmin = true)
        {
            if (isMailForAdmin)
            {
                return new string[] { contactUsForm.Name, contactUsForm.Email,
                                    contactUsForm.Title, contactUsForm.Company,
                                    contactUsForm.PhoneNo, contactUsForm.Message,
                                    contactUsForm.chkSpecialOffers ? "Yes" : "No", contactUsForm.Address };
            }

            // get body for user email
            string businessMail = GetBusinessMail(contactUsPage.BusinessRecipientsEmail, UniqueEmailAddress(homePage));
            return new string[] { homePage.NameInEmail, homePage.BusinessContactNumber, businessMail };
        }

        private static bool UniqueEmailAddress(IHome homePage)
        {
            return homePage is Models.GreenfieldArchitects.Pages.HomePage
                || homePage is Models.HighConcreteAccessories.Pages.HomePage
                || homePage is Models.HighConstructionCo.Pages.HomePage
                || homePage is Models.RealEstateGroup.Pages.HomePage
                || homePage is Models.Rollover.Pages.HomePage
                || homePage is Models.HighConcrete.Pages.HomePage
                || homePage is Models.Commercial.Pages.HomePage
                || homePage is Models.SteelServiceCentre.Pages.HomePage
                || homePage is Models.HighSteelStructure.Pages.HomePage
                || homePage is Models.Industries.Pages.HomePage
                || homePage is Models.GreenfieldArchitects.Pages.HomePage
                || homePage is Models.StructureCareUs.Pages.HomePage
                || homePage is Models.HighTransit.Pages.HomePage;
        }
    }

    public class EmailContentModel
    {
        public EmailContentModel()
        {
            ConfirmationSubjectArgs = new string[0];
            EmailBodyArgs = new string[0];
        }

        public string[] ConfirmationSubjectArgs { get; set; }
        public string[] EmailBodyArgs { get; set; }
    }
}