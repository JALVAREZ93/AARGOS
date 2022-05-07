using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using AARGOS.DATOS.Entities;
using AARGOS.DATOS.Enums;
using Newtonsoft.Json;

namespace AARGOS.DATOS
{
    /// <summary>
    /// Metodos de Webservice
    /// </summary>
    public class WebServies
    {
        /// <summary>
        /// Tiemout por defecto
        /// </summary>
        private readonly int DefaultTimeOut = 30000;

        /// <summary>
        /// Realiza el llamado a un servicio HTTP
        /// </summary>
        /// <typeparam name="RESPONSE">Response Type</typeparam>
        /// <typeparam name="REQUEST">Request Type</typeparam>
        /// <param name="request">Request</param>
        /// <returns>Response</returns>
        public HttpResponse<RESPONSE> CallService<RESPONSE, REQUEST>(HttpRequest<REQUEST> request)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(request.URL);
            webRequest.Method = request.Method.ToString().ToUpper(CultureInfo.CurrentCulture);
            webRequest.Timeout = (request.TimeOut > 0 ? (int)request.TimeOut : DefaultTimeOut);
            webRequest.ContentType = GetContentType(request.ContentType);
            if (request.Method != HttpMethod.GET)
            {
                string data = RawData<REQUEST>(request);
                webRequest.ContentLength = Encoding.UTF8.GetBytes(data).Length;
                using (StreamWriter writerSolicitud = new StreamWriter(webRequest.GetRequestStream()))
                {
                    writerSolicitud.Write(data);
                }
            }

            HttpResponse<RESPONSE> response;
            using (HttpWebResponse wsResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                using (StreamReader reader = new StreamReader(wsResponse.GetResponseStream()))
                {
                    ContentType responseContentType = GetContentType(wsResponse.ContentType);
                    string rawData = reader.ReadToEnd();
                    RESPONSE dataResponse = ParseResponse<RESPONSE>(rawData, responseContentType);
                    response = new HttpResponse<RESPONSE>(responseContentType, rawData,dataResponse);
                    response.HttpCode = (int)wsResponse.StatusCode;
                }
            }
            return response;
        }

        /// <summary>
        /// Convierte la respuesta del servicio
        /// </summary>
        public T ParseResponse<T>(string rawData, ContentType contentTypeResponse) 
        {
            T result = default;
            if (contentTypeResponse == ContentType.Json) 
            {
                result = JsonConvert.DeserializeObject<T>(rawData);
            }
            return result;

        }

        /// <summary>
        /// Obtiene la informacion cruda de la peticion
        /// </summary>
        /// <typeparam name="REQUEST">Tipo peticion</typeparam>
        /// <param name="dataRequest">Datos peticion</param>
        /// <param name="content">Tipo de contenido</param>
        /// <returns>Datos peticion cruda</returns>
        public string RawData<REQUEST>(HttpRequest<REQUEST> request)
        {
            string data;
            if (request.Serialize && request.ContentType == ContentType.Json)
            {
                data = JsonConvert.SerializeObject(request.Data);
            }
            else
            {
                data = request.Data?.ToString() ?? string.Empty;
            }
            return data;
        }

        /// <summary>
        /// Obtiene la descripcion para el tipo de contenido
        /// </summary>
        /// <param name="contentType">ContentType</param>
        /// <returns>Descripcion</returns>
        private string GetContentType(ContentType contentType)
        {
            string contentDescription;
            switch (contentType)
            {
                case ContentType.Html:
                    contentDescription = "text/html";
                    break;
                case ContentType.Form:
                    contentDescription = "multipart/form-data";
                    break;
                case ContentType.Xml:
                    contentDescription = "application/xml";
                    break;
                case ContentType.Json:
                    contentDescription = "application/json";
                    break;
                default:
                    contentDescription = "text/plain";
                    break;
            }
            return contentDescription;
        }

        /// <summary>
        /// Obtiene el tipo de contenido a partir de su descripcion
        /// </summary>
        /// <param name="contentTypeDescription">Descripcion Content-Type</param>
        /// <returns>ContentType</returns>
        private ContentType GetContentType(string contentTypeDescription)
        {
            ContentType contentType;
            switch (contentTypeDescription)
            {
                case "text/html":
                    contentType = ContentType.Html;
                    break;
                case "multipart/form-data":
                    contentType = ContentType.Form;
                    break;
                case "application/xml":
                    contentType = ContentType.Xml;
                    break;
                case "application/json":
                case "application/json; charset=utf-8":
                    contentType = ContentType.Json;
                    break;
                default:
                    contentType = ContentType.Text;
                    break;
            }
            return contentType;
        }
    }

}
