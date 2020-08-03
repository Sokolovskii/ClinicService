export class Response<T>{
    code: ResponseCode;
    data: T;
    message: string;
}

export enum ResponseCode{
    Ok=0,
    Warning=1,
    Error=2,
}