import { useState } from "react";
import ImageUploading from "react-images-uploading";
import { Button } from "../Button/Button";
import styles from "./UploadImage.module.scss";

export default function UploadImage() {
    const [picture, setPicture] = useState<any[]>([]);

    const onChange = (imageList: any[]) => {
        setPicture(imageList);
    };
    return (
        <ImageUploading
            multiple={false}
            value={picture}
            onChange={onChange}
            maxNumber={1}
            dataURLKey="data_url"
        >
            {({
                imageList,
                onImageUpload,
                onImageUpdate,
                onImageRemove,
                isDragging,
                dragProps,
            }) => (
                <div className="upload__image-wrapper">
                    <Button
                        customStyles={styles["pic-btn"]}
                        handleClick={onImageUpload}
                        title="Add Picture"
                        {...dragProps}
                    >
                        Click to add picture
                    </Button>
                    &nbsp;
                    {imageList.map((image, index) => (
                        <div key={index} className="image-item">
                            <img
                                className={styles["pic"]}
                                src={image["data_url"]}
                                alt=""
                                width="2.5%"
                                height="2.5%"
                            />
                            <div className="image-item__btn-wrapper">
                                <Button
                                    customStyles={styles["pic-btn"]}
                                    handleClick={() => onImageUpdate(index)}
                                    title={"Update Picture"}
                                >
                                    Update
                                </Button>
                                <Button
                                    customStyles={styles["pic-btn"]}
                                    handleClick={() => onImageRemove(index)}
                                    title={"Remove Picture"}
                                >
                                    Remove
                                </Button>
                            </div>
                        </div>
                    ))}
                </div>
            )}
        </ImageUploading>
    );
}
