interface IModelLogin {
    username: string = '';
    password: string = '';
}

interface IModelLoginRequest {
    token: string = '';
    expiration: Date = '';
    authenticate:boolean = false;
    message: string = '';
    username : string = '';
}

interface IModelAuthorized {
    auth: boolean;
}

interface IModelReducer {
    type: string;
    payload: IModelLoginRequest;
}

interface IModelItemMenu {
    icon: any;
    label: string;
    key: string;
}



interface IModelAlert {
    message: string;
    type: string = "error" | "success" | "info" | "warning" | undefined;
}