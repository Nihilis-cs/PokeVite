import { CheckSquareFilled } from "@ant-design/icons";
import { Button } from "antd";
import { PokeDto } from "../type/dto.type";

interface AddPokemonProps {
    pokemon: PokeDto;
}

function ButtonAddPkmn({ pokemon }: AddPokemonProps) {

    

    return (
        // <Button onClick={} >
        <Button>
            <CheckSquareFilled />
        </Button>

    )
}
export default ButtonAddPkmn;