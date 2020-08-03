import userManager from "./UserManager";
import {GetElementValueById, GetElementTextById, GetFirstElementByClassName} from "../Helpers";
import {OpenCommonRegisterModal} from "../Authorization/AuthorizationHandler";
import {GetCookie} from "../Cookie";


if (document.getElementById("doctorIdSession") !== null && document.getElementById("dateForSessions") !== null) {
    const doctorIdElem = document.getElementById("doctorIdSession").innerText;
    const dateTime = GetElementValueById("dateForSessions");
    if (!window.location.href.includes(`Session?doctorId=${doctorIdElem}&dateTime=${dateTime}`))
        window.location.href = `Session?doctorId=${doctorIdElem}&dateTime=${dateTime}`
}

export function RedirectToSession(doctorId: number) {
    const dateTime = GetElementValueById("dateForSessions");
    window.location.href = `Session?doctorId=${doctorId}&dateTime=${dateTime}`
}

export function OpenReservingSubmitModal(event: Event) {
    const element = event.target as HTMLElement;
    element.className = "reservingSession";
    document.getElementById("doctorIdReserving").innerText = GetElementTextById("doctorIdSession");
    document.getElementById("doctorNameReserving").innerText = GetElementTextById("name").split(": ")[1];
    document.getElementById("TimeOfBeginSession").innerText = element.dataset.time;
    document.getElementById("DateOfSession").innerText = GetElementValueById("dateForSessions");
    document.getElementById("doctorProfessionReserving").innerText = GetElementTextById("profession").split(": ")[1];
    (<HTMLDialogElement>document.getElementById("ReservingInfoModal")).showModal();
}

export function OpenDeletingSubmitModal(event: Event) {
    const element = event.target as HTMLElement;
    element.className = "deletingSession"
    document.getElementById("sessionIdDeleting").innerText = element.dataset.sessionid
    document.getElementById("doctorNameDeleting").innerText = GetElementTextById("name").split(": ")[1];
    document.getElementById("TimeOfBeginDeleting").innerText = element.dataset.time;
    document.getElementById("DateOfSessionDeleting").innerText = GetElementValueById("dateForSessions");
    document.getElementById("doctorProfessionDeleting").innerText = GetElementTextById("profession").split(": ")[1];
    (<HTMLDialogElement>document.getElementById("DeletingInfoModal")).showModal();

}

export function CloseReservingSubmitModal() {
    if (GetFirstElementByClassName("reservingSession") !== undefined) {
        GetFirstElementByClassName("reservingSession").className = "sessionRowBoxFree";
    }
    (<HTMLDialogElement>document.getElementById("ReservingInfoModal")).close();
}

export function CloseDeletingSubmitModal() {
    if (GetFirstElementByClassName("deletingSession") !== undefined) {
        GetFirstElementByClassName("deletingSession").className = "sessionRowBoxReservedByUser";
    }
    (<HTMLDialogElement>document.getElementById("DeletingInfoModal")).close();
}

export function ReserveSession() {
    const element = GetFirstElementByClassName("reservingSession");
    const date = document.getElementById("DateOfSession").innerText;
    const time = document.getElementById("TimeOfBeginSession").innerText;
    const doctorId = +document.getElementById("doctorIdReserving").innerText;

    const response = userManager.ReserveSession(date, time, doctorId).then((response) => {
        if (typeof response === "number") {
            element.className = "sessionRowBoxReservedByUser";
            element.dataset.sessionid = response.toString();
            element.innerHTML = "Занято вами";
            element.onclick = function (event) {
                OpenDeletingSubmitModal(event);
            }
            CloseReservingSubmitModal();
        } else {
            document.getElementById("ReservingInfoModalError").innerHTML = response
        }
    });
}

export function UnreserveSession() {
    const element = GetFirstElementByClassName("deletingSession");
    const sessionId = +document.getElementById("sessionIdDeleting").innerText;

    const result = userManager.UnreserveSession(sessionId).then((result) => {
        if (typeof result !== "string") {
            element.className = "sessionRowBoxFree"
            element.dataset.sessionid = "";
            element.onclick = function (event) {
                OpenReservingSubmitModal(event);
            }
            element.innerHTML = "";
            CloseDeletingSubmitModal();
        } else {
            document.getElementById("DeletingInfoModalError").innerHTML = result;
        }
    });
}










