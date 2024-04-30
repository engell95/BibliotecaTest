import { Button, Col, Layout, Popover, Row, Typography } from "antd";
import { NavLink, useNavigate } from 'react-router-dom';
import { UserOutlined } from "@ant-design/icons";
import { useDispatch } from 'react-redux'
import { CloseSession } from "../../actions";
import { SessionData } from '../../helpers';
import React from "react";

const { Text } = Typography;
const Header = () => {
    
    const sessionData = SessionData() as IModelLoginRequest;

    const navigate = useNavigate();
    const dispatch = useDispatch();
    const logout = () => {
        dispatch(CloseSession());
        navigate("/logout");
    }

    const perfilPopover = (
        <React.Fragment>
            <NavLink to="profile" >
                <Button className="block" icon={<UserOutlined />}>
                    Perfil
            </Button>
            </NavLink>
            <Button type="text" className="block" onClick={logout}>
                Salir
            </Button>
        </React.Fragment>
    );


    return (
        <Layout.Header  className="header" >
            <Row justify="end" align="middle" gutter={[10, 10]}>
                <Col flex={100}></Col>
                <Col className="hidden-sm">
                    <Text >
                        Bienvenido, {" "}
                        <Text strong>
                            {sessionData.name}
                        </Text>
                    </Text>
                </Col>
                <Col className="col-profile-picture">
                    <Popover placement="bottom" content={perfilPopover} trigger="click">
                        <UserOutlined/>
                    </Popover>
                </Col>

            </Row>
        </Layout.Header>
    );
}
export { Header };