import adminManager from './AdminManager'
import {
    ReturnResponse,
    GetElementValueById,
    GetFirstElementByClassName, GetChangeWorkDayFromInputById,
    parseDate, parseWeekToDate
} from "../Helpers";
import scheduleManager from "../Schedule/ScheduleManager";

export function OpenChangeModal(doctorId: number, doctorName: string) {
    (<HTMLDialogElement>document.getElementById("ChangeScheduleModal")).showModal();
}

export function CloseChangeModal() {
    (<HTMLDialogElement>document.getElementById("ChangeScheduleModal")).close();
}

export async function ChangeSchedule() {
    const doctorId = +document.getElementById("doctorId");

    const monday = GetChangeWorkDayFromInputById("monday");
    const tuesday = GetChangeWorkDayFromInputById("tuesday");
    const wednesday = GetChangeWorkDayFromInputById("wednesday");
    const thursday = GetChangeWorkDayFromInputById("thursday");
    const friday = GetChangeWorkDayFromInputById("friday");
    const saturday = GetChangeWorkDayFromInputById("saturday");
    const sunday = GetChangeWorkDayFromInputById("sunday");

    const actualisationDate = parseWeekToDate((<HTMLInputElement>document.getElementById("newActualisationDate")).value);
    const result = adminManager.ChangeDoctorSchedule(doctorId, monday, tuesday, wednesday, thursday, friday, saturday, sunday, actualisationDate).then((result) => {
        if (typeof result === "string") {
            document.getElementById("ChangeScheduleModalError").innerHTML = result;
        } else {
            CloseChangeModal();
        }
    });
}

export function DeleteDoctor() {
    const element = GetFirstElementByClassName("doctorDeleteMarked");
    const doctorId = +document.getElementById("doctorIdDelete").innerText;
    const dateOfDismissal = GetElementValueById("dateOfDismissal");
    const response = adminManager.DeleteDoctor(doctorId, dateOfDismissal).then((response) => {
        const answer = ReturnResponse(response);
        if (typeof answer !== "string") {
            const newElement = element.parentElement;
            element.remove();
            newElement.className = "dissmised";
            newElement.innerHTML = "Врач будет уволен " + response.data;
            CloseDeleteModal();
        } else {
            document.getElementById("dismissModalError").innerHTML = answer;
        }
    })
}

export function OpenDeleteModal(event: Event) {
    document.getElementById("doctorNameDelete").innerHTML = (<HTMLElement>event.target).parentElement.parentElement.childNodes[1].textContent;
    document.getElementById("doctorIdDelete").innerHTML = (<HTMLElement>event.target).dataset.doctorid;
    (<HTMLInputElement>document.getElementById("dateOfDismissal")).value = parseDate(new Date().toLocaleDateString());
    (<HTMLElement>event.target).className = "doctorDeleteMarked";
    (<HTMLDialogElement>document.getElementById("dismissModal")).showModal();
}

export function CloseDeleteModal() {
    document.getElementById("dismissModalError").innerHTML = "";
    GetFirstElementByClassName("doctorDeleteMarked").removeAttribute("class");
    (<HTMLDialogElement>document.getElementById("dismissModal")).close();
}

