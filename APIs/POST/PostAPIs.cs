using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_QLSH.APIs
{


    class PostAPIs
    {
        APIHelper apiHelper = new APIHelper();

        public JObject PostPayment(string payment)
        {

            //bước 1: tạo httpwebrequest + tên API + phương thức
            HttpWebRequest httpWebRequest = apiHelper.initRequest("api/v1/PostPayment", "POST");

            //bước 2: tạo body để gửi, ở đây body là account (kiểu jSonstring)
            createSendBody(httpWebRequest, payment);

            //bước 3: lấy kqua trả về từ response
            StreamReader responseReader = CreateresponseReader(httpWebRequest);

            //bước 4: parse response ra JObject
            string strReceiveContent = responseReader.ReadToEnd();
            JObject jObject = JObject.Parse(strReceiveContent);

            return jObject;
        }

        public JObject PostAcount(string account)
        {
           
            //bước 1: tạo httpwebrequest + tên API + phương thức
            HttpWebRequest httpWebRequest = apiHelper.initRequest("api/v1/PostAccount", "POST");
            
            //bước 2: tạo body để gửi, ở đây body là account (kiểu jSonstring)
            createSendBody(httpWebRequest, account);

            //bước 3: lấy kqua trả về từ response
            StreamReader responseReader = CreateresponseReader(httpWebRequest);

            //bước 4: parse response ra JObject
            string strReceiveContent = responseReader.ReadToEnd();
            JObject jObject = JObject.Parse(strReceiveContent);

            return jObject;
        }

        public JObject PostFlower(string flower)
        {

            //bước 1: tạo httpwebrequest + tên API + phương thức
            HttpWebRequest httpWebRequest = apiHelper.initRequest("api/v1/PostFlower", "POST");

            //bước 2: tạo body để gửi, ở đây body là account (kiểu jSonstring)
            createSendBody(httpWebRequest, flower);

            //bước 3: lấy kqua trả về từ response
            StreamReader responseReader = CreateresponseReader(httpWebRequest);

            //bước 4: parse response ra JObject
            string strReceiveContent = responseReader.ReadToEnd();
            JObject jObject = JObject.Parse(strReceiveContent);

            return jObject;
        }

        private static void createSendBody(HttpWebRequest httpWebRequest, string strSendContent)
        {
            //JObject jObjectSendContent = null;

            if(strSendContent == null)
            {
                strSendContent = string.Empty;
            }

            //strSendContent = JsonConvert.SerializeObject(strSendContent);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(strSendContent);
            }
        }

        private static StreamReader CreateresponseReader(HttpWebRequest httpWebRequest)
        {
            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            if (httpWebResponse.StatusCode != HttpStatusCode.OK)
            {
                string strErrorMessageDetail = httpWebResponse.StatusCode.ToString();
            }
            StreamReader responseReader = new StreamReader(httpWebResponse.GetResponseStream());
            return responseReader;
        }
    }
}
