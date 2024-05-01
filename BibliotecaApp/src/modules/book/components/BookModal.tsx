import { Modal, Input, Form, Row, Button, Divider, Col } from "antd"
import { SaveOutlined, CloseCircleOutlined ,UserOutlined,BookOutlined,ScheduleOutlined,NumberOutlined } from "@ant-design/icons"
import {TypeAction} from "../../../helpers/TypeAction"
import TextArea from "antd/lib/input/TextArea";

const BookModal = ({ showModal, formData, onChange, Type, onSave,onLoad }: PropBook) => {
    const layout = { labelCol: { span: 8 }, wrapperCol: { span: 16 } };

    return(
            <Modal {...layout} open={showModal} destroyOnClose={true} onCancel={onChange} title={TypeAction(Type,"Libro")} footer={false} centered>
                <Form initialValues={formData} onFinish={onSave}>
                    <Col>
                        <Form.Item name="id" required={true} hidden>
                            <Input disabled />
                        </Form.Item>
                    </Col >
                    <Col>
                        {Type === 1 ? (
                            <h3>{formData.nombre}</h3>
                        ) : (
                            <Form.Item label="Nombre" name="nombre" rules={[{ required: true,min:5,max:100}]}>
                                <Input /> 
                            </Form.Item>
                         )}
                    </Col>
                    <Col>
                        {Type === 1 ? (
                            <span><UserOutlined/> Autor: {formData.autor}</span>
                        ) : (
                            <Input /> 
                        )}
                    </Col>
                    <Col>
                        {Type === 1 ? (
                            <span><BookOutlined /> Editorial: {formData.editorial}</span>
                        ) : (
                            <Input /> 
                        )}
                    </Col>
                    <Col>
                        {Type === 1 ? (
                            <span><NumberOutlined/> Copias: {formData.copias}</span>
                        ) : (
                            <Input /> 
                        )}
                    </Col>
                    <Col>
                        {Type === 1 ? 
                        (
                            <>
                                <Divider/>
                                <span>Descripción: </span><br/>
                                <span>{formData.descripcion}</span>
                            </>
                        ) : 
                        (
                            <Form.Item label="Descripción" name="descripcion">
                                <TextArea />
                            </Form.Item>
                        )}
                       
                    </Col>
                    <Divider />
                    <Row justify="space-around">
                        <Button type="default" onClick={onChange} icon={<CloseCircleOutlined />} >
                            Cerrar
                        </Button>
                        <Button type="primary" onClick={() => onLoad(formData)} icon={<ScheduleOutlined />} >
                            Prestar
                        </Button>
                        { Type == 2 || Type == 3?
                        <Button type="primary" htmlType="submit" icon={<SaveOutlined />}>
                            Guardar
                        </Button>
                        :<></>
                        }
                    </Row>
                </Form>
            </Modal>
    );
}

export { BookModal };