import axios from "axios"
const API_BASE_URL = import.meta.env.VITE_API_BASE_URL;
class AccountService{
    static async Authenticate(model:IModelLogin)
    {
        const response:IModelLoginRequest= {} as IModelLoginRequest;
        await axios.post(`${API_BASE_URL}v1/Account/Login`, model)
        .then( reponsePost => {
            response.expiration = reponsePost.data.authenticate;
            response.token = reponsePost.data.expiration;
            response.authenticate = true;
            response.username = model.username;
        })
        .catch( error => {
            response.authenticate = false;
            response.message = error.response.data;
        });

       return response;
    }
}

export {AccountService};