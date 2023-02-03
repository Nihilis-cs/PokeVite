import { useQuery } from "@tanstack/react-query";
import { Select } from "antd";
import { DefaultOptionType } from "antd/es/select";
import { useState } from "react";
import { byUser } from "../services/axiosRequests";
import { UserDto } from "../type/dto.type";

interface SelectUserProps {
    value: string | undefined;
    onChange: (value: string) => void;
}
function SelectUser({value, onChange} : SelectUserProps) {
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

    return (
        <Select
            style={{ width: '100%' }}
            allowClear
            placeholder="Select a User"
            value={value}
            onSelect={(value) => onChange(value)}
            options={selectUserOptions(users)}
        >
        </Select>
    )
}
export default SelectUser;