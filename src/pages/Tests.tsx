import { Button } from "antd";
import axios from "axios";
import { all } from "../services/axiosRequests";
import CollectionList from "../components/CollectionList";
import AddCollectionForm from "../components/forms/AddCollectionForm";

function Tests() {

    
    return (
        <>
            <div className="grid grid-cols-2 gap-4 h-full">
                <div>
                    <AddCollectionForm />
                </div>
                <div>
                    <CollectionList />
                </div>

            </div>

        </>
    )
}
export default Tests;