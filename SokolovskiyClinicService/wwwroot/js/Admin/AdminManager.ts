import adminRepository from "./AdminRepository";
import {ReturnResponse} from "../Helpers";
import {Response} from "../Response";
import {Profession, WorkDayDto} from "../DataClasses";

class AdminManager {
    public ChangeScheduleModal = document.getElementById("ChangeScheduleModal") as HTMLDialogElement;
    
    public async DeleteDoctor(doctorId: number, dateOfDismissal: string): Promise<Response<string>>{
        const result = await adminRepository.DeleteDoctor(doctorId, dateOfDismissal);
        if(ReturnResponse(result))
            return result
    }
    
    public async ChangeDoctorSchedule(doctorId: number, monday: WorkDayDto, tuesday: WorkDayDto, wednesday: WorkDayDto, thursday: WorkDayDto, friday: WorkDayDto, saturday: WorkDayDto, sunday: WorkDayDto, actualisationDate: string): Promise<void|string>{
        const result = await adminRepository.ChangeDoctorSchedule(doctorId, monday, tuesday, wednesday, thursday, friday, saturday, sunday, actualisationDate);
        return ReturnResponse(result)
    }
    
    public OpenChangeModal(doctorId: string, doctorName: string, newDate: string){
        document.getElementById("doctorName").innerText = doctorName;
        document.getElementById("doctorId").innerText = doctorId;
        (<HTMLInputElement>document.getElementById("newActualisationDate")).value = newDate;
        this.ChangeScheduleModal.showModal();
    }

    public CloseChangeModal(){
        this.ChangeScheduleModal.close();
    }
    
    public async ApproveDoctor(doctorId: number): Promise<void|string>{
        const result = await adminRepository.ApproveDoctor(doctorId);
        return ReturnResponse(result)
    }

    public async DisapproveDoctor(doctorId: number): Promise<void|string>{
        const result = await adminRepository.DisapproveDoctor(doctorId);
        return ReturnResponse(result)
    }

    public async AddNewProfession(professionName: string): Promise<void|string>{
        const result = await adminRepository.AddNewProfession(professionName);
        return ReturnResponse(result)
    }
    
    public async GetProfession(doctorId: number): Promise<Profession|string> {
        const result = await adminRepository.GetProfession(doctorId);
        return ReturnResponse(result)
    }
}

const adminManager = new AdminManager();
export default adminManager;