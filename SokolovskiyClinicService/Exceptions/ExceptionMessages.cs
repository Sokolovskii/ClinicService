namespace SokolovskiyClinicService.Exceptions
{
    public static class ExceptionMessages
    {
        public const string UserNotFound = "Пользователь не был найден";
        public const string SessionNotFound = "Сеанс не был найден, повторите попытку";
        public const string DoctorNotFound = "Врач не был найден, повторите запрос";
        public const string DoctorHasntInBase = "Доктор отсутствует в базе, уточните запрос";
        public const string SessionHasntInBase = "Запись отсутствует в базе, уточните запрос";

        public const string LoginOrPasswordUncorrect =
            "Веден неверный логин или пароль, уточните данные и повторите запрос";

        public const string DateOfChangeWorkDayNotOptimal =
            "Невозможно сменить дату графика в связи с наличием конфликтующих записей, запросите оптимальную дату и повторите запрос";

        public const string UserWithThisLoginHasInBase =
            "Пользователь с таким логином уже существет в базе, смените логин и повторите запрос";

        public const string SessionOutSideTiming =
            "Вы попытались запичсаться во внерабочее время врача, укажите корректное время и повторите";

        public const string SessionWasReserved =
            "На данную время и дату уже забронирована запись, выберете другое дату и время и повторите попытку";

        public const string TimeOfWorkDayIsNonCorrect =
            "Указано время, которое находится за пределеами рабочего дня больницы";

        public const string WorkDayIsNotCorrect =
            "Время окончания рабочего дня указано как более раннее, чем время начала рабочего дня, проверьте корректность введенных данных и повторите попытку";

        public const string IsNotCurrentUser = "Вы пытаетесь отменить сессию, которую бронировали не вы";

        public const string Error = "Произошла ошибка, повторите запрос через какое-то время";

        public const string HasConflictSessions =
            "Невозможно уволить врача, поскольку спустя две недели после указанной даты имеются записи к данному врачу, выберете другую дату для удаления";
    }
}