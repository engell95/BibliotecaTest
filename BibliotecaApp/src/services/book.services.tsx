import axios from 'axios';
import { SessionData } from '../helpers';
const API_BASE_URL = import.meta.env.VITE_API_BASE_URL;

class BookService {

    static async GetListBook() {
        const sessionData = SessionData() as IModelLoginRequest;
        let response: Array<IModelBook> = [] as Array<IModelBook>;
        await axios.get(`${API_BASE_URL}v1/Libro`,{
                headers: {
                    Authorization: `Bearer ${sessionData.token}`
                }
            })
            .then(reponsePost => {
                response = reponsePost.data.datos;
            })
            .catch(error => {
                console.log("🚀 ~ file: book.services.tsx ~ line 19 ~ BookService ~ GetListBook ~ error", error)
            });
        return response;
    }

}

export { BookService };