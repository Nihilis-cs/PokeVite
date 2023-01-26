import { useQuery } from "@tanstack/react-query";
import { Select, Spin } from "antd";
import { DefaultOptionType } from "antd/es/select";
import axios from "axios";
import { ReactNode, useMemo, useState } from "react";
import { capitalize } from "../services/stringFunctions";
import { DetailsDto, ListDto, PokeDtoSpecies } from "../type/dto.type";

interface FlavorTextProps {
    pokemonSpecies?: PokeDtoSpecies;
}
interface SelectedFlavor {
    version: string;
    language: string;
}


function FlavorText({ pokemonSpecies }: FlavorTextProps) {
    //Pour les flavor text
    const [selectedFlavor, setSelectedFlavor] = useState<SelectedFlavor>({ version: "red", language: "en" });
    const onChangeVersion = (value: string) => {
        setSelectedFlavor({ ...selectedFlavor, version: value });
    }
    const onChangeLanguage = (value: string) => {
        setSelectedFlavor({ ...selectedFlavor, language: value });
    }
    const text = useMemo<string | ReactNode>(() => {
        var vRet = pokemonSpecies?.flavor_text_entries?.find(x => x.language.name == (selectedFlavor.language) && x.version.name == (selectedFlavor.version));
        if (vRet) { return vRet?.flavor_text; }
        else {return 'No Data'}
    }, [selectedFlavor.language, selectedFlavor.version, open, pokemonSpecies]);
    const { data: pokemonGames } = useQuery<DetailsDto[]>(["pokemon", "games"],
        async () => {
            var vGames = await axios.get<ListDto>("https://pokeapi.co/api/v2/version/?offset=0&limit=100");
            return vGames.data.results;
        }, { enabled: pokemonSpecies != null }
    );
    //Pour les select
    const gamesOptions = useMemo<DefaultOptionType[]>(() => {
        var vRet: DefaultOptionType[] = [];
        pokemonGames?.forEach(g => vRet.push({ label: capitalize.capitalizeFirstLetter(g.name), value: g.name }));
        return vRet;
    }, [pokemonGames, pokemonSpecies]);

    const languagesOptions: DefaultOptionType[] = [{ label: "Français", value: "fr" }, { label: "English", value: "en" }];

    return (
        <div>
            <div className='flex '> {/*FlavorText*/}
                <Select options={gamesOptions} className="w-full" onChange={onChangeVersion} value={selectedFlavor.version} />
                <Select options={languagesOptions} className="w-full" onChange={onChangeLanguage} value={selectedFlavor.language} />
            </div>
            <p className='m-2'>{text}</p>

        </div>
    )
}

export default FlavorText;