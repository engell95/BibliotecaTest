import { useNavigate } from "react-router-dom";
import { HomeOutlined, ApartmentOutlined, LockOutlined, UserOutlined, CodeOutlined, HddOutlined, UnorderedListOutlined, CheckCircleOutlined } from "@ant-design/icons"
import { Layout, Menu, MenuProps } from "antd";
import logo from '../../assets/img/logoFlujo.svg';
import { SessionData } from '../../helpers';
import { useEffect, useState } from "react";


function getIcon(Type: any) {
  switch (Type) {
    case 'HomeOutlined':
      return <HomeOutlined />;
    case 'UserOutlined':
      return <UserOutlined />;
    case 'ApartmentOutlined':
      return <ApartmentOutlined />;
    case 'LockOutlined':
      return <LockOutlined />;
    case 'CodeOutlined':
      return <CodeOutlined />;
    case 'UnorderedListOutlined':
      return <UnorderedListOutlined />;
    case 'CheckCircleOutlined':
      return <CheckCircleOutlined />;
    default:
      return <HddOutlined />;
  }
}

const Sider = () => {
  const navigate = useNavigate();
  const [menusLayout, setMenusLayout] = useState([] as Array<MenuItem>);
  
  interface IMenuItem {
    MenuItem: MenuProps
    MenuItemChild: Array<MenuProps>
  }

  type MenuItem = Required<MenuProps>['items'][number];

  const onMenuClick: MenuProps['onClick'] = e => {
    let url =  e.key.split(',');
    navigate(url[0])
  }



  return (
    <Layout.Sider
      breakpoint="lg"
      collapsedWidth="0"
      //color={SiderCSS.background}
      //style={{ background: SiderCSS.background, color: SiderCSS.color, boxShadow: "" }}
    >
      <img src={logo} alt="logo" className="logo-layout" />
      <Menu
        defaultSelectedKeys={['/Home']}
        defaultOpenKeys={['/Home']}
        mode="inline"
        //style={{ background: SiderCSS.background, color: SiderCSS.color }}
        items={menusLayout}
        onClick={onMenuClick}
      />
    </Layout.Sider>
  )
}

export { Sider };