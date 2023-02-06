export type PokeDto = {
    name: string;
    url: string;
}

export type ResultDto = {
    count: number;
    results: PokeDto[];
}

export type TypeResultDto = {
    name: string;
    pokemon: [
        { pokemon: PokeDto }
    ];
}

export type GenResultDto = {
    main_region: DetailsDto;
    id: number;
    pokemon_species: PokeDto[];
}

export type PokeDtoFull = {
    id: number;
    name: string;
    url: string;
    types: TypesDto[];
    height: number;
    weight: number;
    abilities: DetailsDto[];
    moves: DetailsDto[];
    stats: StatDto[];
}

export type StatDto = {
    base_stat: number;
    stat: DetailsDto;
}

export type DetailsDto = {
    name: string;
}
export type TypesDto = {
    slot: number;
    type: DetailsDto;
}
export type PokeDtoSpecies = {
    name: string;
    flavor_text_entries: FlavorDto[];
    evolution_chain: { url: string };
    evolves_from_species: PokeDto;
    varieties: VarietiesDto[]
}

export type EvolutionToDto = {
    species: PokeDto, // 2
    evolves_to: EvolutionToDto[]
}

export type EvolutionChainDto = {
    id: number;
    chain: EvolutionToDto;
}
export type FlavorDto = {
    flavor_text: string;
    language: DetailsDto;
    version: DetailsDto;
}

export type ListDto = {
    count: number;
    results: DetailsDto[];
}
export type VarietiesDto = {
    pokemon: PokeDto;
}

export type UserDto = {
    name: string;
    id: string;
}

export type CollectionDto = {
    name: string;
    description: string;
    userId: string;
}
export type CollectionIdDto = {
    name: string;
    description: string;
    userId: string;
    colId: string;
}
export type CollectionFullDto = {
    name: string;
    description: string;
    userId: string;
    colId: string;
    pokemons: PokeDto[];
}
export type CollectionPokemonDto = {
    pokemonName : string;
    collectionId: string;
    userId: string;
}