import { Avatar, Card, Typography } from 'antd';
import { useState } from 'react';
import { idFromUrl, capitalize } from '../services/stringFunctions';
import { PokeDto } from '../type/dto.type';

const { Title } = Typography;

interface CardPkmnProps {
    pokemon: PokeDto;
    onOpenPokemon: (id: number) => void;
}
function CardPkmn({ pokemon, onOpenPokemon }: CardPkmnProps) {


    return (
            <Card hoverable onClick={() => onOpenPokemon(idFromUrl.getIdFromUrl(pokemon.url))} className="" >
                <div className='grid grid-cols-3 items-center card-pkmn p-0'>
                    <Avatar src={"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/"
                        + idFromUrl.getIdFromUrl(pokemon.url) + ".png"}
                        size={64} shape="square" className="col-span-1 card-avatar overflow-visible" />
                    <h4 className="col-span-2 align-middle text-2xl font-normal m-0">
                        {idFromUrl.getIdFromUrl(pokemon.url) + ' - ' + capitalize.capitalizeFirstLetter(pokemon.name)}
                    </h4>
                </div>
            </Card>
    );
}
export default CardPkmn;