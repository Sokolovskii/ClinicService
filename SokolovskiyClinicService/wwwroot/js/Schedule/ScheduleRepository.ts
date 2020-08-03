import {ScheduleFull} from "../DataClasses";
import {GetRequest} from "../GetAndPostRequest";
import {Response} from "../Response";


class ScheduleRepository{

    public GetSchedule(doctorId: number): Promise<Response<ScheduleFull>>{
        const data = {
            "doctorId": doctorId
        }
        return GetRequest("api/common/getDoctorSchedule", data);
    }
}

const scheduleRepository = new ScheduleRepository();
export default scheduleRepository;