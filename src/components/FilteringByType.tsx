import { useQuery } from "@tanstack/react-query";
import { Button, Select } from "antd";
import type { SelectProps } from 'antd';
import { useState } from "react";
import { all, byGen, byType } from "../services/axiosRequests";
import { PokeDto, ResultDto } from "../type/dto.type";
import FilteredList from "./FilteredList";
import { idFromUrl } from "../services/stringFunctions";
import { inner } from "../services/arrayFunctions";
import { DefaultOptionType } from "antd/es/select";

interface TypesSelected {
    type1: string;
    type2?: string;
}
function FilteringByType() {
    const [typeSelected, setTypeSelected] = useState<TypesSelected>({type1: 'normal', type2: undefined});
    const [selectTypeOptions, setSelectTypeOptions] = useState<DefaultOptionType[]>([]);
    const [genSelected, setGenSelected] = useState<number[]>([]);
    const { data: types } = useQuery<ResultDto>(["pokemon", "types"],
        async () => {
            var vRet = await byType.getTypes();
            var opt : DefaultOptionType[] = [];
            vRet.results.forEach(t => {
                opt.push({
                    label: t.name,
                    value: t.name,
                });
            });
            setSelectTypeOptions(opt);
            return vRet;
        }
    );

    const handleChange = (value: string[]) => {
        setTypeSelected({type1: value[0], type2: value[1]? value[1]: ""});
    }

    const { isLoading, data: list } = useQuery<ResultDto>(["pokemon", "list", typeSelected],
        async () => {
            var vRet1: ResultDto = { count: 0, results: [] };
            var vReq = await byType.listByType(typeSelected.type1);
            vReq.pokemon.forEach(poke => {
                if (idFromUrl.getIdFromUrl(poke.pokemon.url) < 10000) {
                    vRet1.count++;
                    vRet1.results.push(poke.pokemon);
                }
            });
            if (typeSelected.type2) {
                var vRet2: ResultDto = { count: 0, results: [] };
                var vReq = await byType.listByType(typeSelected.type2);
                vReq.pokemon.forEach(poke => {
                    if (idFromUrl.getIdFromUrl(poke.pokemon.url) < 10000) {
                        vRet2.count++;
                        vRet2.results.push(poke.pokemon);
                    }
                });
                var rResults = inner.innerCompare(vRet1.results, vRet2.results);
                var vRet : ResultDto = {count: rResults.length , results: rResults};
                return vRet;
            }else{
                return vRet1;
            }
            
        }
    );
    //Les filtres renvoient PokeDto[]
    // const filterByType = async () => {
    //     console.log("filtering by" + typeSelected)
    //     var vRet: ResultDto = { count: 0, results: [] };
    //     var vReq = await byType.listByType(typeSelected);
    //     vReq.pokemon.forEach(poke => {
    //         vRet.count++;
    //         vRet.results.push(poke.pokemon);
    //     });
    //     setList(vRet);
    // }
    // const filterByGen = (generations: number[]) => {
    //     return async () => {
    //         var vRet: ResultDto = { count: 0, results: [] };
    //         var vReq = await byGen.listByGen(generations);
    //         vReq.forEach(gen =>
    //             gen.pokemon_species.forEach(poke => {
    //                 vRet.count++;
    //                 vRet.results.push(poke);
    //             })
    //         )
    //         return vRet;
    //     }
    // }

    return (
        <div className="flex flex-col h-full">
            <div className="flex gap-2 m-0 mb-4 items-center">
                <Select
                     mode="multiple"
                     allowClear
                     style={{ width: '100%' }}
                     placeholder="Select up to 2 types"
                     defaultValue={['normal']}
                     onChange={(value) => handleChange(value)}
                     options={selectTypeOptions}
                >
                </Select>
                <p className="m-0">Corresponding results: {list?.count}</p>
            </div>
            <div className="flex-grow">
                <FilteredList pokemons={list} />
            </div>
        </div>
    );
}
export default FilteringByType;