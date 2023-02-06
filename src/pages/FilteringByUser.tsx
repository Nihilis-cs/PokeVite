import { useQuery } from "@tanstack/react-query";
import { Select, Spin } from "antd";
import { useState } from "react";
import { byUser } from "../services/axiosRequests";
import { ResultDto, UserDto } from "../type/dto.type";
import FilteredList from "../components/FilteredList";
import { DefaultOptionType } from "antd/es/select";
import { idFromUrl } from "../services/stringFunctions";

function FilteringByUser() {
    const [userSelected, setUserSelected] = useState<string>();
    
    const { data: users } = useQuery<UserDto[]>(["listUser"],
        async () => {
            var vUsers = await byUser.getUsers();
            return vUsers;
        }
    );
    const selectUserOptions = (users: UserDto[] | undefined): DefaultOptionType[] => {
        var vRet: DefaultOptionType[] = [];
        if (users) {
            users.forEach((u) => {
                vRet.push({
                    label: u.name,
                    value: u.id,
                });
            });
        }
        return vRet;
    };

    const { isLoading, data: list } = useQuery<ResultDto>(["pokemon", "list", userSelected],
        async () => {
            var vRet: ResultDto = { count: 0, results: [] };
            if(userSelected)
            {
                var vReq = await byUser.listByUser(userSelected!);
                vReq.forEach(poke => {
                    if (idFromUrl.getIdFromUrl(poke.url) < 10000) {
                        vRet.count++;
                        vRet.results.push(poke);
                    }
                });
            }
            return vRet;
        }
    );

    return (
        <div className="flex flex-col h-full">
            <div className="flex gap-2 m-0 mb-4 items-center">
                <Select
                    style={{ width: '100%' }}
                    placeholder="Select a User"
                    value={userSelected}
                    onSelect={(value) => setUserSelected(value)}
                    options={selectUserOptions(users)}
                >
                </Select>
                <p className="m-0">Corresponding results: {list?.count}</p>
            </div>
            <div className="flex-grow">
                {isLoading &&
                    <div className="flex flex-col h-full">
                        <div className='relative flex-grow'>
                            <div className='flex-center'>
                                <Spin></Spin>
                            </div></div></div>}
                <FilteredList pokemons={list} />
            </div>
        </div>
    );
}
export default FilteringByUser;