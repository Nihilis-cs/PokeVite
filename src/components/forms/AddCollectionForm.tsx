
import { useForm, Controller } from "react-hook-form";
import { Button, Input } from 'antd';
import { CollectionDto } from "../../type/dto.type";
import SelectUser from "../SelectUser";
import { collections } from "../../services/axiosRequests";

function AddCollectionForm() {
    const { control, handleSubmit, formState } = useForm<CollectionDto>({

    });
    const onSubmit = async (data: CollectionDto) => {
        var vDto = await collections.createCollection(data);
        return vDto;
    }
    return (
        <>
            <div>
                <h1>Create a Collection</h1>
            </div>
            <form onSubmit={handleSubmit(onSubmit)}>
                <div className="grid grid-cols-3 gap-4">
                    <div className="col-span-2">
                        <Controller
                            control={control}
                            name="name"
                            rules={{ required: true }}
                            render={({ field, fieldState }) =>
                                <>
                                    <Input placeholder="Name of the collection" allowClear {...field} maxLength={25} />
                                    {fieldState.error && <div>{fieldState.error.message}</div>}
                                </>}
                        />
                    </div>
                    <div className="col-span-1">
                        <Controller
                            control={control}
                            name="userId"
                            rules={{ required: true }}
                            render={({ field, fieldState }) =>
                                <SelectUser {...field} />
                            }
                        />
                    </div>
                    <div className="col-span-3">
                        <Controller
                            control={control}
                            name="description"
                            rules={{ required: false }}
                            render={({ field, fieldState }) =>
                                <>
                                    <Input.TextArea rows={3} placeholder="Description of the collection" allowClear {...field}
                                        showCount maxLength={100} /*style={{ resize: "none" }}*/ className="resize-none" />
                                    {fieldState.error && <div>{fieldState.error.message}</div>}
                                </>}
                        />
                    </div>
                </div>
                {formState.isValid &&
                    <Button type="primary" htmlType="submit">
                        Submit
                    </Button>
                }
                {!formState.isValid &&
                    <Button type="dashed" htmlType="submit">
                        Submit
                    </Button>}
            </form>
        </>
    )
}
export default AddCollectionForm;