import { Menu, MenuProps, Layout, Image, Drawer, FloatButton } from "antd";
import { Outlet } from "react-router-dom";
import { DashOutlined, MenuOutlined } from '@ant-design/icons';
import '../App.css';
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";


function PokeLayout() {
    const navigate = useNavigate();
    const [open, setOpen] = useState<boolean>(false);
    const [move, setMove] = useState<number>(0);

    const showDrawer = () => {
        setMove(1);
        setOpen(true);
    };
    const onClose = () => {
        setMove(0);
        setOpen(false);
    };
    type MenuItem = Required<MenuProps>['items'][number];
    function getItem(
        label: React.ReactNode,
        key: React.Key,
        onClick: () => void,
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
            onClick,
        } as MenuItem;
    }
    const items: MenuProps['items'] = [
        getItem('All', 'sub1',() => navigate("/") ,<DashOutlined />),
        getItem('ByType', 'sub2',() => navigate("/filteredType"), <DashOutlined />),
        getItem('ByGen', 'sub3',() => navigate("/filteredGen"), <DashOutlined />),
        getItem('ByUser', 'sub4', () => navigate("/filteredUser"), <DashOutlined/> ),
        getItem('PageTests', 'sub5', () => navigate("/tests"), <DashOutlined/>)
    ];

    return (
        <Layout className="h-screen">
            <div>
                <FloatButton onClick={showDrawer}
                    icon={<MenuOutlined />}
                    style={{ left: 18, top: 8, boxShadow: '0px 0px 10px 0px #FFFFFF', transform: `translateX(${move * 370}px)` }}
                    className="z-[2000] transition delay-75 duration-300 "
                />
            </div>
            <Layout.Header>
                <Image src="/pokeapi.png" preview={false} width={`15em`} style={{ transform: `translateX(${move * 390}px)` }} className="z-[3000] transition delay-100 duration-300 " />
            </Layout.Header>
            <Layout.Content className="pt-6 px-12 h-full">
                <Layout className="h-full">
                    <Drawer
                        title="Menu"
                        placement='left'
                        closable={true}
                        closeIcon={<MenuOutlined />}
                        onClose={onClose}
                        open={open}
                        mask={true}>
                        <Menu
                            mode="inline"
                            defaultSelectedKeys={['1']}
                            defaultOpenKeys={['sub1']}
                            style={{ height: '100%' }}
                            items={items} />
                    </Drawer>
                    <Layout.Content >
                        <Outlet />
                    </Layout.Content>
                </Layout>
            </Layout.Content>
            <Layout.Footer style={{ textAlign: 'center'}}>Designed avec le cul @ 2023</Layout.Footer>
        </Layout>
    );
}
export default PokeLayout;

