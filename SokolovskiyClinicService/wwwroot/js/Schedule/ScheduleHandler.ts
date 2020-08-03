import scheduleManager from "./ScheduleManager";

export function ViewSchedule(doctorId: number, name: string){
    const result = scheduleManager.GetSchedule(doctorId).then((result)=> {
        if(typeof result !== "string"){
            document.getElementById("doctorName").innerHTML = name;

            if(result.monday !== null){
                document.getElementById("mondayBeginView").innerHTML = result.monday.beginOfDay;
                document.getElementById("mondayEndView").innerHTML = result.monday.endOfDay;
            }

            if(result.tuesday !== null){
                document.getElementById("tuesdayBeginView").innerHTML = result.tuesday.beginOfDay;
                document.getElementById("tuesdayEndView").innerHTML = result.tuesday.endOfDay;
            }

            if(result.wednesday !== null){
                document.getElementById("wednesdayBeginView").innerHTML = result.wednesday.beginOfDay;
                document.getElementById("wednesdayEndView").innerHTML = result.wednesday.endOfDay;
            }

            if(result.thursday !== null){
                document.getElementById("thursdayBeginView").innerHTML = result.thursday.beginOfDay;
                document.getElementById("thursdayEndView").innerHTML = result.thursday.endOfDay;
            }

            if(result.friday !== null){
                document.getElementById("fridayBeginView").innerHTML = result.friday.beginOfDay;
                document.getElementById("fridayEndView").innerHTML = result.friday.endOfDay;
            }

            if(result.saturday !== null){
                document.getElementById("saturdayBeginView").innerHTML = result.saturday.beginOfDay;
                document.getElementById("saturdayEndView").innerHTML = result.saturday.endOfDay;
            }

            if(result.sunday !== null){
                document.getElementById("sundayBeginView").innerHTML = result.sunday.beginOfDay;
                document.getElementById("sundayEndView").innerHTML = result.sunday.endOfDay;
            }

        }
        else{
            document.getElementById("scheduleNotFound").innerHTML = result
        }
        (<HTMLDialogElement>document.getElementById("ViewScheduleModal")).showModal()
    })
}

export function CloseViewScheduleModal() {
    (<HTMLDialogElement>document.getElementById("ViewScheduleModal")).close()
}