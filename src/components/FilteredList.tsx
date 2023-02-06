import { message } from "antd";
import { useState } from "react";
import { idFromUrl } from "../services/stringFunctions";
import { PokeDto, ResultDto } from "../type/dto.type";
import CardPkmn from "./CardPkmn";
import DetailsPkmn from "./DetailsPkmn";
import ModalAddToColForm from "./forms/ModalAddToColForm";

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
    const [openCol, setOpenCol] = useState<boolean>(false);
    const onOpenCol = (aId: number) => {
        setCurrentPokemonId(aId);
        setOpenCol(true);
    }
    const [messageApi, contextHolder] = message.useMessage();
    const success = (aMessage: string) => {
        messageApi.open({
          type: 'success',
          content: aMessage,
        });
      };

    return (
        <div className="flex flex-col h-full">
            {contextHolder}
            <div className='relative flex-grow'>
                <div className='absolute inset-0 w-full h-full overflow-auto'>
                    <div className='grid gap-2 sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-5 bg-gray-100'>
                        {pokemons?.results.length == 0 && <h1>No pokemons here</h1>}
                        {pokemons?.results.map(item => {
                            return (
                                <CardPkmn key={item.name} pokemon={item} onOpenPokemon={(id) => { onOpen(id); }} onOpenAddCollection={(id) => {onOpenCol(id)}}></CardPkmn>
                            );
                        })}
                    </div>
                </div>
            </div>
            <DetailsPkmn id={currentPokemonId} open={open} onClose={() => setOpen(false)} />
            <ModalAddToColForm id={currentPokemonId} open={openCol} onClose={() => setOpenCol(false)} onAdd={(pkmn) => success(pkmn + " successfully added to collection")} />
        </div>
    );
}
export default FilteredList;