using EPiServer.Logging;
using High.Net.Core.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.WebPages;
using System.Xml.Linq;

namespace High.Net.Models.Business.Solve360
{
    public static class Solve360Helper
    {
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(Solve360Helper));

        public static List<SolveCategoryTag> GetCategoryTags()
        {
            var response = new Solve360Client().MakeRequest("/contacts/categories/", HttpVerb.GET, HttpStatusCode.OK);
            if (response != null)
            {
                var categories =
                    response.Descendants("category")
                        .Select(x => new SolveCategoryTag { Name = x.Element("name").Value, Id = x.Element("id").Value })
                        .ToList();
                return categories;
            }
            return new List<SolveCategoryTag>();
        }

        public static XDocument GetContact(int id = 0)
        {
            var response = new Solve360Client().MakeRequest("/contacts/" + id, HttpVerb.GET, HttpStatusCode.OK);
            return response;
        }

        public static int SearchContact(string SearchEmail)
        {
            var response = new Solve360Client().MakeRequest("/contacts?filtermode=byemail&filtervalue=" + SearchEmail,
                HttpVerb.GET, HttpStatusCode.OK);
            if (response == null)
            {
                Logger.Warning("Solve360Client().MakeRequest(/contacts/) return null.");
                return 0;
            }

            int contactCount =0;
            int.TryParse(response.Descendants("count").FirstOrDefault()?.Value, out contactCount);
          
            return contactCount > 0 ? GetContactId(response): contactCount;
        }

        private static int GetContactId(XDocument document)
        {
            int companyId;
            int.TryParse(document.Descendants("id").FirstOrDefault()?.Value, out companyId);
            return companyId;

        }

        public static bool AddContacts(string postcontactData, string activityNote)
        {
            postcontactData = AddSourceWebsiteCategory(postcontactData);
            var response = new Solve360Client().MakeRequest("/contacts/", HttpVerb.POST, HttpStatusCode.Created,
                postcontactData);
            if (response == null)
            {
                Logger.Warning("Solve360Client().MakeRequest(/contacts/) return null.");
                return false;
            }

            //var contactid = response.Descendants("id").FirstOrDefault().Value;
            var contactid = GetContactId(response);
            return
                AddActivity(
                    string.Format(
                        "<request><parent>{0}</parent><data><details>{1}</details><nodate>1</nodate></data></request>",
                        contactid, activityNote));
        }

        public static bool UpdateContacts(int contactId, string postData, string activityNote)
        {
            try
            {
                postData = AddSourceWebsiteCategory(postData);
                var response = new Solve360Client().MakeRequest("/contacts/" + contactId, HttpVerb.PUT,
                    HttpStatusCode.OK, postData);
                if (!activityNote.IsEmpty())
                {
                    return response.ToString().Contains("success")
                        ? AddActivity(
                            string.Format(
                                "<request><parent>{0}</parent><data><details>{1}</details><nodate>1</nodate></data></request>",
                                contactId, activityNote))
                        : false;
                }
                return response.ToString().Contains("success");
            }
            catch (Exception ex)
            {
                Logger.Error("Failed when calling UpdateContacts, message: " + ex.Message);
                return false;
            }
        }

        private static string AddSourceWebsiteCategory(string postData)
        {
            var categories = GetCategoryTags();
            if (categories.IsNullOrEmpty()) { return string.Empty; }
            var sourceWebsiteCategory =
                int.Parse(categories.Where(x => x.Name.Contains("Source:Website")).Select(c => c.Id).FirstOrDefault());
            if (sourceWebsiteCategory != 0)
            {
                var categoryIndex = postData.IndexOf("</category>");
                postData = postData.Insert(categoryIndex + "</category>".Length,
                    "<category>" + sourceWebsiteCategory + "</category>");
            }
            return postData;
        }

        public static bool AddActivity(string postData)
        {
            var response = new Solve360Client().MakeRequest("/contacts/followup/", HttpVerb.POST, HttpStatusCode.Created,
                postData);
            if (response == null)
            {
                Logger.Warning("Solve360Client().MakeRequest(/contacts/) return null.");
                return false;
            }
            return response.ToString().Contains("success") ? true : false;
        }

        public static int SearchCompany(string companyName)
        {
            var response = new Solve360Client().MakeRequest("/companies/?searchmode=Sany&searchvalue=" + companyName,
                HttpVerb.GET, HttpStatusCode.OK);
            if (response == null)
            {
                Logger.Warning("Solve360Client().MakeRequest(/contacts/) return null.");
                return -1;
            }
            var companyCountStr = response.Descendants("count").FirstOrDefault()?.Value;
            int companyCount;
            int.TryParse(companyCountStr, out companyCount);
            if (companyCount > 0)
            {
                return GetContactId(response);               
            }
            return AddCompany(string.Format("<request><name>{0}</name></request>", companyName));
        }

        public static int AddCompany(string postData)
        {
            var response = new Solve360Client().MakeRequest("/companies/", HttpVerb.POST, HttpStatusCode.Created,
                postData);
            if (response == null)
            {
                Logger.Warning("Solve360Client().MakeRequest(/contacts/) return null.");
                return 0;
            }
            return GetContactId(response);            
        }
    }
}