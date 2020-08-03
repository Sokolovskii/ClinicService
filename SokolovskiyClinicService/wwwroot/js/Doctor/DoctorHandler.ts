import doctorManager from "./DoctorManager";
import {parseWeekToDate, GetChangeWorkDayFromInputById, GetNewWorkDayFromInputById} from "../Helpers";
import {CloseAddNewProfessionModal} from "../Admin/AdminHandler";

const selectBlock = document.getElementById("selectNewProfession") as HTMLSelectElement;
if (selectBlock !== null) {
    const result = doctorManager.GetAllProfessions().then((result) => {
        if (typeof result === "string") {
            alert(result)
        } else {
            for (let i = 0; i < result.length; i++) {
                let text = result[i].name;
                let value = result[i].id.toString();
                selectBlock.options[selectBlock.options.length] = new Option(text, value);
            }
        }
    })
}

export function OpenNewScheduleModal() {
    (<HTMLDialogElement>document.getElementById("AddNewScheduleModal")).showModal();
}

export function CloseNewScheduleModal() {
    (<HTMLDialogElement>document.getElementById("AddNewScheduleModal")).close();
}

export function OpenAddOrUpdateScheduleModal() {
    (<HTMLDialogElement>document.getElementById("ChangeScheduleModal")).showModal()
}

export function CloseAddOrUpdateScheduleModal() {
    (<HTMLDialogElement>document.getElementById("ChangeScheduleModal")).close()
}

export function AddNewSchedule() {
    const monday = GetNewWorkDayFromInputById("monday");
    const tuesday = GetNewWorkDayFromInputById("tuesday");
    const wednesday = GetNewWorkDayFromInputById("wednesday");
    const thursday = GetNewWorkDayFromInputById("thursday");
    const friday = GetNewWorkDayFromInputById("friday");
    const saturday = GetNewWorkDayFromInputById("saturday");
    const sunday = GetNewWorkDayFromInputById("sunday");
    
    const result = doctorManager.AddNewSchedule(monday, tuesday, wednesday, thursday, friday, saturday, sunday).then((result) => {
        if(typeof result === "string"){
            document.getElementById("AddNewScheduleModalError").innerHTML = result;
        }
        else{
            CloseNewScheduleModal();
            location.reload();
        }
    });
}

export function AddOrUpdateSchedule() {
    const monday = GetChangeWorkDayFromInputById("monday");
    const tuesday = GetChangeWorkDayFromInputById("tuesday");
    const wednesday = GetChangeWorkDayFromInputById("wednesday");
    const thursday = GetChangeWorkDayFromInputById("thursday");
    const friday = GetChangeWorkDayFromInputById("friday");
    const saturday = GetChangeWorkDayFromInputById("saturday");
    const sunday = GetChangeWorkDayFromInputById("sunday");
    const actualisationDate = parseWeekToDate((<HTMLInputElement>document.getElementById("newActualisationDate")).value);

    const result = doctorManager.UpdateOrAddSchedule(monday, tuesday, wednesday, thursday, friday, saturday, sunday, actualisationDate).then((result) => {
        if(typeof result === "string") {
            document.getElementById("ChangeScheduleModalError").innerHTML = result;
        }
        else{
            CloseAddOrUpdateScheduleModal();
            location.reload();
        }
    });
}

export async function AddProfession() {
    const professionId = +selectBlock.value;
    const result =  doctorManager.AddProfession(professionId).then((result)=>{
        if(typeof result === "string") {
            document.getElementById("AddProfessionModalError").innerHTML = result;
        }
        else{
            CloseAddNewProfessionModal();
            location.reload();
        }
    });
}

document.getElementById("closeChangeScheduleModal").onclick = function () {
    CloseAddOrUpdateScheduleModal();
}

document.getElementById("submitChangeScheduleModal").onclick = function () {
    AddOrUpdateSchedule();
}