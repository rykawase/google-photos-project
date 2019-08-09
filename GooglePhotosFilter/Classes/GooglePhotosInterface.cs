using GooglePhotosFilter.Classes.Albums;
using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GooglePhotosFilter.Classes.Error;
using GooglePhotosFilter.Classes.Media;

namespace GooglePhotosFilter.Classes
{
    public class GooglePhotosInterface
    {
        private string accessToken = string.Empty;

        private List<string> listPageToken = new List<string>();
        private int counterIndexPageToken = 0;

        private static readonly GooglePhotosInterface instance = new GooglePhotosInterface();

        public static GooglePhotosInterface Instance
        {
            get
            {
                return instance;
            }
        }

        public void SetToken(string token)
        {
            this.accessToken = token;
        }

        public string GetToken()
        {
            return this.accessToken;
        }

        public ResultMediaItems ListNextMediaItems(string albumId = "")
        {
            ResultMediaItems resultListMediaItems = new ResultMediaItems();

            try
            {
                Dictionary<string, string> dictParam = new Dictionary<string, string>();
                dictParam.Add("pageSize", "100");

                if (albumId != string.Empty)
                {
                    dictParam.Add("albumId", albumId);
                    resultListMediaItems = CallListMediaGooglePhotosApi(GoogleConstants.URL_SEARCH_MEDIA_ITEMS, Method.POST, dictParam);
                }
                else
                {
                    if(counterIndexPageToken < listPageToken.Count - 1)
                        counterIndexPageToken++;

                    string pageToken = listPageToken.ElementAt(counterIndexPageToken);

                    dictParam.Add("pageToken", pageToken);
                    resultListMediaItems = CallListMediaGooglePhotosApi(GoogleConstants.URL_LIST_MEDIA_ITEMS, Method.GET, dictParam);
                }
            }
            catch(Exception ex)
            {

            }

            return resultListMediaItems;
        }

        public ResultMediaItems ListPreviousMediaItems(string albumId = "")
        {
            ResultMediaItems resultListMediaItems = new ResultMediaItems();

            try
            {
                Dictionary<string, string> dictParam = new Dictionary<string, string>();
                dictParam.Add("pageSize", "100");

                if (albumId != string.Empty)
                {
                    dictParam.Add("albumId", albumId);
                    resultListMediaItems = CallListMediaGooglePhotosApi(GoogleConstants.URL_SEARCH_MEDIA_ITEMS, Method.POST, dictParam);
                }
                else
                {
                    if (counterIndexPageToken > 0)
                        counterIndexPageToken--;

                    string pageToken = listPageToken.ElementAt(counterIndexPageToken);

                    dictParam.Add("pageToken", pageToken);
                    resultListMediaItems = CallListMediaGooglePhotosApi(GoogleConstants.URL_LIST_MEDIA_ITEMS, Method.GET, dictParam);
                }
            }
            catch (Exception ex)
            {

            }

            return resultListMediaItems;
        }
    
        public ResultMediaItems ListMediaItems(string albumId = "")
        {
            ResultMediaItems resultListMediaItems = new ResultMediaItems();

            try
            {
                counterIndexPageToken = 0;

                listPageToken = new List<string>();
                listPageToken.Add(string.Empty);

                Dictionary<string, string> dictParam = new Dictionary<string, string>();
                dictParam.Add("pageSize", "100");

                if(albumId != string.Empty)
                {
                    dictParam.Add("albumId", albumId);
                    resultListMediaItems = CallListMediaGooglePhotosApi(GoogleConstants.URL_SEARCH_MEDIA_ITEMS, Method.POST, dictParam);
                }
                else
                {
                    resultListMediaItems = CallListMediaGooglePhotosApi(GoogleConstants.URL_LIST_MEDIA_ITEMS, Method.GET, dictParam);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }

            return resultListMediaItems;
        }
        
        public ResultAlbums ListAlbums()
        {
            ResultAlbums resultListAlbums = new ResultAlbums();
            List<AlbumData> listAlbums = new List<AlbumData>();

            try
            {
                Uri uri = new Uri(GoogleConstants.URL_LIST_ALBUMS);

                RestClient client = new RestClient(uri);
                RestRequest request = new RestRequest(Method.GET);
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Authorization", "Bearer " + this.accessToken);
                                
                bool hasMoreAlbums = true;

                while(hasMoreAlbums)
                {
                    IRestResponse response = client.Execute(request);

                    if (response.IsSuccessful)
                    {
                        ResultAlbums resultAlbums = JsonConvert.DeserializeObject<ResultAlbums>(response.Content);
                        listAlbums.AddRange(resultAlbums.Albums);

                        resultListAlbums.ResultCode = response.StatusCode.ToString();
                        resultListAlbums.ResultMessage = (response.ErrorMessage == "null") ? string.Empty : response.ErrorMessage;

                        if (resultAlbums.NextPageToken != null)
                        {
                            request.AddParameter("pageToken", resultAlbums.NextPageToken);
                        }                            
                        else
                        {
                            resultListAlbums.Albums = listAlbums;
                            hasMoreAlbums = false;
                        }                            
                    }
                    else
                    {
                        ResultError resultError = JsonConvert.DeserializeObject<ResultError>(response.Content);
                        resultListAlbums.ResultCode = response.StatusCode.ToString();
                        resultListAlbums.ResultMessage = (resultError.Error != null) ? resultError.Error.Message : "Erro";
                        hasMoreAlbums = false;
                    }
                }


            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }

            return resultListAlbums;
        }

        private ResultMediaItems CallListMediaGooglePhotosApi(string url, Method method, Dictionary<string, string> dictParam)
        {
            IRestResponse response = null;
            ResultMediaItems resultListMediaItems = new ResultMediaItems();

            try
            {
                Uri uri = new Uri(url);

                RestClient client = new RestClient(uri);
                RestRequest request = new RestRequest(method);
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Authorization", "Bearer " + this.accessToken);

                for (int i = 0; i < dictParam.Count; i++ )
                {
                    request.AddParameter(dictParam.ElementAt(i).Key, dictParam.ElementAt(i).Value);
                }

                response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    ResultMediaItems resultMediaItems = JsonConvert.DeserializeObject<ResultMediaItems>(response.Content);
                    resultListMediaItems.MediaItems = resultMediaItems.MediaItems;
                    resultListMediaItems.ResultCode = response.StatusCode.ToString();
                    resultListMediaItems.ResultMessage = (response.ErrorMessage == "null") ? string.Empty : response.ErrorMessage;

                    if (resultMediaItems.NextPageToken != null &&
                        resultMediaItems.NextPageToken != string.Empty &&
                        !listPageToken.Contains(resultMediaItems.NextPageToken))
                    {
                        resultListMediaItems.HasNextPage = true;
                        listPageToken.Add(resultMediaItems.NextPageToken);
                    }
                    else
                    {
                        resultListMediaItems.HasNextPage = false;
                    }

                    if (counterIndexPageToken == 0)
                        resultListMediaItems.HasPreviousPage = false;
                    else
                        resultListMediaItems.HasPreviousPage = true;
                }
                else
                {
                    ResultError resultError = JsonConvert.DeserializeObject<ResultError>(response.Content);
                    resultListMediaItems.ResultCode = response.StatusCode.ToString();
                    resultListMediaItems.ResultMessage = (resultError.Error != null) ? resultError.Error.Message : "Erro";
                }
            }
            catch(Exception ex)
            {
                resultListMediaItems = new ResultMediaItems();
            }

            return resultListMediaItems;
        }
    }
}
