import {Layout} from "antd";

const Footer = () =>
{
    return(
        <Layout.Footer  style={{textAlign:'center', overflowY:'hidden'}}>
            Flujo Admin {new Date().getFullYear()} - Sistemas integrados.
        </Layout.Footer>
    );
};

export {Footer};