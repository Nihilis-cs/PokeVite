import { PlusCircleFilled, PlusCircleOutlined } from "@ant-design/icons";
import { Button } from "antd";
import { MouseEventHandler } from "react";
import { PokeDto } from "../type/dto.type";

interface AddPokemonProps {
    onAdd: () => void;
}

function ButtonAddPkmn({onAdd }: AddPokemonProps) {

    return (
        // <Button onClick={} >
        <div className="">
            <Button className='font-normal m-0 hover:bg-slate-100 bg-slate-200 hover:border-zinc-700 border-white' 
                    shape="circle" onClick={(e) => { onAdd(); e.stopPropagation(); e.preventDefault() }}>
                <PlusCircleOutlined className="h-full" />
            </Button>
        </div>
    )
}
export default ButtonAddPkmn;