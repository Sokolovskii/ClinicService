export function SetCookie(Key: string, Value: string, options = {}){
    options = {
        path: '/',
        'max-age': 86400
    };

    let updatedCookie = Key+ "=" + Value;

    for (let optionKey in options) {
        updatedCookie += "; " + optionKey;
        let optionValue = options[optionKey];
        if (optionValue !== true) {
            updatedCookie += "=" + optionValue;
        }
    }

    document.cookie = updatedCookie;
}

export function GetCookie(Key: string){
    let matches = document.cookie.match(new RegExp(
        "(?:^|; )" + Key.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
}

export function DeleteCookie(Key: string){
    SetCookie(Key, "", {
        'max-age': -1
    })
}