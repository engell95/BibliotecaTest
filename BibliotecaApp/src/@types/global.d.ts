interface IModelLoginRequest {
    country: string = '';
    username: string = '';
    url: string | null = '';
    message: string | null = '';
    authenticate: boolean = false;
    idrol: int;
    name: string = '';
    menues: IModelMenu
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

interface IModelLogin {
    country: string = 'NI';
    username: string = '';
    password: string = '';
}

interface IModelAlert {
    message: string;
    type: string = "error" | "success" | "info" | "warning" | undefined;
}