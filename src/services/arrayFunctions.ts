import { VerticalRightOutlined } from "@ant-design/icons";
import { PokeDto } from "../type/dto.type";

function innerCompare(arr1 : PokeDto[], arr2 : PokeDto[]): PokeDto[]  {
    var vRet : PokeDto[] = [];
    arr1.forEach(item1 => {
        arr2.forEach(item2 => {
            if (item1.name == item2.name){
                vRet.push(item1)
            }
        })
    })
    return vRet;
}

export const inner ={
    innerCompare
}