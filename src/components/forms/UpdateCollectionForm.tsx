import { Input, Button } from "antd";
import { useEffect } from "react";
import { Controller, useForm } from "react-hook-form";
import { collections } from "../../services/axiosRequests";
import { CollectionFullDto } from "../../type/dto.type";


interface UpdateCollectionProps {
    collection?: CollectionFullDto;
}

function UpdateCollectionForm({ collection }: UpdateCollectionProps) {
    const { control, reset, handleSubmit, formState } = useForm<CollectionFullDto>({});
    const onSubmit = async (data: CollectionFullDto) => {
        alert(data?.name);
        var vDto = await collections.updateCollection(data);
        return vDto;
    }

    useEffect(() => {
        reset(collection);
    }, [collection]);

    return (<>
        <form onSubmit={handleSubmit(onSubmit)}>
            <div className="flex flex-col gap-4">
                <div className="">
                    <Controller
                        control={control}
                        name="name"
                        rules={{ required: true }}
                        render={({ field }) =>
                            <>
                                <Input placeholder="Name of the collection" allowClear maxLength={25} {...field} />
                            </>}
                    />
                </div>
                <div className="">
                    <Controller
                        control={control}
                        name="description"
                        rules={{ required: false }}
                        render={({ field, fieldState }) =>
                            <>
                                <Input.TextArea rows={3} placeholder="Description of the collection" allowClear {...field}
                                    showCount maxLength={100} style={{ resize: "none" }} />
                                {fieldState.error && <div>{fieldState.error.message}</div>}
                            </>}
                    />
                </div>
                <div className="justify-center text-center">
                    {formState.isValid &&
                        <Button type="primary" htmlType="submit" className="w-full">
                            Update
                        </Button>
                    }
                    {!formState.isValid &&
                        <Button type="dashed" htmlType="submit" className="w-full">
                            Update
                        </Button>}
                </div>
            </div>
        </form>

    </>)
}

export default UpdateCollectionForm;