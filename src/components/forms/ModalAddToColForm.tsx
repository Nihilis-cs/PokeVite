import { useQuery } from "@tanstack/react-query";
import { Modal, message } from "antd";
import axios from "axios";
import { useMemo } from "react";
import { Controller, useForm } from "react-hook-form";
import { collections, pkmnDetails } from "../../services/axiosRequests";
import { CollectionPokemonDto, PokeDtoFull } from "../../type/dto.type";
import SelectCollection from "../SelectCollection";
import SelectUser from "../SelectUser";

interface AddToColProps {
    id?: number;
    open: boolean;
    onClose: () => void;
    onAdd: (pkmnName : string) => void;
}

function ModalAddToColForm({ id, open, onClose, onAdd }: AddToColProps) {
    const { control, watch, handleSubmit } = useForm<CollectionPokemonDto>({});
    const user = watch("userId");
    const { data: pokemon } = useQuery<PokeDtoFull>(["pokemon", "details", id],
        async () => {
            var vRes = pkmnDetails.getPokeDto(id!);
            return vRes;
        }, { enabled: open }
    );
    const title = useMemo(() => {
        return ("Add " + pokemon?.name + " to a collection")
    }, [pokemon]);

    const onSubmit = async (data: CollectionPokemonDto) => {
        data.pokemonName = pokemon?.name!;
        await collections.addPokemonToCollection(data);
        onAdd(pokemon?.name!);
        onClose();
    }


    return (
        <form >
            <Modal title={title} key={id} open={open} onOk={handleSubmit(onSubmit)} onCancel={onClose} closable={false}
                okButtonProps={{ htmlType: "submit" }}
            >

                <Controller
                    control={control}
                    name="userId"
                    rules={{ required: true }}
                    render={({ field }) => <SelectUser {...field} />}
                />
                <Controller
                    control={control}
                    name="collectionId"
                    render={({ field }) => <SelectCollection  {...field} userId={user} />}
                />

            </Modal>
        </form>
    )
}
export default ModalAddToColForm;