import { SessionData } from '../helpers';
const sessionData = SessionData() as IModelLoginRequest;
const Admin = import.meta.env.VITE_ROL_ADMIN;

const IsAdmin:boolean = sessionData.role == Admin?true:false;
export { IsAdmin };