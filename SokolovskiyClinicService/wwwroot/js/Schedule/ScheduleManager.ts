import scheduleRepository from "../Schedule/ScheduleRepository";
import {ScheduleFull} from "../DataClasses";
import {ReturnResponse} from "../Helpers";

class ScheduleManager{
    public async GetSchedule(doctorId: number): Promise<ScheduleFull|string>{
        const result = await scheduleRepository.GetSchedule(doctorId);
        return ReturnResponse(result)
    }
}

const scheduleManager = new ScheduleManager();
export default scheduleManager;
