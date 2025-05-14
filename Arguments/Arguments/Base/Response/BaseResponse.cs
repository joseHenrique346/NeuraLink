namespace Arguments.Arguments.Base.Response
{
    public class BaseResponse<TContent>
    {
        #region Properties
        public bool isSuccess { get; set; }
        public List<string>? MessageErrors { get; set; } = new List<string>();
        public TContent? Content { get; set; }
        #endregion

        #region Constructors
        public BaseResponse(bool isSuccess, List<string>? messageErrors, TContent? content)
        {
            this.isSuccess = isSuccess;
            MessageErrors = messageErrors;
            Content = content;
        }

        public BaseResponse() { }
        #endregion
    }
}