import {PostRequest} from "../GetAndPostRequest";
import {SessionForReservingDto, SessionToDeleting} from "../DataClasses";
import {Response} from "../Response";

class UserRepository{
    
    public ReserveSession(date: string, timeOfBegin: string, doctorId: number, userId: number): Promise<Response<number>>{
        const data = new SessionForReservingDto(date, timeOfBegin, doctorId, userId);
        return PostRequest("api/user/ReserveSession", data);
    }
    
    public UnreserveSession(sessionId: number): Promise<Response<void>>{
        return PostRequest("api/user/UnreserveSession", sessionId);
    }
}

const userRepository = new UserRepository();
export default userRepository;