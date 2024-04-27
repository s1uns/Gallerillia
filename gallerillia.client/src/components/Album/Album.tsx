import { FC, useState } from "react";
import styles from "./Album.module.scss";
import { Link } from "react-router-dom";
import { Button } from "../Button/Button";
import { DeleteDialogWindow } from "../DialogWindow/DeleteDialogWindow";
import { deleteAlbum } from "../../services/api";
import { toast } from "react-toastify";

export interface AlbumProps {
    id: string;
    title: string;
    imgUrl: string;
    author: string;
    authorId: string;
    canBeDeleted: boolean;
    onDelete: (isDeleted: boolean) => void ;
}

export const Album: FC<AlbumProps> = (props: AlbumProps) => {
    const onAlbumdelete = () => {
        const response = deleteAlbum(props.id);
        props.onDelete(true);
        response
            .then((data) => {
                toast.success(data);
            })
            .catch((error: any) => {
                if (error.response) {
                    toast.error(error.response.data);
                }
            });
    };
    return (
        <div className={styles["album"]}>
            <Link to={`/pictures/${props.id}`}>
                <div className={styles["container"]}>
                    <div className={styles["album__image-container"]}>
                        <img
                            className={styles["album__image"]}
                            src={
                                props.imgUrl.length > 0
                                    ? props.imgUrl
                                    : import.meta.env.VITE_BASE_ALBUM_IMG_URL
                            }
                            alt={props.title}
                        />
                    </div>

                    <div className={styles["album__description"]}>
                        <div className={styles["album__description--title"]}>
                            {props.title}
                        </div>
                        <div className={styles["album__description--author"]}>
                            Posted by {props.author}
                        </div>
                    </div>
                </div>
            </Link>
            {props.canBeDeleted ? (
                <div className={styles["manage-btns"]}>
                    <Button
                        customStyles={styles["update-btn"]}
                        title={"Delete album"}
                    >
                        Update
                    </Button>

                    <DeleteDialogWindow
                        entityName="album"
                        handleAgree={onAlbumdelete}
                        render={(handleClick) => (
                            <Button
                                customStyles={styles["delete-btn"]}
                                title={"Delete album"}
                                handleClick={handleClick}
                            >
                                Delete
                            </Button>
                        )}
                    ></DeleteDialogWindow>
                </div>
            ) : null}
        </div>
    );
};
