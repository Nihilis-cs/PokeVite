import { Progress } from "antd";
import { capitalize } from "../services/stringFunctions";
import { StatDto } from "../type/dto.type";

function StatPokemon ({ stat }: { stat?: StatDto }) {
    // Pour les jauges de statistiques
    const getColor = (stat?: number) => {
        if (stat) {
            let vH: number = 100 - ((1 - stat / 150) * 100);
            return `hsl(${vH}, 95%, 50%)`;
        }
        return undefined;
    }

    return <div>
        <div className='w-32 h-auto'>{stat ? `${capitalize.capitalizeFirstLetter(stat.stat.name)}: ${stat.base_stat}` : "Loading data..."}</div>
        <Progress percent={stat ? (stat.base_stat * 100 / 200) : 0}
            strokeColor={getColor(stat?.base_stat)}
            showInfo={false} />
    </div>
}
export default StatPokemon;