import axios from 'axios';
import { SessionData } from '../helpers';
const API_BASE_URL = import.meta.env.VITE_API_BASE_URL;

class loanService {

    static async GetListloan() {
        const sessionData = SessionData() as IModelLoginRequest;
        let response: Array<IModelLoan> = [] as Array<IModelLoan>;
        await axios.get(`${API_BASE_URL}v1/Prestamo`,{
                headers: {
                    Authorization: `Bearer ${sessionData.token}`
                }
            })
            .then(reponsePost => {
                response = reponsePost.data.datos;
            })
            .catch(error => {
                console.log("🚀 ~ file: loan.services.tsx ~ line 19 ~ loanService ~ GetListloan ~ error", error)
            });
        return response;
    }

    static NewLoan = async (model: IModelLoanRequest) => {
        
        const sessionData = SessionData() as IModelLoginRequest;
        const { data } = await axios.post(`${API_BASE_URL}v1/Prestamo`, model,{
            headers: {
                Authorization: `Bearer ${sessionData.token}`
            }
        });

        return data;
    }

}

export { loanService };