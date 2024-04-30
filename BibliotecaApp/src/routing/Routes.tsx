import {
    BrowserRouter as Router,
    Route,
    Routes as Switch

} from "react-router-dom";
import { PublicRoutes } from "./PublicRoutes";


const Routes = () => {
    const baseNameUrl =  localStorage.getItem('ruta') ?? "";
    
    return (
        <Router basename={baseNameUrl}>
            <Switch>
                <Route  path="*" element={<PublicRoutes/>} />
            </Switch>
        </Router>
    );
}



export { Routes };