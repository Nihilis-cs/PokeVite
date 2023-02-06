import { useQuery } from "@tanstack/react-query";
import { Select } from "antd";
import { DefaultOptionType } from "antd/es/select";
import { useCallback, useEffect, useState } from "react";
import { byUser, collections } from "../services/axiosRequests";
import { CollectionIdDto, UserDto } from "../type/dto.type";

interface SelectCollectionProps {
    value: string | undefined;
    onChange: (value: string) => void;
    userId?: string | undefined;
}
function SelectCollection({ value, onChange, userId }: SelectCollectionProps) {
    const [collectionsList, setCollectionsList] = useState<CollectionIdDto[]>();

    useEffect(() => {
        if (userId) {
            collections.listCollectionByUser(userId).then((result) => {
                setCollectionsList(result);
                if (result) {
                    onChange(result[0].colId);
                }
            });
        } else {
            setCollectionsList([]);
        }
    }, [userId]);
    const selectCollectionOptions = (collections: CollectionIdDto[] | undefined): DefaultOptionType[] => {
        var vRet: DefaultOptionType[] = [];
        if (collections) {
            collections.forEach((u) => {
                vRet.push({
                    label: u.name,
                    value: u.colId
                });
            });
        }
        return vRet;
    };

    return (
        <Select
            style={{ width: '100%' }}
            allowClear
            disabled={userId == undefined}
            placeholder="Select a Collection"
            value={value}
            onSelect={(value) => onChange(value)}
            options={selectCollectionOptions(collectionsList)}
        >
        </Select>
    )
}
export default SelectCollection;