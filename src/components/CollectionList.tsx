import { useQuery } from "@tanstack/react-query";
import { Card, Spin } from "antd";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { collections } from "../services/axiosRequests";
import { CollectionIdDto } from "../type/dto.type";
import DetailsList from "./DetailsList";
import SelectUser from "./SelectUser";

function CollectionList() {
    const navigate = useNavigate();
    const [user, setUser] = useState<string>('');
    const { isLoading, data: userCol } = useQuery<CollectionIdDto[]>(["collection", "list", user],
        async () => {
            var vRet = collections.listCollectionByUser(user);
            return vRet;
        }
    );
    const [currentListId, setCurrentListId] = useState<string>();
    const [open, setOpen] = useState<boolean>(false);
    const onOpen = (aId: string) => {
        setCurrentListId(aId);
        setOpen(true);
    }

    return (
        <>
            <h1> Collection List by User</h1>
            <SelectUser value={user} onChange={(value) => { setUser(value) }} />
            <div className="flex flex-col h-full">
                <div className='relative flex-grow -2'>
                    <div className='absolute inset-0 w-full h-full overflow-auto'>
                        <div className='grid gap-2 sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 bg-gray-100'>
                            {isLoading && <Spin />}
                            {userCol?.map(col => {
                                return (
                                    <div>
                                        <Card title={col.name} hoverable onClick={() => navigate('/collection/'+col.colId)}>
                                            <p>{col.description && col.description}</p>
                                            <p>{!col.description && 'A list'}</p>
                                        </Card>
                                    </div>
                                );
                            })}</div>
                    </div>
                </div>
            </div>

        </>
    )
}
export default CollectionList;