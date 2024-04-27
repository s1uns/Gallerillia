import { FC, useState } from "react";
import styles from "./Album.module.scss";
import { Link } from "react-router-dom";
import { Button } from "../Button/Button";
import { DeleteDialogWindow } from "../DialogWindow/DeleteDialogWindow";
import { deleteAlbum, updateAlbum } from "../../services/api";
import { toast } from "react-toastify";
import { IAlbumProps } from "../../types/interfaces";
import { TitleDialogWindow } from "../DialogWindow/TitleDialogWindow";

export const Album: FC<IAlbumProps> = (props: IAlbumProps) => {
    const [newTitle, setNewTitle] = useState("");

    const onAlbumDelete = () => {
        const response = deleteAlbum(props.id);
        response
            .then((data) => {
                toast.success(data);
            })
            .catch((error: any) => {
                if (error.response) {
                    toast.error(error.response.data);
                }
            });
        props.onChange(true);
    };

    const onAlbumUpdate = () => {
        if (newTitle.trim().length < 5 || newTitle.trim().length > 19) {
            toast.error(
                "The album title should be between 5 and 50 characters long"
            );
            return;
        }
        const response = updateAlbum({ Id: props.id, title: newTitle });
        response
            .then((data) => {
                toast.success(data);
            })
            .catch((error: any) => {
                if (error.response) {
                    toast.error(error.response.data);
                }
            });
        props.onChange(true);
    };

    const updateTitleInput = (e: React.ChangeEvent<HTMLInputElement>) => {
        setNewTitle((oldTitle) => e.target.value);
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
            {props.canBeManaged ? (
                <div className={styles["manage-btns"]}>
                    <TitleDialogWindow
                        entityName="album"
                        handleAgree={onAlbumUpdate}
                        currentValue={newTitle}
                        onChangeValue={updateTitleInput}
                        render={(handleClick) => (
                            <Button
                                customStyles={styles["update-btn"]}
                                title={"Update album"}
                                handleClick={handleClick}
                            >
                                Update
                            </Button>
                        )}
                    ></TitleDialogWindow>

                    <DeleteDialogWindow
                        entityName="album"
                        handleAgree={onAlbumDelete}
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
