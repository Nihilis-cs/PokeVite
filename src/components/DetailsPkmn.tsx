import { Modal, Image, Typography, Skeleton, Divider, Progress, Select, Form, Avatar, Spin } from 'antd';
import { PokeDtoFull, DetailsDto, PokeDtoSpecies, ListDto, EvolutionChainDto, EvolutionToDto, StatDto } from '../type/dto.type';
import axios from 'axios';
import { useQuery } from '@tanstack/react-query';
import { capitalize, idFromUrl } from '../services/stringFunctions';
import { useState } from 'react';
import { LeftOutlined, RightOutlined } from '@ant-design/icons';
import { useConditionalEffect } from '@react-hookz/web';
import CarouselPkmnImg from './CarouselPkmnImg';
import PokemonImage from './PokemonImage';
import StatPokemon from './StatPokemon';
import FlavorText from './FlavorText';
import EvolutionChain from './EvolutionChain';


interface DetailsPkmnProps {
    id?: number;
    open: boolean;
    onClose: () => void;
}


function DetailsPkmn({ id, open, onClose }: DetailsPkmnProps) {
    const [pokemonId, setpokemonId] = useState<number>();

    const { isLoading, data: pokemon } = useQuery<PokeDtoFull>(["pokemon", "details", pokemonId],
        async () => {
            var vRet = await axios.get<PokeDtoFull>("https://pokeapi.co/api/v2/pokemon/" + pokemonId);
            return vRet.data;
        }, { enabled: open }
    );

    useConditionalEffect(() => {
        setpokemonId(id);
    }, [open, id], [open && id]);


    const { data: pokemonSpecies } = useQuery<PokeDtoSpecies>(["pokemon", "flavor", pokemon?.id],
        async () => {
            var vRetF = await axios.get<PokeDtoSpecies>("https://pokeapi.co/api/v2/pokemon-species/" + pokemon?.id);
            return vRetF.data;
        }, { enabled: pokemon != null }
    );

    const previousId = () => {
        var vRet: number = pokemon?.id! - 1;
        return vRet;
    };

    const nextId = () => {
        var vRet: number = pokemon?.id! + 1;
        return vRet;
    };

    const toNext = () => {
        setpokemonId(nextId());
    }

    const toPrevious = () => {
        setpokemonId(previousId());
    }

    return (
        <Modal key={id} open={open} onOk={onClose} onCancel={onClose} footer={false}>
            <>
                <div className='flex divide-y-0 divide-x divide-solid h-134 divide-gray-200'>
                    <div className='pr-2 max-h-32'> {/*Image*/}
                        <PokemonImage id={pokemon?.id} />
                    </div>
                    <div className='grow pl-5'> {/*Infos*/}
                        <div className='flex flex-col'>
                            <div className="font-semibold text-3xl pb-2">{pokemon?.id} - {pokemonSpecies && capitalize.capitalizeFirstLetter(pokemonSpecies.name)}</div>
                            <div className='flex gap-2 pb-2'>
                                <div className='font-semibold text-xl'>Types:</div>
                                <div className='flex gap-2'>
                                    {pokemon?.types?.map(item => {
                                        return (
                                            <div className='font-semibold italic text-xl'>{item.type.name}</div>
                                        );
                                    })}
                                </div>
                            </div>
                            <div className='flex gap-2'>
                                <div className='font-semibold'>Height : </div>
                                <div className='font-semibold italic'>{pokemon?.height}</div>
                            </div>
                            <div className='flex gap-2'>
                                <div className='font-semibold'>Weight : </div>
                                <div className='font-semibold italic'>{pokemon?.weight}</div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className='flex gap-2 border-solid border-0 border-t border-gray-200'>
                    <div className='mt-2'> {/*Stats*/}
                        <StatPokemon stat={pokemon?.stats[0]} />
                        <StatPokemon stat={pokemon?.stats[1]} />
                        <StatPokemon stat={pokemon?.stats[2]} />
                        <StatPokemon stat={pokemon?.stats[3]} />
                        <StatPokemon stat={pokemon?.stats[4]} />
                        <StatPokemon stat={pokemon?.stats[5]} />
                    </div>
                    <div className='w-full flex flex-col'>
                        <div className='h-20 w-full mb-6'>

                            <h3 className='mt-2 mb-0'>Evolution chain</h3>
                            {pokemonSpecies?.evolution_chain &&
                                <EvolutionChain url={pokemonSpecies.evolution_chain.url} onChangePokemon={(poke) => { setpokemonId(poke) }} />
                            }
                        </div>
                        <div className='h-20 w-full mb-8'>
                            <h3 className='mt-0 mb-0'>Varieties</h3>
                            {pokemonSpecies &&
                                <CarouselPkmnImg content={pokemonSpecies.varieties} onChangePokemon={(poke) => { setpokemonId(poke) }}/>
                            }
                        </div>
                        <div className='h-40 w-full mb-8'>
                            <h3 className='mt-0 mb-2'>Description</h3>
                            <FlavorText pokemonSpecies={pokemonSpecies} />
                        </div>
                    </div>
                </div>
                <div className='border-solid border-0 border-t border-gray-200'>
                    <div className='flex flex-row mt-2 first-letter'>
                        <div className='flex flex-row' onClick={() => { toPrevious() }}>
                            <LeftOutlined style={{ fontSize: '250%', alignSelf: 'center' }} className="flex" />
                            <Avatar src={"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/"
                                + previousId() + ".png"}
                                size={64} className="flex border border-gray-200" />
                        </div>
                        <div className='flex flex-grow'></div>
                        <div className='flex flex-row'>
                            <Avatar src={"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/"
                                + pokemon?.id + ".png"}
                                size={64} className="flex border border-gray-400" />
                        </div>
                        <div className='flex flex-grow'></div>
                        <div className='flex flex-row' onClick={() => { toNext() }} >
                            <Avatar src={"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/"
                                + nextId() + ".png"}
                                size={64} className="flex border border-gray-200" />
                            <RightOutlined style={{ fontSize: '250%', alignSelf: 'center' }} className="flex" />
                        </div>
                    </div>
                </div>
            </>
        </Modal >
    );
}
export default DetailsPkmn;