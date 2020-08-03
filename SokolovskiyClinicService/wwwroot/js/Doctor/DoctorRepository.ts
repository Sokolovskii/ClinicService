import {Profession, Schedule, ScheduleToAddingDto, WorkDayDto} from '../DataClasses';
import {GetRequest, PostRequest} from "../GetAndPostRequest";
import {Response} from "../Response";

class DoctorRepository{
    public AddNewSchedule(monday: WorkDayDto, tuesday: WorkDayDto, wednesday: WorkDayDto, thursday: WorkDayDto, friday: WorkDayDto, saturday: WorkDayDto, sunday: WorkDayDto): Promise<Response<void>>{
        const data = new ScheduleToAddingDto(monday, tuesday, wednesday, thursday, friday, saturday, sunday);
        return PostRequest("api/doctor/AddNewSchedule", data);
    }
    
    public UpdateOrAddSchedule(monday: WorkDayDto, tuesday: WorkDayDto, wednesday: WorkDayDto, thursday: WorkDayDto, friday: WorkDayDto, saturday: WorkDayDto, sunday: WorkDayDto, actualisationDate: string): Promise<Response<void>>{
        const data = new Schedule(monday, tuesday, wednesday, thursday, friday,saturday, sunday, actualisationDate);
        return PostRequest("api/doctor/AddOrUpdateSchedule", data);
    }
    
    public AddProfession(professionId:number): Promise<Response<void>>{
        return PostRequest("api/doctor/AddProfession", professionId);
    }
    
    public GetAllProfessions(): Promise<Response<Profession[]>>{
        return GetRequest<Profession[]>("api/common/getAllProfessions")
    }
}

const doctorRepository = new DoctorRepository();
export default doctorRepository;