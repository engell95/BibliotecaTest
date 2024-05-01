interface IModelLogin {
    username: string = '';
    password: string = '';
}

interface IModelLoginRequest {
    token: string = '';
    expiration: string = '';
    authenticate:boolean = false;
    message: string = '';
    userName : string = '';
    email : string = '';
    role : string = '';
}

interface IModelAuthorized {
    auth: boolean;
}

interface IModelReducer {
    type: string;
    payload: IModelLoginRequest;
}

interface IModelAlert {
    message: string;
    type: string = "error" | "success" | "info" | "warning" | undefined;
}

interface IModelBook {
    id: number;
    nombre: string;
    descripcion: string;
    copias: number;
    fecha_Publicacion: string; 
    idAutor: number;
    autor: string;
    idEditorial: number;
    editorial: string;
}

interface PropBook {
    showModal: boolean;
    formData: IModelBook;
    onChange: (event: React.MouseEvent) => void;
    Type: number;
    onSave: (form: any) => void;
    onLoad: (data: IModelBook) => void;
}

interface IModelAuthor {
    id: number;
    nombre: string;
    estado: boolean;
}

interface IModelPublisher {
    id: number;
    nombre: string;
    estado: boolean;
}

interface PropLoan {
    showModal: boolean;
    formData: IModelLoan;
    onChange: (event: React.MouseEvent) => void;
    Type: number;
}

interface IModelLoan {
    id: number;
    fecha_Prestamo: string;
    fecha_Devolucion_Esperada: string;
    fecha_Devolucion_Real: string | null;
    libro: IModelBook;
    idUsuario: string;
    usuario: string;
}

