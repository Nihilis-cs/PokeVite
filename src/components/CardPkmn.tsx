import { Avatar, Card, Typography } from 'antd';
import { useState } from 'react';
import { idFromUrl, capitalize } from '../services/stringFunctions';
import { PokeDto } from '../type/dto.type';
import ButtonAddPkmn from './ButtonAddPkmn';

const { Title } = Typography;

interface CardPkmnProps {
    pokemon: PokeDto;
    onOpenPokemon: (id: number) => void;
    onOpenAddCollection: (id: number) => void; 
}
function CardPkmn({ pokemon, onOpenPokemon, onOpenAddCollection }: CardPkmnProps) {


    return (
        <Card hoverable onClick={() => onOpenPokemon(idFromUrl.getIdFromUrl(pokemon.url))} className="px-1 " >
            <div className='grid grid-cols-5 items-center card-pkmn p-0'>
                <Avatar src={"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/"
                    + idFromUrl.getIdFromUrl(pokemon.url) + ".png"}
                    size={64} shape="square" className="col-span-1 card-avatar overflow-visible" />
                <div className="col-span-3 text-2xl font-normal m-0 overflow-visible px-1">
                    <h4 className='text-2xl font-normal m-0'>
                        {idFromUrl.getIdFromUrl(pokemon.url) + ' - ' + capitalize.capitalizeFirstLetter(pokemon.name)}
                    </h4>
                </div>
                <div className="col-span-1 flex justify-end">
                    <ButtonAddPkmn onAdd={() => onOpenAddCollection(idFromUrl.getIdFromUrl(pokemon.url))} />
                </div>
            </div>
        </Card>
    );
}
export default CardPkmn;