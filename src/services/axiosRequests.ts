import axios from "axios";

import { GenResultDto, ResultDto, TypeResultDto } from "../type/dto.type";
import { idFromUrl } from "./stringFunctions";


//Lists 
async function listAll(offset: number, itemsPerPage: number) {
    var vRet = await axios.get<ResultDto>("https://pokeapi.co/api/v2/pokemon-species/?limit=" + itemsPerPage + "&offset=" + offset);
    return vRet.data;
}
export const all = {
    listAll
}

async function listByType(type : string) {
    var vRet = await axios.get<TypeResultDto>("https://pokeapi.co/api/v2/type/" + type);
    return vRet.data;
}

async function getTypes() {
    var vRequest = await axios.get<ResultDto>("https://pokeapi.co/api/v2/type/");
    var vRet : ResultDto = {count: 0, results: []};
    vRequest.data.results.forEach(item => {
        if(item.name != 'unknown' && item.name != 'shadow'){
            vRet.count++;
            vRet.results.push(item);
        }
        else {
            return vRet;
        }
    });
    return vRet;
}

export const byType = {
    listByType,
    getTypes
}

async function listByGen(generation : number) {
    var vGen = await axios.get<GenResultDto>("https://pokeapi.co/api/v2/generation/" + generation);
    var vRet = await axios.get<ResultDto>("https://pokeapi.co/api/v2/pokemon-species/?limit=" + (vGen.data.pokemon_species.length) + "&offset=" + (idFromUrl.getIdFromUrl(vGen.data.pokemon_species[0].url) -1));
    
    return vRet.data;
}

async function getGens(){
    var vRet = await axios.get<ResultDto>("https://pokeapi.co/api/v2/generation");
    return vRet.data;
}

export const byGen = {
    listByGen,
    getGens    
}

