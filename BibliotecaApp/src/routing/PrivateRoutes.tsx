import { Navigate, Route, Routes } from "react-router-dom";
import { MasterLayout } from "../layout";
import {HomePage,BookPage} from '../modules';

const PrivateRoutes = () => {
    return (
        <Routes>
            <Route path="/*" element={<MasterLayout />}>
                <Route path="home" element={<HomePage/>} />
                <Route path="book" element={<BookPage/>} />
            </Route>
            <Route path="/login" element={<Navigate to="/home"/>} />
        </Routes>
    );
};

export { PrivateRoutes };