export async function OpenDoctorInfoModal(doctorId: number, doctorName: string) {
    document.getElementById("doctorInfoId").innerHTML = doctorId.toString();
    document.getElementById("doctorNameApprove").innerHTML = doctorName;
    const profession = await adminManager.GetProfession(doctorId);
    const schedule = await scheduleManager.GetSchedule(doctorId);
    if (typeof profession === "string") {
        document.getElementById("approveError").innerHTML += profession;
        document.getElementById("professionNameApprove").innerHTML = "Не указана";
        (<HTMLButtonElement>document.getElementById("ApproveDoctor")).disabled = true;
    }
    if (typeof schedule === "string") {
        document.getElementById("approveError").innerHTML += schedule;
        document.getElementById("scheduleInfo").innerHTML += " : Не указана";
        document.getElementById("scheduleInfoTable").className = "invisible";
        (<HTMLButtonElement>document.getElementById("ApproveDoctor")).disabled = true;
    }
    if (typeof profession !== "string" && typeof schedule !== "string") {
        document.getElementById("scheduleInfoTable").removeAttribute("class");
        document.getElementById("approveError").innerHTML = "";
        document.getElementById("professionNameApprove").innerHTML = profession.name;

        if (schedule.monday !== null) {
            document.getElementById("mondayBeginApprove").innerHTML = schedule.monday.beginOfDay;
            document.getElementById("mondayEndApprove").innerHTML = schedule.monday.endOfDay;
        }

        if (schedule.tuesday !== null) {
            document.getElementById("tuesdayBeginApprove").innerHTML = schedule.tuesday.beginOfDay;
            document.getElementById("tuesdayEndApprove").innerHTML = schedule.tuesday.endOfDay;
        }

        if (schedule.wednesday !== null) {
            document.getElementById("wednesdayBeginApprove").innerHTML = schedule.wednesday.beginOfDay;
            document.getElementById("wednesdayEndApprove").innerHTML = schedule.wednesday.endOfDay;
        }

        if (schedule.thursday !== null) {
            document.getElementById("thursdayBeginApprove").innerHTML = schedule.thursday.beginOfDay;
            document.getElementById("thursdayEndApprove").innerHTML = schedule.thursday.endOfDay;
        }

        if (schedule.friday !== null) {
            document.getElementById("fridayBeginApprove").innerHTML = schedule.friday.beginOfDay;
            document.getElementById("fridayEndApprove").innerHTML = schedule.friday.endOfDay;
        }

        if (schedule.saturday !== null) {
            document.getElementById("saturdayBeginApprove").innerHTML = schedule.saturday.beginOfDay;
            document.getElementById("saturdayEndApprove").innerHTML = schedule.saturday.endOfDay;
        }

        if (schedule.sunday !== null) {
            document.getElementById("sundayBeginApprove").innerHTML = schedule.sunday.beginOfDay;
            document.getElementById("sundayEndApprove").innerHTML = schedule.sunday.endOfDay;
        }

        (<HTMLButtonElement>document.getElementById("ApproveDoctor")).disabled = false;
    }
    (<HTMLDialogElement>document.getElementById("DoctorInfoModal")).showModal();
}

export function CloseDoctorInfoModal() {
    document.getElementById("mondayBeginApprove").innerHTML = "";
    document.getElementById("mondayEndApprove").innerHTML = "";

    document.getElementById("tuesdayBeginApprove").innerHTML = "";
    document.getElementById("tuesdayEndApprove").innerHTML = "";
    
    document.getElementById("wednesdayBeginApprove").innerHTML = "";
    document.getElementById("wednesdayEndApprove").innerHTML = "";
    
    document.getElementById("thursdayBeginApprove").innerHTML = "";
    document.getElementById("thursdayEndApprove").innerHTML = "";
    
    document.getElementById("fridayBeginApprove").innerHTML = "";
    document.getElementById("fridayEndApprove").innerHTML = "";
    
    document.getElementById("saturdayBeginApprove").innerHTML = "";
    document.getElementById("saturdayEndApprove").innerHTML = "";
    
    document.getElementById("sundayBeginApprove").innerHTML = "";
    document.getElementById("sundayEndApprove").innerHTML = "";
    
    document.getElementById("approveError").innerHTML = "";
    document.getElementById("scheduleInfo").innerHTML = "Расписание врача";

    (<HTMLDialogElement>document.getElementById("DoctorInfoModal")).close();
}

export function ApproveDoctor() {
    const doctorId = +document.getElementById("doctorInfoId").innerHTML;
    const result = adminManager.ApproveDoctor(doctorId).then((result) => {
        if (typeof result === "string") {
            document.getElementById("DoctorInfoModalError").innerHTML = result;
        } else {
            CloseDoctorInfoModal();
        }
    });
}

export async function DisapproveDoctor() {
    const doctorId = +document.getElementById("doctorInfoId").innerHTML;
    const result = adminManager.DisapproveDoctor(doctorId).then((result) => {
        if (typeof result === "string") {
            document.getElementById("DoctorInfoModalError").innerHTML = result;
        } else {
            CloseDoctorInfoModal();
        }
    });
}

export function OpenAddNewProfessionModal() {
    (<HTMLDialogElement>document.getElementById("AddNewProfessionModal")).showModal();
}

export function CloseAddNewProfessionModal() {
    (<HTMLDialogElement>document.getElementById("AddNewProfessionModal")).close();
}

export function AddNewProfession() {
    const professionName = GetElementValueById("NewProfessionName");
    const result = adminManager.AddNewProfession(professionName).then((result) => {
        if (typeof result === "string") {
            document.getElementById("AddNewProfessionModalError").innerHTML = result;
        } else {
            CloseAddNewProfessionModal();
        }
    });
}

document.getElementById("submitChangeScheduleModal").onclick = function () {
    ChangeSchedule()
}

document.getElementById("closeChangeScheduleModal").onclick = function () {
    CloseChangeModal();
}



