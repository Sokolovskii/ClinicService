import {GetRequest} from "./GetAndPostRequest";
import {Profession, WorkDayDto} from "./DataClasses";
import {Response, ResponseCode} from "./Response";

export function formatDate(date: Date): string {
    let dd = date.getDate().toString();
    if (+dd < 10) dd = '0' + dd;

    let mm = (date.getMonth() + 1).toString();
    if (+mm < 10) mm = '0' + mm;

    let yy = date.getFullYear().toString();
    if (+yy < 10) yy = '0' + yy;

    return yy + '-' + mm + '-' + dd;
}

export function ReturnResponse<T>(response: Response<T>): T|string {
    if(response.code===ResponseCode.Ok){
        return response.data;
    }
    else if(response.code===ResponseCode.Warning){
        return response.message;
    }
    else return "Произошел сбой, перезагрузите страницу и повторите запрос через несколько минут";
}


export function parseTime(time: string): string {
    const hour = +time.split(":")[0];
    const minute = +time.split(":")[1];
    if (hour < 10) {
        if (minute == 0) {
            return "0" + hour.toString() + ":0" + minute.toString();
        } else {
            return "0" + hour.toString() + ":" + minute.toString();
        }
    } else {
        if (minute == 0) {
            return hour.toString() + ":0" + minute.toString();
        } else {
            return hour.toString() + ":0" + minute.toString();
        }
    }
}

export function parseDate(date: string): string {
    
    const parts = date.split(/[./-]/);
    return parts[2] + '-' + parts[1] + '-' + parts[0]
}

export function GetElementValueById(id: string) {
    return (<HTMLInputElement>document.getElementById(id)).value;
}

export async function SetAllProfessions() {
    const selectBlock = document.getElementById("selectDoctorsNavBar") as HTMLSelectElement;
    selectBlock.value = null;
    selectBlock.options[0] = new Option("Профиль врача: ", "");
    selectBlock.options[0].disabled = true;
    selectBlock.options[0].selected = true;
    selectBlock.options[0].hidden = true;
    let result;
    result = await GetRequest<Profession[]>("api/common/getAllProfessions");
    const answer = ReturnResponse(result) 
    {
        if(typeof answer !== "string"){
            for (let i = 0; i < result.data.length; i++) {
                let text = result.data[i].name;
                let value = result.data[i].id.toString();
                selectBlock.options[selectBlock.options.length] = new Option(text, value);
            }
        }
        else{
            alert(answer);
        }
    }
    if(window.location.href.includes("/Home/DoctorsForUser")|| window.location.href.includes("/Home/Session")){
        let professionId = +location.href.split(/\?|&|=/)[2];
        if(window.location.href.includes("/Home/Session")){
            professionId = +document.getElementById("professionIdSession").innerText;
        }
        (<HTMLSelectElement>document.getElementById("selectDoctorsNavBar")).options[professionId].selected=true;
    }
}

export function GetElementTextById(id: string){
    return document.getElementById(id).innerText;
}

export function GetFirstElementByClassName(className: string){
    return document.getElementsByClassName(className)[0] as HTMLElement;
}

export function parseWeekToDate(date: string): string{
    const elems = date.split("-W");
    const dd = (1+(+elems[1]-1)*7)-2;
    return parseDate(new Date(+elems[0], 0, dd).toLocaleDateString());
}

export function GetChangeWorkDayFromInputById(dayOfWeek: string): WorkDayDto|null{
    if((<HTMLInputElement>document.getElementById(dayOfWeek+"BeginChange")).value != "" && (<HTMLInputElement>document.getElementById(dayOfWeek + "EndChange")).value != "") 
        return new WorkDayDto((<HTMLInputElement>document.getElementById(dayOfWeek+"BeginChange")).value,
        (<HTMLInputElement>document.getElementById(dayOfWeek + "EndChange")).value)
    else{
        return null;
    }
}

export function GetNewWorkDayFromInputById(dayOfWeek: string): WorkDayDto|null{
    if((<HTMLInputElement>document.getElementById(dayOfWeek+"Begin")).value != "" && (<HTMLInputElement>document.getElementById(dayOfWeek + "End")).value != "")
        return new WorkDayDto((<HTMLInputElement>document.getElementById(dayOfWeek+"Begin")).value,
            (<HTMLInputElement>document.getElementById(dayOfWeek + "End")).value)
    else{
        return null;
    }
}

