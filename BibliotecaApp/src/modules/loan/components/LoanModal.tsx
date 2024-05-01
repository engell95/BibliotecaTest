import { Modal, Input, Form, Row, Button, Divider, Col } from "antd"
import { SaveOutlined, CloseCircleOutlined ,UserOutlined,BookOutlined,NumberOutlined } from "@ant-design/icons"
import {TypeAction} from "../../../helpers/TypeAction"

const LoanModal = ({ showModal, formData, onChange, Type }: PropLoan) => {
    const layout = { labelCol: { span: 8 }, wrapperCol: { span: 16 } };

    return(
        <Modal {...layout} open={showModal} destroyOnClose={true} onCancel={onChange} title={TypeAction(Type,"Prestamo")} footer={false} centered>
            <Form initialValues={formData} >

            </Form>
        </Modal>
        
    );
}

export { LoanModal };