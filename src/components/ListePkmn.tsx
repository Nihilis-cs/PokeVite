import { useQuery } from '@tanstack/react-query';
import { Pagination, Spin } from 'antd';
import axios from 'axios';
import { useState } from 'react';
import { all } from '../services/axiosRequests';
import { ResultDto } from '../type/dto.type';
import CardPkmn from './CardPkmn';
import DetailsPkmn from './DetailsPkmn';
import FilteredList from './FilteredList';

interface FilterPokemom {
    page: number;
    itemsPerPage: number;
}

function ListePkmn() {
    const [filter, setFilter] = useState<FilterPokemom>({ page: 1, itemsPerPage: 50 });
    const onChange = (page: number, pageSize: number) => {
        setFilter({ ...filter, page: page, itemsPerPage: pageSize });
    }

    const { isLoading, data: pokemons } = useQuery<ResultDto>(["pokemon", "list", filter],
        async () => {
            var offset = (filter.page - 1) * filter.itemsPerPage;
            var vRet = all.listAll(offset, filter.itemsPerPage);
            return vRet;
        }
    );

    return (
        <div className='flex flex-col w-full h-full'>
            {isLoading && <div><Spin></Spin></div>}
            <div className='grid p-2 justify-center'>
                <Pagination current={filter.page}
                    pageSize={filter.itemsPerPage}
                    total={pokemons?.count}
                    onChange={onChange}
                />
            </div>
            <FilteredList pokemons={pokemons}></FilteredList>
        </div>
    );
}
export default ListePkmn;