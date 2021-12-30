using ClientFrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace ClientFrontEnd.Service
{
    public class ApiService
    {
        public static string BaseUrl = "https://localhost:7215/";
        public static string XAccessToken;

        public ApiService()
        {
            if(XAccessToken!=null)
            {

            }
        }
        public object? login(SiteUser user)
        {
            var client = new RestClient(BaseUrl + "login");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(user);
            IRestResponse response = client.Execute(request);
            XAccessToken = "X-Access-Token=" + JsonConvert.DeserializeObject<UserModel>(response.Content).token;
            return response.IsSuccessful == true ? response.Content : null;
        }
        public object? updateuser(SiteUser user)
        {
            var client = new RestClient(BaseUrl + "updateuser");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cookie", XAccessToken);
            request.AddJsonBody(user);
            IRestResponse response = client.Execute(request);
            return response.IsSuccessful == true ? response.Content : null;
        }
        public object? logout()
        {
            var client = new RestClient(BaseUrl + "logout");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            IRestResponse response = client.Execute(request);
            XAccessToken = null;
            return response.IsSuccessful == true ? response.Content : null;
        }
        
        public object? register(SiteUser user)
        {
            var client = new RestClient(BaseUrl + "register");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(user);
            IRestResponse response = client.Execute(request);
            return response.IsSuccessful == true ? response.Content : null;
        }
        public object? getuser(string userName)
        {
            var client = new RestClient(BaseUrl + "getuser");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", XAccessToken);
            request.AddQueryParameter("userName",userName);
            IRestResponse response = client.Execute(request);
            return response.IsSuccessful == true ? response.Content : null;
        }
        public object? getmyapplicationlist()
        {
            var client = new RestClient(BaseUrl + "getmyapplicationlist");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", XAccessToken);
            IRestResponse response = client.Execute(request);
            return response.IsSuccessful == true ? response.Content : null;
        }
        public object? getuserlist()
        {
            var client = new RestClient(BaseUrl + "getuserlist");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", XAccessToken);
            IRestResponse response = client.Execute(request);
            return response.IsSuccessful == true ? response.Content : null;
        }
        public object? getapplyapplication()
        {
            var client = new RestClient(BaseUrl + "getapplyapplication");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", XAccessToken);
            IRestResponse response = client.Execute(request);
            return response.IsSuccessful == true ? response.Content : null;
        }
        
        public object? getprogramlist()
        {
            var client = new RestClient(BaseUrl + "getprogramlist");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", XAccessToken);
            IRestResponse response = client.Execute(request);
            return response.IsSuccessful == true ? response.Content : null;
        }
        public object? addprogram(AcademicProgram program)
        {
            var client = new RestClient(BaseUrl + "addprogram");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cookie", XAccessToken);
            request.AddJsonBody(program);
            IRestResponse response = client.Execute(request);
            return response.IsSuccessful == true ? response.Content : null;
        }
        public object? applyprogram(Applications applications)
        {
            var client = new RestClient(BaseUrl + "applyprogram");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cookie", XAccessToken);
            request.AddJsonBody(applications);
            IRestResponse response = client.Execute(request);
            return response.IsSuccessful == true ? response.Content : null;
        }
        public object? getevaluationapplication()
        {
            var client = new RestClient(BaseUrl + "getevaluationapplication");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", XAccessToken);
            IRestResponse response = client.Execute(request);
            return response.IsSuccessful == true ? response.Content : null;
        }
        public object? checkapplyprogram(Applications applications)
        {
            var client = new RestClient(BaseUrl + "checkapplyprogram");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cookie", XAccessToken);
            request.AddJsonBody(applications);
            IRestResponse response = client.Execute(request);
            return response.IsSuccessful == true ? response.Content : null;
        }
        
    }
}
