import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './assets/css/index.css';
import "antd/dist/antd.css";
import {ConfigProvider} from 'antd';
import es_ES from 'antd/es/locale/es_ES';

ConfigProvider.config({
  theme:{
    primaryColor:"#00583C",
    errorColor:"#D43C37",
    infoColor: "#00ABEC",
    processingColor:"#33BA75",
    successColor:"#008866",
    warningColor:"#F4AD3D"
  }
});

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <ConfigProvider locale={es_ES}>
      <App />
    </ConfigProvider>
  </React.StrictMode>,
)
