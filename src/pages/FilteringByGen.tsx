import { useQuery } from "@tanstack/react-query";
import { Select, Spin } from "antd";
import { useState } from "react";
import { byGen } from "../services/axiosRequests";
import { ResultDto } from "../type/dto.type";
import FilteredList from "../components/FilteredList";
import { DefaultOptionType } from "antd/es/select";
import { idFromUrl } from "../services/stringFunctions";

function FilteringByGen() {
    const [selectTypeOptions, setSelectTypeOptions] = useState<DefaultOptionType[]>([]);
    const [genSelected, setGenSelected] = useState<number>(1);
    const { data: generations } = useQuery<ResultDto>(["pokemon", "generation"],
        async () => {
            var vRet = await byGen.getGens();
            var opt: DefaultOptionType[] = [];
            vRet.results.forEach((g, index) => {
                opt.push({
                    label: 'Generation ' + (index + 1),
                    value: index + 1,
                });
            });
            setSelectTypeOptions(opt);
            return vRet;
        }
    );
    const handleChange = (value: number) => {
        setGenSelected(value);
    }

    const { isLoading, data: list } = useQuery<ResultDto>(["pokemon", "list", genSelected],
        async () => {
            var vRet: ResultDto = { count: 0, results: [] };
            var vReq = await byGen.listByGen(genSelected!);
            vReq.results.forEach(poke => {
                if (idFromUrl.getIdFromUrl(poke.url) < 10000) {
                    vRet.count++;
                    vRet.results.push(poke);
                }
            });
            return vRet;
        }
    );

    return (
        <div className="flex flex-col h-full">
            <div className="flex gap-2 m-0 mb-4 items-center">
                <Select
                    style={{ width: '100%' }}
                    placeholder="Select a generation"
                    defaultValue={1}
                    onChange={(value) => handleChange(value)}
                    options={selectTypeOptions}
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
export default FilteringByGen;