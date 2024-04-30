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
    const [newAlbumTitle, setNewAlbumTitle] = useState(props.title);

    const onAlbumDelete = () => {
        const response = deleteAlbum(props.id);
        response
            .then((data) => {
                toast.success(data);
                props.onChange(true);
            })
            .catch((error: any) => {
                if (error.response) {
                    toast.error(error.response.data);
                }
            });
        props.onChange(false);
    };

    const onAlbumUpdate = () => {
        if (
            newAlbumTitle.trim().length < 3 ||
            newAlbumTitle.trim().length > 19
        ) {
            toast.error(
                "The album title should be between 3 and 19 characters long"
            );
            return;
        }

        if (newAlbumTitle == props.title) {
            return;
        }

        const response = updateAlbum({ Id: props.id, title: newAlbumTitle });
        response
            .then((data) => {
                toast.success(data);
                props.onChange(true);
            })
            .catch((error: any) => {
                if (error.response) {
                    toast.error(error.response.data);
                }
            });
        setNewAlbumTitle("");

        props.onChange(false);
    };

    const updateTitleInput = (e: React.ChangeEvent<HTMLInputElement>) => {
        setNewAlbumTitle((oldTitle) => e.target.value);
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
                        handleClose={() => setNewAlbumTitle(props.title)}
                        currentValue={newAlbumTitle}
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
