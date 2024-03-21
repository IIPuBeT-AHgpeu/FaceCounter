using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace FaceCounter.Controllers
{
    [Route("pages")]
    public class PageController : Controller
    {
        [HttpGet]
        public ContentResult Index()
        {
            var response = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n\t<title>Recognize</title>\r\n</head>\r\n<body>\r\n\t<hr />\r\n\t<h1 style=\"text-align: center;\">Face counter</h1>\r\n\t<hr />\r\n\t<table style=\"margin-top: 100px;\" align=\"center\">\r\n\t\t<tbody>\r\n\t\t\t<tr>\r\n\t\t\t\t<td style=\"padding: 10px;\">File</td>\r\n\t\t\t\t<td style=\"padding: 10px;\">Count of faces</td>\r\n\t\t\t</tr>\r\n\t\t\t<tr>\r\n\t\t\t\t<td style=\"padding: 10px;\"><input id=\"image\" type=\"file\" name=\"image\" /></td>\r\n\t\t\t\t<td style=\"padding: 10px;\"><input id=\"result\" type=\"text\" readonly name=\"num\" value=\"0\" /></td>\r\n\t\t\t</tr>\r\n\t\t</tbody>\r\n\t</table>\r\n\t<div align=\"center\" style=\"margin-top: 30px\">\r\n\t\t<input id=\"find\" type=\"button\" value=\"Count\" />\r\n\t</div>\r\n</body>\r\n</html>\r\n\r\n<script>\r\n\tdocument.getElementById(\"find\").onclick = recognizeButton;\r\n\r\n\tfunction recognizeButton() {\r\n        const form = new FormData();\r\n        form.append(\"image\", document.querySelector(\"input[type='file']\").files[0]);\r\n\r\n        fetch(\"http://localhost:5062/recognize\", {\r\n            method: \"POST\",\r\n            body: form,\r\n        })\r\n            .then(response => response.text())\r\n            .then(data => document.getElementById(\"result\").value = data)\r\n            .catch(error => console.error(error));\r\n\t}\r\n</script>";

            return new ContentResult
            {
                Content = response,
                ContentType = "text/html"
            };
        }

        [HttpGet("history")]
        public ContentResult History()
        {
            var response = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n<title>History</title>\r\n</head>\r\n<body>\r\n<hr />\r\n<h1 style=\"text-align: center;\">History of recognition</h1>\r\n        <hr />\r\n        <table id=\"table\" style=\"margin-top: 50px; align-self: center\" align=\"center\" border=\"1\">\r\n            <tbody >\r\n                <tr>\r\n                    <td style=\"padding: 10px; text-align: center;\">Id</td>\r\n                    <td style=\"padding: 10px; text-align: center;\">Picture</td>\r\n                    <td style=\"padding: 10px; text-align: center;\">Count of faces</td>\r\n                </tr>\r\n\r\n            </tbody>\r\n        </table>\r\n        <div align=\"center\" style=\"margin-top: 30px\">\r\n            <input id=\"update\" type=\"button\" value=\"Update\" />\r\n        </div>\r\n    </body>\r\n</html>\r\n<script>\r\n    document.getElementById(\"update\").onclick = updateButton;\r\n\r\n    function updateButton() {\r\n        const Http = new XMLHttpRequest();\r\n        const url = 'http://localhost:5062/history/all';\r\n        let table = document.getElementById('table');\r\n        try {\r\n            Http.open(\"GET\", url, false);\r\n            Http.send(null);\r\n\r\n            var result = JSON.parse(Http.responseText);\r\n\r\n            for (i = 0; i < result.length; i++) {\r\n                let tr = table.insertRow(-1);\r\n\r\n                let td_id = tr.insertCell(-1);\r\n                td_id.innerHTML = result[i]['id'];\r\n                td_id.setAttribute('style', 'text-align: center;');\r\n\r\n                let td_image = tr.insertCell(-1);\r\n                td_image.setAttribute('style', 'text-align: center;');\r\n\r\n                let image = document.createElement('img');\r\n                image.setAttribute('src', 'data:image/gif;base64,' + result[i]['image']);\r\n                image.setAttribute('width', '150px');\r\n                image.setAttribute('heigth', '100px');\r\n\r\n                td_image.appendChild(image);\r\n\r\n                let td_result = tr.insertCell(-1);\r\n                td_result.setAttribute('style', 'text-align: center;');\r\n                td_result.innerHTML = result[i]['result'];\r\n            }\r\n\r\n        } catch (e) {\r\n            console.log(e);\r\n        }\r\n    }\r\n</script>";
            
            return new ContentResult
            {
                Content = response,
                ContentType = "text/html"
            };
        }
    }
}
