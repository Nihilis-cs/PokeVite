import { useQuery } from "@tanstack/react-query";
import { useParams } from "react-router-dom";
import { collections } from "../services/axiosRequests";
import { CollectionFullDto, ResultDto } from "../type/dto.type";
import FilteredList from "./FilteredList";
import UpdateCollectionForm from "./forms/UpdateCollectionForm";

function DetailsList() {
    const { colid } = useParams();
    const { isLoading, data: collection } = useQuery<CollectionFullDto>(["collection", colid],
        async () => {
            var vRet = collections.collectionById(colid);
            return vRet;
        }
    );
    const { data: pokemons } = useQuery<ResultDto>(["list", collection],
        async () => {
            var vRet: ResultDto = { count: 0, results: [] };
            collection?.pokemons.forEach(poke => {
                vRet.results.push(poke);
                vRet.count++;
            });

            return vRet;
        }
    );


    return (
        <>
            <div className="grid grid-cols-4 h-full gap-4">
                <div className="flex flex-col">
                    <div className="flex flex-col justify-center text-center">
                        <h1 className="text-2xl">{collection?.name}</h1>
                        <p>{collection?.description ? collection.description : 'No description'}</p>
                    </div>
                    <div className="h-full">
                        <UpdateCollectionForm collection={collection} />
                    </div>
                </div>
                <div className="col-span-3 ">
                    <FilteredList pokemons={pokemons} />
                </div>
            </div>

        </>
    )
}
export default DetailsList;