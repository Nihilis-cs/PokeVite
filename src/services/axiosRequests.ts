import axios from "axios";

import { CollectionDto, CollectionFullDto, CollectionIdDto, CollectionPokemonDto, GenResultDto, PokeDto, PokeDtoFull, ResultDto, TypeResultDto, UserDto } from "../type/dto.type";
import { idFromUrl } from "./stringFunctions";

export const all = {
    listAll
}
export const byType = {
    listByType,
    getTypes
}
export const byGen = {
    listByGen,
    getGens
}
export const byUser = {
    listByUser,
    getUsers
}
export const collections = {
    createCollection,
    listCollectionByUser,
    collectionById,
    updateCollection,
    addPokemonToCollection,
}
export const pkmnDetails = {
    getPokeDto
}

//Lists 
async function listAll(offset: number, itemsPerPage: number) {
    var vRet = await axios.get<ResultDto>("https://pokeapi.co/api/v2/pokemon-species/?limit=" + itemsPerPage + "&offset=" + offset);
    return vRet.data;
}

async function listByType(type: string) {
    var vRet = await axios.get<TypeResultDto>("https://pokeapi.co/api/v2/type/" + type);
    return vRet.data;
}

async function getTypes() {
    var vRequest = await axios.get<ResultDto>("https://pokeapi.co/api/v2/type/");
    var vRet: ResultDto = { count: 0, results: [] };
    vRequest.data.results.forEach(item => {
        if (item.name != 'unknown' && item.name != 'shadow') {
            vRet.count++;
            vRet.results.push(item);
        }
        else {
            return vRet;
        }
    });
    return vRet;
}


async function listByGen(generation: number) {
    var vGen = await axios.get<GenResultDto>("https://pokeapi.co/api/v2/generation/" + generation);
    var vRet = await axios.get<ResultDto>("https://pokeapi.co/api/v2/pokemon-species/?limit=" + (vGen.data.pokemon_species.length) + "&offset=" + (idFromUrl.getIdFromUrl(vGen.data.pokemon_species[0].url) - 1));

    return vRet.data;
}

async function getGens() {
    var vRet = await axios.get<ResultDto>("https://pokeapi.co/api/v2/generation");
    return vRet.data;
}


async function getUsers() {
    var vRet = await axios.get<UserDto[]>("https://localhost:5001/User/all");
    return vRet.data;
}
async function listByUser(aUserId: string) {
    var vRet = await axios.get<PokeDto[]>("https://localhost:5001/Pokemon/" + aUserId);
    return vRet.data;
}

async function createCollection(aDto: CollectionDto) {
    var vRet = await axios.post<CollectionDto>('https://localhost:5001/Collection/new', aDto);
    return vRet.data;
}
async function listCollectionByUser(aUserId: string) {
    var vRet = await axios.get<CollectionIdDto[]>('https://localhost:5001/Collection/all/?userId=' + aUserId);
    return vRet.data;
}
async function collectionById(aColId?: string) {
    var vRet = await axios.get('https://localhost:5001/Collection/' + aColId);
    return vRet.data;
}
async function updateCollection(aCollection: CollectionFullDto) {

}

async function addPokemonToCollection(aCollection : CollectionPokemonDto )
{
    var vRet = await axios.post<string>("https://localhost:5001/Collection/pokemon/add", {pokemonName : aCollection.pokemonName, collectionId: aCollection.collectionId});
    return vRet.data;
}

async function getPokeDto(aId: number) {
    var vRet = await axios.get<PokeDtoFull>("https://pokeapi.co/api/v2/pokemon/" + aId);
    return vRet.data;
}

