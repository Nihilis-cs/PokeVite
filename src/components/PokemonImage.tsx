import { useQuery } from "@tanstack/react-query";
import { Spin } from "antd";
import axios from "axios";

interface PokemonImageProps {
    id?: number;
}

function PokemonImage ({ id }: PokemonImageProps) {
    const getBase64 = (img: Blob): Promise<string> => {
        return new Promise((resolve, reject) => {
            const reader = new FileReader();
            reader.readAsDataURL(img);
            reader.onload = () => resolve(reader.result as string);
            reader.onerror = (error) => reject(error);
        });
    };

    const useImage = () => {
        return useQuery(["pokemon", "image", id], async () => {
            const vResponse = await axios.get("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/" + id + ".png", { responseType: "blob" });
            const vBase64 = await getBase64(vResponse.data);
            return vBase64;
        });
    };
    const { data: image } = useImage();

    if (id && image) {
        return <img className='grid justify-center items-center object-cover w-32 h-32 max-h-32 max-w-32' src={image} />;
    }
    else {
        return <div className='grid justify-center items-center object-cover h-32 w-32'><Spin /></div>;
    }
}

export default PokemonImage;