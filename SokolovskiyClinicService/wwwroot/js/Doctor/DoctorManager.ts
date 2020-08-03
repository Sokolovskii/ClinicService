import doctorRepository from "./DoctorRepository";
import {Profession, WorkDayDto} from "../DataClasses";
import {ReturnResponse} from "../Helpers";

class DoctorManager{
    public async AddNewSchedule(monday: WorkDayDto, tuesday: WorkDayDto, wednesday: WorkDayDto, thursday: WorkDayDto, friday: WorkDayDto, saturday: WorkDayDto, sunday: WorkDayDto): Promise<void|string>{
        const result = await doctorRepository.AddNewSchedule(monday, tuesday, wednesday, thursday, friday, saturday, sunday);
        return ReturnResponse(result)
    }
    
    public async UpdateOrAddSchedule(monday: WorkDayDto, tuesday: WorkDayDto, wednesday: WorkDayDto, thursday: WorkDayDto, friday: WorkDayDto, saturday: WorkDayDto, sunday: WorkDayDto, actualisationDate: string): Promise<void|string>{
        const result = await doctorRepository.UpdateOrAddSchedule(monday, tuesday, wednesday, thursday, friday, saturday, sunday, actualisationDate);
        return ReturnResponse(result)
    }
    
    public async AddProfession(professionId:number): Promise<void|string>{
        const result = await doctorRepository.AddProfession(professionId);
        return ReturnResponse(result);
    }
    
    public async GetAllProfessions(): Promise<Profession[]|string>{
        const result = await doctorRepository.GetAllProfessions();
        return ReturnResponse(result)
    }
}

const doctorManager = new DoctorManager();
export default doctorManager;