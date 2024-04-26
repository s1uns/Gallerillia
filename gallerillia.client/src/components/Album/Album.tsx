import { FC } from "react";
import styles from "./Album.module.scss";
import { Link } from "react-router-dom";
import { Button } from "../Button/Button";

export interface AlbumProps {
    id: string;
    title: string;
    imgUrl: string;
    author: string;
    authorId: string;
    canBeDeleted: boolean;
}

export const Album: FC<AlbumProps> = (props: AlbumProps) => {
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
                        Delete
                    </Button>
                    <Button
                        customStyles={styles["delete-btn"]}
                        title={"Delete album"}
                    >
                        Delete
                    </Button>
                </div>
            ) : null}
        </div>
    );
};
