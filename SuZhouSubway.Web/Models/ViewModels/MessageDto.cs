namespace SuZhouSubway.Web.Models.ViewModels
{
    /// <summary>
    /// 消息模型，目前仅用于文件上传
    /// </summary>
    public class MessageDto
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public static MessageDto Fail(string message = "失败")
        {
            return new MessageDto()
            {
                Message = message,
                IsSuccess = false
            };
        }

        public static MessageDto Success(string message = "成功")
        {
            return new MessageDto()
            {
                Message = message,
                IsSuccess = true
            };
        }
    }

    public class MessageDto<T> : MessageDto
    {
        public T Data { get; set; }

        public static MessageDto<T> Fail(T data, string message = "失败")
        {
            return new MessageDto<T>()
            {
                Message = message,
                IsSuccess = false,
                Data = data
            };
        }

        public static MessageDto<T> Success(T data, string message = "成功")
        {
            return new MessageDto<T>()
            {
                Message = message,
                IsSuccess = true,
                Data = data
            };
        }
    }

    public class FileUploadDto
    {
        public int Errno { get; set; }

        public string[] Data { get; set; }

        public string Message { get; set; }
    }
}