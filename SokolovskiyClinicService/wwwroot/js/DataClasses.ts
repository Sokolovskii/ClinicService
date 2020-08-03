class User {
    id: number;
    name: string;
    login: string;
    role: string;
}

export class UserToLogIn {
    login: string;
    password: string;

    constructor(login: string, password: string) {
        this.login = login;
        this.password = password;
    }
}

export class UserToSignIn {
    name: string;
    login: string;
    password: string;
    isDoctor: boolean;

    constructor(name: string, login: string, password: string, isDoctor: boolean) {
        this.name = name;
        this.login = login;
        this.password = password;
        this.isDoctor = isDoctor;
    }
}

export class WorkDayDto {
    beginOfDay: string;
    endOfDay: string;

    constructor(beginOfDay: string, endOfDay: string) {
        this.beginOfDay = beginOfDay;
        this.endOfDay = endOfDay;
    }
}

export class AuthorizedUser {
    jwtToken: string;
    user: User;
}

export class DoctorToDeletingDto {
    doctorId: number;
    dateOfDismissal: string;

    constructor(doctorId: number, dateOfDismissal: string) {
        this.doctorId = doctorId;
        this.dateOfDismissal = dateOfDismissal;
    }
}

export class Doctor {
    id: number;
    name: string;
    professionId: number;
}

export class DoctorToAddingDto {
    name: string;
    professionId: number;
    specialisation: string;

    constructor(name: string, professionId?: number, specialisation?: string) {
        this.name = name;
        this.professionId = professionId;
        this.specialisation = specialisation
    }
}

export class ScheduleToAddingDto {
    monday: WorkDayDto;
    tuesday: WorkDayDto;
    wednesday: WorkDayDto;
    thursday: WorkDayDto;
    friday: WorkDayDto;
    saturday: WorkDayDto;
    sunday: WorkDayDto;

    constructor(monday: WorkDayDto, tuesday: WorkDayDto, wednesday: WorkDayDto, thursday: WorkDayDto, friday: WorkDayDto, saturday: WorkDayDto,
                sunday: WorkDayDto) {
        this.monday = monday;
        this.tuesday = tuesday;
        this.wednesday = wednesday;
        this.thursday = thursday;
        this.friday = friday;
        this.saturday = saturday;
        this.sunday = sunday;
    }
}

export class Schedule {
    monday: WorkDayDto;
    tuesday: WorkDayDto;
    wednesday: WorkDayDto;
    thursday: WorkDayDto;
    friday: WorkDayDto;
    saturday: WorkDayDto;
    sunday: WorkDayDto;
    actualisationDate: string;

    constructor(monday: WorkDayDto, tuesday: WorkDayDto, wednesday: WorkDayDto, thursday: WorkDayDto, friday: WorkDayDto, saturday: WorkDayDto,
                sunday: WorkDayDto, actualisationDate: string) {
        this.monday = monday;
        this.tuesday = tuesday;
        this.wednesday = wednesday;
        this.thursday = thursday;
        this.friday = friday;
        this.saturday = saturday;
        this.sunday = sunday;
        this.actualisationDate = actualisationDate;
    }
}

export class ScheduleFull {
    doctorId: number;
    monday: WorkDayDto;
    tuesday: WorkDayDto;
    wednesday: WorkDayDto;
    thursday: WorkDayDto;
    friday: WorkDayDto;
    saturday: WorkDayDto;
    sunday: WorkDayDto;
    actualisationDate: string;

    constructor(doctorId: number, monday: WorkDayDto, tuesday: WorkDayDto, wednesday: WorkDayDto, thursday: WorkDayDto, friday: WorkDayDto, saturday: WorkDayDto,
                sunday: WorkDayDto, actualisationDate: string) {
        this.doctorId = doctorId;
        this.monday = monday;
        this.tuesday = tuesday;
        this.wednesday = wednesday;
        this.thursday = thursday;
        this.friday = friday;
        this.saturday = saturday;
        this.sunday = sunday;
        this.actualisationDate = actualisationDate;
    }
}

export class Profession {
    id: number;
    name: string;
}

export class SessionForReservingDto {
    date: string;
    timeOfBeginSession: string;
    doctorId: number;
    userId: number;

    constructor(date: string, timeOfBegin: string, doctorId: number, userId: number) {
        this.date = date;
        this.timeOfBeginSession = timeOfBegin;
        this.doctorId = doctorId;
        this.userId = userId
    }
}

export class Session {
    id: number;
    date: Date;
    timeOfBegin: string;
    doctorId: number;
    userId: number;
}

export class SessionToDeleting {
    sessionId: number;
    userId: number;

    constructor(sessionId: number, userId: number) {
        this.sessionId = sessionId;
        this.userId = userId;
    }
}