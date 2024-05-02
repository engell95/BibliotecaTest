import { useNavigate } from "react-router-dom";
import { HomeOutlined, ControlOutlined , ContainerOutlined, UserOutlined, ScheduleOutlined , ReadOutlined } from "@ant-design/icons"
import { Layout, Menu, MenuProps,Row } from "antd";
import logo from "../../assets/img/logo.png";

type MenuItem = Required<MenuProps>['items'][number];

function getItem(
  label: React.ReactNode,
  key: React.Key,
  icon?: React.ReactNode,
  children?: MenuItem[],
  type?: 'group',
): MenuItem {
  return {
    key,
    icon,
    children,
    label,
    type,
  } as MenuItem;
}

const items: MenuProps['items'] = [

  getItem('Inicio', '/home', <HomeOutlined />),
  getItem('Libros', '', <ReadOutlined  />, [
    getItem('Libros', 'book', <ReadOutlined  />),
    getItem('Prestamos', 'loan', <ScheduleOutlined />),
  ]),
  getItem('Autores', 'author', <UserOutlined />),
  getItem('Editoriales', 'publisher', <ContainerOutlined />),
  getItem('Usuarios', 'user', <ControlOutlined  />),

];

const Sider = () => {
  const navigate = useNavigate();
 
  const onMenuClick: MenuProps['onClick'] = e => {
    let url =  e.key.split(',');
    navigate(url[0])
  }

  return (
    <Layout.Sider
      breakpoint="lg"
      collapsedWidth="0"
    >
      <Row justify="center" align="middle" gutter={[10, 10]}>
        <img src={logo} alt="logo" className="logo-layout" />
      </Row>
      <Menu
        defaultSelectedKeys={['/Home']}
        defaultOpenKeys={['/Home']}
        mode="inline"
        items={items}
        onClick={onMenuClick}
      />
    </Layout.Sider>
  )
}

export { Sider };