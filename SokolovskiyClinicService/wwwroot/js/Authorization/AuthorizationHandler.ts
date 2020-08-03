import authorizationManager from "./AuthorizationManager";
import {GetElementValueById} from "../Helpers";

export function CloseLogInModal() {
    authorizationManager.CloseLogInModal();
    (<HTMLInputElement>document.getElementById("loginInput")).value = "";
    (<HTMLInputElement>document.getElementById("passwordInput")).value = "";
}

export function CloseRegistrationModal() {
    authorizationManager.CloseRegistrationModal();
}

export function OpenRegistrationModal() {
    authorizationManager.OpenRegistrationModal();
}

export function OpenLogInModal () {
    authorizationManager.OpenLogInModal()
}

export async function LogIn() {
    const login = GetElementValueById("loginInput");
    const password = GetElementValueById("passwordInput")
    const result = authorizationManager.LogIn(login, password).then((result)=>{
        if(typeof result === "string"){
            document.getElementById("LogInModalError").innerHTML = result;
        }
        else{
            CloseLogInModal();
            window.location.href="/";
        }
    });
}

export async function SignIn() {
    const name = GetElementValueById("nameRegister");
    const login = GetElementValueById("loginRegister");
    const password = GetElementValueById("passwordRegister");
    const confirmPassword = GetElementValueById("ConfirmPasswordRegister");
    const isDoctor = <HTMLInputElement>document.getElementById("IsDoctorCheckbox");
    let isDoctorFlag:boolean = false;
    if(isDoctor.checked){
        isDoctorFlag = true;
    }
    const result = authorizationManager.SignIn(name, login, password, confirmPassword, isDoctorFlag).then((result)=>{
        if(typeof result === "string"){
            document.getElementById("RegistrationModalError").innerHTML = result;
        }
        else{
            CloseRegistrationModal();
            window.location.href="/";
        }
    });
}

export function OpenCommonRegisterModal() {
    authorizationManager.OpenCommonAuthorizationModal();
}

export function CloseCommonRegisterModal() {
    authorizationManager.CloseCommonAuthorizationModal();
}


