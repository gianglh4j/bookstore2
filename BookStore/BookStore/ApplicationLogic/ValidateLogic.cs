
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookStore.ApplicationLogic
{

    public class ResultValidate
    {
        public int statuscode { get; set; }
        public string message { get; set; }
    }

    public class Token
    {
        public string token { get; set; }
        public string message { get; set; }
    }


  


    public class ValidateLogic
    {
        private static readonly HttpClient client = new HttpClient();



        //public bool POSTData(object json, string url)
        //{
        //    using (var content = new StringContent(JsonConvert.SerializeObject(json), System.Text.Encoding.UTF8, "application/json"))
        //    {
        //        HttpResponseMessage result = client.PostAsync(url, content).Result;
        //        if (result.StatusCode == System.Net.HttpStatusCode.Created)
        //            return true;
        //        string returnValue = result.Content.ReadAsStringAsync().Result;
        //        throw new Exception($"Failed to POST data: ({result.StatusCode}): {returnValue}");
        //    }
        //}

        public async Task<ResultValidate> validateAdminToken(string header)
        {
           
            string token = null;
            //header = "Bearer eyJhbGciOiJIUzI1NiIXVCJ9...TJVA95OrM7E20RMHrHDcEfxjoYZgeFONFh7HgQ";
            if (header != null && header.Contains("Bearer"))
            {
                string[] aux = header.Split(" ");
                token = aux.Length > 1 ? aux[1].Trim() : token;
            }
            if (token != null)
            {
                
            //    var content = new FormUrlEncodedContent(new[]
            //    {
            //    new KeyValuePair<string, string>("token", token)
            //});


                Token tokenn = new Token()
                {
                    token = token
                };
                StringContent stringcontent1 = new StringContent(JsonConvert.SerializeObject(tokenn), System.Text.Encoding.UTF8, "application/json");

                var responseTask = await client.PostAsync($"https://jsonplaceholder.typicode.com/users/", stringcontent1);
                var stringContentRes = responseTask.Content.ReadAsStringAsync().Result;

                // JObject json = JObject.Parse(stringContent);
                //var result1 = JsonConvert.DeserializeObject<ResultValidate>(stringContent);
                ResultValidate result1 = new ResultValidate()
                {
                    statuscode = 200
                };


                return result1;
            }
            else
            {
                throw new KeyNotFoundException("no token cant not access");
            }

           
        }
    }
}
