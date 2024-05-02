import React, { useEffect, useState } from "react";
import { Button, Col, Divider, Row,Card, Space, Modal, Input } from "antd";
import { EditOutlined, LoadingOutlined, ScheduleOutlined } from '@ant-design/icons';
import { BookService } from '../../services';
import { BookModal } from "./components";
import { LoanModal } from "../loan/components";
import { IsAdmin,SessionData } from '../../helpers';
const sessionData = SessionData() as IModelLoginRequest;
const Search = Input.Search;

const BookPage = () => {

    const [loading, setLoading] = useState(false);
    const [lstBook, setLstBook] = useState([] as Array<IModelBook>);
    const [lstFilter, setLstFilter] = useState([] as Array<IModelBook>);
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [isModalVisibleLoan, setIsModalVisibleLoan] = useState(false);
    const [Book, setBook] = useState({} as IModelBook);
    const [Loan, setLoan] = useState({} as IModelLoanModal);
    const [Type, setType] = useState(1);

    useEffect(() => {
        fetchListBook();
    }, []);

    const changeModal = () => {
        setIsModalVisible(!isModalVisible);
    }

    const changeModalLoan = () => {
        setIsModalVisibleLoan(!isModalVisibleLoan);
    }

    const fetchListBook = async () => {
        setLoading(true);
        let result = await BookService.GetListBook();
        setLstBook(result);
        setLoading(false);
    }

    const search = (value: string) => {
        const filteredList = lstBook.filter(book =>
            book.nombre.toLowerCase().includes(value.toLowerCase())
        );
        setLstFilter(filteredList);
    };

    const showLoan = (data: IModelBook) => {
        console.log(Loan)
        Loan.id_Usuario = sessionData.idUser;
        Loan.id_Libro = data.id;
        Loan.autor = data.autor;
        Loan.editorial = data.editorial;
        Loan.libro = data.nombre;
        //setLoan(Loan); 
        console.log(Loan)
        changeModalLoan();
    }

    const showBook = (data: IModelBook) => {
        setType(1);
        setBook(data);
        changeModal();
    }

    const createBook = () => {
        setType(2);
        changeModal();
    }

    const editBook = (data: IModelBook) => {
        setType(3);
        setBook(data);
        changeModal();
    }

    const save = (form: IModelBook) => {
        const modal = Modal.success({
            icon: <LoadingOutlined />,
            title: "Guardando...",
            centered: true,
            content: "Se esta guardando el libro",
            okButtonProps:{ disabled: true }
        });

        
    }

    return (
        <React.Fragment>
            <Row gutter={[16, 16]} justify="end" align="middle">
                <Col>
                    <Search type="search" placeholder="Buscar" onChange={e => search(e.target.value)}/>
                </Col>
                <Col>
                    {IsAdmin
                        ?<Button type="primary" onClick={() => createBook()}>Nuevo Libro</Button>
                        :<></>
                    }
                </Col>
            </Row>
            <Divider />
            <Row gutter={[16, 16]} justify="center" align="middle">
                {(lstFilter.length > 0 ? lstFilter : lstBook).map((book, index) => (
                    <Col key={book.id} xs={24} sm={12} md={8} lg={6} xl={6}>
                        <Card
                            hoverable
                            style={{ marginBottom: 16 }}
                            cover={<img alt={book.nombre} src={`https://picsum.photos/150/150?random=${book.id}`} />}
                            actions={[
                                <Space onClick={(e) => e.stopPropagation()}>
                                    {IsAdmin?
                                    <Button type="primary" icon={<EditOutlined />} onClick={() => editBook(book)}>Editar</Button>
                                    :<></>}
                                    <Button type="primary" icon={<ScheduleOutlined />} onClick={() => showLoan(book)}>Prestar</Button>
                                </Space>
                            ]}
                            onClick={() => showBook(book)}
                        >
                            <Card.Meta
                                title={book.nombre}
                                description={book.descripcion.length > 50 ? `${book.descripcion.substring(0, 50)}...` : book.descripcion}
                            />
                        </Card>
                        {(index + 1) % 4 === 0 && <div style={{ width: '100%', height: 0 }} />}
                    </Col>
                ))}
            </Row>
            <BookModal showModal={isModalVisible} formData={Book} onChange={changeModal} Type={Type} onSave={save} onLoad={showLoan} />
            <LoanModal showModal={isModalVisibleLoan} formData={Loan} onChange={changeModalLoan} Type={4} />
        </React.Fragment>
    );
}

export { BookPage };