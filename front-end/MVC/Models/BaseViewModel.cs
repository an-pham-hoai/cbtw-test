namespace MVC.Models
{
    public class BaseViewModel
    {
        public ApiSettings? ApiSettings { get; set; }

        public string ApiUrl
        {
            get
            {
                return ApiSettings?.BaseUrl ?? string.Empty;
            }
        }

        public BaseViewModel() { }

        public BaseViewModel(ApiSettings? apiSettings) { ApiSettings = apiSettings; }
    }
}
