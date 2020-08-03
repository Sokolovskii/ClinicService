import {Response} from './Response'

async function GetRequest<T>(urlString: string, data?: any): Promise<Response<T>> {

    let response;
    const url = new URL(urlString, document.baseURI);

    if (data !== undefined) {
        Object.keys(data).forEach(key => url.searchParams.append(key, data[key]));
    }
    
    response = await fetch(url.toString(),{
        redirect: "manual"
    });
    
    if (!response.ok) {
        if (response.status == 401) {
            alert("неавторизованный запрос невозможен")
        }
    }
    else if(response.redirected){
        location.href = response.url;
    }
    const result = await response.json();
    return result as Response<T>;
}

async function PostRequest<T>(url: string, data?: any): Promise<Response<T>> {

    let response;
    
        response = await fetch(url, {
            method: "POST",
            redirect: "manual",
            headers: {
                'Content-Type': 'application/json; charset=utf-8',
            },
            body: JSON.stringify(data)
        });
        
    if (!response.ok) {
        if (response.status == 401) {
            alert("неавторизованный запрос, авторизуйтесь и повторите попытку")
        }
    }
    else if(response.redirected){
        location.href = response.url;
    }
    const result = await response.json();
    return result as Response<T>;
}

export {GetRequest, PostRequest}