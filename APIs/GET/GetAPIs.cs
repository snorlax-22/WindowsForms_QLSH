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


    class GetAPIs
    {
        APIHelper apiHelper = new APIHelper();
        public JObject GetAllRole()
        {
           
            //bước 1: tạo httpwebrequest + tên API + phương thức
            HttpWebRequest httpWebRequest = apiHelper.initRequest("api/v1/GetAllRole", "POST");
            
            //bước 2: tạo body để gửi, ở đây body là {}
            createSendBody(httpWebRequest,null);

            //bước 3: lấy kqua trả về từ response
            StreamReader responseReader = CreateresponseReader(httpWebRequest);

            //bước 4: parse response ra JObject
            string strReceiveContent = responseReader.ReadToEnd();
            JObject jObject = JObject.Parse(strReceiveContent);

            return jObject;
        }

        public JObject GetAllFlower()
        {

            //bước 1: tạo httpwebrequest + tên API + phương thức
            HttpWebRequest httpWebRequest = apiHelper.initRequest("api/v1/GetAllFlower", "POST");

            //bước 2: tạo body để gửi, ở đây body là {}
            createSendBody(httpWebRequest, null);

            //bước 3: lấy kqua trả về từ response
            StreamReader responseReader = CreateresponseReader(httpWebRequest);

            //bước 4: parse response ra JObject
            string strReceiveContent = responseReader.ReadToEnd();
            JObject jObject = JObject.Parse(strReceiveContent);

            return jObject;
        }

        private static void createSendBody(HttpWebRequest httpWebRequest, string strSendContent)
        {
            JObject jObjectSendContent = null;

            if(strSendContent == null)
            {
                strSendContent = string.Empty;
            }
            
            strSendContent = JsonConvert.SerializeObject(jObjectSendContent);
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
