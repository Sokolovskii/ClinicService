import {GetRequest, PostRequest} from "../GetAndPostRequest";
import {DoctorToDeletingDto, Profession, ScheduleFull, WorkDayDto} from "../DataClasses";
import {Response} from "../Response";

class AdminRepository {

    public DeleteDoctor(doctorId: number, dateOfDismissal: string): Promise<Response<string>> {
        const data = new DoctorToDeletingDto(doctorId, dateOfDismissal)
        return PostRequest("api/admin/DeleteDoctor", data);
    }

    public ChangeDoctorSchedule(doctorId: number, monday: WorkDayDto, tuesday: WorkDayDto, wednesday: WorkDayDto, thursday: WorkDayDto, friday: WorkDayDto, saturday: WorkDayDto, sunday: WorkDayDto, actualisationDate: string): Promise<Response<void>>{
        
        const data = new ScheduleFull(doctorId, monday, tuesday, wednesday, thursday, friday,saturday, sunday, actualisationDate);
        return PostRequest("api/admin/ChangeDoctorSchedule", data);
    }
    
    public GetProfession(doctorId: number): Promise<Response<Profession>>{
        const data={
            "doctorId": doctorId
        }
        return GetRequest<Profession>("api/common/getProfessionByDoctorId", data);
    }
    
    public ApproveDoctor(doctorId: number): Promise<Response<void>>{
        return PostRequest("api/admin/ApproveDoctor", doctorId);
    }
    
    public DisapproveDoctor(doctorId: number): Promise<Response<void>>{
        return PostRequest("api/admin/DisapproveDoctor", doctorId);
    }
    
    public AddNewProfession(professionName: string): Promise<Response<void>>{
        return PostRequest("api/admin/AddNewProfession", professionName);
    }
    
}

const adminRepository = new AdminRepository();
export default adminRepository;