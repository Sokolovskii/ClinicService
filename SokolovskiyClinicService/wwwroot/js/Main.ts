import {SetAllProfessions} from "./Helpers";
if(document.getElementById("selectDoctorsNavBar")!=null){
    SetAllProfessions();
}

export function ViewDoctors(){
    const professionId = (<HTMLSelectElement>document.getElementById("selectDoctorsNavBar")).value
    location.href = `DoctorsForUser?professionId=${professionId}`;
}





