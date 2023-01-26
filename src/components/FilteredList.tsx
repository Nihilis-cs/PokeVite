import { useState } from "react";
import { PokeDto, ResultDto } from "../type/dto.type";
import CardPkmn from "./CardPkmn";
import DetailsPkmn from "./DetailsPkmn";

interface FilteredListProps {
    pokemons?: ResultDto;
}

function FilteredList({ pokemons }: FilteredListProps) {

    const [currentPokemonId, setCurrentPokemonId] = useState<number>();
    const [open, setOpen] = useState<boolean>(false);
    const onOpen = (aId: number) => {
        setCurrentPokemonId(aId);
        setOpen(true);
    }

    return (
        <div className="flex flex-col h-full">
            <div className='relative flex-grow'>
                <div className='absolute inset-0 w-full h-full overflow-auto'>
                    <div className='grid gap-2 sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-5 bg-gray-100'>
                        {pokemons?.results.map(item => {
                            return (
                                <CardPkmn key={item.name} pokemon={item} onOpenPokemon={(id) => {
                                    onOpen(id);
                                }}></CardPkmn>
                            );
                        })}
                    </div>
                </div>
            </div>
            <DetailsPkmn id={currentPokemonId} open={open} onClose={() => setOpen(false)} />
        </div>
    );
}
export default FilteredList;