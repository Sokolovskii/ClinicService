import userRepository from "./UserRepository";
import {ReturnResponse} from "../Helpers";

class UserManager{
    
    public modal = document.getElementById("UserSubmitModal") as HTMLDialogElement;
    
    public async ReserveSession(date: string, timeOfBegin: string, doctorId: number): Promise<number|string> {
        const userId = +localStorage.getItem("id");
        const result = await userRepository.ReserveSession(date, timeOfBegin, doctorId, userId);
        return ReturnResponse(result)
    }
    
    public async UnreserveSession(sessionId: number): Promise<void|string>{
        const userId = +localStorage.getItem("id");
        const result = await userRepository.UnreserveSession(sessionId);
        return ReturnResponse(result)
    }
    
    public OpenModal(): void{
        this.modal.showModal();
    }
    
    public CloseModal(): void{
        this.modal.close();
    }
}

const userManager = new UserManager();
export default userManager;