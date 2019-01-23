using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TflRestApi.Logic
{
    public class TflApiServices : ITflApiServices
    {
        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <param name="roadId">The road identifier.</param>
        /// <returns>If valid road id returns display name or returns the error message </returns>
        public string GetDisplayName(string roadId)
        {
          
            var displayName = string.Empty;
            if (IsValidRoadId(roadId))
            {
                

                foreach (var data in GetTflApiResponse(roadId).Result)
                {
                    
                        displayName = data.DisplayName;
                    

                }
            }
          
            return displayName;

        }

        /// <summary>
        /// Gets the status severity.
        /// </summary>
        /// <param name="roadId">The road identifier.</param>
        /// <returns></returns>
        public string GetStatusSeverity(string roadId)
        {
            var statusSeverity = string.Empty;
            if (IsValidRoadId(roadId))
            {
                
                foreach (var data in GetTflApiResponse(roadId).Result)
                {
                    
                        statusSeverity = data.StatusSeverity;
                    

                }
            }
            return statusSeverity;
        }

        /// <summary>
        /// Gets the status severity description.
        /// </summary>
        /// <param name="roadId">The road identifier.</param>
        /// <returns></returns>
        public string GetStatusSeverityDescription(string roadId)
        {
            var statusSeverityDescription = string.Empty;
            if (IsValidRoadId(roadId))
            {
                foreach (var data in GetTflApiResponse(roadId).Result)
                {
                    
                        statusSeverityDescription = data.StatusSeverityDescription;
                    
                }
            }
           
            return statusSeverityDescription;
        }

        private bool IsValidRoadId(string roadId)
        {
            return GetValidRoadIds().Contains(roadId);
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <param name="roadId">The road identifier.</param>
        /// <returns></returns>
        public string GetMessage(string roadId)
        {
            var errorMessage = string.Empty;
            if (!IsValidRoadId(roadId))
            {
                foreach (var data in GetTflApiErrorResponse(roadId).Result)
                {
                    errorMessage = data.Message;
                }
            }
            
            return errorMessage ;
        }

        /// <summary>
        /// Gets the HTTP status code.
        /// </summary>
        /// <param name="roadId">The road identifier.</param>
        /// <returns></returns>
        public int GetHttpStatusCode(string roadId)
        {
            var httpStatusCode = 0;

            if (!IsValidRoadId(roadId))
            {
                
                foreach (var data in GetTflApiErrorResponse(roadId).Result)
                {
                    httpStatusCode = data.HttpStatusCode;
                }
            }
            
            return  httpStatusCode;
        }

        /// <summary>
        /// Gets the HTTP status.
        /// </summary>
        /// <param name="roadId">The road identifier.</param>
        /// <returns></returns>
        public string GetHttpStatus(string roadId)
        {
            var httpStatus = string.Empty;
           
            if (!IsValidRoadId(roadId))
            {
                foreach (var data in GetTflApiErrorResponse(roadId).Result)
                {
                    httpStatus = data.HttpStatus;
                }
            }

            return httpStatus;
        }
        /// <summary>
        /// Gets the TFL API response.
        /// </summary>
        /// <param name="roadId">The road identifier.</param>
        /// <returns></returns>
        private static async Task<List<ApiResponse>> GetTflApiResponse(string roadId)
        {
            var apiResponse = new List<ApiResponse>();
            const string appId = "c7d08eb2";
            const string appKey = "822328c4d06595431c207907ed980231";
            var baseUri = new UriBuilder("https://api.tfl.gov.uk/Road/");
            var roadIdToAppend = roadId + "?";
            var appIdToAppend = "app_id=" + appId;
            var appKeyToAppend = "app_key=" + appKey;

            //building the url
            var tflApiUrl = baseUri + roadIdToAppend + appIdToAppend + "&" + appKeyToAppend;
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(tflApiUrl);
                return JsonConvert.DeserializeObject<List<ApiResponse>>(content);
            }
        }
        /// <summary>
        /// Gets the TFL API error response.
        /// </summary>
        /// <param name="roadId">The road identifier.</param>
        /// <returns></returns>
        private static async Task<List<ApiErrorResponse>> GetTflApiErrorResponse(string roadId)
        {
            var apiErrorResponse = new List<ApiErrorResponse>();
            const string appId = "c7d08eb2";
            const string appKey = "822328c4d06595431c207907ed980231";
            var baseUri = new UriBuilder("https://api.tfl.gov.uk/Road/");
            var roadIdToAppend = roadId + "?";
            var appIdToAppend = "app_id=" + appId;
            var appKeyToAppend = "app_key=" + appKey;

            //building the url
            var tflApiUrl = baseUri + roadIdToAppend + appIdToAppend + "&" + appKeyToAppend;
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(tflApiUrl);
                return JsonConvert.DeserializeObject<List<ApiErrorResponse>>(content);
            }
        }
        /// <summary>
        /// Gets the TFL API response.
        /// </summary>
        /// <param name="roadId">The road identifier.</param>
        /// <returns></returns>
        //private static IEnumerable<ApiResponse> GetTflApiResponse(string roadId)
        //{
        //    var apiResponse = new List<ApiResponse>();
        //    const string appId = "c7d08eb2";
        //    const string appKey = "822328c4d06595431c207907ed980231";
        //    var baseUri = new UriBuilder("https://api.tfl.gov.uk/Road/");
        //    var roadIdToAppend = roadId + "?";
        //    var appIdToAppend = "app_id=" + appId;
        //    var appKeyToAppend = "app_key=" + appKey;

        //    //building the url
        //    var tflApiUrl = baseUri + roadIdToAppend + appIdToAppend + "&" + appKeyToAppend;

        //    using (var wc = new WebClient())
        //    {
        //        var jsonData = wc.DownloadString(tflApiUrl);

        //        var data = JsonConvert.DeserializeObject<List<ApiResponse>>(jsonData);
        //        foreach (var d in data)
        //        {
        //            apiResponse.Add(new ApiResponse
        //            {
        //                ApiType = d.ApiType,
        //                Id = d.Id,
        //                DisplayName = d.DisplayName,
        //                StatusSeverity = d.StatusSeverity,
        //                StatusSeverityDescription = d.StatusSeverityDescription,
        //                Bounds = d.Bounds,
        //                Envelope = d.Envelope,
        //                Url = d.Url
        //            });
        //        }
        //    }


        //    return apiResponse;
        //}
        //private static IEnumerable<ApiErrorResponse> GetTflApiErrorResponse(string roadId)
        //{
        //    var apiErrorResponse = new List<ApiErrorResponse>();


        //    const string appId = "c7d08eb2";
        //    const string appKey = "822328c4d06595431c207907ed980231";
        //    var baseUri = new UriBuilder("https://api.tfl.gov.uk/Road/");
        //    var roadIdToAppend = roadId + "?";
        //    var appIdToAppend = "app_id=" + appId;
        //    var appKeyToAppend = "app_key=" + appKey;

        //    //building the url
        //    var tflApiUrl = baseUri + roadIdToAppend + appIdToAppend + "&" + appKeyToAppend;

        //    try
        //    {
        //        using (var wc = new HttpClient())
        //        {
        //            var jsonData = wc.(tflApiUrl);

        //            var data = JsonConvert.DeserializeObject<List<ApiErrorResponse>>(jsonData);
        //            foreach (var d in data)
        //            {
        //                apiErrorResponse.Add(new ApiErrorResponse
        //                {
        //                    ApiType = d.ApiType,
        //                    ExceptionType = d.ExceptionType,
        //                    HttpStatus = d.HttpStatus,
        //                    HttpStatusCode = d.HttpStatusCode,
        //                    Message = d.Message,
        //                    RelativeUri = d.RelativeUri,
        //                    TimestampUtc = d.TimestampUtc


        //                });
        //            }
        //        }
        //    }
        //    catch (WebException webex)
        //    {
        //        using (var streamReader = new StreamReader(webex.Response.GetResponseStream()))
        //        {
        //            var htmlCode = streamReader.ReadToEnd();
        //        }
        //    }
           
        //    return apiErrorResponse;
        //}
        private async Task<string> GetApiResponse(string roadId)
        {
            string apiResponse;
            // ... Endpoint
            const string appId = "c7d08eb2";
            const string appKey = "822328c4d06595431c207907ed980231";
            var baseUri = new UriBuilder("https://api.tfl.gov.uk/Road/");
            var roadIdToAppend = roadId + "?";
            var appIdToAppend = "app_id=" + appId;
            var appKeyToAppend = "app_key=" + appKey;

            //building the url
            var tflApiUrl = baseUri + roadIdToAppend + appIdToAppend + "&" + appKeyToAppend;

            // ... Use HttpClient.
            using (var client = new HttpClient())
            using (var response = await client.GetAsync(tflApiUrl))
            using (var content = response.Content)
            {
                // ... Read the string.
                apiResponse = await content.ReadAsStringAsync();
                
            }

            return apiResponse;

        }

        /// <summary>
        /// Gets the valid road ids.
        /// </summary>
        /// <returns></returns>
        private List<string> GetValidRoadIds()
        {
            

            return new List<string>
            {
                "A1",
                "A2",
                "A3",
                "A4"

            };
        }
    }
}
