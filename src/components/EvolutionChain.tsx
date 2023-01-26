import { useQuery } from "@tanstack/react-query";
import { Avatar, Spin } from "antd";
import axios from "axios";
import { idFromUrl } from "../services/stringFunctions";
import { EvolutionChainDto, EvolutionToDto } from "../type/dto.type";

interface EvolutionChainProps {
    url?: string;
    onChangePokemon: (poke: number) => void;
}

function EvolutionChain({ url, onChangePokemon }: EvolutionChainProps) {
    const { data: evoChain } = useQuery<EvolutionChainDto>(["pokemon", "evolutionChain", url],
        async () => {
            var vRet = await axios.get<EvolutionChainDto>(url!);
            return vRet.data;
        }, { enabled: url != null }
    );
    const getEvolutions = (aEvo: EvolutionToDto, aChild: string[]): string[] => {
        if (aEvo.evolves_to) {
            aEvo.evolves_to.forEach(evo => {
                aChild.push(evo.species.url);
                if (evo.evolves_to) {
                    aChild = getEvolutions(evo, aChild);
                }
            })
        }
        return aChild;
    }

    if (evoChain) {
        return (
            <div className="relative h-20">
                <div className="absolute inset-0 ">
                    <div className='flex justify-center'>
                        <Avatar size={64} src=
                            {"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + idFromUrl.getIdFromUrl(evoChain?.chain?.species?.url!) + ".png"}
                            onClick={() => {onChangePokemon(idFromUrl.getIdFromUrl(evoChain?.chain?.species?.url!))}} className="hover:shadow" />
                        {getEvolutions(evoChain?.chain!, []).map((item => {
                            return (
                                <Avatar size={64} src=
                                    {"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + idFromUrl.getIdFromUrl(item) + ".png"} 
                                    onClick={() => {onChangePokemon(idFromUrl.getIdFromUrl(item))}} className="hover:shadow" />
                            );
                        }))}
                    </div>
                </div>
            </div>
        )
    }
    return <div className='h-20 w-full'><Spin delay={1000} /></div>;
}

export default EvolutionChain;