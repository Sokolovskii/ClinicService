import authorizationRepository from "./AuthorizationRepository";
import {ReturnResponse} from "../Helpers";


class AuthorizationManager{
    
    public async LogIn(login: string, password: string): Promise<void|string>{
        const result = await authorizationRepository.GiveUserToLogIn(login, password);
        return ReturnResponse(result)
    }
    
    public async SignIn(name: string, login: string, password: string, confirmPassword: string, isDoctorFlag: boolean): Promise<void|string>{
        if(password === confirmPassword){
            const result = await authorizationRepository.GiveUserToSignIn(name ,login, password, isDoctorFlag);
            return ReturnResponse(result)
        }
        else return "Пароли не совпадают, проверьте правильность данных и повторите попытку";
    }
    
    public OpenLogInModal(): void{
        (<HTMLDialogElement>document.getElementById("LogInModal")).showModal();
    }
    
    public CloseLogInModal(): void{
        (<HTMLDialogElement>document.getElementById("LogInModal")).close();
    }

    public OpenRegistrationModal(): void{
        (<HTMLDialogElement>document.getElementById("RegistrationModal")).showModal();
    }

    public CloseRegistrationModal(): void{
        (<HTMLDialogElement>document.getElementById("RegistrationModal")).close();
    }
    
    public OpenCommonAuthorizationModal(): void{
        (<HTMLDialogElement>document.getElementById("LogInAndRegisterModal")).showModal();
    }

    public CloseCommonAuthorizationModal(): void{
        (<HTMLDialogElement>document.getElementById("LogInAndRegisterModal")).close();
    }
}

const authorizationManager = new AuthorizationManager();
export default authorizationManager;