namespace SokolovskiyClinicService.DataHandler.Response
{
    public enum ResponseCode
    {
        Ok = 0,         // Все прошло без ошибок
        Warning = 1,    // Отработка с ошибкой, которая была предусмотрена
        Exception = 2,  // Отработка с исключением, которое не было предусмотрено 
    }
}