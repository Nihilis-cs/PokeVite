import { Avatar, Button } from "antd";
import { VarietiesDto } from "../type/dto.type";
import { idFromUrl } from '../services/stringFunctions';
import { useState, useMemo } from "react";
import { LeftOutlined, RightOutlined } from "@ant-design/icons";


interface CarouselPkmnProps {
    content: VarietiesDto[];
    onChangePokemon: (poke: number) => void;
}

function CarouselPkmnImg({ content, onChangePokemon }: CarouselPkmnProps) {
    const [current, setCurrent] = useState<number>(0);
    const positions = useMemo<number[]>(() => {
        var vRet: number[] = [];
        for (let i = 0; i < content.length; i++) {
            vRet.push(i * 192);
        }
        return vRet;
    }, [content]);
    const doNext = () => {
        var vCurrent = current + 1;
        if (vCurrent > positions.length - 1) {
            vCurrent = 0;
        }
        setCurrent(vCurrent);
    }
    const doPrev = () => {
        var vCurrent = current - 1;
        if (vCurrent < 0) {
            vCurrent = positions.length - 1;
        }
        setCurrent(vCurrent);
    }
    const hidden = useMemo<boolean>(() => {
        if (content.length > 1) return false;
        else {
            setCurrent(0);
            return true;
        }
    }, [content]);

    return (
        <div className="flex flex-row items-center h-20 w-full" >
            <Button onClick={() => doPrev()} style={{ visibility: hidden ? 'hidden' : 'visible' }}><LeftOutlined /></Button>
            <div className="flex relative overflow-hidden h-20 w-48 m-auto ">
                <div className="flex h-20 w-48">
                    <div className="h-20 w-4 z-10 carousel-shadow bg-white"></div>
                    <div className="grow z-0"></div>
                    <div className="h-20 w-4 z-10 carousel-shadow bg-white"></div>
                </div>
                <div className="absolute flex transition delay-75 duration-500 ease-in-out z-5" style={{ transform: `translateX(${-positions[current]}px)` }}>
                    {content.map((item) => {
                        return <div className="grid w-48 justify-center" >
                            <Avatar shape="square" size={80} src=
                                {"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + idFromUrl.getIdFromUrl(item.pokemon.url) + ".png"}
                                onClick={() => {onChangePokemon(idFromUrl.getIdFromUrl(item.pokemon.url))}} className=" hover:shadow-lg" 
                            />
                        </div>
                    }
                    )}
                </div>
            </div>
            <Button onClick={() => doNext()} style={{ visibility: hidden ? 'hidden' : 'visible' }}><RightOutlined /></Button>
        </div >
    );
};

export default CarouselPkmnImg;