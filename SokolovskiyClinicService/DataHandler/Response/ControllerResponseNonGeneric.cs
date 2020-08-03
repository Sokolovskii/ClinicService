using System.Runtime.Serialization;

namespace SokolovskiyClinicService.DataHandler.Response
{
    /// <summary>
    /// Класс ответа без передачи данных от сервера
    /// </summary>
    [DataContract]
    public class ControllerResponse
    {
        /// <summary>
        /// Код операции
        /// </summary>
        [DataMember(Name = "code")]
        public ResponseCode Code { get; protected set; }
        
        /// <summary>
        /// Сообщение клиенту
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; protected set; }

        /// <summary>
        /// Собирает успешный респонс
        /// </summary>
        
        public static ControllerResponse Ok()
        {
            return new ControllerResponse
            {
                Code = ResponseCode.Ok,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Собирает респонс с предупреждением
        /// </summary>
        public static ControllerResponse Warning(string message)
        {
            return new ControllerResponse
            {
                Code = ResponseCode.Warning,
                Message = message
            };
        }
        
        /// <summary>
        /// Собирает респонс с исключением
        /// </summary>
        public static ControllerResponse Exception(string message)
        {
            return new ControllerResponse
            {
                Code = ResponseCode.Exception,
                Message = message
            };
        }
    }
}