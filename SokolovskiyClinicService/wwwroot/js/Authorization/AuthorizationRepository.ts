import {PostRequest} from "../GetAndPostRequest";
import {Response} from "../Response";
import {AuthorizedUser, UserToLogIn, UserToSignIn} from "../DataClasses";

class AuthorizationRepository {

    public GiveUserToLogIn(login: string, password: string): Promise<Response<void|string>> {
        const data = new UserToLogIn(login, password)
        return PostRequest("api/authorization/LogIn", data);
    }

    public GiveUserToSignIn(name: string, login: string, password: string, isDoctorFlag: boolean): Promise<Response<void|string>>{
        const data= new UserToSignIn(name, login, password, isDoctorFlag)
        return PostRequest("api/authorization/SignIn", data);
    }
    
    public LogOut(){
        return PostRequest("api/authorization/LogOut");
    }
}

const authorizationRepository = new AuthorizationRepository();
export default authorizationRepository;