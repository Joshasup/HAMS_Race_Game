using System;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;


    public class ClientLibrary
    {
        

        public static Profile getProfile(string username)
        {
            HttpClient test = new HttpClient();
            string temp = "{\n\"username\": \"" + username + "\"}";
            var content = new StringContent(temp, Encoding.UTF8, "application/json");
            var result = test.PostAsync("http://45.33.33.245:8000/profile", content).Result;
            var jsonString = result.Content.ReadAsStringAsync().Result;

            return new Profile(searchJSON("username", jsonString), searchJSON("wins", jsonString), searchJSON("losses", jsonString));

        }
        
        public static void postWin(string username)
        {
            HttpClient test = new HttpClient();
            string temp = "{\n\"username\": \"" + username + "\"}";
            var content = new StringContent(temp, Encoding.UTF8, "application/json");
            var result = test.PostAsync("http://45.33.33.245:8000/profile/win", content).Result;
        }
        
        public static void postLoss(string username)
        {
            HttpClient test = new HttpClient();
            string temp = "{\n\"username\": \"" + username + "\"}";
            var content = new StringContent(temp, Encoding.UTF8, "application/json");
            var result = test.PostAsync("http://45.33.33.245:8000/profile/loss", content).Result;
        }

        public static Match getMatch(UInt32 matchID)
        {
            HttpClient test = new HttpClient();
            string temp = "{\n\"matchID\": "  + matchID + " \n}";
            var content = new StringContent(temp, Encoding.UTF8, "application/json");
            var result = test.PostAsync("http://45.33.33.245:8000/match/get", content).Result;
            var jsonString = result.Content.ReadAsStringAsync().Result;
            var started = searchJSON("started", jsonString).Equals("true");

            return new Match(UInt32.Parse(searchJSON("matchID", jsonString)), started );
        }

        public static void startMatch(UInt32 matchID)
        {
            HttpClient test = new HttpClient();
            string temp = "{\n\"matchID\": "  + matchID + " \n}";
            var content = new StringContent(temp, Encoding.UTF8, "application/json");
            var result = test.PostAsync("http://45.33.33.245:8000/match/start", content).Result;
        }
        
        public static void endMatch(UInt32 matchID)
        {
            HttpClient test = new HttpClient();
            string temp = "{\n\"matchID\": "  + matchID + " \n}";
            var content = new StringContent(temp, Encoding.UTF8, "application/json");
            var result = test.PostAsync("http://45.33.33.245:8000/match/end", content).Result;
        }
        
        
        
        public static UInt32 createMatch(String username)
        {
            HttpClient test = new HttpClient();
            string temp = "{\n\"username\": \""  + username + "\" \n}";
            var content = new StringContent(temp, Encoding.UTF8, "application/json");
            var result = test.PostAsync("http://45.33.33.245:8000/match/create", content).Result;
            var jsonString = result.Content.ReadAsStringAsync().Result;
            return UInt32.Parse(searchJSON("matchID", jsonString));
        }
        
        public static UInt32 joinMatch(String username)
        {
            HttpClient test = new HttpClient();
            string temp = "{\n\"username\": \""  + username + "\" \n}";
            var content = new StringContent(temp, Encoding.UTF8, "application/json");
            var result = test.PostAsync("http://45.33.33.245:8000/match/join", content).Result;
            var jsonString = result.Content.ReadAsStringAsync().Result;
            return UInt32.Parse(searchJSON("matchID", jsonString));
        }
        
        public static string searchJSON(string search, string json)
        {
            string searchString = search + "\":\\s\"(?<value>\\w*)";
            Regex testrx = new Regex(searchString);
            MatchCollection matches = testrx.Matches(json);
            if (matches.Count > 0)
                return matches[0].Groups[1].Value;
            return "";
        }
        
        public static AuthResult authUser(string username, string password)
        {
            HttpClient test = new HttpClient();
            string temp = "{\n\"username\": \"" + username + "\",\n\"password\": \"" + password + "\"" + "}";
            var content = new StringContent(temp, Encoding.UTF8, "application/json");
            var result = test.PostAsync("http://45.33.33.245:8000/auth", content).Result;
            var jsonString = result.Content.ReadAsStringAsync().Result;

            if (searchJSON("login", jsonString).Equals("success")){
                return new AuthResult(true);
            }
            else
            {
                return new AuthResult(false);
            }
        }
        
        
        
        public static bool regUser(string username, string password)
        {
            HttpClient test = new HttpClient();
            string temp = "{\n\"username\": \"" + username + "\",\n\"password\": \"" + password + "\"" + "}";
            var content = new StringContent(temp, Encoding.UTF8, "application/json");
            var result = test.PostAsync("http://45.33.33.245:8000/reg", content).Result;
            var jsonString = result.Content.ReadAsStringAsync().Result;
            return searchJSON("registration", jsonString).Equals("success");
            /*{
                return new RegResult(true);
            }
            else
            {
                return new RegResult(false);
            }*/
        }
        
        
        
    }
    
