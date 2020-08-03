using System.Runtime.Serialization;

namespace SokolovskiyClinicService.DataHandler.Response
{
    /// <summary>
    /// Класс ответа с данными от сервера
    /// </summary>
    [DataContract]
    public class ControllerResponse<T> : ControllerResponse
    {
        /// <summary>
        /// Данные для передачи
        /// </summary>
        [DataMember(Name="data")]
        public T Data { get; private set; }

        /// <summary>
        /// Собирает успешный респонс с передачей данных
        /// </summary>
        public static ControllerResponse<T> Ok(T data)
        {
            return new ControllerResponse<T>
            {
                Code = ResponseCode.Ok,
                Data = data,
                Message = string.Empty
            };
        }
        
        /// <summary>
        /// Собирает респонс с предупреждением
        /// </summary>
        public new static ControllerResponse<T> Warning(string message)
        {
            return new ControllerResponse<T>
            {
                Code = ResponseCode.Warning,
                Message = message,
                Data = default
            };
        }
        
        /// <summary>
        /// Собирает респонс с исключением
        /// </summary>
        public static ControllerResponse<T> Exception()
        {
            return new ControllerResponse<T>
            {
                Code = ResponseCode.Exception,
                Message = string.Empty,
                Data = default
            };
        }
    }
}